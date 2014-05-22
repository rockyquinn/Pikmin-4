using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pikmin_4
{
    class Cursor : CollisionObject
    {
        /// <summary>
        /// Boolean representation of whether or not the left mouse button
        /// was clicked in this frame.
        /// </summary>
        public static bool leftClicked;

        /// <summary>
        /// True if Cursor has been initiated
        /// </summary>
        public static bool initiated = false;

        /// <summary>
        /// Initiates the cursor
        /// </summary>
        /// <param name="i">(Texture2D) Button image</param>
        public Cursor(Texture2D i) : base("Cursor", Game1.mState.X, Game1.mState.Y, i)
        {
            leftClicked = false;
        }


        /// <summary>
        /// Updates the cursor's location
        /// </summary>
        public void update()
        {
            setPosition(Game1.mState.X, Game1.mState.Y);

            if (Game1.mState.LeftButton == ButtonState.Pressed)
                leftClicked = true;
            else
                leftClicked = false;
        }
    }
}
