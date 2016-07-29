Option Explicit On
Option Strict On


Namespace xScreen.Model
    ''' <summary>
    ''' Konfiguration des Programms.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Configuration

#Region " Members "
        Private Shared _CurrentConfiguration As Configuration = Nothing

        ''' <summary>
        ''' NIEMALS ÄNDERN, SONST GEHEN ALTE BILDER NICHT MEHR AUF!
        ''' </summary>
        Private Shared ReadOnly _InternPassword As String = "Sorry, not very secure, but better than nothing :<"
#End Region

#Region " Construction "
        Private Sub New()

        End Sub
#End Region

#Region " Methods "
        ''' <summary>
        ''' Gibt die Konfiguration als String zurück.
        ''' </summary>
        ''' <returns></returns>
        Public Function GetConfigurationString() As String
            Dim pis = GetType(Configuration).GetProperties()
            Dim config As New Text.StringBuilder()

            For Each pi In pis
                If (Not pi.GetCustomAttributes(True).Any(Function(Item)
                                                             Return TypeOf Item Is ComponentModel.DisplayNameAttribute
                                                         End Function) OrElse
                    pi.GetCustomAttributes(True).Any(Function(Item)
                                                         Return TypeOf Item Is ComponentModel.PasswordPropertyTextAttribute
                                                     End Function)) Then Continue For
                config.Append(pi.Name).
                    Append("=").
                    Append(pi.GetValue(Me, Nothing)).
                    AppendLine()
            Next

            Return config.ToString()
        End Function
#End Region

#Region " Properties "
        Public Shared ReadOnly Property CurrentConfiguration As Model.Configuration
            Get
                If (Configuration._CurrentConfiguration Is Nothing) Then
                    Configuration._CurrentConfiguration = New Configuration()
                End If

                Return Configuration._CurrentConfiguration
            End Get
        End Property

#Region " General "
        <ComponentModel.DisplayName("Directory Path")>
        <ComponentModel.Description("Sets the path of the directory in which the screenshots are saved.")>
        <ComponentModel.Category("General")>
        Public Property DirectoryPath As String
            Get
                Return My.Settings.DirectoryPath
            End Get
            Set(value As String)
                My.Settings.DirectoryPath = value
            End Set
        End Property

        <ComponentModel.DisplayName("Cycle in seconds")>
        <ComponentModel.Description("Sets the cycle in seconds in which the screenshots are taken.")>
        <ComponentModel.Category("General")>
        Public Property Cycle As Integer
            Get
                Return My.Settings.Cycle
            End Get
            Set(value As Integer)
                My.Settings.Cycle = value
            End Set
        End Property

        <ComponentModel.DisplayName("Auto start with windows")>
        <ComponentModel.Description("xScreen will start automatically with windows.")>
        <ComponentModel.Category("General")>
        Public Property AutoStart As Boolean
            Get
                Return My.Settings.StartWithWindows
            End Get
            Set(value As Boolean)
                My.Settings.StartWithWindows = value
            End Set
        End Property

        <ComponentModel.DisplayName("Hide main window")>
        <ComponentModel.Description("Hides the main window. You can show it via tray icon.")>
        <ComponentModel.Category("General")>
        Public Property HideMainWindow As Boolean
            Get
                Return My.Settings.HideMainWindow
            End Get
            Set(value As Boolean)
                My.Settings.HideMainWindow = value
            End Set
        End Property

        <ComponentModel.DisplayName("Background error handling")>
        <ComponentModel.Description("Handles errors in the background. No messageboxes are shown.")>
        <ComponentModel.Category("General")>
        Public Property BackgroundErrorHandling As Boolean
            Get
                Return My.Settings.BackgroundErrorHandling
            End Get
            Set(value As Boolean)
                My.Settings.BackgroundErrorHandling = value
            End Set
        End Property
#End Region

#Region " Image "
        <ComponentModel.DisplayName("Image format")>
        <ComponentModel.Description("Sets the image format.")>
        <ComponentModel.Category("Image")>
        Public Property ImageFormat() As System.Drawing.Imaging.ImageFormat
            Get
                Return My.Settings.ImageFormat
            End Get
            Set(value As System.Drawing.Imaging.ImageFormat)
                My.Settings.ImageFormat = value
            End Set
        End Property

        <ComponentModel.DisplayName("Image quality")>
        <ComponentModel.Description("Sets the quality in percent.")>
        <ComponentModel.Category("Image")>
        Public Property Quality() As Integer
            Get
                Return My.Settings.Quality
            End Get
            Set(value As Integer)
                My.Settings.Quality = value
            End Set
        End Property

        <ComponentModel.DisplayName("Write timestamp")>
        <ComponentModel.Description("Writes the current timestamp on the captured screenshot.")>
        <ComponentModel.Category("Image")>
        Public Property WriteTimeStamp() As Boolean
            Get
                Return My.Settings.WriteTimeStamp
            End Get
            Set(value As Boolean)
                My.Settings.WriteTimeStamp = value
            End Set
        End Property
#End Region

#Region " Similar images "
        <ComponentModel.DisplayName("Skip similar images")>
        <ComponentModel.Description("Skips similar images, if True.")>
        <ComponentModel.Category("Skip similar images")>
        Public Property SkipSimilarImages As Boolean
            Get
                Return My.Settings.SkipSimilarImages
            End Get
            Set(value As Boolean)
                My.Settings.SkipSimilarImages = value
            End Set
        End Property

        <ComponentModel.DisplayName("Image similarity")>
        <ComponentModel.Description("Sets the similarity in percent for the comparision of the two images.")>
        <ComponentModel.Category("Skip similar images")>
        Public Property SkipImageSimilarity As Double
            Get
                Return My.Settings.SkipImageSimilarity
            End Get
            Set(value As Double)
                My.Settings.SkipImageSimilarity = value
            End Set
        End Property
#End Region

#Region " ZIP "
        <ComponentModel.DisplayName("Save in ZIP")>
        <ComponentModel.Description("Saves the image in a ZIP file.")>
        <ComponentModel.Category("ZIP")>
        Public Property SaveAsZip As Boolean
            Get
                Return My.Settings.SaveAsZip
            End Get
            Set(value As Boolean)
                My.Settings.SaveAsZip = value
            End Set
        End Property

        <ComponentModel.DisplayName("Password")>
        <ComponentModel.Description("Sets a password for the ZIP file.")>
        <ComponentModel.Category("ZIP")>
        <ComponentModel.PasswordPropertyText(True)>
        Public Property ZipPassword As String
            Get
                If (String.IsNullOrEmpty(My.Settings.ZipPassword)) Then
                    Return String.Empty
                End If

                Dim decrypted As String = Util.DecryptString(My.Settings.ZipPassword, Configuration._InternPassword)

                Return decrypted
            End Get
            Set(value As String)
                If (String.IsNullOrEmpty(value)) Then
                    My.Settings.ZipPassword = String.Empty
                End If

                Dim encrypted As String = Util.EncryptString(value, Configuration._InternPassword)
                My.Settings.ZipPassword = encrypted
            End Set
        End Property

        <ComponentModel.DisplayName("Split ZIP in parts")>
        <ComponentModel.Description("Splits the ZIP files in parts.")>
        <ComponentModel.Category("ZIP")>
        Public Property SplitZipPackages As Boolean
            Get
                Return My.Settings.SplitZipPackages
            End Get
            Set(value As Boolean)
                My.Settings.SplitZipPackages = value
                If (My.Settings.NewZipPerDay) Then
                    My.Settings.NewZipPerDay = False
                End If
            End Set
        End Property

        <ComponentModel.DisplayName("Part size (MB)")>
        <ComponentModel.Description("Sets the size (mega byte) in which the ZIP file is split.")>
        <ComponentModel.Category("ZIP")>
        Public Property ZipPackageSize As Integer
            Get
                Return My.Settings.ZipPackageSize
            End Get
            Set(value As Integer)
                My.Settings.ZipPackageSize = value
            End Set
        End Property

        <ComponentModel.DisplayName("One ZIP per day")>
        <ComponentModel.Description("Creates a new ZIP file each day.")>
        <ComponentModel.Category("ZIP")>
        Public Property NewZipPerDay As Boolean
            Get
                Return My.Settings.NewZipPerDay
            End Get
            Set(value As Boolean)
                My.Settings.NewZipPerDay = value

                If (My.Settings.SplitZipPackages) Then
                    My.Settings.SplitZipPackages = False
                End If
            End Set
        End Property
#End Region

#End Region

    End Class

End Namespace

