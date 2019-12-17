<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLCVAV
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
        Me.chkVFDFromJCI = New System.Windows.Forms.CheckBox()
        Me.chkUseECMDesign = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(212, 71)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(72, 26)
        Me.cmdOK.TabIndex = 10
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(134, 71)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 26)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'chkVFDFromJCI
        '
        Me.chkVFDFromJCI.AutoSize = True
        Me.chkVFDFromJCI.Location = New System.Drawing.Point(12, 12)
        Me.chkVFDFromJCI.Name = "chkVFDFromJCI"
        Me.chkVFDFromJCI.Size = New System.Drawing.Size(215, 17)
        Me.chkVFDFromJCI.TabIndex = 12
        Me.chkVFDFromJCI.Text = "Base Unit Will Ship From JCI with a VFD"
        Me.chkVFDFromJCI.UseVisualStyleBackColor = True
        '
        'chkUseECMDesign
        '
        Me.chkUseECMDesign.AutoSize = True
        Me.chkUseECMDesign.Location = New System.Drawing.Point(12, 35)
        Me.chkUseECMDesign.Name = "chkUseECMDesign"
        Me.chkUseECMDesign.Size = New System.Drawing.Size(228, 17)
        Me.chkUseECMDesign.TabIndex = 13
        Me.chkUseECMDesign.Text = "Single Phase Supply Fan Use ECM Design"
        Me.chkUseECMDesign.UseVisualStyleBackColor = True
        '
        'frmLCVAV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(296, 109)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkUseECMDesign)
        Me.Controls.Add(Me.chkVFDFromJCI)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmLCVAV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LCVAV"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents chkVFDFromJCI As CheckBox
    Friend WithEvents chkUseECMDesign As CheckBox
End Class
