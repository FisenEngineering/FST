Public Class frmYLAAUnitEntry
    Public Property pCancelled As Boolean

    Private Sub frmYLAAUnitEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pCancelled = False
        cmbPowerSupply.Text = "-"
        cmbFluid.Text = "Water"
        txtUnitTag.Text = frmMain.txtTag.Text
        txtQty.Text = frmMain.txtQty.Text
        txtModelNumber.Text = frmMain.txtBrandModelNum.Text
        txtRefrigerant.Text = "R410A"
    End Sub

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        Dim CanX As Boolean
        frmYLAAEntryPage1.ShowDialog()
        CanX = frmYLAAEntryPage1.pCancelled
        cmdNext.Enabled = False
        If CanX Then
            pCancelled = True
            Me.Hide()
        End If
        cmdOK.Enabled = True
    End Sub
    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim dummy As MsgBoxResult
        If cmdPointLoads.Enabled = True Then
            dummy = MsgBox("Please Enter the chiller's point loads.", vbOKOnly, "Fisen Sales Handoff Tool")
            Exit Sub
        End If
        frmMain.Show()
        frmMain.cmdFieldInst.Enabled = False
        frmMain.cmdFIOPS.Enabled = False
        frmMain.cmdWriteUnit.Select()
        Me.Hide()
    End Sub

    Private Sub cmdPointLoads_Click(sender As Object, e As EventArgs) Handles cmdPointLoads.Click
        Dim CanX As Boolean
        frmPointLoads.ShowDialog()
        CanX = frmPointLoads.pCancelled
        If CanX Then
            pCancelled = True
            Me.Hide()
        End If
        cmdPointLoads.Enabled = False
        cmdOK.Enabled = True
    End Sub

    Private Sub lblPINA_DoubleClick(sender As Object, e As EventArgs) Handles lblPINA.DoubleClick
        Dim fullModel As String
        fullModel = InputBox("Enter the full model number from the AVM Spec.", "Fisen Sales Handoff Tool")
        txtPIN10.Text = Mid(fullModel, 1, 10)
        fullModel = Mid(fullModel, 11)
        txtPIN20.Text = Mid(fullModel, 1, 10)
        fullModel = Mid(fullModel, 11)
        txtPIN30.Text = Mid(fullModel, 1, 10)
        fullModel = Mid(fullModel, 11)
        txtPIN40.Text = Mid(fullModel, 1, 10)
        fullModel = Mid(fullModel, 11)
        txtPIN50.Text = Mid(fullModel, 1, 10)
        fullModel = Mid(fullModel, 11)
        If Len(fullModel) > 0 Then
            txtPIN60.Text = Mid(fullModel, 1, 10)
            fullModel = Mid(fullModel, 11)
        Else

        End If
        If Len(fullModel) > 0 Then
            txtPIN70.Text = Mid(fullModel, 1, 10)
            fullModel = Mid(fullModel, 11)
        Else

        End If
        If Len(fullModel) > 0 Then
            txtPIN80.Text = Mid(fullModel, 1, 10)
            fullModel = Mid(fullModel, 11)
        Else

        End If
        If Len(fullModel) > 0 Then
            txtPIN90.Text = Mid(fullModel, 1, 10)
            fullModel = Mid(fullModel, 11)
        Else

        End If
    End Sub

End Class