

using System.Data;
using System.Net.NetworkInformation;
using SplashKitSDK;
 namespace RobotDodge
{
        

    public class Player
    {
        private Bitmap _playerBitmap;
        public double X { get; set; }
        public double Y { get; set; }

        public bool Quit { get; private set; }
        public int Width { get { return _playerBitmap.Width; } }
        public int Height { get { return _playerBitmap.Height; } }


        public Player(Window gameWindow)
        {
            _playerBitmap = new Bitmap("Player", "Player.png");

            // Calculate the center of the screen and set player position
            X = (gameWindow.Width - Width) / 2;
            Y = (gameWindow.Height - Height) / 2;
            Quit = false;

        }

        public void Draw()
        {
            _playerBitmap.Draw(X, Y);
        }
        
    public void HandleInput()
    {
        const int SPEED=5;
        
        SplashKit.ProcessEvents();
        if (SplashKit.KeyDown(KeyCode.RightKey))
        {

            X += SPEED;

        }

        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {

            X -= SPEED;

        }

        if (SplashKit.KeyDown(KeyCode.DownKey))
        {

            Y += SPEED;

        }

        if (SplashKit.KeyDown(KeyCode.UpKey))
        {

            Y -= SPEED;

        }

        if (SplashKit.KeyDown(KeyCode.EscapeKey))
        {
            Quit = true;
        }
    }

        public void StayOnScreen(Window gameWindow)
        {

            const int GAP = 10;

            if (X < GAP)
            {
                X = GAP;
            }

            if (X > (gameWindow.Width - Width - GAP))
            {
                X = gameWindow.Width - Width - GAP;
            }

            if (Y < GAP)
            {
                Y = GAP;
            }

            if (Y > (gameWindow.Height - Height - GAP))
            {
                Y = gameWindow.Height - Height - GAP;
            }
        }
        public bool CollidedWith(Robot gameWindow) {
            return _playerBitmap.CircleCollision(X,Y,gameWindow.CollisionCircle);
        }
    }
}
