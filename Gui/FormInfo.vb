Namespace xScreen.Gui
    Public Class FormInfo
        Private Sub FormInfo_Shown(sender As Object, e As EventArgs) Handles Me.Shown
            Dim info As New Text.StringBuilder()

            With info
                .AppendFormat($"xScreen {Application.ProductVersion} by Andreas Hoffmann")
                .AppendLine()
                .AppendLine("Icons by INCORS GmbH (www.incors.com)")
                .AppendLine("Ionic.Zip.dll: https://dotnetzip.codeplex.com/)")
                Me.TextBoxInfo.Text = .ToString()
            End With

        End Sub
    End Class
End Namespace