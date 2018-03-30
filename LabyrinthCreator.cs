using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoEn_task_1
{
    class LabyrinthCreator
    {
        public Labyrinth labyrinth = new Labyrinth();


        private Point2D _exitPoint; //координаты выхода
        private Point2D _exitVector; //"сторона", куда выходим

        public void Generate(String enterTrip, String exitTrip)
        {
            if (labyrinth.circuit[0].Count == 0) //если лабиринт пуст
            {
                var input = new Cell() { condition = (int)Cell.conditionsList.enter }; //объявляем ячейку входа
                labyrinth.circuit[0].Add(input); //добавляем ее в лабиринт
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


        private void Step(String trip, Point2D oldCoords, Point2D coordsIncrement)
        {
            if (trip.Length == 0)
                return;

            bool areTurned = false;

            while (trip.Length > 0 && trip[0] != 'W')
            {
                areTurned = true;
                if (trip[0] == 'L')
                {
                    coordsIncrement.MoveLeft();
                }
                else if (trip[0] == 'R')
                {
                    labyrinth.circuit[oldCoords.x][oldCoords.y].MoveRight(coordsIncrement);
                    coordsIncrement.MoveRight();
                }
                //TODO else{ throw new UnsupportedCharException()}
                trip = trip.Substring(1);
            }

            if (!areTurned)
                labyrinth.circuit[oldCoords.x][oldCoords.y].MoveForvard(coordsIncrement);

            if (trip.Length == 1) // if exit
            {
                labyrinth.circuit[oldCoords.x][oldCoords.y].condition = (int)Cell.conditionsList.exit;
                this._exitPoint = new Point2D(oldCoords.x, oldCoords.y);
                this._exitVector = new Point2D(-coordsIncrement.x, -coordsIncrement.y);
                return;
            }



            oldCoords.x = oldCoords.x + coordsIncrement.x;// x = i
            oldCoords.y = oldCoords.y + coordsIncrement.y;

            labyrinth.AddNewCell(oldCoords);

            trip = trip.Substring(1);
            Step(trip, oldCoords, coordsIncrement);

        }

    }
}
