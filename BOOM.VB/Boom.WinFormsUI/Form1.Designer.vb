
Namespace Boom.WinFormsUI
	Partial Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.pictureBox1 = New System.Windows.Forms.PictureBox()
			Me.button1 = New System.Windows.Forms.Button()
			Me.comboBox1 = New System.Windows.Forms.ComboBox()
			Me.comboBox2 = New System.Windows.Forms.ComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.button2 = New System.Windows.Forms.Button()
			Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
			Me.button3 = New System.Windows.Forms.Button()
			Me.button4 = New System.Windows.Forms.Button()
			DirectCast(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' pictureBox1
			' 
			Me.pictureBox1.Location = New System.Drawing.Point(60, 49)
			Me.pictureBox1.Name = "pictureBox1"
			Me.pictureBox1.Size = New System.Drawing.Size(869, 804)
			Me.pictureBox1.TabIndex = 0
			Me.pictureBox1.TabStop = False
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(1170, 59)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(207, 99)
			Me.button1.TabIndex = 1
			Me.button1.Text = "New Training Game"
            Me.button1.UseVisualStyleBackColor = True
            AddHandler button1.Click, AddressOf Me.button1_Click
            ' 
            ' comboBox1
            ' 
            Me.comboBox1.FormattingEnabled = True
			Me.comboBox1.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", _
				"6", "7", "8", "9"})
			Me.comboBox1.Location = New System.Drawing.Point(1170, 614)
			Me.comboBox1.Name = "comboBox1"
			Me.comboBox1.Size = New System.Drawing.Size(207, 39)
			Me.comboBox1.TabIndex = 2
            ' 
            ' comboBox2
            ' 
            Me.comboBox2.FormattingEnabled = True
			Me.comboBox2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", _
				"6", "7", "8", "9"})
			Me.comboBox2.Location = New System.Drawing.Point(1170, 484)
			Me.comboBox2.Name = "comboBox2"
			Me.comboBox2.Size = New System.Drawing.Size(207, 39)
			Me.comboBox2.TabIndex = 3
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(1164, 552)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(71, 32)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Row"
            ' 
            ' label2
            ' 
            Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(1164, 413)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(58, 32)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Col"
            ' 
            ' button2
            ' 
            Me.button2.Location = New System.Drawing.Point(1170, 691)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(207, 85)
			Me.button2.TabIndex = 6
			Me.button2.Text = "Fire Missile"
			Me.button2.UseVisualStyleBackColor = True
            AddHandler button2.Click, AddressOf Me.button2_Click
            ' 
            ' richTextBox1
            ' 
            Me.richTextBox1.Location = New System.Drawing.Point(60, 893)
			Me.richTextBox1.Name = "richTextBox1"
			Me.richTextBox1.Size = New System.Drawing.Size(869, 133)
			Me.richTextBox1.TabIndex = 7
			Me.richTextBox1.Text = ""
			' 
			' button3
			' 
			Me.button3.Location = New System.Drawing.Point(1170, 211)
			Me.button3.Name = "button3"
			Me.button3.Size = New System.Drawing.Size(207, 97)
			Me.button3.TabIndex = 8
			Me.button3.Text = "New Random Game"
			Me.button3.UseVisualStyleBackColor = True
            AddHandler button3.Click, AddressOf Me.button3_Click
            ' 
            ' button4
            ' 
            Me.button4.Location = New System.Drawing.Point(1170, 829)
			Me.button4.Name = "button4"
			Me.button4.Size = New System.Drawing.Size(207, 73)
			Me.button4.TabIndex = 9
			Me.button4.Text = "Fire Bomb"
			Me.button4.UseVisualStyleBackColor = True
            AddHandler button4.Click, AddressOf Me.button4_Click            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(16F, 31F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1745, 1096)
			Me.Controls.Add(Me.button4)
			Me.Controls.Add(Me.button3)
			Me.Controls.Add(Me.richTextBox1)
			Me.Controls.Add(Me.button2)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.comboBox2)
			Me.Controls.Add(Me.comboBox1)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.pictureBox1)
			Me.Name = "Form1"
			Me.Text = "BOOM - Battleships with OO Makeover"
            DirectCast(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private pictureBox1 As System.Windows.Forms.PictureBox
		Private button1 As System.Windows.Forms.Button
		Private comboBox1 As System.Windows.Forms.ComboBox
		Private comboBox2 As System.Windows.Forms.ComboBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private button2 As System.Windows.Forms.Button
		Private richTextBox1 As System.Windows.Forms.RichTextBox
		Private button3 As System.Windows.Forms.Button
		Private button4 As System.Windows.Forms.Button
	End Class
End Namespace


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
