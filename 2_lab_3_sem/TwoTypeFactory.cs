using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lab_3_sem
{
    public class TwoTypeFactory : IGraphicFactory
    {
        private bool counter = false;
        public TwoTypeFactory()
        {

        }
        public GraphObject CreateGraphObject()
        {
            GraphObject go;
            if (counter == false)
            {
                go = CreateRectangleFigure();
                counter = true;
            }
            else
            {
                go = CreateEllipseFigure();
                counter = false;
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
