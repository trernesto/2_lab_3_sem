using System;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace _2_lab_3_sem
{
    public abstract class GraphObject
    {
        static protected Random r = new Random();
        protected Color c; 
        protected int x, y;
        protected SolidBrush brush;
        protected bool selected = false;
        public GraphObject()
        {
            Color[] cols = { Color.Red, Color.Green, 
                Color.Yellow, Color.Tomato, Color.Cyan };
            c = cols[r.Next(cols.Length)];
            x = r.Next(400);
            y = r.Next(300);
            brush = new SolidBrush(c);

        }

        abstract public void render(Graphics g);

        abstract public bool ContainsPoint(Point p);

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

        public bool Selected 
        {
            get => selected;
            set { selected = value; }
        }
    }
}