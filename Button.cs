using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pikmin_4
{
    class Button
    {
        private int x, y, width, height;
        /// <summary>
        /// 'x' and 'y' coordinate for this button
        /// </summary>
        private Vector2 position;
        /// <summary>
        /// Image representation of the button
        /// </summary>
        private Texture2D image;
        /// <summary>
        /// String representation of the state to be switched to
        /// </summary>
        private String stateChange;
        /// <summary>
        /// Boolean representing whether or not button is selected
        /// </summary>
        private bool selected;
        /// <summary>
        /// Boolean representing whether or not button is clicked
        /// </summary>
        private bool clicked;

        /// <summary>
        /// Constructor for a Button.
        /// </summary>
        /// <param name="nx">(int) X position</param>
        /// <param name="ny">(int) Y position</param>
        /// <param name="w">(int) Width</param>
        /// <param name="h">(int) Height</param>
        /// <param name="state">(String) State to change to if button is clicked</param>
        /// <param name="im">(Texture2D) Image</param>
        public Button(int nx, int ny, int w, int h, String state, Texture2D im)
        {
            x = nx;
            y = ny;
            width = w;
            height = h;
            selected = false;
            clicked = false;
            stateChange = state;

            position = new Vector2(x, y);
            image = im;
        }

        /// <summary>
        /// Returns the position of the Button.
        /// </summary>
        /// <returns>(Vector2) position</returns>
        public Vector2 getPosition()
        {
            return position;
        }

        /// <summary>
        /// Returns the image of the button.
        /// </summary>
        /// <returns>(Texture2D) image</returns>
        public Texture2D getImage()
        {
            return image;
        }

        /// <summary>
        /// Returns the width of the button.
        /// </summary>
        /// <returns>(int) width</returns>
        public int getWidth()
        {
            return width;
        }

        /// <summary>
        /// Returns the height of the Button
        /// </summary>
        /// <returns>(int) height</returns>
        public int getHeight()
        {
            return height;
        }

        /// <summary>
        /// Returns whether the button is selected
        /// </summary>
        /// <returns>(bool) selected</returns>
        public bool isSelected()
        {
            return selected;
        }

        /// <summary>
        /// Forces the button to be selected
        /// </summary>
        public void forceSelect()
        {
            selected = true;
        }

        /// <summary>
        /// Makes the button unselected
        /// </summary>
        public void unselect()
        {
            selected = false;
        }

        /// <summary>
        /// Sets clicked to true
        /// </summary>
        /// <returns>(String) stateChange</returns>
        public String click()
        {
            clicked = true;
            return stateChange;
        }


        public bool isClicked()
        {
            return clicked;
        }
    }
}
