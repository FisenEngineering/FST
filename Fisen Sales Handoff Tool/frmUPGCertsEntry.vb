Public Class frmUPGCertsEntry
    Private Sub picASHRAE90_1_Click(sender As Object, e As EventArgs) Handles picASHRAE90_1.Click
        chkASHRAE90_1.Checked = Not (chkASHRAE90_1.Checked)
    End Sub

    Private Sub picISO9001_Click(sender As Object, e As EventArgs) Handles picISO9001.Click
        chkISO9001.Checked = Not (chkISO9001.Checked)
    End Sub

    Private Sub picCSADesignCert_Click(sender As Object, e As EventArgs) Handles picCSADesignCert.Click
        chkCSADesign.Checked = Not (chkCSADesign.Checked)
    End Sub

    Private Sub picAHRICert_Click(sender As Object, e As EventArgs) Handles picAHRICert.Click
        chkAHRICert.Checked = Not (chkAHRICert.Checked)
    End Sub

    Private Sub picCSA_C_US_Click(sender As Object, e As EventArgs) Handles picCSA_C_US.Click
        chkCSA_C_US.Checked = Not (chkCSA_C_US.Checked)
    End Sub

    Private Sub picETL_C_US_Click(sender As Object, e As EventArgs) Handles picETL_C_US.Click
        chkETL_C_US.Checked = Not (chkETL_C_US.Checked)
    End Sub

    Private Sub picCSAGas_Click(sender As Object, e As EventArgs) Handles picCSAGas.Click
        chkCSAGas.Checked = Not (chkCSAGas.Checked)
    End Sub

    Private Sub picETL_Click(sender As Object, e As EventArgs) Handles picETL.Click
        chkETL.Checked = Not (chkETL.Checked)
    End Sub

    Private Sub picAmQ_Click(sender As Object, e As EventArgs) Handles picAmQ.Click
        chkAmericanQ.Checked = Not (chkAmericanQ.Checked)
    End Sub

    Private Sub picEStar_Click(sender As Object, e As EventArgs) Handles picEStar.Click
        chkEnergyStar.Checked = Not (chkEnergyStar.Checked)
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Me.Hide()
    End Sub
End Class