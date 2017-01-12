<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OutputFramework
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OutputFramework))
        Me.tmrPug = New System.Windows.Forms.Timer(Me.components)
        Me.pctOutput = New System.Windows.Forms.PictureBox()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.lblEnterPassword = New System.Windows.Forms.Label()
        Me.tlpOutput = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        CType(Me.pctOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpOutput.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrPug
        '
        Me.tmrPug.Enabled = True
        '
        'pctOutput
        '
        Me.pctOutput.Location = New System.Drawing.Point(-1, -1)
        Me.pctOutput.Name = "pctOutput"
        Me.pctOutput.Size = New System.Drawing.Size(437, 316)
        Me.pctOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctOutput.TabIndex = 24
        Me.pctOutput.TabStop = False
        '
        'txtInput
        '
        Me.txtInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInput.Location = New System.Drawing.Point(12, 39)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtInput.Size = New System.Drawing.Size(409, 26)
        Me.txtInput.TabIndex = 25
        '
        'lblEnterPassword
        '
        Me.lblEnterPassword.AutoSize = True
        Me.lblEnterPassword.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnterPassword.Location = New System.Drawing.Point(7, 7)
        Me.lblEnterPassword.Name = "lblEnterPassword"
        Me.lblEnterPassword.Size = New System.Drawing.Size(247, 25)
        Me.lblEnterPassword.TabIndex = 26
        Me.lblEnterPassword.Text = "Please enter your password."
        '
        'tlpOutput
        '
        Me.tlpOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpOutput.ColumnCount = 2
        Me.tlpOutput.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpOutput.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpOutput.Controls.Add(Me.OK_Button, 0, 0)
        Me.tlpOutput.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.tlpOutput.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.tlpOutput.Location = New System.Drawing.Point(271, 275)
        Me.tlpOutput.Name = "tlpOutput"
        Me.tlpOutput.RowCount = 1
        Me.tlpOutput.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpOutput.Size = New System.Drawing.Size(146, 29)
        Me.tlpOutput.TabIndex = 23
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 27
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 28
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'OutputFramework
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 312)
        Me.Controls.Add(Me.lblEnterPassword)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.tlpOutput)
        Me.Controls.Add(Me.pctOutput)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OutputFramework"
        Me.Text = "Password Entry"
        Me.TopMost = True
        CType(Me.pctOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpOutput.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tmrPug As Timer
    Friend WithEvents pctOutput As PictureBox
    Friend WithEvents txtInput As TextBox
    Friend WithEvents lblEnterPassword As Label
    Friend WithEvents tlpOutput As TableLayoutPanel
    Friend WithEvents OK_Button As Button
    Friend WithEvents Cancel_Button As Button
End Class
