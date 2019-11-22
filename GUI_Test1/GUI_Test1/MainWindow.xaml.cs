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

namespace GUI_Test1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TXB_Ergebnis.IsEnabled = false;
        }

        private void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BTN_Sortiere_Click(object sender, RoutedEventArgs e)
        {
            Sortierer();          
        }        
        private string Sortierer()
        {
            int[] intArray;
            intArray = new int[6];
            intArray[0] = Convert.ToInt32(TXB_1.Text);
            intArray[1] = Convert.ToInt32(TXB_2.Text);
            intArray[2] = Convert.ToInt32(TXB_3.Text);
            intArray[3] = Convert.ToInt32(TXB_4.Text);
            intArray[4] = Convert.ToInt32(TXB_5.Text);
            intArray[5] = Convert.ToInt32(TXB_6.Text);
            int ii = 0;
            do
            {
                if (intArray[0] > intArray[1])
                {
                    int temp = intArray[0];
                    intArray[0] = intArray[1];
                    intArray[1] = temp;
                }
                if (intArray[1] > intArray[2])
                {
                    int temp = intArray[1];
                    intArray[1] = intArray[2];
                    intArray[2] = temp;
                }
                if (intArray[2] > intArray[3])
                {
                    int temp = intArray[2];
                    intArray[2] = intArray[3];
                    intArray[3] = temp;
                }
                if (intArray[3] > intArray[4])
                {
                    int temp = intArray[3];
                    intArray[3] = intArray[4];
                    intArray[4] = temp;
                }
                if (intArray[4] > intArray[5])
                {
                    int temp = intArray[4];
                    intArray[4] = intArray[5];
                    intArray[5] = temp;
                }
                ii++;
            } while (ii < intArray.Length);
            string Zahl1 = Convert.ToString(intArray[0]);
            string Zahl2 = Convert.ToString(intArray[1]);
            string Zahl3 = Convert.ToString(intArray[2]);
            string Zahl4 = Convert.ToString(intArray[3]);
            string Zahl5 = Convert.ToString(intArray[4]);
            string Zahl6 = Convert.ToString(intArray[5]);
            return TXB_Ergebnis.Text = (Zahl1 + " "+Zahl2 + " "+Zahl3+" "+Zahl4+" "+Zahl5+" "+Zahl6);          
        }        
    }
}
