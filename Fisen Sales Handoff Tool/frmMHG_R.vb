Public Class frmMHG_R
    Private pCancelled As Boolean
    Public Property Cancelled As Boolean
        Get
            Return pCancelled
        End Get
        Set(value As Boolean)
            pCancelled = value
        End Set
    End Property

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        pCancelled = True
        Me.Hide()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim dummy As MsgBoxResult
        If Not (chkSSHXThere.Checked) Then
            dummy = MsgBox("Verify if a SS HX is present on base unit.", vbOKOnly, "Fisen Sales Handoff Tool")
            Exit Sub
        End If

        Me.Hide()
    End Sub

End Class