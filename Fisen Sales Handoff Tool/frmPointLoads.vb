Public Class frmPointLoads
    Public Property pCancelled As Boolean
    Public Property pDoneLoading As Boolean

    Private Sub frmPointLoads_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pCancelled = False
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If Not pDoneLoading Then Exit Sub
        Dim i As Integer
        Dim TopofList As Integer
        Dim MyTextBox As TextBox
        Dim MyLabel As Label
        Dim ControlName As String

        TopofList = NumericUpDown1.Value / 2
        For i = 1 To TopofList
            ControlName = "lblR" & Trim(Str(i))
            MyLabel = Me.Controls.Item(ControlName)
            MyLabel.Visible = True
            ControlName = "lblL" & Trim(Str(i))
            MyLabel = Me.Controls.Item(ControlName)
            MyLabel.Visible = True

            ControlName = "txtXR" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            MyTextBox.Visible = True
            ControlName = "txtXL" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            MyTextBox.Visible = True
            ControlName = "txtYR" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            MyTextBox.Visible = True
            ControlName = "txtYL" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            MyTextBox.Visible = True
            ControlName = "txtOpWtR" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            MyTextBox.Visible = True
            ControlName = "txtOpWtL" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            MyTextBox.Visible = True
        Next

        For i = TopofList + 1 To 6
            ControlName = "lblR" & Trim(Str(i))
            MyLabel = Me.Controls.Item(ControlName)
            MyLabel.Visible = False
            ControlName = "lblL" & Trim(Str(i))
            MyLabel = Me.Controls.Item(ControlName)
            MyLabel.Visible = False

            ControlName = "txtXR" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            MyTextBox.Visible = False
            MyTextBox.Text = "-"
            ControlName = "txtXL" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            MyTextBox.Visible = False
            MyTextBox.Text = "-"
            ControlName = "txtYR" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            MyTextBox.Visible = False
            MyTextBox.Text = "-"
            ControlName = "txtYL" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            MyTextBox.Visible = False
            MyTextBox.Text = "-"
            ControlName = "txtOpWtR" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            MyTextBox.Visible = False
            MyTextBox.Text = "-"
            ControlName = "txtOpWtL" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            MyTextBox.Visible = False
            MyTextBox.Text = "-"
        Next

    End Sub

    Private Sub frmPointLoads_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        pDoneLoading = True
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If Not pDoneLoading Then Exit Sub
        Dim i As Integer
        Dim TopofList As Integer
        Dim MyTextBox As TextBox
        Dim ControlName As String
        Dim GTG As Boolean

        GTG = True
        TopofList = NumericUpDown1.Value / 2
        For i = 1 To TopofList

            ControlName = "txtXR" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            If MyTextBox.Text = "-" Then GTG = False
            ControlName = "txtXL" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            If MyTextBox.Text = "-" Then GTG = False
            ControlName = "txtYR" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            If MyTextBox.Text = "-" Then GTG = False
            ControlName = "txtYL" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            If MyTextBox.Text = "-" Then GTG = False
            ControlName = "txtOpWtR" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            If MyTextBox.Text = "-" Then GTG = False
            ControlName = "txtOpWtL" & Trim(Str(i))
            MyTextBox = Me.Controls.Item(ControlName)
            If MyTextBox.Text = "-" Then GTG = False
        Next
        If Not (GTG) Then Exit Sub
        Me.Hide()

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        pCancelled = True
        Me.Hide()
    End Sub
End Class