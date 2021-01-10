using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbInput.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbInput.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbInput.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbInput.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbInput.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tbInput.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tbInput.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tbInput.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tbInput.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (tbInput.Text != string.Empty)
            {
                if (tbInput.Text[tbInput.Text.Length - 2] == '/' && tbInput.Text[tbInput.Text.Length - 1] == ' ')
                {
                    MessageBox.Show("Не може да се дели на нула", "Грешка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            tbInput.Text += "0";
        }
        bool dotUsed = false;
        private void btnDot_Click(object sender, EventArgs e)
        {


            if (dotUsed == false)
            {
                tbInput.Text += ".";
                dotUsed = true;
            }
            else
            {
                tbInput.Text += string.Empty;
            }

        }


        private void btnDivide_Click(object sender, EventArgs e)
        {
            //cant start with /
            if (tbInput.Text == string.Empty)
            {
                MessageBoxWarninDivideMultiply();
                return;
            }
            if (ValidatingRightOperators(tbInput))
            {
                return;
            }


            tbInput.Text += " / ";

            dotUsed = false;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {

            //cant start with *
            if (tbInput.Text == string.Empty)
            {
                MessageBoxWarninDivideMultiply();
                return;
            }
            if (ValidatingRightOperators(tbInput))
            {
                return;
            }

            tbInput.Text += " * ";

            dotUsed = false;

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (tbInput.Text != string.Empty)
            {
                if (ValidatingRightOperators(tbInput))
                {
                    return;
                }
            }

            tbInput.Text += " - ";
            dotUsed = false;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (ValidatingRightOperators(tbInput))
            {
                return;
            }
            tbInput.Text += " + ";
            dotUsed = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbInput.Clear();
        }

        public static void MessageBoxWarninDivideMultiply()
        {
            MessageBox.Show("Не може уравнението да започва с този знак", "Грешка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MessageBoxCantTwoOperators()
        {
            MessageBox.Show("Не може два оператора един до друг", "Грешка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ValidatingRightOperators(TextBox tbInput)
        {
            if (tbInput.Text[tbInput.Text.Length - 1] == ' ' && (tbInput.Text[tbInput.Text.Length - 2] == '*'
                || tbInput.Text[tbInput.Text.Length - 2] == '/'
                || tbInput.Text[tbInput.Text.Length - 2] == '+'
                || tbInput.Text[tbInput.Text.Length - 2] == '-'))
            {
                MessageBoxCantTwoOperators();
                return true;

            }
            return false;
        }


    }
}
