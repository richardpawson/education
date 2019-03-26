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
        Me.Grid = New System.Windows.Forms.PictureBox()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.ScenarioSelector = New System.Windows.Forms.ComboBox()
        Me.AlgorithmSelector = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.visitedCount = New System.Windows.Forms.TextBox()
        Me.pathLength = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Speed = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Speed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Location = New System.Drawing.Point(132, 91)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(1170, 987)
        Me.Grid.TabIndex = 0
        Me.Grid.TabStop = False
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(1480, 325)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(158, 117)
        Me.StartButton.TabIndex = 1
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Location = New System.Drawing.Point(1480, 492)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(157, 113)
        Me.ResetButton.TabIndex = 2
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'ScenarioSelector
        '
        Me.ScenarioSelector.FormattingEnabled = True
        Me.ScenarioSelector.Location = New System.Drawing.Point(1689, 91)
        Me.ScenarioSelector.Name = "ScenarioSelector"
        Me.ScenarioSelector.Size = New System.Drawing.Size(198, 39)
        Me.ScenarioSelector.TabIndex = 3
        '
        'AlgorithmSelector
        '
        Me.AlgorithmSelector.FormattingEnabled = True
        Me.AlgorithmSelector.Location = New System.Drawing.Point(1689, 191)
        Me.AlgorithmSelector.Name = "AlgorithmSelector"
        Me.AlgorithmSelector.Size = New System.Drawing.Size(198, 39)
        Me.AlgorithmSelector.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1474, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 32)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Scenario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1474, 198)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 32)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Algorithm"
        '
        'visitedCount
        '
        Me.visitedCount.Location = New System.Drawing.Point(1689, 681)
        Me.visitedCount.Name = "visitedCount"
        Me.visitedCount.Size = New System.Drawing.Size(198, 38)
        Me.visitedCount.TabIndex = 7
        '
        'pathLength
        '
        Me.pathLength.Location = New System.Drawing.Point(1689, 785)
        Me.pathLength.Name = "pathLength"
        Me.pathLength.Size = New System.Drawing.Size(198, 38)
        Me.pathLength.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1474, 687)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(185, 32)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Visited Count"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1474, 791)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 32)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Path Length"
        '
        'Speed
        '
        Me.Speed.Location = New System.Drawing.Point(1689, 377)
        Me.Speed.Name = "Speed"
        Me.Speed.Size = New System.Drawing.Size(198, 38)
        Me.Speed.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1683, 325)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 32)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Delay"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1983, 1130)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Speed)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pathLength)
        Me.Controls.Add(Me.visitedCount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AlgorithmSelector)
        Me.Controls.Add(Me.ScenarioSelector)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.Grid)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Speed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As PictureBox
    Friend WithEvents StartButton As Button
    Friend WithEvents ResetButton As Button
    Friend WithEvents ScenarioSelector As ComboBox
    Friend WithEvents AlgorithmSelector As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents visitedCount As TextBox
    Friend WithEvents pathLength As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Speed As NumericUpDown
    Friend WithEvents Label5 As Label
End Class
