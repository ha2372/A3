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

namespace Rechteckprofil_Berechnung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// Variablen  Zuweisungen
    public partial class MainWindow : Window
    {
        double breite;
        double hoehe;
        double tiefe;
        double dichte;
        double Radius;
        double radius;
        double vierinnen;
        double vieraussen;

        //Main Window Grundeinstellung
        public MainWindow()
        {
            InitializeComponent();
            InitOberflaeche();
            TxtB_Flaechentraegkeitsmoment.IsEnabled = false;
            TxtB_Querschnittsflaeche.IsEnabled = false;
            TxtB_Gewicht.IsEnabled = false;
            TxtB_Volumen.IsEnabled = false;
            Labl_Radius.Visibility = Visibility.Hidden;
            Labl_Innenradius.Visibility = Visibility.Hidden;
            TxtB_Radius.Visibility = Visibility.Hidden;
            TxtB_radius.Visibility = Visibility.Hidden;
            Labl_VierInnen.Visibility = Visibility.Hidden;
            TxtB_VierInnen.Visibility = Visibility.Hidden;
            Labl_VierAussen.Visibility = Visibility.Hidden;
            TxtB_VierAussen.Visibility = Visibility.Hidden;
            png_Rechteck.Visibility = Visibility.Hidden;
            png_Quadrat.Visibility = Visibility.Hidden;
            png_Quadratrohr.Visibility = Visibility.Hidden;
            png_Rohrprofil.Visibility = Visibility.Hidden;
            png_Rundprofil.Visibility = Visibility.Hidden;

          

        }

        //Profilberechnungen
        private void InitOberflaeche()
        {
            TxtB_Breite.Text = "";
            TxtB_Dichte.Text = "";
            TxtB_Hoehe.Text = "";
            TxtB_Tiefe.Text = "";
            TxtB_Radius.Text = "";
            TxtB_radius.Text = "";
            TxtB_VierAussen.Text = "";
            TxtB_VierInnen.Text = "";

            TxtB_Flaechentraegkeitsmoment.Text = "";
            TxtB_Querschnittsflaeche.Text = "";
            TxtB_Gewicht.Text = "";
            TxtB_Volumen.Text = "";
        }
        private double BerechneQuerschnittsflaeche()
        {
            return breite * hoehe;
        }
        private double BerechneVolumen()
        {
            return BerechneQuerschnittsflaeche() * tiefe;
        }
        private double BerechneGewicht()
        {
            return BerechneVolumen() * dichte;
        }
        private double BerechneFlaechentraegheitsmoment()
        {
            return breite * Math.Pow(hoehe, 3) / 12;
        }
        private double BerechneQuerschnittsflaecheRund()
        {
            return 3.14 * Radius * Radius;
        }
        private double BerechneVolumenRund()
        {
            return BerechneQuerschnittsflaecheRund() * tiefe;
        }
        private double BerechneGewichtRund()
        {
            return BerechneVolumenRund() * dichte;
        }
        private double BerechneFlaechentraegheitsmomentRund()
        {
            return 3.14 * Radius * 2 * Radius * 2 * Radius * 2 * Radius * 2 / 64;
        }
        private double BerechneQuerschnittsflaecheRohr()
        {
            return 3.14 * Radius * Radius - 3.14 * radius * radius;
        }
        private double BerechneVolumenRohr()
        {
            return BerechneQuerschnittsflaecheRohr() * tiefe;
        }
        private double BerechneGewichtRohr()
        {
            return BerechneVolumenRohr() * dichte;
        }
        private double BerechneFlaechentraegheitsmomentRohr()
        {
            double I = 2 * Radius * 2 * Radius * 2 * Radius * 2 * Radius - 2 * radius * 2 * radius * 2 * radius * 2 * radius;
            return 3.14 * I / 64;
        }
        private double BerechneQuerschnittsflaecheVier()
        {
            return hoehe * hoehe;
        }
        private double BerechneVolumenVier()
        {
            return BerechneQuerschnittsflaecheVier() * tiefe;
        }
        private double BerechneGewichtVier()
        {
            return BerechneVolumenVier() * dichte;
        }
        private double BerechneFlaechentraegheitsmomentVier()
        {
            return hoehe * hoehe * hoehe * hoehe / 12;
        }
        private double BerechneQuerschnittsflaecheVierRohr()
        {
            return vieraussen * vieraussen - vierinnen * vierinnen;
        }
        private double BerechneVolumenVierRohr()
        {
            return BerechneQuerschnittsflaecheVierRohr() * tiefe;
        }
        private double BerechneGewichtVierRohr()
        {
            return BerechneVolumenVierRohr() * dichte;
        }
        private double BerechneFlaechentraegheitsmomentVierRohr()
        {
            return vieraussen * vieraussen * vieraussen * vieraussen / 12 - vierinnen * vierinnen * vierinnen * vierinnen / 12;
        }
        private void Berechnungen()
        {
            if (TxtB_Radius.Text == "0" & TxtB_radius.Text == "0" & TxtB_VierInnen.Text == "0")
            {
                TxtB_Querschnittsflaeche.Text = BerechneQuerschnittsflaeche().ToString();
                TxtB_Volumen.Text = BerechneVolumen().ToString();
                TxtB_Gewicht.Text = BerechneGewicht().ToString();
                TxtB_Flaechentraegkeitsmoment.Text = BerechneFlaechentraegheitsmoment().ToString();
            }
            if (hoehe > 0 & TxtB_Breite.Text == "0" & TxtB_VierInnen.Text =="0")
            {
                TxtB_Querschnittsflaeche.Text = BerechneQuerschnittsflaecheVier().ToString();
                TxtB_Volumen.Text = BerechneVolumenVier().ToString();
                TxtB_Gewicht.Text = BerechneGewichtVier().ToString();
                TxtB_Flaechentraegkeitsmoment.Text = BerechneFlaechentraegheitsmomentVier().ToString();
            }
            if (vierinnen > 0 & vieraussen > 0)
            {
                TxtB_Querschnittsflaeche.Text = BerechneQuerschnittsflaecheVierRohr().ToString();
                TxtB_Volumen.Text = BerechneVolumenVierRohr().ToString();
                TxtB_Gewicht.Text = BerechneGewichtVierRohr().ToString();
                TxtB_Flaechentraegkeitsmoment.Text = BerechneFlaechentraegheitsmomentVierRohr().ToString();
            }
            if (TxtB_radius.Text == "0" & TxtB_Hoehe.Text == "0" & TxtB_VierInnen.Text =="0")
            {
                TxtB_Querschnittsflaeche.Text = BerechneQuerschnittsflaecheRund().ToString();
                TxtB_Volumen.Text = BerechneVolumenRund().ToString();
                TxtB_Gewicht.Text = BerechneGewichtRund().ToString();
                TxtB_Flaechentraegkeitsmoment.Text = BerechneFlaechentraegheitsmomentRund().ToString();
            }
            if (TxtB_Hoehe.Text == "0" & radius > 0 & TxtB_VierInnen.Text == "0")
            {
                TxtB_Querschnittsflaeche.Text = BerechneQuerschnittsflaecheRohr().ToString();
                TxtB_Volumen.Text = BerechneVolumenRohr().ToString();
                TxtB_Gewicht.Text = BerechneGewichtRohr().ToString();
                TxtB_Flaechentraegkeitsmoment.Text = BerechneFlaechentraegheitsmomentRohr().ToString();
            }
        }
    // Variablenwert zuweisung
    // 

        private void Btn_Berechnen_Click(object sender, RoutedEventArgs e)
        {
            SetzenNichtGefuellteFelderAufNull();
            try
            {
                breite = Convert.ToDouble(TxtB_Breite.Text.Replace('.', ','));
                hoehe = Convert.ToDouble(TxtB_Hoehe.Text.Replace('.', ','));
                tiefe = Convert.ToDouble(TxtB_Tiefe.Text.Replace('.', ','));
                dichte = Convert.ToDouble(TxtB_Dichte.Text.Replace('.', ','));
                Radius = Convert.ToDouble(TxtB_Radius.Text.Replace('.', ','));
                radius = Convert.ToDouble(TxtB_radius.Text.Replace('.', ','));
                vierinnen = Convert.ToDouble(TxtB_VierInnen.Text.Replace('.', ','));
                vieraussen = Convert.ToDouble(TxtB_VierAussen.Text.Replace('.', ','));
                Berechnungen();
            }
            catch (Exception)
            {
                // Fehlermeldung bei falscher Eingabe

                var result = MessageBox.Show("Bitte nur Zahlenwerte eingeben!" + Environment.NewLine + "Möchten Sie die Eingaben löschen?", "ALARM!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (result == MessageBoxResult.Yes)
                {
                    InitOberflaeche();
                }
            }

        }
        // Nicht gefüllte Felder auf Null setzen
        private void SetzenNichtGefuellteFelderAufNull()
        {
            if (TxtB_Breite.Text == "")
            {
                TxtB_Breite.Text = "0";
            }
            if (TxtB_Hoehe.Text == "")
            {
                TxtB_Hoehe.Text = "0";
            }
            if (TxtB_Tiefe.Text == "")
            {
                TxtB_Tiefe.Text = "0";
            }
            if (TxtB_Dichte.Text == "")
            {
                TxtB_Dichte.Text = "0";
            }
            if (TxtB_Radius.Text == "")
            {
                TxtB_Radius.Text = "0";
            }
            if (TxtB_radius.Text == "")
            {
                TxtB_radius.Text = "0";
            }
            if (TxtB_VierInnen.Text == "")
            {
                TxtB_VierInnen.Text = "0";
            }
            if (TxtB_VierAussen.Text == "")
            {
                TxtB_VierAussen.Text = "0";
            }
        }

        // Reset/ Felder leeren
        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            InitOberflaeche();

        }

        // Textbox initialiesierung 
        // Textbox initialiesierung Rundstahl
        
        private void Rundstahl()
        {
            Labl_Höhe.Visibility = Visibility.Hidden;
            TxtB_Hoehe.Visibility = Visibility.Hidden;
            Labl_Radius.Visibility = Visibility.Visible;
            TxtB_Radius.Visibility = Visibility.Visible;
            Labl_Innenradius.Visibility = Visibility.Hidden;
            TxtB_radius.Visibility = Visibility.Hidden;
            Labl_Breite.Visibility = Visibility.Hidden;
            TxtB_Breite.Visibility = Visibility.Hidden;
            Labl_nichtradius.Visibility = Visibility.Hidden;
            Labl_VierInnen.Visibility = Visibility.Hidden;
            TxtB_VierInnen.Visibility = Visibility.Hidden;
            Labl_VierAussen.Visibility = Visibility.Hidden;
            TxtB_VierAussen.Visibility = Visibility.Hidden;
            TxtB_VierInnen.Text = "";
            TxtB_VierAussen.Text = "";
            TxtB_Hoehe.Text = "";
            TxtB_Breite.Text = "";
            TxtB_radius.Text = "";
            TxtB_Radius.Text = "";
            png_Rechteck.Visibility = Visibility.Hidden;
            png_Quadrat.Visibility = Visibility.Hidden;
            png_Quadratrohr.Visibility = Visibility.Hidden;
            png_Rohrprofil.Visibility = Visibility.Hidden;
            png_Rundprofil.Visibility = Visibility.Visible;
        }
        // Treeview Rundmaterial AUswahl

        private void Rundmaterial(object sender, RoutedEventArgs e)
        {
            Rundstahl();
        }

        // Textbox initialiesierung Rechteckprofil
        private void Rechteckprofil(object sender, RoutedEventArgs e)
        {
            Rechteckpro();
        }
        // Treeview Rehteckprofil Auswahl
        private void Rechteckpro()
        {
            Labl_Radius.Visibility = Visibility.Hidden;
            TxtB_Radius.Visibility = Visibility.Hidden;
            Labl_Innenradius.Visibility = Visibility.Hidden;
            TxtB_radius.Visibility = Visibility.Hidden;
            Labl_Höhe.Visibility = Visibility.Visible;
            TxtB_Hoehe.Visibility = Visibility.Visible;
            Labl_Breite.Visibility = Visibility.Visible;
            TxtB_Breite.Visibility = Visibility.Visible;
            Labl_nichtradius.Visibility = Visibility.Visible;
            Labl_VierInnen.Visibility = Visibility.Hidden;
            TxtB_VierInnen.Visibility = Visibility.Hidden;
            Labl_VierAussen.Visibility = Visibility.Hidden;
            TxtB_VierAussen.Visibility = Visibility.Hidden;
            TxtB_VierInnen.Text = "";
            TxtB_VierAussen.Text = "";
            TxtB_Radius.Text = "";
            TxtB_radius.Text = "";
            TxtB_Hoehe.Text = "";
            TxtB_Breite.Text = "";
            png_Rechteck.Visibility = Visibility.Visible;
            png_Quadrat.Visibility = Visibility.Hidden;
            png_Quadratrohr.Visibility = Visibility.Hidden;
            png_Rohrprofil.Visibility = Visibility.Hidden;
            png_Rundprofil.Visibility = Visibility.Hidden;

        }

        private void Träger_T(object sender, RoutedEventArgs e)
        {
            Rechteckpro();
        }

        private void Träger_DT(object sender, RoutedEventArgs e)
        {
            Rechteckpro();
        }

        //Treeview Rohrprofil Auswahl
        // Textbox initialiesierung Rohrprofil
       
        private void Rohr(object sender, RoutedEventArgs e)
        {
            Rohrpro();
        }
        private void Rohrpro()
        {
            Labl_Höhe.Visibility = Visibility.Hidden;
            TxtB_Hoehe.Visibility = Visibility.Hidden;
            Labl_Breite.Visibility = Visibility.Hidden;
            TxtB_Breite.Visibility = Visibility.Hidden;
            Labl_Radius.Visibility = Visibility.Visible;
            TxtB_Radius.Visibility = Visibility.Visible;
            Labl_Innenradius.Visibility = Visibility.Visible;
            TxtB_radius.Visibility = Visibility.Visible;
            Labl_nichtradius.Visibility = Visibility.Visible;
            Labl_VierInnen.Visibility = Visibility.Hidden;
            TxtB_VierInnen.Visibility = Visibility.Hidden;
            Labl_VierAussen.Visibility = Visibility.Hidden;
            TxtB_VierAussen.Visibility = Visibility.Hidden;
            TxtB_VierInnen.Text = "";
            TxtB_VierAussen.Text = "";
            TxtB_Hoehe.Text = "";
            TxtB_Breite.Text = "";
            TxtB_Radius.Text = "";
            TxtB_radius.Text = "";
            png_Rechteck.Visibility = Visibility.Hidden;
            png_Quadrat.Visibility = Visibility.Hidden;
            png_Quadratrohr.Visibility = Visibility.Hidden;
            png_Rohrprofil.Visibility = Visibility.Visible;
            png_Rundprofil.Visibility = Visibility.Hidden;
        }

        // Treeview Vierkant Auswahl
        // Textbox initialiesierung Vierkant

        private void Vierkant(object sender, RoutedEventArgs e)
        {
            VierkantVier();
        }
        private void VierkantVier()
        {
            Labl_Radius.Visibility = Visibility.Hidden;
            TxtB_Radius.Visibility = Visibility.Hidden;
            Labl_Innenradius.Visibility = Visibility.Hidden;
            TxtB_radius.Visibility = Visibility.Hidden;
            Labl_Höhe.Visibility = Visibility.Visible;
            TxtB_Hoehe.Visibility = Visibility.Visible;
            Labl_Breite.Visibility = Visibility.Hidden;
            TxtB_Breite.Visibility = Visibility.Hidden;
            Labl_nichtradius.Visibility = Visibility.Hidden;            
            Labl_VierInnen.Visibility = Visibility.Hidden;
            TxtB_VierInnen.Visibility = Visibility.Hidden;
            Labl_VierAussen.Visibility = Visibility.Hidden;
            TxtB_VierAussen.Visibility = Visibility.Hidden;
            TxtB_VierInnen.Text = "";
            TxtB_VierAussen.Text = "";
            TxtB_Radius.Text = "";
            TxtB_radius.Text = "";
            TxtB_Hoehe.Text = "";
            TxtB_Breite.Text = "";
            png_Rechteck.Visibility = Visibility.Hidden;
            png_Quadrat.Visibility = Visibility.Visible;
            png_Quadratrohr.Visibility = Visibility.Hidden;
            png_Rohrprofil.Visibility = Visibility.Hidden;
            png_Rundprofil.Visibility = Visibility.Hidden;
        }

        //Treeview Vierkantrohr Auswahl
        // Textbox initialiesierung Vierkantrohr
        private void Vierkantrohr(object sender, RoutedEventArgs e)
        {
            VierRohr();
        }
        private void VierRohr()
        {
            Labl_Radius.Visibility = Visibility.Hidden;
            TxtB_Radius.Visibility = Visibility.Hidden;
            Labl_Innenradius.Visibility = Visibility.Hidden;
            TxtB_radius.Visibility = Visibility.Hidden;
            Labl_Höhe.Visibility = Visibility.Hidden;
            TxtB_Hoehe.Visibility = Visibility.Hidden;
            Labl_Breite.Visibility = Visibility.Hidden;
            TxtB_Breite.Visibility = Visibility.Hidden;
            Labl_nichtradius.Visibility = Visibility.Visible;
            Labl_VierInnen.Visibility = Visibility.Visible;
            TxtB_VierInnen.Visibility = Visibility.Visible;
            Labl_VierAussen.Visibility = Visibility.Visible;
            TxtB_VierAussen.Visibility = Visibility.Visible;
            TxtB_VierInnen.Text = "";
            TxtB_VierAussen.Text = "";
            TxtB_Radius.Text = "";
            TxtB_radius.Text = "";
            TxtB_Hoehe.Text = "";
            TxtB_Breite.Text = "";
            png_Rechteck.Visibility = Visibility.Hidden;
            png_Quadrat.Visibility = Visibility.Hidden;
            png_Quadratrohr.Visibility = Visibility.Visible;
            png_Rohrprofil.Visibility = Visibility.Hidden;
            png_Rundprofil.Visibility = Visibility.Hidden;
        }
    }   
}
