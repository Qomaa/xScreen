Namespace xScreen.Gui
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FormInfo
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInfo))
            Me.TextBoxInfo = New System.Windows.Forms.TextBox()
            Me.SuspendLayout()
            '
            'TextBoxInfo
            '
            Me.TextBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TextBoxInfo.Location = New System.Drawing.Point(0, 0)
            Me.TextBoxInfo.Multiline = True
            Me.TextBoxInfo.Name = "TextBoxInfo"
            Me.TextBoxInfo.ReadOnly = True
            Me.TextBoxInfo.Size = New System.Drawing.Size(642, 465)
            Me.TextBoxInfo.TabIndex = 0
            '
            'FormInfo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(642, 465)
            Me.Controls.Add(Me.TextBoxInfo)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FormInfo"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Info"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents TextBoxInfo As TextBox
    End Class
End Namespace