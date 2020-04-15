<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.grpUnitStyle = New System.Windows.Forms.GroupBox()
        Me.optPremier = New System.Windows.Forms.RadioButton()
        Me.optSelect = New System.Windows.Forms.RadioButton()
        Me.optChoice = New System.Windows.Forms.RadioButton()
        Me.chkHydroKit = New System.Windows.Forms.CheckBox()
        Me.optOther = New System.Windows.Forms.RadioButton()
        Me.optSolution = New System.Windows.Forms.RadioButton()
        Me.optYLAA = New System.Windows.Forms.RadioButton()
        Me.optYCAL = New System.Windows.Forms.RadioButton()
        Me.optYVAA = New System.Windows.Forms.RadioButton()
        Me.optSeries100 = New System.Windows.Forms.RadioButton()
        Me.optSeries40 = New System.Windows.Forms.RadioButton()
        Me.optSeries20 = New System.Windows.Forms.RadioButton()
        Me.optSeries12 = New System.Windows.Forms.RadioButton()
        Me.optSeries10 = New System.Windows.Forms.RadioButton()
        Me.optSeries5 = New System.Windows.Forms.RadioButton()
        Me.cmdEnterPerformance = New System.Windows.Forms.Button()
        Me.cmdWriteUnit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUnitNum = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTag = New System.Windows.Forms.TextBox()
        Me.cmbBrand = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBrandModelNum = New System.Windows.Forms.TextBox()
        Me.cmdFIOPS = New System.Windows.Forms.Button()
        Me.cmdBODF = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdPreFlight = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBaseUnitFile = New System.Windows.Forms.TextBox()
        Me.cmdBrowseTargetFile = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtUnitDirectory = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtUnitRootDirectory = New System.Windows.Forms.TextBox()
        Me.txtDebug = New System.Windows.Forms.Button()
        Me.lstRequiredFiles = New System.Windows.Forms.ListBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Modifications = New System.Windows.Forms.Label()
        Me.lstMods = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkAdminMode = New System.Windows.Forms.CheckBox()
        Me.cmdFieldInst = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtModList = New System.Windows.Forms.TextBox()
        Me.grpUnitStyle.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpUnitStyle
        '
        Me.grpUnitStyle.Controls.Add(Me.optPremier)
        Me.grpUnitStyle.Controls.Add(Me.optSelect)
        Me.grpUnitStyle.Controls.Add(Me.optChoice)
        Me.grpUnitStyle.Controls.Add(Me.chkHydroKit)
        Me.grpUnitStyle.Controls.Add(Me.optOther)
        Me.grpUnitStyle.Controls.Add(Me.optSolution)
        Me.grpUnitStyle.Controls.Add(Me.optYLAA)
        Me.grpUnitStyle.Controls.Add(Me.optYCAL)
        Me.grpUnitStyle.Controls.Add(Me.optYVAA)
        Me.grpUnitStyle.Controls.Add(Me.optSeries100)
        Me.grpUnitStyle.Controls.Add(Me.optSeries40)
        Me.grpUnitStyle.Controls.Add(Me.optSeries20)
        Me.grpUnitStyle.Controls.Add(Me.optSeries12)
        Me.grpUnitStyle.Controls.Add(Me.optSeries10)
        Me.grpUnitStyle.Controls.Add(Me.optSeries5)
        Me.grpUnitStyle.Enabled = False
        Me.grpUnitStyle.Location = New System.Drawing.Point(12, 282)
        Me.grpUnitStyle.Name = "grpUnitStyle"
        Me.grpUnitStyle.Size = New System.Drawing.Size(517, 140)
        Me.grpUnitStyle.TabIndex = 12
        Me.grpUnitStyle.TabStop = False
        Me.grpUnitStyle.Text = "Unit Type"
        '
        'optPremier
        '
        Me.optPremier.AutoSize = True
        Me.optPremier.Location = New System.Drawing.Point(168, 65)
        Me.optPremier.Name = "optPremier"
        Me.optPremier.Size = New System.Drawing.Size(60, 17)
        Me.optPremier.TabIndex = 14
        Me.optPremier.Text = "Premier"
        Me.optPremier.UseVisualStyleBackColor = True
        '
        'optSelect
        '
        Me.optSelect.AutoSize = True
        Me.optSelect.Location = New System.Drawing.Point(168, 42)
        Me.optSelect.Name = "optSelect"
        Me.optSelect.Size = New System.Drawing.Size(55, 17)
        Me.optSelect.TabIndex = 13
        Me.optSelect.Text = "Select"
        Me.optSelect.UseVisualStyleBackColor = True
        '
        'optChoice
        '
        Me.optChoice.AutoSize = True
        Me.optChoice.Location = New System.Drawing.Point(168, 19)
        Me.optChoice.Name = "optChoice"
        Me.optChoice.Size = New System.Drawing.Size(58, 17)
        Me.optChoice.TabIndex = 12
        Me.optChoice.Text = "Choice"
        Me.optChoice.UseVisualStyleBackColor = True
        '
        'chkHydroKit
        '
        Me.chkHydroKit.AutoSize = True
        Me.chkHydroKit.Enabled = False
        Me.chkHydroKit.Location = New System.Drawing.Point(390, 117)
        Me.chkHydroKit.Name = "chkHydroKit"
        Me.chkHydroKit.Size = New System.Drawing.Size(131, 17)
        Me.chkHydroKit.TabIndex = 11
        Me.chkHydroKit.Text = "JCI Installed Hydrokit?"
        Me.chkHydroKit.UseVisualStyleBackColor = True
        '
        'optOther
        '
        Me.optOther.AutoSize = True
        Me.optOther.Location = New System.Drawing.Point(382, 19)
        Me.optOther.Name = "optOther"
        Me.optOther.Size = New System.Drawing.Size(51, 17)
        Me.optOther.TabIndex = 10
        Me.optOther.Text = "Other"
        Me.optOther.UseVisualStyleBackColor = True
        '
        'optSolution
        '
        Me.optSolution.AutoSize = True
        Me.optSolution.Location = New System.Drawing.Point(307, 19)
        Me.optSolution.Name = "optSolution"
        Me.optSolution.Size = New System.Drawing.Size(69, 17)
        Me.optSolution.TabIndex = 9
        Me.optSolution.Text = "XTI/XTO"
        Me.optSolution.UseVisualStyleBackColor = True
        '
        'optYLAA
        '
        Me.optYLAA.AutoSize = True
        Me.optYLAA.Location = New System.Drawing.Point(249, 42)
        Me.optYLAA.Name = "optYLAA"
        Me.optYLAA.Size = New System.Drawing.Size(52, 17)
        Me.optYLAA.TabIndex = 8
        Me.optYLAA.Text = "YLAA"
        Me.optYLAA.UseVisualStyleBackColor = True
        '
        'optYCAL
        '
        Me.optYCAL.AutoSize = True
        Me.optYCAL.Location = New System.Drawing.Point(249, 19)
        Me.optYCAL.Name = "optYCAL"
        Me.optYCAL.Size = New System.Drawing.Size(52, 17)
        Me.optYCAL.TabIndex = 7
        Me.optYCAL.Text = "YCAL"
        Me.optYCAL.UseVisualStyleBackColor = True
        '
        'optYVAA
        '
        Me.optYVAA.AutoSize = True
        Me.optYVAA.Location = New System.Drawing.Point(249, 65)
        Me.optYVAA.Name = "optYVAA"
        Me.optYVAA.Size = New System.Drawing.Size(53, 17)
        Me.optYVAA.TabIndex = 6
        Me.optYVAA.Text = "YVAA"
        Me.optYVAA.UseVisualStyleBackColor = True
        '
        'optSeries100
        '
        Me.optSeries100.AutoSize = True
        Me.optSeries100.Location = New System.Drawing.Point(87, 19)
        Me.optSeries100.Name = "optSeries100"
        Me.optSeries100.Size = New System.Drawing.Size(75, 17)
        Me.optSeries100.TabIndex = 5
        Me.optSeries100.Text = "Series 100"
        Me.optSeries100.UseVisualStyleBackColor = True
        '
        'optSeries40
        '
        Me.optSeries40.AutoSize = True
        Me.optSeries40.Location = New System.Drawing.Point(6, 111)
        Me.optSeries40.Name = "optSeries40"
        Me.optSeries40.Size = New System.Drawing.Size(69, 17)
        Me.optSeries40.TabIndex = 4
        Me.optSeries40.Text = "Series 40"
        Me.optSeries40.UseVisualStyleBackColor = True
        '
        'optSeries20
        '
        Me.optSeries20.AutoSize = True
        Me.optSeries20.Location = New System.Drawing.Point(6, 88)
        Me.optSeries20.Name = "optSeries20"
        Me.optSeries20.Size = New System.Drawing.Size(69, 17)
        Me.optSeries20.TabIndex = 3
        Me.optSeries20.Text = "Series 20"
        Me.optSeries20.UseVisualStyleBackColor = True
        '
        'optSeries12
        '
        Me.optSeries12.AutoSize = True
        Me.optSeries12.Location = New System.Drawing.Point(6, 65)
        Me.optSeries12.Name = "optSeries12"
        Me.optSeries12.Size = New System.Drawing.Size(69, 17)
        Me.optSeries12.TabIndex = 2
        Me.optSeries12.Text = "Series 12"
        Me.optSeries12.UseVisualStyleBackColor = True
        '
        'optSeries10
        '
        Me.optSeries10.AutoSize = True
        Me.optSeries10.Location = New System.Drawing.Point(6, 42)
        Me.optSeries10.Name = "optSeries10"
        Me.optSeries10.Size = New System.Drawing.Size(69, 17)
        Me.optSeries10.TabIndex = 1
        Me.optSeries10.Text = "Series 10"
        Me.optSeries10.UseVisualStyleBackColor = True
        '
        'optSeries5
        '
        Me.optSeries5.AutoSize = True
        Me.optSeries5.Location = New System.Drawing.Point(6, 19)
        Me.optSeries5.Name = "optSeries5"
        Me.optSeries5.Size = New System.Drawing.Size(63, 17)
        Me.optSeries5.TabIndex = 0
        Me.optSeries5.Text = "Series 5"
        Me.optSeries5.UseVisualStyleBackColor = True
        '
        'cmdEnterPerformance
        '
        Me.cmdEnterPerformance.Enabled = False
        Me.cmdEnterPerformance.Location = New System.Drawing.Point(18, 725)
        Me.cmdEnterPerformance.Name = "cmdEnterPerformance"
        Me.cmdEnterPerformance.Size = New System.Drawing.Size(75, 24)
        Me.cmdEnterPerformance.TabIndex = 16
        Me.cmdEnterPerformance.Text = "Performance"
        Me.ToolTip1.SetToolTip(Me.cmdEnterPerformance, "Enables when Model Number Loses Focus")
        Me.cmdEnterPerformance.UseVisualStyleBackColor = True
        '
        'cmdWriteUnit
        '
        Me.cmdWriteUnit.Enabled = False
        Me.cmdWriteUnit.Location = New System.Drawing.Point(454, 725)
        Me.cmdWriteUnit.Name = "cmdWriteUnit"
        Me.cmdWriteUnit.Size = New System.Drawing.Size(75, 24)
        Me.cmdWriteUnit.TabIndex = 19
        Me.cmdWriteUnit.Text = "Write Unit"
        Me.cmdWriteUnit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(9, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Job Number"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Location = New System.Drawing.Point(136, 6)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(65, 20)
        Me.txtJobNumber.TabIndex = 0
        Me.txtJobNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Unit Number"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUnitNum
        '
        Me.txtUnitNum.Location = New System.Drawing.Point(136, 32)
        Me.txtUnitNum.Name = "txtUnitNum"
        Me.txtUnitNum.Size = New System.Drawing.Size(65, 20)
        Me.txtUnitNum.TabIndex = 2
        Me.txtUnitNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Project Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtProjectName
        '
        Me.txtProjectName.Location = New System.Drawing.Point(136, 58)
        Me.txtProjectName.Name = "txtProjectName"
        Me.txtProjectName.Size = New System.Drawing.Size(387, 20)
        Me.txtProjectName.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(9, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Quantity"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(136, 84)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(65, 20)
        Me.txtQty.TabIndex = 4
        Me.txtQty.Text = "1"
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(244, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Unit Tag"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTag
        '
        Me.txtTag.Location = New System.Drawing.Point(306, 84)
        Me.txtTag.Name = "txtTag"
        Me.txtTag.Size = New System.Drawing.Size(65, 20)
        Me.txtTag.TabIndex = 5
        Me.txtTag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbBrand
        '
        Me.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBrand.FormattingEnabled = True
        Me.cmbBrand.Items.AddRange(New Object() {"JCI", "TMP", "York", "LUX", "FRJ"})
        Me.cmbBrand.Location = New System.Drawing.Point(452, 83)
        Me.cmbBrand.Name = "cmbBrand"
        Me.cmbBrand.Size = New System.Drawing.Size(71, 21)
        Me.cmbBrand.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(391, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 18)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Brand"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(9, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Brand Model Number"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBrandModelNum
        '
        Me.txtBrandModelNum.Location = New System.Drawing.Point(136, 110)
        Me.txtBrandModelNum.Name = "txtBrandModelNum"
        Me.txtBrandModelNum.Size = New System.Drawing.Size(387, 20)
        Me.txtBrandModelNum.TabIndex = 7
        '
        'cmdFIOPS
        '
        Me.cmdFIOPS.Enabled = False
        Me.cmdFIOPS.Location = New System.Drawing.Point(99, 725)
        Me.cmdFIOPS.Name = "cmdFIOPS"
        Me.cmdFIOPS.Size = New System.Drawing.Size(75, 24)
        Me.cmdFIOPS.TabIndex = 17
        Me.cmdFIOPS.Text = "FIOPS"
        Me.cmdFIOPS.UseVisualStyleBackColor = True
        '
        'cmdBODF
        '
        Me.cmdBODF.Location = New System.Drawing.Point(207, 6)
        Me.cmdBODF.Name = "cmdBODF"
        Me.cmdBODF.Size = New System.Drawing.Size(39, 20)
        Me.cmdBODF.TabIndex = 1
        Me.cmdBODF.Text = "BOD"
        Me.cmdBODF.UseVisualStyleBackColor = True
        '
        'cmdPreFlight
        '
        Me.cmdPreFlight.Location = New System.Drawing.Point(18, 695)
        Me.cmdPreFlight.Name = "cmdPreFlight"
        Me.cmdPreFlight.Size = New System.Drawing.Size(75, 24)
        Me.cmdPreFlight.TabIndex = 15
        Me.cmdPreFlight.Text = "PreFlight"
        Me.ToolTip1.SetToolTip(Me.cmdPreFlight, "Enables when Model Number Loses Focus")
        Me.cmdPreFlight.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(9, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(121, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Target File"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBaseUnitFile
        '
        Me.txtBaseUnitFile.Location = New System.Drawing.Point(136, 188)
        Me.txtBaseUnitFile.Name = "txtBaseUnitFile"
        Me.txtBaseUnitFile.Size = New System.Drawing.Size(342, 20)
        Me.txtBaseUnitFile.TabIndex = 10
        '
        'cmdBrowseTargetFile
        '
        Me.cmdBrowseTargetFile.Location = New System.Drawing.Point(484, 136)
        Me.cmdBrowseTargetFile.Name = "cmdBrowseTargetFile"
        Me.cmdBrowseTargetFile.Size = New System.Drawing.Size(39, 20)
        Me.cmdBrowseTargetFile.TabIndex = 10
        Me.cmdBrowseTargetFile.Text = "..."
        Me.cmdBrowseTargetFile.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(9, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Project Directory"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUnitDirectory
        '
        Me.txtUnitDirectory.Location = New System.Drawing.Point(136, 136)
        Me.txtUnitDirectory.Name = "txtUnitDirectory"
        Me.txtUnitDirectory.Size = New System.Drawing.Size(342, 20)
        Me.txtUnitDirectory.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(9, 165)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Unit Directory"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUnitRootDirectory
        '
        Me.txtUnitRootDirectory.Location = New System.Drawing.Point(136, 162)
        Me.txtUnitRootDirectory.Name = "txtUnitRootDirectory"
        Me.txtUnitRootDirectory.Size = New System.Drawing.Size(342, 20)
        Me.txtUnitRootDirectory.TabIndex = 9
        '
        'txtDebug
        '
        Me.txtDebug.Location = New System.Drawing.Point(476, 5)
        Me.txtDebug.Name = "txtDebug"
        Me.txtDebug.Size = New System.Drawing.Size(47, 21)
        Me.txtDebug.TabIndex = 18
        Me.txtDebug.Text = "DBug"
        Me.txtDebug.UseVisualStyleBackColor = True
        '
        'lstRequiredFiles
        '
        Me.lstRequiredFiles.FormattingEnabled = True
        Me.lstRequiredFiles.Location = New System.Drawing.Point(12, 581)
        Me.lstRequiredFiles.Name = "lstRequiredFiles"
        Me.lstRequiredFiles.Size = New System.Drawing.Size(517, 108)
        Me.lstRequiredFiles.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(15, 565)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(121, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Required Files"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Modifications
        '
        Me.Modifications.Location = New System.Drawing.Point(12, 425)
        Me.Modifications.Name = "Modifications"
        Me.Modifications.Size = New System.Drawing.Size(121, 13)
        Me.Modifications.TabIndex = 38
        Me.Modifications.Text = "Modifications"
        Me.Modifications.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstMods
        '
        Me.lstMods.FormattingEnabled = True
        Me.lstMods.Items.AddRange(New Object() {"HWCoil", "LCVAV", "MGH(R)", "RFan"})
        Me.lstMods.Location = New System.Drawing.Point(12, 441)
        Me.lstMods.Name = "lstMods"
        Me.lstMods.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstMods.Size = New System.Drawing.Size(517, 121)
        Me.lstMods.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(402, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 21)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "Wt Test"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkAdminMode
        '
        Me.chkAdminMode.AutoSize = True
        Me.chkAdminMode.Location = New System.Drawing.Point(438, 33)
        Me.chkAdminMode.Name = "chkAdminMode"
        Me.chkAdminMode.Size = New System.Drawing.Size(85, 17)
        Me.chkAdminMode.TabIndex = 40
        Me.chkAdminMode.Text = "Admin Mode"
        Me.chkAdminMode.UseVisualStyleBackColor = True
        '
        'cmdFieldInst
        '
        Me.cmdFieldInst.Enabled = False
        Me.cmdFieldInst.Location = New System.Drawing.Point(180, 725)
        Me.cmdFieldInst.Name = "cmdFieldInst"
        Me.cmdFieldInst.Size = New System.Drawing.Size(75, 24)
        Me.cmdFieldInst.TabIndex = 18
        Me.cmdFieldInst.Text = "Field Inst."
        Me.cmdFieldInst.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(9, 217)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(121, 13)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Modification List"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtModList
        '
        Me.txtModList.Location = New System.Drawing.Point(136, 214)
        Me.txtModList.Name = "txtModList"
        Me.txtModList.Size = New System.Drawing.Size(342, 20)
        Me.txtModList.TabIndex = 11
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 761)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtModList)
        Me.Controls.Add(Me.cmdFieldInst)
        Me.Controls.Add(Me.chkAdminMode)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Modifications)
        Me.Controls.Add(Me.lstMods)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lstRequiredFiles)
        Me.Controls.Add(Me.txtDebug)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtUnitRootDirectory)
        Me.Controls.Add(Me.cmdPreFlight)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtUnitDirectory)
        Me.Controls.Add(Me.cmdBrowseTargetFile)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtBaseUnitFile)
        Me.Controls.Add(Me.cmdBODF)
        Me.Controls.Add(Me.cmdFIOPS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtBrandModelNum)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbBrand)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTag)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtProjectName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUnitNum)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtJobNumber)
        Me.Controls.Add(Me.cmdWriteUnit)
        Me.Controls.Add(Me.cmdEnterPerformance)
        Me.Controls.Add(Me.grpUnitStyle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fisen Sales Handoff Tool"
        Me.grpUnitStyle.ResumeLayout(False)
        Me.grpUnitStyle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpUnitStyle As GroupBox
    Friend WithEvents optSeries40 As RadioButton
    Friend WithEvents optSeries20 As RadioButton
    Friend WithEvents optSeries12 As RadioButton
    Friend WithEvents optSeries10 As RadioButton
    Friend WithEvents optSeries5 As RadioButton
    Friend WithEvents cmdEnterPerformance As Button
    Friend WithEvents cmdWriteUnit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtJobNumber As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUnitNum As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtProjectName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTag As TextBox
    Friend WithEvents cmbBrand As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtBrandModelNum As TextBox
    Friend WithEvents cmdFIOPS As Button
    Friend WithEvents optSeries100 As RadioButton
    Friend WithEvents cmdBODF As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBaseUnitFile As TextBox
    Friend WithEvents cmdBrowseTargetFile As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label9 As Label
    Friend WithEvents txtUnitDirectory As TextBox
    Friend WithEvents cmdPreFlight As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents txtUnitRootDirectory As TextBox
    Friend WithEvents txtDebug As Button
    Friend WithEvents lstRequiredFiles As ListBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Modifications As Label
    Friend WithEvents lstMods As ListBox
    Friend WithEvents optOther As RadioButton
    Friend WithEvents optSolution As RadioButton
    Friend WithEvents optYLAA As RadioButton
    Friend WithEvents optYCAL As RadioButton
    Friend WithEvents optYVAA As RadioButton
    Friend WithEvents chkHydroKit As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents chkAdminMode As CheckBox
    Friend WithEvents cmdFieldInst As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtModList As TextBox
    Friend WithEvents optPremier As RadioButton
    Friend WithEvents optSelect As RadioButton
    Friend WithEvents optChoice As RadioButton
End Class
