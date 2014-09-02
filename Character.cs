using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pikmin_4
{
    class Character : CollisionObject
    {
        /// <summary>
        /// Speed and Direction of this character.
        /// </summary>
        private int velX, velY;


        private bool eastCollision, westCollision, northCollision, southCollision;


        public Character(int nx, int ny, string type) : base("Character", nx, ny)
        {
            List<Texture2D> right = new List<Texture2D>();
            eastCollision = false;
            westCollision = false;
            northCollision = false;
            southCollision = false;
            Dictionary<String, Texture2D> aniDict = new Dictionary<String, Texture2D>();
            #region Olimar
            if (type.Equals("olimar"))
            {
                aniDict.Add("right1", Game1.PLAYER_IMAGES["olimarRight1"]);
                aniDict.Add("right2", Game1.PLAYER_IMAGES["olimarRight2"]);
                aniDict.Add("right3", Game1.PLAYER_IMAGES["olimarRight3"]);
                aniDict.Add("right4", Game1.PLAYER_IMAGES["olimarRight4"]);
                aniDict.Add("right5", Game1.PLAYER_IMAGES["olimarRight5"]);
                aniDict.Add("right6", Game1.PLAYER_IMAGES["olimarRight4"]);
                aniDict.Add("right7", Game1.PLAYER_IMAGES["olimarRight3"]);
                aniDict.Add("right8", Game1.PLAYER_IMAGES["olimarRight2"]);

                aniDict.Add("stand", Game1.PLAYER_IMAGES["olimarRight2"]);

                this.setBuffer((int)(8 - velX * 2));

                velX = 4;
                velY = 4;
            }
            #endregion

            this.setAnimations(aniDict);
            this.setWidth(aniDict["stand"].Width);
            this.setHeight(aniDict["stand"].Height);
            this.maxAniCount = 8;
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
                    case 5:
                        spriteBatch.Draw(animations["right5"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    case 6:
                        spriteBatch.Draw(animations["right6"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    case 7:
                        spriteBatch.Draw(animations["right7"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    case 8:
                        spriteBatch.Draw(animations["right8"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    default:
                        break;
                }
            }
            #endregion
            #region Left movement (Under Construction)
            if (this.facingLeft)
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
                    case 5:
                        spriteBatch.Draw(animations["right5"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    case 6:
                        spriteBatch.Draw(animations["right6"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    case 7:
                        spriteBatch.Draw(animations["right7"], this.position, Color.White);
                        this.aniCount++;
                        break;
                    case 8:
                        spriteBatch.Draw(animations["right8"], this.position, Color.White);
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
