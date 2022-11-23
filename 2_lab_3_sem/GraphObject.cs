using System;
using System.Drawing;

namespace _2_lab_3_sem
{
    public class GraphObject
    {
        static Random r = new Random();
        private Color c; 
        private int x, y, w, h;
        private SolidBrush brush;
        public GraphObject()
        {
            Color[] cols = { Color.Red, Color.Green, 
                Color.Yellow, Color.Tomato, Color.Cyan };
            c = cols[r.Next(cols.Length)];
            x = r.Next(600);
            y = r.Next(300);
            w = r.Next(100); ;
            h = r.Next(100); ;
            brush = new SolidBrush(c);

        }

        internal void render(Graphics g)
        {
            g.FillEllipse(brush, x, y, w, h);
        }

        public int X { get => x; set { x = value; } }
        public int Y { get => y; set { y = value; } }
        public int W { get => w; set { w = value; } }
        public int H { get => h; set { h = value; } }
    }
}