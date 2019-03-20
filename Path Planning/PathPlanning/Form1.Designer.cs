using Graph;
using System;

namespace PathPlanning
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
            this.Grid = new System.Windows.Forms.PictureBox();
            this.ScenarioSelector = new System.Windows.Forms.ComboBox();
            this.ScenarioLabel = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.NumericUpDown();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.visitedCount = new System.Windows.Forms.TextBox();
            this.VisitedCountLabel = new System.Windows.Forms.Label();
            this.pathLength = new System.Windows.Forms.TextBox();
            this.PathLengthLabel = new System.Windows.Forms.Label();
            this.algorithmSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.algorithmLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.Location = new System.Drawing.Point(74, 71);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(1423, 1308);
            this.Grid.TabIndex = 0;
            this.Grid.TabStop = false;
            this.Grid.Click += new System.EventHandler(this.Grid_Click);
            // 
            // ScenarioSelector
            // 
            this.ScenarioSelector.DataSource = ScenarioList();
            this.ScenarioSelector.FormattingEnabled = true;
            this.ScenarioSelector.Location = new System.Drawing.Point(1852, 84);
            this.ScenarioSelector.Name = "ScenarioSelector";
            this.ScenarioSelector.Size = new System.Drawing.Size(236, 39);
            this.ScenarioSelector.TabIndex = 1;
            this.ScenarioSelector.SelectedIndexChanged += new System.EventHandler(this.ScenarioSelector_SelectedIndexChanged);
            // 
            // ScenarioLabel
            // 
            this.ScenarioLabel.AutoSize = true;
            this.ScenarioLabel.Location = new System.Drawing.Point(1660, 84);
            this.ScenarioLabel.Name = "ScenarioLabel";
            this.ScenarioLabel.Size = new System.Drawing.Size(128, 32);
            this.ScenarioLabel.TabIndex = 2;
            this.ScenarioLabel.Text = "Scenario";
            // 
            // Speed
            // 
            this.Speed.Location = new System.Drawing.Point(1951, 358);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(120, 38);
            this.Speed.TabIndex = 3;
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(1945, 283);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(88, 32);
            this.SpeedLabel.TabIndex = 4;
            this.SpeedLabel.Text = "Delay";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(1677, 283);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(160, 113);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // visitedCount
            // 
            this.visitedCount.Location = new System.Drawing.Point(1852, 579);
            this.visitedCount.Name = "visitedCount";
            this.visitedCount.Size = new System.Drawing.Size(270, 38);
            this.visitedCount.TabIndex = 6;
            // 
            // VisitedCountLabel
            // 
            this.VisitedCountLabel.AutoSize = true;
            this.VisitedCountLabel.Location = new System.Drawing.Point(1634, 579);
            this.VisitedCountLabel.Name = "VisitedCountLabel";
            this.VisitedCountLabel.Size = new System.Drawing.Size(179, 32);
            this.VisitedCountLabel.TabIndex = 7;
            this.VisitedCountLabel.Text = "Visited count";
            // 
            // pathLength
            // 
            this.pathLength.Location = new System.Drawing.Point(1852, 708);
            this.pathLength.Name = "pathLength";
            this.pathLength.Size = new System.Drawing.Size(270, 38);
            this.pathLength.TabIndex = 8;
            // 
            // PathLengthLabel
            // 
            this.PathLengthLabel.AutoSize = true;
            this.PathLengthLabel.Location = new System.Drawing.Point(1644, 714);
            this.PathLengthLabel.Name = "PathLengthLabel";
            this.PathLengthLabel.Size = new System.Drawing.Size(169, 32);
            this.PathLengthLabel.TabIndex = 9;
            this.PathLengthLabel.Text = "Path Length";
            // 
            // algorithmSelector
            // 
            this.algorithmSelector.DataSource = new Graph.Algorithms[] {
        Graph.Algorithms.Dijkstra,
        Graph.Algorithms.Optimistic,
        Graph.Algorithms.AStar};
            this.algorithmSelector.FormattingEnabled = true;
            this.algorithmSelector.Location = new System.Drawing.Point(1852, 186);
            this.algorithmSelector.Name = "algorithmSelector";
            this.algorithmSelector.Size = new System.Drawing.Size(236, 39);
            this.algorithmSelector.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 1450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "label1";
            // 
            // algorithmLabel
            // 
            this.algorithmLabel.AutoSize = true;
            this.algorithmLabel.Location = new System.Drawing.Point(1650, 193);
            this.algorithmLabel.Name = "algorithmLabel";
            this.algorithmLabel.Size = new System.Drawing.Size(136, 32);
            this.algorithmLabel.TabIndex = 12;
            this.algorithmLabel.Text = "Algorithm";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(1677, 448);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(160, 108);
            this.resetButton.TabIndex = 13;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2250, 1475);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.algorithmLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.algorithmSelector);
            this.Controls.Add(this.PathLengthLabel);
            this.Controls.Add(this.pathLength);
            this.Controls.Add(this.VisitedCountLabel);
            this.Controls.Add(this.visitedCount);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.ScenarioLabel);
            this.Controls.Add(this.ScenarioSelector);
            this.Controls.Add(this.Grid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Grid;
        private System.Windows.Forms.ComboBox ScenarioSelector;
        private System.Windows.Forms.Label ScenarioLabel;
        private System.Windows.Forms.NumericUpDown Speed;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox visitedCount;
        private System.Windows.Forms.Label VisitedCountLabel;
        private System.Windows.Forms.TextBox pathLength;
        private System.Windows.Forms.Label PathLengthLabel;
        private System.Windows.Forms.ComboBox algorithmSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label algorithmLabel;
        private System.Windows.Forms.Button resetButton;
    }
}

