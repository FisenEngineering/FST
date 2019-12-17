Public Class frmYPALUnitEntry
    Public Property pCancelled As Boolean

    Private Sub frmYPALUnitEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPowerSupply.Text = "-"
        txtUnitTag.Text = frmMain.txtTag.Text
        txtQty.Text = frmMain.txtQty.Text
        txtModelNumber.Text = frmMain.txtBrandModelNum.Text
        txtRefrigerant.Text = "R410A"
        cmbSPSLabel1.Text = "N/A"
        cmbSPSLabel2.Text = "N/A"
        cmbSPSLabel3.Text = "N/A"
        cmbSPSLabel4.Text = "N/A"
        cmbSPSLabel5.Text = "N/A"
        cmbSPSLabel6.Text = "N/A"
        cmbSPSLabel7.Text = "N/A"
        cmbSPSLabel8.Text = "N/A"
        pCancelled = False
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Me.Hide()

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        pCancelled = True
        Me.Hide()
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
            Case Is = "Gas Heat"
                lblHeatLine1.Visible = True
                lblHeatLine2.Visible = True
                lblHeatLine3.Visible = True
                lblHeatLine4.Visible = True
                lblHeatLine5.Visible = True
                lblHeatLine6.Visible = True
                lblHeatLine7.Visible = False
                lblHeatLine8.Visible = False
                lblHeatLine9.Visible = False
                lblHeatLine1.Text = "Heat Output"
                lblHeatLine2.Text = "Heat Input"
                lblHeatLine3.Text = "Gas Consumption"
                lblHeatLine4.Text = "Gas Heat Content"
                lblHeatLine5.Text = "Entering Air Temp"
                lblHeatLine6.Text = "Leaving Air Temp"
                lblHeatLine7.Text = "---"
                txtHeatLine7.Visible = False
                lblHeatLine8.Text = "---"
                txtHeatLine8.Visible = False
                lblHeatLine9.Text = "---"
                txtHeatLine9.Visible = False
            Case Is = "Electric Heat"
                lblHeatLine1.Visible = True
                lblHeatLine2.Visible = True
                lblHeatLine3.Visible = True
                lblHeatLine4.Visible = True
                lblHeatLine5.Visible = True
                lblHeatLine6.Visible = True
                lblHeatLine7.Visible = True
                lblHeatLine8.Visible = True
                lblHeatLine9.Visible = False
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
        End Select
    End Sub

    Private Sub optRFan_CheckedChanged(sender As Object, e As EventArgs) Handles optRFan.CheckedChanged
        If optRFan.Checked Then
            lblRXFanAFlow.Visible = True
            lblRXFanAFlow.Text = "Return Airflow"
            txtRXFanAFlow.Visible = True
            txtRXFanAFlow.Text = "-"
            lblRXFanESP.Visible = True
            lblRXFanESP.Text = "Return Duct ESP"
            txtRXFanESP.Visible = True
            txtRXFanESP.Text = "-"
            grpRXFanPerformance.Visible = True
            grpRXFanPerformance.Text = "Return Fan Performance"
            lblRXFanFLA.Text = "Return Fan"
        Else
            lblRXFanAFlow.Visible = False
            lblRXFanAFlow.Text = "RX Airflow"
            txtRXFanAFlow.Visible = False
            txtRXFanAFlow.Text = "-"
            lblRXFanESP.Visible = False
            lblRXFanESP.Text = "Return Duct ESP"
            txtRXFanESP.Visible = False
            txtRXFanESP.Text = "-"
            grpRXFanPerformance.Visible = False
            grpRXFanPerformance.Text = "Exhaust Fan Performance"
            lblRXFanFLA.Text = "Exhaust Fan"
            txtRXFanFLA.Text = "-"

        End If
    End Sub

    Private Sub optXFan_CheckedChanged(sender As Object, e As EventArgs) Handles optXFan.CheckedChanged
        If optXFan.Checked Then
            lblRXFanAFlow.Visible = True
            lblRXFanAFlow.Text = "Return Airflow"
            txtRXFanAFlow.Visible = True
            txtRXFanAFlow.Text = "-"
            lblRXFanAFlow.Visible = True
            lblRXFanESP.Text = "Return Duct ESP"
            txtRXFanESP.Visible = True
            txtRXFanESP.Text = "-"
            grpRXFanPerformance.Visible = True
            grpRXFanPerformance.Text = "Exhaust Fan Performance"
            lblRXFanFLA.Text = "Exhaust Fan"
        Else
            lblRXFanAFlow.Visible = False
            lblRXFanAFlow.Text = "RX Airflow"
            txtRXFanAFlow.Visible = False
            txtRXFanAFlow.Text = "-"
            lblRXFanAFlow.Visible = False
            lblRXFanAFlow.Text = "Return Duct ESP"
            txtRXFanESP.Visible = False
            txtRXFanESP.Text = "-"
            grpRXFanPerformance.Visible = False
            grpRXFanPerformance.Text = "Exhaust Fan Performance"
            lblRXFanFLA.Text = "Exhaust Fan"
            txtRXFanFLA.Text = "-"

        End If
    End Sub

    Private Sub txtAirflow_Leave(sender As Object, e As EventArgs) Handles txtAirflow.Leave
        txtSFanAFlow.Text = txtAirflow.Text
    End Sub


End Class