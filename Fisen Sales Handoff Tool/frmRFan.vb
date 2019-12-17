Public Class frmRFan
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
    Private Sub frmRFan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

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
        Dim dummy As MsgBoxResult
        Dim TempFunc As Boolean
        Dim raf As String
        Dim numraf As Double

        Dim esp As String
        Dim numesp As Double

        TempFunc = True

        'Check the aiflow
        raf = txtReturnAirFlow.Text
        If Not (IsNumeric(raf)) Then
            dummy = MsgBox("Return Air Flow must be a numberic value", vbOKOnly, frmMain.SlnName)
            TempFunc = False
        Else
            numraf = Val(raf)
            If numraf < 0 Then
                dummy = MsgBox("Return Air Flow must be greater than 0", vbOKOnly, frmMain.SlnName)
                TempFunc = False
            End If
            Select Case frmMain.Family
                Case Is = "Series5"
                    If numraf > 2000 Then
                        dummy = MsgBox("Return Air Flow must be less than 2000", vbOKOnly, frmMain.SlnName)
                    End If
                Case Is = "Series10"
                    If numraf > 4800 Then
                        dummy = MsgBox("Return Air Flow must be less than 4800", vbOKOnly, frmMain.SlnName)
                    End If
                Case Is = "Series20"
                    If numraf > 10000 Then
                        dummy = MsgBox("Return Air Flow must be less than 10000", vbOKOnly, frmMain.SlnName)
                    End If
                Case Is = "Series40"
                    If numraf > 16000 Then
                        dummy = MsgBox("Return Air Flow must be less than 16000", vbOKOnly, frmMain.SlnName)
                    End If
                Case Is = "Series100"
                    If numraf > 60000 Then
                        dummy = MsgBox("Return Air Flow must be less than 60000", vbOKOnly, frmMain.SlnName)
                    End If
                Case Else
            End Select
        End If

        'check the external static pressure
        esp = txtESP.Text
        If Not (IsNumeric(esp)) Then
            dummy = MsgBox("External Static Pressure must be a numberic value", vbOKOnly, frmMain.SlnName)
            TempFunc = False
        Else
            numesp = Val(esp)
            If numesp < 0 Then
                dummy = MsgBox("External Static Pressure must be greater than 0", vbOKOnly, frmMain.SlnName)
                TempFunc = False
            Else
                If numesp > 5 Then
                    dummy = MsgBox("External Static Pressure must be less than 5.00", vbOKOnly, frmMain.SlnName)
                    TempFunc = False
                End If
            End If
        End If

        Return TempFunc
    End Function


End Class