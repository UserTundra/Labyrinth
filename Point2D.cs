using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoEn_task_1
{
    public class Point2D
    {
        public int x;
        public int y;



        public Point2D(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public Point2D Copy()
        {
            return new Point2D(this.x, this.y);
        }

        public void MoveLeft()
        {
            int tmp = this.x;           //00  01  02
                                        //    ^^    
            this.x = this.y * -1;       //10->11  12   | v = 0,1 : v1 = -1,0
            this.y = tmp;               //20  21  22
        }

        public void MoveRight()
        {
            int tmp = this.y;           //00  01  02
            this.y = this.x * -1;       //10  11<-12   | v = 0,-1 : v1 = 1,0
                                        //    vv
            this.x = tmp;               //20  21  22
        }

    }
}
