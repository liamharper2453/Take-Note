<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.lblAboutLine1 = New System.Windows.Forms.Label()
        Me.lblAboutLine2 = New System.Windows.Forms.Label()
        Me.pctPug = New System.Windows.Forms.PictureBox()
        CType(Me.pctPug, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAboutLine1
        '
        Me.lblAboutLine1.AutoSize = True
        Me.lblAboutLine1.BackColor = System.Drawing.Color.Snow
        Me.lblAboutLine1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAboutLine1.ForeColor = System.Drawing.Color.Goldenrod
        Me.lblAboutLine1.Location = New System.Drawing.Point(14, 195)
        Me.lblAboutLine1.Name = "lblAboutLine1"
        Me.lblAboutLine1.Size = New System.Drawing.Size(359, 21)
        Me.lblAboutLine1.TabIndex = 2
        Me.lblAboutLine1.Text = "Take Note is an application intended to take notes. "
        '
        'lblAboutLine2
        '
        Me.lblAboutLine2.AutoSize = True
        Me.lblAboutLine2.BackColor = System.Drawing.Color.Snow
        Me.lblAboutLine2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAboutLine2.ForeColor = System.Drawing.Color.Goldenrod
        Me.lblAboutLine2.Location = New System.Drawing.Point(119, 226)
        Me.lblAboutLine2.Name = "lblAboutLine2"
        Me.lblAboutLine2.Size = New System.Drawing.Size(133, 21)
        Me.lblAboutLine2.TabIndex = 3
        Me.lblAboutLine2.Text = "Also, water is wet."
        '
        'pctPug
        '
        Me.pctPug.Cursor = System.Windows.Forms.Cursors.Help
        Me.pctPug.Image = CType(resources.GetObject("pctPug.Image"), System.Drawing.Image)
        Me.pctPug.Location = New System.Drawing.Point(33, 12)
        Me.pctPug.Name = "pctPug"
        Me.pctPug.Size = New System.Drawing.Size(323, 168)
        Me.pctPug.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctPug.TabIndex = 0
        Me.pctPug.TabStop = False
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(387, 266)
        Me.Controls.Add(Me.lblAboutLine2)
        Me.Controls.Add(Me.lblAboutLine1)
        Me.Controls.Add(Me.pctPug)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(403, 305)
        Me.MinimumSize = New System.Drawing.Size(403, 305)
        Me.Name = "About"
        Me.Text = "About"
        CType(Me.pctPug, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pctPug As System.Windows.Forms.PictureBox
    Friend WithEvents lblAboutLine1 As System.Windows.Forms.Label
    Friend WithEvents lblAboutLine2 As System.Windows.Forms.Label
End Class
