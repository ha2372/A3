using INFITF;
using MECMOD;
using PARTITF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Catia_Anbindung_GUI
{
    internal class CatiaCon
    {
        INFITF.Application hsp_catiaApp;
        MECMOD.PartDocument hsp_catiaPart;
        MECMOD.Sketch hsp_catiaProfil;
        //Funktion CatiaLäuft
        public bool CATIALaeuft()
        {
            try
            {
                object catiaObject = System.Runtime.InteropServices.Marshal.GetActiveObject(
                   "CATIA.Application");
                hsp_catiaApp = (INFITF.Application)catiaObject;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Funktion ErzeugePart
        public Boolean ErzeugePart()
        {
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPart = catDocuments1.Add("Part") as MECMOD.PartDocument;
            return true;
        }
        //Funktion Skizze erstellen
        public void ErstelleLeereSkizze()
        {
            HybridBody catHybridBody1;
            HybridBodies catHybridBodies1;
            try
            {
                catHybridBodies1 = hsp_catiaPart.Part.HybridBodies;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Was auch immer");
                return;
            }

            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                       "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                       "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPart.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaProfil = catSketches1.Add(catReference1);
            ErzeugeAchsensystem();
            hsp_catiaPart.Part.Update();
        }
        //Funktion ErzeugeAchsensystem
        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[]
            {
                0.0, 0.0, 0.0,
                0.0, 1.0, 0.0,
                0.0, 0.0, 1.0
            };
            hsp_catiaProfil.SetAbsoluteAxisData(arr);
        }
        //Funktion ErzeugeKreis
        public void ErzeugeKreis(Double r)
        {
            hsp_catiaProfil.set_Name("Kreis");
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0,0);
            Circle2D catcircle2D1 = catFactory2D1.CreateClosedCircle(0.000000, 0.000000,r);
            catcircle2D1.CenterPoint = catPoint2D1;

            hsp_catiaProfil.CloseEdition();
            hsp_catiaPart.Part.Update();
        }
        //Funktion ErzeugeKreisring
        public void ErzeugeKreisring(Double ra, Double ri)
        {
            hsp_catiaProfil.set_Name("Kreisring");
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, 0);
            Circle2D catcircle2D1 = catFactory2D1.CreateClosedCircle(0.000000, 0.000000, ra);
            Circle2D catcircle2D2 = catFactory2D1.CreateClosedCircle(0.000000, 0.000000, ri);
            catcircle2D1.CenterPoint = catPoint2D1;

            hsp_catiaProfil.CloseEdition();
            hsp_catiaPart.Part.Update();
        }
        //Funktion ErzeugeRechteck
        public void ErzeugeRechteck(Double h, Double b)
        {
            hsp_catiaProfil.set_Name("Rechteck");
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0,h);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(b,h);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(b,0);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(0,0);

            Line2D catLine2D1 = catFactory2D1.CreateLine(0,h,b,h);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(b,h,b,0);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(b,0,0,0);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(0,0,0,h);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            hsp_catiaProfil.CloseEdition();
            hsp_catiaPart.Part.Update();
        }
        //Funktion ErzeugeVierkantrohr (mitRadien)
        public void ErzeugeVierkantrohr(Double r_ah, Double r_ab,Double z)
        {
            hsp_catiaProfil.set_Name("VierkantRohr");
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();
            
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(z, z);

            Point2D catPoint2D5 = catFactory2D1.CreatePoint(0, z);
            Point2D catPoint2D12 = catFactory2D1.CreatePoint(z, 0);

            Circle2D catCircle2D1 = catFactory2D1.CreateCircle(z, z, z, 0, 0);
            catCircle2D1.CenterPoint = catPoint2D1;
            catCircle2D1.StartPoint = catPoint2D5;
            catCircle2D1.EndPoint = catPoint2D12;

            Point2D catPoint2D6 = catFactory2D1.CreatePoint(0, r_ah - z);

            Line2D catLine2D1 = catFactory2D1.CreateLine(0, z, 0, r_ah - z);
            catLine2D1.StartPoint = catPoint2D5;
            catLine2D1.EndPoint = catPoint2D6;

            Point2D catPoint2D2 = catFactory2D1.CreatePoint(z, r_ah - z);
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(z, r_ah);

            Circle2D catCircle2D2 = catFactory2D1.CreateCircle(z, r_ah - z, z, 0, 0);
            catCircle2D2.CenterPoint = catPoint2D2;
            catCircle2D2.StartPoint = catPoint2D7;
            catCircle2D2.EndPoint = catPoint2D6;

            Point2D catPoint2D8 = catFactory2D1.CreatePoint(r_ab - z, r_ah);

            Line2D catLine2D2 = catFactory2D1.CreateLine(z, r_ah, r_ab - z, r_ah);
            catLine2D2.StartPoint = catPoint2D7;
            catLine2D2.EndPoint = catPoint2D8;

            Point2D catPoint2D3 = catFactory2D1.CreatePoint(r_ab - z, r_ah - z);
            Point2D catPoint2D9 = catFactory2D1.CreatePoint(r_ab, r_ah - z);

            Circle2D catCircle2D3 = catFactory2D1.CreateCircle(r_ab - z, r_ah - z, z, 0, 0);
            catCircle2D3.CenterPoint = catPoint2D3;
            catCircle2D3.StartPoint = catPoint2D9;
            catCircle2D3.EndPoint = catPoint2D8;

            Point2D catPoint2D10 = catFactory2D1.CreatePoint(r_ab, z);

            Line2D catLine2D3 = catFactory2D1.CreateLine(r_ab, r_ah - z, r_ab, z);
            catLine2D3.StartPoint = catPoint2D9;
            catLine2D3.EndPoint = catPoint2D10;

            Point2D catPoint2D4 = catFactory2D1.CreatePoint(r_ab - z, z);
            Point2D catPoint2D11 = catFactory2D1.CreatePoint(r_ab - z, 0);

            Circle2D catCircle2D4 = catFactory2D1.CreateCircle(r_ab - z, z, z, z, z);
            catCircle2D4.CenterPoint = catPoint2D4;
            catCircle2D4.StartPoint = catPoint2D11;
            catCircle2D4.EndPoint = catPoint2D10;

            Line2D catLine2D4 = catFactory2D1.CreateLine(r_ab - z, 0, z, 0);
            catLine2D4.StartPoint = catPoint2D11;
            catLine2D4.EndPoint = catPoint2D12;

            Point2D catPoint2D13 = catFactory2D1.CreatePoint(z / 2, z);
            Point2D catPoint2D20 = catFactory2D1.CreatePoint(z, z / 2);

            Circle2D catCircle2D5 = catFactory2D1.CreateCircle(z, z, z / 2, z / 2, z / 2);
            catCircle2D5.CenterPoint = catPoint2D1;
            catCircle2D5.StartPoint = catPoint2D13;
            catCircle2D5.EndPoint = catPoint2D20;

            Point2D catPoint2D14 = catFactory2D1.CreatePoint(z / 2, r_ah - z);

            Line2D catLine2D5 = catFactory2D1.CreateLine(z / 2, z, z / 2, r_ah - z);
            catLine2D5.StartPoint = catPoint2D13;
            catLine2D5.EndPoint = catPoint2D14;

            Point2D catPoint2D15 = catFactory2D1.CreatePoint(z, r_ah - z / 2);

            Circle2D catCircle2D6 = catFactory2D1.CreateCircle(z, r_ah - z, z / 2, z / 2, z / 2);
            catCircle2D6.CenterPoint = catPoint2D2;
            catCircle2D6.StartPoint = catPoint2D15;
            catCircle2D6.EndPoint = catPoint2D14;

            Point2D catPoint2D16 = catFactory2D1.CreatePoint(r_ab - z, r_ah - z / 2);

            Line2D catLine2D6 = catFactory2D1.CreateLine(z, r_ah - z / 2, r_ab - z, r_ah - z / 2);
            catLine2D6.StartPoint = catPoint2D16;
            catLine2D6.EndPoint = catPoint2D15;

            Point2D catPoint2D17 = catFactory2D1.CreatePoint(r_ab - z / 2, r_ah - z);

            Circle2D catCircle2D7 = catFactory2D1.CreateCircle(r_ab - z, r_ah - z, z / 2, z / 2, z / 2);
            catCircle2D7.CenterPoint = catPoint2D3;
            catCircle2D7.StartPoint = catPoint2D17;
            catCircle2D7.EndPoint = catPoint2D16;

            Point2D catPoint2D18 = catFactory2D1.CreatePoint(r_ab - z / 2, z);

            Line2D catLine2D7 = catFactory2D1.CreateLine(r_ab - z / 2, r_ah - z, r_ab - z / 2, z);
            catLine2D7.StartPoint = catPoint2D17;
            catLine2D7.EndPoint = catPoint2D18;

            Point2D catPoint2D19 = catFactory2D1.CreatePoint(r_ab - z, z / 2);

            Circle2D catCircle2D8 = catFactory2D1.CreateCircle(r_ab - z, z, z / 2, z / 2, z / 2);
            catCircle2D8.CenterPoint = catPoint2D4;
            catCircle2D8.StartPoint = catPoint2D19;
            catCircle2D8.EndPoint = catPoint2D18;

            Line2D catLine2D8 = catFactory2D1.CreateLine(r_ab - z, z / 2, z, z / 2);
            catLine2D8.StartPoint = catPoint2D19;
            catLine2D8.EndPoint = catPoint2D20;           

            hsp_catiaProfil.CloseEdition();
            hsp_catiaPart.Part.Update();
        }
        //Funktion Erzeuge RechteckRohr (ohneRadien)
        public void ErzeugeRechteckRohr(Double r_ah,Double r_ab,Double z)
        {
            hsp_catiaProfil.set_Name("RechteckRohr");
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, r_ah);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(r_ab, r_ah);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(r_ab, 0);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(0, 0);

            Point2D catPoint2D5 = catFactory2D1.CreatePoint(z/2, r_ah-z/2);
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(r_ab-z/2, r_ah-z/2);
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(r_ab-z/ 2, z/2);
            Point2D catPoint2D8 = catFactory2D1.CreatePoint(z/2, z/2);

            Line2D catLine2D1 = catFactory2D1.CreateLine(0, r_ah, r_ab, r_ah);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(r_ab, r_ah, r_ab, 0);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(r_ab, 0, 0, 0);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(0, 0, 0, r_ah);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            Line2D catLine2D5 = catFactory2D1.CreateLine(z/2, r_ah-z/2, r_ab-z/2, r_ah-z/2);
            catLine2D5.StartPoint = catPoint2D5;
            catLine2D5.EndPoint = catPoint2D6;

            Line2D catLine2D6 = catFactory2D1.CreateLine(r_ab-z/2, r_ah-z/2, r_ab-z/ 2,z/2);
            catLine2D6.StartPoint = catPoint2D6;
            catLine2D6.EndPoint = catPoint2D7;

            Line2D catLine2D7 = catFactory2D1.CreateLine(r_ab-z / 2, z / 2,z/2,z/2);
            catLine2D7.StartPoint = catPoint2D7;
            catLine2D7.EndPoint = catPoint2D8;

            Line2D catLine2D8 = catFactory2D1.CreateLine(z / 2, z / 2, z / 2, r_ah-z/2);
            catLine2D8.StartPoint = catPoint2D8;
            catLine2D8.EndPoint = catPoint2D5;

            hsp_catiaProfil.CloseEdition();
            hsp_catiaPart.Part.Update();
        }
        //Funktion ErzeugeQuadratrohr
        public void ErzeugeQuadratrohr(Double qr_t)
        {
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, qr_t);

            catPad1.set_Name("Rechteckrohr");

            hsp_catiaPart.Part.Update();
        }
        //Funktion ErzeugeStab
        public void ErzeugeStab(Double tr)
        {
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, tr);

            catPad1.set_Name("Stab");

            hsp_catiaPart.Part.Update();
        }
        //Funktion ErzeugeRohr
        public void ErzeugeRohr(Double rtr)
        {
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, rtr);

            catPad1.set_Name("Rohr");

            hsp_catiaPart.Part.Update();
        }
        //Funktion ErzeugeBalken
        public void ErzeugeBalken(Double t)
        {
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, t);

            catPad1.set_Name("Balken");

            hsp_catiaPart.Part.Update();
        }
    }
}