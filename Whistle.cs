using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Pikmin_4
{
    class Whistle : CollisionObject
    {
        public Whistle()
            : base("Whistle", GameState.cursor.getX(), GameState.cursor.getX())
        {
            Dictionary<String,Texture2D> aniDict = new Dictionary<String,Texture2D>();
            aniDict.Add("animation1", Game1.PLAYER_IMAGES["whistle1"]);
            aniDict.Add("animation2", Game1.PLAYER_IMAGES["whistle2"]);
            aniDict.Add("animation3", Game1.PLAYER_IMAGES["whistle3"]);
            aniDict.Add("stand", Game1.PLAYER_IMAGES["whistle1"]);
            this.setAnimations(aniDict);
            this.unanimate();
        }


        public void whistle(int nx, int ny)
        {
            this.setPosition(GameState.cursor.getX(), GameState.cursor.getY());
            this.reanimate();
        }
    }
}
