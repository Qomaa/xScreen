Namespace xScreen.Gui
    Public Class FormInfo
        Private Sub FormInfo_Shown(sender As Object, e As EventArgs) Handles Me.Shown
            Dim info As New Text.StringBuilder()

            info.AppendFormat($"xScreen {Application.ProductVersion} by Andreas Hoffmann (xscreen.codeplex.com)")
            info.AppendLine()
            info.AppendLine("Icons by INCORS GmbH (www.incors.com)")
            info.AppendLine("Ionic.Zip.dll: (dotnetzip.codeplex.com)")

            Me.TextBoxInfo.Text = info.ToString()
        End Sub
    End Class
End Namespace