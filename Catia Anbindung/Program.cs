using INFITF;
using MECMOD;
using PARTITF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catia_Anbindung
{ 
     class CatiaControl
     { 
         CatiaControl()
         { 
             try 
             {  
                 CatiaCon cc = new CatiaCon();  
                 if (cc.CATIALaeuft())
                 { 
                     Console.WriteLine("0"); 

                     cc.ErzeugePart(); 
                     Console.WriteLine("1"); 
 
                     cc.ErstelleLeereSkizze(); 
                     Console.WriteLine("2"); 
 
                     cc.ErzeugeProfil(20, 10); 
                     Console.WriteLine("3"); 
 
                     cc.ErzeugeBalken(300); 
                     Console.WriteLine("4"); 
                 } 
                 else 
                 { 
                     Console.WriteLine("Laufende Catia Application nicht gefunden"); 
                 } 
             } 
             catch (Exception ex) 
             { 
                MessageBox.Show(ex.Message, "Exception aufgetreten"); 
             } 
             Console.WriteLine("Fertig - Taste drücken."); 
             Console.ReadKey(); 
         } 
         static void Main(string[] args)
         { 
            new CatiaControl();
         } 
     }   
}
