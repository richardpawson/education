namespace Trees
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
            this.button1 = new System.Windows.Forms.Button();
            this.angle_min = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.branch_min = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.level = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.angle_max = new System.Windows.Forms.NumericUpDown();
            this.branch_max = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.size = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.angle_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branch_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angle_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branch_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 517);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 110);
            this.button1.TabIndex = 0;
            this.button1.Text = "Regular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Regular_Click);
            // 
            // angle_min
            // 
            this.angle_min.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.angle_min.Location = new System.Drawing.Point(99, 66);
            this.angle_min.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.angle_min.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.angle_min.Name = "angle_min";
            this.angle_min.Size = new System.Drawing.Size(120, 38);
            this.angle_min.TabIndex = 1;
            this.angle_min.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.angle_min.ValueChanged += new System.EventHandler(this.branchMin);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Branch Angle (degrees)";
            // 
            // branch_min
            // 
            this.branch_min.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.branch_min.Location = new System.Drawing.Point(99, 196);
            this.branch_min.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.branch_min.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.branch_min.Name = "branch_min";
            this.branch_min.Size = new System.Drawing.Size(120, 38);
            this.branch_min.TabIndex = 20;
            this.branch_min.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.branch_min.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Branch Length (%)";
            // 
            // level
            // 
            this.level.Location = new System.Drawing.Point(99, 305);
            this.level.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.level.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(120, 38);
            this.level.TabIndex = 5;
            this.level.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.level.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Level";
            // 
            // angle_max
            // 
            this.angle_max.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.angle_max.Location = new System.Drawing.Point(266, 66);
            this.angle_max.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.angle_max.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.angle_max.Name = "angle_max";
            this.angle_max.Size = new System.Drawing.Size(120, 38);
            this.angle_max.TabIndex = 7;
            this.angle_max.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.angle_max.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // branch_max
            // 
            this.branch_max.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.branch_max.Location = new System.Drawing.Point(266, 196);
            this.branch_max.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.branch_max.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.branch_max.Name = "branch_max";
            this.branch_max.Size = new System.Drawing.Size(120, 38);
            this.branch_max.TabIndex = 8;
            this.branch_max.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.branch_max.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 529);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 8);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(252, 517);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 110);
            this.button3.TabIndex = 10;
            this.button3.Text = "Variable";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Variable_Click);
            // 
            // size
            // 
            this.size.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.size.Location = new System.Drawing.Point(99, 422);
            this.size.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.size.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(120, 38);
            this.size.TabIndex = 21;
            this.size.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 32);
            this.label4.TabIndex = 22;
            this.label4.Text = "Size";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 795);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.size);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.branch_max);
            this.Controls.Add(this.angle_max);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.level);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.branch_min);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.angle_min);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Regular Tree";
            ((System.ComponentModel.ISupportInitialize)(this.angle_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branch_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angle_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branch_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown angle_min;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown branch_min;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown level;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown angle_max;
        private System.Windows.Forms.NumericUpDown branch_max;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown size;
        private System.Windows.Forms.Label label4;
    }
}

