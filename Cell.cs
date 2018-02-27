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
            canGoEast = true;
            canGoNorth = true;
            canGoSouth = true;
            canGoWest = true;
            this.condition = (int) Cell.conditionsList.simpleCell;
        }

        public void FillFields(Point2D coord) // take the vector and block the side
        {                                     //движение по сторонам; изменение позиций стен
            if (coord.x == 1 && coord.y == 0)           //00 01 02
                canGoSouth = false;                     //10 11 12
            if (coord.x == 0 && coord.y == 1)           //20 21 22
                canGoEast = false;                      //т.е. если вектор изменился на определенный х, у, значит где-то стена
            if (coord.x == -1 && coord.y == 0)          //прим. движение вверх есть, нет движения в стороны => т.е. стена сверху
                canGoNorth = false;
            if (coord.x == 0 && coord.y == -1)
                canGoWest = false;
        }
        
        public void MoveRight(Point2D _oldCoords) //при повороте из клетки направо: стена спереди и слева
        {
            Point2D oldCoords = _oldCoords.Copy();
            FillFields(oldCoords); // block forward - а тут стена спереди, и так всегда

            oldCoords.MoveLeft(); //стена слева
            FillFields(oldCoords); // block left
        }

        public void MoveForvard(Point2D _oldCoords) //при движении вперед стена только слева
        {
            Point2D oldCoords = _oldCoords.Copy();
            oldCoords.MoveLeft();
            FillFields(oldCoords); // block left side
        }

        public string Encrypt()
        {
            var res = 
                ((canGoNorth ? 1 : 0) ) |
                ((canGoSouth ? 1 : 0) << 1) |
                ((canGoWest ? 1 : 0) << 2) |
                ((canGoEast ? 1: 0) << 3); // take index and let answer

            string encode = "0123456789abcdef";
            return encode[res].ToString();
        }

        
    }
}
