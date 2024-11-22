<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.dataGridViewProcesses = New System.Windows.Forms.DataGridView()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.BtnEndProcess = New System.Windows.Forms.Button()
        CType(Me.dataGridViewProcesses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dataGridViewProcesses
        '
        Me.dataGridViewProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridViewProcesses.Location = New System.Drawing.Point(22, 26)
        Me.dataGridViewProcesses.Name = "dataGridViewProcesses"
        Me.dataGridViewProcesses.Size = New System.Drawing.Size(532, 265)
        Me.dataGridViewProcesses.TabIndex = 0
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(22, 311)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'BtnEndProcess
        '
        Me.BtnEndProcess.Location = New System.Drawing.Point(470, 311)
        Me.BtnEndProcess.Name = "BtnEndProcess"
        Me.BtnEndProcess.Size = New System.Drawing.Size(75, 23)
        Me.BtnEndProcess.TabIndex = 2
        Me.BtnEndProcess.Text = "End"
        Me.BtnEndProcess.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 346)
        Me.Controls.Add(Me.BtnEndProcess)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.dataGridViewProcesses)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Task manager"
        CType(Me.dataGridViewProcesses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dataGridViewProcesses As System.Windows.Forms.DataGridView
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents BtnEndProcess As System.Windows.Forms.Button

End Class
