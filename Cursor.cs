using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pikmin_4
{
    class Cursor
    {
        public static int x, y;
        private Vector2 POSITION;

        public Cursor()
        {
            x = Game1.mState.X;
            y = Game1.mState.Y;
            POSITION = new Vector2(x, y);
        }


        public void update()
        {
            x = Game1.mState.X;
            y = Game1.mState.Y;
            POSITION = new Vector2(x, y);
        }

        public Vector2 getPosition()
        {
            return POSITION;
        }
    }
}
