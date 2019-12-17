<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHWCoil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHWCoil))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHeatingAirFlow = New System.Windows.Forms.TextBox()
        Me.txtEAT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCap = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEFT = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFluidFlow = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAPD = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbFluid = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPercent = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(118, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Heating Airflow"
        '
        'txtHeatingAirFlow
        '
        Me.txtHeatingAirFlow.Location = New System.Drawing.Point(12, 12)
        Me.txtHeatingAirFlow.Name = "txtHeatingAirFlow"
        Me.txtHeatingAirFlow.Size = New System.Drawing.Size(100, 20)
        Me.txtHeatingAirFlow.TabIndex = 0
        '
        'txtEAT
        '
        Me.txtEAT.Location = New System.Drawing.Point(12, 64)
        Me.txtEAT.Name = "txtEAT"
        Me.txtEAT.Size = New System.Drawing.Size(100, 20)
        Me.txtEAT.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(118, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "EAT db"
        '
        'txtCap
        '
        Me.txtCap.Location = New System.Drawing.Point(12, 90)
        Me.txtCap.Name = "txtCap"
        Me.txtCap.Size = New System.Drawing.Size(100, 20)
        Me.txtCap.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(118, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Capacity"
        '
        'txtEFT
        '
        Me.txtEFT.Location = New System.Drawing.Point(12, 116)
        Me.txtEFT.Name = "txtEFT"
        Me.txtEFT.Size = New System.Drawing.Size(100, 20)
        Me.txtEFT.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(118, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "EFT"
        '
        'txtFluidFlow
        '
        Me.txtFluidFlow.Location = New System.Drawing.Point(12, 142)
        Me.txtFluidFlow.Name = "txtFluidFlow"
        Me.txtFluidFlow.Size = New System.Drawing.Size(100, 20)
        Me.txtFluidFlow.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(118, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fluid Flow"
        '
        'txtAPD
        '
        Me.txtAPD.Location = New System.Drawing.Point(12, 38)
        Me.txtAPD.Name = "txtAPD"
        Me.txtAPD.Size = New System.Drawing.Size(100, 20)
        Me.txtAPD.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(118, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Budgeted Coil APD"
        '
        'cmbFluid
        '
        Me.cmbFluid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFluid.FormattingEnabled = True
        Me.cmbFluid.Items.AddRange(New Object() {"Water", "E.G.", "P.G."})
        Me.cmbFluid.Location = New System.Drawing.Point(12, 168)
        Me.cmbFluid.Name = "cmbFluid"
        Me.cmbFluid.Size = New System.Drawing.Size(100, 21)
        Me.cmbFluid.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(118, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Fluid Flow"
        '
        'txtPercent
        '
        Me.txtPercent.Location = New System.Drawing.Point(178, 168)
        Me.txtPercent.Name = "txtPercent"
        Me.txtPercent.Size = New System.Drawing.Size(48, 20)
        Me.txtPercent.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(232, 171)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "%"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(280, 198)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 26)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(358, 198)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(72, 26)
        Me.cmdOK.TabIndex = 8
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'frmHWCoil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(442, 229)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtPercent)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbFluid)
        Me.Controls.Add(Me.txtAPD)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtFluidFlow)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtEFT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCap)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEAT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtHeatingAirFlow)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHWCoil"
        Me.Text = "Hot Water Coil Conditions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtHeatingAirFlow As TextBox
    Friend WithEvents txtEAT As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCap As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEFT As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFluidFlow As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAPD As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbFluid As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPercent As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdOK As Button
End Class
