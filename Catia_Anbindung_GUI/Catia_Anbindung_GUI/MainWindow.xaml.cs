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
            TxtB_hoehe.Text = "0";
            TxtB_breite.Text = "0";
            TxtB_tiefe.Text = "0";
            TxtB_tiefer.Text = "0";
            TxtB_radius.Text = "0";
            TxtB_RAhoehe.Text = "0";
            TxtB_RIhoehe.Text = "0";
            TxtB_RAbreite.Text = "0";
            TxtB_RIbreite.Text = "0";
            TxtB_RAradius.Text = "0";
            TxtB_RIradius.Text = "0";
            TxtB_Rtiefe.Text = "0";
            TxtB_Rtiefer.Text = "0";
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
                    double tr = Convert.ToDouble(TxtB_tiefer.Text);
                    double r = Convert.ToDouble(TxtB_radius.Text);
                    double r_ah = Convert.ToDouble(TxtB_RAhoehe.Text);
                    double r_ih = Convert.ToDouble(TxtB_RIhoehe.Text);
                    double r_ab = Convert.ToDouble(TxtB_RAbreite.Text);
                    double r_ib = Convert.ToDouble(TxtB_RIbreite.Text);
                    double qr_t = Convert.ToDouble(TxtB_Rtiefe.Text);
                    double ra = Convert.ToDouble(TxtB_RAradius.Text);
                    double ri = Convert.ToDouble(TxtB_RIradius.Text);
                    double rtr = Convert.ToDouble(TxtB_Rtiefer.Text);
                    int eins = Convert.ToInt32(TxtB_hoehe.Text);
                    int zwei = Convert.ToInt32(TxtB_radius.Text);
                    int drei = Convert.ToInt32(TxtB_RAhoehe.Text);
                    int vier = Convert.ToInt32(TxtB_RAradius.Text);
                    cc.ErzeugePart();
                    cc.ErstelleLeereSkizze();
                    if(eins > 0 & zwei == 0 & drei == 0 & vier == 0)
                    {
                        cc.ErzeugeRechteck(b, h);
                        cc.ErzeugeBalken(t);
                    }
                    if(eins == 0 & zwei > 0 & drei == 0 & vier == 0)
                    {
                        cc.ErzeugeKreis(r);
                        cc.ErzeugeStab(tr);
                    }             
                    if(eins == 0 & zwei == 0 & drei > 0 & vier == 0)
                    {
                        cc.ErzeugeRechteckRohr(r_ah, r_ih, r_ab, r_ib);
                        cc.ErzeugeQuadratrohr(qr_t);
                    }
                    if(eins == 0 & zwei == 0 & drei == 0 & vier > 0)
                    {
                        cc.ErzeugeKreisring(ra, ri);
                        cc.ErzeugeRohr(rtr);
                    }                    
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

        public void Rechteckauswahl()
        {
            Felderleeren();
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
            Grid_Rechteckrohr.Visibility = Visibility.Hidden;
            Grid_Rohrprofil.Visibility = Visibility.Hidden;
        }

        public void Rundprofilauswahl()
        {
            Felderleeren();
            Grid_Profilauswahl.Visibility = Visibility.Hidden;
            Grid_Vollprofil_Rundprofil.Visibility = Visibility.Visible;
        }

        private void Pict_Rundprofil_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Rundprofilauswahl();
        }

        private void Pict_Rechteckrohr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RechteckrohrAuswahl();
        }
        
        public void RechteckrohrAuswahl()
        {
            Felderleeren();
            Grid_Profilauswahl.Visibility = Visibility.Hidden;
            Grid_Rechteckrohr.Visibility = Visibility.Visible;
        }

        private void Pict_Rohr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RohrAuswahl();
        }

        public void RohrAuswahl()
        {
            Felderleeren();
            Grid_Profilauswahl.Visibility = Visibility.Hidden;
            Grid_Rohrprofil.Visibility = Visibility.Visible;
        }
    }    
}
