using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace FestiveGame
{
    class EnemyManager : Entity
    {
        // This thing just spams enemies into the scene haha
        public bool hasStarted;
        float timeForNextWave;
        float timeForNextEnemy;
        int curWave;
        // Wave-timing
        // Pattern stuff


        public override void Update()
        {
            base.Update();

            if(hasStarted)
            {
                if(timeForNextEnemy <= 0)
                {
                    timeForNextEnemy = 60 * Rand.Float(0.3f, 1.5f); // set up for wave/pattern
                    // Spawn an enemy!
                    SpawnEnemy();
                }
                timeForNextEnemy--;
                if(timeForNextWave <= 0)
                {
                    timeForNextWave = 60 * 300; // set up for next wave type
                    curWave++;
                }
                timeForNextWave--;
            }

        }

        public void SpawnEnemy()
        {
            //check pattern/wave

            Enemy newEn = new Enemy(450, Rand.Float(40, 200), 0);
            this.Scene.Add(newEn);
        }

    }
}
