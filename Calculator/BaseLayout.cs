using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class BaseLayout : Form
    {
        protected Core Calculator;

        public BaseLayout()
        {
            InitializeComponent();
            Calculator = new Core();
        }

        protected void TransferNumberToExpression()
        {
            if (numericDisplay.Text != "")
            {
                Calculator.AddNumberAsToken(numericDisplay.Text);
                UpdateExpressionDisplay();
                numericDisplay.Clear();
            }
        }

        protected void UpdateExpressionDisplay()
        {
            expression.Text = Calculator.TokensAsString();
        }

        protected void button0_Click(object sender, EventArgs e)
        {
            numericDisplay.AppendText("0");
        }
        protected void button1_Click(object sender, EventArgs e)
        {
            numericDisplay.AppendText("1");
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            numericDisplay.AppendText("2");
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            numericDisplay.AppendText("3");
        }

        protected void button4_Click(object sender, EventArgs e)
        {
            numericDisplay.AppendText("4");
        }

        protected void button5_Click(object sender, EventArgs e)
        {
            numericDisplay.AppendText("5");
        }

        protected void button6_Click(object sender, EventArgs e)
        {
            numericDisplay.AppendText("6");
        }
        protected void button7_Click(object sender, EventArgs e)
        {
            numericDisplay.AppendText("7");
        }
        protected void button8_Click(object sender, EventArgs e)
        {
            numericDisplay.AppendText("8");
        }

        protected void button9_Click(object sender, EventArgs e)
        {
            numericDisplay.AppendText("9");
        }

        protected void decimalPoint_Click(object sender, EventArgs e)
        {
            if (numericDisplay.Text == "")
            {
                numericDisplay.AppendText("0.");
            } else
            {
                numericDisplay.AppendText(".");
            }
            
        }

        protected void plus_Click(object sender, EventArgs e)
        {
            AddOperator('+');
        }

        protected void minus_Click(object sender, EventArgs e)
        {
            AddOperator('-');
        }

        protected void times_Click(object sender, EventArgs e)
        {
            AddOperator('*');
        }

        protected void divide_Click(object sender, EventArgs e)
        {
            AddOperator('/');
        }

        protected void AddOperator(char op)
        {
            TransferNumberToExpression();
            Calculator.AddSymbolAsToken(op);
            UpdateExpressionDisplay();
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            numericDisplay.Clear();
            Calculator.Clear();
            UpdateExpressionDisplay();
        }

        protected void clearEntry_Click(object sender, EventArgs e)
        {
            numericDisplay.Clear();
        }

        protected void DisplayResult(double result)
        {
            if (result > 0)
            {
                numericDisplay.Text = result.ToString();
            } else
            {
                numericDisplay.Text = "- ";
                numericDisplay.AppendText((-result).ToString());
            }
        }
    }
}
