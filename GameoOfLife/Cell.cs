using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameoOfLife
{
    struct Cell
    {
        public bool hasOrganism;      
        public int state;              

        public const int EMPTY = 0;
        public const int SURVIVES = 1;
        public const int DEATH_BY_OVERCROWDING = 2;
        public const int DEATH_BY_LONELINESS = 3;
        public const int SPAWNING = 4;
        public const int UNMARKED = 5;

        public Cell(bool hasOrganism)
        {
            this.hasOrganism = hasOrganism;
            this.state = EMPTY;
        }

    }
}
