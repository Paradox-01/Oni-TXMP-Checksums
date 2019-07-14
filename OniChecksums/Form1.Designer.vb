<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btWriteChecksums = New System.Windows.Forms.Button()
        Me.tbInput = New System.Windows.Forms.TextBox()
        Me.grpbUserStats = New System.Windows.Forms.GroupBox()
        Me.tbISBN = New System.Windows.Forms.TextBox()
        Me.lbISBN = New System.Windows.Forms.Label()
        Me.lbStandAloneOrBundled = New System.Windows.Forms.Label()
        Me.cbStandAloneOrBundled = New System.Windows.Forms.ComboBox()
        Me.cbLanguage = New System.Windows.Forms.ComboBox()
        Me.cbPlateform = New System.Windows.Forms.ComboBox()
        Me.lbPlateform = New System.Windows.Forms.Label()
        Me.tbSpecialNote = New System.Windows.Forms.TextBox()
        Me.lbLanguage = New System.Windows.Forms.Label()
        Me.lbSpecialNote = New System.Windows.Forms.Label()
        Me.tbUser = New System.Windows.Forms.TextBox()
        Me.lbUser = New System.Windows.Forms.Label()
        Me.lbOniSplitNote = New System.Windows.Forms.Label()
        Me.grpbUserStats.SuspendLayout()
        Me.SuspendLayout()
        '
        'btWriteChecksums
        '
        Me.btWriteChecksums.Location = New System.Drawing.Point(12, 160)
        Me.btWriteChecksums.Name = "btWriteChecksums"
        Me.btWriteChecksums.Size = New System.Drawing.Size(177, 23)
        Me.btWriteChecksums.TabIndex = 0
        Me.btWriteChecksums.Text = "Write file checksums of this folder"
        Me.btWriteChecksums.UseVisualStyleBackColor = True
        '
        'tbInput
        '
        Me.tbInput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbInput.Location = New System.Drawing.Point(195, 162)
        Me.tbInput.Name = "tbInput"
        Me.tbInput.Size = New System.Drawing.Size(576, 20)
        Me.tbInput.TabIndex = 1
        '
        'grpbUserStats
        '
        Me.grpbUserStats.Controls.Add(Me.tbISBN)
        Me.grpbUserStats.Controls.Add(Me.lbISBN)
        Me.grpbUserStats.Controls.Add(Me.lbStandAloneOrBundled)
        Me.grpbUserStats.Controls.Add(Me.cbStandAloneOrBundled)
        Me.grpbUserStats.Controls.Add(Me.cbLanguage)
        Me.grpbUserStats.Controls.Add(Me.cbPlateform)
        Me.grpbUserStats.Controls.Add(Me.lbPlateform)
        Me.grpbUserStats.Controls.Add(Me.tbSpecialNote)
        Me.grpbUserStats.Controls.Add(Me.lbLanguage)
        Me.grpbUserStats.Controls.Add(Me.lbSpecialNote)
        Me.grpbUserStats.Controls.Add(Me.tbUser)
        Me.grpbUserStats.Controls.Add(Me.lbUser)
        Me.grpbUserStats.Location = New System.Drawing.Point(12, 12)
        Me.grpbUserStats.Name = "grpbUserStats"
        Me.grpbUserStats.Size = New System.Drawing.Size(760, 101)
        Me.grpbUserStats.TabIndex = 2
        Me.grpbUserStats.TabStop = False
        Me.grpbUserStats.Text = "Game meta data"
        '
        'tbISBN
        '
        Me.tbISBN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbISBN.Location = New System.Drawing.Point(126, 72)
        Me.tbISBN.Name = "tbISBN"
        Me.tbISBN.Size = New System.Drawing.Size(213, 20)
        Me.tbISBN.TabIndex = 17
        '
        'lbISBN
        '
        Me.lbISBN.AutoSize = True
        Me.lbISBN.Location = New System.Drawing.Point(17, 75)
        Me.lbISBN.Name = "lbISBN"
        Me.lbISBN.Size = New System.Drawing.Size(32, 13)
        Me.lbISBN.TabIndex = 16
        Me.lbISBN.Text = "ISBN"
        '
        'lbStandAloneOrBundled
        '
        Me.lbStandAloneOrBundled.AutoSize = True
        Me.lbStandAloneOrBundled.Location = New System.Drawing.Point(17, 48)
        Me.lbStandAloneOrBundled.Name = "lbStandAloneOrBundled"
        Me.lbStandAloneOrBundled.Size = New System.Drawing.Size(55, 13)
        Me.lbStandAloneOrBundled.TabIndex = 15
        Me.lbStandAloneOrBundled.Text = "Bought as"
        '
        'cbStandAloneOrBundled
        '
        Me.cbStandAloneOrBundled.AutoCompleteCustomSource.AddRange(New String() {"Stand-alone", "Bundled with other game(s)", "Unknown"})
        Me.cbStandAloneOrBundled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStandAloneOrBundled.FormattingEnabled = True
        Me.cbStandAloneOrBundled.Items.AddRange(New Object() {"Stand-alone", "Bundled with other game(s)", "Unknown"})
        Me.cbStandAloneOrBundled.Location = New System.Drawing.Point(126, 45)
        Me.cbStandAloneOrBundled.Name = "cbStandAloneOrBundled"
        Me.cbStandAloneOrBundled.Size = New System.Drawing.Size(213, 21)
        Me.cbStandAloneOrBundled.TabIndex = 14
        '
        'cbLanguage
        '
        Me.cbLanguage.AutoCompleteCustomSource.AddRange(New String() {"English", "German", "French", "Spanish", "Portuguese", "Italian", "Russian", "Poland", "Japanese", "Chinese"})
        Me.cbLanguage.FormattingEnabled = True
        Me.cbLanguage.Items.AddRange(New Object() {"English", "German", "French", "Spanish", "Portuguese", "Italian", "Russian", "Poland", "Japanese", "Chinese"})
        Me.cbLanguage.Location = New System.Drawing.Point(538, 45)
        Me.cbLanguage.Name = "cbLanguage"
        Me.cbLanguage.Size = New System.Drawing.Size(213, 21)
        Me.cbLanguage.TabIndex = 13
        '
        'cbPlateform
        '
        Me.cbPlateform.AutoCompleteCustomSource.AddRange(New String() {"PC retail", "PC demo", "PC alpha", "Mac retail", "Mac demo", "Mac alpha"})
        Me.cbPlateform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPlateform.FormattingEnabled = True
        Me.cbPlateform.Items.AddRange(New Object() {"PC retail", "PC demo", "PC alpha", "Mac retail", "Mac demo", "Mac alpha"})
        Me.cbPlateform.Location = New System.Drawing.Point(538, 18)
        Me.cbPlateform.Name = "cbPlateform"
        Me.cbPlateform.Size = New System.Drawing.Size(213, 21)
        Me.cbPlateform.TabIndex = 12
        '
        'lbPlateform
        '
        Me.lbPlateform.AutoSize = True
        Me.lbPlateform.Location = New System.Drawing.Point(465, 20)
        Me.lbPlateform.Name = "lbPlateform"
        Me.lbPlateform.Size = New System.Drawing.Size(51, 13)
        Me.lbPlateform.TabIndex = 11
        Me.lbPlateform.Text = "Plateform"
        '
        'tbSpecialNote
        '
        Me.tbSpecialNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSpecialNote.Location = New System.Drawing.Point(538, 72)
        Me.tbSpecialNote.Name = "tbSpecialNote"
        Me.tbSpecialNote.Size = New System.Drawing.Size(213, 20)
        Me.tbSpecialNote.TabIndex = 6
        '
        'lbLanguage
        '
        Me.lbLanguage.AutoSize = True
        Me.lbLanguage.Location = New System.Drawing.Point(465, 48)
        Me.lbLanguage.Name = "lbLanguage"
        Me.lbLanguage.Size = New System.Drawing.Size(49, 13)
        Me.lbLanguage.TabIndex = 4
        Me.lbLanguage.Text = "Laguage"
        '
        'lbSpecialNote
        '
        Me.lbSpecialNote.AutoSize = True
        Me.lbSpecialNote.Location = New System.Drawing.Point(450, 75)
        Me.lbSpecialNote.Name = "lbSpecialNote"
        Me.lbSpecialNote.Size = New System.Drawing.Size(66, 13)
        Me.lbSpecialNote.TabIndex = 3
        Me.lbSpecialNote.Text = "Special note"
        '
        'tbUser
        '
        Me.tbUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbUser.Location = New System.Drawing.Point(126, 19)
        Me.tbUser.Name = "tbUser"
        Me.tbUser.Size = New System.Drawing.Size(213, 20)
        Me.tbUser.TabIndex = 2
        '
        'lbUser
        '
        Me.lbUser.AutoSize = True
        Me.lbUser.Location = New System.Drawing.Point(17, 22)
        Me.lbUser.Name = "lbUser"
        Me.lbUser.Size = New System.Drawing.Size(79, 13)
        Me.lbUser.TabIndex = 0
        Me.lbUser.Text = "Verified by user"
        '
        'lbOniSplitNote
        '
        Me.lbOniSplitNote.AutoSize = True
        Me.lbOniSplitNote.Location = New System.Drawing.Point(14, 133)
        Me.lbOniSplitNote.Name = "lbOniSplitNote"
        Me.lbOniSplitNote.Size = New System.Drawing.Size(449, 13)
        Me.lbOniSplitNote.TabIndex = 16
        Me.lbOniSplitNote.Text = "Keep things consistent: split original GDF *.dat into *.oni files by using OniSpl" &
    "it version 0.9.95.0"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 195)
        Me.Controls.Add(Me.lbOniSplitNote)
        Me.Controls.Add(Me.grpbUserStats)
        Me.Controls.Add(Me.tbInput)
        Me.Controls.Add(Me.btWriteChecksums)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 234)
        Me.MinimumSize = New System.Drawing.Size(800, 234)
        Me.Name = "Form1"
        Me.Text = "Oni checksums"
        Me.grpbUserStats.ResumeLayout(False)
        Me.grpbUserStats.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btWriteChecksums As Button
    Friend WithEvents tbInput As TextBox
    Friend WithEvents grpbUserStats As GroupBox
    Friend WithEvents cbPlateform As ComboBox
    Friend WithEvents lbPlateform As Label
    Friend WithEvents tbSpecialNote As TextBox
    Friend WithEvents lbLanguage As Label
    Friend WithEvents lbSpecialNote As Label
    Friend WithEvents tbUser As TextBox
    Friend WithEvents lbUser As Label
    Friend WithEvents cbLanguage As ComboBox
    Friend WithEvents lbStandAloneOrBundled As Label
    Friend WithEvents cbStandAloneOrBundled As ComboBox
    Friend WithEvents lbOniSplitNote As Label
    Friend WithEvents tbISBN As TextBox
    Friend WithEvents lbISBN As Label
End Class
