namespace Super2DGame.Models
{
    public class Tank
    {
        private string _imagePath;
        private Bitmap _tankBitmap;
        private PictureBox _tankEntity;
        private int _tankSize;
        private int _tankSpeed;
        private bool _isCanFire;
        private int _reloadTimeout;
        private int _currentReloadTimeout;
        private Directions _currentDirection;

        public PictureBox TankEntity
        {
            get => _tankEntity;
        }

        public int TankSize
        {
            get => _tankSize;
        }

        public bool IsCanFire
        {
            get => _isCanFire;
        }

        public Tank(string tankImagePath, int tankSize, int tankSpeed, int reloadTimeout, Point initLocation, Directions initDirection)
        {
            _imagePath = tankImagePath;
            _tankBitmap = new Bitmap(Image.FromFile(_imagePath));
            _tankSize = tankSize;
            _tankSpeed = tankSpeed;
            _reloadTimeout = reloadTimeout;
            _tankEntity = new PictureBox
            {
                Size = new Size(_tankSize, _tankSize),
                Image = _tankBitmap,
                Location = initLocation
            };

            RotateTank(initDirection);
        }

        public void RotateTank(Directions direction)
        {
            if (_currentDirection == direction)
            {
                return;
            }

            Bitmap tankImage;
            switch (direction)
            {
                case Directions.Left:
                    tankImage = new Bitmap(Image.FromFile(_imagePath));
                    tankImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    _tankEntity.Image = tankImage;
                    _tankEntity.Refresh();
                    _currentDirection = Directions.Left;
                    break;
                case Directions.Right:
                    tankImage = new Bitmap(Image.FromFile(_imagePath));
                    tankImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    _tankEntity.Image = tankImage;
                    _tankEntity.Refresh();
                    _currentDirection = Directions.Right;
                    break;
                case Directions.Top:
                    tankImage = new Bitmap(Image.FromFile(_imagePath));
                    _tankEntity.Image = tankImage;
                    _tankEntity.Refresh();
                    _currentDirection = Directions.Top;
                    break;
                case Directions.Bottom:
                    tankImage = new Bitmap(Image.FromFile(_imagePath));
                    tankImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    _tankEntity.Image = tankImage;
                    _tankEntity.Refresh();
                    _currentDirection = Directions.Bottom;
                    break;
            }
        }

        public void ReverseCurrentDirection()
        {
            Directions newDirection = Directions.Top;
            switch (_currentDirection)
            {
                case Directions.Left:
                    newDirection = Directions.Right;
                    break;
                case Directions.Right:
                    newDirection = Directions.Left;
                    break;
                case Directions.Top:
                    newDirection = Directions.Bottom;
                    break;
                case Directions.Bottom:
                    newDirection = Directions.Top;
                    break;
            }

            RotateTank(newDirection);
        }

        public void MoveTank(Directions direction)
        {
            RotateTank(direction);
            MoveTank();
        }

        public void MoveTank()
        {
            switch (_currentDirection)
            {
                case Directions.Left:
                    _tankEntity.Left -= _tankSpeed;
                    break;
                case Directions.Right:
                    _tankEntity.Left += _tankSpeed;
                    break;
                case Directions.Top:
                    _tankEntity.Top -= _tankSpeed;
                    break;
                case Directions.Bottom:
                    _tankEntity.Top += _tankSpeed;
                    break;
            }
        }

        public Bullet Fire()
        {
            _isCanFire = false;
            return new Bullet(_currentDirection, this);
        }

        public void UpdateReloadTimeout()
        {
            if (!_isCanFire)
            {
                if (_currentReloadTimeout != 0)
                {
                    _currentReloadTimeout--;
                    return;
                }

                _currentReloadTimeout = _reloadTimeout;
                _isCanFire = true;
            }
        }
    }
}
