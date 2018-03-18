<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.NextShape = New System.Windows.Forms.Button()
        Me.PrevShape = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Draw Triangle", "Draw Rectangle", "Move Shape", "Resize Shape", "Draw House"})
        Me.ComboBox1.Location = New System.Drawing.Point(13, 13)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'NextShape
        '
        Me.NextShape.Location = New System.Drawing.Point(13, 42)
        Me.NextShape.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.NextShape.Name = "NextShape"
        Me.NextShape.Size = New System.Drawing.Size(55, 29)
        Me.NextShape.TabIndex = 1
        Me.NextShape.Text = "Next"
        Me.NextShape.UseVisualStyleBackColor = True
        '
        'PrevShape
        '
        Me.PrevShape.Location = New System.Drawing.Point(85, 42)
        Me.PrevShape.Margin = New System.Windows.Forms.Padding(1, 1, 1, 1)
        Me.PrevShape.Name = "PrevShape"
        Me.PrevShape.Size = New System.Drawing.Size(47, 29)
        Me.PrevShape.TabIndex = 2
        Me.PrevShape.Text = "Prev"
        Me.PrevShape.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 311)
        Me.Controls.Add(Me.PrevShape)
        Me.Controls.Add(Me.NextShape)
        Me.Controls.Add(Me.ComboBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents NextShape As Button
    Friend WithEvents PrevShape As Button
End Class
