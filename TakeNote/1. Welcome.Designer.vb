<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Welcome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Welcome))
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.cmdAbout = New System.Windows.Forms.Button()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.pctWelcome = New System.Windows.Forms.PictureBox()
        CType(Me.pctWelcome, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.BackColor = System.Drawing.Color.Transparent
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.ForeColor = System.Drawing.Color.Goldenrod
        Me.lblWelcome.Location = New System.Drawing.Point(200, 108)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(154, 30)
        Me.lblWelcome.TabIndex = 2
        Me.lblWelcome.Text = "By Liam Harper"
        '
        'cmdAbout
        '
        Me.cmdAbout.Cursor = System.Windows.Forms.Cursors.Help
        Me.cmdAbout.Location = New System.Drawing.Point(363, 168)
        Me.cmdAbout.Name = "cmdAbout"
        Me.cmdAbout.Size = New System.Drawing.Size(29, 23)
        Me.cmdAbout.TabIndex = 3
        Me.cmdAbout.Text = "?"
        Me.cmdAbout.UseVisualStyleBackColor = True
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblStart.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStart.ForeColor = System.Drawing.Color.Goldenrod
        Me.lblStart.Location = New System.Drawing.Point(176, 43)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(236, 65)
        Me.lblStart.TabIndex = 5
        Me.lblStart.Text = "TakeNote."
        '
        'pctWelcome
        '
        Me.pctWelcome.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctWelcome.Image = CType(resources.GetObject("pctWelcome.Image"), System.Drawing.Image)
        Me.pctWelcome.Location = New System.Drawing.Point(22, 25)
        Me.pctWelcome.Name = "pctWelcome"
        Me.pctWelcome.Size = New System.Drawing.Size(148, 141)
        Me.pctWelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctWelcome.TabIndex = 4
        Me.pctWelcome.TabStop = False
        '
        'Welcome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(404, 203)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.pctWelcome)
        Me.Controls.Add(Me.cmdAbout)
        Me.Controls.Add(Me.lblWelcome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(420, 242)
        Me.MinimumSize = New System.Drawing.Size(420, 242)
        Me.Name = "Welcome"
        Me.Text = "Welcome!"
        CType(Me.pctWelcome, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
    Friend WithEvents cmdAbout As System.Windows.Forms.Button
    Friend WithEvents pctWelcome As PictureBox
    Friend WithEvents lblStart As Label
End Class
