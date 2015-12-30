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

        public float Invuln;
        public HUDBar healthBarRef;
        public float Dashing; //thru the snow...
        public Vector2 FreezeStick;
        public ParticleSystem smokeParticles;

        public PlayerEnt(float x, float y, Graphic gfx, Collider col, string nm)
        {
            X = x;
            Y = y;
            Graphic = gfx;
            if(col != null)
            {
                Collider = col;
            }

            Collider = new BoxCollider(gfx.Width, gfx.Height, 5);
            Collider.CenterOrigin();
            Name = nm;
            currentWeapon = new Weapon(this, 0);
            smokeParticles = new ParticleSystem(X, Y);
            smokeParticles.Initialize(7, 3, 0, 360, 2, 45, Assets.GFX_SMOKE, 16, 16, 1, true, 8, 0);
            smokeParticles.particleScroll = 0;
            smokeParticles.beginColour = Color.White;
            smokeParticles.endColour = Color.White;
            smokeParticles.particleStartScale = 1.0f;
            smokeParticles.particleEndScale = 1.0f;
            smokeParticles.particleShake = 3;
        }

        public override void Added()
        {
            base.Added();

            Scene.Add(smokeParticles);
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

            smokeParticles.X = X;
            smokeParticles.Y = Y;

            // We fly forward at a fixed speed, which is altered by movement keys.
            if (Dashing <= 0)
            {
                smokeParticles.Stop();
                X += BaseSpeed * Global.theController.LeftStick.X;
                Y += BaseSpeed * Global.theController.LeftStick.Y;
            }
            else
            {
                X += BaseSpeed * 5 * FreezeStick.X;
                Y += BaseSpeed * 5 * FreezeStick.Y;
                Dashing--;
            }
            
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
            
            // we get hurt?
            if(Collider.Overlap(X, Y, 10) && Invuln < 1)
            {
                Invuln = 85;
                healthBarRef.RemoveVal(10);
                Sound newSnd = new Sound(Assets.SND_HURT);
                newSnd.Pitch = Rand.Float(0.8f, 1.1f);
                newSnd.Play();
                Scene.GetEntity<CameraShaker>().ShakeCamera();
            }

            if(Invuln > 0)
            {
                Invuln -= 1;
                if(Math.Floor(Global.theGame.Timer) % 8 == 0)
                {
                    if(Graphic.Color.A != 0)
                    {
                        Graphic.Color.A = 0;
                    }
                    else
                    {
                        Graphic.Color.A = 1;
                    }
                }
            }
            else
            {
                Graphic.Color.A = 1;
            }

            if(healthBarRef.Val <= 0)
            {
                //die!!
                RemoveSelf();
            }
            
        }

        public void HandleInput()
        {
            if(Global.theController.X.Down)
            {
                // firing!!
                currentWeapon.Fire();
            }
            if(Global.theController.A.Pressed && Dashing <= 0)
            {
                // DASH
                Dashing += 8;
                FreezeStick.X = Global.theController.LeftStick.X;
                FreezeStick.Y = Global.theController.LeftStick.Y;
                if(Global.theController.LeftStick.Neutral)
                {
                    FreezeStick.X = 1;
                    FreezeStick.Y = 0;
                }
                smokeParticles.Start();
            }

        }
    }
}
