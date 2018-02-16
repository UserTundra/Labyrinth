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
        
        //public static Dictionary<Point2D,>

        public bool canGoNorth;
        public bool canGoSouth;
        public bool canGoWest;
        public bool canGoEast;

        public int condition { get; set; } //1 - in, -1 - out, 0 - simple cell
        
        public Cell()
        {
            canGoEast = true;
            canGoNorth = true;
            canGoSouth = true;
            canGoWest = true;
            this.condition = (int) Cell.conditionsList.simpleCell;
        }

        public void moveLeft(Point2D oldCoord)
        {
            if(oldCoord.x == 0 && oldCoord.y == 1)
            {

            }
        }

        public void moveRight(Point2D oldCoord, Point2D newCoord)
        {

        }

        public void moveForvard(Point2D oldCoord, Point2D newCoord)
        {

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
