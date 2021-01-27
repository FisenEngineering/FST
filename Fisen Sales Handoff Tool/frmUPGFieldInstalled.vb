Public Class frmUPGFieldInstalled
    Public Property pCancelled As Boolean

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Me.Hide()
    End Sub

    Private Sub frmUPGFIOPEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pCancelled = False
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        pCancelled = True
        Me.Hide()
    End Sub

    Private Sub CheckBox45_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox45.CheckedChanged
        Dim dummy As MsgBoxResult
        dummy = MsgBox("What don't you understand about the word Never", vbOKOnly, "FST")

    End Sub
End Class