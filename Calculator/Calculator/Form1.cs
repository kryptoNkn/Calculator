using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }


        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
        }

        private void buttonClick(object sender, EventArgs e)
        {
            var currentButton = sender as Button;
            maskedTextBox1.Text += currentButton.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var equals = new DataTable();
            maskedTextBox1.Text = equals.Compute(maskedTextBox1.Text, "").ToString();
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var str = "";
            for (int i = 0; i < maskedTextBox1.Text.Length - 1; i++)
            {
                str += maskedTextBox1.Text[i];
            }
            maskedTextBox1.Text = str;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
