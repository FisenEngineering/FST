Public Class frmYVAAEntryPage1
    Public Property pCancelled As Boolean
    Private Sub frmYVAAEntryPage1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pCancelled = False
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        pCancelled = True
        Me.Hide()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Me.Hide()
    End Sub

    Private Sub txtAmbient100_Leave(sender As Object, e As EventArgs) Handles txtAmbient100.Leave
        txtSoundAmbient100.Text = txtAmbient100.Text

    End Sub

    Private Sub txtAmbient75_Leave(sender As Object, e As EventArgs) Handles txtAmbient75.Leave
        txtSoundAmbient75.Text = txtAmbient75.Text
    End Sub

    Private Sub txtAmbient50_Leave(sender As Object, e As EventArgs) Handles txtAmbient50.Leave
        txtSoundAmbient50.Text = txtAmbient50.Text
    End Sub

    Private Sub txtAmbient25_Leave(sender As Object, e As EventArgs) Handles txtAmbient25.Leave
        txtSoundAmbient25.Text = txtAmbient25.Text
    End Sub
End Class