using System;

namespace Calculator
{
    public partial class RPNLayout : BaseLayout
    {
        public RPNLayout() : base()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, EventArgs e)
        {
            TransferNumberToExpression();
        } 

        private void evaluate_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayResult(Calculator.EvaluateTokensAsRPN());
            }
            catch (Exception)
            {
                numericDisplay.Text = "Error!";
            }
        }
      
    }
}
