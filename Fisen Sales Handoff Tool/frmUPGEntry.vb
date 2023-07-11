Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmUPGEntry
    Public Property pCancelled As Boolean
    Private Sub frmUPGEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbHeatType.Text = "No Heat"
        cmbVolts.Text = "-"
        cmbReheatStyle.Text = "None"
        pCancelled = False
        Call PopulateDimsAndClearances()

    End Sub
    Private Sub PopulateDimsAndClearances()
        Dim lFamily As String

        lFamily = frmMain.Family
        Select Case lFamily
            Case Is = "Choice"
                Select Case frmMain.NomTons
                    Case Is = "15"
                        txtHeight.Text = "49"
                        txtLength.Text = "130"
                        txtWidth.Text = "89"
                        txtRight.Text = "42"
                        txtFront.Text = "80"
                        txtBack.Text = "36"
                        txtTop.Text = "120"
                        txtBottom.Text = "0"
                        txtLeft.Text = "96"
                    Case Is = "17.5"
                        txtHeight.Text = "49"
                        txtLength.Text = "130"
                        txtWidth.Text = "89"
                        txtRight.Text = "42"
                        txtFront.Text = "80"
                        txtBack.Text = "36"
                        txtTop.Text = "120"
                        txtBottom.Text = "0"
                        txtLeft.Text = "96"
                    Case Is = "20"
                        txtHeight.Text = "49"
                        txtLength.Text = "144"
                        txtWidth.Text = "89"
                        txtRight.Text = "42"
                        txtFront.Text = "80"
                        txtBack.Text = "0"
                        txtTop.Text = "120"
                        txtBottom.Text = "0"
                        txtLeft.Text = "18"
                End Select
                'txtHeight.Text = ""
                'txtLength.Text = ""
                'txtWidth.Text = ""
                'txtRight.Text = ""
                'txtFront.Text = ""
                'txtBack.Text = ""
                'txtTop.Text = ""
                'txtBottom.Text = ""
                'txtLeft.Text = ""
            Case Is = "Series10"
                Select Case frmMain.NomTons
                    Case Is = "12.5"
                        txtHeight.Text = "51"
                        txtLength.Text = "120"
                        txtWidth.Text = "59"
                        txtRight.Text = "12"
                        txtFront.Text = "48"
                        txtBack.Text = "36"
                        txtTop.Text = "72"
                        txtBottom.Text = "0"
                        txtLeft.Text = "36"
                    Case Is = "8.5"
                        txtHeight.Text = "51"
                        txtLength.Text = "89"
                        txtWidth.Text = "59"
                        txtRight.Text = "12"
                        txtFront.Text = "48"
                        txtBack.Text = "36"
                        txtTop.Text = "72"
                        txtBottom.Text = "0"
                        txtLeft.Text = "36"
                    Case Is = "4"
                        txtHeight.Text = "42"
                        txtLength.Text = "89"
                        txtWidth.Text = "59"
                        txtRight.Text = "12"
                        txtFront.Text = "36"
                        txtBack.Text = "36"
                        txtTop.Text = "72"
                        txtBottom.Text = "0"
                        txtLeft.Text = "36"
                    Case Is = "3"
                        txtHeight.Text = "42"
                        txtLength.Text = "89"
                        txtWidth.Text = "59"
                        txtRight.Text = "12"
                        txtFront.Text = "36"
                        txtBack.Text = "36"
                        txtTop.Text = "72"
                        txtBottom.Text = "0"
                        txtLeft.Text = "36"
                End Select

            Case Else
                'Undefined Family Selected.
                txtHeight.Text = "-"
                txtLength.Text = "-"
                txtWidth.Text = "-"
                txtRight.Text = "-"
                txtFront.Text = "-"
                txtBack.Text = "-"
                txtTop.Text = "-"
                txtBottom.Text = "-"
                txtLeft.Text = "-"
        End Select
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
                cmdPasteHeating.Visible = False
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
                cmdPasteHeating.Visible = True
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
                cmdPasteHeating.Visible = True
        End Select
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        frmUPGCertsEntry.ShowDialog()
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

    Private Sub txtHeatLine5_Leave(sender As Object, e As EventArgs) Handles txtHeatLine5.Leave
        Dim EAT, LAT, DeltaT As Double
        If cmbHeatType.Text = "Gas Heat" Then
            EAT = Val(txtHeatLine1.Text)
            LAT = Val(txtHeatLine5.Text)
            DeltaT = LAT - EAT
            txtHeatLine6.Text = Format(DeltaT, "0.0")
        End If
    End Sub

    Private Sub txtHeatLine9_DoubleClick(sender As Object, e As EventArgs) Handles txtHeatLine9.DoubleClick
        If cmbHeatType.Text = "Gas Heat" Then
            If txtHeatLine9.Text = "Staged" Then
                txtHeatLine9.Text = "Modulating"
            Else
                txtHeatLine9.Text = "Staged"
            End If
        End If
    End Sub

    Private Sub txtSFanDuctLoc_DoubleClick(sender As Object, e As EventArgs) Handles txtSFanDuctLoc.DoubleClick
        If txtSFanDuctLoc.Text = "Bottom" Then
            txtSFanDuctLoc.Text = "Side"
        Else
            txtSFanDuctLoc.Text = "Bottom"
        End If
    End Sub

    Public Function getNumeric(myLineItem As String) As String
        Dim tempvar As String
        tempvar = Regex.Match(myLineItem, "((\+|-)?([0-9]+)(\.[0-9]+)?)|((\+|-)?\.?[0-9]+)").Value

        Return tempvar
    End Function
    Private Sub cmdPasteCooling_Click(sender As Object, e As EventArgs) Handles cmdPasteCooling.Click
        Dim ClpBrd As String

        ClpBrd = Clipboard.GetText

        Dim LineItem As String() = ClpBrd.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "TOTAL GROSS") > 0 Then
                txtCoolTCap.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next

        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "SENSIBLE") > 0 Then
                txtCoolSCap.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next

        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "EFFICIENCY") > 0 Then
                txtCoolEffARI.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next

        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "AMBIENT") > 0 Then
                txtCoolAmbientDB.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next

        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "ENTERING DB") > 0 Then
                txtCoolEnteringDB.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next

        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "ENTERING WB") > 0 Then
                txtCoolEnteringWB.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next

        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "LEAVING DB") > 0 Then
                txtCoolLeavingDB.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next

        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "LEAVING WB") > 0 Then
                txtCoolLEavingWB.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next

        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "POWER INPUT") > 0 Then
                txtCoolPower.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next

        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "SOUND POWER") > 0 Then
                txtCoolSoundPower.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
    End Sub

    Private Sub cmdPasteReheat_Click(sender As Object, e As EventArgs) Handles cmdPasteReheat.Click
        Dim ClpBrd As String

        ClpBrd = Clipboard.GetText

        Dim LineItem As String() = ClpBrd.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "TOTAL CAPACITY") > 0 Then
                txtReheatTCap.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "AMBIENT DB") > 0 Then
                txtReheatAmbient.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "ENTERING DB") > 0 Then
                txtReheatEnteringdb.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "ENTERING WB") > 0 Then
                txtReheatEnteringwb.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "LEAVING DB") > 0 Then
                txtReheatLeavingDB.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "LEAVING WB") > 0 Then
                txtReheatLeavingWB.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "POWER INPUT") > 0 Then
                txtReheatPower.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "GALLONS") > 0 Then
                txtReheatGPH.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
    End Sub

    Private Sub cmdPasteHeating_Click(sender As Object, e As EventArgs) Handles cmdPasteHeating.Click
        Dim ClpBrd As String

        ClpBrd = Clipboard.GetText

        Dim LineItem As String() = ClpBrd.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        If cmbHeatType.Text = "Gas Heat" Then
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "ENTERING DB") > 0 Then
                    txtHeatLine1.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "OUTPUT CAPACITY") > 0 Then
                    txtHeatLine2.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "SUPPLY AIR") > 0 Then
                    txtHeatLine3.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "INPUT CAPACITY") > 0 Then
                    txtHeatLine4.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "LEAVING DB") > 0 Then
                    txtHeatLine5.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "TEMP. RISE") > 0 Then
                    txtHeatLine6.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "SSE") > 0 Then
                    txtHeatLine7.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "STAGES") > 0 Then
                    txtHeatLine8.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
        End If

        If cmbHeatType.Text = "Electric" Then
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "ENTERING DB") > 0 Then
                    txtHeatLine1.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1

                If InStr(UCase(LineItem(i)), "HEATING OUTPUT") > 0 Then
                    txtHeatLine2.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "NOMINAL") > 0 Then
                    txtHeatLine3.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "APPLIED") > 0 Then
                    txtHeatLine4.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "INSTALLED") > 0 Then
                    If InStr(UCase(LineItem(i)), "FACTORY") Then
                        txtHeatLine5.Text = "Factory"
                    Else
                        txtHeatLine5.Text = "Field"
                    End If
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1

                If InStr(UCase(LineItem(i)), "SUPPLY AIR") > 0 Then
                    txtHeatLine6.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "LEAVING DB") > 0 Then
                    txtHeatLine7.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
            For i = 0 To LineItem.Length - 1
                If InStr(UCase(LineItem(i)), "TEMP. RISE") > 0 Then
                    txtHeatLine8.Text = getNumeric(LineItem(i))
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cmdPasteSFan_Click(sender As Object, e As EventArgs) Handles cmdPasteSFan.Click
        Dim sTemp As String
        Dim ClpBrd As String
        ClpBrd = Clipboard.GetText

        Dim LineItem As String() = ClpBrd.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "SUPPLY AIR") > 0 Then
                txtSFanAFlow.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "STATIC PRESSURE") > 0 Then
                txtSFanESP.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "BLOWER SPEED") > 0 Then
                txtSFanRPM.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "MAX") > 0 Then
                txtSFanMaxBHP.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "DUCT LOCATION") > 0 Then
                sTemp = Mid(LineItem(i), InStrRev(LineItem(i), " "))
                txtSFanDuctLoc.Text = sTemp
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "MOTOR RATING") > 0 Then
                txtSFanMotorHP.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "REQUIRED") > 0 Then
                txtSFanbhp.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "POWER INPUT") > 0 Then
                txtSFanFanPower.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "ELEVATION") > 0 Then
                txtSFanElevation.Text = getNumeric(LineItem(i))
                Exit For
            End If
        Next
        For i = 0 To LineItem.Length - 1
            If InStr(UCase(LineItem(i)), "DRIVE TYPE") > 0 Then
                sTemp = Mid(LineItem(i), InStrRev(LineItem(i), " "))
                txtSFanDriveType.Text = sTemp
                Exit For
            End If
        Next
    End Sub
End Class