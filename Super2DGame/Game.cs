using Super2DGame.Models;

namespace Super2DGame
{
    public partial class Game : Form
    {
        private Random _random;
        private Array _directions;
        private Tank _player;
        private List<Bullet> _bullets;
        private List<Tank> _enemyTanks;
        private System.Windows.Forms.Timer _gameTimer;
        private int _timerCounter;

        public Game()
        {
            InitializeComponent();
            this.Text = "Tank Game";
            this.Size = new Size(600, 600);
            this.KeyDown += TankGame_KeyDown;
            _random = new Random();
            _directions = Enum.GetValues(typeof(Directions));
            _bullets = new List<Bullet>();
            _enemyTanks = new List<Tank>();
            _gameTimer = new System.Windows.Forms.Timer();
            _timerCounter = 0;
            _gameTimer.Interval = 16;
            _gameTimer.Tick += GameTimer_Tick;
            InitializeGame();
            _gameTimer.Start();
        }

        private void InitializeGame()
        {
            _player = new Tank(@"Resources\Images\player.png", 30, 10, 5, new Point(this.ClientSize.Width / 2, this.ClientSize.Height - 100), Directions.Top);
            this.Controls.Add(_player.TankEntity);
            for (int i = 0; i < 3; i++)
            {
                SpawnNewEnemyTank();
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (_timerCounter == 80)
            {
                RandomRotateAllEnemyTanks();
                _timerCounter = 0;
            }

            MoveBullets();
            MoveEnemyTanks();
            CheckCollisions();
            _player.UpdateReloadTimeout();
            foreach (var enemies in _enemyTanks)
            {
                enemies.UpdateReloadTimeout();
            }

            _timerCounter++;
        }

        private void SpawnNewEnemyTank()
        {
            var enemyTank = new Tank(@"Resources\Images\enemy.png", 30, 2, 15, new Point(_random.Next(0, this.ClientSize.Width - 50), 10), Directions.Bottom);
            _enemyTanks.Add(enemyTank);
            this.Controls.Add(enemyTank.TankEntity);
        }

        private void TankGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && _player.TankEntity.Left > 0)
            {
                _player.MoveTank(Directions.Left);
            }

            if (e.KeyCode == Keys.D && _player.TankEntity.Right < this.ClientSize.Width)
            {
                _player.MoveTank(Directions.Right);
            }

            if (e.KeyCode == Keys.W && _player.TankEntity.Top > 0)
            {
                _player.MoveTank(Directions.Top);
            }

            if (e.KeyCode == Keys.S && _player.TankEntity.Bottom < this.ClientSize.Height)
            {
                _player.MoveTank(Directions.Bottom);
            }

            if (e.KeyCode == Keys.Space && _player.IsCanFire)
            {
                Bullet bullet = _player.Fire();
                _bullets.Add(bullet);
                this.Controls.Add(bullet.BulletEntity);
            }
        }

        private void MoveBullets()
        {
            foreach (var bullet in _bullets.ToList())
            {
                bullet.MoveBullet();
                if (bullet.BulletEntity.Bottom < 0)
                {
                    _bullets.Remove(bullet);
                    this.Controls.Remove(bullet.BulletEntity);
                }

                if (bullet.BulletEntity.Right < 0)
                {
                    _bullets.Remove(bullet);
                    this.Controls.Remove(bullet.BulletEntity);
                }

                if (bullet.BulletEntity.Top > this.ClientSize.Height)
                {
                    _bullets.Remove(bullet);
                    this.Controls.Remove(bullet.BulletEntity);
                }

                if (bullet.BulletEntity.Left > this.ClientSize.Width)
                {
                    _bullets.Remove(bullet);
                    this.Controls.Remove(bullet.BulletEntity);
                }
            }
        }

        private void RandomRotateAllEnemyTanks()
        {
            foreach (var enemyTank in _enemyTanks)
            {
                RandomRotateEnemyTank(enemyTank);
            }
        }

        private void RandomRotateEnemyTank(Tank enemyTank)
        {
            var direction = (Directions)_directions.GetValue(_random.Next(0, 3));
            enemyTank.MoveTank(direction);
        }

        private void MoveEnemyTanks()
        {
            foreach (var enemyTank in _enemyTanks)
            {
                if (enemyTank.TankEntity.Bottom > this.ClientSize.Height)
                {
                    enemyTank.ReverseCurrentDirection();
                }

                if (enemyTank.TankEntity.Right > this.ClientSize.Width)
                {
                    enemyTank.ReverseCurrentDirection();
                }

                if (enemyTank.TankEntity.Top < 0)
                {
                    enemyTank.ReverseCurrentDirection();
                }

                if (enemyTank.TankEntity.Left < 0)
                {
                    enemyTank.ReverseCurrentDirection();
                }

                enemyTank.MoveTank();
            }
        }

        private void CheckCollisions()
        {
            foreach (var bullet in _bullets)
            {
                foreach (var enemyTank in _enemyTanks)
                {
                    if (bullet.BulletEntity.Bounds.IntersectsWith(enemyTank.TankEntity.Bounds))
                    {
                        _bullets.Remove(bullet);
                        this.Controls.Remove(bullet.BulletEntity);
                        _enemyTanks.Remove(enemyTank);
                        this.Controls.Remove(enemyTank.TankEntity);
                        SpawnNewEnemyTank();
                        return;
                    }
                }
            }
        }
    }
}
