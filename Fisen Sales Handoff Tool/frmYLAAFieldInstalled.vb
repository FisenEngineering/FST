﻿Public Class frmYLAAFieldInstalled
    Public Property pCancelled As Boolean

    Private Sub frmYLAAFieldInstalled_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pCancelled = False
    End Sub
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        pCancelled = True
        Me.Hide()
    End Sub
    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click

        Me.Hide()
    End Sub
End Class