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
        private int x, y;

        /// <summary>
        /// 'x' and 'y' coordinates of the cursor.
        /// </summary>
        private Vector2 position;

        /// <summary>
        /// Image of the button
        /// </summary>
        private Texture2D image;

        /// <summary>
        /// Boolean representation of whether or not the left mouse button
        /// was clicked in this frame.
        /// </summary>
        public static bool leftClicked;

        /// <summary>
        /// Constructor for a Cursor
        /// </summary>
        /// <param name="i">(Texture2D) Button image</param>
        public Cursor(Texture2D i)
        {
            x = Game1.mState.X;
            y = Game1.mState.Y;
            position = new Vector2(x, y);
            image = i;
            leftClicked = false;
        }


        /// <summary>
        /// Updates the cursor's location
        /// </summary>
        public void update()
        {
            x = Game1.mState.X;
            y = Game1.mState.Y;
            position = new Vector2(x, y);

            if (Game1.mState.LeftButton == ButtonState.Pressed)
                leftClicked = true;
            else
                leftClicked = false;
        }


        /// <summary>
        /// Returns the 'x' and 'y' coordinate of cursor.
        /// </summary>
        /// <returns>(Vector2) Cursor position</returns>
        public Vector2 getPosition()
        {
            return position;
        }


        /// <summary>
        /// Returns the image of the button.
        /// </summary>
        /// <returns>(Texture2D) Button image</returns>
        public Texture2D getImage()
        {
            return image;
        }


        /// <summary>
        /// Sets the button's image to a new image.
        /// </summary>
        /// <param name="i">New image</param>
        public void setImage(Texture2D i)
        {
            image = i;
        }


        public bool isLeftClicked()
        {
            return leftClicked;
        }
    }
}
