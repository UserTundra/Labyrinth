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
        public List<List<Cell>> circuit
        {
            get
            {
                if (_circuit == null) 
                    init();
                return _circuit;
            }
            set { _circuit = value; }
        }


        public Labyrinth(int width, int height)
        {

        }
        public Labyrinth() { }

        private void init()
        {
            _circuit = new List<List<Cell>>();
            _circuit.Add(new List<Cell>());
        }

        public void generate(String enterTrip)
        {
            
            if (circuit[0].Count == 0)
            {
                int i = 0;
                int j = 0;
                int idx = 1;
                int idy = 0;
                var input = new Cell() { condition = (int) Cell.conditionsList.enter };
                circuit[0].Add(input);
                enterTrip = enterTrip.Substring(1);
                Point2D oldCoord = new Point2D(i, j);
                Point2D coordIncr = new Point2D(idx, idy);
                step(enterTrip, oldCoord, coordIncr);
                
            }
                
        }

        private void step(String trip, Point2D oldCoords, Point2D coordsIncrement)
        {
            if(trip.Length == 0)
                return;

            while (trip[0] != 'W')
            {
                
                if(trip[0] == 'L')
                {
                    //circuit[i][j].c TODO canMovelalalala..
                    //circuit[oldCoords.x][oldCoords.y].moveLeft(oldCoords, coordsIncrement);

                    int tmp = coordsIncrement.x;
                    coordsIncrement.x = coordsIncrement.y * -1;
                    coordsIncrement.y = tmp;
                }
                else if(trip[0] == 'R')
                {
                    //circuit[oldCoords.x][oldCoords.y].moveRight(oldCoords, coordsIncrement);

                    int tmp = coordsIncrement.y;
                    coordsIncrement.y = coordsIncrement.x * -1;
                    coordsIncrement.x = tmp;
                }
                trip = trip.Substring(1);
            }

            if (trip.Length == 1)
                return;

            oldCoords.x = oldCoords.x + coordsIncrement.x;// x = i
            oldCoords.y = oldCoords.y + coordsIncrement.y;
            Cell counter;
            while(oldCoords.x < 0)
            {
                oldCoords.x += 1;
                circuit.Insert(0, new List<Cell>());
            }
            while (oldCoords.x > circuit.Count - 1)
            {
                circuit.Add(new List<Cell>());
            }

            while(oldCoords.y > circuit[oldCoords.x].Count-1 )
            {
                
                counter = new Cell();   
                circuit[oldCoords.x].Add(counter);
            }
            while(oldCoords.y < 0)
            {
                oldCoords.y += 1;
                counter = new Cell();
                circuit[oldCoords.x].Insert(0, counter);
            }

            circuit[oldCoords.x][oldCoords.y].moveForvard(oldCoords, coordsIncrement);

            trip = trip.Substring(1);
            step(trip, oldCoords, coordsIncrement);


        }

        public string encode()
        {
            string ans = "";
            foreach (var iterator in circuit)
            {
                foreach (var el in iterator)
                {
                    ans += el.encrypt();
                }
                ans += "\n";
            }
            return ans;
        }


    }

}
