using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;
 
namespace FestiveGame
{
    class PlayerEnt:Entity
    {
        // Lil spaceship!
        // Gfx managed by scene, so no need to worry bout that.

        public bool SceneOver = false;
        public float BaseSpeed = 2.0f;
        public float SpeedMult = 1.0f;
        public Weapon currentWeapon;

        public PlayerEnt(float x, float y, Graphic gfx, Collider col, string nm)
        {
            X = x;
            Y = y;
            Graphic = gfx;
            if(col != null)
            {
                Collider = col;
            }
            
            Name = nm;
            currentWeapon = new Weapon(this, 0);
        }

        public override void Update()
        {
            if(!SceneOver)
            {
                return;
            }

            // If we're out of a cutscene, play starts!

            // Update input
            currentWeapon.Update();
            HandleInput();

            // We fly forward at a fixed speed, which is altered by movement keys.
            X += BaseSpeed * Global.theController.LeftStick.X;
            Y += BaseSpeed * Global.theController.LeftStick.Y;
            if(X < 60)
            {
                X = 60;
            }
            if(X > 330)
            {
                X = 330;
            }
            if(Y < 50)
            {
                Y = 50;
            }
            if(Y > 220)
            {
                Y = 220;
            }
            
            
        }

        public void HandleInput()
        {
            if(Global.theController.X.Down)
            {
                // firing!!
                currentWeapon.Fire();
            }

        }
    }
}
