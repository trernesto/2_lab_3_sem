using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_lab_3_sem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitProgram(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MoveMouse(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = $"Mouse: {e.X}, {e.Y}";
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        List<GraphObject> list = new List<GraphObject>();
        private void PaintPanel(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach(GraphObject obj in list) 
            {
                obj.render(g);
            }

        }

        private void AddFigure(object sender, EventArgs e)
        {
            createRandomFigure(sender, e);
            panel1.Invalidate();
        }
        private static Random r = new Random();
        private GraphObject createRandomFigure(object sender, EventArgs e)
        {
            GraphObject go;
            if (r.Next(2) == 0)
            {
                go = AddRectangleFigure(sender, e);
            }
            else
            {
                go = AddEllipseFigure(sender, e);
            }
            return go;
        }
        private GraphObject AddRectangleFigure(object sender, EventArgs e)
        {
            GraphObject go = new RectangleObject();
            list.Add(go);
            return go;
        }

        private GraphObject AddEllipseFigure(object sender, EventArgs e)
        {
            GraphObject go = new EllipseObject();
            list.Add(go);
            return go;
        }

        private void doubleClick(object sender, MouseEventArgs e)
        {
            GraphObject go = createRandomFigure(sender, e);
            try
            {
                go.X = e.X;
                go.Y = e.Y;
            } catch (ArgumentException ex)
            {
                MessageBox.Show("Invalid arguments");
            }
            panel1.Refresh();
        }
        GraphObject savedObject;
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            savedObject = null;
            foreach (GraphObject obj in list)
            {
                obj.Selected = false;
                if (obj.ContainsPoint(e.Location))
                {
                    savedObject = obj;
                }
            }
            if (savedObject != null)
            {
                savedObject.Selected = true;
            }
            panel1.Invalidate();
        }

        private void deleteFigure(object sender, KeyPressEventArgs e)
        {   //q char
            if (e.KeyChar == (char)113)
            {
                delete(savedObject);
            }
            //e char
            if (e.KeyChar == (char)101)
            {
                setNewCords(savedObject);
            }
        }
        private void delete(GraphObject gp)
        {
            if (gp != null)
            {
                list.Remove(gp);
                panel1.Invalidate();
            }
        }

        private void setNewCords(GraphObject gp)
        {
            if (gp != null)
            {
                gp.X = r.Next(400);
                gp.Y = r.Next(300);
                panel1.Invalidate();
            }
        }

        private void deleteFigureMenu(object sender, EventArgs e)
        {
            delete(savedObject);
        }

        private void setNewCordsMenu(object sender, EventArgs e)
        {
            setNewCords(savedObject);
        }

        private void DeleteAll(object sender, EventArgs e)
        {
            list = new List<GraphObject>();
            panel1.Refresh();
        }
    }
}
