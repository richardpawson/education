
Namespace Calculator

    Public Class CalculatorBase

        Private components As System.ComponentModel.IContainer = Nothing

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.button7 = New System.Windows.Forms.Button()
            Me.button8 = New System.Windows.Forms.Button()
            Me.button9 = New System.Windows.Forms.Button()
            Me.numericDisplay = New System.Windows.Forms.TextBox()
            Me.plus = New System.Windows.Forms.Button()
            Me.expression = New System.Windows.Forms.TextBox()
            Me.button6 = New System.Windows.Forms.Button()
            Me.button5 = New System.Windows.Forms.Button()
            Me.button4 = New System.Windows.Forms.Button()
            Me.button3 = New System.Windows.Forms.Button()
            Me.button2 = New System.Windows.Forms.Button()
            Me.button1 = New System.Windows.Forms.Button()
            Me.decimalPoint = New System.Windows.Forms.Button()
            Me.button0 = New System.Windows.Forms.Button()
            Me.minus = New System.Windows.Forms.Button()
            Me.times = New System.Windows.Forms.Button()
            Me.divide = New System.Windows.Forms.Button()
            Me.clearAll = New System.Windows.Forms.Button()
            Me.clearEntry = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            Me.button7.Location = New System.Drawing.Point(102, 115)
            Me.button7.Margin = New System.Windows.Forms.Padding(1)
            Me.button7.Name = "button7"
            Me.button7.Size = New System.Drawing.Size(34, 34)
            Me.button7.TabIndex = 0
            Me.button7.Text = "7"
            Me.button7.UseVisualStyleBackColor = True
            'Me.button7.Click += New System.EventHandler(Me.button7_Click)
            Me.button8.Location = New System.Drawing.Point(156, 115)
            Me.button8.Margin = New System.Windows.Forms.Padding(1)
            Me.button8.Name = "button8"
            Me.button8.Size = New System.Drawing.Size(34, 34)
            Me.button8.TabIndex = 1
            Me.button8.Text = "8"
            Me.button8.UseVisualStyleBackColor = True
            'Me.button8.Click += New System.EventHandler(Me.button8_Click)
            Me.button9.Location = New System.Drawing.Point(209, 115)
            Me.button9.Margin = New System.Windows.Forms.Padding(1)
            Me.button9.Name = "button9"
            Me.button9.Size = New System.Drawing.Size(34, 34)
            Me.button9.TabIndex = 2
            Me.button9.Text = "9"
            Me.button9.UseVisualStyleBackColor = True
            'Me.button9.Click += New System.EventHandler(Me.button9_Click)
            Me.numericDisplay.Location = New System.Drawing.Point(27, 57)
            Me.numericDisplay.Margin = New System.Windows.Forms.Padding(1)
            Me.numericDisplay.Name = "numericDisplay"
            Me.numericDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.numericDisplay.Size = New System.Drawing.Size(270, 20)
            Me.numericDisplay.TabIndex = 6
            Me.numericDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.plus.Location = New System.Drawing.Point(261, 115)
            Me.plus.Margin = New System.Windows.Forms.Padding(1)
            Me.plus.Name = "plus"
            Me.plus.Size = New System.Drawing.Size(36, 34)
            Me.plus.TabIndex = 7
            Me.plus.Text = "+"
            Me.plus.UseVisualStyleBackColor = True
            'Me.plus.Click += New System.EventHandler(Me.plus_Click)
            Me.expression.Location = New System.Drawing.Point(27, 21)
            Me.expression.Margin = New System.Windows.Forms.Padding(1)
            Me.expression.Name = "expression"
            Me.expression.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.expression.Size = New System.Drawing.Size(270, 20)
            Me.expression.TabIndex = 9
            Me.expression.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.button6.Location = New System.Drawing.Point(209, 161)
            Me.button6.Margin = New System.Windows.Forms.Padding(1)
            Me.button6.Name = "button6"
            Me.button6.Size = New System.Drawing.Size(34, 34)
            Me.button6.TabIndex = 12
            Me.button6.Text = "6"
            Me.button6.UseVisualStyleBackColor = True
            'Me.button6.Click += New System.EventHandler(Me.button6_Click)
            Me.button5.Location = New System.Drawing.Point(156, 161)
            Me.button5.Margin = New System.Windows.Forms.Padding(1)
            Me.button5.Name = "button5"
            Me.button5.Size = New System.Drawing.Size(34, 34)
            Me.button5.TabIndex = 11
            Me.button5.Text = "5"
            Me.button5.UseVisualStyleBackColor = True
            'Me.button5.Click += New System.EventHandler(Me.button5_Click)
            Me.button4.Location = New System.Drawing.Point(102, 161)
            Me.button4.Margin = New System.Windows.Forms.Padding(1)
            Me.button4.Name = "button4"
            Me.button4.Size = New System.Drawing.Size(34, 34)
            Me.button4.TabIndex = 10
            Me.button4.Text = "4"
            Me.button4.UseVisualStyleBackColor = True
            'Me.button4.Click += New System.EventHandler(Me.button4_Click)
            Me.button3.Location = New System.Drawing.Point(209, 207)
            Me.button3.Margin = New System.Windows.Forms.Padding(1)
            Me.button3.Name = "button3"
            Me.button3.Size = New System.Drawing.Size(34, 34)
            Me.button3.TabIndex = 15
            Me.button3.Text = "3"
            Me.button3.UseVisualStyleBackColor = True
            'Me.button3.Click += New System.EventHandler(Me.button3_Click)
            Me.button2.Location = New System.Drawing.Point(156, 207)
            Me.button2.Margin = New System.Windows.Forms.Padding(1)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(34, 34)
            Me.button2.TabIndex = 14
            Me.button2.Text = "2"
            Me.button2.UseVisualStyleBackColor = True
            'Me.button2.Click += New System.EventHandler(Me.button2_Click)
            Me.button1.Location = New System.Drawing.Point(102, 207)
            Me.button1.Margin = New System.Windows.Forms.Padding(1)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(34, 34)
            Me.button1.TabIndex = 13
            Me.button1.Text = "1"
            Me.button1.UseVisualStyleBackColor = True
            'Me.button1.Click += New System.EventHandler(Me.button1_Click)
            Me.decimalPoint.Location = New System.Drawing.Point(102, 255)
            Me.decimalPoint.Margin = New System.Windows.Forms.Padding(1)
            Me.decimalPoint.Name = "decimalPoint"
            Me.decimalPoint.Size = New System.Drawing.Size(34, 34)
            Me.decimalPoint.TabIndex = 18
            Me.decimalPoint.Text = "."
            Me.decimalPoint.UseVisualStyleBackColor = True
            'Me.decimalPoint.Click += New System.EventHandler(Me.decimalPoint_Click)
            Me.button0.Location = New System.Drawing.Point(156, 255)
            Me.button0.Margin = New System.Windows.Forms.Padding(1)
            Me.button0.Name = "button0"
            Me.button0.Size = New System.Drawing.Size(34, 34)
            Me.button0.TabIndex = 17
            Me.button0.Text = "0"
            Me.button0.UseVisualStyleBackColor = True
            'Me.button0.Click += New System.EventHandler(Me.button0_Click)
            Me.minus.Location = New System.Drawing.Point(261, 161)
            Me.minus.Margin = New System.Windows.Forms.Padding(1)
            Me.minus.Name = "minus"
            Me.minus.Size = New System.Drawing.Size(36, 34)
            Me.minus.TabIndex = 19
            Me.minus.Text = "-"
            Me.minus.UseVisualStyleBackColor = True
            'Me.minus.Click += New System.EventHandler(Me.minus_Click)
            Me.times.Location = New System.Drawing.Point(261, 207)
            Me.times.Margin = New System.Windows.Forms.Padding(1)
            Me.times.Name = "times"
            Me.times.Size = New System.Drawing.Size(36, 36)
            Me.times.TabIndex = 20
            Me.times.Text = "*"
            Me.times.UseVisualStyleBackColor = True
            'Me.times.Click += New System.EventHandler(Me.times_Click)
            Me.divide.Location = New System.Drawing.Point(261, 253)
            Me.divide.Margin = New System.Windows.Forms.Padding(1)
            Me.divide.Name = "divide"
            Me.divide.Size = New System.Drawing.Size(36, 36)
            Me.divide.TabIndex = 21
            Me.divide.Text = "/"
            Me.divide.UseVisualStyleBackColor = True
            'Me.divide.Click += New System.EventHandler(Me.divide_Click)
            Me.clearAll.Location = New System.Drawing.Point(27, 115)
            Me.clearAll.Name = "clearAll"
            Me.clearAll.Size = New System.Drawing.Size(55, 34)
            Me.clearAll.TabIndex = 22
            Me.clearAll.Text = "CA"
            Me.clearAll.UseVisualStyleBackColor = True
            'Me.clearAll.Click += New System.EventHandler(Me.clear_Click)
            Me.clearEntry.Location = New System.Drawing.Point(27, 161)
            Me.clearEntry.Name = "clearEntry"
            Me.clearEntry.Size = New System.Drawing.Size(55, 34)
            Me.clearEntry.TabIndex = 23
            Me.clearEntry.Text = "CE"
            Me.clearEntry.UseVisualStyleBackColor = True
            'Me.clearEntry.Click += New System.EventHandler(Me.clearEntry_Click)
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(324, 376)
            Me.Controls.Add(Me.clearEntry)
            Me.Controls.Add(Me.clearAll)
            Me.Controls.Add(Me.divide)
            Me.Controls.Add(Me.times)
            Me.Controls.Add(Me.minus)
            Me.Controls.Add(Me.decimalPoint)
            Me.Controls.Add(Me.button0)
            Me.Controls.Add(Me.button3)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.button6)
            Me.Controls.Add(Me.button5)
            Me.Controls.Add(Me.button4)
            Me.Controls.Add(Me.expression)
            Me.Controls.Add(Me.plus)
            Me.Controls.Add(Me.numericDisplay)
            Me.Controls.Add(Me.button9)
            Me.Controls.Add(Me.button8)
            Me.Controls.Add(Me.button7)
            Me.Margin = New System.Windows.Forms.Padding(1)
            Me.Name = "BaseLayout"
            Me.Text = "Base Calculator"
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Protected expression As System.Windows.Forms.TextBox

        Protected numericDisplay As System.Windows.Forms.TextBox

        Friend WithEvents button9 As System.Windows.Forms.Button

        Friend WithEvents button8 As System.Windows.Forms.Button

        Friend WithEvents button7 As System.Windows.Forms.Button

        Friend WithEvents button6 As System.Windows.Forms.Button

        Friend WithEvents button5 As System.Windows.Forms.Button

        Friend WithEvents button4 As System.Windows.Forms.Button

        Friend WithEvents button3 As System.Windows.Forms.Button

        Friend WithEvents button2 As System.Windows.Forms.Button

        Friend WithEvents button1 As System.Windows.Forms.Button

        Friend WithEvents button0 As System.Windows.Forms.Button

        Friend WithEvents decimalPoint As System.Windows.Forms.Button

        Friend WithEvents plus As System.Windows.Forms.Button

        Friend WithEvents minus As System.Windows.Forms.Button

        Friend WithEvents times As System.Windows.Forms.Button

        Friend WithEvents divide As System.Windows.Forms.Button

        Friend WithEvents clearAll As System.Windows.Forms.Button

        Friend WithEvents clearEntry As System.Windows.Forms.Button
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by Refactoring Essentials.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
