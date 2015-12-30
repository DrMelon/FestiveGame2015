using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;


namespace FestiveGame
{
    class Bullet:Entity
    {
        public int myType;
        public string name;
        public float speed;
        public ParticleSystem myParticles;

        public Bullet(float x, float y, int type)
        {
            X = x;
            Y = y;
            myType = type;
            LifeSpan = 60 * 8;
            
            switch(type)
            {
                case 0:
                    Graphic = new Image(Assets.GFX_BULLET_PULSE);
                    speed = 6.0f;
                    break;
                default:
                    Graphic = new Image(Assets.GFX_BULLET_PULSE);
                    speed = 2.0f;
                    break;
            }

            Graphic.Scroll = 0;
            Graphic.CenterOrigin();
            Collider = new BoxCollider(Graphic.Width, Graphic.Height, 15);
            Collider.CenterOrigin();


            myParticles = new ParticleSystem(x, y);
            myParticles.Initialize(6, 2, 0, 360, 1, 20, Assets.GFX_BULLET_PULSE_PARTICLE, 8, 8, 1, true, 6, 0);
            myParticles.particleScroll = 0;
            myParticles.beginColour = Color.White;
            myParticles.endColour = Color.White;
            myParticles.particleStartScale = 1.0f;
            myParticles.particleEndScale = 1.0f;
            

            myParticles.Start();
            
        }

        public override void Added()
        {
            base.Added();

            Scene.Add(myParticles);
        }

        public override void Update()
        {
            base.Update();

            // move right
            X += speed;
            myParticles.X = X;
            myParticles.Y = Y;
            
        }

        public override void Removed()
        {
            myParticles.RemoveSelf();
            base.Removed();

        }
    }
}
