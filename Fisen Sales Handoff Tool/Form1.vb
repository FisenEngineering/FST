Imports System.Xml
Imports System.IO
Imports System.CodeDom.Compiler

Public Class frmMain
    Public MySecurity As New ClsSecurity

    Public UnitBaseUnitFile As String
    Private pversion As String
    Private pbprq As Boolean
    Private pSolutionname As String
    Public ModShopOptionsPresent As Boolean

    Public Property SlnName As String
        Get
            Return "Fisen Sales Handoff Tool"
        End Get
        Set(value As String)
            pSolutionname = value
        End Set
    End Property
    Public Property BypassRequest As Boolean
        Get
            Return pbprq
        End Get
        Set(value As Boolean)
            pbprq = value
        End Set
    End Property
    Private Sub cmdEnterPerformance_Click(sender As Object, e As EventArgs) Handles cmdEnterPerformance.Click
        Dim CanX As Boolean
        CanX = False
        Dim Dummy As MsgBoxResult

        If optSeries5.Checked Then
            frmUPGEntry.ShowDialog()
            CanX = frmUPGEntry.pCancelled

        End If
        If optSeries10.Checked Then
            frmUPGEntry.ShowDialog()
            CanX = frmUPGEntry.pCancelled
        End If
        If optSeries12.Checked Then
            frmUPGEntry.ShowDialog()
            CanX = frmUPGEntry.pCancelled
        End If
        If optSeries20.Checked Then
            frmUPGEntry.ShowDialog()
            CanX = frmUPGEntry.pCancelled
        End If
        If optSeries40.Checked Then
            frmUPGEntry.ShowDialog()
            CanX = frmUPGEntry.pCancelled
        End If

        If optSeriesLX.Checked Then
            frmUPGEntry.ShowDialog()
            CanX = frmUPGEntry.pCancelled
        End If

        If optChoice.Checked Then
            frmUPGEntry.ShowDialog()
            CanX = frmUPGEntry.pCancelled
        End If

        If optSelect.Checked Then
            frmUPGEntry.ShowDialog()
            CanX = frmUPGEntry.pCancelled
        End If

        If optPremier.Checked Then
            frmYPALUnitEntry.ShowDialog()
            CanX = frmYPALUnitEntry.pCancelled
        End If

        If optSeries100.Checked Then
            frmYPALUnitEntry.ShowDialog()
            CanX = frmYPALUnitEntry.pCancelled
        End If

        If optYVAA.Checked Then
            frmYVAAUnitEntry.ShowDialog()
            CanX = frmYVAAUnitEntry.pCancelled
        End If

        If optYLAA.Checked Then
            frmYLAAUnitEntry.ShowDialog()
            CanX = frmYLAAUnitEntry.pCancelled
        End If

        If CanX Then
            Dummy = MsgBox("User Cancelled.")
            End
        Else
            cmdFIOPS.Enabled = True
        End If

        cmdEnterPerformance.Enabled = False
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UnitBaseUnitFile = "C:\Users\jlevine\Desktop\BaseUnitFile.xml"
        cmbBrand.Text = "JCI"
        txtBaseUnitFile.Text = UnitBaseUnitFile
        pversion = Application.ProductVersion
        Me.Text = "Fisen Sales Handoff Tool Version " & pversion
        ModShopOptionsPresent = False
    End Sub

    Private Function UPGUnit() As Boolean
        Dim dummy As Boolean
        dummy = False

        If optSeries5.Checked Then dummy = True
        If optSeries10.Checked Then dummy = True
        If optSeries12.Checked Then dummy = True
        If optSeries20.Checked Then dummy = True
        If optSeries40.Checked Then dummy = True
        If optSeriesLX.Checked Then dummy = True
        If optChoice.Checked Then dummy = True
        If optSelect.Checked Then dummy = True
        If optPremier.Checked Then dummy = True

        UPGUnit = dummy

    End Function

    Private Function YPALUnit() As Boolean
        Dim dummy As Boolean
        dummy = False
        If optSeries100.Checked Then dummy = True

        YPALUnit = dummy
    End Function

    Private Sub SaveTheXMLData()
        Dim myXMLSettings As New XmlWriterSettings
        Dim UnitWriter As XmlWriter
        Dim i As Integer

        myXMLSettings.Indent = True
        myXMLSettings.NewLineOnAttributes = True

        UnitBaseUnitFile = txtBaseUnitFile.Text

        UnitWriter = XmlWriter.Create(UnitBaseUnitFile)
        UnitWriter.WriteComment("Base Unit File by Fisen")
        UnitWriter.WriteStartElement("BaseUnit")
        UnitWriter.WriteString("Base Unit Performance File")
        '***
        UnitWriter.WriteStartElement("ProjectData")
        Call WriteProjectData(UnitWriter, myXMLSettings)
        UnitWriter.WriteEndElement() 'ProjectData
        '***
        UnitWriter.WriteStartElement("CoolingData")
        If UPGUnit() Then Call WriteUPGCoolingData(UnitWriter, myXMLSettings)
        If YPALUnit() Then Call WriteYPALCoolingData(UnitWriter, myXMLSettings)
        If Kingdom() = "Chiller" Then

            Select Case Family()
                Case Is = "YVAA"
                    UnitWriter.WriteStartElement("NominalTons")
                    UnitWriter.WriteString(frmYVAAUnitEntry.txtNominalTons.Text)
                    UnitWriter.WriteEndElement()
                Case Is = "YLAA"
                    UnitWriter.WriteStartElement("NominalTons")
                    UnitWriter.WriteString(frmYLAAUnitEntry.txtNominalTons.Text)
                    UnitWriter.WriteEndElement()

                    UnitWriter.WriteStartElement("Refrigerant")
                    UnitWriter.WriteString(frmYLAAUnitEntry.txtRefrigerant.Text)
                    UnitWriter.WriteEndElement()

                Case Else
                    UnitWriter.WriteComment("Not Applicable to this Unit.")
            End Select

        End If

        UnitWriter.WriteEndElement() 'Cooling Data
        '***
        UnitWriter.WriteStartElement("ReheatData")
        If UPGUnit() Then Call WriteUPGReheatData(UnitWriter, myXMLSettings)
        If Kingdom() = "Chiller" Then
            UnitWriter.WriteComment("Not Applicable to this Unit.")

        End If

        UnitWriter.WriteEndElement() 'ReheatData
        '***
        UnitWriter.WriteStartElement("HeatingData")
        If UPGUnit() Then Call WriteUPGHeatData(UnitWriter, myXMLSettings)
        If YPALUnit() Then Call WriteYPALHeatData(UnitWriter, myXMLSettings)
        If Kingdom() = "Chiller" Then
            UnitWriter.WriteComment("Not Applicable to this Unit.")
        End If

        UnitWriter.WriteEndElement() 'Heating Data
        '***
        UnitWriter.WriteStartElement("SupplyFanData")
        If UPGUnit() Then Call WriteUPGSFanData(UnitWriter, myXMLSettings)
        If YPALUnit() Then Call WriteYPALSFanData(UnitWriter, myXMLSettings)
        If Kingdom() = "Chiller" Then
            UnitWriter.WriteComment("Not Applicable to this Unit.")
        End If

        UnitWriter.WriteEndElement() 'SupplyFanData
        '***
        UnitWriter.WriteStartElement("RXFanData")
        If UPGUnit() Then Call WriteUPGRXFanData(UnitWriter, myXMLSettings)
        If YPALUnit() Then Call WriteYPALRXFanData(UnitWriter, myXMLSettings)
        If Kingdom() = "Chiller" Then
            UnitWriter.WriteComment("Not Applicable to this Unit.")
        End If

        UnitWriter.WriteEndElement() 'RXFanData
        '***

        UnitWriter.WriteStartElement("EvaporatorData")
        If UPGUnit() Then
            UnitWriter.WriteComment("Not Applicable to this Unit.")
        End If
        If YPALUnit() Then
            UnitWriter.WriteComment("Not Applicable to this Unit.")
        End If
        If Family() = "YVAA" Then Call WriteYVAAEvapData(UnitWriter, myXMLSettings)
        If Family() = "YLAA" Then Call WriteYLAAEvapData(UnitWriter, myXMLSettings)

        UnitWriter.WriteEndElement() 'EvapData

        UnitWriter.WriteStartElement("CondenserData")
        If UPGUnit() Then UnitWriter.WriteComment("Not Applicable to this Unit.")
        If YPALUnit() Then UnitWriter.WriteComment("Not Applicable to this Unit.")
        If Family() = "YVAA" Then Call WriteYVAACondenserData(UnitWriter, myXMLSettings)
        If Family() = "YLAA" Then Call WriteYLAACondenserData(UnitWriter, myXMLSettings)

        UnitWriter.WriteEndElement() 'Condenser

        UnitWriter.WriteStartElement("PerformanceData")
        If UPGUnit() Then
            UnitWriter.WriteComment("Not Applicable to this Unit.")
        End If
        If YPALUnit() Then
            UnitWriter.WriteComment("Not Applicable to this Unit.")
        End If
        If Family() = "YVAA" Then Call WriteYVAAPerformanceData(UnitWriter, myXMLSettings)
        If Family() = "YLAA" Then Call WriteYLAAPerformanceData(UnitWriter, myXMLSettings)

        UnitWriter.WriteEndElement() 'Performance

        UnitWriter.WriteStartElement("ElectricalData")
        If UPGUnit() Then Call WriteUPGElectricalData(UnitWriter, myXMLSettings)
        If YPALUnit() Then Call WriteYPALElectricalData(UnitWriter, myXMLSettings)
        If Family() = "YVAA" Then Call WriteYVAAElectricalData(UnitWriter, myXMLSettings)
        If Family() = "YLAA" Then Call WriteYLAAElectricalData(UnitWriter, myXMLSettings)

        UnitWriter.WriteEndElement() 'ElectricalData
        '***

        UnitWriter.WriteStartElement("PhysicalData")
        If UPGUnit() Then Call WriteUPGPhysicalData(UnitWriter, myXMLSettings)
        If YPALUnit() Then Call WriteYPALPhysicalData(UnitWriter, myXMLSettings)
        If Family() = "YVAA" Then Call WriteYVAAPhysicalData(UnitWriter, myXMLSettings)
        If Family() = "YLAA" Then Call WriteYLAAPhysicalData(UnitWriter, myXMLSettings)

        UnitWriter.WriteEndElement() 'PhysicalData
        '***


        UnitWriter.WriteStartElement("FIOPS")
        If UPGUnit() Then Call WriteUPGFIOPS(UnitWriter, myXMLSettings)
        If Family() = "YLAA" Then Call WriteYLAAFIOPS(UnitWriter, myXMLSettings)
        UnitWriter.WriteEndElement() 'FIOPS

        '***


        UnitWriter.WriteStartElement("FieldInstalled")
        If UPGUnit() Then Call WriteUPGFieldInstalled(UnitWriter, myXMLSettings)
        If Family() = "YLAA" Then Call WriteYLAAFieldInstalled(UnitWriter, myXMLSettings)
        UnitWriter.WriteEndElement() 'FIOPS

        '***
        UnitWriter.WriteStartElement("SoundData")
        If YPALUnit() Then Call WriteYPALSoundData(UnitWriter, myXMLSettings)
        If Family() = "YVAA" Then Call WriteYVAASoundData(UnitWriter, myXMLSettings)
        If Family() = "YLAA" Then Call WriteYLAASoundData(UnitWriter, myXMLSettings)

        UnitWriter.WriteEndElement() 'SoundData

        '***
        UnitWriter.WriteStartElement("HydronicData")

        UnitWriter.WriteEndElement() 'HydronicData

        '***
        UnitWriter.WriteStartElement("AuxPerformance")
        If Family() = "YVAA" Then Call WriteYVAAAuxPerformance(UnitWriter, myXMLSettings)
        If Family() = "YLAA" Then Call WriteYLAAAuxPerformance(UnitWriter, myXMLSettings)

        UnitWriter.WriteEndElement() 'AuxPerformance

        '***
        UnitWriter.WriteStartElement("Modifications")
        For i = 0 To lstMods.SelectedItems.Count - 1
            Select Case lstMods.SelectedItems.Item(i)
                Case Is = "HWCoil"
                    Call WriteHWCoilConditions(UnitWriter, myXMLSettings)
            End Select
        Next
        UnitWriter.WriteEndElement() 'Modifications

        UnitWriter.WriteEndElement() 'BaseUnit    
        UnitWriter.Close()

        UnitWriter = Nothing
    End Sub
    Private Sub WriteHWCoilConditions(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("HWCoil")

        lUnitWriter.WriteStartElement("HeatAFlow")
        lUnitWriter.WriteString(frmHWCoil.txtHeatingAirFlow.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("APD")
        lUnitWriter.WriteString(frmHWCoil.txtAPD.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("EAT")
        lUnitWriter.WriteString(frmHWCoil.txtEAT.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Capacity")
        lUnitWriter.WriteString(frmHWCoil.txtCap.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("EFT")
        lUnitWriter.WriteString(frmHWCoil.txtEFT.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FluidFlow")
        lUnitWriter.WriteString(frmHWCoil.txtFluidFlow.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Fluid")
        lUnitWriter.WriteString(frmHWCoil.cmbFluid.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Percent")
        lUnitWriter.WriteString(frmHWCoil.txtPercent.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'HWCoil
    End Sub
    Private Sub cmdWriteUnit_Click(sender As Object, e As EventArgs) Handles cmdWriteUnit.Click
        Call SaveTheXMLData()
        End
    End Sub
    Private Sub WriteUPGFieldInstalled(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)

        Dim cControl As CheckBox
        For Each cControl In frmUPGFieldInstalled.Controls.OfType(Of CheckBox)

            If cControl.Checked Then
                lUnitWriter.WriteStartElement("FieldInstalledItem")
                lUnitWriter.WriteString(cControl.Text)
                lUnitWriter.WriteEndElement()
            End If


        Next


    End Sub
    Private Sub WriteYLAAFieldInstalled(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)

        Dim cControl As CheckBox
        For Each cControl In frmYLAAFieldInstalled.Controls.OfType(Of CheckBox)
            If cControl.Checked Then
                lUnitWriter.WriteStartElement("FieldInstalledItem")
                lUnitWriter.WriteString(cControl.Text)
                lUnitWriter.WriteEndElement()
            End If
        Next


    End Sub
    Private Sub WriteUPGFIOPS(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)

        Dim cControl As CheckBox
        For Each cControl In frmUPGFIOPEntry.Controls.OfType(Of CheckBox)

            If cControl.Checked Then
                lUnitWriter.WriteStartElement("FIOPItem")
                lUnitWriter.WriteString(cControl.Text)
                lUnitWriter.WriteEndElement()
            End If
        Next

        If ModShopOptionsPresent Then
            For Each cControl In frmModShopOptions.Controls.OfType(Of CheckBox)
                If cControl.Checked Then
                    lUnitWriter.WriteStartElement("FIOPItem")
                    lUnitWriter.WriteString(cControl.Text)
                    lUnitWriter.WriteEndElement()
                End If
            Next
        End If


    End Sub

    Private Sub WriteYLAAFIOPS(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)

        Dim cControl As CheckBox
        For Each cControl In frmYLAAFIOPS.Controls.OfType(Of CheckBox)

            If cControl.Checked Then
                lUnitWriter.WriteStartElement("FIOPItem")
                lUnitWriter.WriteString(cControl.Text)
                lUnitWriter.WriteEndElement()
            End If
        Next


    End Sub

    Private Sub WriteYLAACondenserData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtAmbient.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Altitude")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtAltitude.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompType")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtCompressorType.Text)
        lUnitWriter.WriteEndElement()

    End Sub

    Private Sub WriteYVAACondenserData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtAmbient.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Altitude")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtAltitude.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompType")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtCompressorType.Text)
        lUnitWriter.WriteEndElement()

    End Sub

    Private Sub WriteYLAAPerformanceData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("EER")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtEER.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("NPLV")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtNPLV.Text)
        lUnitWriter.WriteEndElement()

    End Sub

    Private Sub WriteYVAAPerformanceData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("EER")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtEER.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("NPLV")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtNPLV.Text)
        lUnitWriter.WriteEndElement()

    End Sub

    Private Sub WriteYLAAAuxPerformance(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        Dim i As Integer
        Dim ControlName As String
        Dim MyControl As TextBox

        For i = 1 To 6
            lUnitWriter.WriteStartElement("Stage" & Trim(Str(i)))

            lUnitWriter.WriteStartElement("Ambient")
            ControlName = "txtAmbient_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpPartLoad.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("Capacity")
            ControlName = "txtCapacity_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpPartLoad.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("TotalkW")
            ControlName = "txtkW_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpPartLoad.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("Efficiency")
            ControlName = "txtEfficiency_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpPartLoad.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteEndElement() 'stage i
        Next i

        lUnitWriter.WriteStartElement("EWT")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtEWT.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LWT")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtLWT.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Flow")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtFlow.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TPD")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtTPD.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Fluid")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtFluid.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FoulFactor")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtFoulFactor.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Volume")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtFluidVolume.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtAmbient.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Altitude")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtAltitude.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("EER")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtEER.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("NPLV")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtNPLV.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CoolCap")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtnetCap.Text)
        lUnitWriter.WriteEndElement()

    End Sub

    Private Sub WriteYVAAAuxPerformance(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("Load100")

        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtAmbient100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Capacity")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtCapacity100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TotalkW")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtkW100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Efficiency")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtEfficiency100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Load100

        lUnitWriter.WriteStartElement("Load75")

        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtAmbient75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Capacity")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtCapacity75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TotalkW")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtkW75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Efficiency")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtEfficiency75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Load75

        lUnitWriter.WriteStartElement("Load50")

        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtAmbient50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Capacity")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtCapacity50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TotalkW")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtkW50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Efficiency")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtEfficiency50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Load50

        lUnitWriter.WriteStartElement("Load25")

        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtAmbient25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Capacity")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtCapacity25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TotalkW")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtkW25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Efficiency")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtEfficiency25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Load25

        lUnitWriter.WriteStartElement("EWT")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtEWT.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LWT")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtLWT.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Flow")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtFlow.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TPD")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtTPD.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Fluid")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtFluid.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FoulFactor")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtFoulFactor.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Volume")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtFluidVolume.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtAmbient.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Altitude")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtAltitude.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("EER")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtEER.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("NPLV")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtNPLV.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CoolCap")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtnetCap.Text)
        lUnitWriter.WriteEndElement()

    End Sub

    Private Sub WriteYLAAPhysicalData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("RigWeight")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtRigWeight.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("OpWeight")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtOpWeight.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("RefCharge")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtRefCharge.Text)
        lUnitWriter.WriteEndElement()

        Call WriteChillerPointLoads(lUnitWriter, lsettings)

        lUnitWriter.WriteStartElement("Notes")
        lUnitWriter.WriteString(frmYLAAEntryPage1.txtNotes.Text)
        lUnitWriter.WriteEndElement()

    End Sub

    Private Sub WriteYVAAPhysicalData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("RigWeight")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtRigWeight.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("OpWeight")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtOpWeight.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("RefCharge")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtRefCharge.Text)
        lUnitWriter.WriteEndElement()

        Call WriteChillerPointLoads(lUnitWriter, lsettings)

        lUnitWriter.WriteStartElement("Notes")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtNotes.Text)
        lUnitWriter.WriteEndElement()

    End Sub

    Private Sub WriteChillerPointLoads(xUnitWriter As XmlWriter, xsettings As XmlWriterSettings)
        Dim TopofLoop As Integer
        Dim PointLoad As String
        Dim MyTextBox As TextBox
        Dim ControlName As String
        Dim i As Integer

        TopofLoop = frmPointLoads.NumericUpDown1.Value

        xUnitWriter.WriteStartElement("PointLoads")

        xUnitWriter.WriteStartElement("NumberofLoads")
        xUnitWriter.WriteString(Trim(Str(TopofLoop)))
        xUnitWriter.WriteEndElement()

        For i = 1 To TopofLoop / 2
            xUnitWriter.WriteStartElement("R" & Trim(Str(i)))

            xUnitWriter.WriteStartElement("XDist")
            ControlName = "txtXR" & Trim(Str(i))
            MyTextBox = frmPointLoads.Controls.Item(ControlName)
            PointLoad = MyTextBox.Text
            xUnitWriter.WriteString(PointLoad)
            xUnitWriter.WriteEndElement() 'XDist

            xUnitWriter.WriteStartElement("YDist")
            ControlName = "txtYR" & Trim(Str(i))
            MyTextBox = frmPointLoads.Controls.Item(ControlName)
            PointLoad = MyTextBox.Text
            xUnitWriter.WriteString(PointLoad)
            xUnitWriter.WriteEndElement() 'YDist

            xUnitWriter.WriteStartElement("Weight")
            ControlName = "txtOpWtR" & Trim(Str(i))
            MyTextBox = frmPointLoads.Controls.Item(ControlName)
            PointLoad = MyTextBox.Text
            xUnitWriter.WriteString(PointLoad)
            xUnitWriter.WriteEndElement() 'Weight

            xUnitWriter.WriteEndElement() 'Ri
        Next i
        For i = 1 To TopofLoop / 2
            xUnitWriter.WriteStartElement("L" & Trim(Str(i)))

            xUnitWriter.WriteStartElement("XDist")
            ControlName = "txtXL" & Trim(Str(i))
            MyTextBox = frmPointLoads.Controls.Item(ControlName)
            PointLoad = MyTextBox.Text
            xUnitWriter.WriteString(PointLoad)
            xUnitWriter.WriteEndElement() 'XDist

            xUnitWriter.WriteStartElement("YDist")
            ControlName = "txtYL" & Trim(Str(i))
            MyTextBox = frmPointLoads.Controls.Item(ControlName)
            PointLoad = MyTextBox.Text
            xUnitWriter.WriteString(PointLoad)
            xUnitWriter.WriteEndElement() 'YDist

            xUnitWriter.WriteStartElement("Weight")
            ControlName = "txtOpWtL" & Trim(Str(i))
            MyTextBox = frmPointLoads.Controls.Item(ControlName)
            PointLoad = MyTextBox.Text
            xUnitWriter.WriteString(PointLoad)
            xUnitWriter.WriteEndElement() 'Weight

            xUnitWriter.WriteEndElement() 'Li
        Next i
        xUnitWriter.WriteEndElement() 'PointLoads

    End Sub

    Private Sub WriteYLAAEvapData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("EWT")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtEWT.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LWT")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtLWT.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FlowRate")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtFlowRate.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("EvapPD")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtEvapPD.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Fluid")
        lUnitWriter.WriteString(frmYLAAUnitEntry.cmbFluid.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Percent")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtPercent.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("StrainerPD")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtStrainerPD.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("ExtKitPD")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtExtKitPD.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TPD")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtTPD.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FoulFactor")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtFoulFactor.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FluidVolume")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtFluidVolume.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MinFlow")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtMinFlowRate.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MaxFlow")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtMaxFlowRate.Text)
        lUnitWriter.WriteEndElement()

    End Sub

    Private Sub WriteYVAAEvapData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("EWT")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtEWT.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LWT")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtLWT.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FlowRate")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtFlowRate.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TPD")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtTPD.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Fluid")
        lUnitWriter.WriteString(frmYVAAUnitEntry.cmbFluid.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Percent")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtPercent.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FoulFactor")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtFoulFactor.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("NumPass")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtNumberPasses.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FluidVolume")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtFluidVolume.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MinFlow")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtMinFlowRate.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MaxFlow")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtMaxFlowRate.Text)
        lUnitWriter.WriteEndElement()

    End Sub

    Private Sub WriteYLAASoundData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        Dim i As Integer
        Dim ControlName As String
        Dim MyControl As TextBox

        lUnitWriter.WriteStartElement("SoundType")
        lUnitWriter.WriteString(frmYLAAEntryPage1.lstSoundDescription.GetItemText(frmYLAAEntryPage1.lstSoundDescription.SelectedItem))
        lUnitWriter.WriteEndElement()

        For i = 1 To 6

            lUnitWriter.WriteStartElement("Stage" & Trim(Str(i)))

            lUnitWriter.WriteStartElement("Ambient")
            ControlName = "txtSoundAmbient" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpSound.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("v63")
            ControlName = "txtSPL63_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpSound.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("v125")
            ControlName = "txtSPL125_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpSound.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("v250")
            ControlName = "txtSPL250_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpSound.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("v500")
            ControlName = "txtSPL500_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpSound.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("v1k")
            ControlName = "txtSPL1k_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpSound.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("v2k")
            ControlName = "txtSPL2k_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpSound.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("v4k")
            ControlName = "txtSPL4k_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpSound.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("v8k")
            ControlName = "txtSPL8k_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpSound.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("dBA")
            ControlName = "txtSPLLWA_" & Trim(Str(i))
            MyControl = frmYLAAEntryPage1.grpSound.Controls.Item(ControlName)
            lUnitWriter.WriteString(MyControl.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteEndElement() 'Leveli
        Next i
    End Sub

    Private Sub WriteYVAASoundData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("Level100")
        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSoundAmbient100.Text)
        lUnitWriter.WriteEndElement()


        lUnitWriter.WriteStartElement("v63")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL63_100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v125")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL125_100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v250")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL250_100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v500")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL500_100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v1k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL1k_100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v2k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL2k_100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v4k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL4k_100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v8k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL8k_100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("dBA")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPLLWA_100.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Level100

        lUnitWriter.WriteStartElement("Level75")
        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSoundAmbient75.Text)
        lUnitWriter.WriteEndElement()


        lUnitWriter.WriteStartElement("v63")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL63_75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v125")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL125_75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v250")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL250_75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v500")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL500_75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v1k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL1k_75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v2k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL2k_75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v4k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL4k_75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v8k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL8k_75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("dBA")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPLLWA_75.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Level75

        lUnitWriter.WriteStartElement("Level50")
        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSoundAmbient50.Text)
        lUnitWriter.WriteEndElement()


        lUnitWriter.WriteStartElement("v63")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL63_50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v125")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL125_50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v250")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL250_50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v500")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL500_50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v1k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL1k_50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v2k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL2k_50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v4k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL4k_50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v8k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL8k_50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("dBA")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPLLWA_50.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Level50

        lUnitWriter.WriteStartElement("Level25")
        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSoundAmbient25.Text)
        lUnitWriter.WriteEndElement()


        lUnitWriter.WriteStartElement("v63")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL63_25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v125")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL125_25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v250")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL250_25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v500")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL500_25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v1k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL1k_25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v2k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL2k_25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v4k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL4k_25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v8k")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPL8k_25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("dBA")
        lUnitWriter.WriteString(frmYVAAEntryPage1.txtSPLLWA_25.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Level25


    End Sub

    Private Sub WriteYPALSoundData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("DuctedDischarge")

        lUnitWriter.WriteStartElement("v63")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDD63.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v125")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDD125.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v250")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDD250.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v500")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDD500.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v1k")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDD1k.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v2k")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDD2k.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v4k")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDD4k.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v8k")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDD8k.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("dBA")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDDdBA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Ducted Discharge

        lUnitWriter.WriteStartElement("DuctedInlet")

        lUnitWriter.WriteStartElement("v63")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDI63.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v125")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDI125.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v250")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDI250.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v500")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDI500.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v1k")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDI1k.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v2k")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDI2k.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v4k")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDI4k.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v8k")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDI8k.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("dBA")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDIdBA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Ducted Inlet

        lUnitWriter.WriteStartElement("Radiated")

        lUnitWriter.WriteStartElement("v63")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRad63.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v125")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRad125.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v250")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRad250.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v500")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRad500.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v1k")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRad1k.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v2k")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRad2k.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v4k")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRad4k.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("v8k")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRad8k.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("dBA")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRaddBA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Radiated

    End Sub
    Private Sub WriteYPALPhysicalData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("Height")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtHeight.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Length")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtLength.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Width")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtWidth.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Weight")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtWeight.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("UnitSize")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtUnitSize.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("AWeight")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtAWeight.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("BWeight")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtBWeight.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CWeight")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCWeight.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("DWeight")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtDWeight.Text)
        lUnitWriter.WriteEndElement()



    End Sub
    Private Sub WriteUPGPhysicalData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("Height")
        lUnitWriter.WriteString(frmUPGEntry.txtHeight.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Length")
        lUnitWriter.WriteString(frmUPGEntry.txtLength.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Width")
        lUnitWriter.WriteString(frmUPGEntry.txtWidth.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Weight")
        lUnitWriter.WriteString(frmUPGEntry.txtWeight.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Right")
        lUnitWriter.WriteString(frmUPGEntry.txtRight.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Front")
        lUnitWriter.WriteString(frmUPGEntry.txtFront.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Back")
        lUnitWriter.WriteString(frmUPGEntry.txtBack.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Top")
        lUnitWriter.WriteString(frmUPGEntry.txtTop.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Bottom")
        lUnitWriter.WriteString(frmUPGEntry.txtBottom.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Left")
        lUnitWriter.WriteString(frmUPGEntry.txtLeft.Text)
        lUnitWriter.WriteEndElement()

    End Sub

    Private Sub WriteYLAAElectricalData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("Volts")
        lUnitWriter.WriteString(frmYLAAUnitEntry.cmbPowerSupply.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Phase")
        lUnitWriter.WriteString("3")
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Frequency")
        lUnitWriter.WriteString("60")
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MCA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtMCA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("RecFuse")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtRecFuse.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MaxITCB")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtMaxCB.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MOP")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtMaxDEFuse.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("SCCR")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtSCCR.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("WiresPerPhase")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtWiresperPhase.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LugSize")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtLugSize.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("StarterType")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtStarterType.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorkW")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtCompressorKW.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TotalFankW")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtTotalFankW.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TotalkW")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtTotalkWLessHydro.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TotalWithHydroKitkW")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtTotalKW.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Circuit1")

        lUnitWriter.WriteStartElement("CompressorARLA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtComp1ARLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorBRLA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtComp1BRLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorCRLA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtComp1CRLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CFanQty")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtFanQty1.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CFanFLA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtFanFLAea1.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorALRA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtComp1ALRA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorBLRA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtComp1BLRA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorCLRA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtComp1CLRA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Circuit 1

        lUnitWriter.WriteStartElement("Circuit2")

        lUnitWriter.WriteStartElement("CompressorARLA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtComp2ARLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorBRLA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtComp2BRLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorCRLA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtComp2CRLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CFanQty")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtFanQty2.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CFanFLA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtFanFLAea2.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorALRA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtComp2ALRA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorBLRA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtComp2BLRA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorCLRA")
        lUnitWriter.WriteString(frmYLAAUnitEntry.txtComp2CLRA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Circuit 2
    End Sub

    Private Sub WriteYVAAElectricalData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("Volts")
        lUnitWriter.WriteString(frmYVAAUnitEntry.cmbPowerSupply.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Phase")
        lUnitWriter.WriteString("3")
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Frequency")
        lUnitWriter.WriteString("60")
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MCA")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtMCA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MinFuse")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtMinFuse.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MOP")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtMOP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("SCCR")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtSCCR.Text)
        lUnitWriter.WriteEndElement()


        lUnitWriter.WriteStartElement("WiresPerPhase")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtWiresperPhase.Text)
        lUnitWriter.WriteEndElement()


        lUnitWriter.WriteStartElement("LugSize")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtLugSize.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("PowerFactor")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtPowerFactor.Text)
        lUnitWriter.WriteEndElement()


        lUnitWriter.WriteStartElement("ControlKVA")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtControlKVA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorkW")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtCompressorKW.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TotalkW")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtTotalKW.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Circuit1")

        lUnitWriter.WriteStartElement("CompressorkW")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtComp1kW.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorRLA")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtComp1RLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CFanQty")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtFanQty1.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CFanFLA")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtFanFLA1.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Circuit 1

        lUnitWriter.WriteStartElement("Circuit2")

        lUnitWriter.WriteStartElement("CompressorkW")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtComp2kW.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorRLA")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtComp2RLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CFanQty")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtFanQty2.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CFanFLA")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtFanFLA2.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Circuit 2

        lUnitWriter.WriteStartElement("Circuit3")

        lUnitWriter.WriteStartElement("CompressorkW")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtComp3kW.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorRLA")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtComp3RLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CFanQty")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtFanQty3.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CFanFLA")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtFanFLA3.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Circuit 3

        lUnitWriter.WriteStartElement("Circuit4")

        lUnitWriter.WriteStartElement("CompressorkW")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtComp4kW.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CompressorRLA")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtComp4RLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CFanQty")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtFanQty4.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CFanFLA")
        lUnitWriter.WriteString(frmYVAAUnitEntry.txtFanFLA4.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteEndElement() 'Circuit 4

    End Sub
    Private Sub WriteYPALElectricalData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)

        lUnitWriter.WriteStartElement("Volts")
        lUnitWriter.WriteString(frmYPALUnitEntry.cmbPowerSupply.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Phase")
        lUnitWriter.WriteString("3")
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Frequency")
        lUnitWriter.WriteString("60")
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MCA")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtMCA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MOP")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtMOP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CondenserFansFLA")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCFanFLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("SupplyFanFLA")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtSFanFLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("RXFanFLA")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRXFanFLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("ControlTransformerFLA")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCtrlXfmrFLA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CC1A")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCC1A.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CC1B")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCC1B.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CC2A")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCC2A.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CC2B")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCC2B.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CC3A")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCC3A.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("CC3B")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCC3B.Text)
        lUnitWriter.WriteEndElement()



    End Sub

    Private Sub WriteUPGElectricalData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("Volts")
        lUnitWriter.WriteString(frmUPGEntry.cmbVolts.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Phase")
        If frmUPGEntry.opt3Phasex.Checked Then
            lUnitWriter.WriteString("3")
        Else
            lUnitWriter.WriteString("1")
        End If
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Frequency")
        lUnitWriter.WriteString("60")
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MCA")
        lUnitWriter.WriteString(frmUPGEntry.txtMCA.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MOP")
        lUnitWriter.WriteString(frmUPGEntry.txtMOP.Text)
        lUnitWriter.WriteEndElement()

    End Sub
    Private Sub WriteUPGRXFanData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("Present")
        If frmUPGEntry.optRXFanPresent.Checked Then
            lUnitWriter.WriteString("True")
        Else
            lUnitWriter.WriteString("False")
        End If
        lUnitWriter.WriteEndElement()


        lUnitWriter.WriteStartElement("Airflow")
        lUnitWriter.WriteString(frmUPGEntry.txtRXFanAFlow.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("ESP")
        lUnitWriter.WriteString(frmUPGEntry.txtRXFanESP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("RPM")
        lUnitWriter.WriteString(frmUPGEntry.txtRXFanRPM.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MotorMaxBHP")
        lUnitWriter.WriteString(frmUPGEntry.txtRXFanMaxBHP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("DuctLoc")
        lUnitWriter.WriteString(frmUPGEntry.txtRXFanDuctLoc.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MotorHP")
        lUnitWriter.WriteString(frmUPGEntry.txtRXFanMotorHP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("BHP")
        lUnitWriter.WriteString(frmUPGEntry.txtRXFanbhp.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FankW")
        lUnitWriter.WriteString(frmUPGEntry.txtRXFanFanPower.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("DriveType")
        lUnitWriter.WriteString(frmUPGEntry.txtRXFanDriveType.Text)
        lUnitWriter.WriteEndElement()

    End Sub
    Private Sub WriteYPALRXFanData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        If frmYPALUnitEntry.optNoFan.Checked Then
            lUnitWriter.WriteStartElement("FanType")
            lUnitWriter.WriteString("-")
            lUnitWriter.WriteEndElement()
        End If

        If frmYPALUnitEntry.optRFan.Checked Then
            lUnitWriter.WriteStartElement("FanType")
            lUnitWriter.WriteString("Return")
            lUnitWriter.WriteEndElement()
        End If

        If frmYPALUnitEntry.optXFan.Checked Then
            lUnitWriter.WriteStartElement("FanType")
            lUnitWriter.WriteString("Exhaust")
            lUnitWriter.WriteEndElement()
        End If

        lUnitWriter.WriteStartElement("Airflow")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRXFanAFlow.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("ESP")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRXFanESP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FanName")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRXFanFan.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("RPM")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRXFanRPM.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MotorText")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRXFanMotor.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MotorHP")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRXFanMHP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("BHP")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRXFanBHP.Text)
        lUnitWriter.WriteEndElement()

    End Sub
    Private Sub WriteYPALSFanData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("Airflow")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtSFanAFlow.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("ESP")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtSFanESP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FanName")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtSFanFan.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("RPM")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtSFanRPM.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MotorText")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtSFanMotor.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MotorHP")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtSFanMHP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("BHP")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtSFanBHP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Elevation")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtAltitude.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("StaticPressureSummary")
        If frmYPALUnitEntry.cmbSPSLabel1.Text <> "N/A" Then
            lUnitWriter.WriteStartElement("Item")
            lUnitWriter.WriteStartElement("Name")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSLabel1.Text)
            lUnitWriter.WriteEndElement() 'Name
            lUnitWriter.WriteStartElement("Value")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSValue1.Text)
            lUnitWriter.WriteEndElement() 'Value
            lUnitWriter.WriteEndElement() 'Item

        End If

        If frmYPALUnitEntry.cmbSPSLabel2.Text <> "N/A" Then
            lUnitWriter.WriteStartElement("Item")
            lUnitWriter.WriteStartElement("Name")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSLabel2.Text)
            lUnitWriter.WriteEndElement() 'Name
            lUnitWriter.WriteStartElement("Value")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSValue2.Text)
            lUnitWriter.WriteEndElement() 'Value
            lUnitWriter.WriteEndElement() 'Item

        End If

        If frmYPALUnitEntry.cmbSPSLabel3.Text <> "N/A" Then
            lUnitWriter.WriteStartElement("Item")
            lUnitWriter.WriteStartElement("Name")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSLabel3.Text)
            lUnitWriter.WriteEndElement() 'Name
            lUnitWriter.WriteStartElement("Value")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSValue3.Text)
            lUnitWriter.WriteEndElement() 'Value
            lUnitWriter.WriteEndElement() 'Item

        End If

        If frmYPALUnitEntry.cmbSPSLabel4.Text <> "N/A" Then
            lUnitWriter.WriteStartElement("Item")
            lUnitWriter.WriteStartElement("Name")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSLabel4.Text)
            lUnitWriter.WriteEndElement() 'Name
            lUnitWriter.WriteStartElement("Value")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSValue4.Text)
            lUnitWriter.WriteEndElement() 'Value
            lUnitWriter.WriteEndElement() 'Item

        End If

        If frmYPALUnitEntry.cmbSPSLabel5.Text <> "N/A" Then
            lUnitWriter.WriteStartElement("Item")
            lUnitWriter.WriteStartElement("Name")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSLabel5.Text)
            lUnitWriter.WriteEndElement() 'Name
            lUnitWriter.WriteStartElement("Value")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSValue5.Text)
            lUnitWriter.WriteEndElement() 'Value
            lUnitWriter.WriteEndElement() 'Item

        End If

        If frmYPALUnitEntry.cmbSPSLabel6.Text <> "N/A" Then
            lUnitWriter.WriteStartElement("Item")
            lUnitWriter.WriteStartElement("Name")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSLabel6.Text)
            lUnitWriter.WriteEndElement() 'Name
            lUnitWriter.WriteStartElement("Value")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSValue6.Text)
            lUnitWriter.WriteEndElement() 'Value
            lUnitWriter.WriteEndElement() 'Item

        End If

        If frmYPALUnitEntry.cmbSPSLabel7.Text <> "N/A" Then
            lUnitWriter.WriteStartElement("Item")
            lUnitWriter.WriteStartElement("Name")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSLabel7.Text)
            lUnitWriter.WriteEndElement() 'Name
            lUnitWriter.WriteStartElement("Value")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSValue7.Text)
            lUnitWriter.WriteEndElement() 'Value
            lUnitWriter.WriteEndElement() 'Item

        End If

        If frmYPALUnitEntry.cmbSPSLabel8.Text <> "N/A" Then
            lUnitWriter.WriteStartElement("Item")
            lUnitWriter.WriteStartElement("Name")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSLabel8.Text)
            lUnitWriter.WriteEndElement() 'Name
            lUnitWriter.WriteStartElement("Value")
            lUnitWriter.WriteString(frmYPALUnitEntry.cmbSPSValue8.Text)
            lUnitWriter.WriteEndElement() 'Value
            lUnitWriter.WriteEndElement() 'Item

        End If

        lUnitWriter.WriteStartElement("TSP")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtTotalStatic.Text)
        lUnitWriter.WriteEndElement()


        lUnitWriter.WriteEndElement() 'StaticPressure Summary

    End Sub
    Private Sub WriteUPGSFanData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("Airflow")
        lUnitWriter.WriteString(frmUPGEntry.txtSFanAFlow.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("ESP")
        lUnitWriter.WriteString(frmUPGEntry.txtSFanESP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("RPM")
        lUnitWriter.WriteString(frmUPGEntry.txtSFanRPM.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MotorMaxBHP")
        lUnitWriter.WriteString(frmUPGEntry.txtSFanMaxBHP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("DuctLoc")
        lUnitWriter.WriteString(frmUPGEntry.txtSFanDuctLoc.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("MotorHP")
        lUnitWriter.WriteString(frmUPGEntry.txtSFanMotorHP.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("BHP")
        lUnitWriter.WriteString(frmUPGEntry.txtSFanbhp.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FankW")
        lUnitWriter.WriteString(frmUPGEntry.txtSFanFanPower.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Elevation")
        lUnitWriter.WriteString(frmUPGEntry.txtSFanElevation.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("DriveType")
        lUnitWriter.WriteString(frmUPGEntry.txtSFanDriveType.Text)
        lUnitWriter.WriteEndElement()


    End Sub
    Private Sub WriteYPALHeatData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("HeatType")
        lUnitWriter.WriteString(frmYPALUnitEntry.cmbHeatType.Text)
        lUnitWriter.WriteEndElement()
        If frmYPALUnitEntry.cmbHeatType.Text = "Gas Heat" Then

            lUnitWriter.WriteStartElement("CapOut")
            lUnitWriter.WriteString(frmYPALUnitEntry.txtHeatLine1.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("CapIn")
            lUnitWriter.WriteString(frmYPALUnitEntry.txtHeatLine2.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("GasConsumption")
            lUnitWriter.WriteString(frmYPALUnitEntry.txtHeatLine3.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("GasHeatContent")
            lUnitWriter.WriteString(frmYPALUnitEntry.txtHeatLine4.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("EATdb")
            lUnitWriter.WriteString(frmYPALUnitEntry.txtHeatLine5.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("LATdb")
            lUnitWriter.WriteString(frmYPALUnitEntry.txtHeatLine6.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("HeatAirflow")
            lUnitWriter.WriteString(frmYPALUnitEntry.txtAirflow.Text)
            lUnitWriter.WriteEndElement()
        End If

        If frmYPALUnitEntry.cmbHeatType.Text = "None" Then
            'Do Nothing
        End If


    End Sub
    Private Sub WriteUPGHeatData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("HeatType")
        lUnitWriter.WriteString(frmUPGEntry.cmbHeatType.Text)
        lUnitWriter.WriteEndElement()
        If frmUPGEntry.cmbHeatType.Text = "Gas Heat" Then
            lUnitWriter.WriteStartElement("EATdb")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine1.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("CapOut")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine2.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("HeatAirflow")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine3.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("CapIn")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine4.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("LATdb")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine5.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("SSE")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine7.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("Stages")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine8.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("ControlStyle")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine9.Text)
            lUnitWriter.WriteEndElement()
        End If

        If frmUPGEntry.cmbHeatType.Text = "None" Then
            'Do Nothing
        End If

        If frmUPGEntry.cmbHeatType.Text = "Electric" Then
            lUnitWriter.WriteStartElement("EATdb")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine1.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("CapOut")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine2.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("NominalElectricHeat")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine3.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("AppliedElectricHeat")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine4.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("Installed")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine5.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("SupplyAir")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine6.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("LeavingDB")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine7.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("AirTempRise")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine7.Text)
            lUnitWriter.WriteEndElement()

            lUnitWriter.WriteStartElement("ControlStyle")
            lUnitWriter.WriteString(frmUPGEntry.txtHeatLine9.Text)
            lUnitWriter.WriteEndElement()


        End If

    End Sub
    Private Sub WriteUPGReheatData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)

        lUnitWriter.WriteStartElement("ReheatStyle")
        lUnitWriter.WriteString(frmUPGEntry.cmbReheatStyle.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("TCap")
        lUnitWriter.WriteString(frmUPGEntry.txtReheatTCap.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmUPGEntry.txtReheatAmbient.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("EATdb")
        lUnitWriter.WriteString(frmUPGEntry.txtReheatEnteringdb.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("EATwb")
        lUnitWriter.WriteString(frmUPGEntry.txtReheatEnteringwb.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LATdb")
        lUnitWriter.WriteString(frmUPGEntry.txtReheatLeavingDB.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LATwb")
        lUnitWriter.WriteString(frmUPGEntry.txtReheatLeavingWB.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Power")
        lUnitWriter.WriteString(frmUPGEntry.txtReheatPower.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("GPH")
        lUnitWriter.WriteString(frmUPGEntry.txtReheatGPH.Text)
        lUnitWriter.WriteEndElement()

    End Sub
    Private Sub WriteUPGCoolingData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("TCap")
        lUnitWriter.WriteString(frmUPGEntry.txtCoolTCap.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("SCap")
        lUnitWriter.WriteString(frmUPGEntry.txtCoolSCap.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Eff")
        lUnitWriter.WriteString(frmUPGEntry.txtCoolEffARI.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmUPGEntry.txtCoolAmbientDB.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("EATdb")
        lUnitWriter.WriteString(frmUPGEntry.txtCoolEnteringDB.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("EATwb")
        lUnitWriter.WriteString(frmUPGEntry.txtCoolEnteringWB.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LATdb")
        lUnitWriter.WriteString(frmUPGEntry.txtCoolLeavingDB.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LATwb")
        lUnitWriter.WriteString(frmUPGEntry.txtCoolLEavingWB.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Power")
        lUnitWriter.WriteString(frmUPGEntry.txtCoolPower.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("SoundPower")
        lUnitWriter.WriteString(frmUPGEntry.txtCoolSoundPower.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Refrigerant")
        lUnitWriter.WriteString(frmUPGEntry.txtRefrigerant.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("NominalTons")
        lUnitWriter.WriteString(frmUPGEntry.txtNominalTons.Text)
        lUnitWriter.WriteEndElement()
    End Sub

    Private Sub WriteYPALCoolingData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        lUnitWriter.WriteStartElement("TCap")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCoolTCap.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("SCap")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCoolSCap.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("EATdb")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCoolEnteringDB.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("EATwb")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCoolEnteringWB.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LATdb")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCoolLeavingDBcoil.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LATwb")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCoolLEavingWBcoil.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LATdbUnit")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCoolLEavingDBunit.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("LATwbUnit")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCoolLEavingWBunit.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("FaceVelocity")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCoolFaceVel.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Power")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCoolPower.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("EER")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCoolEERatARI.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("IEER")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtCoolIEERatARI.Text)
        lUnitWriter.WriteEndElement()


        lUnitWriter.WriteStartElement("Ambient")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtUnitDataAmbientDB.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("SoundPower")
        lUnitWriter.WriteString("-")
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Refrigerant")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtRefrigerant.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("NominalTons")
        lUnitWriter.WriteString(frmYPALUnitEntry.txtNominalTons.Text)
        lUnitWriter.WriteEndElement()
    End Sub
    Private Sub WriteProjectData(lUnitWriter As XmlWriter, lsettings As XmlWriterSettings)
        Dim Dummy As MsgBoxResult

        lUnitWriter.WriteStartElement("JobNumber")
        lUnitWriter.WriteString(txtJobNumber.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("UnitNumber")
        lUnitWriter.WriteString(txtUnitNum.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("ProjectName")
        lUnitWriter.WriteString(txtProjectName.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Quantity")
        lUnitWriter.WriteString(txtQty.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("UTag")
        lUnitWriter.WriteString(txtTag.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Brand")
        lUnitWriter.WriteString(cmbBrand.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("BrandModelNum")
        lUnitWriter.WriteString(txtBrandModelNum.Text)
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Kingdom")
        lUnitWriter.WriteString(Kingdom())
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Family")
        lUnitWriter.WriteString(Family())
        lUnitWriter.WriteEndElement()

        lUnitWriter.WriteStartElement("Notes")
        Select Case Family()
            Case Is = "Series100"
                lUnitWriter.WriteString(frmYPALUnitEntry.txtNotes.Text)
            Case Else
                lUnitWriter.WriteString("-")

        End Select
        lUnitWriter.WriteEndElement()

        Select Case Family()
            Case Is = "Series100"
                lUnitWriter.WriteStartElement("UnitSize")
                lUnitWriter.WriteString(frmYPALUnitEntry.txtUnitSize.Text)
                lUnitWriter.WriteEndElement()
            Case Is = "YVAA"
                Call WriteYVAAPIN(lUnitWriter, lsettings)
            Case Is = "YLAA"
                Call WriteYLAAPIN(lUnitWriter, lsettings)
        End Select

        lUnitWriter.WriteStartElement("ModCodes")
        lUnitWriter.WriteString(txtModList.Text)
        lUnitWriter.WriteEndElement()

        Dummy = MsgBox("Is the Base Unit 65k SCCR Rated?", vbYesNo, "Fisen Sales Tool")
        lUnitWriter.WriteStartElement("ModCodes")
        If Dummy = vbYes Then
            lUnitWriter.WriteString("True")
        Else
            lUnitWriter.WriteString("False")
        End If
        lUnitWriter.WriteEndElement()
    End Sub

    Private Sub WriteYLAAPIN(mUnitWriter As XmlWriter, msettings As XmlWriterSettings)
        mUnitWriter.WriteStartElement("PIN")

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYLAAUnitEntry.txtPIN10.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYLAAUnitEntry.txtPIN20.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYLAAUnitEntry.txtPIN30.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYLAAUnitEntry.txtPIN40.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYLAAUnitEntry.txtPIN50.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYLAAUnitEntry.txtPIN60.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYLAAUnitEntry.txtPIN70.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYLAAUnitEntry.txtPIN80.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYLAAUnitEntry.txtPIN90.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteEndElement() 'PIN
    End Sub

    Private Sub WriteYVAAPIN(mUnitWriter As XmlWriter, msettings As XmlWriterSettings)
        mUnitWriter.WriteStartElement("PIN")

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYVAAUnitEntry.txtPIN10.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYVAAUnitEntry.txtPIN20.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYVAAUnitEntry.txtPIN30.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYVAAUnitEntry.txtPIN40.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYVAAUnitEntry.txtPIN50.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYVAAUnitEntry.txtPIN60.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYVAAUnitEntry.txtPIN70.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYVAAUnitEntry.txtPIN80.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteStartElement("PIN")
        mUnitWriter.WriteString(frmYVAAUnitEntry.txtPIN90.Text)
        mUnitWriter.WriteEndElement() 'PIN Group

        mUnitWriter.WriteEndElement() 'PIN
    End Sub


    Private Function Kingdom() As String
        Dim RetKing As String

        RetKing = "Undef"

        If optSeries5.Checked Then
            RetKing = "RTU"
        End If

        If optSeries10.Checked Then
            RetKing = "RTU"
        End If

        If optSeries12.Checked Then
            RetKing = "RTU"
        End If

        If optSeries20.Checked Then
            RetKing = "RTU"
        End If

        If optSeries40.Checked Then
            RetKing = "RTU"
        End If

        If optSeriesLX.Checked Then
            RetKing = "RTU"
        End If

        If optSeries100.Checked Then
            RetKing = "RTU"
        End If

        If optYVAA.Checked Then
            RetKing = "Chiller"
        End If

        If optYLAA.Checked Then
            RetKing = "Chiller"
        End If

        If optYCAL.Checked Then
            RetKing = "Chiller"
        End If

        If optSolution.Checked Then
            RetKing = "AHU"
        End If

        If optOther.Checked Then
            RetKing = "Other"
        End If

        If optChoice.Checked Then
            RetKing = "RTU"
        End If

        If optPremier.Checked Then
            RetKing = "RTU"
        End If

        If optSelect.Checked Then
            RetKing = "RTU"
        End If


        Return RetKing

    End Function

    Public Function Family() As String
        Dim RetFam As String

        RetFam = "Undef"

        If optSeries5.Checked Then
            RetFam = "Series5"
        End If

        If optSeries10.Checked Then
            RetFam = "Series10"
        End If

        If optSeries12.Checked Then
            RetFam = "Series12"
        End If

        If optSeries20.Checked Then
            RetFam = "Series20"
        End If

        If optSeries40.Checked Then
            RetFam = "Series40"
        End If

        If optSeriesLX.Checked Then
            RetFam = "SeriesLX"
        End If

        If optSeries100.Checked Then
            RetFam = "Series100"
        End If

        If optChoice.Checked Then
            RetFam = "Choice"
        End If

        If optSelect.Checked Then
            RetFam = "Select"
        End If

        If optPremier.Checked Then
            RetFam = "Premier"
        End If

        If optYVAA.Checked Then
            RetFam = "YVAA"
        End If

        If optYLAA.Checked Then
            RetFam = "YLAA"
        End If

        If optYCAL.Checked Then
            RetFam = "YCAL"
        End If

        If optSolution.Checked Then
            RetFam = "XTI/XTO"
        End If

        If optOther.Checked Then
            RetFam = "Other"
        End If

        Return RetFam

    End Function
    Private Sub cmdFIOPS_Click(sender As Object, e As EventArgs) Handles cmdFIOPS.Click
        Dim CanX As Boolean
        Dim Dummy As MsgBoxResult

        If optSeries5.Checked Then
            frmUPGFIOPEntry.ShowDialog()
            CanX = frmUPGFIOPEntry.pCancelled
        End If
        If optSeries10.Checked Then
            frmUPGFIOPEntry.ShowDialog()
            CanX = frmUPGFIOPEntry.pCancelled
        End If
        If optSeries12.Checked Then
            frmUPGFIOPEntry.ShowDialog()
            CanX = frmUPGFIOPEntry.pCancelled
        End If
        If optSeries20.Checked Then
            frmUPGFIOPEntry.ShowDialog()
            CanX = frmUPGFIOPEntry.pCancelled
        End If

        If optSeries40.Checked Then
            frmUPGFIOPEntry.ShowDialog()
            CanX = frmUPGFIOPEntry.pCancelled
        End If

        If optSeriesLX.Checked Then
            frmUPGFIOPEntry.ShowDialog()
            CanX = frmUPGFIOPEntry.pCancelled
        End If

        If optChoice.Checked Then
            frmUPGFIOPEntry.ShowDialog()
            CanX = frmUPGFIOPEntry.pCancelled
        End If

        If optSelect.Checked Then
            frmUPGFIOPEntry.ShowDialog()
            CanX = frmUPGFIOPEntry.pCancelled
        End If

        If optPremier.Checked Then
            frmUPGFIOPEntry.ShowDialog()
            CanX = frmUPGFIOPEntry.pCancelled
        End If

        If CanX Then
            Dummy = MsgBox("User Cancelled.")
            End
        Else
            cmdFieldInst.Enabled = True
        End If

        cmdFIOPS.Enabled = False

    End Sub

    Private Sub cmdBODF_Click(sender As Object, e As EventArgs) Handles cmdBODF.Click
        txtJobNumber.Text = "BODF"
    End Sub

    Private Sub cmdBrowseTargetFile_Click(sender As Object, e As EventArgs) Handles cmdBrowseTargetFile.Click
        Dim startlocation As String

        Dim jobnum As String
        Dim lasttwo As Integer

        startlocation = "J:\"
        If ((Len(txtJobNumber.Text) = 5) And (Mid(txtJobNumber.Text, 5, 1) = "F")) Then
            jobnum = Mid(txtJobNumber.Text, 1, 4)
            lasttwo = Val(Mid(jobnum, 3, 2))
            If lasttwo <= 49 Then
                startlocation = startlocation & Mid(txtJobNumber.Text, 1, 2) & "00-" & Mid(txtJobNumber.Text, 1, 2) & "49\"
            End If
            If lasttwo >= 50 Then
                startlocation = startlocation & Mid(txtJobNumber.Text, 1, 2) & "50-" & Mid(txtJobNumber.Text, 1, 2) & "99\"
            End If
        End If
        FolderBrowserDialog1.SelectedPath = startlocation
        FolderBrowserDialog1.ShowNewFolderButton = False

        FolderBrowserDialog1.ShowDialog()
        txtUnitDirectory.Text = FolderBrowserDialog1.SelectedPath
        txtBaseUnitFile.Text = txtUnitDirectory.Text & "\" & txtJobNumber.Text & "-" & txtUnitNum.Text & "\Submittal Source (Do not Distribute)\Submittal Design\BaseUnitFile.xml"
        txtUnitRootDirectory.Text = txtUnitDirectory.Text & "\" & txtJobNumber.Text & "-" & txtUnitNum.Text
        grpUnitStyle.Enabled = True
    End Sub

    Private Function ValidateJobNumber() As Boolean
        Dim Dummy As MsgBoxResult
        Dim AOK As Boolean
        Dim TestValue As String

        AOK = True
        TestValue = txtJobNumber.Text
        If TestValue <> "BODF" Then
            If Len(TestValue) <> 5 Then
                AOK = False
            End If
            If Not (IsNumeric(Mid(TestValue, 1, 4))) Then
                AOK = False
            End If
            If Mid(TestValue, 5, 1) <> "F" Then
                AOK = False
            End If
            If Not (AOK) Then
                Dummy = MsgBox("Job Number must be in the nnnnF or BODF format.")
                txtJobNumber.Select()
            End If
        End If
        Return AOK

    End Function

    Private Function ValidateUnitNumber() As Boolean
        Dim Dummy As MsgBoxResult
        Dim AOK As Boolean
        Dim TestValue As String

        AOK = True
        TestValue = txtUnitNum.Text
        If Len(TestValue) <> 2 Then
            AOK = False
        End If
        If Not (IsNumeric(TestValue)) Then
            AOK = False
        End If
        If Not (AOK) Then
            Dummy = MsgBox("Unit Number must be in the nn format.")
            txtUnitNum.Select()
        End If
        Return AOK

    End Function

    Private Function ValidateProjectName() As Boolean
        Dim Dummy As MsgBoxResult
        Dim AOK As Boolean
        Dim TestValue As String

        AOK = True
        TestValue = txtProjectName.Text
        If TestValue = "" Then
            AOK = False
        End If

        If Not (AOK) Then
            Dummy = MsgBox("Project Name must not be blank.")
            txtProjectName.Select()
        End If
        Return AOK
    End Function

    Private Function ValidateUnitTag() As Boolean
        Dim Dummy As MsgBoxResult
        Dim AOK As Boolean
        Dim TestValue As String

        AOK = True
        TestValue = txtTag.Text
        If TestValue = "" Then
            AOK = False
        End If

        If Not (AOK) Then
            Dummy = MsgBox("Unit Tag must not be blank.")
            txtProjectName.Select()
        End If
        Return AOK
    End Function

    Private Function ValidateBrandModelNumber() As Boolean
        Dim Dummy As MsgBoxResult
        Dim AOK As Boolean
        Dim TestValue As String

        AOK = True
        TestValue = txtBrandModelNum.Text
        If TestValue = "" Then
            AOK = False
        End If

        If Not (AOK) Then
            Dummy = MsgBox("Model Number must not be blank.")
            txtBrandModelNum.Select()
        End If

        Return AOK
    End Function

    Private Function ValidateRequiredFiles() As Boolean
        Dim Dummy As MsgBoxResult
        Dim AOK As Boolean
        Dim i, j As Integer
        Dim SalesPath As String
        Dim MissingFileMessage As String
        Dim FileList As String()
        Dim TempFile As String
        Dim VLoc, DotLoc As Integer

        AOK = True
        MissingFileMessage = "Could not locate a required file." & vbCrLf & "Verifiy file location and name." & vbCrLf
        SalesPath = txtUnitRootDirectory.Text & "\Sales Info\"

        FileList = Directory.GetFiles(SalesPath)

        For i = 0 To lstRequiredFiles.Items.Count - 1
            AOK = False
            For j = 0 To FileList.Length - 1
                TempFile = FileList(j)
                TempFile = UCase(TempFile)

                VLoc = InStrRev(TempFile, "V")
                    If VLoc > 0 Then
                        DotLoc = InStrRev(TempFile, ".")
                        TempFile = Trim(Mid(TempFile, 1, VLoc - 1)) & Trim(Mid(TempFile, DotLoc + 1))
                    End If
                    If TempFile = UCase(SalesPath & lstRequiredFiles.Items.Item(i)) Then
                        AOK = True
                        Exit For
                    End If

            Next
            If AOK = False Then
                Dummy = MsgBox(MissingFileMessage & lstRequiredFiles.Items.Item(i), vbOKOnly, "Fisen Sales Handoff Tool")
            End If
            'If Not (System.IO.File.Exists(SalesPath & lstRequiredFiles.Items.Item(i))) Then
            '    AOK = False
            '    Dummy = MsgBox(MissingFileMessage & lstRequiredFiles.Items.Item(i), vbOKOnly, "Fisen Sales Handoff Tool")
            'End If
        Next

        Return True

    End Function


    Private Function ValidateFactoryInstalledOptionsPage() As Boolean
        Dim Dummy As MsgBoxResult
        Dim AOK As Boolean

        Dim MissingPageMessage As String
        Dim FiopPagePresentMessage As String


        AOK = True
        FiopPagePresentMessage = "Is the page titled 'Factory Installed Options'" & vbCrLf & "present in the base unit selection?"
        MissingPageMessage = "That page must be provided to engineering to proceed."

        Dummy = MsgBox(FiopPagePresentMessage, vbYesNo, "Fisen Sales Tools")

        If Dummy = vbNo Then
            Dummy = MsgBox(MissingPageMessage, vbOKOnly, "Fisen Sales Handoff Tool")
            AOK = False
        End If

        Return AOK

    End Function

    Private Function ValidateFamily() As Boolean
        Dim Dummy As MsgBoxResult
        Dim AOK As Boolean
        Dim i As Integer

        Dim MissingFileMessage As String

        AOK = True
        MissingFileMessage = "You must choose a unit family."

        AOK = optSeries5.Checked Or optSeries10.Checked Or optSeries20.Checked Or optSeries40.Checked Or optSeriesLX.Checked Or optSeries100.Checked Or optSeries12.Checked Or optYVAA.Checked Or optYCAL.Checked Or optYLAA.Checked Or optSolution.Checked Or optOther.Checked Or optChoice.Checked Or optPremier.Checked Or optSelect.Checked

        If Not AOK Then
            Dummy = MsgBox(MissingFileMessage, vbOKOnly, "Fisen Sales Handoff Tool")
        End If

        Return AOK

    End Function

    Private Function ValidateModifications() As Boolean
        Dim Dummy As MsgBoxResult
        Dim AOK As Boolean

        AOK = True

        For i = 0 To lstMods.SelectedItems.Count - 1
            Select Case lstMods.SelectedItems.Item(i)
                Case Is = "HWCoil"
                    frmHWCoil.ShowDialog()
                    If frmHWCoil.Cancelled = True Then
                        Dummy = MsgBox("User Cancelled Entry.  Exiting Program.")
                        End
                    End If
                Case Is = "MGH(R)"
                    frmMHG_R.ShowDialog()
                    If frmMHG_R.Cancelled = True Then
                        Dummy = MsgBox("User Cancelled Entry.  Exiting Program.")
                        End
                    End If
                Case Is = "RFan"
                    frmRFan.ShowDialog()
                    AOK = frmRFan.AOK And AOK
                    If frmRFan.Cancelled = True Then
                        Dummy = MsgBox("User Cancelled Entry.  Exiting Program.")
                        End
                    End If
                Case Is = "LCVAV"
                    frmLCVAV.ShowDialog()
                    AOK = frmLCVAV.AOK And AOK
                    If frmLCVAV.Cancelled = True Then
                        Dummy = MsgBox("User Cancelled Entry.  Exiting Program.")
                        End
                    End If

            End Select
        Next


        Return AOK
    End Function

    Private Sub cmdPreFlight_Click(sender As Object, e As EventArgs) Handles cmdPreFlight.Click
        Dim Dummy As String
        Dim GTG As Boolean

        chkAdminMode.Enabled = False
        GTG = True

        If Not (ValidateJobNumber()) Then GTG = False
        If Not (ValidateUnitNumber()) Then GTG = False
        If Not (ValidateProjectName()) Then GTG = False
        If Not (ValidateUnitTag()) Then GTG = False
        If Not (ValidateBrandModelNumber()) Then GTG = False
        If Not (ValidateRequiredFiles()) Then GTG = False

        If Not (ValidateModifications()) Then GTG = False
        If Not (ValidateFamily()) Then GTG = False

        If ((Kingdom() = "RTU") And (Family() <> "Series100")) Then
            If Not (ValidateFactoryInstalledOptionsPage()) Then GTG = False
        End If

        If Not (GTG) Then
            If Me.BypassRequest Then
                Dummy = InputBox("Enter the Bypass Code:", Me.SlnName)
                If Not (BypassOK(Date2Julian(Now()), Dummy)) Then
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        End If

            'Stuff is ok.  Lock it down.
            txtJobNumber.Enabled = False
        txtUnitNum.Enabled = False
        txtProjectName.Enabled = False
        txtQty.Enabled = False
        txtTag.Enabled = False
        txtBrandModelNum.Enabled = False
        cmbBrand.Enabled = False
        txtUnitDirectory.Enabled = False
        txtUnitRootDirectory.Enabled = False
        txtBaseUnitFile.Enabled = False
        cmdBrowseTargetFile.Enabled = False
        cmdBODF.Enabled = False
        grpUnitStyle.Enabled = False
        lstMods.Enabled = False
        lstRequiredFiles.Enabled = False
        cmdPreFlight.Enabled = False

        cmdEnterPerformance.Enabled = True

    End Sub

    Private Sub txtDebug_Click(sender As Object, e As EventArgs) Handles txtDebug.Click
        'txtJobNumber.Text = "3348F"
        'txtUnitNum.Text = "01"
        'txtProjectName.Text = "501 Seventeen"
        'txtQty.Text = "1"
        'txtTag.Text = "RTU-4"
        'txtBrandModelNum.Text = "J20ZRC00P4C2BCA5L1"
        'txtUnitDirectory.Text = "J:\"
        'txtUnitRootDirectory.Text = ""
        'txtBaseUnitFile.Text = ""

        Dim dummy As String
        Dim dummy2 As MsgBoxResult
        dummy = InputBox("Enter Today's Code:")
        If MySecurity.BypassOK(MySecurity.Date2Julian(Now), dummy) Then
            dummy2 = MsgBox("Yes")
        Else
            dummy2 = MsgBox("No")
        End If


    End Sub

    Private Sub optSeries5_CheckedChanged(sender As Object, e As EventArgs) Handles optSeries5.CheckedChanged
        Dim JobAndUnit As String
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "
        If optSeries5.Checked Then
            lstRequiredFiles.Items.Clear()
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Selection.pdf")
            chkHydroKit.Checked = False
            chkHydroKit.Enabled = False
        End If
    End Sub

    Private Sub optSeries10_CheckedChanged(sender As Object, e As EventArgs) Handles optSeries10.CheckedChanged
        Dim JobAndUnit As String
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "
        If optSeries10.Checked Then
            lstRequiredFiles.Items.Clear()
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Selection.pdf")
            chkHydroKit.Checked = False
            chkHydroKit.Enabled = False
        End If
    End Sub

    Private Sub optSeries12_CheckedChanged(sender As Object, e As EventArgs) Handles optSeries12.CheckedChanged
        Dim JobAndUnit As String
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "
        If optSeries12.Checked Then
            lstRequiredFiles.Items.Clear()
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Selection.pdf")
            chkHydroKit.Checked = False
            chkHydroKit.Enabled = False
        End If
    End Sub

    Private Sub optSeries20_CheckedChanged(sender As Object, e As EventArgs) Handles optSeries20.CheckedChanged
        Dim JobAndUnit As String
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "
        If optSeries20.Checked Then
            lstRequiredFiles.Items.Clear()
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Selection.pdf")
            chkHydroKit.Checked = False
            chkHydroKit.Enabled = False
        End If
    End Sub

    Private Sub optSeries40_CheckedChanged(sender As Object, e As EventArgs) Handles optSeries40.CheckedChanged
        Dim JobAndUnit As String
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "
        If optSeries40.Checked Then
            lstRequiredFiles.Items.Clear()
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Selection.pdf")
            chkHydroKit.Checked = False
            chkHydroKit.Enabled = False
        End If
    End Sub

    Private Sub optSeriesLX_CheckedChanged(sender As Object, e As EventArgs) Handles optSeriesLX.CheckedChanged
        Dim JobAndUnit As String
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "
        If optSeriesLX.Checked Then
            lstRequiredFiles.Items.Clear()
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Selection.pdf")
            chkHydroKit.Checked = False
            chkHydroKit.Enabled = False
        End If
    End Sub

    Private Sub optSeries100_CheckedChanged(sender As Object, e As EventArgs) Handles optSeries100.CheckedChanged
        Dim JobAndUnit As String
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "
        If optSeries100.Checked Then
            lstRequiredFiles.Items.Clear()
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Selection.pdf")
            lstRequiredFiles.Items.Add(JobAndUnit & "Order Details.pdf")
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Drawing.dwg")
            chkHydroKit.Checked = False
            chkHydroKit.Enabled = False
        End If
    End Sub

    Private Sub optYVAA_CheckedChanged(sender As Object, e As EventArgs) Handles optYVAA.CheckedChanged
        Dim JobAndUnit As String
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "
        If optYVAA.Checked Then
            lstRequiredFiles.Items.Clear()
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Selection.pdf")
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Drawing.dwg")
            'lstRequiredFiles.Items.Add(JobAndUnit & "AVMSpec.pdf")
            lstRequiredFiles.Items.Add(JobAndUnit & "OrderSpec.pdf")
            chkHydroKit.Checked = False
            chkHydroKit.Enabled = False
        End If

    End Sub

    Private Sub optYCAL_CheckedChanged(sender As Object, e As EventArgs) Handles optYCAL.CheckedChanged
        Dim JobAndUnit As String
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "
        If optYCAL.Checked Then
            lstRequiredFiles.Items.Clear()
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Selection.pdf")
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Drawing.dwg")
            lstRequiredFiles.Items.Add(JobAndUnit & "AVMSpec.pdf")
            lstRequiredFiles.Items.Add(JobAndUnit & "OrderSpec.pdf")
            chkHydroKit.Checked = False
            chkHydroKit.Enabled = True

        End If
    End Sub

    Private Sub optYLAA_CheckedChanged(sender As Object, e As EventArgs) Handles optYLAA.CheckedChanged
        Dim JobAndUnit As String
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "
        If optYLAA.Checked Then
            lstRequiredFiles.Items.Clear()
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Selection.pdf")
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Drawing.dwg")
            lstRequiredFiles.Items.Add(JobAndUnit & "AVMSpec.pdf")
            lstRequiredFiles.Items.Add(JobAndUnit & "OrderSpec.pdf")
            chkHydroKit.Checked = False
            chkHydroKit.Enabled = True

        End If
    End Sub

    Private Sub optSolution_CheckedChanged(sender As Object, e As EventArgs) Handles optSolution.CheckedChanged
        Dim JobAndUnit As String
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "
        If optSolution.Checked Then
            lstRequiredFiles.Items.Clear()
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Selection.rtf")
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Drawing.dwg")
            chkHydroKit.Checked = False
            chkHydroKit.Enabled = False
        End If
    End Sub

    Private Sub optOther_CheckedChanged(sender As Object, e As EventArgs) Handles optOther.CheckedChanged
        Dim JobAndUnit As String
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "
        If optOther.Checked Then
            lstRequiredFiles.Items.Clear()
            lstRequiredFiles.Items.Add(JobAndUnit & "Base Unit Selection.pdf")
            chkHydroKit.Checked = False
            chkHydroKit.Enabled = False
        End If
    End Sub



    Private Sub chkHydroKit_CheckedChanged(sender As Object, e As EventArgs) Handles chkHydroKit.CheckedChanged
        Dim JobAndUnit As String
        Dim i As Integer
        JobAndUnit = txtJobNumber.Text & "-" & txtUnitNum.Text & " - "

        If chkHydroKit.Checked Then
            lstRequiredFiles.Items.Add(JobAndUnit & "PumpCurveSpec.pdf")
        Else
            For i = 0 To lstRequiredFiles.Items.Count - 1
                If lstRequiredFiles.Items.Item(i) = (JobAndUnit & "PumpCurveSpec.pdf") Then
                    lstRequiredFiles.Items.RemoveAt(i)
                    Exit For
                End If
            Next
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Debug.Print(Trim(Date2Julian(Now())))

    End Sub

    Public Function Date2Julian(ByVal vDate As Date) As Long

        Date2Julian = CLng(Format(Year(vDate), "0000") _
                      + Format(DateDiff("d", CDate("01/01/" _
                      + Format(Year(vDate), "0000")), vDate) _
                      + 1, "000"))

    End Function

    Public Function BypassOK(ByVal jDate As Long, mycode As String) As Boolean
        Dim ScramDate As String
        Dim strDate As String

        Dim retcode As Boolean

        strDate = Trim(Str(jDate))
        ScramDate = Mid(strDate, 7, 1) & Mid(strDate, 5, 1) & Mid(strDate, 3, 1) & Mid(strDate, 1, 1) & Mid(strDate, 2, 1) & Mid(strDate, 4, 1) & Mid(strDate, 6, 1)
        Debug.Print(ScramDate)
        If ScramDate = mycode Then
            retcode = True
        Else
            retcode = False
        End If

        Return retcode
    End Function

    Private Sub cmdFieldInst_Click(sender As Object, e As EventArgs) Handles cmdFieldInst.Click
        Dim CanX As Boolean
        Dim Dummy As MsgBoxResult

        cmdFieldInst.Enabled = False

        If optSeries5.Checked Then
            frmUPGFieldInstalled.ShowDialog()
            CanX = frmUPGFieldInstalled.pCancelled
        End If
        If optSeries10.Checked Then
            frmUPGFieldInstalled.ShowDialog()
            CanX = frmUPGFieldInstalled.pCancelled
        End If
        If optSeries12.Checked Then
            frmUPGFieldInstalled.ShowDialog()
            CanX = frmUPGFieldInstalled.pCancelled
        End If
        If optSeries20.Checked Then
            frmUPGFieldInstalled.ShowDialog()
            CanX = frmUPGFieldInstalled.pCancelled
        End If
        If optSeries40.Checked Then
            frmUPGFieldInstalled.ShowDialog()
            CanX = frmUPGFieldInstalled.pCancelled
        End If
        If optSeriesLX.Checked Then
            frmUPGFieldInstalled.ShowDialog()
            CanX = frmUPGFieldInstalled.pCancelled
        End If

        If optSelect.Checked Then
            frmUPGFieldInstalled.ShowDialog()
            CanX = frmUPGFieldInstalled.pCancelled
        End If

        If optChoice.Checked Then
            frmUPGFieldInstalled.ShowDialog()
            CanX = frmUPGFieldInstalled.pCancelled
        End If

        If optPremier.Checked Then
            frmUPGFieldInstalled.ShowDialog()
            CanX = frmUPGFieldInstalled.pCancelled
        End If



        If CanX Then
            Dummy = MsgBox("User Cancelled.")
            End
        Else
            cmdWriteUnit.Enabled = True
        End If

        cmdFIOPS.Enabled = False

    End Sub

    Private Sub txtJobNumber_Leave(sender As Object, e As EventArgs) Handles txtJobNumber.Leave
        Dim MyString As String
        Dim ItsANumber As Boolean
        Dim ItEndsInNumber As Boolean


        MyString = txtJobNumber.Text
        If MyString = "" Then Exit Sub
        ItsANumber = IsNumeric(MyString)
        ItEndsInNumber = IsNumeric(Mid(MyString, Len(MyString), 1))

        If ItsANumber And ItEndsInNumber And (Len(MyString) = 4) Then
            txtJobNumber.Text = txtJobNumber.Text & "F"
        End If

    End Sub

    Private Sub txtTag_TextChanged(sender As Object, e As EventArgs) Handles txtTag.TextChanged

    End Sub

    Private Sub txtTag_Leave(sender As Object, e As EventArgs) Handles txtTag.Leave
        If txtTag.Text = "" Then txtTag.Text = "Untagged"
    End Sub


End Class
