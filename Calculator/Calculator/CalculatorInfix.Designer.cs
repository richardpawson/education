namespace Calculator
{
    partial class CalculatorInfix
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.equals = new System.Windows.Forms.Button();
            this.openBracket = new System.Windows.Forms.Button();
            this.closeBracket = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // equals
            // 
            this.equals.Location = new System.Drawing.Point(226, 306);
            this.equals.Margin = new System.Windows.Forms.Padding(1);
            this.equals.Name = "equals";
            this.equals.Size = new System.Drawing.Size(71, 32);
            this.equals.TabIndex = 8;
            this.equals.Text = "=";
            this.equals.UseVisualStyleBackColor = true;
            this.equals.Click += new System.EventHandler(this.equals_click);
            // 
            // openBracket
            // 
            this.openBracket.Location = new System.Drawing.Point(27, 207);
            this.openBracket.Name = "openBracket";
            this.openBracket.Size = new System.Drawing.Size(37, 34);
            this.openBracket.TabIndex = 24;
            this.openBracket.Text = "(";
            this.openBracket.UseVisualStyleBackColor = true;
            this.openBracket.Click += new System.EventHandler(this.openBracket_Click);
            // 
            // closeBracket
            // 
            this.closeBracket.Location = new System.Drawing.Point(27, 255);
            this.closeBracket.Name = "closeBracket";
            this.closeBracket.Size = new System.Drawing.Size(37, 34);
            this.closeBracket.TabIndex = 25;
            this.closeBracket.Text = ")";
            this.closeBracket.UseVisualStyleBackColor = true;
            this.closeBracket.Click += new System.EventHandler(this.closeBracket_Click);
            // 
            // CalculatorInfix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(324, 376);
            this.Controls.Add(this.closeBracket);
            this.Controls.Add(this.openBracket);
            this.Controls.Add(this.equals);
            this.Name = "CalculatorInfix";
            this.Text = "Infix Calculator";
            this.Controls.SetChildIndex(this.equals, 0);
            this.Controls.SetChildIndex(this.button7, 0);
            this.Controls.SetChildIndex(this.button8, 0);
            this.Controls.SetChildIndex(this.button9, 0);
            this.Controls.SetChildIndex(this.numericDisplay, 0);
            this.Controls.SetChildIndex(this.plus, 0);
            this.Controls.SetChildIndex(this.expression, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.button6, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button0, 0);
            this.Controls.SetChildIndex(this.decimalPoint, 0);
            this.Controls.SetChildIndex(this.minus, 0);
            this.Controls.SetChildIndex(this.times, 0);
            this.Controls.SetChildIndex(this.divide, 0);
            this.Controls.SetChildIndex(this.clearAll, 0);
            this.Controls.SetChildIndex(this.clearEntry, 0);
            this.Controls.SetChildIndex(this.openBracket, 0);
            this.Controls.SetChildIndex(this.closeBracket, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button equals;
        private System.Windows.Forms.Button openBracket;
        private System.Windows.Forms.Button closeBracket;
    }
}

