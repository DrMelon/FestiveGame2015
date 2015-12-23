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
            Collider = new BoxCollider(Graphic.Width, Graphic.Height, 15);
        }

        public override void Update()
        {
            base.Update();

            // move right
            X += speed;

        }
    }
}
