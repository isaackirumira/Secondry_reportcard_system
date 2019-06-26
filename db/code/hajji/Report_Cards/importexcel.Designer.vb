<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class importexcel
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
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbHeaderYes = New System.Windows.Forms.RadioButton()
        Me.rbHeaderNo = New System.Windows.Forms.RadioButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.dataGridView1.Location = New System.Drawing.Point(12, 51)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.Size = New System.Drawing.Size(1164, 686)
        Me.dataGridView1.TabIndex = 8
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(12, 20)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(107, 23)
        Me.btnSelect.TabIndex = 9
        Me.btnSelect.Text = "Select File"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(134, 22)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(42, 13)
        Me.label1.TabIndex = 10
        Me.label1.Text = "Header"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.rbHeaderYes)
        Me.groupBox1.Controls.Add(Me.rbHeaderNo)
        Me.groupBox1.Location = New System.Drawing.Point(182, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(98, 33)
        Me.groupBox1.TabIndex = 11
        Me.groupBox1.TabStop = False
        '
        'rbHeaderYes
        '
        Me.rbHeaderYes.AutoSize = True
        Me.rbHeaderYes.Checked = True
        Me.rbHeaderYes.Location = New System.Drawing.Point(6, 11)
        Me.rbHeaderYes.Name = "rbHeaderYes"
        Me.rbHeaderYes.Size = New System.Drawing.Size(43, 17)
        Me.rbHeaderYes.TabIndex = 7
        Me.rbHeaderYes.TabStop = True
        Me.rbHeaderYes.Text = "Yes"
        Me.rbHeaderYes.UseVisualStyleBackColor = True
        '
        'rbHeaderNo
        '
        Me.rbHeaderNo.Location = New System.Drawing.Point(55, 11)
        Me.rbHeaderNo.Name = "rbHeaderNo"
        Me.rbHeaderNo.Size = New System.Drawing.Size(85, 17)
        Me.rbHeaderNo.TabIndex = 6
        Me.rbHeaderNo.Text = "No"
        Me.rbHeaderNo.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(306, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Save Imported Data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(475, 23)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(241, 23)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Clear Row(s)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'importexcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1188, 749)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.dataGridView1)
        Me.Name = "importexcel"
        Me.Text = "importexcel"
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents btnSelect As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents rbHeaderYes As System.Windows.Forms.RadioButton
    Private WithEvents rbHeaderNo As System.Windows.Forms.RadioButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
