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
        private Point2D _exitPoint;
        private Point2D _exitVector;
        
        public List<List<Cell>> circuit
        {
            get
            {
                if (_circuit == null) 
                    Init();
                return _circuit;
            }
            set { _circuit = value; }
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
            if (circuit[0].Count == 0)
            {
                var input = new Cell() { condition = (int) Cell.conditionsList.enter };
                circuit[0].Add(input);
                enterTrip = enterTrip.Substring(1);

                Point2D oldCoord = new Point2D(0, 0);
                Point2D coordIncr = new Point2D(1, 0);

                Step(enterTrip, oldCoord, coordIncr);
                Backwards(exitTrip);
            }
        }

        private void Backwards(string backTrip)
        {
            if (_exitPoint == null || _exitVector == null)
            {
                Console.WriteLine("NO EXIT!");
                return; 
            }
            backTrip = backTrip.Substring(1);
            Step(backTrip, _exitPoint, _exitVector);
        }

        private void AddNewCell(Point2D oldCoords)
        {

            Cell counter;
            while (oldCoords.x < 0)
            {
                oldCoords.x += 1;
                circuit.Insert(0, new List<Cell>());
            }
            while (oldCoords.x > circuit.Count - 1)
            {
                circuit.Add(new List<Cell>());
            }

            while (oldCoords.y > circuit[oldCoords.x].Count - 1)
            {
                counter = new Cell();
                circuit[oldCoords.x].Add(counter);
            }
            while (oldCoords.y < 0)
            {
                oldCoords.y += 1;
                counter = new Cell();
                circuit[oldCoords.x].Insert(0, counter);
            }
        }
        

        private void Step(String trip, Point2D oldCoords, Point2D coordsIncrement)
        {
            if(trip.Length == 0)
                return;

            bool areTurned = false;

            while (trip[0] != 'W')
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

            if (trip.Length == 1) // if exit
            {
                circuit[oldCoords.x][oldCoords.y].condition = (int)Cell.conditionsList.exit;
                this._exitPoint = new Point2D(oldCoords.x, oldCoords.y);
                this._exitVector = new Point2D(-coordsIncrement.x, -coordsIncrement.y);
                return;
            }

            if (!areTurned)
                circuit[oldCoords.x][oldCoords.y].MoveForvard(coordsIncrement);

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
