namespace GUI
{
    partial class OldForm
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
            this.Messages = new System.Windows.Forms.RichTextBox();
            this.NewTrainingGame = new System.Windows.Forms.Button();
            this.NewRandomGame = new System.Windows.Forms.Button();
            this.FireMissile = new System.Windows.Forms.Button();
            this.FireBomb = new System.Windows.Forms.Button();
            this.Row = new System.Windows.Forms.ComboBox();
            this.Column = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.Location = new System.Drawing.Point(64, 52);
            this.Grid.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(869, 804);
            this.Grid.TabIndex = 0;
            this.Grid.TabStop = false;
            // 
            // Messages
            // 
            this.Messages.Location = new System.Drawing.Point(64, 899);
            this.Messages.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(863, 166);
            this.Messages.TabIndex = 1;
            this.Messages.Text = "";
            // 
            // NewTrainingGame
            // 
            this.NewTrainingGame.Location = new System.Drawing.Point(1373, 52);
            this.NewTrainingGame.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.NewTrainingGame.Name = "NewTrainingGame";
            this.NewTrainingGame.Size = new System.Drawing.Size(224, 105);
            this.NewTrainingGame.TabIndex = 2;
            this.NewTrainingGame.Text = "New Training Game";
            this.NewTrainingGame.UseVisualStyleBackColor = true;
            this.NewTrainingGame.Click += new System.EventHandler(this.NewTrainingGame_Click);
            // 
            // NewRandomGame
            // 
            this.NewRandomGame.Location = new System.Drawing.Point(1373, 205);
            this.NewRandomGame.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.NewRandomGame.Name = "NewRandomGame";
            this.NewRandomGame.Size = new System.Drawing.Size(224, 103);
            this.NewRandomGame.TabIndex = 3;
            this.NewRandomGame.Text = "New Random Game";
            this.NewRandomGame.UseVisualStyleBackColor = true;
            // 
            // FireMissile
            // 
            this.FireMissile.Location = new System.Drawing.Point(1373, 799);
            this.FireMissile.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.FireMissile.Name = "FireMissile";
            this.FireMissile.Size = new System.Drawing.Size(224, 93);
            this.FireMissile.TabIndex = 4;
            this.FireMissile.Text = "Fire Missile";
            this.FireMissile.UseVisualStyleBackColor = true;
            this.FireMissile.Click += new System.EventHandler(this.FireMissile_Click);
            // 
            // FireBomb
            // 
            this.FireBomb.Location = new System.Drawing.Point(1373, 935);
            this.FireBomb.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.FireBomb.Name = "FireBomb";
            this.FireBomb.Size = new System.Drawing.Size(224, 93);
            this.FireBomb.TabIndex = 5;
            this.FireBomb.Text = "Fire Bomb";
            this.FireBomb.UseVisualStyleBackColor = true;
            this.FireBomb.Click += new System.EventHandler(this.FireBomb_Click);
            // 
            // Row
            // 
            this.Row.FormattingEnabled = true;
            this.Row.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.Row.Location = new System.Drawing.Point(1373, 494);
            this.Row.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Row.Name = "Row";
            this.Row.Size = new System.Drawing.Size(217, 39);
            this.Row.TabIndex = 6;
            // 
            // Column
            // 
            this.Column.FormattingEnabled = true;
            this.Column.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.Column.Location = new System.Drawing.Point(1373, 637);
            this.Column.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Column.Name = "Column";
            this.Column.Size = new System.Drawing.Size(217, 39);
            this.Column.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1373, 432);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Row";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1373, 591);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "Column";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1947, 1292);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Column);
            this.Controls.Add(this.Row);
            this.Controls.Add(this.FireBomb);
            this.Controls.Add(this.FireMissile);
            this.Controls.Add(this.NewRandomGame);
            this.Controls.Add(this.NewTrainingGame);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.Grid);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Battleships";
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Grid;
        private System.Windows.Forms.RichTextBox Messages;
        private System.Windows.Forms.Button NewTrainingGame;
        private System.Windows.Forms.Button NewRandomGame;
        private System.Windows.Forms.Button FireMissile;
        private System.Windows.Forms.Button FireBomb;
        private System.Windows.Forms.ComboBox Row;
        private System.Windows.Forms.ComboBox Column;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

