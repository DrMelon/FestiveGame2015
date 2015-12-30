using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestiveGame
{
    class Weapon
    {
        //pew pew!
        public PlayerEnt myPly;

        
        public float RefireTime = 0.0f;
        public float MaxRefire = 30.0f;
        public int myType;
        public int myBulletType;

        public Weapon(PlayerEnt ply, int type)
        {
            myPly = ply;
            myType = type;
            if(myType == 0)
            {
                MaxRefire = 10.0f;
            }
        }

        public void Update()
        {
            if(RefireTime > 0)
            {
                RefireTime -= 1.0f;
            }
        }

        public void Fire()
        {
            if(RefireTime <= 0)
            {
                if(myType == 0)
                {
                    Otter.Sound newSnd = new Otter.Sound(Assets.SND_SHOOT);
                    newSnd.Pitch = Otter.Rand.Float(0.85f, 1.05f);
                    newSnd.Play();
                    myBulletType = 0;
                    //make bullet
                    Bullet newbul = new Bullet(myPly.X, myPly.Y, myBulletType);
                    myPly.Scene.Add(newbul);
                }
                
                RefireTime = MaxRefire;
            }
            else
            {
                //dont do
            }
        }


    }
}
