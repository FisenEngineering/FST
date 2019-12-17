Public Class frmLCVAV
    Private pCancelled As Boolean
    Private pAOK As Boolean
    Public ReadOnly Property AOK As Boolean
        Get
            Return pAOK
        End Get

    End Property
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
        If Not (ValidateConditions()) Then
            pAOK = False
            If Not (frmMain.chkAdminMode.Checked) Then
                Exit Sub
            Else
                frmMain.BypassRequest = True
            End If
        End If
        Me.Hide()
    End Sub

    Private Function ValidateConditions() As Boolean
        Dim TempFunc As Boolean

        TempFunc = True

        Return TempFunc

    End Function

    Private Sub DesignCautions()
        Dim dummy As MsgBoxResult
        Dim YourCode As String

        If frmMain.optSeries5.Checked Then
            dummy = MsgBox("Have you verified that your unit has a 3 phase supply fan blower?")
            If dummy = vbNo Then
                dummy = MsgBox("Please consult engineering to continue.")
                End
            Else
                YourCode = InputBox("Please enter the Bypass Code provided by engineering.")
                If Not (frmMain.MySecurity.BypassOK(frmMain.MySecurity.Date2Julian(Now), YourCode)) Then End
            End If
        End If
    End Sub

    Private Sub frmLCVAV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call DesignCautions()

    End Sub
End Class