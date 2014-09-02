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

        public static Cursor cursor;

        /// <summary>
        /// Initiates the static GameState class.
        /// </summary>
        public static void initiate(Cursor c)
        {
            allPikmin = new List<Pikmin>();
            allPikmin.Add(new Pikmin("blue", 3, 300, 300));
            allPikmin.Add(new Pikmin("blue", 2, 310, 310));
            allPikmin.Add(new Pikmin("blue", 1, 320, 320));
            allPikmin.Add(new Pikmin("red", 3, 330, 330));
            allPikmin.Add(new Pikmin("red", 2, 340, 340));
            allPikmin.Add(new Pikmin("red", 1, 350, 350));
            allPikmin.Add(new Pikmin("yellow", 3, 360, 360));
            allPikmin.Add(new Pikmin("yellow", 2, 370, 370));
            allPikmin.Add(new Pikmin("yellow", 1, 380, 380));
            allPikmin.Add(new Pikmin("white", 3, 390, 390));
            allPikmin.Add(new Pikmin("white", 2, 400, 400));
            allPikmin.Add(new Pikmin("white", 1, 410, 410));

            Character ch = new Character(100, 100, "olimar");

            Game1.COLLISIONS.Add("pikminList", allPikmin);
            Game1.COLLISIONS.Add("character", ch);

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

            if (Game1.kbState.IsKeyDown(Keys.Q))
            {
                for (int i = 0; i < allPikmin.Count(); i++)
                {
                    allPikmin[i].reanimate();
                    if (allPikmin[i].getType().Equals("yellow"))
                        allPikmin[i].moveTowards(new Vector2(200, 200));
                    else if (allPikmin[i].getType().Equals("red"))
                        allPikmin[i].moveTowards(new Vector2(300, 100));
                    else if (allPikmin[i].getType().Equals("blue"))
                        allPikmin[i].moveTowards(new Vector2(400, 200));
                    else if (allPikmin[i].getType().Equals("white"))
                        allPikmin[i].moveTowards(new Vector2(300, 300));
                }
            }
            if (Game1.kbState.IsKeyDown(Keys.L))
            {
                for (int i = 0; i < allPikmin.Count(); i++)
                    allPikmin[i].levelUp();
            }
            if (Game1.kbState.IsKeyDown(Keys.K))
            {
                for (int i = 0; i < allPikmin.Count(); i++)
                    allPikmin[i].levelDown();
            }

            string direction = "none";
            if (Game1.kbState.IsKeyDown(Keys.J))
            {
                for (int i = 0; i < allPikmin.Count(); i++)
                    allPikmin[i].moveTowards(new Vector2(cursor.getX(), cursor.getY()));
            }
            else if (Game1.kbState.IsKeyDown(Keys.D))
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
            ((Character)Game1.COLLISIONS["character"]).move(direction);
        }

        /// <summary>
        /// Draw function called every frame.
        /// </summary>
        public static void draw(SpriteBatch spriteBatch)
        {
            if (!isInitiated)
                return;
            ((CollisionObject)Game1.COLLISIONS["character"]).draw(spriteBatch);
            for (int i = 0; i < allPikmin.Count(); i++)
            {
                allPikmin[i].draw(spriteBatch);
            }
        }
    }
}
