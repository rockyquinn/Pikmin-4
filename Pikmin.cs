using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pikmin_4
{
    class Pikmin
    {
        private List<Texture2D> rightAnimation;
        private String type;
        private int level;

        /// <summary>
        /// Constructor for any Pikmin.
        /// </summary>
        public Pikmin(String typ, int lvl)
        {
            type = typ;
            level = lvl;

            initImages();
        }


        /// <summary>
        /// Initializes the set of animations that a Pikmin will have.
        /// </summary>
        public void initImages()
        {
            rightAnimation = new List<Texture2D>();
            if (type.Equals("blue"))
            {
                //if (level == 1)
                //else if(level == 2)
                //else
            }
        }
        
    }
}
