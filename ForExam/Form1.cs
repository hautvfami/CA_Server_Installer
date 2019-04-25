using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            A51 obj1 = new A51();
            A51 obj2 = new A51();
            if (textBox1.Text == "True")
            {
                textBox2.Text = obj1.Crypt(true).ToString();
            }
            else
            {
                textBox2.Text = obj1.Crypt(false).ToString();
            }

            if (textBox2.Text == "True")
            {
                textBox3.Text = obj2.Crypt(true).ToString();
            }
            else
            {
                textBox3.Text = obj2.Crypt(false).ToString();
            }
        }
    }
}
