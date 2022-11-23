using System;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace _2_lab_3_sem
{
    public class GraphObject
    {
        static Random r = new Random();
        private Color c; 
        private int x, y, w, h;
        private SolidBrush brush;
        private bool selected = false;
        public GraphObject()
        {
            Color[] cols = { Color.Red, Color.Green, 
                Color.Yellow, Color.Tomato, Color.Cyan };
            c = cols[r.Next(cols.Length)];
            x = r.Next(400);
            y = r.Next(300);
            w = r.Next(100); ;
            h = r.Next(100); ;
            brush = new SolidBrush(c);

        }

        internal void render(Graphics g)
        {
            g.FillEllipse(brush, x, y, w, h);
            if (selected == false)
            {
                g.DrawRectangle(Pens.Black, x, y, w, h);
            } else
            {
                g.DrawRectangle(Pens.Green, x, y, w, h);
            }
        }

        public bool ContainsPoint(Point p)
        {
            if (p.X <= x + w && p.X >= x 
                && p.Y <= y + h && p.Y >= y)
            {
                return true;
            }
            return false;
        }

        public int X { 
            get => x; 
            set {
                if (value < 0) { throw new ArgumentException("x<0!"); }
                if (value > 685) { throw new ArgumentException("x>685!"); }
                x = value; 
            } 
        }
        public int Y
        {
            get => y;
            set
            {
                if (value < 0) { throw new ArgumentException("y<0!"); }
                if (value > 300) { throw new ArgumentException("y>300!"); }
                y = value;
            }
        }
        public int W
        {
            get => w;
            set
            {
                if (value < 0) { throw new ArgumentException("w<0!"); }
                w = value;
            }
        }
        public int H
        {
            get => h;
            set
            {
                if (value < 0) { throw new ArgumentException("h<0!"); }
                h = value;
            }
        }

        public bool Selected 
        {
            get => selected;
            set { selected = value; }
        }
    }
}