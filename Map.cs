using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Pikmin_4
{
    class Map
    {
        private string area;
        private int[][] intMap;
        private Block[][] blockMap;


        public Map()
        {
            area = "debug";

            createMap();
        }


        public void createMap()
        {
            //60x height
            //80x width
            if (area.Equals("debug"))
            {
                
            }
        }


        public void drawMap(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < blockMap.Length; i++)
                for (int i2 = 0; i2 < blockMap[0].Length; i2++)
                    blockMap[i][i2].draw(spriteBatch);
        }
    }
}
