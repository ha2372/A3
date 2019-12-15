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
        //public Variable d, da sie für alle Auswahlfenster verwendet wird 
        public double d;
        //MainWindow-Start des Programms
        public MainWindow()
        {
            InitializeComponent();
            //Textboxen der Berechnungen deaktivieren
            TxtB_Querschnittsfläche.IsEnabled = false;
            TxtB_Volumen.IsEnabled = false;
            TxtB_Flächenträgheitsmoment.IsEnabled = false;
            TxtB_Gewicht.IsEnabled = false;
            TxtB_Dichte.IsEnabled = false;            
        }
        //Funktionsaufruf Felderleeren
        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            Felderleeren();
        }
        //Funktion Felderleeren
        private void Felderleeren()
        {
            TxtB_hoehe.Text = "0";
            TxtB_breite.Text = "0";
            TxtB_tiefe.Text = "0";
            TxtB_tiefer.Text = "0";
            TxtB_radius.Text = "0";
            TxtB_RAhoehe.Text = "0";           
            TxtB_RAbreite.Text = "0";
            TxtB_Wandstärke.Text = "0";
            TxtB_RAradius.Text = "0";
            TxtB_RIradius.Text = "0";
            TxtB_Rtiefe.Text = "0";
            TxtB_Rtiefer.Text = "0";
            TxtB_Flächenträgheitsmoment.Text = "0";
            TxtB_Querschnittsfläche.Text = "0";
            TxtB_Volumen.Text = "0";
            TxtB_Gewicht.Text = "0";
            TxtB_Dichte.Text = "0";
        }
        //Funktionsaufruf Erstellen
        private void Btn_Erstellen_Click(object sender, RoutedEventArgs e)
        {
            Erstellen();
        }
        //Funktion Erstellen
        public void Erstellen()
        {
            try
            {
                //Funktionsaufruf CatiaCon
                CatiaCon cc = new CatiaCon();
                if (cc.CATIALaeuft())
                {
                    //Textboxen in Variablen konvertieren
                    double h = Convert.ToDouble(TxtB_hoehe.Text);
                    double b = Convert.ToDouble(TxtB_breite.Text);
                    double t = Convert.ToDouble(TxtB_tiefe.Text);
                    double tr = Convert.ToDouble(TxtB_tiefer.Text);
                    double r = Convert.ToDouble(TxtB_radius.Text);
                    double r_ah = Convert.ToDouble(TxtB_RAhoehe.Text);
                    double r_ab = Convert.ToDouble(TxtB_RAbreite.Text);
                    double x = Convert.ToDouble(TxtB_Wandstärke.Text);
                    double z = 2 * x;
                    double qr_t = Convert.ToDouble(TxtB_Rtiefe.Text);
                    double ra = Convert.ToDouble(TxtB_RAradius.Text);
                    double ri = Convert.ToDouble(TxtB_RIradius.Text);
                    double rtr = Convert.ToDouble(TxtB_Rtiefer.Text);
                    //Zusatzvariablen für Checkboxen und Profilauswahl
                    int eins = Convert.ToInt32(TxtB_hoehe.Text);
                    int zwei = Convert.ToInt32(TxtB_radius.Text);
                    int drei = Convert.ToInt32(TxtB_RAhoehe.Text);
                    int vier = Convert.ToInt32(TxtB_RAradius.Text);
                    int fünf = Convert.ToInt32(ChBo_Radien.IsChecked);
                    //Kontrolle negative Werte
                    if (h>0 ^ r_ah >0&r_ab>0 ^ ra > ri ^ r > 0)
                    {
                        //Skizze erstellen
                        cc.ErzeugePart();
                        cc.ErstelleLeereSkizze();
                        //Rechteck Vollprofil
                        if (eins > 0 & zwei == 0 & drei == 0 & vier == 0)
                        {
                            cc.ErzeugeRechteck(b, h);
                            cc.ErzeugeBalken(t);
                        }
                        //Kreis Vollprofil
                        if (eins == 0 & zwei > 0 & drei == 0 & vier == 0)
                        {
                            cc.ErzeugeKreis(r);
                            cc.ErzeugeStab(tr);
                        }
                        //Rechteck Rohr
                        if (eins == 0 & zwei == 0 & drei > 0 & vier == 0)
                        {
                            //mit Radien
                            if (fünf > 0)
                            {
                                cc.ErzeugeVierkantrohr(r_ah, r_ab,z);
                            }
                            //ohne Radien
                            else
                            {
                                cc.ErzeugeRechteckRohr(r_ah, r_ab,z);
                            }
                            cc.ErzeugeQuadratrohr(qr_t);
                        }
                        //Kreis Rohr
                        if (eins == 0 & zwei == 0 & drei == 0 & vier > 0)
                        {
                            cc.ErzeugeKreisring(ra, ri);
                            cc.ErzeugeRohr(rtr);
                        }
                    }
                    //Fehlermeldung negativer Wert
                    else
                    {
                        MessageBox.Show("Äußerer Wert nicht größer als innerer Wert! Wert kleiner Null!");
                    }
                    
                }
                //Fehlermeldung Catia läugt nicht
                else
                {
                    Console.WriteLine("Laufende Catia Application nicht gefunden");
                }
            }
            //Absturzsicherung
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception aufgetreten");
            }
        }
        //Funktionsaufruf Rechteckauswahl
        private void Pict_Rechteck_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rechteckauswahl();
        }
        //Funktion Rechteckauswahl
        public void Rechteckauswahl()
        {
            Felderleeren();
            Grid_Profilauswahl.Visibility = Visibility.Hidden;
            Grid_Vollprofil_Rechteck.Visibility = Visibility.Visible;
            Grid_Info.Visibility = Visibility.Visible;
        }
        //Funktionsaufruf Profilauswahl
        private void Btn_Zurück_Click(object sender, RoutedEventArgs e)
        {
            Profilauswahl();
        }
        //Funktion Profilauswahl
        private void Profilauswahl()
        {
            Grid_Profilauswahl.Visibility = Visibility.Visible;
            Grid_Vollprofil_Rundprofil.Visibility = Visibility.Hidden;
            Grid_Vollprofil_Rechteck.Visibility = Visibility.Hidden;
            Grid_Rechteckrohr.Visibility = Visibility.Hidden;
            Grid_Rohrprofil.Visibility = Visibility.Hidden;
            Grid_Info.Visibility = Visibility.Hidden;
        }
        //Funktion Rundprofilauswahl
        public void Rundprofilauswahl()
        {
            Felderleeren();
            Grid_Profilauswahl.Visibility = Visibility.Hidden;
            Grid_Vollprofil_Rundprofil.Visibility = Visibility.Visible;
            Grid_Info.Visibility = Visibility.Visible;
        }
        //Funktionsaufruf Rundprofilauswahl
        private void Pict_Rundprofil_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Rundprofilauswahl();
        }
        //Funktionsaufruf Rechteckrohrauwahl
        private void Pict_Rechteckrohr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RechteckrohrAuswahl();
        }
        //Funktion Rechteckrohrauswahl
        public void RechteckrohrAuswahl()
        {
            Felderleeren();
            Grid_Profilauswahl.Visibility = Visibility.Hidden;
            Grid_Rechteckrohr.Visibility = Visibility.Visible;
            Grid_Info.Visibility = Visibility.Visible;
        }
        //Funktionsaufruf RohrAuswahl
        private void Pict_Rohr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RohrAuswahl();
        }
        //Funktion RohrAuswahl
        public void RohrAuswahl()
        {
            Felderleeren();
            Grid_Profilauswahl.Visibility = Visibility.Hidden;
            Grid_Rohrprofil.Visibility = Visibility.Visible;
            Grid_Info.Visibility = Visibility.Visible;
        }
        //Funktionsaufruf Berechnen
        private void Btn_Berechnen_Click(object sender, RoutedEventArgs e)
        {
            Berechnen();
        }
        //Funktion Berechnen
        public void Berechnen()
        {
            //Textboxen zu Vriablen konvertieren
            double h = Convert.ToDouble(TxtB_hoehe.Text);
            double b = Convert.ToDouble(TxtB_breite.Text);
            double t = Convert.ToDouble(TxtB_tiefe.Text);
            double tr = Convert.ToDouble(TxtB_tiefer.Text);
            double r = Convert.ToDouble(TxtB_radius.Text);
            double r_ah = Convert.ToDouble(TxtB_RAhoehe.Text);
            double r_ab = Convert.ToDouble(TxtB_RAbreite.Text);
            double x = Convert.ToDouble(TxtB_Wandstärke.Text);
            double z = 2 * x;
            double qr_t = Convert.ToDouble(TxtB_Rtiefe.Text);
            double ra = Convert.ToDouble(TxtB_RAradius.Text);
            double ri = Convert.ToDouble(TxtB_RIradius.Text);
            double rtr = Convert.ToDouble(TxtB_Rtiefer.Text);
            //Zusatzvariablen wie oben
            int eins = Convert.ToInt32(TxtB_hoehe.Text);
            int zwei = Convert.ToInt32(TxtB_radius.Text);
            int drei = Convert.ToInt32(TxtB_RAhoehe.Text);
            int vier = Convert.ToInt32(TxtB_RAradius.Text);
            int fünf = Convert.ToInt32(ChBo_Radien.IsChecked);
            int sechs = Convert.ToInt32(ChBo_Dichte.IsChecked);
            //Benutzerdefinierte Dichte
            if (sechs>0)
            {
                d = Convert.ToDouble(TxtB_Dichte.Text);
            }
            //Rechteck Vollprofil
            if (eins > 0 & zwei == 0 & drei == 0 & vier == 0)
            {
                TxtB_Querschnittsfläche.Text = Convert.ToString( h * b);
                TxtB_Volumen.Text = Convert.ToString(h * b * t);
                TxtB_Flächenträgheitsmoment.Text = Convert.ToString((b / 1000) * (h / 1000) * (h / 1000) * (h / 1000) / 12);
                TxtB_Gewicht.Text = Convert.ToString((h * b * t)*d/1000/1000);
            }
            //Kreis Vollprofil
            if (eins == 0 & zwei > 0 & drei == 0 & vier == 0)
            {
                TxtB_Querschnittsfläche.Text = Convert.ToString(3.14*r*r);
                TxtB_Volumen.Text = Convert.ToString(3.14*r*r*tr);
                TxtB_Flächenträgheitsmoment.Text = Convert.ToString(3.14 * (2 * r / 1000) * (2 * r / 1000) * (2 * r / 1000) * (2 * r / 1000) / 64);
                TxtB_Gewicht.Text = Convert.ToString((3.14 * r * r * tr)*d/1000/1000);
            }
            //Kreis Rohr
            if (eins == 0 & zwei == 0 & drei == 0 & vier > 0)
            {
                TxtB_Querschnittsfläche.Text = Convert.ToString((3.14 * ra * ra)-(3.14*ri*ri));
                TxtB_Volumen.Text = Convert.ToString(((3.14 * ra * ra) - (3.14 * ri * ri))*rtr);
                TxtB_Flächenträgheitsmoment.Text = Convert.ToString((3.14 * ((2 * ra / 1000) * (2 * ra / 1000) * (2 * ra / 1000) * (2 * ra / 1000)- (2 * ri / 1000) * (2 * ri / 1000) * (2 * ri / 1000) * (2 * ri / 1000))) / 64);
                TxtB_Gewicht.Text = Convert.ToString((((3.14 * ra * ra) - (3.14 * ri * ri)) * rtr)*d/1000/1000);
            }
            //Rechteck Rohr
            if (eins == 0 & zwei == 0 & drei > 0 & vier == 0)
            {
                //mit Radien
                if (fünf > 0)
                {
                    TxtB_Querschnittsfläche.Text = Convert.ToString(r_ah * r_ab-(r_ah-z)*(r_ab-z));
                    TxtB_Volumen.Text = Convert.ToString((r_ah * r_ab - (r_ah - z) * (r_ab - z))*qr_t);
                    TxtB_Flächenträgheitsmoment.Text = Convert.ToString(((r_ab / 1000) * (r_ah / 1000) * (r_ah / 1000) * (r_ah / 1000) / 12) - (((r_ab - z) / 1000) * ((r_ah - z) / 1000) * ((r_ah - z) / 1000) * ((r_ah - z) / 1000) / 12));
                    TxtB_Gewicht.Text = Convert.ToString(((r_ah * r_ab - (r_ah - z) * (r_ab - z)) * qr_t)*d/1000/1000);
                }
                //ohne Radien
                else
                {
                    TxtB_Querschnittsfläche.Text = Convert.ToString(r_ah * r_ab - (r_ah - z) * (r_ab - z));
                    TxtB_Volumen.Text = Convert.ToString((r_ah * r_ab - (r_ah - z) * (r_ab - z)) * qr_t);
                    TxtB_Flächenträgheitsmoment.Text = Convert.ToString(((r_ab / 1000) * (r_ah / 1000) * (r_ah / 1000) * (r_ah / 1000) / 12) - (((r_ab - z) / 1000) * ((r_ah - z) / 1000) * ((r_ah - z) / 1000) * ((r_ah - z) / 1000) / 12));
                    TxtB_Gewicht.Text = Convert.ToString(((r_ah * r_ab - (r_ah - z) * (r_ab - z)) * qr_t) * d/1000/1000);
                }           
            }
        }
        //Funktionsaufruf Dichte
        private void ChBo_Dichte_Checked(object sender, RoutedEventArgs e)
        {
            Dichte();
        }
        //Funktion Dichte
        public void Dichte()
        {
            ChBo_Stahl.IsChecked = false;
            ChBo_Aluminium.IsChecked = false;
            TxtB_Dichte.IsEnabled = true;                      
        }
        //Funktionsaufruf Stahl
        public void ChBo_Stahl_Checked(object sender, RoutedEventArgs e)
        {
            Stahl();
        }
        //Funktion Stahl
        public double Stahl()
        {
            ChBo_Dichte.IsChecked = false;
            ChBo_Aluminium.IsChecked = false;
            TxtB_Dichte.IsEnabled = false;
            TxtB_Dichte.Text = "0";
            return d = 7.85;
        }
        //Funktionsaufruf Aluminium
        private void ChBo_Aluminium_Checked(object sender, RoutedEventArgs e)
        {
            Aluminium();
        }
        //Funktion Aluminium
        public double Aluminium()
        {
            ChBo_Dichte.IsChecked = false;
            ChBo_Stahl.IsChecked = false;
            TxtB_Dichte.IsEnabled = false;
            TxtB_Dichte.Text = "0";
            return d = 2.7;
        }
    }    
}
