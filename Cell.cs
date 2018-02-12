using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoEn_task_1
{
    public class Cell
    {
        

        public enum conditionsList : int { simpleCell = 0, enter = 1, exit = -1 }

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
                ((canGoNorth ? 1 : 0) ) |
                ((canGoSouth ? 1 : 0) << 1) |
                ((canGoWest ? 1 : 0) << 2) |
                ((canGoEast ? 1: 0) << 3);

            Console.WriteLine(res);
            var ans = ((char) ('0' + res)).ToString();
            return ans;
        }


    }
}
