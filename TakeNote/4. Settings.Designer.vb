<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.lblLanguage = New System.Windows.Forms.Label()
        Me.lblTheme = New System.Windows.Forms.Label()
        Me.txtFirstLine = New System.Windows.Forms.TextBox()
        Me.txtSecondLine = New System.Windows.Forms.TextBox()
        Me.txtThirdLine = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.cmdChangePassword = New System.Windows.Forms.Button()
        Me.cmdEnglish = New System.Windows.Forms.Button()
        Me.cmdSpanish = New System.Windows.Forms.Button()
        Me.lblSettings = New System.Windows.Forms.Label()
        Me.lblFirebrick = New System.Windows.Forms.Label()
        Me.lblDark = New System.Windows.Forms.Label()
        Me.lblLight = New System.Windows.Forms.Label()
        Me.lblSeaGreen = New System.Windows.Forms.Label()
        Me.lblDarkOrchid = New System.Windows.Forms.Label()
        Me.cmdCustom = New System.Windows.Forms.Button()
        Me.pctSettings = New System.Windows.Forms.PictureBox()
        Me.lblSteelBlue = New System.Windows.Forms.Label()
        Me.lblMaroon = New System.Windows.Forms.Label()
        Me.lblDarkPink = New System.Windows.Forms.Label()
        Me.lblBlack = New System.Windows.Forms.Label()
        Me.lblDimGray = New System.Windows.Forms.Label()
        Me.lblDarkGreen = New System.Windows.Forms.Label()
        Me.lblOrange = New System.Windows.Forms.Label()
        CType(Me.pctSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = True
        Me.lblLanguage.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLanguage.ForeColor = System.Drawing.Color.Goldenrod
        Me.lblLanguage.Location = New System.Drawing.Point(12, 73)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(81, 21)
        Me.lblLanguage.TabIndex = 0
        Me.lblLanguage.Text = "Language:"
        '
        'lblTheme
        '
        Me.lblTheme.AutoSize = True
        Me.lblTheme.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTheme.ForeColor = System.Drawing.Color.Goldenrod
        Me.lblTheme.Location = New System.Drawing.Point(12, 121)
        Me.lblTheme.Name = "lblTheme"
        Me.lblTheme.Size = New System.Drawing.Size(60, 21)
        Me.lblTheme.TabIndex = 1
        Me.lblTheme.Text = "Theme:"
        '
        'txtFirstLine
        '
        Me.txtFirstLine.BackColor = System.Drawing.Color.Black
        Me.txtFirstLine.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFirstLine.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFirstLine.Location = New System.Drawing.Point(-6, 57)
        Me.txtFirstLine.Multiline = True
        Me.txtFirstLine.Name = "txtFirstLine"
        Me.txtFirstLine.Size = New System.Drawing.Size(321, 1)
        Me.txtFirstLine.TabIndex = 16
        '
        'txtSecondLine
        '
        Me.txtSecondLine.BackColor = System.Drawing.Color.Black
        Me.txtSecondLine.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSecondLine.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSecondLine.Location = New System.Drawing.Point(-6, 108)
        Me.txtSecondLine.Multiline = True
        Me.txtSecondLine.Name = "txtSecondLine"
        Me.txtSecondLine.Size = New System.Drawing.Size(321, 1)
        Me.txtSecondLine.TabIndex = 17
        '
        'txtThirdLine
        '
        Me.txtThirdLine.BackColor = System.Drawing.Color.Black
        Me.txtThirdLine.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtThirdLine.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtThirdLine.Location = New System.Drawing.Point(-6, 180)
        Me.txtThirdLine.Multiline = True
        Me.txtThirdLine.Name = "txtThirdLine"
        Me.txtThirdLine.Size = New System.Drawing.Size(321, 1)
        Me.txtThirdLine.TabIndex = 18
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.Goldenrod
        Me.lblPassword.Location = New System.Drawing.Point(14, 193)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(79, 21)
        Me.lblPassword.TabIndex = 22
        Me.lblPassword.Text = "Password:"
        '
        'cmdChangePassword
        '
        Me.cmdChangePassword.Location = New System.Drawing.Point(99, 194)
        Me.cmdChangePassword.Name = "cmdChangePassword"
        Me.cmdChangePassword.Size = New System.Drawing.Size(165, 23)
        Me.cmdChangePassword.TabIndex = 23
        Me.cmdChangePassword.Text = "Change Password"
        Me.cmdChangePassword.UseVisualStyleBackColor = True
        '
        'cmdEnglish
        '
        Me.cmdEnglish.Location = New System.Drawing.Point(107, 74)
        Me.cmdEnglish.Name = "cmdEnglish"
        Me.cmdEnglish.Size = New System.Drawing.Size(75, 23)
        Me.cmdEnglish.TabIndex = 24
        Me.cmdEnglish.Text = "English"
        Me.cmdEnglish.UseVisualStyleBackColor = True
        '
        'cmdSpanish
        '
        Me.cmdSpanish.Location = New System.Drawing.Point(197, 74)
        Me.cmdSpanish.Name = "cmdSpanish"
        Me.cmdSpanish.Size = New System.Drawing.Size(75, 23)
        Me.cmdSpanish.TabIndex = 25
        Me.cmdSpanish.Text = "Spanish"
        Me.cmdSpanish.UseVisualStyleBackColor = True
        '
        'lblSettings
        '
        Me.lblSettings.AutoSize = True
        Me.lblSettings.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSettings.ForeColor = System.Drawing.Color.Goldenrod
        Me.lblSettings.Location = New System.Drawing.Point(66, 9)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(140, 30)
        Me.lblSettings.TabIndex = 27
        Me.lblSettings.Text = "Configuration"
        '
        'lblFirebrick
        '
        Me.lblFirebrick.AutoSize = True
        Me.lblFirebrick.BackColor = System.Drawing.Color.Firebrick
        Me.lblFirebrick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFirebrick.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblFirebrick.ForeColor = System.Drawing.Color.Firebrick
        Me.lblFirebrick.Location = New System.Drawing.Point(83, 146)
        Me.lblFirebrick.Name = "lblFirebrick"
        Me.lblFirebrick.Size = New System.Drawing.Size(21, 15)
        Me.lblFirebrick.TabIndex = 28
        Me.lblFirebrick.Text = "00"
        '
        'lblDark
        '
        Me.lblDark.AutoSize = True
        Me.lblDark.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.lblDark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDark.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblDark.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.lblDark.Location = New System.Drawing.Point(83, 127)
        Me.lblDark.Name = "lblDark"
        Me.lblDark.Size = New System.Drawing.Size(21, 15)
        Me.lblDark.TabIndex = 29
        Me.lblDark.Text = "00"
        '
        'lblLight
        '
        Me.lblLight.AutoSize = True
        Me.lblLight.BackColor = System.Drawing.Color.White
        Me.lblLight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLight.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblLight.ForeColor = System.Drawing.Color.White
        Me.lblLight.Location = New System.Drawing.Point(110, 127)
        Me.lblLight.Name = "lblLight"
        Me.lblLight.Size = New System.Drawing.Size(21, 15)
        Me.lblLight.TabIndex = 30
        Me.lblLight.Text = "00"
        '
        'lblSeaGreen
        '
        Me.lblSeaGreen.AutoSize = True
        Me.lblSeaGreen.BackColor = System.Drawing.Color.Indigo
        Me.lblSeaGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSeaGreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSeaGreen.ForeColor = System.Drawing.Color.Indigo
        Me.lblSeaGreen.Location = New System.Drawing.Point(191, 127)
        Me.lblSeaGreen.Name = "lblSeaGreen"
        Me.lblSeaGreen.Size = New System.Drawing.Size(21, 15)
        Me.lblSeaGreen.TabIndex = 31
        Me.lblSeaGreen.Text = "00"
        '
        'lblDarkOrchid
        '
        Me.lblDarkOrchid.AutoSize = True
        Me.lblDarkOrchid.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.lblDarkOrchid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDarkOrchid.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblDarkOrchid.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lblDarkOrchid.Location = New System.Drawing.Point(218, 127)
        Me.lblDarkOrchid.Name = "lblDarkOrchid"
        Me.lblDarkOrchid.Size = New System.Drawing.Size(21, 15)
        Me.lblDarkOrchid.TabIndex = 33
        Me.lblDarkOrchid.Text = "00"
        '
        'cmdCustom
        '
        Me.cmdCustom.Location = New System.Drawing.Point(247, 132)
        Me.cmdCustom.Name = "cmdCustom"
        Me.cmdCustom.Size = New System.Drawing.Size(50, 21)
        Me.cmdCustom.TabIndex = 34
        Me.cmdCustom.Text = "Custom"
        Me.cmdCustom.UseVisualStyleBackColor = True
        '
        'pctSettings
        '
        Me.pctSettings.Image = CType(resources.GetObject("pctSettings.Image"), System.Drawing.Image)
        Me.pctSettings.Location = New System.Drawing.Point(16, 7)
        Me.pctSettings.Name = "pctSettings"
        Me.pctSettings.Size = New System.Drawing.Size(44, 44)
        Me.pctSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctSettings.TabIndex = 26
        Me.pctSettings.TabStop = False
        '
        'lblSteelBlue
        '
        Me.lblSteelBlue.AutoSize = True
        Me.lblSteelBlue.BackColor = System.Drawing.Color.SteelBlue
        Me.lblSteelBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSteelBlue.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSteelBlue.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblSteelBlue.Location = New System.Drawing.Point(164, 127)
        Me.lblSteelBlue.Name = "lblSteelBlue"
        Me.lblSteelBlue.Size = New System.Drawing.Size(21, 15)
        Me.lblSteelBlue.TabIndex = 32
        Me.lblSteelBlue.Text = "00"
        '
        'lblMaroon
        '
        Me.lblMaroon.AutoSize = True
        Me.lblMaroon.BackColor = System.Drawing.Color.Maroon
        Me.lblMaroon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMaroon.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblMaroon.ForeColor = System.Drawing.Color.Maroon
        Me.lblMaroon.Location = New System.Drawing.Point(137, 127)
        Me.lblMaroon.Name = "lblMaroon"
        Me.lblMaroon.Size = New System.Drawing.Size(21, 15)
        Me.lblMaroon.TabIndex = 40
        Me.lblMaroon.Text = "00"
        '
        'lblDarkPink
        '
        Me.lblDarkPink.AutoSize = True
        Me.lblDarkPink.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDarkPink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDarkPink.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblDarkPink.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDarkPink.Location = New System.Drawing.Point(191, 146)
        Me.lblDarkPink.Name = "lblDarkPink"
        Me.lblDarkPink.Size = New System.Drawing.Size(21, 15)
        Me.lblDarkPink.TabIndex = 39
        Me.lblDarkPink.Text = "00"
        '
        'lblBlack
        '
        Me.lblBlack.AutoSize = True
        Me.lblBlack.BackColor = System.Drawing.Color.Black
        Me.lblBlack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBlack.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblBlack.ForeColor = System.Drawing.Color.Black
        Me.lblBlack.Location = New System.Drawing.Point(164, 146)
        Me.lblBlack.Name = "lblBlack"
        Me.lblBlack.Size = New System.Drawing.Size(21, 15)
        Me.lblBlack.TabIndex = 38
        Me.lblBlack.Text = "00"
        '
        'lblDimGray
        '
        Me.lblDimGray.AutoSize = True
        Me.lblDimGray.BackColor = System.Drawing.Color.DimGray
        Me.lblDimGray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDimGray.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblDimGray.ForeColor = System.Drawing.Color.DimGray
        Me.lblDimGray.Location = New System.Drawing.Point(110, 146)
        Me.lblDimGray.Name = "lblDimGray"
        Me.lblDimGray.Size = New System.Drawing.Size(21, 15)
        Me.lblDimGray.TabIndex = 37
        Me.lblDimGray.Text = "00"
        '
        'lblDarkGreen
        '
        Me.lblDarkGreen.AutoSize = True
        Me.lblDarkGreen.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDarkGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDarkGreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblDarkGreen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDarkGreen.Location = New System.Drawing.Point(218, 146)
        Me.lblDarkGreen.Name = "lblDarkGreen"
        Me.lblDarkGreen.Size = New System.Drawing.Size(21, 15)
        Me.lblDarkGreen.TabIndex = 36
        Me.lblDarkGreen.Text = "00"
        '
        'lblOrange
        '
        Me.lblOrange.AutoSize = True
        Me.lblOrange.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblOrange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrange.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblOrange.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblOrange.Location = New System.Drawing.Point(137, 146)
        Me.lblOrange.Name = "lblOrange"
        Me.lblOrange.Size = New System.Drawing.Size(21, 15)
        Me.lblOrange.TabIndex = 35
        Me.lblOrange.Text = "00"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(306, 232)
        Me.Controls.Add(Me.lblMaroon)
        Me.Controls.Add(Me.lblDarkPink)
        Me.Controls.Add(Me.lblBlack)
        Me.Controls.Add(Me.lblDimGray)
        Me.Controls.Add(Me.lblDarkGreen)
        Me.Controls.Add(Me.lblOrange)
        Me.Controls.Add(Me.cmdCustom)
        Me.Controls.Add(Me.lblDarkOrchid)
        Me.Controls.Add(Me.lblSteelBlue)
        Me.Controls.Add(Me.lblSeaGreen)
        Me.Controls.Add(Me.lblLight)
        Me.Controls.Add(Me.lblDark)
        Me.Controls.Add(Me.lblFirebrick)
        Me.Controls.Add(Me.lblSettings)
        Me.Controls.Add(Me.pctSettings)
        Me.Controls.Add(Me.cmdSpanish)
        Me.Controls.Add(Me.cmdEnglish)
        Me.Controls.Add(Me.cmdChangePassword)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtThirdLine)
        Me.Controls.Add(Me.txtSecondLine)
        Me.Controls.Add(Me.txtFirstLine)
        Me.Controls.Add(Me.lblTheme)
        Me.Controls.Add(Me.lblLanguage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(322, 271)
        Me.MinimumSize = New System.Drawing.Size(322, 271)
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.TopMost = True
        CType(Me.pctSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblLanguage As Label
    Friend WithEvents lblTheme As Label
    Friend WithEvents txtSecondLine As TextBox
    Friend WithEvents txtThirdLine As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents cmdChangePassword As Button
    Friend WithEvents cmdEnglish As Button
    Friend WithEvents cmdSpanish As Button
    Friend WithEvents pctSettings As PictureBox
    Friend WithEvents lblSettings As Label
    Friend WithEvents lblFirebrick As Label
    Friend WithEvents lblDark As Label
    Friend WithEvents lblLight As Label
    Friend WithEvents lblSeaGreen As Label
    Friend WithEvents lblDarkOrchid As Label
    Friend WithEvents cmdCustom As Button
    Friend WithEvents lblSteelBlue As Label
    Friend WithEvents lblMaroon As Label
    Friend WithEvents lblDarkPink As Label
    Friend WithEvents lblBlack As Label
    Friend WithEvents lblDimGray As Label
    Friend WithEvents lblDarkGreen As Label
    Friend WithEvents lblOrange As Label
    Friend WithEvents txtFirstLine As TextBox
End Class
