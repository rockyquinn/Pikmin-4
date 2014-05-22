using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Pikmin_4
{
    class GameState
    {
        /// <summary>
        /// A list of all Pikmin on the field.
        /// </summary>
        public static List<Pikmin> allPikmin;

        public static bool isInitiated = false;

        private static Cursor cursor;

        /// <summary>
        /// Initiates the static GameState class.
        /// </summary>
        public static void initiate(Cursor c)
        {
            allPikmin = new List<Pikmin>();
            allPikmin.Add(new Pikmin("blue", 3, 0, 0));
            allPikmin.Add(new Pikmin("white", 3, 0, 100));
            allPikmin.Add(new Pikmin("white", 1, 0, 100));
            Game1.COLLISIONS.Add("pikminList", allPikmin);

            cursor = c;

            isInitiated = true;
        }

        /// <summary>
        /// Update function called every frame.
        /// </summary>
        public static void update()
        {
            if (!isInitiated)
                return;
            Vector2 loc = new Vector2(Game1.mState.X,Game1.mState.Y);
            for(int i=0; i<allPikmin.Count(); i++)
            {
                allPikmin[i].moveTowards(loc);
            }
        }

        /// <summary>
        /// Draw function called every frame.
        /// </summary>
        public static void draw(SpriteBatch spriteBatch)
        {
            if (!isInitiated)
                return;
            for (int i = 0; i < allPikmin.Count(); i++)
            {
                allPikmin[i].draw(spriteBatch);
            }
        }
    }
}
