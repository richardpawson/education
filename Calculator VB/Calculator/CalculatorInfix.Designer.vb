
Namespace Calculator

    Partial Class CalculatorInfix

        Private Sub InitializeComponent()
            Me.equals = New System.Windows.Forms.Button()
            Me.openBracket = New System.Windows.Forms.Button()
            Me.closeBracket = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            Me.equals.Location = New System.Drawing.Point(226, 306)
            Me.equals.Margin = New System.Windows.Forms.Padding(1)
            Me.equals.Name = "equals"
            Me.equals.Size = New System.Drawing.Size(71, 32)
            Me.equals.TabIndex = 8
            Me.equals.Text = "="
            Me.equals.UseVisualStyleBackColor = True
            'Me.equals.Click += New System.EventHandler(Me.equals_click)
            Me.openBracket.Location = New System.Drawing.Point(27, 207)
            Me.openBracket.Name = "openBracket"
            Me.openBracket.Size = New System.Drawing.Size(37, 34)
            Me.openBracket.TabIndex = 24
            Me.openBracket.Text = "("
            Me.openBracket.UseVisualStyleBackColor = True
            'Me.openBracket.Click += New System.EventHandler(Me.openBracket_Click)
            Me.closeBracket.Location = New System.Drawing.Point(27, 255)
            Me.closeBracket.Name = "closeBracket"
            Me.closeBracket.Size = New System.Drawing.Size(37, 34)
            Me.closeBracket.TabIndex = 25
            Me.closeBracket.Text = ")"
            Me.closeBracket.UseVisualStyleBackColor = True
            'Me.closeBracket.Click += New System.EventHandler(Me.closeBracket_Click)
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.ClientSize = New System.Drawing.Size(324, 376)
            Me.Controls.Add(Me.closeBracket)
            Me.Controls.Add(Me.openBracket)
            Me.Controls.Add(Me.equals)
            Me.Name = "CalculatorInfix"
            Me.Text = "Infix Calculator"
            Me.Controls.SetChildIndex(Me.equals, 0)
            Me.Controls.SetChildIndex(Me.button7, 0)
            Me.Controls.SetChildIndex(Me.button8, 0)
            Me.Controls.SetChildIndex(Me.button9, 0)
            Me.Controls.SetChildIndex(Me.numericDisplay, 0)
            Me.Controls.SetChildIndex(Me.plus, 0)
            Me.Controls.SetChildIndex(Me.expression, 0)
            Me.Controls.SetChildIndex(Me.button4, 0)
            Me.Controls.SetChildIndex(Me.button5, 0)
            Me.Controls.SetChildIndex(Me.button6, 0)
            Me.Controls.SetChildIndex(Me.button1, 0)
            Me.Controls.SetChildIndex(Me.button2, 0)
            Me.Controls.SetChildIndex(Me.button3, 0)
            Me.Controls.SetChildIndex(Me.button0, 0)
            Me.Controls.SetChildIndex(Me.decimalPoint, 0)
            Me.Controls.SetChildIndex(Me.minus, 0)
            Me.Controls.SetChildIndex(Me.times, 0)
            Me.Controls.SetChildIndex(Me.divide, 0)
            Me.Controls.SetChildIndex(Me.clearAll, 0)
            Me.Controls.SetChildIndex(Me.clearEntry, 0)
            Me.Controls.SetChildIndex(Me.openBracket, 0)
            Me.Controls.SetChildIndex(Me.closeBracket, 0)
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Friend WithEvents equals As System.Windows.Forms.Button

        Friend WithEvents openBracket As System.Windows.Forms.Button

        Friend WithEvents closeBracket As System.Windows.Forms.Button
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by Refactoring Essentials.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
