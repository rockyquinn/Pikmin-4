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
            if (type.Equals("olimar"))
            {
                right.Add(Game1.PLAYER_IMAGES["olimarRight1"]);
                right.Add(Game1.PLAYER_IMAGES["olimarRight2"]);
                right.Add(Game1.PLAYER_IMAGES["olimarRight3"]);
                right.Add(Game1.PLAYER_IMAGES["olimarRight4"]);
                right.Add(Game1.PLAYER_IMAGES["olimarRight5"]);
                right.Add(Game1.PLAYER_IMAGES["olimarRight4"]);
                right.Add(Game1.PLAYER_IMAGES["olimarRight3"]);
                right.Add(Game1.PLAYER_IMAGES["olimarRight2"]);

                this.setRightAnimations(right);
                this.setLeftAnimations(right);
                this.setStand(right[2]);
                this.setWidth(right[2].Width);
                this.setHeight(right[2].Height);
                this.setBuffer((int)(8 - velX * 2));

                velX = 4;
                velY = 4;
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
    }
}
