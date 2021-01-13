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
        private void btnPower_Click(object sender, EventArgs e)
        {
            //cant start with *
            if (tbInput.Text == string.Empty)
            {
                MessageBoxWarninDivideMultiplyPower();
                return;
            }
            if (ValidatingRightOperators(tbInput))
            {
                return;
            }
            if (WrongSymbolsUnderSqrt(tbInput))
            {
                return;
            }

            tbInput.Text += " ^ ";

            dotUsed = false;
        }
        private void btnSqrt_Click(object sender, EventArgs e)
        {
            tbInput.Text += " √ ";
            dotUsed = false;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            //cant start with /
            if (tbInput.Text == string.Empty)
            {
                MessageBoxWarninDivideMultiplyPower();
                return;
            }
            if (ValidatingRightOperators(tbInput))
            {
                return;
            }
            if (WrongSymbolsUnderSqrt(tbInput))
            {
                return;
            }


            tbInput.Text += " / ";


        }

        private void btnProduct_Click(object sender, EventArgs e)
        {

            //cant start with *
            if (tbInput.Text == string.Empty)
            {
                MessageBoxWarninDivideMultiplyPower();
                return;
            }
            if (ValidatingRightOperators(tbInput))
            {
                return;
            }
            if (WrongSymbolsUnderSqrt(tbInput))
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
            if (tbInput.Text.Contains('√'))
            {
                if (tbInput.Text[tbInput.Text.Length - 2] == '√')
                {
                    MessageBox.Show("Коренът не може да е отрицателно число", "Грешка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            tbInput.Text += " - ";
            dotUsed = false;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            if (tbInput.Text != string.Empty)
            {
                if (ValidatingRightOperators(tbInput))
                {
                    return;
                }
            }
            tbInput.Text += " + ";
            dotUsed = false;
            // Set focus to control
            tbInput.Focus();
            // Set text-selection to end
            tbInput.SelectionStart = tbInput.Text.Length == 0 ? 0 : tbInput.Text.Length - 1;
            // Set text-selection length (in your case 0 = no blue text)
            tbInput.SelectionLength = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbInput.Clear();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (tbInput.Text != string.Empty)
            {
                string text = tbInput.Text;

                List<string> separated = text.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries).ToList();
                if (separated[0] == "")
                {
                    separated.RemoveAt(0);
                }
                if ((separated[0]) == "+" || separated[0] == "-")
                {
                    if (true)
                    {

                    }
                    separated[0] += separated[1];
                    separated.RemoveAt(1);
                }
                if (separated[separated.Count - 1] == "" && (separated[separated.Count - 2] == "+" || separated[separated.Count - 2] == "-" || separated[separated.Count - 2] == "/" || separated[separated.Count - 2] == "*" || separated[separated.Count - 2] == "^"))
                {
                    if (lblResult.Text != "Output")
                    {
                        separated.RemoveAt(separated.Count - 1);
                        separated.Add(lblResult.Text);
                    }
                    else
                    {
                        separated.RemoveAt(separated.Count - 1);
                        separated.RemoveAt(separated.Count - 1);
                    }

                }

                while (separated.Contains("*") || separated.Contains("/") || separated.Contains("+") || separated.Contains("-") || separated.Contains("^") || separated.Contains("√"))
                {
                    if (separated.Contains("√"))
                    {

                        int indexOfRoot = separated.IndexOf("√");
                        if (separated[indexOfRoot + 1] == "" && separated[indexOfRoot + 2] == "√")
                        {
                            indexOfRoot = separated.LastIndexOf("√");
                        }
                        double number = Math.Sqrt(double.Parse(separated[indexOfRoot + 1]));
                        separated.Insert(indexOfRoot + 2, number.ToString());
                        if (indexOfRoot == 0)
                        {

                            separated.RemoveRange(indexOfRoot, 2);
                        }
                        else if (separated[indexOfRoot - 1] == "-")
                        {
                            separated.RemoveRange(indexOfRoot, 2);
                        }
                        else
                        {

                            separated.RemoveRange(indexOfRoot - 1, 3);
                        }

                    }
                    else if (separated.Contains("*"))
                    {
                        int indexOfStar = separated.IndexOf("*");
                        double number = double.Parse(separated[indexOfStar - 1]) * double.Parse(separated[indexOfStar + 1]);
                        separated.Insert(indexOfStar + 2, number.ToString());
                        separated.RemoveRange(indexOfStar - 1, 3);
                    }
                    else if (separated.Contains("/"))
                    {
                        int indexOfDivide = separated.IndexOf("/");

                        double number = double.Parse(separated[indexOfDivide - 1]) / double.Parse(separated[indexOfDivide + 1]);
                        separated.Insert(indexOfDivide + 2, number.ToString());
                        separated.RemoveRange(indexOfDivide - 1, 3);
                    }
                    else if (separated.Contains("+"))
                    {
                        int indexOfPlus = separated.IndexOf("+");
                        double number = double.Parse(separated[indexOfPlus - 1]) + double.Parse(separated[indexOfPlus + 1]);
                        separated.Insert(indexOfPlus + 2, number.ToString());
                        separated.RemoveRange(indexOfPlus - 1, 3);
                    }
                    else if (separated.Contains("-"))
                    {
                        if (separated.Count == 2)
                        {
                            separated[0] += separated[1];
                            double number = double.Parse(separated[0]);
                            separated.RemoveAt(1);
                            lblResult.Text = $"{number}";
                        }
                        else
                        {
                            int indexOfMinus = separated.IndexOf("-");
                            double number = double.Parse(separated[indexOfMinus - 1]) - double.Parse(separated[indexOfMinus + 1]);
                            separated.Insert(indexOfMinus + 2, number.ToString());
                            separated.RemoveRange(indexOfMinus - 1, 3);
                        }

                    }
                    else if (separated.Contains("^"))
                    {
                        int indexOfPower = separated.IndexOf("^");
                        double number = Math.Pow(double.Parse(separated[indexOfPower - 1]), double.Parse(separated[indexOfPower + 1]));
                        separated.Insert(indexOfPower + 2, number.ToString());
                        separated.RemoveRange(indexOfPower - 1, 3);
                    }



                }

                lblResult.Text = $"{double.Parse(separated[0]):f2}";
                tbInput.Clear();
            }

        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Length > 1)
            {
                if (tbInput.Text[tbInput.Text.Length - 1] == ' ')
                {
                    tbInput.Text = tbInput.Text.Substring(0, tbInput.Text.Length - 3);
                }
                else
                {
                    tbInput.Text = tbInput.Text.Substring(0, tbInput.Text.Length - 1);
                }
            }
            else
            {
                tbInput.Text = string.Empty;
            }


        }

        //Methods
        static bool WrongSymbolsUnderSqrt(TextBox tbInput)
        {

            if (tbInput.Text[tbInput.Text.Length - 2] == '√')
            {
                MessageBox.Show("Неправилен символ", "Грешка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        public static void MessageBoxWarninDivideMultiplyPower()
        {
            MessageBox.Show("Не може уравнението да започва с този знак", "Грешка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MessageBoxCantTwoOperators()
        {
            MessageBox.Show("Не може два оператора един до друг", "Грешка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ValidatingRightOperators(TextBox tbInput)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            if (tbInput.Text[tbInput.Text.Length - 1] == ' ' && (tbInput.Text[tbInput.Text.Length - 2] == '*'
                || tbInput.Text[tbInput.Text.Length - 2] == '/'
                || tbInput.Text[tbInput.Text.Length - 2] == '+'
                || tbInput.Text[tbInput.Text.Length - 2] == '-'
                || tbInput.Text[tbInput.Text.Length - 2] == '^'

                ))
            {
                MessageBoxCantTwoOperators();
                return true;

            }
            return false;
        }
    }
}
