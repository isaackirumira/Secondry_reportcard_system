<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegisterClassesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageStudentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageSubjectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageTeachersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecordMarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageDatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecordMarksALevelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ANALYSISToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe Print", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Red
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 339)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Main Panel"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Report_Cards.My.Resources.Resources.edit_validated_icon11
        Me.PictureBox1.Location = New System.Drawing.Point(6, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(197, 303)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(234, 29)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegisterClassesToolStripMenuItem, Me.ManageStudentsToolStripMenuItem, Me.ManageSubjectsToolStripMenuItem, Me.ManageTeachersToolStripMenuItem, Me.RecordMarksToolStripMenuItem, Me.LogoutToolStripMenuItem, Me.ManageDatesToolStripMenuItem, Me.RecordMarksALevelToolStripMenuItem, Me.ANALYSISToolStripMenuItem})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Segoe Print", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(41, 25)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'RegisterClassesToolStripMenuItem
        '
        Me.RegisterClassesToolStripMenuItem.Image = Global.Report_Cards.My.Resources.Resources.Floppy_Small_icon
        Me.RegisterClassesToolStripMenuItem.Name = "RegisterClassesToolStripMenuItem"
        Me.RegisterClassesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.RegisterClassesToolStripMenuItem.Size = New System.Drawing.Size(258, 26)
        Me.RegisterClassesToolStripMenuItem.Text = "Manage Classes"
        '
        'ManageStudentsToolStripMenuItem
        '
        Me.ManageStudentsToolStripMenuItem.Image = Global.Report_Cards.My.Resources.Resources.Actions_document_edit_icon1
        Me.ManageStudentsToolStripMenuItem.Name = "ManageStudentsToolStripMenuItem"
        Me.ManageStudentsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ManageStudentsToolStripMenuItem.Size = New System.Drawing.Size(258, 26)
        Me.ManageStudentsToolStripMenuItem.Text = "Manage Students"
        '
        'ManageSubjectsToolStripMenuItem
        '
        Me.ManageSubjectsToolStripMenuItem.Image = Global.Report_Cards.My.Resources.Resources.Basic_Update_icon
        Me.ManageSubjectsToolStripMenuItem.Name = "ManageSubjectsToolStripMenuItem"
        Me.ManageSubjectsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.ManageSubjectsToolStripMenuItem.Size = New System.Drawing.Size(258, 26)
        Me.ManageSubjectsToolStripMenuItem.Text = "Manage Subjects"
        '
        'ManageTeachersToolStripMenuItem
        '
        Me.ManageTeachersToolStripMenuItem.Image = Global.Report_Cards.My.Resources.Resources.App_login_manager_icon1
        Me.ManageTeachersToolStripMenuItem.Name = "ManageTeachersToolStripMenuItem"
        Me.ManageTeachersToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.ManageTeachersToolStripMenuItem.Size = New System.Drawing.Size(258, 26)
        Me.ManageTeachersToolStripMenuItem.Text = "Manage Teachers"
        '
        'RecordMarksToolStripMenuItem
        '
        Me.RecordMarksToolStripMenuItem.Image = Global.Report_Cards.My.Resources.Resources.Actions_document_save_as_icon
        Me.RecordMarksToolStripMenuItem.Name = "RecordMarksToolStripMenuItem"
        Me.RecordMarksToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.RecordMarksToolStripMenuItem.Size = New System.Drawing.Size(258, 26)
        Me.RecordMarksToolStripMenuItem.Text = "Record Marks OLevel"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LogoutToolStripMenuItem.Image = Global.Report_Cards.My.Resources.Resources.login_icon
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(258, 26)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'ManageDatesToolStripMenuItem
        '
        Me.ManageDatesToolStripMenuItem.Image = Global.Report_Cards.My.Resources.Resources.Actions_arrow_right_double_icon2
        Me.ManageDatesToolStripMenuItem.Name = "ManageDatesToolStripMenuItem"
        Me.ManageDatesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ManageDatesToolStripMenuItem.Size = New System.Drawing.Size(258, 26)
        Me.ManageDatesToolStripMenuItem.Text = "Manage Dates"
        '
        'RecordMarksALevelToolStripMenuItem
        '
        Me.RecordMarksALevelToolStripMenuItem.Image = Global.Report_Cards.My.Resources.Resources.Register_icon2
        Me.RecordMarksALevelToolStripMenuItem.Name = "RecordMarksALevelToolStripMenuItem"
        Me.RecordMarksALevelToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.RecordMarksALevelToolStripMenuItem.Size = New System.Drawing.Size(258, 26)
        Me.RecordMarksALevelToolStripMenuItem.Text = "Record Marks ALevel"
        '
        'ANALYSISToolStripMenuItem
        '
        Me.ANALYSISToolStripMenuItem.Name = "ANALYSISToolStripMenuItem"
        Me.ANALYSISToolStripMenuItem.Size = New System.Drawing.Size(258, 26)
        Me.ANALYSISToolStripMenuItem.Text = "ANALYSIS"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(234, 385)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.Text = "ORION"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegisterClassesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageStudentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageSubjectsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageTeachersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RecordMarksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageDatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecordMarksALevelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ANALYSISToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
