using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Übung_0_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            double zzz = 0.1;
            string z = Console.ReadLine();
            double f = Convert.ToDouble(z);
            while (i <= 12)
                {
                f = f - zzz;
                i = i + 1;
                Console.WriteLine(f);
                }

            Console.ReadKey();
        }
    }
}
