using System;
using System.Runtime.InteropServices;
using RobotDodge;
using SplashKitSDK;

namespace BulleT{

    
    public class Bullet{
        public double X;
        public double Y;
        private Window _gamewindow;
        private Bitmap _bulletBitmap;

        public Vector2D velocity;
        public Bullet(Player player, Window gameWindow){

            _gamewindow=gameWindow;
            _bulletBitmap = new Bitmap("bullet", "Fire.png");

            X=player.X;
            Y=player.Y;
            const int SPEED=5;

            Point2D from=new Point2D(){
                X=X,Y=Y
            };

            Point2D to=SplashKit.MousePosition();
            Vector2D dir;
            dir=SplashKit.UnitVector(SplashKit.VectorPointToPoint(from,to));

            velocity=SplashKit.VectorMultiply(dir,SPEED);

        }

        public void Draw(){
            _bulletBitmap.Draw(X, Y);
        }

        public void update(){
            X += velocity.X;
            Y += velocity.Y;
        }

        public bool CollidedWith(Robot gameWindow) {
            return _bulletBitmap.CircleCollision(X,Y,gameWindow.CollisionCircle);
        }

    }


    public class Life{
        private double X {get;set;}
        private double Y{get;set;}

        private Bitmap _heart;
    
        public int Width { get { return _heart.Width; } }
        public int Height { get { return _heart.Height; } }


        public Life (Window gameWindow){
            _heart= new Bitmap("life","heart.png");

            X=0;
            Y=0;
        }

        public void Draw(int X, int Y){
            _heart.Draw(X,Y);
        }




    }

}