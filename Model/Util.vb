Option Explicit On
Option Strict On

Imports System.IO
Imports System.Security.Cryptography

Namespace xScreen.Model
    Public Class Util
        Private Shared _SyncLock As New Object()

#Region " Construction "
        Private Sub New()

        End Sub
#End Region

#Region " Encryption "
        ''' <summary>
        ''' Encrypts the string.
        ''' </summary>
        ''' <param name="clearText">The clear text.</param>
        ''' <param name="Password">The password.</param>
        ''' <returns></returns>
        Public Shared Function EncryptString(clearText As String, Password As String) As String
            Dim clearBytes As Byte() = System.Text.Encoding.Unicode.GetBytes(clearText)
            Dim pdb As New Rfc2898DeriveBytes(Password, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            Dim encryptedData As Byte() = EncryptString(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16))
            Return Convert.ToBase64String(encryptedData)
        End Function

        ''' <summary>
        ''' Decrypts the string.
        ''' </summary>
        ''' <param name="cipherText">The cipher text.</param>
        ''' <param name="Password">The password.</param>
        ''' <returns></returns>
        Public Shared Function DecryptString(cipherText As String, Password As String) As String
            Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
            Dim pdb As New Rfc2898DeriveBytes(Password, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            Dim decryptedData As Byte() = DecryptString(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16))
            Return System.Text.Encoding.Unicode.GetString(decryptedData)
        End Function

        ''' <summary>
        ''' Encrypts the string.
        ''' </summary>
        ''' <param name="clearText">The clear text.</param>
        ''' <param name="Key">The key.</param>
        ''' <param name="IV">The IV.</param>
        ''' <returns></returns>
        Private Shared Function EncryptString(clearText As Byte(), Key As Byte(), IV As Byte()) As Byte()
            Dim ms As New MemoryStream()
            Dim alg As Rijndael = Rijndael.Create()
            alg.Key = Key
            alg.IV = IV
            Dim cs As New CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write)
            cs.Write(clearText, 0, clearText.Length)
            cs.Close()
            Dim encryptedData As Byte() = ms.ToArray()
            Return encryptedData
        End Function

        ''' <summary>
        ''' Decrypts the string.
        ''' </summary>
        ''' <param name="cipherData">The cipher data.</param>
        ''' <param name="Key">The key.</param>
        ''' <param name="IV">The IV.</param>
        ''' <returns></returns>
        Private Shared Function DecryptString(cipherData As Byte(), Key As Byte(), IV As Byte()) As Byte()
            Dim ms As New MemoryStream()
            Dim alg As Rijndael = Rijndael.Create()
            alg.Key = Key
            alg.IV = IV
            Dim cs As New CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write)
            cs.Write(cipherData, 0, cipherData.Length)
            cs.Close()
            Dim decryptedData As Byte() = ms.ToArray()
            Return decryptedData
        End Function
#End Region

#Region " Error handling "
        Public Shared Sub HandleError(Message As String, Ex As Exception)
            Dim messageBuilder As New Text.StringBuilder()
            Dim errorFile As String = IO.Path.GetTempFileName()

            messageBuilder.AppendLine("*** AN ERROR OCCURRED ***")
            messageBuilder.AppendLine(Date.Now.ToString())
            messageBuilder.AppendLine()
            messageBuilder.AppendLine(Message)
            messageBuilder.AppendLine()

            File.WriteAllText(errorFile, vbNewLine & Ex.StackTrace)

            While Ex IsNot Nothing
                messageBuilder.AppendLine(Ex.Message)
                Ex = Ex.InnerException
            End While

            File.WriteAllText(errorFile, messageBuilder.ToString())

            messageBuilder.AppendLine()
            messageBuilder.AppendLine()
            messageBuilder.AppendFormat("This error message was saved in '{0}'.", errorFile)

            Util.WriteLogFileEntry(messageBuilder.ToString(), True)

            If (Not Configuration.Current.BackgroundErrorHandling) Then
                MessageBox.Show(
                    messageBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        End Sub
#End Region

#Region " Logfile "
        Public Shared Sub WriteLogFileEntry(Message As String, WithTimeStamp As Boolean)
            Try
                SyncLock Util._SyncLock
                    If (WithTimeStamp) Then
                        Message = vbNewLine & Date.Now.ToString("dd.MM.yyyy HH:mm:ss") & ": " & Message
                    Else
                        Message = vbNewLine & Message
                    End If

                    File.AppendAllText(Util.LogFilePath, Message)
                End SyncLock
            Catch ex As Exception
                'Fehler werden vorerst ignoriert.
                'Throw New Exception($"Error while writing in logfile: {logFilePath}.", ex)
            End Try
        End Sub

        Public Shared ReadOnly Property LogFilePath() As String
            Get
                Return Path.Combine(Application.StartupPath, String.Concat("Log_", Date.Now.ToString("yyyy-MM"), ".txt"))
            End Get
        End Property
#End Region
    End Class

End Namespace
