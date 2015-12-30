using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;




// TODO:
// player ship, bullets
// player powerup followers (train style)
// text boxes (copy from space questionmark)
// xmas tree boss
// cutscenes?



namespace FestiveGame
{
        
    class ShmupScene:Scene
    {
        //Add non-scrolling bg to scene
        public Entity bgImage;
        //Add scrolling clouds
        public Entity bgScrollCloud1;
        public Entity bgScrollCloud2;
        public Entity bgScrollCloud3;
        public Entity bgScrollCloud4;
        public Entity bgScrollCloud5;
        public Entity bgScrollCloud6;
        public Entity bgScrollCloud7;
        public Entity bgScrollCloud8;

        public Entity bgSnowfield1;
        public Entity bgSnowfield2;

        // GET FESTIVE text!
        public Entity bgGetFestive;
        public RichText txGetFestive;
        // GET FESTIVE melon transform
        public PlayerEnt bgMelonGetFestive;
        public Spritemap<string> melonSprite;

        public CameraShaker theCamShaker;

        // HUD stuff
        // player health bar
        public HUDBar playerHealthBar;

        // Screen flash ent;
        public Entity scrFlash;

        // Scene state stuff
        bool MelonGotFestiveYet;
        bool IntroOver;

        // Scene Setup
        public ShmupScene()
        {
            // Set up cam shaker
            theCamShaker = new CameraShaker();
            Add(theCamShaker);
            // Set up BG
            SetUpBG();

            // Set up scrflash object
            scrFlash = new Entity(0, 0, Image.CreateRectangle(Color.White), null, "scrflash") { Layer = 1 };
            scrFlash.Layer = 1;
            scrFlash.Graphic.Scroll = 0;
            scrFlash.Graphic.Color.A = 0;
            Add(scrFlash);

            // Set up melon gfx
            melonSprite = new Spritemap<string>(Assets.GFX_MELON, 40, 32);
            melonSprite.Scroll = 0;
            melonSprite.CenterOrigin();
            melonSprite.Add("def", new Anim(new int[] { 0, 1 }, new float[] { 2.0f, 2.0f }));
            melonSprite.Play("def");

            
            
            
        }

        public override void Update()
        {
            // Scroll Camera.
            ScrollCamera();


            
            


            base.Update();
        }

        public void ScrollCamera()
        {
            if(bgMelonGetFestive.SceneOver == false)
            {
                CameraX += 1.0f;
            }
            CameraX += (1.0f + ((bgMelonGetFestive.X - 50) / 350.0f));
            if(bgMelonGetFestive.SceneOver)
            {
                // melon influences cam a tiny bit
                CameraY = (bgMelonGetFestive.Y - 120) / 4.0f;
            }
            
            
            
            bgSnowfield1.Y += 0.1f;
            bgSnowfield2.Y += 0.3f;
        }

        public void SetUpBG()
        {
            bgImage = new Entity(0, 0, new Image(Assets.GFX_BG_SKY), null, "bg_sky");
            bgImage.Graphic.ScrollX = 0;
            bgImage.Graphic.ScrollY = 0;
            bgImage.Graphic.RepeatX = true;
            bgImage.Layer = 110;

            bgScrollCloud7 = new Entity(0, 240 - 30, new Image(Assets.GFX_BG_CLOUD), null, "bg_cloud1");
            bgScrollCloud7.Graphic.ScrollX = 0.8f;
            bgScrollCloud7.Graphic.ScrollY = 0.8f;
            bgScrollCloud7.Graphic.ScaleY = 1.2f;
            bgScrollCloud7.Graphic.RepeatX = true;
            bgScrollCloud7.Layer = 98;
            bgScrollCloud8 = new Entity(64, 30, new Image(Assets.GFX_BG_CLOUD), null, "bg_cloud1");
            bgScrollCloud8.Graphic.ScrollX = 0.8f;
            bgScrollCloud8.Graphic.ScrollY = 0.8f;
            bgScrollCloud8.Graphic.ScaleY = -1.2f;
            bgScrollCloud8.Graphic.RepeatX = true;
            bgScrollCloud8.Layer = 98;

            bgScrollCloud1 = new Entity(0, 240 - 60, new Image(Assets.GFX_BG_CLOUD), null, "bg_cloud1");
            bgScrollCloud1.Graphic.ScrollX = 0.5f;
            bgScrollCloud1.Graphic.ScrollY = 0.5f;
            bgScrollCloud1.Graphic.RepeatX = true;
            bgScrollCloud1.Layer = 99;
            bgScrollCloud2 = new Entity(64, 60, new Image(Assets.GFX_BG_CLOUD), null, "bg_cloud1");
            bgScrollCloud2.Graphic.ScrollX = 0.5f;
            bgScrollCloud2.Graphic.ScrollY = 0.5f;
            bgScrollCloud2.Graphic.ScaleY = -1;
            bgScrollCloud2.Graphic.RepeatX = true;
            bgScrollCloud2.Layer = 99;

            bgScrollCloud3 = new Entity(0, 240 - 80, new Image(Assets.GFX_BG_CLOUD), null, "bg_cloud1");
            bgScrollCloud3.Graphic.ScrollX = 0.3f;
            bgScrollCloud3.Graphic.ScrollY = 0.3f;
            bgScrollCloud3.Graphic.ScaleX = 0.8f;
            bgScrollCloud3.Graphic.ScaleY = 0.8f;
            bgScrollCloud3.Graphic.Color *= 0.8f;
            bgScrollCloud3.Graphic.RepeatX = true;
            bgScrollCloud3.Layer = 100;
            bgScrollCloud4 = new Entity(64, 80, new Image(Assets.GFX_BG_CLOUD), null, "bg_cloud1");
            bgScrollCloud4.Graphic.ScrollX = 0.3f;
            bgScrollCloud4.Graphic.ScrollY = 0.3f;
            bgScrollCloud4.Graphic.ScaleX = 0.8f;
            bgScrollCloud4.Graphic.ScaleY = -0.8f;
            bgScrollCloud4.Graphic.Color *= 0.8f;
            bgScrollCloud4.Graphic.RepeatX = true;
            bgScrollCloud4.Layer = 100;

            bgScrollCloud5 = new Entity(0, 240 - 90, new Image(Assets.GFX_BG_CLOUD), null, "bg_cloud1");
            bgScrollCloud5.Graphic.ScrollX = 0.2f;
            bgScrollCloud5.Graphic.ScrollY = 0.2f;
            bgScrollCloud5.Graphic.RepeatX = true;
            bgScrollCloud5.Graphic.ScaleX = 0.6f;
            bgScrollCloud5.Graphic.ScaleY = 0.6f;
            bgScrollCloud5.Graphic.Color *= 0.6f;
            bgScrollCloud5.Layer = 101;
            bgScrollCloud6 = new Entity(64, 90, new Image(Assets.GFX_BG_CLOUD), null, "bg_cloud1");
            bgScrollCloud6.Graphic.ScrollX = 0.2f;
            bgScrollCloud6.Graphic.ScrollY = 0.2f;
            bgScrollCloud6.Graphic.ScaleX = 0.6f;
            bgScrollCloud6.Graphic.ScaleY = -0.6f;
            bgScrollCloud6.Graphic.Color *= 0.6f;
            bgScrollCloud6.Graphic.RepeatX = true;
            bgScrollCloud6.Layer = 101;

            bgSnowfield1 = new Entity(0, 0, new Image(Assets.GFX_BG_SNOWFIELD), null, "bg_snowfield");
            bgSnowfield1.Graphic.ScrollX = 0.9f;
            bgSnowfield1.Graphic.ScrollY = 0.9f;
            bgSnowfield1.Graphic.Repeat = true;
            bgSnowfield1.Graphic.Color.A = 0.8f;
            bgSnowfield1.Graphic.Color *= 0.9f;
            bgSnowfield1.Layer = 101;

            bgSnowfield2 = new Entity(0, 0, new Image(Assets.GFX_BG_SNOWFIELD), null, "bg_snowfield");
            bgSnowfield2.Graphic.Scale = 2.0f;
            bgSnowfield2.Graphic.ScrollX = 1.3f;
            bgSnowfield2.Graphic.ScrollY = 1.3f;
            bgSnowfield2.Graphic.Repeat = true;
            bgSnowfield2.Graphic.Color.A = 0.6f;
            bgSnowfield2.Layer = 30;

            txGetFestive = new RichText("{waveRate:3}{waveAmpY:8}GET FESTIVE!", Assets.ASSETPATH + "consola.ttf", 12, -1, -1);

            txGetFestive.Smooth = false;
            txGetFestive.FontSize = 48;
            txGetFestive.DefaultCharColor = Color.Red * 0.7f;
            txGetFestive.X = 200;
            txGetFestive.Y = 110;
            txGetFestive.CenterOrigin();
            txGetFestive.DefaultShadowColor = Color.Green * 0.55f;
            txGetFestive.DefaultShadowX = 2;
            txGetFestive.DefaultShadowY = 2;
            txGetFestive.Refresh();

            txGetFestive.Scroll = 0;
            
            
            
            
            Add(bgImage);
            Add(bgScrollCloud1);
            Add(bgScrollCloud2);
            Add(bgScrollCloud3);
            Add(bgScrollCloud4);
            Add(bgScrollCloud5);
            Add(bgScrollCloud6);
            Add(bgScrollCloud7);
            Add(bgScrollCloud8);
            Add(bgSnowfield1);
            Add(bgSnowfield2);
            bgGetFestive = new Entity(0, 0, txGetFestive, null, "") { Layer = 50 };
            Add(bgGetFestive);

            // Make cutscene melon in the bottom left, begin tweening to center?
            bgMelonGetFestive = new PlayerEnt(-32, 180, new Image(Assets.GFX_MELON_PRE), null, "melon_cutscene") { Layer = 49 };
            bgMelonGetFestive.Graphic.Scroll = 0;
            bgMelonGetFestive.Graphic.CenterOrigin();

            // Set up tweens
            Action melonFinish = MelonTransform;
            Tween(bgMelonGetFestive, new { X = 200 }, 5 * 60).Ease(Ease.ElasticOut).OnComplete(melonFinish);
            Tween(bgMelonGetFestive, new { Y = 160 }, 6f* 60).Ease(Ease.CubeOut);
            Add(bgMelonGetFestive);
        }

        public void MelonTransform()
        {
            FlashScreen(1.0f * 60.0f);
            
            bgMelonGetFestive.Graphics.Clear();
            bgMelonGetFestive.AddGraphic(melonSprite);
            bgGetFestive.RemoveSelf();
            // Give control to player!
            bgMelonGetFestive.Graphic.Scroll = 0;
            bgMelonGetFestive.X = 200;
            bgMelonGetFestive.Y = 160;
            
            bgMelonGetFestive.SceneOver = true;

            
            
            playerHealthBar = new HUDBar(20, 20, 200, 8, 100, 0.45f, Color.Red * Color.Gray, Color.Yellow, Color.Red, Color.White);
            playerHealthBar.Layer = 5;
            bgMelonGetFestive.healthBarRef = playerHealthBar;
            
            Add(playerHealthBar);
            // start up enemy spawner
            // theEnemySpawner.Start()
            // test/debug
            EnemyManager enMan = new EnemyManager();
            Add(enMan);
            enMan.hasStarted = true;
        }

        public void FlashScreen(float duration)
        {
            scrFlash.Graphic.Color.A = 1.0f;
            Tween(scrFlash.Graphic.Color, new { A = 0.0f }, duration).Ease(Ease.Linear);
            Sound newSnd = new Sound(Assets.SND_TRANSFORM);
            newSnd.Play();
        }

    }
}
