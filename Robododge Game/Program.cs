using System;

using SplashKitSDK;


namespace RobotDodge
{
    public class Program
    {
        
        public static void Main()
        {
            Window window = new Window("RobotDodge", 500, 500);
            

            Console.WriteLine("Press esc if you want to leave the game");
            RobotDodge objRobotDodge=new RobotDodge(window);
            SplashKitSDK.Timer _score = SplashKit.CreateTimer("mytimer");
            SplashKit.StartTimer(_score);

            while ((!(SplashKit.WindowCloseRequested("RobotDodge") || objRobotDodge.Quit))&& objRobotDodge.remainingLife >0)
            {
                
                SplashKit.ProcessEvents();
                objRobotDodge.HandleInput();
                objRobotDodge.Update();
                objRobotDodge.Draw();
                objRobotDodge.score(_score);
                
            }
            
            SplashKit.Delay(2000);
            
        }
    }
}
