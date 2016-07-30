Namespace xScreen.Gui
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FormConfig
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfig))
            Me.PropertyGridConfig = New System.Windows.Forms.PropertyGrid()
            Me.SuspendLayout()
            '
            'PropertyGridConfig
            '
            Me.PropertyGridConfig.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PropertyGridConfig.Location = New System.Drawing.Point(0, 0)
            Me.PropertyGridConfig.Name = "PropertyGridConfig"
            Me.PropertyGridConfig.PropertySort = System.Windows.Forms.PropertySort.NoSort
            Me.PropertyGridConfig.Size = New System.Drawing.Size(377, 487)
            Me.PropertyGridConfig.TabIndex = 0
            Me.PropertyGridConfig.ToolbarVisible = False
            '
            'FormConfig
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(377, 487)
            Me.Controls.Add(Me.PropertyGridConfig)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "FormConfig"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "config"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PropertyGridConfig As System.Windows.Forms.PropertyGrid
    End Class
End Namespace

