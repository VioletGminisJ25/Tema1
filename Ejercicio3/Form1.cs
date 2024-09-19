#define PERDER
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jugar();
        }

        public void Jugar()
        {

                Random gen = new Random();

                textBox1.Text = gen.Next(1, 8).ToString();
                textBox2.Text = gen.Next(1, 8).ToString();
                textBox3.Text = gen.Next(1, 8).ToString();

                label1.Text = (Convert.ToInt32(label1.Text) - 2).ToString();
                Normas();


        }
        public void Normas()
        {
            if (textBox1.Text == textBox2.Text && textBox1.Text == textBox3.Text)
            {
                label2.Text = "Premio!";
                label1.Text = (Convert.ToInt32(label1.Text) + 20).ToString();
            }
            if (textBox1.Text != textBox2.Text && textBox1.Text != textBox3.Text && textBox2.Text != textBox3.Text)
            {
                label2.Text = "";
            }
            else
            {
                label2.Text = "Premio!";
#if PERDER
                label1.Text = (Convert.ToInt32(label1.Text) - 5).ToString();
#else
                label1.Text = (Convert.ToInt32(label1.Text) + 5).ToString();
#endif
            }
            if(Convert.ToInt32(label1.Text) < 2)
            {
                if (Convert.ToInt32(label1.Text) < 0)
                {
                    label1.Text = 0.ToString();

                }
                button1.Enabled =false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = (Convert.ToInt32(label1.Text) + 10).ToString();
            button1.Enabled = true;
        }
    }
}
