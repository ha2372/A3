using System;

namespace Profilberechnung
{
    class Program
    {
        static void Main()
        {
            //Eingabevariablen: Länge, Breite, Höhe, Dichte, Radius
            string lae;
            string bre;
            string hoe;
            string dic;
            string rad;
            //Werteingabe beginnen
            Console.WriteLine("Profilberechnung");
            Console.WriteLine("Bitte wählen sie ein Profil");
            Console.WriteLine("Rechteck:1");
            Console.WriteLine("Kreis:2");
            Console.WriteLine("rechtwinkliges Dreieck:3");
            string x = Console.ReadLine();
            int y = Convert.ToInt32(x);
            switch (y)
            {
                //Rechteckprofil
                case 1:
                Console.Clear();
                Console.WriteLine("Rechteckprofil gewählt!");
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
                //Fenstertext löschen
                Console.Clear();
                //eingegebene Werte wiedergeben
                Console.WriteLine("Länge:" + l + "mm");
                Console.WriteLine("Breite:" + b + "mm");
                Console.WriteLine("Höhe:" + h + "mm");
                Console.WriteLine("Dichte:" + d + "kg/m^3");
                //Berechnungen
                //Fläche
                double fla = l * b;
                //Volumen
                double vol = l * b * h;
                //Gewicht
                double gew = l * b * h / 1000000 * d;
                //Rechenergebnisse
                Console.WriteLine();
                Console.WriteLine("Flächeninhalt:" + fla + "mm^2");
                Console.WriteLine("Volumen:" + vol + "mm^3");
                Console.WriteLine("Gewicht:" + gew + "kg");

                break;
                //Kreisprofil
                case 2:
                Console.Clear();
                Console.WriteLine("Kreisprofilgewählt!");
                //Radius (mm)
                Console.WriteLine("Bitte Radius in Millimeter eingeben");
                rad = Console.ReadLine();
                double r = Convert.ToDouble(rad);
                //Höhe (mm)
                Console.WriteLine("Bitte Höhe in Millimter eingeben");
                hoe = Console.ReadLine();
                double kh = Convert.ToDouble(hoe);
                //Dichte
                Console.WriteLine("Bitte Dichte eingeben");
                dic = Console.ReadLine();
                double kd = Convert.ToDouble(dic);
                //Fenstertext löschen
                Console.Clear();
                //eingegebene Werte wiedergeben   
                Console.WriteLine("Höhe:" + kh + "mm");
                Console.WriteLine("Dichte:" + kd + "kg/m^3");
                Console.WriteLine("Radius:" + r + "mm");
                //Berechnung
                //Fläche
                double krf = r * r * 3.14;
                //Volumen
                double krv = krf * kh;
                //Gewicht
                double krg = krv * kd / 1000000;
                //Rechenergebnisse
                Console.WriteLine();
                Console.WriteLine("Flächeninhalt:" + krf + "mm^2");
                Console.WriteLine("Volumen:" + krv + "mm^3");
                Console.WriteLine("Gewicht:" + krg + "kg");

                break;
                //rechtwinkliges Dreieck
                case 3:
                Console.Clear();
                Console.WriteLine("rechtwinkliges Dreieck gewählt!");
                //Länge (mm)
                Console.WriteLine("Bitte Länge in Millimeter eingeben");
                lae = Console.ReadLine();
                double dl = Convert.ToDouble(lae);
                //Breite (mm)
                Console.WriteLine("Bitte Breite in Millimter eingeben");
                bre = Console.ReadLine();
                double db = Convert.ToDouble(bre);
                //Höhe (mm)
                Console.WriteLine("Bitte Höhe in Millimter eingeben");
                hoe = Console.ReadLine();
                double dh = Convert.ToDouble(hoe);
                //Dichte (kg/m^3)
                Console.WriteLine("Bitte Dichte in kg pro Kubikmeter eingeben");
                dic = Console.ReadLine();
                double dd = Convert.ToDouble(dic);
                //Fenstertext löschen
                Console.Clear();
                //eingegebne Werte wiedergeben
                Console.WriteLine("Länge:" + dl + "mm");
                Console.WriteLine("Breite:" + db + "mm");
                Console.WriteLine("Höhe:" + dh + "mm");
                Console.WriteLine("Dichte:" + dd + "kg/m^3");
                //Berechnung
                //Fläche
                double rdf = dl * db / 2;
                //Volumen
                double rdv = rdf * dh;
                //Gewicht
                double rdg = rdv * dd / 1000000;
                //Rechenergebnisse
                Console.WriteLine();
                Console.WriteLine("Flächeninhalt:" + rdf + "mm^2");
                Console.WriteLine("Volumen:" + rdv + "mm^3");
                Console.WriteLine("Gewicht:" + rdg + "kg");

                break;

                default:
                Console.WriteLine("Fehlerhafte Eingabe!");
                break;
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Programm beenden:beliebige Taste");
            Console.ReadKey();
        }
    }
}
