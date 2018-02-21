namespace Calculator
{
    partial class InfixLayout
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.equals = new System.Windows.Forms.Button();
          // 
            // equals
            // 
            this.equals.Location = new System.Drawing.Point(223, 306);
            this.equals.Margin = new System.Windows.Forms.Padding(1);
            this.equals.Name = "equals";
            this.equals.Size = new System.Drawing.Size(71, 32);
            this.equals.TabIndex = 8;
            this.equals.Text = "=";
            this.equals.UseVisualStyleBackColor = true;
            this.equals.Click += new System.EventHandler(this.equals_click);
            // 
            // Infix
            // 
            this.Controls.Add(this.equals);
            this.Name = "Infix";
            this.Text = "Infix Calculator";
        }

        #endregion

        private System.Windows.Forms.Button equals;
    }
}

