using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

// FestiveGame, a festive shmup!

namespace FestiveGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Global.theGame = new Game("FestiveGame", 400, 240, 60, false);
            Global.theSession = Global.theGame.AddSession("playerSession");
            Global.theController = new ControllerXbox360(0);
            Global.theSession.Controller = Global.theController;
            Global.theGame.SetWindowScale(2);

            Global.theController.X.AddKey(Key.Z); //shoot
            Global.theController.A.AddKey(Key.X); //dash key
            Global.theController.LeftStick.AddKeys(Key.Up, Key.Right, Key.Down, Key.Left); //movement

            // Setup Complete, Run Game
            Global.theGame.AddScene(new ShmupScene());

            // Boot!
            Global.theGame.Start();

        }
    }
}
