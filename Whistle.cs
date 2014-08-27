using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pikmin_4
{
    class Whistle : CollisionObject
    {
        public Whistle()
            : base("Whistle", GameState.cursor.getX(), GameState.cursor.getX())
        {

        }


    }
}
