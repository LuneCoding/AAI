using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DragonVilleGameAI.Entities;
using DragonVilleGameAI.GUI;

namespace DragonVilleGameAI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null,
         WorldView, new object[] { true });
            World.Instance.View = this;
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void WorldView_Paint(object sender, PaintEventArgs e)
        {
            WorldGraphics.Render(e.Graphics, WorldView);
        }

        public void Render()
        {
           WorldView.Invalidate();
        }

        private void WorldView_Click(object sender, EventArgs e)
        {
            WorldView.Invalidate();

        }
    }
}
