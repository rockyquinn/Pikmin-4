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
        /// <summary>
        /// List of animations involved with moving to the right
        /// </summary>
        private List<Texture2D> rightAnimation;
        /// <summary>
        /// Image of Pikmin facing the user.
        /// </summary>
        private Texture2D frontImage;
        /// <summary>
        /// String representation of the Color/Type of a Pikmin:
        ///     "red":      Fire pikmin
        ///     "blue":     Water pikmin
        ///     "yellow":   Electric pikmin
        ///     "white":    Poison pikmin
        ///     "purple":   Large pikmin
        ///     "flying":   Flying pikmin
        ///     "rock":     Rock pikmin
        /// </summary>
        private String type;
        /// <summary>
        /// 'x' and 'y' coordinate of a pikmin.
        /// </summary>
        private Vector2 position;
        /// <summary>
        /// Integer representation of the Level of a Pikmin:
        ///     1:  "leaf"
        ///     2:  "bud"
        ///     3:  "flower"
        /// </summary>
        private int level;
        /// <summary>
        /// 'x' position of the Pikmin.
        /// </summary>
        private int x;
        /// <summary>
        /// 'y' position of the Pikmin.
        /// </summary>
        private int y;
        /// <summary>
        /// Pikmin's velocity over the x-axis.
        /// </summary>
        private int velX;
        /// <summary>
        /// Pikmin's velocity over the y-axis.
        /// </summary>
        private int velY;
        /// <summary>
        /// Pikmin's image width.
        /// </summary>
        private int width;
        /// <summary>
        /// Pikmin's image height.
        /// </summary>
        private int height;
        /// <summary>
        /// Pikmin's attack power.
        /// </summary>
        private int attackPower;


        /// <summary>
        /// Constructor for any Pikmin.
        /// </summary>
        /// <param name="typ">(string) Color/Type of the Pikmin</param>
        /// <param name="lvl">(int) Level of Pikmin</param>
        public Pikmin(String typ, int lvl)
        {
            type = typ;
            level = lvl;
            x = 0;
            y = 0;

            initPikmin();
        }

        /// <summary>
        /// Constructor for a Pikmin with its position.
        /// </summary>
        /// <param name="typ">(string) Color/Type of the Pikmin</param>
        /// <param name="lvl">(int) Level of the Pikmin</param>
        /// <param name="nx">(int) 'x' position of the Pikmin</param>
        /// <param name="ny">(int) 'y' position of the Pikmin</param>
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
            if (type.Equals("blue")) //Blue
            {
                if (level == 1) //Blue Leaf
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["blueLeafRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["blueLeafRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["blueLeafRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["blueLeafFront"];

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else if (level == 2) //Blue Bud
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["blueBudRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["blueBudRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["blueBudRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["blueLeafFront"];//*** NEED BUD IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else //Blue Flower
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["blueFlowerRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["blueFlowerRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["blueFlowerRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["blueLeafFront"];//*** NEED FLOWER IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
            }
            else if (type.Equals("red")) //Red
            {
                if (level == 1) //Red Leaf
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["redLeafRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["redLeafRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["redLeafRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["redLeafFront"];

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else if (level == 2) //Red Bud
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["redBudRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["redBudRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["redBudRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["redLeafFront"];//*** NEED BUD IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else //Red Flower
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["redFlowerRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["redFlowerRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["redFlowerRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["redLeafFront"];//*** NEED FLOWER IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
            }
            else if(type.Equals("yellow")) //Yellow
            {
                if(level == 1) //Yellow Leaf
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["yellowLeafRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["yellowLeafRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["yellowLeafRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["yellowLeafFront"];

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else if (level == 2) //Yellow Bud
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["yellowBudRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["yellowBudRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["yellowBudRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["yellowLeafFront"];//*** NEED BUD IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else //Yellow Flower
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["yellowFlowerRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["yellowFlowerRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["yellowFlowerRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["yellowLeafFront"];//*** NEED FLOWER IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
            }
            else if (type.Equals("white")) //White
            {
                if (level == 1) //White Leaf
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["whiteLeafRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["whiteLeafRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["whiteLeafRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["whiteLeafFront"];

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else if (level == 2) //White Bud
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["whiteBudRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["whiteBudRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["whiteBudRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["whiteLeafFront"];//*** NEED BUD IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else //White Flower
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["whiteFlowerRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["whiteFlowerRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["whiteFlowerRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["whiteLeafFront"];//*** NEED FLOWER IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
            }
            /*
            else if (type.Equals("purple")) //Purple
            {
                if (level == 1) //Purple Leaf
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleLeafRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleLeafRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleLeafRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["purpleLeafFront"];

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else if (level == 2) //Purple Bud
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleBudRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleBudRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleBudRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["purpleLeafFront"];//*** NEED BUD IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else //Purple Flower
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleFlowerRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleFlowerRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleFlowerRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["purpleLeafFront"];//*** NEED FLOWER IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
            */
            /*
            else if (type.Equals("rock")) //Rock
            {
                if (level == 1) //Rock Leaf
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockLeafRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockLeafRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockLeafRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["rockLeafFront"];

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else if (level == 2) //Rock Bud
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockBudRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockBudRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockBudRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["rockLeafFront"];//*** NEED BUD IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else //Rock Flower
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockFlowerRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockFlowerRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockFlowerRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["rockLeafFront"];//*** NEED FLOWER IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
            */
            /*
            else if (type.Equals("flying")) //Flying
            {
                if (level == 1) //Flying Leaf
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingLeafRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingLeafRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingLeafRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["flyingLeafFront"];

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else if (level == 2) //Flying Bud
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingBudRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingBudRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingBudRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["flyingLeafFront"];//*** NEED BUD IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
                else //Flying Flower
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingFlowerRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingFlowerRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingFlowerRight3"]);

                    frontImage = Game1.PIKMIN_IMAGES["flyingLeafFront"];//*** NEED FLOWER IMAGE ***\\

                    velX = 0;
                    velY = 0;
                    width = 0;
                    height = 0;
                    attackPower = 0;
                }
            */
        }
        ///////////////////////////////
        ////  End of initImages()  ////
        ///////////////////////////////
    }
}
