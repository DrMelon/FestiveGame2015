using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Otter;

namespace FestiveGame
{
    class HUDBar : Entity
    {
        public float MaxVal;
        public float Val;
        public float TargetVal;
        public float LagTime;
        public Image BarBack;
        public Image BarLag;
        public Image BarFront;
        public Image BarHighlight;

        public HUDBar(float x, float y, float width, float height, float maxval, float lag, Color back, Color lagcol, Color front, Color highlight)
        {
            X = x;
            Y = y;
            LagTime = lag;
            MaxVal = maxval;
            Val = MaxVal;
            TargetVal = MaxVal;

            // Create bars
            BarBack = Image.CreateRectangle((int)width, (int)height, back);
            BarBack.Scroll = 0;
            BarLag = Image.CreateRectangle((int)width, (int)height, lagcol);
            BarLag.Scroll = 0;
            BarFront = Image.CreateRectangle((int)width, (int)height, front);
            BarFront.Scroll = 0;
            BarHighlight = Image.CreateRectangle((int)width, (int)height / 3, highlight);
            BarHighlight.Y = height / 6;
            BarHighlight.Color.A = 0.7f;
            BarHighlight.Scroll = 0;

            AddGraphic(BarBack);
            AddGraphic(BarLag);
            AddGraphic(BarFront);
            AddGraphic(BarHighlight);
            
        }

        public override void Update()
        {
            base.Update();

            // Update bars to match val?


        }

        public void RemoveVal(float val)
        {
            if(val <= 0)
            {
                return;
            }
            Val -= val;
            if(Val <= 0)
            {
                Val = 0;
            }

            //tween bar widths 
            Tween(BarFront, new { ScaleX = (Val / MaxVal) }, 0.5f * 60, 0);
            Tween(BarLag, new { ScaleX = (Val / MaxVal) }, 0.6f * 60, LagTime * 60);
            Tween(BarHighlight, new { ScaleX = (Val / MaxVal) }, 0.5f * 60, 0);


        }

        public void AddVal(float val)
        {
            if(val <= 0)
            {
                return;
            }
            Val += val;
            if(Val > MaxVal)
            {
                Val = MaxVal;
            }

            //tween bar widths 
            Tween(BarFront, new { ScaleX = (Val / MaxVal) }, 0.5f * 60, 0);
            Tween(BarLag, new { ScaleX = (Val / MaxVal) }, 0.5f * 60, 0);
            Tween(BarHighlight, new { ScaleX = (Val / MaxVal) }, 0.5f * 60, 0);


        }

    }
}
