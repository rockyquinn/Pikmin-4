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
            if(Game1.baseState.Equals("main")) // if the title screen is in session
            {
                Button b = (Button)Game1.COLLISIONS["playButton"];
                Button b2 = (Button)Game1.COLLISIONS["optionsButton"];
                if ( !b.isSelected() &&
                    b.compareTo((CollisionObject)Game1.COLLISIONS["cursor"]).Equals("collision"))
                {
                    b.forceSelect();
                }
                else if (b.isSelected() &&
                    b.compareTo((CollisionObject)Game1.COLLISIONS["cursor"]).Equals("none"))
                {
                    b.unselect();
                }
                else if (b.isSelected() &&
                    Cursor.leftClicked)
                {
                    b.click();
                }


                if (!b2.isSelected() &&
                    b2.compareTo((CollisionObject)Game1.COLLISIONS["cursor"]).Equals("collision"))
                {
                    b2.forceSelect();
                }
                else if (b2.isSelected() &&
                    b2.compareTo((CollisionObject)Game1.COLLISIONS["cursor"]).Equals("none"))
                {
                    b2.unselect();
                }
                else if (b2.isSelected() &&
                    Cursor.leftClicked)
                {
                    b2.click();
                }
            }
            else if (Game1.baseState.Equals("game")) // if the game is in session
            {

                if (!GameState.isInitiated)
                    return;
                List<Pikmin> pikminList = (List<Pikmin>)Game1.COLLISIONS["pikminList"];
                for (int i = 0; i < pikminList.Count(); i++)
                {
                    for (int i2 = 0; i2 < pikminList.Count(); i2++)
                    {
                        if (i >= i2)
                            continue;
                        else if (pikminList[i].compareTo(pikminList[i2]).Equals("collision"))
                        {
                            if (!pikminList[i].getCollidable())
                                continue;
                            pikminList[i].collision("south");
                            pikminList[i2].collision("north");
                        }
                    }
                }
            }
            else if (Game1.baseState.Equals("options"))//if the option screen is displayed.
            { 
                //Options collisions (Buttons and stuff)\\
            }
        }
    }
}
