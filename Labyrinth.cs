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
        private Point2D _exitPoint; //координаты выхода
        private Point2D _exitVector; //"сторона", куда выходим

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

        public void Generate(String enterTrip, String exitTrip)
        {
            if (circuit[0].Count == 0) //если лабиринт пуст
            {
                var input = new Cell() { condition = (int) Cell.conditionsList.enter }; //объявляем ячейку входа
                circuit[0].Add(input); //добавляем ее в лабиринт
                enterTrip = enterTrip.Substring(1); //убираем первую букву из последовательности, т.к. она - вход

                Point2D oldCoord = new Point2D(0, 0); //координата входа - одна строка и один элемент
                Point2D coordIncr = new Point2D(1, 0); //направление движения; вход на верхней стороне, т.е. всегда двигаемся вниз; х +1, у +0

                Step(enterTrip, oldCoord, coordIncr); //проходится по последовательности
                Backwards(exitTrip); //проходится по последовательности наоборот
            }
        }

        private void Backwards(string backTrip) //если выхода нет, то и идти некуда
        {
            if (_exitPoint == null || _exitVector == null)
            {
                Console.WriteLine("NO EXIT!");
                return; 
            }
            backTrip = backTrip.Substring(1); //на обратной дороге убираем первую букву
            Step(backTrip, _exitPoint, _exitVector);
        }

        private void insertCollumn(int idx = 0) //вставка колонки по индексу
        {
            foreach (var el in circuit)
            {
                     el.Insert(idx, new Cell());
            }
        }

        private void insertRow(int idx = 0) //вставка строки по индексу
        {
            
            var node = new List<Cell>();
                for (int i = 0; i<_width; i++)
                {
                    node.Add(new Cell());
                }
            circuit.Insert(idx, node);
            
        }

        private void AddNewCell(Point2D oldCoords) //добавление новой ячейки
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
        

        private void Step(String trip, Point2D oldCoords, Point2D coordsIncrement)
        {
            if(trip.Length == 0)
                return;

            bool areTurned = false;

            while (trip.Length > 0 && trip[0] != 'W' )
            {
                areTurned = true;
                if(trip[0] == 'L')
                {
                    coordsIncrement.MoveLeft();
                }
                else if(trip[0] == 'R')
                {
                    circuit[oldCoords.x][oldCoords.y].MoveRight(coordsIncrement);
                    coordsIncrement.MoveRight();
                }
                //TODO else{ throw new UnsupportedCharException()}
                trip = trip.Substring(1);
            }

            if (!areTurned)
                circuit[oldCoords.x][oldCoords.y].MoveForvard(coordsIncrement);

            if (trip.Length == 1) // if exit
            {
                circuit[oldCoords.x][oldCoords.y].condition = (int)Cell.conditionsList.exit;
                this._exitPoint = new Point2D(oldCoords.x, oldCoords.y);
                this._exitVector = new Point2D(-coordsIncrement.x, -coordsIncrement.y);
                return;
            }

            

            oldCoords.x = oldCoords.x + coordsIncrement.x;// x = i
            oldCoords.y = oldCoords.y + coordsIncrement.y;

            AddNewCell(oldCoords);
            
            trip = trip.Substring(1);
            Step(trip, oldCoords, coordsIncrement);

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
                ans += "\n";
            }
            return ans;
        }


    }

}
