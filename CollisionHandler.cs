using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Pikmin_4
{
    class CollisionHandler
    {
        /// <summary>
        /// Empty constructor for a CollisionHandler
        /// </summary>
        public CollisionHandler()
        {
        }

        public static void update()
        {
            checkCollisons();
        }

        /// <summary>
        /// Checks all collisions in Game1.COLLISIONS Dictionary.
        /// </summary>
        public static void checkCollisons()
        {
            //Game1.COLLISIONS["playButton"]
            //Game1.COLLISIONS["cursor"]
            /*
            if(Game1.COLLISIONS["cursor"].getX() >= Game1.COLLISIONS["playButton"].getX() &&
                Game1.COLLISIONS["cursor"].getX() <= Game1.COLLISIONS["playButton"].getX() &&
                Game1.COLLISIONS["cursor"].getY() >= Game1.COLLISIONS["playButton"].getY() &&
                Game1.COLLISIONS["cursor"].getY() <= Game1.COLLISIONS["playButton"].getY())
            {

            }
            */
            Cursor c = (Cursor)Game1.COLLISIONS["cursor"];
            Button b = (Button)Game1.COLLISIONS["playButton"];
            if ( !b.isSelected() &&
                c.getPosition().X >= b.getPosition().X &&
                c.getPosition().X <= (b.getPosition().X+b.getWidth()) &&
                c.getPosition().Y >= b.getPosition().Y &&
                c.getPosition().Y <= (b.getPosition().Y+b.getHeight()))
            {
                b.forceSelect();
            }
            else if (b.isSelected() &&
                (c.getPosition().X < b.getPosition().X ||
                 c.getPosition().X > (b.getPosition().X + b.getWidth()) ||
                 c.getPosition().Y < b.getPosition().Y ||
                 c.getPosition().Y > (b.getPosition().Y + b.getHeight())))
            {
                b.unselect();
            }
            else if (b.isSelected() &&
                c.isLeftClicked())
            {
                b.click();
            }
        }
    }
}
