using System.Drawing;
using System;

namespace _2_lab_3_sem
{
    public class EllipseObject : GraphObject
    {
        private int a, b;

        public EllipseObject() : base()
        {
            //a = r.Next(200);
            //b = r.Next(200);
            a = 100; b = 100;
            this.X = 100;
            this.Y = 100;
        }

        public override bool ContainsPoint(Point p)
        {
            double cx = x + a / 2;
            double cy = y + b / 2;
            if (
                (Math.Pow((p.X - cx), 2) / Math.Pow(a/2, 2) +
                Math.Pow((p.Y - cy), 2) / Math.Pow(b/2, 2)) <= 1.0)
            {
                return true;
            }
            return false;
        }

        public override void render(Graphics g)
        {
            g.FillEllipse(brush, x, y, a, b);
            if (selected == false)
            {
                g.DrawEllipse(Pens.Black, x, y, a, b);
            }
            else
            {
                g.DrawEllipse(Pens.AliceBlue, x, y, a, b);
            }
        }

        public int A
        {
            get => a;
            set
            {
                if (value < 0) { throw new ArgumentException("a<0!"); }
                a = value;
            }
        }
        public int B
        {
            get => b;
            set
            {
                if (value < 0) { throw new ArgumentException("b<0!"); }
                b = value;
            }
        }
    }
}