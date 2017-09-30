<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBasicPotion = New System.Windows.Forms.Label()
        Me.lblSuperPotion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblRevive = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(78, 102)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightBlue
        Me.Label1.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(92, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(319, 102)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Simple Potion"
        '
        'lblBasicPotion
        '
        Me.lblBasicPotion.AutoSize = True
        Me.lblBasicPotion.BackColor = System.Drawing.Color.LightBlue
        Me.lblBasicPotion.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBasicPotion.Location = New System.Drawing.Point(355, 79)
        Me.lblBasicPotion.Name = "lblBasicPotion"
        Me.lblBasicPotion.Size = New System.Drawing.Size(0, 35)
        Me.lblBasicPotion.TabIndex = 2
        '
        'lblSuperPotion
        '
        Me.lblSuperPotion.AutoSize = True
        Me.lblSuperPotion.BackColor = System.Drawing.Color.LightBlue
        Me.lblSuperPotion.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuperPotion.Location = New System.Drawing.Point(355, 193)
        Me.lblSuperPotion.Name = "lblSuperPotion"
        Me.lblSuperPotion.Size = New System.Drawing.Size(0, 35)
        Me.lblSuperPotion.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightBlue
        Me.Label3.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(92, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(319, 102)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Super Potion"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(12, 126)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(78, 102)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'lblRevive
        '
        Me.lblRevive.AutoSize = True
        Me.lblRevive.BackColor = System.Drawing.Color.LightBlue
        Me.lblRevive.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRevive.Location = New System.Drawing.Point(355, 301)
        Me.lblRevive.Name = "lblRevive"
        Me.lblRevive.Size = New System.Drawing.Size(0, 35)
        Me.lblRevive.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightBlue
        Me.Label4.Font = New System.Drawing.Font("Calibri", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(92, 234)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(319, 102)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Revive"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(12, 234)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(78, 102)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Khaki
        Me.ClientSize = New System.Drawing.Size(427, 342)
        Me.Controls.Add(Me.lblRevive)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.lblSuperPotion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lblBasicPotion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form3"
        Me.Text = "Bag"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblBasicPotion As Label
    Friend WithEvents lblSuperPotion As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblRevive As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox3 As PictureBox
End Class
