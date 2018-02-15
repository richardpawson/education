namespace OOPDraw
{
    partial class Form1
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Next = new System.Windows.Forms.Button();
            this.Previous = new System.Windows.Forms.Button();
            this.Function = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(73, 76);
            this.Next.Margin = new System.Windows.Forms.Padding(1);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(54, 44);
            this.Next.TabIndex = 1;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Previous
            // 
            this.Previous.Location = new System.Drawing.Point(8, 76);
            this.Previous.Margin = new System.Windows.Forms.Padding(1);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(52, 44);
            this.Previous.TabIndex = 10;
            this.Previous.Text = "Prev";
            this.Previous.UseVisualStyleBackColor = true;
            this.Previous.Click += new System.EventHandler(this.Previous_click);
            // 
            // Function
            // 
            this.Function.FormattingEnabled = true;
            this.Function.Items.AddRange(new object[] {
            "New Rectangle",
            "New Triangle",
            "New House",
            "New Circle",
            "Move",
            "Resize"});
            this.Function.Location = new System.Drawing.Point(8, 32);
            this.Function.Margin = new System.Windows.Forms.Padding(1);
            this.Function.Name = "Function";
            this.Function.Size = new System.Drawing.Size(114, 21);
            this.Function.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Function:";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(8, 136);
            this.Clear.Margin = new System.Windows.Forms.Padding(1);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(52, 41);
            this.Clear.TabIndex = 16;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(722, 445);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Function);
            this.Controls.Add(this.Previous);
            this.Controls.Add(this.Next);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.ComboBox Function;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Clear;
    }
}

