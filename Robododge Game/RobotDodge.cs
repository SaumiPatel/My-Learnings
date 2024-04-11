using System.Security.Cryptography.X509Certificates;
using System.Timers;
using BulleT;
using SplashKitSDK;



namespace RobotDodge {
    public class RobotDodge {
        private Player _Player;
        private Window _GameWindow;
        private List< Bullet> _bullet= new List<Bullet>();

        // private Robot _TestRobot;

        private List<Robot> _Robots = new List<Robot>();
        private Life _Life;
        public bool Quit { get { return _Player.Quit; } }
        private Bitmap _playerBitmap;
        public  int remainingLife=5;
        public int _score;
        

        public RobotDodge(Window gameWindow) {
            _GameWindow = gameWindow;
            Player objPlayer = new Player(gameWindow);
            _Player = objPlayer;
            Life objLife=new Life(gameWindow);
            _Life=objLife;
            // _TestRobot=RandomRobot();
        }
        
        public void Draw()
        {
            _GameWindow.Clear(Color.White);
            foreach (Robot i in _Robots) {
                i.Draw();
            }
            foreach (Bullet i in _bullet) {
                i.Draw();
            }
            
            _Player.Draw();
            _Player.StayOnScreen(_GameWindow);

            int lifeX=0;
            int lifeY=0;
            for(int i=0; i<remainingLife;i++){
                if (i!=0)
                lifeX+=50;
                
                _Life.Draw(lifeX,lifeY);
            }
            drawScore(420,20);
            
            _GameWindow.Refresh(60);


        }
        
        public void HandleInput() {
            _Player.HandleInput();
        }
        
        public void Update() {
            CheckCollisions();
            if (SplashKit.Rnd() < 0.04) {
                _Robots.Add(RandomRobot());
            }
            foreach (Robot objrob in _Robots) {
                objrob.update();
            }
            SplashKit.ProcessEvents();

            if (SplashKit.MouseDown(MouseButton.LeftButton)) {
                _bullet.Add(RandomBullet());
            }
            foreach (Bullet objbullet in _bullet) {
                objbullet.update();
            }
        }
        
        public Robot RandomRobot() {
            Robot objRobot = new Robot(_GameWindow, _Player);
            return objRobot;
        }

        public Bullet RandomBullet(){
            Bullet objBullet= new Bullet(_Player,_GameWindow);
            return objBullet;
        }

        private void CheckCollisions() {
            List<Robot> robotsToRemove = new List<Robot>();
            foreach(var bullet in _bullet){
                foreach (var robot in _Robots) {
                    if (bullet.CollidedWith(robot) || robot.IsOffscreen(_GameWindow)) {
                        robotsToRemove.Add(robot);
                    }
                    
                }
            }

            foreach(var robot in _Robots){
                if (_Player.CollidedWith(robot)){

                        robotsToRemove.Add(robot);
                        remainingLife =remainingLife-1;
                    }
            }

            foreach (var robotToRemove in robotsToRemove) {
                _Robots.Remove(robotToRemove);
            }
        }

        public void score(SplashKitSDK.Timer _score1){
            _score= Convert.ToInt32(SplashKit.TimerTicks(_score1)/1000.0);
        }

        public void drawScore(int x, int y){
            
            SplashKit.DrawText($"Score {_score}",Color.Black,"TimesNewRoman",8,x,y);
            
        }
    }
}