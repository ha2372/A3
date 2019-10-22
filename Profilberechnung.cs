using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profilberechnung
{
    class Program
    {
        static void Main(string[] args)
        {
            //Eingabevariablen: Länge, Breite, Höhe, Dichte, Radius
            string lae;
            string bre;
            string hoe;
            string dic;
            string rad;
            //Werteingabe beginnen
            Console.WriteLine("Profilberechnung");
            Console.WriteLine("Bei nicht erforderlichen/ nicht vorhandenen Wert, bitte 1 eintragen");
            //Länge (mm)
            Console.WriteLine("Bitte Länge in Millimeter eingeben");
            lae = Console.ReadLine();
            double l = Convert.ToDouble(lae);
            //Breite (mm)
            Console.WriteLine("Bitte Breite in Millimter eingeben");
            bre = Console.ReadLine();
            double b = Convert.ToDouble(bre);
            //Höhe (mm)
            Console.WriteLine("Bitte Höhe in Millimter eingeben");
            hoe = Console.ReadLine();
            double h = Convert.ToDouble(hoe);
            //Dichte (kg/m^3)
            Console.WriteLine("Bitte Dichte in kg pro Kubikmeter eingeben");
            dic = Console.ReadLine();
            double d = Convert.ToDouble(dic);
            //Radius (mm)
            Console.WriteLine("Bitte Radius in Millimeter eingeben");
            rad = Console.ReadLine();
            double r = Convert.ToDouble(rad);
            //Fenstertext löschen
            Console.Clear();
            //eingegebene Werte wiedergeben
            Console.WriteLine("Länge:" + l + "mm");
            Console.WriteLine("Breite:" + b + "mm");
            Console.WriteLine("Höhe:" + h + "mm");
            Console.WriteLine("Dichte:" + d + "kg/m^3");
            Console.WriteLine("Radius:" + r + "mm");
            //Berechnungen
            //Rechteckfläche
            double fla = l * b;
            //Rechteckvolumen
            double vol = l * b * h;
            //Rechteckgewicht
            double gew = l * b * h / 1000000 * d;
            //Kreisfläche
            double krf = r *r * 3.14;
            //Kreisvolumen
            double krv = krf * h;
            //Kreisgewicht
            double krg = krv * d / 1000000;
            //Dreicksfläche
            double rdf = l * b / 2;
            //Dreiecksvolumen
            double rdv = rdf * h;
            //Dreiecksgewicht
            double rdg = rdv * d / 1000000;
            //Wertausgabe Rechteckprofil
            Console.WriteLine("Rechteckprofil:");
            Console.WriteLine("Flächeninhalt:" + fla + "mm^2");
            Console.WriteLine("Volumen:" + vol + "mm^3");
            Console.WriteLine("Gewicht:" + gew + "kg");
            Console.WriteLine();
            //Wertausgabe Kreisprofil
            Console.WriteLine("Kreisprofil");
            Console.WriteLine("Flächeninhalt:" + krf + "mm^2");
            Console.WriteLine("Volumen:" + krv + "mm^3");
            Console.WriteLine("Gewicht:" + krg + "kg");
            Console.WriteLine();
            //Wertausgabe Rechtwinkliges Dreick
            Console.WriteLine("Rechtwinkliges Dreieck");
            Console.WriteLine("Flächeninhalt:" + rdf + "mm^2");
            Console.WriteLine("Volumen:" + rdv + "mm^3");
            Console.WriteLine("Gewicht:" + rdg + "kg");
            Console.ReadKey();
        }
    }
}
