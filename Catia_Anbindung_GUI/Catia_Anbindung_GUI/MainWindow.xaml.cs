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
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            Felderleeren();
        }

        private void Felderleeren()
        {
            TxtB_hoehe.Text = "";
            TxtB_breite.Text = "";
            TxtB_tiefe.Text = "";
        }

        private void Btn_Erstellen_Click(object sender, RoutedEventArgs e)
        {
            Erstellen();
        }

        public void Erstellen()
        {
            try
            {
                CatiaCon cc = new CatiaCon();
                if (cc.CATIALaeuft())
                {
                    double h = Convert.ToDouble(TxtB_hoehe.Text);
                    double b = Convert.ToDouble(TxtB_breite.Text);
                    double t = Convert.ToDouble(TxtB_tiefe.Text);
                    cc.ErzeugePart();
                    cc.ErstelleLeereSkizze();                   
                    cc.ErzeugeProfil(b,h);
                    cc.ErzeugeBalken(t);
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
        }

        private void Pict_Rechteck_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rechteckauswahl();
        }

        private void Rechteckauswahl()
        {
            Grid_Profilauswahl.Visibility = Visibility.Hidden;
            Grid_Vollprofil_Rechteck.Visibility = Visibility.Visible;
        }

        private void Btn_Zurück_Click(object sender, RoutedEventArgs e)
        {
            Profilauswahl();
        }

        private void Profilauswahl()
        {
            Grid_Profilauswahl.Visibility = Visibility.Visible;
            Grid_Vollprofil_Rundprofil.Visibility = Visibility.Hidden;
            Grid_Vollprofil_Rechteck.Visibility = Visibility.Hidden;
        }

        private void Rundprofilauswahl()
        {
            Grid_Profilauswahl.Visibility = Visibility.Hidden;
            Grid_Vollprofil_Rundprofil.Visibility = Visibility.Visible;
        }

        private void Pict_Rundprofil_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Rundprofilauswahl();
        }
    }    
}
