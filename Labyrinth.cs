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

        private void generate(String enterTrip)
        {
            
            if (circuit[0].Count < 0)
            {
                int i = 0;
                int j = 0;
                int idx = 1;
                int idy = 0;
                var input = new Cell() { condition = (int) Cell.conditionsList.enter };
                circuit[0].Add(input);
                enterTrip = enterTrip.Substring(1);
                step(enterTrip, i, j, idx, idy);
            }
                
        }

        private void step(String trip, int i, int j, int idx, int idy)
        {
            while (trip[0] != 'W')
            {
                
                if(trip[0] == 'L')
                {
                    //circuit[i][j].c TODO canMovelalalala..
                    int tmp = idx;
                    idx = idy * -1;
                    idy = tmp;
                }
                else if(trip[0] == 'R')
                {
                    int tmp = idy;
                    idy = idx * -1;
                    idx = tmp;
                }
                trip = trip.Substring(1);
            }

            i = i + idx;
            j = j + idy;
            Cell counter;
            if(i < 0 )
            {
                circuit.Add(new List<Cell>());
                counter = new Cell();

                circuit[circuit.Count - 1].Add(counter);
            }



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
