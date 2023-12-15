namespace Super2DGame.Models
{
    public class Bullet
    {
        private PictureBox _bulletEntity;
        private int _bulletSize;
        private Directions _direction;
        private bool _isEnemyBullet;

        public PictureBox BulletEntity
        {
            get => _bulletEntity;
        }

        public bool IsEnemyBullet
        {
            get => _isEnemyBullet;
        }

        public Bullet(Directions direction, Tank tank) 
        {
            var initPoint = new Point();
            _direction = direction;
            switch (direction)
            {
                case Directions.Left:
                    initPoint = new Point(tank.TankEntity.Left - _bulletSize, tank.TankEntity.Top + tank.TankSize / 2 - _bulletSize / 2);
                    break;
                case Directions.Right:
                    initPoint = new Point(tank.TankEntity.Right + _bulletSize / 2, tank.TankEntity.Top + tank.TankSize / 2 - _bulletSize / 2);
                    break;
                case Directions.Top:
                    initPoint = new Point(tank.TankEntity.Left + tank.TankSize / 2 - _bulletSize / 2, tank.TankEntity.Top - _bulletSize);
                    break;
                case Directions.Bottom:
                    initPoint = new Point(tank.TankEntity.Left + tank.TankSize / 2 - _bulletSize / 2, tank.TankEntity.Bottom + _bulletSize / 2);
                    break;
            }

            _isEnemyBullet = tank.IsEnemy;

            _bulletEntity = new PictureBox
            {
                Size = new Size(5, 5),
                BackColor = Color.Yellow,
                Location = initPoint
            };
        }

        public void MoveBullet()
        {
            switch (_direction)
            {
                case Directions.Left:
                    _bulletEntity.Left -= 5;
                    break;
                case Directions.Right:
                    _bulletEntity.Left += 5;
                    break;
                case Directions.Top:
                    _bulletEntity.Top -= 5;
                    break;
                case Directions.Bottom:
                    _bulletEntity.Top += 5;
                    break;
            }
        }
    }
}
