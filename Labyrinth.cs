using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoEn_task_1
{
    public class Labyrinth
    {
        public List<List<Cell>> circuit { get; set; }

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
