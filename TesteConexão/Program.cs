using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TesteConexão
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> speedList = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                Stopwatch watch = new Stopwatch(); //using system.diagnostics
                watch.Start();
                WebClient web = new WebClient();
                byte[] bytes = web.DownloadData("https://1.1.1.1");
                watch.Stop();
                double sec = watch.Elapsed.TotalSeconds;

                double speed = bytes.Count() / sec;
                var speedMb = speed / 100000;

                speedList.Add(speedMb);
                Console.WriteLine(speedMb);
                Task.Delay(10000);
            }

            double maximum = speedList.Max();
            double minimum = speedList.Min();
            double avg = speedList.Average();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(avg + " mb/s");
            Console.ReadLine();
        }
    }
}
