Option Explicit On
Option Strict On

Namespace xScreen.Gui
    ''' <summary>
    ''' Formular zum Verwalten der Konfigration.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class FormConfig

#Region " Construction "
        Public Sub New()
            Me.InitializeComponent()
            Me.Initialize()
        End Sub
#End Region

#Region " Implementation "
        Private Sub Initialize()
            Me.PropertyGridConfig.SelectedObject = Model.Configuration.Current
            Me.PropertyGridConfig.ToolbarVisible = False
            Me.PropertyGridConfig.PropertySort = PropertySort.Categorized
        End Sub

        Private Sub ValidateItem(Item As System.Windows.Forms.GridItem, OldValue As Object)
            If (Item.PropertyDescriptor.Name = "DirectoryPath") Then
                If (String.IsNullOrEmpty(CStr(Item.Value))) Then
                    MessageBox.Show("Empty path not allowed.")
                    Return
                End If
                If (Not System.IO.Directory.Exists(CStr(Item.Value))) Then
                    If (MessageBox.Show("Directory doesn't exists. Create it?", "Create directory?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                        System.IO.Directory.CreateDirectory(CStr(Item.Value))
                    End If
                    Return
                End If
            End If

            If (Item.PropertyDescriptor.Name = "Cycle") Then
                If (CInt(Item.Value) < 1) Then
                    MessageBox.Show("Cycle must be greater than 0.")
                    Return
                End If
            End If

            If (Item.PropertyDescriptor.Name = "Quality") Then
                If (CInt(Item.Value) < 1 OrElse CInt(Item.Value) > 100) Then
                    MessageBox.Show("Image quality value must be between 1 and 100.")
                    Return
                End If
            End If

            If (Item.PropertyDescriptor.Name = "SkipImageSimilarity") Then
                If (CDbl(Item.Value) < 1 OrElse CDbl(Item.Value) > 100) Then
                    MessageBox.Show("Image similarity value must be between 1 and 100.")
                    Return
                End If
            End If

            If (Item.PropertyDescriptor.Name = "ZipPackageSize") Then
                If (CInt(Item.Value) < 1) Then
                    MessageBox.Show("ZIP part size must be at least 1.")
                    Return
                End If
            End If
        End Sub

        Private Sub PropertyGridConfig_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PropertyGridConfig.PropertyValueChanged
            Me.ValidateItem(e.ChangedItem, e.OldValue)
        End Sub
#End Region

    End Class

End Namespace

