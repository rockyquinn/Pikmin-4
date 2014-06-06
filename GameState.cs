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
            allPikmin.Add(new Pikmin("blue", 3, 500, 300));
            allPikmin.Add(new Pikmin("white", 3, 400, 300));
            allPikmin.Add(new Pikmin("white", 1, 300, 300));
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
            //Vector2 loc = new Vector2(Game1.mState.X,Game1.mState.Y);
            string direction = "none";
            if (Game1.kbState.IsKeyDown(Keys.D))
            {
                direction = "east";
                if (Game1.kbState.IsKeyDown(Keys.W))
                    direction = "northeast";
                if (Game1.kbState.IsKeyDown(Keys.S))
                    direction = "southeast";
                if (Game1.kbState.IsKeyDown(Keys.A))
                    direction = "none";
            }
            else if (Game1.kbState.IsKeyDown(Keys.W))
            {
                direction = "north";
                if (Game1.kbState.IsKeyDown(Keys.A))
                    direction = "northwest";
                if (Game1.kbState.IsKeyDown(Keys.S))
                    direction = "none";
            }
            else if (Game1.kbState.IsKeyDown(Keys.S))
            {
                direction = "south";
                if (Game1.kbState.IsKeyDown(Keys.A))
                    direction = "southwest";
            }
            else if (Game1.kbState.IsKeyDown(Keys.A))
            {
                direction = "west";
            }
            for(int i=0; i<allPikmin.Count(); i++)
            {
                allPikmin[i].move(direction);
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
