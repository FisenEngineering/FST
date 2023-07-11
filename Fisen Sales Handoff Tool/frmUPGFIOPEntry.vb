Public Class frmUPGFIOPEntry
    Public Property pCancelled As Boolean

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim dummy As MsgBoxResult

        dummy = MsgBox("Are there any Norman Mod Shop Options?", vbYesNo, "Fisen Sales Tools")
        If dummy = vbYes Then
            frmModShopOptions.ShowDialog()

        End If
        Me.Hide()
    End Sub

    Private Sub frmUPGFIOPEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pCancelled = False
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        pCancelled = True
        Me.Hide()
    End Sub

    Private Sub cmdClipboardImport_Click(sender As Object, e As EventArgs) Handles cmdClipboardImport.Click
        Dim dummy As MsgBoxResult
        Dim ClipText As String
        Dim FIOPArray() As String
        Dim i As Integer

        dummy = MsgBox("Please Copy the Page 2 Options to the Clipboard", vbOKCancel, "Experimental Feature")
        If dummy = vbCancel Then Exit Sub
        ClipText = My.Computer.Clipboard.GetText
        FIOPArray = Split(ClipText, vbCrLf)

        For i = 0 To FIOPArray.Length - 1
            If FIOPArray(i).Contains("Heat Type:") Then

            End If
            Debug.Print(FIOPArray(i))
        Next


        'Debug.Print(ClipText)


    End Sub
End Class