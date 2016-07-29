Option Explicit On
Option Strict On
Imports System.ComponentModel

Imports System.Drawing.Imaging

Namespace xScreen.Model
    ''' <summary>
    ''' Stellt einen Screenshot dar.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ScreenShot
        Implements IDisposable

#Region " Members "

#End Region

#Region " Construction "

        Public Sub New(Image As Bitmap, ImageDate As Date)
            Me.Image = Image
            Me.ImageDate = ImageDate
        End Sub
#End Region

#Region " Implementation "
        ''' <summary>
        ''' Nimmt den Bildschirm auf und gibt einen Verweis auf den Screenshot zurück.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function CaptureNew() As ScreenShot
            Dim bitmap As Bitmap = Nothing
            Dim imageDate As Date = Date.Now

            Try
                If (SessionInfo.SessionLocked) Then Return Nothing

                bitmap = New Bitmap(SystemInformation.VirtualScreen.Width,
                                    SystemInformation.VirtualScreen.Height,
                                    PixelFormat.Format32bppArgb)

                Using gfx As Graphics = Graphics.FromImage(bitmap)
                    Try
                        gfx.CopyFromScreen(SystemInformation.VirtualScreen.X,
                                   SystemInformation.VirtualScreen.Y,
                                   0,
                                   0,
                                   SystemInformation.VirtualScreen.Size,
                                   CopyPixelOperation.SourceCopy)
                    Catch ex As Win32Exception
                        'Z.B. wenn der aktuelle Desktop nicht sichtbar ist (anderer Benutzer ist angemeldet).
                        Return Nothing
                    Catch ex As Exception
                        Throw ex
                    End Try
                End Using

                Return New ScreenShot(bitmap, imageDate)
            Catch ex As Exception
                Throw New Exception("Error while capturing new screenshot.", ex)
            End Try
        End Function

        Public Function IsSimilarImage(ScreenShotToCompare As ScreenShot) As Boolean

            If (Not Configuration.CurrentConfiguration.SkipSimilarImages) Then Return False
            If (ScreenShotToCompare Is Nothing) Then Return False
            If (ScreenShotToCompare.Image Is Nothing) Then Return False
            If (Me.Image.Width <> ScreenShotToCompare.Image.Width) Then Return False
            If (Me.Image.Height <> ScreenShotToCompare.Image.Height) Then Return False

            Dim currentImagePixels = Me.Image.Width * Me.Image.Height
            Dim equalPixels As Integer = 0
            Dim bytesPerPixel As Integer = CInt(Drawing.Image.GetPixelFormatSize(Me.Image.PixelFormat) / 8)
            Dim currentImageBytes As Integer = currentImagePixels * bytesPerPixel
            Dim p1Bytes(currentImageBytes) As Byte
            Dim p2Bytes(currentImageBytes) As Byte
            Dim p1BitmapData As BitmapData
            Dim p2BitmapData As BitmapData

            Try
                p1BitmapData = Me.Image.LockBits(
                                                New Rectangle(0, 0, Me.Image.Width - 1, Me.Image.Height - 1),
                                                ImageLockMode.ReadOnly, Me.Image.PixelFormat)

                p2BitmapData = ScreenShotToCompare.Image.LockBits(
                                                New Rectangle(0, 0, ScreenShotToCompare.Image.Width - 1, ScreenShotToCompare.Image.Height - 1),
                                                ImageLockMode.ReadOnly, ScreenShotToCompare.Image.PixelFormat)

                Runtime.InteropServices.Marshal.Copy(p1BitmapData.Scan0, p1Bytes, 0, currentImageBytes)
                Runtime.InteropServices.Marshal.Copy(p2BitmapData.Scan0, p2Bytes, 0, currentImageBytes)

                Dim pixEqual As Boolean = True

                For i As Integer = 0 To currentImageBytes - 1 Step bytesPerPixel
                    For j As Integer = i To i + bytesPerPixel - 1
                        If (p1Bytes(j) <> p2Bytes(j)) Then
                            pixEqual = False
                        End If
                    Next

                    If (pixEqual) Then
                        equalPixels += 1
                    End If

                    pixEqual = True
                Next

                Me.Image.UnlockBits(p1BitmapData)
                ScreenShotToCompare.Image.UnlockBits(p2BitmapData)

                Dim similarity As Double = equalPixels / (currentImagePixels / 100)

                Return (similarity >= Configuration.CurrentConfiguration.SkipImageSimilarity)
            Catch ex As Exception
                Throw New Exception("Error while comparing images.", ex)
            Finally

            End Try
        End Function

        ''' <summary>
        ''' Speichert den Screenshot ins konfigurierte Verzeichnis.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SaveAsNewFile()
            Dim format As ImageFormat
            Dim fileExtension As String
            Dim codecInfo As ImageCodecInfo
            Dim encoder As Encoder
            Dim encoderParam As EncoderParameter
            Dim encoderParams As EncoderParameters

            Try
                format = Configuration.CurrentConfiguration.ImageFormat

                If (Configuration.CurrentConfiguration.WriteTimeStamp) Then
                    Me.AddTimeStamp()
                End If

                codecInfo = Me.GetEncoderInfo(format)
                encoder = Encoder.Quality
                encoderParams = New EncoderParameters(1)
                encoderParam = New EncoderParameter(encoder, Configuration.CurrentConfiguration.Quality)
                encoderParams.Param(0) = encoderParam

                If (codecInfo IsNot Nothing) Then
                    If (codecInfo.FilenameExtension.Contains(";")) Then
                        fileExtension = codecInfo.FilenameExtension.Split(";"c)(0)
                    Else
                        fileExtension = codecInfo.FilenameExtension
                    End If
                    fileExtension = fileExtension.Replace("*", "")
                    fileExtension = fileExtension.Replace(".", "")

                    Me.Filename = IO.Path.Combine(Configuration.CurrentConfiguration.DirectoryPath,
                                                     String.Format("screen-{0}.{1}", Me.ImageDate.ToString("yyyyMMdd-HHmmss"), fileExtension))

                    Me.Image.Save(Me.Filename, codecInfo, encoderParams)
                Else
                    Me.Filename = IO.Path.Combine(Configuration.CurrentConfiguration.DirectoryPath,
                                                     String.Format("screen-{0}.{1}", Me.ImageDate.ToString("yyyyMMdd-HHmmss"), format.ToString()))
                    Me.Image.Save(Me.Filename, format)
                End If

                If (Configuration.CurrentConfiguration.SaveAsZip) Then
                    Me.SaveAsZip()
                End If
            Catch ex As Exception
                Throw New Exception(String.Format("Error saving in path: {0}", Me.Filename), ex)
            End Try
        End Sub

        Public Sub AddTimeStamp()
            Using gfx As Graphics = Graphics.FromImage(Me.Image)
                Dim y As Single = SystemInformation.VirtualScreen.Height - 40
                Dim x As Single = 10.0F
                Dim now As Date = Date.Now
                gfx.DrawString(now.ToString("u"), New Font("Courier New", 16.0F, FontStyle.Bold), Brushes.Black, New PointF(x - 1, y - 1))
                gfx.DrawString(now.ToString("u"), New Font("Courier New", 16.0F, FontStyle.Bold), Brushes.Black, New PointF(x + 1, y + 1))
                gfx.DrawString(now.ToString("u"), New Font("Courier New", 16.0F, FontStyle.Bold), Brushes.White, New PointF(x, y))
            End Using
        End Sub

        ''' <summary>
        ''' Speichert den Screenshot in einer (passwortgeschützen) ZIP-Datei ins konfigurierte Verzeichnis.
        ''' </summary>
        Private Sub SaveAsZip()
            Dim zipFile As Ionic.Zip.ZipFile
            Dim zipPath As String = String.Empty
            Dim dictionary As String = Configuration.CurrentConfiguration.DirectoryPath
            Dim fileNumber As Integer = 1
            Dim filename As String

            Try
                If (Configuration.CurrentConfiguration.SplitZipPackages) Then
                    filename = "screens{0:000000}.zip"

                    Dim files = IO.Directory.GetFiles(dictionary, String.Format(filename, "*"))

                    If (files.Length > 0) Then
                        Array.Sort(files)
                        Dim file = New IO.FileInfo(files.Last())

                        fileNumber = CInt(file.Name.Substring("screens".Length, file.Name.LastIndexOf(".") - "screens".Length))

                        If (file.Length / 1024 / 1024 > Configuration.CurrentConfiguration.ZipPackageSize) Then
                            fileNumber += 1
                        End If
                    End If
                    zipPath = IO.Path.Combine(dictionary, String.Format(filename, fileNumber))
                ElseIf (Configuration.CurrentConfiguration.NewZipPerDay) Then
                    filename = "screens{0:yyyyMMdd}.zip"
                    zipPath = IO.Path.Combine(dictionary, String.Format(filename, Date.Now))
                Else
                    filename = "screens.zip"
                    zipPath = IO.Path.Combine(dictionary, filename)
                End If

                zipFile = New Ionic.Zip.ZipFile(zipPath)
                zipFile.Encryption = Ionic.Zip.EncryptionAlgorithm.WinZipAes256
                zipFile.Password = Configuration.CurrentConfiguration.ZipPassword
                zipFile.AddFile(Me.Filename, String.Empty)
                zipFile.Save()

                IO.File.Delete(Me.Filename)

                Me.Filename = zipPath
            Catch ex As Exception
                Throw New System.Exception(String.Format("Error saving in path as ZIP: {0}", zipPath), ex)
            End Try
        End Sub

        Private Function GetEncoderInfo(ByVal Format As ImageFormat) As ImageCodecInfo
            Dim j As Integer
            Dim encoders() As ImageCodecInfo
            encoders = ImageCodecInfo.GetImageEncoders()

            j = 0
            While j < encoders.Length
                If (encoders(j).FormatID = Format.Guid) Then
                    Return encoders(j)
                End If
                j += 1
            End While

            Return Nothing
        End Function
#End Region

#Region " Properties "
        Public Image As Bitmap = Nothing

        Public ImageDate As Date = Date.MinValue

        Public Filename As String = String.Empty
#End Region

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Dient zur Erkennung redundanter Aufrufe.

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    If (Me.Image IsNot Nothing) Then
                        Me.Image.Dispose()
                    End If
                End If
                Me.Image = Nothing
            End If
            Me.disposedValue = True
        End Sub

        ' Dieser Code wird von Visual Basic hinzugefügt, um das Dispose-Muster richtig zu implementieren.
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub
#End Region

    End Class

End Namespace

