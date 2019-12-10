﻿using INFITF;
using MECMOD;
using PARTITF;
using System;
using System.Windows;

namespace Catia_Anbindung
{
    class CatiaCon
    {
        INFITF.Application hsp_catiaApp;
        MECMOD.PartDocument hsp_catiaPart;
        MECMOD.Sketch hsp_catiaProfil;
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
        public Boolean ErzeugePart()
        {
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPart = catDocuments1.Add("Part") as MECMOD.PartDocument;
            return true;
        }
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
        public void ErzeugeProfil(Double b, Double h)
        {
            hsp_catiaProfil.set_Name("Rechteck");
            Factory2D catFactory2D1 = hsp_catiaProfil.OpenEdition();

            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-50, 50);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(50, 50);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(50, -50);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-50, -50);

            Line2D catLine2D1 = catFactory2D1.CreateLine(-50, 50, 50, 50);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(50, 50, 50, -50);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(50, -50, -50, -50);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-50, -50, -50, 50);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            hsp_catiaProfil.CloseEdition();
            hsp_catiaPart.Part.Update();
        }
        public void ErzeugeBalken(Double l)
        {
            hsp_catiaPart.Part.InWorkObject = hsp_catiaPart.Part.MainBody;

            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPart.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaProfil, l);

            catPad1.set_Name("Balken");

            hsp_catiaPart.Part.Update();
        }


    }
}