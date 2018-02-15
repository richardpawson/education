namespace GUI
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
            this.Grid.Location = new System.Drawing.Point(24, 22);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(326, 337);
            this.Grid.TabIndex = 0;
            this.Grid.TabStop = false;
            // 
            // Messages
            // 
            this.Messages.Location = new System.Drawing.Point(24, 377);
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(326, 72);
            this.Messages.TabIndex = 1;
            this.Messages.Text = "";
            // 
            // NewTrainingGame
            // 
            this.NewTrainingGame.Location = new System.Drawing.Point(515, 22);
            this.NewTrainingGame.Name = "NewTrainingGame";
            this.NewTrainingGame.Size = new System.Drawing.Size(84, 44);
            this.NewTrainingGame.TabIndex = 2;
            this.NewTrainingGame.Text = "New Training Game";
            this.NewTrainingGame.UseVisualStyleBackColor = true;
            this.NewTrainingGame.Click += new System.EventHandler(this.NewTrainingGame_Click);
            // 
            // NewRandomGame
            // 
            this.NewRandomGame.Location = new System.Drawing.Point(515, 86);
            this.NewRandomGame.Name = "NewRandomGame";
            this.NewRandomGame.Size = new System.Drawing.Size(84, 43);
            this.NewRandomGame.TabIndex = 3;
            this.NewRandomGame.Text = "New Random Game";
            this.NewRandomGame.UseVisualStyleBackColor = true;
            // 
            // FireMissile
            // 
            this.FireMissile.Location = new System.Drawing.Point(515, 335);
            this.FireMissile.Name = "FireMissile";
            this.FireMissile.Size = new System.Drawing.Size(84, 39);
            this.FireMissile.TabIndex = 4;
            this.FireMissile.Text = "Fire Missile";
            this.FireMissile.UseVisualStyleBackColor = true;
            this.FireMissile.Click += new System.EventHandler(this.FireMissile_Click);
            // 
            // FireBomb
            // 
            this.FireBomb.Location = new System.Drawing.Point(515, 392);
            this.FireBomb.Name = "FireBomb";
            this.FireBomb.Size = new System.Drawing.Size(84, 39);
            this.FireBomb.TabIndex = 5;
            this.FireBomb.Text = "Fire Bomb";
            this.FireBomb.UseVisualStyleBackColor = true;
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
            this.Row.Location = new System.Drawing.Point(515, 207);
            this.Row.Name = "Row";
            this.Row.Size = new System.Drawing.Size(84, 21);
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
            this.Column.Location = new System.Drawing.Point(515, 267);
            this.Column.Name = "Column";
            this.Column.Size = new System.Drawing.Size(84, 21);
            this.Column.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Row";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(515, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Column";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
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

