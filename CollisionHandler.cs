using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Pikmin_4
{
    class CollisionHandler
    {
        public static void update()
        {
            checkCollisons();
        }

        /// <summary>
        /// Checks all collisions in Game1.COLLISIONS Dictionary.
        /// </summary>
        public static void checkCollisons()
        {
            CollisionObject cursor = (CollisionObject)Game1.COLLISIONS["cursor"];
            if(Game1.baseState.Equals("main")) // if the title screen is in session
            {
                Button b = (Button)Game1.COLLISIONS["playButton"];
                if ( !b.isSelected() &&
                    b.compareTo(cursor).Equals("collision"))
                {
                    b.forceSelect();
                }
                else if (b.isSelected() &&
                    b.compareTo(cursor).Equals("none"))
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

                if (!GameState.isInitiated)
                    return;
                List<Pikmin> pikminList = (List<Pikmin>)Game1.COLLISIONS["pikminList"];
                for (int i = 0; i < pikminList.Count(); i++)
                {
                    if (pikminList.Count() <= 1  ||  i+1 == (pikminList.Count()-1))
                        break;
                    for (int i2 = 0; i2 < pikminList.Count(); i2++)
                    {
                        if (i == i2)
                            continue;
                        else if (pikminList[i].compareTo(pikminList[i2]).Equals("collision"))//Jank collision (temporary)
                        {
                            pikminList[i].collisionFromBottom();
                            pikminList[i2].collisionFromTop();
                        }
                        /*
                        // Collision from the left
                        if (pikminList[i].getX()  + (pikminList[i].getWidth() / 2) <= pikminList[i2].getX() + pikminList[i2].getWidth() &&
                            pikminList[i].getX() <= pikminList[i2].getX() + pikminList[i2].getWidth() &&
                            pikminList[i].getY() <= pikminList[i2].getY() + pikminList[i2].getHeight() &&
                            pikminList[i].getY() + pikminList[i].getHeight() >= pikminList[i2].getY())
                        {
                            pikminList[i].collisionFromLeft();
                            pikminList[i2].collisionFromRight();
                        }
                        // Collision from the right
                        else if (pikminList[i].getX() + (pikminList[i].getWidth() / 2) >= pikminList[i2].getX() &&
                            pikminList[i].getX() + pikminList[i].getWidth() >= pikminList[i2].getX() &&
                            pikminList[i].getY() <= pikminList[i2].getY() + pikminList[i2].getHeight() &&
                            pikminList[i].getY() + pikminList[i].getHeight() >= pikminList[i2].getY())
                        {
                            pikminList[i].collisionFromRight();
                            pikminList[i2].collisionFromLeft();
                        }

                        // Collision from top
                        if (pikminList[i].getX() + pikminList[i].getWidth() >= pikminList[i2].getX() && //correct
                            pikminList[i].getX() <= pikminList[i2].getX() + pikminList[i2].getWidth() && //correct
                            pikminList[i].getY() + pikminList[i].getHeight() >= pikminList[i2].getY() &&
                            pikminList[i].getY() <= pikminList[i2].getY())//correct
                        {
                            pikminList[i].collisionFromTop();
                            pikminList[i2].collisionFromBottom();
                        }
                        // Collision from bottom
                        else if (pikminList[i].getX() + pikminList[i].getWidth() >= pikminList[i2].getX() &&
                            pikminList[i].getX() <= pikminList[i2].getX() + pikminList[i2].getWidth() &&
                            pikminList[i].getY() + pikminList[i].getHeight() >= (pikminList[i2].getY() + pikminList[i2].getHeight() / 2) + (pikminList[i2].getHeight() / 2) &&
                            pikminList[i].getY() + pikminList[i].getHeight() <= pikminList[i2].getY() + pikminList[i2].getHeight())
                        {
                            pikminList[i].collisionFromBottom();
                            pikminList[i2].collisionFromTop();
                        }
                         */
                    }
                }
                
            }
        }
    }
}
