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
            GraphObject go = new GraphObject();
            list.Add(go);

            panel1.Invalidate();
        }

        private void doubleClick(object sender, MouseEventArgs e)
        {
            GraphObject go = new GraphObject();
            list.Add(go);
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

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            GraphObject go = new GraphObject();
            foreach (GraphObject obj in list)
            {
                obj.Selected = false;
                if (obj.ContainsPoint(e.Location))
                {
                    go = obj;
                }
            }
            go.Selected = true;
            panel1.Invalidate();
        }
    }
}
