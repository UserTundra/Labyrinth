using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoEn_task_1
{
    class Cell
    {
        

        public static enum conditionsList : int { simpleCell = 0, enter = 1, exit = -1 }

        public bool canGoNorth;
        public bool canGoSouth;
        public bool canGoWest;
        public bool canGoEast;

        public int condition { get; set; } //1 - in, -1 - out, 0 - simple cell

        public Cell()
        {
            this.condition = (int) Cell.conditionsList.simpleCell;
        }

        public string encrypt()
        {
            var res = 
                ((canGoNorth ? 1 : 0) << 3) &
                ((canGoSouth ? 1 : 0) << 2) &
                ((canGoWest ? 1 : 0) << 1) &
                ((canGoEast ? 1: 0));

            Console.WriteLine(res);
            return ('0'+res).ToString();
        }


    }
}
