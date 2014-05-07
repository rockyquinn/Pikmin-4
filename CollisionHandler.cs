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
            if(Game1.baseState.Equals("main")) // if the title screen is in session
            {
                Button b = (Button)Game1.COLLISIONS["playButton"];
                if ( !b.isSelected() &&
                    Cursor.X >= b.getPosition().X &&
                    Cursor.X <= (b.getPosition().X+b.getWidth()) &&
                    Cursor.Y >= b.getPosition().Y &&
                    Cursor.Y <= (b.getPosition().Y+b.getHeight()))
                {
                    b.forceSelect();
                }
                else if (b.isSelected() &&
                    (Cursor.X < b.getPosition().X ||
                    Cursor.X > (b.getPosition().X + b.getWidth()) ||
                    Cursor.Y < b.getPosition().Y ||
                    Cursor.Y > (b.getPosition().Y + b.getHeight())))
                {
                    b.unselect();
                }
                else if (b.isSelected() &&
                    Cursor.leftClicked)
                {
                    b.click();
                }
            }
            else if (Game1.baseState.Equals("game")) // if the game is in session
            {
                /*
                List<Pikmin> pikminList = (List<Pikmin>)Game1.COLLISIONS["pikminList"];
                for (int i = 0; i < pikminList.Count(); i++)
                {
                    if (pikminList.Count() <= 1  ||  i+1 == (pikminList.Count()-1))
                        break;
                    for (int i2 = i+1; i2 < pikminList.Count(); i2++)
                    {
                        //if( (pikminList[i].getPosition().X) <= 
                    }
                }
                */
            }
        }
    }
}
