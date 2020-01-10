using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics myCanvas = myPictureBox.CreateGraphics();
            Pen myPen = new Pen(Brushes.Black);
            //myCanvas.DrawEllipse(myPen, 100, 100, 20, 20);

            Huffmann coding = new Huffmann();
            coding.CreateMinHeap(textBox1.Text);
            listBox1.DataSource = coding.codelist;
        }
    }
}
