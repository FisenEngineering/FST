Public Class frmYLAAEntryPage1
    Public Property pCancelled As Boolean
    Private Sub frmYLAAEntryPage1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pCancelled = False
        lstSoundDescription.SelectedIndex = 0
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        pCancelled = True
        Me.Hide()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Me.Hide()
    End Sub

    Private Sub txtAmbient_1_Leave(sender As Object, e As EventArgs) Handles txtAmbient_1.Leave
        txtSoundAmbient1.Text = txtAmbient_1.Text
    End Sub
    Private Sub txtAmbient_2_Leave(sender As Object, e As EventArgs) Handles txtAmbient_2.Leave
        txtSoundAmbient2.Text = txtAmbient_2.Text
    End Sub
    Private Sub txtAmbient_3_Leave(sender As Object, e As EventArgs) Handles txtAmbient_3.Leave
        txtSoundAmbient3.Text = txtAmbient_3.Text
    End Sub
    Private Sub txtAmbient_4_Leave(sender As Object, e As EventArgs) Handles txtAmbient_4.Leave
        txtSoundAmbient4.Text = txtAmbient_4.Text
    End Sub
    Private Sub txtAmbient_5_Leave(sender As Object, e As EventArgs) Handles txtAmbient_5.Leave
        txtSoundAmbient5.Text = txtAmbient_5.Text
    End Sub
    Private Sub txtAmbient_6_Leave(sender As Object, e As EventArgs) Handles txtAmbient_6.Leave
        txtSoundAmbient6.Text = txtAmbient_6.Text
    End Sub
End Class