using System;

namespace Calculator
{
    public partial class InfixLayout : BaseLayout
    {
        public InfixLayout() : base()
        {
            InitializeComponent();

        }
        private void equals_click(object sender, EventArgs e)
        {
            TransferNumberToExpression();
            DisplayResult(Calculator.EvaluateTokensAsInfix());
        }      
    }
}
