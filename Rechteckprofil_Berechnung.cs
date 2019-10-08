using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBerechnung
{
    class Program
    {
        static void Main(string[] args)
        {
            double Laenge, Breite, Hoehe, Dichte;

            Console.WriteLine("Geben Sie die Länge des Rechteckes in [m] ein:");
            Laenge = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Geben Sie die Breite des Rechteckes in [m] ein:");
            Breite = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Geben Sie die Höhe des Rechteckes in [m] ein:");
            Hoehe = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Geben Sie die Dichte des Werkstoffes in [kg/m³] ein:");
            Dichte = double.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Flächeninhalt: " + (Laenge * Breite) + "m²");
            Console.WriteLine("Volumen: " + (Laenge * Breite * Hoehe) + "m³");
            Console.WriteLine("Gewicht: " + (Laenge * Breite * Hoehe * Dichte) + "kg");

            Console.ReadLine();
            
        }
    }
}
