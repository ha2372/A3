using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Übung_Obkektorientierung
{
    public class Kreis
    {
        private float x;
        private float y;
        private float radius;

        public Kreis(float xx, float yy)
        {
            x = xx;
            y = yy;
        }
        public Kreis(float r)
        {
            radius = r;
        }
        public void setMittelpunkt(float xx, float yy)
        {
            x = xx;
            y = yy;
            Console.WriteLine(x);
            Console.WriteLine(y);
        }
        public void setRadius(float r)
        {
            radius = r;
            Console.WriteLine(radius);
        }
    }
    class Kreiscontrol
    {
        Kreiscontrol()
        {
            Kreis MeinKreis1 = new Kreis(0, 0);
            MeinKreis1.setMittelpunkt(10, 20);
            MeinKreis1.setRadius(40);
            MeinKreis1.setMittelpunkt(5, 10);
            MeinKreis1.setRadius(20);
            Kreis MeinKreis2 = new Kreis(0, 0);
            MeinKreis2.setMittelpunkt(40, 45);
            MeinKreis2.setRadius(80);
        }
        static void Main(string[] args)
        {
            new Kreiscontrol();
            Console.ReadKey();
        }   
    }
}

