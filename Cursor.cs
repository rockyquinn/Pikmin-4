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
    class Cursor
    {
        /// <summary>
        /// 
        /// </summary>
        public static int X, Y;

        /// <summary>
        /// 'x' and 'y' coordinates of the cursor.
        /// </summary>
        public static Vector2 POSITION;

        /// <summary>
        /// Image of the button
        /// </summary>
        public static Texture2D IMAGE;

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
        public static void initiate(Texture2D i)
        {
            X = Game1.mState.X;
            Y = Game1.mState.Y;
            POSITION = new Vector2(X, Y);
            IMAGE = i;
            leftClicked = false;
        }


        /// <summary>
        /// Updates the cursor's location
        /// </summary>
        public static void update()
        {
            X = Game1.mState.X;
            Y = Game1.mState.Y;
            POSITION = new Vector2(X, Y);

            if (Game1.mState.LeftButton == ButtonState.Pressed)
                leftClicked = true;
            else
                leftClicked = false;
        }
    }
}
