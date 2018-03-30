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

        public void ParseFile()
        {
            var allText = sr.ReadToEnd();
            var possibleLabyryths = allText.Split('\n');

            var n = int.Parse(possibleLabyryths[0]); // not important arg

            for(int i = 1;i < possibleLabyryths.Length; i++ )
            {
                try
                {
                    var roads = possibleLabyryths[i].Split(' ');
                    var lab = new LabyrinthCreator();
                    lab.Generate(roads[0],roads[1]);

                    sw.WriteLine("\r\nCase #"+i);
                    sw.Write(lab.labyrinth.Encode());
                    sw.Write("\n");
                }
                catch (Exception e)
                {
                    continue;
                }
            }
        }



        public void Run()
        {
            StreamInit();
            ParseFile();    


        }
    }
}
