Public Class frmUPGEntry
    Public Property pCancelled As Boolean
    Private Sub frmUPGEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbHeatType.Text = "No Heat"
        cmbVolts.Text = "-"
        cmbReheatStyle.Text = "None"
        pCancelled = False

    End Sub

    Private Sub cmbHeatType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHeatType.SelectedIndexChanged
        Select Case cmbHeatType.Text
            Case Is = "No Heat"
                lblHeatLine1.Visible = False
                lblHeatLine2.Visible = False
                lblHeatLine3.Visible = False
                lblHeatLine4.Visible = False
                lblHeatLine5.Visible = False
                lblHeatLine6.Visible = False
                lblHeatLine7.Visible = False
                lblHeatLine8.Visible = False
                lblHeatLine9.Visible = False
                txtHeatLine1.Visible = False
                txtHeatLine1.Text = "-"
                txtHeatLine2.Visible = False
                txtHeatLine2.Text = "-"
                txtHeatLine3.Visible = False
                txtHeatLine3.Text = "-"
                txtHeatLine4.Visible = False
                txtHeatLine4.Text = "-"
                txtHeatLine5.Visible = False
                txtHeatLine5.Text = "-"
                txtHeatLine6.Visible = False
                txtHeatLine6.Text = "-"
                txtHeatLine7.Visible = False
                txtHeatLine7.Text = "-"
                txtHeatLine8.Visible = False
                txtHeatLine8.Text = "-"
                txtHeatLine9.Visible = False
                txtHeatLine9.Text = "-"
            Case Is = "Gas Heat"
                lblHeatLine1.Visible = True
                lblHeatLine2.Visible = True
                lblHeatLine3.Visible = True
                lblHeatLine4.Visible = True
                lblHeatLine5.Visible = True
                lblHeatLine6.Visible = True
                lblHeatLine7.Visible = True
                lblHeatLine8.Visible = True
                lblHeatLine9.Visible = True
                txtHeatLine1.Visible = True
                txtHeatLine2.Visible = True
                txtHeatLine3.Visible = True
                txtHeatLine4.Visible = True
                txtHeatLine5.Visible = True
                txtHeatLine6.Visible = True
                txtHeatLine7.Visible = True
                txtHeatLine8.Visible = True
                txtHeatLine9.Visible = True
                lblHeatLine1.Text = "Entering DB Temp"
                lblHeatLine2.Text = "Heating Output Capacity"
                lblHeatLine3.Text = "Supply Air"
                lblHeatLine4.Text = "Heating Input Capacity"
                lblHeatLine5.Text = "Leaving DB Temperature"
                lblHeatLine6.Text = "Air Temp Rise"
                lblHeatLine7.Text = "SSE"
                lblHeatLine8.Text = "Stages"
                lblHeatLine9.Text = "Control Style"
                txtHeatLine9.Text = "Staged"
            Case Is = "Electric"
                lblHeatLine1.Visible = True
                lblHeatLine2.Visible = True
                lblHeatLine3.Visible = True
                lblHeatLine4.Visible = True
                lblHeatLine5.Visible = True
                lblHeatLine6.Visible = True
                lblHeatLine7.Visible = True
                lblHeatLine8.Visible = True
                lblHeatLine9.Visible = False
                txtHeatLine1.Visible = True
                txtHeatLine2.Visible = True
                txtHeatLine3.Visible = True
                txtHeatLine4.Visible = True
                txtHeatLine5.Visible = True
                txtHeatLine6.Visible = True
                txtHeatLine7.Visible = True
                txtHeatLine8.Visible = True
                txtHeatLine9.Visible = True
                lblHeatLine1.Text = "Entering DB Temp"
                lblHeatLine2.Text = "Heating Output Capacity"
                lblHeatLine3.Text = "Nominal Electric Heat"
                lblHeatLine4.Text = "Applied Electric Heat"
                lblHeatLine5.Text = "Installed"
                lblHeatLine6.Text = "Supply"
                lblHeatLine7.Text = "Leaving DB Temp"
                lblHeatLine8.Text = "Air Temp Rise"
                lblHeatLine9.Text = "HeatLine9"
                txtHeatLine9.Visible = False
                txtHeatLine9.Text = "-"
        End Select
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Me.Hide()
    End Sub

    Private Sub optRXFanPresent_CheckedChanged(sender As Object, e As EventArgs) Handles optRXFanPresent.CheckedChanged
        If optRXFanPresent.Checked Then
            txtRXFanAFlow.Enabled = True
            txtRXFanESP.Enabled = True
            txtRXFanRPM.Enabled = True
            txtRXFanMaxBHP.Enabled = True
            txtRXFanDuctLoc.Enabled = True
            txtRXFanMotorHP.Enabled = True
            txtRXFanbhp.Enabled = True
            txtRXFanFanPower.Enabled = True
            txtRXFanDriveType.Enabled = True
        Else
            txtRXFanAFlow.Enabled = False
            txtRXFanESP.Enabled = False
            txtRXFanRPM.Enabled = False
            txtRXFanMaxBHP.Enabled = False
            txtRXFanDuctLoc.Enabled = False
            txtRXFanMotorHP.Enabled = False
            txtRXFanbhp.Enabled = False
            txtRXFanFanPower.Enabled = False
            txtRXFanDriveType.Enabled = False

            txtRXFanAFlow.Text = "-"
            txtRXFanESP.Text = "-"
            txtRXFanRPM.Text = "-"
            txtRXFanMaxBHP.Text = "-"
            txtRXFanDuctLoc.Text = "-"
            txtRXFanMotorHP.Text = "-"
            txtRXFanbhp.Text = "-"
            txtRXFanFanPower.Text = "-"
            txtRXFanDriveType.Text = "-"
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        pCancelled = True
        Me.Hide()
    End Sub

    Private Sub cmbReheatStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReheatStyle.SelectedIndexChanged
        If cmbReheatStyle.Text <> "None" Then
            txtReheatTCap.Enabled = True
            txtReheatAmbient.Enabled = True
            txtReheatEnteringdb.Enabled = True
            txtReheatEnteringwb.Enabled = True
            txtReheatLeavingDB.Enabled = True
            txtReheatLeavingWB.Enabled = True
            txtReheatPower.Enabled = True
            txtReheatGPH.Enabled = True
        Else
            txtReheatTCap.Enabled = False
            txtReheatAmbient.Enabled = False
            txtReheatEnteringdb.Enabled = False
            txtReheatEnteringwb.Enabled = False
            txtReheatLeavingDB.Enabled = False
            txtReheatLeavingWB.Enabled = False
            txtReheatPower.Enabled = False
            txtReheatGPH.Enabled = False
            txtReheatTCap.Text = "-"
            txtReheatAmbient.Text = "-"
            txtReheatEnteringdb.Text = "-"
            txtReheatEnteringwb.Text = "-"
            txtReheatLeavingDB.Text = "-"
            txtReheatLeavingWB.Text = "-"
            txtReheatPower.Text = "-"
            txtReheatGPH.Text = "-"
        End If
    End Sub

    Private Sub cmdBelt_Click(sender As Object, e As EventArgs) Handles cmdBelt.Click
        txtSFanDriveType.Text = "Belt"
    End Sub
End Class