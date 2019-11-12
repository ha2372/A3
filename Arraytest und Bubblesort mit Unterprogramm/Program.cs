using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arraytest_und_Bubblesort_mit_Unterprogramm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Komplette Katastrophe");
            int[] intArray = new int[] { 9, 3, 4, 7, 5, 1 };

            Console.WriteLine(intArray[0]);
            Console.WriteLine(intArray[1]);
            Console.WriteLine(intArray[2]);
            Console.WriteLine(intArray[3]);
            Console.WriteLine(intArray[4]);
            Console.WriteLine(intArray[5]);
            Console.ReadKey();
            Sortiere(intArray);
            outArray(intArray);
            Console.WriteLine();
            Console.WriteLine(intArray[0] < intArray[1] && intArray[1] < intArray[2] && intArray[2] < intArray[3] && intArray[3] < intArray[4] && intArray[4] < intArray[5]);
            Console.ReadKey();
        }

        private static int[] Sortiere(int[] intArray)
        {


            int ii = 0;
            do
            {
                if (intArray[0] > intArray[1])
                {
                    int temp = intArray[0];
                    intArray[0] = intArray[1];
                    intArray[1] = temp;
                }
                if (intArray[1] > intArray[2])
                {
                    int temp = intArray[1];
                    intArray[1] = intArray[2];
                    intArray[2] = temp;
                }
                if (intArray[2] > intArray[3])
                {
                    int temp = intArray[2];
                    intArray[2] = intArray[3];
                    intArray[3] = temp;
                }
                if (intArray[3] > intArray[4])
                {
                    int temp = intArray[3];
                    intArray[3] = intArray[4];
                    intArray[4] = temp;
                }
                if (intArray[4] > intArray[5])
                {
                    int temp = intArray[4];
                    intArray[4] = intArray[5];
                    intArray[5] = temp;
                }
                ii++;
            } while (ii < intArray.Length);
            return (intArray);

        }

        private static void outArray(int[] intArray)
        {
            int i = 0;
            do
            {
                Console.Write(intArray[i] + " ");
                i++;
            } while (i < intArray.Length);
        }
    }
}
