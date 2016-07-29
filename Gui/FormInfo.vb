Namespace xScreen.Gui
    Public Class FormInfo
        Private Sub FormInfo_Shown(sender As Object, e As EventArgs) Handles Me.Shown
            Dim info As New Text.StringBuilder()

            With info
                .AppendFormat($"xScreen {Application.ProductVersion}")
                .AppendLine()
                .AppendLine("Icons by INCORS GmbH (www.incors.com)")
                .AppendLine()
                .AppendLine()
                .AppendLine("1.5 - 2016-07-22")
                .AppendLine("- detailed logging")
                .AppendLine("- info form")
                .AppendLine("- open last screenshot via mouse click")
                .AppendLine("- Button: open logfile")
                .AppendLine()
                .AppendLine("1.4 - 2016-07-21")
                .AppendLine("- timestamp now in Universal Sortable Format")
                .AppendLine("- configuration is logged")
                .AppendLine()
                .AppendLine("1.3 - 2016-07-06")
                .AppendLine("- New feature: Write timestamp on screenshot")
                .AppendLine("- icon remove from context menu quit")
                .AppendLine()
                .AppendLine("1.2 - 2016-07-05")
                .AppendLine("- New feature: Silent mode (no error message boxes)")
                .AppendLine("- Global logging")
                .AppendLine()
                .AppendLine("1.1 - 2016-02-18")
                .AppendLine("- Check for similar images is faster")
                .AppendLine("- Last taken screen is disposed => the application requires less RAM")
                .AppendLine()
                .AppendLine("1.0 - 2016-02-17")
                .AppendLine("- first version with version history")
                .AppendLine("- New feature: New ZIP file per day")

                '- wenn config geschlossen wird, wird u.U. das autoamtische screenshotten nicht gestartet (besonders blöd, wenn hide to tray =true)
                '- ereignislog --> Problem, da "Source" nicht da. Muss mit admin installiert werden
                '- git

                Me.TextBoxInfo.Text = .ToString()
            End With

        End Sub
    End Class
End Namespace