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
        private Vector2 position;
        private Texture2D image;

        public Button(int nx, int ny, int w, int h, Texture2D i)
        {
            x = nx;
            y = ny;
            width = w;
            height = h;

            position = new Vector2(x, y);
            image = i;
        }


        public Vector2 getPosition()
        {
            return position;
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }
    }
}
