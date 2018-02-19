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

        private void insertCollumn(int idx = 0)
        {
            foreach (var el in circuit)
            {
                el.Insert(idx, new Cell());
            }

            
        }

        private void insertRow(int idx = 0)
        {
            
            var node = new List<Cell>();
                for (int i = 0; i<_width; i++)
                {
                    node.Add(new Cell());
                }
            circuit.Insert(idx, node);
            
        }

        private void AddNewCell(Point2D oldCoords)
        {
            while (oldCoords.x < 0)
            {
                insertRow(0);
                oldCoords.x++;
            }
            while (oldCoords.x > circuit.Count - 1)
            {
                insertRow(circuit.Count);
            }
            while (oldCoords.y > circuit[oldCoords.x].Count - 1)
            {
                insertCollumn(circuit[oldCoords.x].Count);
            }
            while (oldCoords.y < 0)
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
