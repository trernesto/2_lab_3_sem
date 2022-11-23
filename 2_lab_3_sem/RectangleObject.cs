using System;
using System.Drawing;

namespace _2_lab_3_sem
{
    public class RectangleObject : GraphObject
    {
        private int w, h;

        public RectangleObject() : base()
        {
            w = r.Next(200);
            h = r.Next(200);
        }

        public override bool ContainsPoint(Point p)
        {
            if (p.X <= x + w && p.X >= x
                && p.Y <= y + h && p.Y >= y)
            {
                return true;
            }
            return false;
        }

        public override void render(Graphics g)
        {
            g.FillRectangle(brush, x, y, w, h);
            if (selected == false)
            {
                g.DrawRectangle(Pens.Black, x, y, w, h);
            }
            else
            {
                g.DrawRectangle(Pens.AliceBlue, x, y, w, h);
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
    }
}