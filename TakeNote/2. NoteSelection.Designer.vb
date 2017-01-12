<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NoteSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NoteSelection))
        Me.cmdNewNote = New System.Windows.Forms.Button()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.pctSettings = New System.Windows.Forms.PictureBox()
        Me.pctSearch = New System.Windows.Forms.PictureBox()
        Me.rtxtSearch = New System.Windows.Forms.RichTextBox()
        Me.txtFirstLine = New System.Windows.Forms.TextBox()
        Me.lblNoNotes = New System.Windows.Forms.Label()
        Me.lblNoNotes1 = New System.Windows.Forms.Label()
        CType(Me.pctSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNewNote
        '
        Me.cmdNewNote.FlatAppearance.BorderSize = 0
        Me.cmdNewNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNewNote.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNewNote.ForeColor = System.Drawing.Color.Goldenrod
        Me.cmdNewNote.Location = New System.Drawing.Point(243, 0)
        Me.cmdNewNote.Name = "cmdNewNote"
        Me.cmdNewNote.Size = New System.Drawing.Size(50, 27)
        Me.cmdNewNote.TabIndex = 1
        Me.cmdNewNote.TabStop = False
        Me.cmdNewNote.Text = "New"
        Me.cmdNewNote.UseVisualStyleBackColor = True
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.ForeColor = System.Drawing.Color.Goldenrod
        Me.lblWelcome.Location = New System.Drawing.Point(40, 9)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(91, 21)
        Me.lblWelcome.TabIndex = 18
        Me.lblWelcome.Text = "lblWelcome"
        Me.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctSettings
        '
        Me.pctSettings.Image = CType(resources.GetObject("pctSettings.Image"), System.Drawing.Image)
        Me.pctSettings.Location = New System.Drawing.Point(12, 5)
        Me.pctSettings.Name = "pctSettings"
        Me.pctSettings.Size = New System.Drawing.Size(22, 22)
        Me.pctSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctSettings.TabIndex = 19
        Me.pctSettings.TabStop = False
        '
        'pctSearch
        '
        Me.pctSearch.Image = CType(resources.GetObject("pctSearch.Image"), System.Drawing.Image)
        Me.pctSearch.Location = New System.Drawing.Point(14, 32)
        Me.pctSearch.Name = "pctSearch"
        Me.pctSearch.Size = New System.Drawing.Size(21, 22)
        Me.pctSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctSearch.TabIndex = 22
        Me.pctSearch.TabStop = False
        '
        'rtxtSearch
        '
        Me.rtxtSearch.Location = New System.Drawing.Point(44, 33)
        Me.rtxtSearch.Name = "rtxtSearch"
        Me.rtxtSearch.Size = New System.Drawing.Size(210, 22)
        Me.rtxtSearch.TabIndex = 24
        Me.rtxtSearch.Text = ""
        Me.rtxtSearch.Visible = False
        '
        'txtFirstLine
        '
        Me.txtFirstLine.BackColor = System.Drawing.Color.Black
        Me.txtFirstLine.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFirstLine.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtFirstLine.Location = New System.Drawing.Point(-6, 63)
        Me.txtFirstLine.Multiline = True
        Me.txtFirstLine.Name = "txtFirstLine"
        Me.txtFirstLine.Size = New System.Drawing.Size(308, 1)
        Me.txtFirstLine.TabIndex = 15
        '
        'lblNoNotes
        '
        Me.lblNoNotes.AutoSize = True
        Me.lblNoNotes.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoNotes.ForeColor = System.Drawing.Color.Goldenrod
        Me.lblNoNotes.Location = New System.Drawing.Point(39, 130)
        Me.lblNoNotes.Name = "lblNoNotes"
        Me.lblNoNotes.Size = New System.Drawing.Size(227, 30)
        Me.lblNoNotes.TabIndex = 25
        Me.lblNoNotes.Text = "404: No Notes Found :("
        Me.lblNoNotes.Visible = False
        '
        'lblNoNotes1
        '
        Me.lblNoNotes1.AutoSize = True
        Me.lblNoNotes1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoNotes1.ForeColor = System.Drawing.Color.Goldenrod
        Me.lblNoNotes1.Location = New System.Drawing.Point(16, 172)
        Me.lblNoNotes1.Name = "lblNoNotes1"
        Me.lblNoNotes1.Size = New System.Drawing.Size(280, 25)
        Me.lblNoNotes1.TabIndex = 26
        Me.lblNoNotes1.Text = "Use the New button to add one!"
        Me.lblNoNotes1.Visible = False
        '
        'NoteSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(310, 335)
        Me.Controls.Add(Me.lblNoNotes1)
        Me.Controls.Add(Me.lblNoNotes)
        Me.Controls.Add(Me.rtxtSearch)
        Me.Controls.Add(Me.pctSearch)
        Me.Controls.Add(Me.pctSettings)
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.txtFirstLine)
        Me.Controls.Add(Me.cmdNewNote)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(326, 374)
        Me.MinimumSize = New System.Drawing.Size(326, 374)
        Me.Name = "NoteSelection"
        Me.Text = "Please select a note!"
        CType(Me.pctSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdNewNote As Button
    Friend WithEvents lblWelcome As Label
    Friend WithEvents pctSearch As PictureBox
    Private WithEvents pctSettings As PictureBox
    Friend WithEvents rtxtSearch As RichTextBox
    Friend WithEvents txtFirstLine As TextBox
    Friend WithEvents lblNoNotes As Label
    Friend WithEvents lblNoNotes1 As Label
End Class
