using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoEn_task_1
{
    public class Labyrinth
    {
        private List<List<Cell>> _circuit;

        private int _width = 1;
        private int _height =1;

        public List<List<Cell>> circuit
        {
            get
            {
                if (_circuit == null) 
                    Init();
                return _circuit;
            }
            
        }


        public Labyrinth(int width, int height)
        {

        }
        public Labyrinth() { }

        private void Init()
        {
            _circuit = new List<List<Cell>>();
            _circuit.Add(new List<Cell>());
        }

        

        public void insertCollumn(int idx = 0) //вставка колонки по индексу
        {
            foreach (var el in circuit)
            {
                     el.Insert(idx, new Cell());
            }
        }

        public void insertRow(int idx = 0) //вставка строки по индексу
        {
            
            var node = new List<Cell>();
                for (int i = 0; i<_width; i++)
                {
                    node.Add(new Cell());
                }
            circuit.Insert(idx, node);
            
        }

        public void AddNewCell(Point2D oldCoords) //добавление новой ячейки
        {
            while (oldCoords.x < 0) //т.е. если вдруг (?!) от входа можно идти наверх (!?), то вставляем строку выше текущей
            {
                insertRow(0);
                oldCoords.x++;
            }
            while (oldCoords.x > circuit.Count - 1) //если ниже текущей строки - вставляем ниже текущей - обыкновенное движение вниз
            {
                insertRow(circuit.Count);
            }
            while (oldCoords.y > circuit[oldCoords.x].Count - 1) // если дальше текущей колонки - вставляем правее текущей
            {
                insertCollumn(circuit[oldCoords.x].Count);
            }
            while (oldCoords.y < 0) //левее текущей
            {
                insertCollumn(0);
                oldCoords.y++;
            }
            _height = Math.Max(_height, circuit.Count);
            _width = Math.Max(_width, circuit[0].Count);
        }
        

        public string Encode()
        {
            string ans = "";
            foreach (var iterator in circuit)
            {
                foreach (var el in iterator)
                {
                    ans += el.Encrypt();
                }
                ans += "\r\n";
            }
            return ans;
        }


    }

}
