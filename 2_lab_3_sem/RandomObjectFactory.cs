using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lab_3_sem
{
    public class RandomObjectFactory : IGraphicFactory
    {
        public RandomObjectFactory()
        {

        }
        public GraphObject CreateGraphObject()
        {
            Random r = new Random();
            GraphObject go;
            if (r.Next(2) == 0)
            {
                go = CreateRectangleFigure();
            }
            else
            {
                go = CreateEllipseFigure();
            }
            return go;
        }

        protected GraphObject CreateRectangleFigure()
        {
            GraphObject go = new RectangleObject();
            return go;
        }

        protected GraphObject CreateEllipseFigure()
        {
            GraphObject go = new EllipseObject();
            return go;
        }
    }
}
