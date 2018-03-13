
Namespace Calculator

    Partial Class CalculatorRPN

        Private Sub InitializeComponent()
            Me.evaluate = New System.Windows.Forms.Button()
            Me.enter = New System.Windows.Forms.Button()
            Me.enter.Location = New System.Drawing.Point(156, 303)
            Me.enter.Margin = New System.Windows.Forms.Padding(1)
            Me.enter.Name = "enter"
            Me.enter.Size = New System.Drawing.Size(64, 32)
            Me.enter.TabIndex = 3
            Me.enter.Text = "enter"
            Me.enter.UseVisualStyleBackColor = True
            'Me.enter.Click += New System.EventHandler(Me.enter_Click)
            Me.evaluate.Location = New System.Drawing.Point(226, 303)
            Me.evaluate.Margin = New System.Windows.Forms.Padding(1)
            Me.evaluate.Name = "evaluate"
            Me.evaluate.Size = New System.Drawing.Size(71, 32)
            Me.evaluate.TabIndex = 8
            Me.evaluate.Text = "evaluate"
            Me.evaluate.UseVisualStyleBackColor = True
            'Me.evaluate.Click += New System.EventHandler(Me.evaluate_Click)
            Me.Controls.Add(Me.evaluate)
            Me.Controls.Add(Me.enter)
            Me.Name = "RPN"
            Me.Text = "RPN Calculator"
        End Sub

        Friend WithEvents enter As System.Windows.Forms.Button

        Friend WithEvents evaluate As System.Windows.Forms.Button
    End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by Refactoring Essentials.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
