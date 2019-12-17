Public Class frmYVAAUnitEntry
    Public Property pCancelled As Boolean

    Private Sub frmYVAAUnitEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pCancelled = False
        cmbPowerSupply.Text = "-"
        cmbFluid.Text = "Water"
        txtUnitTag.Text = frmMain.txtTag.Text
        txtQty.Text = frmMain.txtQty.Text
        txtModelNumber.Text = frmMain.txtBrandModelNum.Text
        txtRefrigerant.Text = "R134A"

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim dummy As MsgBoxResult
        If cmdPointLoads.Enabled = True Then
            dummy = MsgBox("Please Enter the chiller's point loads.", vbOKOnly, "Fisen Sales Handoff Tool")
            Exit Sub
        End If
        Me.Hide()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        pCancelled = True
        Me.Hide()
    End Sub

    Private Sub cmdNext_Click(sender As Object, e As EventArgs) Handles cmdNext.Click
        Dim CanX As Boolean
        frmYVAAEntryPage1.ShowDialog()
        CanX = frmYVAAEntryPage1.pCancelled
        If CanX Then
            pCancelled = True
            Me.Hide()
        End If
        cmdOK.Enabled = True
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

End Class