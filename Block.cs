using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikmin_4
{
    class Block : CollisionObject
    {
        private string type;


        public Block(float x, float y, string typ) : base("block", x, y)
        {
            type = typ;
        }
    }
}
