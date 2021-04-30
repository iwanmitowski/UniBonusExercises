using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorOOP
{
    //The calculator performs operations in the order of entry, not by algebra priority!
    public partial class Calculator : Form
    {
        double result;
        string @operator;
        string previousOperator;
        bool isOperator;

        double memory;
        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lblM.Text = string.Empty;
            lblEquation.Text = string.Empty;

            for (int i = 0; i < this.Controls.Count; i++)
            {
                var control = this.Controls[i];
                if (control is Button && control.Text.Contains("button"))
                {
                    control.Text = control.Text[control.Text.Length - 1].ToString();
                }
            }
        }

        private void ButtonNumbers_Click(object sender, EventArgs e)
        {
            if ((tbResult.Text == "0") || (isOperator))
            {
                tbResult.Clear();
            }

            isOperator = false;

            Button b = (Button)sender;
            if (b.Text == ".")
            {
                if (!tbResult.Text.Contains("."))
                {
                    tbResult.Text += b.Text;
                }
            }
            else
            {
                tbResult.Text += b.Text;
            }
        }

        private void Operators_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (result != 0)
            {
                previousOperator = @operator;
                @operator = b.Text;

                if (isOperator == true)
                {
                    if (@operator == "√")
                    {
                        Sqrt();
                        return;
                    }
                    lblEquation.Text = result + " " + @operator;
                }
                else
                {
                    buttonResult.PerformClick();
                    isOperator = true;
                    lblEquation.Text = result + " " + @operator;
                }
            }
            else
            {
                @operator = b.Text;

                if (tbResult.Text == string.Empty)
                {
                    if (@operator != "√" || @operator != "/" || @operator != "*")
                    {
                        tbResult.Text += @operator;
                        return;
                    }
                }

                isOperator = true;

                if (@operator == "√")
                {
                    Sqrt();
                    return;
                }
                result = double.Parse(tbResult.Text);
                lblEquation.Text = result + " " + @operator;
            }
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            lblEquation.Text = string.Empty;

            try
            {
                double number = double.Parse(tbResult.Text);
                switch (@operator)
                {
                    case "+":
                        tbResult.Text = (result + number).ToString();
                        break;
                    case "-":
                        tbResult.Text = (result - number).ToString();
                        break;
                    case "*":
                        tbResult.Text = (result * number).ToString();
                        break;
                    case "/":
                        if (number == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        tbResult.Text = Math.Round(result / number, 6).ToString();
                        break;
                    case "√":
                        switch (previousOperator)
                        {
                            case "+":
                                tbResult.Text = (result += Math.Round(Math.Sqrt(number), 6)).ToString();
                                break;
                            case "-":
                                tbResult.Text = (result -= Math.Round(Math.Sqrt(number), 6)).ToString();
                                break;
                            case "*":
                                tbResult.Text = (result *= Math.Round(Math.Sqrt(number), 6)).ToString();
                                break;
                            case "/":
                                if (tbResult.Text == "0")
                                {
                                    throw new DivideByZeroException();
                                }
                                tbResult.Text = (result /= Math.Round(Math.Sqrt(number), 6)).ToString();
                                break;
                        }
                        break;
                    default:
                        break;
                }

                result = number;
                @operator = "";
                isOperator = true;
            }
            catch (DivideByZeroException dex)
            {
                MessageBox.Show("Division by 0",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                buttonClear.PerformClick();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter something",
                    "Warning!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                buttonClear.PerformClick();
                return;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            tbResult.Clear();
            result = 0;
            lblEquation.Text = "";
        }

        private void buttonMResult_Click(object sender, EventArgs e)
        {
            tbResult.Text = memory.ToString();
            memory = 0;
            lblM.Text = string.Empty;
        }

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            buttonResult.PerformClick();
            memory += result;
            lblM.Text = "M";
        }

        private void buttonMMinus_Click(object sender, EventArgs e)
        {
            ;
            buttonResult.PerformClick();
            memory -= result;
            lblM.Text = "M";
        }


        private void Sqrt()
        {
            if (tbResult.Text.Contains("-"))
            {
                MessageBox.Show("The square root of a negative number does not exist!",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                buttonClear.PerformClick();

                return;
            }

            result += Math.Round(Math.Sqrt(double.Parse(tbResult.Text)), 6);
            lblEquation.Text = @operator + tbResult.Text;
            tbResult.Text = result.ToString();
        }

        //No idea why it's not working
        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0":
                    button10.PerformClick();
                    break;
                case "1":
                    button1.PerformClick();
                    break;
                case "2":
                    button2.PerformClick();
                    break;
                case "3":
                    button3.PerformClick();
                    break;
                case "4":
                    button4.PerformClick();
                    break;
                case "5":
                    button5.PerformClick();
                    break;
                case "6":
                    button6.PerformClick();
                    break;
                case "7":
                    button7.PerformClick();
                    break;
                case "8":
                    button8.PerformClick();
                    break;
                case "9":
                    button9.PerformClick();
                    break;
                case ".":
                    buttonDot.PerformClick();
                    break;
                case "+":
                    buttonPlus.PerformClick();
                    break;
                case "-":
                    buttonMinus.PerformClick();
                    break;
                case "*":
                    buttonMult.PerformClick();
                    break;
                case "/":
                    buttonDivide.PerformClick();
                    break;
                case "=":
                    buttonResult.PerformClick();
                    break;
            }
        }
    }
}
