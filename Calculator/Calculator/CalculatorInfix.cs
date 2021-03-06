﻿using System;

namespace Calculator
{
    public partial class CalculatorInfix : CalculatorBase
    {
        public CalculatorInfix() : base()
        {
            InitializeComponent();

        }
        private void equals_click(object sender, EventArgs e)
        {
            TransferNumberToExpression();
            try
            {
                DisplayResult(Calculator.EvaluateTokensAsInfix());
            }
            catch (Exception)
            {
                numericDisplay.Text = "Error!";
            }
        }

        private void openBracket_Click(object sender, EventArgs e)
        {
            AddOperator('(');
        }

        private void closeBracket_Click(object sender, EventArgs e)
        {
            AddOperator(')');
        }
    }
}
