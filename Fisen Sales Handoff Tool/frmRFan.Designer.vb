<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRFan
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
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtESP = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtReturnAirFlow = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optBottomReturn = New System.Windows.Forms.RadioButton()
        Me.optHorizRearReturn = New System.Windows.Forms.RadioButton()
        Me.optHorizEndReturn = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(354, 187)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(72, 26)
        Me.cmdOK.TabIndex = 10
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(276, 187)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 26)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtESP
        '
        Me.txtESP.Location = New System.Drawing.Point(12, 38)
        Me.txtESP.Name = "txtESP"
        Me.txtESP.Size = New System.Drawing.Size(100, 20)
        Me.txtESP.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(118, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "External Static Pressure"
        '
        'txtReturnAirFlow
        '
        Me.txtReturnAirFlow.Location = New System.Drawing.Point(12, 12)
        Me.txtReturnAirFlow.Name = "txtReturnAirFlow"
        Me.txtReturnAirFlow.Size = New System.Drawing.Size(100, 20)
        Me.txtReturnAirFlow.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(118, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Return Airflow"
        '
        'optBottomReturn
        '
        Me.optBottomReturn.AutoSize = True
        Me.optBottomReturn.Checked = True
        Me.optBottomReturn.Location = New System.Drawing.Point(6, 19)
        Me.optBottomReturn.Name = "optBottomReturn"
        Me.optBottomReturn.Size = New System.Drawing.Size(93, 17)
        Me.optBottomReturn.TabIndex = 16
        Me.optBottomReturn.TabStop = True
        Me.optBottomReturn.Text = "Bottom Return"
        Me.optBottomReturn.UseVisualStyleBackColor = True
        '
        'optHorizRearReturn
        '
        Me.optHorizRearReturn.AutoSize = True
        Me.optHorizRearReturn.Location = New System.Drawing.Point(6, 42)
        Me.optHorizRearReturn.Name = "optHorizRearReturn"
        Me.optHorizRearReturn.Size = New System.Drawing.Size(139, 17)
        Me.optHorizRearReturn.TabIndex = 17
        Me.optHorizRearReturn.Text = "Horizontal Return (Rear)"
        Me.optHorizRearReturn.UseVisualStyleBackColor = True
        '
        'optHorizEndReturn
        '
        Me.optHorizEndReturn.AutoSize = True
        Me.optHorizEndReturn.Location = New System.Drawing.Point(6, 65)
        Me.optHorizEndReturn.Name = "optHorizEndReturn"
        Me.optHorizEndReturn.Size = New System.Drawing.Size(135, 17)
        Me.optHorizEndReturn.TabIndex = 18
        Me.optHorizEndReturn.Text = "Horizontal Return (End)"
        Me.optHorizEndReturn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optBottomReturn)
        Me.GroupBox1.Controls.Add(Me.optHorizEndReturn)
        Me.GroupBox1.Controls.Add(Me.optHorizRearReturn)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(154, 88)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Return Ducting"
        '
        'frmRFan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 225)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtESP)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtReturnAirFlow)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmRFan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Return Fan"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents txtESP As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtReturnAirFlow As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents optBottomReturn As RadioButton
    Friend WithEvents optHorizRearReturn As RadioButton
    Friend WithEvents optHorizEndReturn As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
End Class
