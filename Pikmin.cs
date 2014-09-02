using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pikmin_4
{
    class Pikmin : CollisionObject
    {
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
        private int level;
        /// <summary>
        /// 'x' position of the Pikmin.
        /// </summary>
        private double startVelX, velX;
        /// <summary>
        /// Pikmin's velocity over the y-axis.
        /// </summary>
        private double startVelY, velY;
        /// <summary>
        /// Pikmin's image width.
        /// </summary>
        private float attackPower;
        /// <summary>
        /// Pikmin's range of vision
        /// </summary>
        private float sight;
        /// <summary>
        /// Collision from the left
        /// </summary>
        private bool westCollision;
        /// <summary>
        /// Collision from the right
        /// </summary>
        private bool eastCollision;
        /// <summary>
        /// Collision from the above
        /// </summary>
        private bool northCollision;
        /// <summary>
        /// Collision from the bottom
        /// </summary>
        private bool southCollision;


        /// <summary>
        /// Constructor for any Pikmin.
        /// </summary>
        /// <param name="typ">(string) Color/Type of the Pikmin</param>
        /// <param name="lvl">(int) Level of Pikmin</param>
        public Pikmin(String typ, int lvl) : base("Pikmin",0,0)
        {
            type = typ;
            level = lvl;

            westCollision = false;
            eastCollision = false;
            northCollision = false;
            southCollision = false;

            initPikmin();
        }

        /// <summary>
        /// Constructor for a Pikmin with its position.
        /// </summary>
        /// <param name="typ">(string) Color/Type of the Pikmin</param>
        /// <param name="lvl">(int) Level of the Pikmin</param>
        /// <param name="nx">(int) 'x' position of the Pikmin</param>
        /// <param name="ny">(int) 'y' position of the Pikmin</param>
        public Pikmin(String typ, int lvl, float nx, float ny) : base("Pikmin",nx,ny)
        {
            type = typ;
            level = lvl;

            this.maxAniCount = 4;

            initPikmin();
        }


        /// <summary>
        /// Initializes the rest of information needed for this Pikmin.
        /// </summary>
        public void initPikmin()
        {
            Dictionary<String,Texture2D> aniDict = new Dictionary<String,Texture2D>();
            #region Blue Pikmin
            if (type.Equals("blue")) //Blue
            {
                if (level == 1) //Blue Leaf
                {
                    aniDict.Add("right1",Game1.PIKMIN_IMAGES["blueLeafRight1"]);
                    aniDict.Add("right2",Game1.PIKMIN_IMAGES["blueLeafRight2"]);
                    aniDict.Add("right3",Game1.PIKMIN_IMAGES["blueLeafRight3"]);
                    aniDict.Add("right4",Game1.PIKMIN_IMAGES["blueLeafRight2"]);

                    aniDict.Add("stand",Game1.PIKMIN_IMAGES["blueLeafFront"]);

                    velX = 1;
                    velY = 1;
                    sight = 0;
                    attackPower = 0;
                }
                else if (level == 2) //Blue Bud
                {
                    aniDict.Add("right1", Game1.PIKMIN_IMAGES["blueBudRight1"]);
                    aniDict.Add("right2", Game1.PIKMIN_IMAGES["blueBudRight2"]);
                    aniDict.Add("right3", Game1.PIKMIN_IMAGES["blueBudRight3"]);
                    aniDict.Add("right4", Game1.PIKMIN_IMAGES["blueBudRight2"]);

                    aniDict.Add("stand", Game1.PIKMIN_IMAGES["blueBudFront"]);

                    velX = 1.5;
                    velY = 1.5;
                    sight = 0;
                    attackPower = 0;
                }
                else //Blue Flower
                {
                    aniDict.Add("right1", Game1.PIKMIN_IMAGES["blueFlowerRight1"]);
                    aniDict.Add("right2", Game1.PIKMIN_IMAGES["blueFlowerRight2"]);
                    aniDict.Add("right3", Game1.PIKMIN_IMAGES["blueFlowerRight3"]);
                    aniDict.Add("right4", Game1.PIKMIN_IMAGES["blueFlowerRight2"]);

                    aniDict.Add("stand", Game1.PIKMIN_IMAGES["blueFlowerFront"]);

                    velX = 2;
                    velY = 2;
                    sight = 0;
                    attackPower = 0;
                }
            }
            #endregion
            #region Red Pikmin
            else if (type.Equals("red")) //Red
            {
                if (level == 1) //Red Leaf
                {
                    aniDict.Add("right1", Game1.PIKMIN_IMAGES["redLeafRight1"]);
                    aniDict.Add("right2", Game1.PIKMIN_IMAGES["redLeafRight2"]);
                    aniDict.Add("right3", Game1.PIKMIN_IMAGES["redLeafRight3"]);
                    aniDict.Add("right4", Game1.PIKMIN_IMAGES["redLeafRight2"]);

                    aniDict.Add("stand", Game1.PIKMIN_IMAGES["redLeafFront"]);

                    velX = 1;
                    velY = 1;
                    sight = 0;
                    attackPower = 0;
                }
                else if (level == 2) //Red Bud
                {
                    aniDict.Add("right1", Game1.PIKMIN_IMAGES["redBudRight1"]);
                    aniDict.Add("right2", Game1.PIKMIN_IMAGES["redBudRight2"]);
                    aniDict.Add("right3", Game1.PIKMIN_IMAGES["redBudRight3"]);
                    aniDict.Add("right4", Game1.PIKMIN_IMAGES["redBudRight2"]);

                    aniDict.Add("stand", Game1.PIKMIN_IMAGES["redLeafFront"]);//*** NEED BUD IMAGE ***\\

                    velX = 1.5;
                    velY = 1.5;
                    sight = 0;
                    attackPower = 0;
                }
                else //Red Flower
                {
                    aniDict.Add("right1", Game1.PIKMIN_IMAGES["redFlowerRight1"]);
                    aniDict.Add("right2", Game1.PIKMIN_IMAGES["redFlowerRight2"]);
                    aniDict.Add("right3", Game1.PIKMIN_IMAGES["redFlowerRight3"]);
                    aniDict.Add("right4", Game1.PIKMIN_IMAGES["redFlowerRight2"]);

                    aniDict.Add("stand", Game1.PIKMIN_IMAGES["redLeafFront"]);//*** NEED FLOWER IMAGE ***\\

                    velX = 2;
                    velY = 2;
                    sight = 0;
                    attackPower = 0;
                }
            }
            #endregion
            #region Yellow Pikmin
            else if(type.Equals("yellow")) //Yellow
            {
                if(level == 1) //Yellow Leaf
                {
                    aniDict.Add("right1", Game1.PIKMIN_IMAGES["yellowLeafRight1"]);
                    aniDict.Add("right2", Game1.PIKMIN_IMAGES["yellowLeafRight2"]);
                    aniDict.Add("right3", Game1.PIKMIN_IMAGES["yellowLeafRight3"]);
                    aniDict.Add("right4", Game1.PIKMIN_IMAGES["yellowLeafRight2"]);

                    aniDict.Add("stand", Game1.PIKMIN_IMAGES["yellowLeafFront"]);

                    velX = 1;
                    velY = 1;
                    sight = 0;
                    attackPower = 0;
                }
                else if (level == 2) //Yellow Bud
                {
                    aniDict.Add("right1", Game1.PIKMIN_IMAGES["yellowBudRight1"]);
                    aniDict.Add("right2", Game1.PIKMIN_IMAGES["yellowBudRight2"]);
                    aniDict.Add("right3", Game1.PIKMIN_IMAGES["yellowBudRight3"]);
                    aniDict.Add("right4", Game1.PIKMIN_IMAGES["yellowBudRight2"]);

                    aniDict.Add("stand", Game1.PIKMIN_IMAGES["yellowLeafFront"]);//*** NEED BUD IMAGE ***\\

                    velX = 1.5;
                    velY = 1.5;
                    sight = 0;
                    attackPower = 0;
                }
                else //Yellow Flower
                {
                    aniDict.Add("right1", Game1.PIKMIN_IMAGES["yellowFlowerRight1"]);
                    aniDict.Add("right2", Game1.PIKMIN_IMAGES["yellowFlowerRight2"]);
                    aniDict.Add("right3", Game1.PIKMIN_IMAGES["yellowFlowerRight3"]);
                    aniDict.Add("right4", Game1.PIKMIN_IMAGES["yellowFlowerRight2"]);

                    aniDict.Add("stand", Game1.PIKMIN_IMAGES["yellowLeafFront"]);//*** NEED FLOWER IMAGE ***\\

                    velX = 2;
                    velY = 2;
                    sight = 0;
                    attackPower = 0;
                }
            }
            #endregion
            #region White Pikmin
            else if (type.Equals("white")) //White
            {
                if (level == 1) //White Leaf
                {
                    aniDict.Add("right1", Game1.PIKMIN_IMAGES["whiteLeafRight1"]);
                    aniDict.Add("right2", Game1.PIKMIN_IMAGES["whiteLeafRight2"]);
                    aniDict.Add("right3", Game1.PIKMIN_IMAGES["whiteLeafRight3"]);
                    aniDict.Add("right4", Game1.PIKMIN_IMAGES["whiteLeafRight2"]);

                    aniDict.Add("stand", Game1.PIKMIN_IMAGES["whiteLeafFront"]);

                    velX = 1.5;
                    velY = 1.5;
                    sight = 0;
                    attackPower = 0;
                }
                else if (level == 2) //White Bud
                {
                    aniDict.Add("right1", Game1.PIKMIN_IMAGES["whiteBudRight1"]);
                    aniDict.Add("right2", Game1.PIKMIN_IMAGES["whiteBudRight2"]);
                    aniDict.Add("right3", Game1.PIKMIN_IMAGES["whiteBudRight3"]);
                    aniDict.Add("right4", Game1.PIKMIN_IMAGES["whiteBudRight2"]);

                    aniDict.Add("stand", Game1.PIKMIN_IMAGES["whiteLeafFront"]);//*** NEED BUD IMAGE ***\\

                    velX = 2.5;
                    velY = 2.5;
                    sight = 0;
                    attackPower = 0;
                }
                else //White Flower
                {
                    aniDict.Add("right1", Game1.PIKMIN_IMAGES["whiteFlowerRight1"]);
                    aniDict.Add("right2", Game1.PIKMIN_IMAGES["whiteFlowerRight2"]);
                    aniDict.Add("right3", Game1.PIKMIN_IMAGES["whiteFlowerRight3"]);
                    aniDict.Add("right4", Game1.PIKMIN_IMAGES["whiteFlowerRight2"]);

                    aniDict.Add("stand", Game1.PIKMIN_IMAGES["whiteLeafFront"]);//*** NEED FLOWER IMAGE ***\\

                    velX = 3.5;
                    velY = 3.5;
                    sight = 0;
                    attackPower = 0;
                }
            }
            #endregion
            #region Purple Pikmin
            /*
            else if (type.Equals("purple")) //Purple
            {
                if (level == 1) //Purple Leaf
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleLeafRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleLeafRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleLeafRight3"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleLeafRight2"]);

                    frontImage = Game1.PIKMIN_IMAGES["purpleLeafFront"];

                    velX = 2;
                    velY = 2;
                    sight = 0;
                    attackPower = 0;
                }
                else if (level == 2) //Purple Bud
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleBudRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleBudRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleBudRight3"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleBudRight2"]);

                    frontImage = Game1.PIKMIN_IMAGES["purpleLeafFront"];//*** NEED BUD IMAGE ***\\

                    velX = 2;
                    velY = 2;
                    sight = 0;
                    attackPower = 0;
                }
                else //Purple Flower
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleFlowerRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleFlowerRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleFlowerRight3"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["purpleFlowerRight2"]);

                    frontImage = Game1.PIKMIN_IMAGES["purpleLeafFront"];//*** NEED FLOWER IMAGE ***\\

                    velX = 2;
                    velY = 2;
                    sight = 0;
                    attackPower = 0;
                }
            }
            */
            #endregion
            #region Rock Pikmin
            /*
            else if (type.Equals("rock")) //Rock
            {
                if (level == 1) //Rock Leaf
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockLeafRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockLeafRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockLeafRight3"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockLeafRight2"]);

                    frontImage = Game1.PIKMIN_IMAGES["rockLeafFront"];

                    velX = 2;
                    velY = 2;
                    sight = 0;
                    attackPower = 0;
                }
                else if (level == 2) //Rock Bud
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockBudRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockBudRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockBudRight3"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockBudRight2"]);

                    frontImage = Game1.PIKMIN_IMAGES["rockLeafFront"];//*** NEED BUD IMAGE ***\\

                    velX = 2;
                    velY = 2;
                    sight = 0;
                    attackPower = 0;
                }
                else //Rock Flower
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockFlowerRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockFlowerRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockFlowerRight3"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["rockFlowerRight2"]);

                    frontImage = Game1.PIKMIN_IMAGES["rockLeafFront"];//*** NEED FLOWER IMAGE ***\\

                    velX = 2;
                    velY = 2;
                    sight = 0;
                    attackPower = 0;
                }
            }
            */
            #endregion
            #region Flying Pikmin
            /*
            else if (type.Equals("flying")) //Flying
            {
                if (level == 1) //Flying Leaf
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingLeafRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingLeafRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingLeafRight3"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingLeafRight2"]);

                    frontImage = Game1.PIKMIN_IMAGES["flyingLeafFront"];

                    velX = 2;
                    velY = 2;
                    sight = 0;
                    attackPower = 0;
                }
                else if (level == 2) //Flying Bud
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingBudRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingBudRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingBudRight3"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingBudRight2"]);

                    frontImage = Game1.PIKMIN_IMAGES["flyingLeafFront"];//*** NEED BUD IMAGE ***\\

                    velX = 2;
                    velY = 2;
                    sight = 0;
                    attackPower = 0;
                }
                else //Flying Flower
                {
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingFlowerRight1"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingFlowerRight2"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingFlowerRight3"]);
                    rightAnimation.Add(Game1.PIKMIN_IMAGES["flyingFlowerRight2"]);

                    frontImage = Game1.PIKMIN_IMAGES["flyingLeafFront"];//*** NEED FLOWER IMAGE ***\\

                    velX = 2;
                    velY = 2;
                    sight = 0;
                    attackPower = 0;
                }
            }
            */
            #endregion

            setBuffer((int)(10-velX*2));
            startVelX = velX;
            startVelY = velY;
            setWidth(aniDict["stand"].Width);
            setHeight(aniDict["stand"].Height);
            setAnimations(aniDict);
            
        }
        ///////////////////////////////
        ////  End of initImages()  ////
        ///////////////////////////////

        /// <summary>
        /// Commands the pikmin to move towards a certain location.
        /// </summary>
        /// <param name="loc">(Vector2) location</param>
        public void moveTowards(Vector2 loc)
        {
            this.reanimate();
            if (getX() < loc.X)
                if ((loc.X - getX()) <= velX)
                    setX((int)(getX() + (loc.X - getX())));
                else
                    move("east");
            else if (getX() > loc.X)
                if ((getX() - loc.X) <= velX)
                    setX((int)(getX() - (getX() - loc.X)));
                else
                    move("west");


            if (getY() < loc.Y)
                if ((loc.Y - getY()) <= velY)
                    setY((int)(getY() + (loc.Y - getY())));
                else
                    move("south");
            else if (getY() > loc.Y)
                if ((getY() - loc.Y) <= velY)
                    setY((int)(getY() - (getY() - loc.Y)));
                else
                    move("north");

            if (northCollision)
            {
                northCollision = false;
                move("south");
            }
            else if (eastCollision)
            {
                eastCollision = false;
                move("west");
            }
            else if (southCollision)
            {
                southCollision = false;
                move("north");
            }
            else if (westCollision)
            {
                westCollision = false;
                move("east");
            }
        }


        /// <summary>
        /// Moves a specific NESW direction
        /// </summary>
        /// <param name="direction">(string) none,north,east,south,west, or in between</param>
        public void move(string direction)
        {
            if (direction.Equals("none"))
            {
                this.unanimate();
                return;
            }
            else if (direction.Equals("north"))
            {
                setY((int)(getY() - velY));
            }
            else if (direction.Equals("northeast"))
            {
                setY((int)(getY() - velY));
                setX((int)(getX() + velX));
            }
            else if (direction.Equals("east"))
            {
                setX((int)(getX() + velX));
            }
            else if (direction.Equals("southeast"))
            {
                setY((int)(getY() + velY));
                setX((int)(getX() + velX));
            }
            else if (direction.Equals("south"))
            {
                setY((int)(getY() + velY));
            }
            else if (direction.Equals("southwest"))
            {
                setY((int)(getY() + velY));
                setX((int)(getX() - velX));
            }
            else if (direction.Equals("west"))
            {
                setX((int)(getX() - velX));
            }
            else if (direction.Equals("northwest"))
            {
                setY((int)(getY() - velY));
                setX((int)(getX() - velX));
            }
            this.reanimate();

            if (northCollision)
            {
                northCollision = false;
                move("south");
            } 
            else if (eastCollision)
            {
                eastCollision = false;
                move("west");
            }
            else if (southCollision)
            {
                southCollision = false;
                move("north");
            }
            else if (westCollision)
            {
                westCollision = false;
                move("east");
            }
        }


        /// <summary>
        /// If any collision is detected
        /// </summary>
        /// <param name="type">(string) type of collision</param>
        public void collision(string type)
        {
            if (type.Equals("west"))
                westCollision = true;
            else if (type.Equals("east"))
                eastCollision = true;
            else if (type.Equals("north"))
                northCollision = true;
            else if (type.Equals("south"))
                southCollision = true;
        }


        public string getType()
        {
            return type;
        }


        /// <summary>
        /// Levels the pikmin to the next life cycle
        /// </summary>
        public void levelUp()
        {
            if (level == 3)
                return;
            level += 1;
            initPikmin();
        }

        /// <summary>
        /// Brings the pikmin back to the leaf stage in it's life cycle.
        /// </summary>
        public void levelDown()
        {
            level = 1;
            initPikmin();
        }


        /// <summary>
        /// Compares the positions of an object compared to this one
        /// </summary>
        /// <param name="o">object used for comparison</param>
        new public string compareTo(CollisionObject o)
        {
            if (this.getX() + this.getWidth() >= o.getX() &&
                this.getX() <= o.getX() + o.getWidth() &&
                this.getY() + this.getHeight() >= o.getY() &&
                this.getY() <= o.getY() + o.getHeight())
            {
                return "collision";
            }
            return "none";
        }


        new public void draw(SpriteBatch spriteBatch)
        {
            #region Right movement
            if (this.facingRight)
            {
                if (this.aniCount > this.maxAniCount)
                    this.aniCount = 1;
                switch (this.aniCount)
                {
                    case 1:
                        spriteBatch.Draw(animations["right1"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    case 2:
                        spriteBatch.Draw(animations["right2"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    case 3:
                        spriteBatch.Draw(animations["right3"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    case 4:
                        spriteBatch.Draw(animations["right4"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    default:
                        break;
                }
            }
            #endregion
            #region Left movement (Under Construction)
            else if (this.facingLeft)
            {
                if (this.aniCount > this.maxAniCount)
                    this.aniCount = 1;
                switch (this.aniCount)
                {
                    case 1:
                        spriteBatch.Draw(animations["right1"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    case 2:
                        spriteBatch.Draw(animations["right2"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    case 3:
                        spriteBatch.Draw(animations["right3"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    case 4:
                        spriteBatch.Draw(animations["right4"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    default:
                        break;
                }
            }
            #endregion
            else
                spriteBatch.Draw(animations["stand"], this.position, Color.White);
        }
    }
}
