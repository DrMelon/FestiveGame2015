using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace FestiveGame
{
    class Enemy:Entity
    {
        // the enemies are presents :D
        public Spritemap<string> mySprite;
        public int hp = 2;
        public int pattern = 0;
        public int hurttimer = 0;

        public Enemy(float x, float y, int pat)
        {
            //'pattern' tells this enemy how to move
            X = x;
            Y = y;
            pattern = pat;

            AddCollider(new BoxCollider(16, 16, 10));

            mySprite = new Spritemap<string>(Assets.GFX_PRESENT_O, 16, 16);
            mySprite.Scroll = 0;
            mySprite.Add("default", new Anim(new int[] { 0 }, new float[] { 1f }));
            mySprite.Add("hurt", new Anim(new int[] { 1, 2 }, new float[] { 2f }));
            AddGraphic(mySprite);
            Layer = 10;
        }

        public void GetHurt()
        {
            if(hp > 0)
            {
                mySprite.Play("hurt", false);
                hurttimer = 5;
                hp -= 1;
            }
            
        }

        public override void Update()
        {
            base.Update();
            if(hurttimer > 0)
            {
                hurttimer--;
            }
            else
            {
                mySprite.Play("default", false);
            }


            if(pattern == 0 && hp > 0)
            {
                // just move left
                X -= 2.5f;
            }

            if(Overlap(X, Y, 15) && hp > 0)
            {
                //ded
                Collider hit = Collide(X, Y, 15);
                hit.Entity.RemoveSelf();
                GetHurt();
            }

            if(hp <= 0)
            {
                // spin and fall 
                Graphic.Angle += 1.5f;
                X += 2.5f;
                Y += 9.81f;

            }

        }

        public void OffScreen()
        {

        }


    }
}
