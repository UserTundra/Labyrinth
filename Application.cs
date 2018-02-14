using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoEn_task_1
{
    class Application
    {
        private StreamReader sr;
        private StreamWriter sw;

        public void StreamInit()
        {
            sw = new StreamWriter(Console.OpenStandardOutput());
            sw.AutoFlush = true;
            Console.SetOut(sw);
            sr = new StreamReader("test.txt");
        }

        public void parseFile()
        {
            var allText = sr.ReadToEnd();
            var possibleLabyryths = allText.Split('\n');

            var n = int.Parse(possibleLabyryths[0]); // not important arg

            foreach (var el in possibleLabyryths)
            {
                var roads = el.Split(' ');
                // invoke ( road[0],road[1])
                //TODO: call func to construct
                sw.Write("\n");
            }
        }



        public void run()
        {
            StreamInit();
            parseFile();    


        }
    }
}
