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
    public partial class MainWindow : Window
    {
        double breite;
        double hoehe;
        double tiefe;
        double dichte;

        public MainWindow()
        {
            InitializeComponent();
            InitOberflaeche();
            TxtB_Flaechentraegkeitsmoment.IsEnabled = false;
            TxtB_Querschnittsflaeche.IsEnabled = false;
            TxtB_Gewicht.IsEnabled = false;
            TxtB_Volumen.IsEnabled = false;
        }
        private void InitOberflaeche()
        {
            TxtB_Breite.Text = "";
            TxtB_Dichte.Text = "";
            TxtB_Hoehe.Text = "";
            TxtB_Tiefe.Text = "";

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


            return BerechneVolumen() * dichte;

        }

        private void Berechnungen()
        {
            TxtB_Querschnittsflaeche.Text = BerechneQuerschnittsflaeche().ToString();
            TxtB_Volumen.Text = BerechneVolumen().ToString();
            TxtB_Gewicht.Text = BerechneGewicht().ToString();
            TxtB_Flaechentraegkeitsmoment.Text = BerechneFlaechentraegheitsmoment().ToString();
            
        }
       
        private void Btn_Berechnen_Click(object sender, RoutedEventArgs e)
        {
            SetzenNichtGefuellteFelderAufNull();
            try { 
            breite =Convert.ToDouble( TxtB_Breite.Text.Replace('.',','));
            hoehe = Convert.ToDouble(TxtB_Hoehe.Text.Replace('.', ','));
              tiefe = Convert.ToDouble(TxtB_Tiefe.Text.Replace('.', ','));
               dichte = Convert.ToDouble(TxtB_Dichte.Text.Replace('.', ','));
                Berechnungen();

            }
            catch (Exception )
            {
                var result = MessageBox.Show("Bitte nur Zahlenwerte eingeben!" + Environment.NewLine + "Möchten Sie die Eingaben löschen?", "ALARM!", MessageBoxButton.YesNo, MessageBoxImage.Error);

               if ( result == MessageBoxResult.Yes)
                {
                    InitOberflaeche();
                    


                }
            }

        }
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
        }
        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            InitOberflaeche();

        }
    }
}
