using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoEn_task_1
{
    public class Labyrinth
    {
        public List<List<Cell>> _circuit;
        public List<List<Cell>> circuit
        {
            get
            {
                if (_circuit == null)
                    _circuit = new List<List<Cell>>();
                return _circuit;
            }
            set { _circuit = value; }
        }


        public Labyrinth(int width, int height)
        {

        }
        public Labyrinth() { }

        

        public string encode()
        {
            string ans = "";
            foreach (var iterator in circuit)
            {
                foreach (var el in iterator)
                {
                    ans += el.encrypt();
                }
                ans += "\r\n";
            }
            return ans;

        }


    }

}
