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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.Modify = new System.Windows.Forms.ComboBox();
            this.Rectangle = new System.Windows.Forms.Button();
            this.TriangleShape = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.House = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Group = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 23);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 105);
            this.button2.TabIndex = 1;
            this.button2.Text = "Next";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Next_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 113);
            this.button1.TabIndex = 5;
            this.button1.Text = "Circle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Circle_Click);
            // 
            // previous
            // 
            this.previous.Location = new System.Drawing.Point(184, 23);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(145, 105);
            this.previous.TabIndex = 10;
            this.previous.Text = "Prev";
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Click += new System.EventHandler(this.Previous_click);
            // 
            // Modify
            // 
            this.Modify.FormattingEnabled = true;
            this.Modify.Items.AddRange(new object[] {
            "Move",
            "Resize",
            "Rotate"});
            this.Modify.Location = new System.Drawing.Point(36, 680);
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(178, 39);
            this.Modify.TabIndex = 11;
            // 
            // Rectangle
            // 
            this.Rectangle.Location = new System.Drawing.Point(184, 162);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(145, 98);
            this.Rectangle.TabIndex = 12;
            this.Rectangle.Text = "Rect";
            this.Rectangle.UseVisualStyleBackColor = true;
            this.Rectangle.Click += new System.EventHandler(this.Rectangle_Click);
            // 
            // TriangleShape
            // 
            this.TriangleShape.Location = new System.Drawing.Point(22, 162);
            this.TriangleShape.Name = "TriangleShape";
            this.TriangleShape.Size = new System.Drawing.Size(129, 98);
            this.TriangleShape.TabIndex = 13;
            this.TriangleShape.Text = "Triangle";
            this.TriangleShape.UseVisualStyleBackColor = true;
            this.TriangleShape.Click += new System.EventHandler(this.Triangle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 627);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "Function:";
            // 
            // House
            // 
            this.House.Location = new System.Drawing.Point(26, 468);
            this.House.Name = "House";
            this.House.Size = new System.Drawing.Size(125, 111);
            this.House.TabIndex = 15;
            this.House.Text = "House";
            this.House.UseVisualStyleBackColor = true;
            this.House.Click += new System.EventHandler(this.House_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(36, 831);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(115, 80);
            this.Clear.TabIndex = 16;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Group
            // 
            this.Group.Location = new System.Drawing.Point(184, 314);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(145, 113);
            this.Group.TabIndex = 17;
            this.Group.Text = "Group";
            this.Group.UseVisualStyleBackColor = true;
            this.Group.Click += new System.EventHandler(this.Group_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1968, 1512);
            this.Controls.Add(this.Group);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.House);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TriangleShape);
            this.Controls.Add(this.Rectangle);
            this.Controls.Add(this.Modify);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.ComboBox Modify;
        private System.Windows.Forms.Button Rectangle;
        private System.Windows.Forms.Button TriangleShape;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button House;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Group;
    }
}

