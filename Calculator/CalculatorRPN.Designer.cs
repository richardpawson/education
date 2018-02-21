namespace Calculator
{
    partial class CalculatorRPN
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.evaluate = new System.Windows.Forms.Button();
            this.enter = new System.Windows.Forms.Button();           
            // 
            // enter
            // 
            this.enter.Location = new System.Drawing.Point(156, 303);
            this.enter.Margin = new System.Windows.Forms.Padding(1);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(64, 32);
            this.enter.TabIndex = 3;
            this.enter.Text = "enter";
            this.enter.UseVisualStyleBackColor = true;
            this.enter.Click += new System.EventHandler(this.enter_Click);
            // 
            // evaluate
            // 
            this.evaluate.Location = new System.Drawing.Point(226, 303);
            this.evaluate.Margin = new System.Windows.Forms.Padding(1);
            this.evaluate.Name = "evaluate";
            this.evaluate.Size = new System.Drawing.Size(71, 32);
            this.evaluate.TabIndex = 8;
            this.evaluate.Text = "evaluate";
            this.evaluate.UseVisualStyleBackColor = true;
            this.evaluate.Click += new System.EventHandler(this.evaluate_Click);
            // 
            // RPN
            // 
            this.Controls.Add(this.evaluate);
            this.Controls.Add(this.enter);
            this.Name = "RPN";
            this.Text = "RPN Calculator";
        }
        #endregion

        private System.Windows.Forms.Button enter;
        private System.Windows.Forms.Button evaluate;
    }
}

