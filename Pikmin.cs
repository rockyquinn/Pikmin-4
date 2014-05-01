using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pikmin_4
{
    class Pikmin
    {
        private List<Texture2D> rightAnimation;
        private Dictionary<String, Texture2D> IMAGES = Game1.PIKMIN_IMAGES;
        private String type;
        private int level,x,y,velX,velY,width,height;

        /// <summary>
        /// Constructor for any Pikmin.
        /// </summary>
        public Pikmin(String typ, int lvl)
        {
            type = typ;
            level = lvl;
            x = 0;
            y = 0;

            initPikmin();
        }

        public Pikmin(String typ, int lvl, int nx, int ny)
        {
            type = typ;
            level = lvl;
            x = nx;
            y = ny;

            initPikmin();
        }


        /// <summary>
        /// Initializes the rest of information needed for this Pikmin.
        /// </summary>
        public void initPikmin()
        {
            rightAnimation = new List<Texture2D>();
            if (type.Equals("blue"))
            {
                if (level == 1)
                {
                    rightAnimation.Add(IMAGES["blueLeafRight1"]);
                    rightAnimation.Add(IMAGES["blueLeafRight2"]);
                    rightAnimation.Add(IMAGES["blueLeafRight3"]);

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                }
                else if (level == 2)
                {
                    rightAnimation.Add(IMAGES["blueBudRight1"]);
                    rightAnimation.Add(IMAGES["blueBudRight2"]);
                    rightAnimation.Add(IMAGES["blueBudRight3"]);

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                }
                else
                {
                    rightAnimation.Add(IMAGES["blueFlowerRight1"]);
                    rightAnimation.Add(IMAGES["blueFlowerRight2"]);
                    rightAnimation.Add(IMAGES["blueFlowerRight3"]);

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                }
            }
            else if (type.Equals("red"))
            {
                if (level == 1)
                {
                    rightAnimation.Add(IMAGES["redLeafRight1"]);
                    rightAnimation.Add(IMAGES["redLeafRight2"]);
                    rightAnimation.Add(IMAGES["redLeafRight3"]);

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                }
                else if (level == 2)
                {
                    rightAnimation.Add(IMAGES["redBudRight1"]);
                    rightAnimation.Add(IMAGES["redBudRight2"]);
                    rightAnimation.Add(IMAGES["redBudRight3"]);

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                }
                else
                {
                    rightAnimation.Add(IMAGES["redFlowerRight1"]);
                    rightAnimation.Add(IMAGES["redFlowerRight2"]);
                    rightAnimation.Add(IMAGES["redFlowerRight3"]);

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                }
            }
            else if(type.Equals("yellow"))
            {
                if(level == 1)
                {
                    rightAnimation.Add(IMAGES["yellowLeafRight1"]);
                    rightAnimation.Add(IMAGES["yellowLeafRight2"]);
                    rightAnimation.Add(IMAGES["yellowLeafRight3"]);

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                }
                else if (level == 2)
                {
                    rightAnimation.Add(IMAGES["yellowBudRight1"]);
                    rightAnimation.Add(IMAGES["yellowBudRight2"]);
                    rightAnimation.Add(IMAGES["yellowBudRight3"]);

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                }
                else
                {
                    rightAnimation.Add(IMAGES["yellowFlowerRight1"]);
                    rightAnimation.Add(IMAGES["yellowFlowerRight2"]);
                    rightAnimation.Add(IMAGES["yellowFlowerRight3"]);

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                }
            }
            else if (type.Equals("white"))
            {
                if (level == 1)
                {
                    rightAnimation.Add(IMAGES["whiteLeafRight1"]);
                    rightAnimation.Add(IMAGES["whiteLeafRight2"]);
                    rightAnimation.Add(IMAGES["whiteLeafRight3"]);
                }
                else if (level == 2)
                {
                    rightAnimation.Add(IMAGES["whiteBudRight1"]);
                    rightAnimation.Add(IMAGES["whiteBudRight2"]);
                    rightAnimation.Add(IMAGES["whiteBudRight3"]);
                }
                else
                {
                    rightAnimation.Add(IMAGES["whiteFlowerRight1"]);
                    rightAnimation.Add(IMAGES["whiteFlowerRight2"]);
                    rightAnimation.Add(IMAGES["whiteFlowerRight3"]);
                }
            }
        }
        ///////////////////////
        //End of initImages()//
        ///////////////////////
    }
}
