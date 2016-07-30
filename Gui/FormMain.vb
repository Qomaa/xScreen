Option Explicit On
Option Strict On
Imports System.ComponentModel

Namespace xScreen.Gui
    ''' <summary>
    ''' Hauptformular des Programms.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class FormMain

#Region " Members "
        Private _IsRunning As Boolean = False
        Private _LastScreenShot As Model.ScreenShot = Nothing
#End Region

#Region " Construction "
        Public Sub New()
            Me.InitializeComponent()
            AddHandler Application.ThreadException, AddressOf Me.CatchUnhandledException
        End Sub
#End Region

#Region " Implementation "
        Private Sub Initialize()
            Try
                Model.Util.WriteLogFileEntry("xScreen (" & Application.ProductVersion & ") started.", True)

                Me.Text = "xScreen (" & Application.ProductVersion & ")"

                Me.ContextMenuItemConfig.Text = Me.ButtonShowConfig.Text
                Me.ContextMenuItemRunStop.Text = Me.ButtonRunStop.Text
                Me.ContextMenuItemShowHide.Text = Me.ButtonHideToTray.Text
                Me.ContextMenuItemScreenNow.Text = Me.ButtonScreenNow.Text

                Me.ApplyConfiguration(True)

                If (Model.Configuration.Current.AutoStart) Then
                    Me.StartCycle()
                Else
                    Me.StopCycle()
                End If
            Catch ex As Exception
                Throw New Exception("Error while initializing main form.", ex)
            End Try
        End Sub

        Private Sub ApplyConfiguration(OnInitialization As Boolean)
            Try
                'My.Settings.Upgrade()
                Me.ShowOrHideMainWindow()
                If (Not OnInitialization) Then Me.SetAutoStart()
                Me.TimerCaptureScreen.Interval = Model.Configuration.Current.Cycle * 1000
                Me.StatusProgressBar.Maximum = 1
                Me.StatusProgressBar.Minimum = 0

                Model.Util.WriteLogFileEntry("Configuration applied:", True)
                Model.Util.WriteLogFileEntry(Model.Configuration.Current.GetConfigurationString(), False)
            Catch ex As Exception
                Throw New Exception("Error while applying cofiguration.", ex)
            End Try
        End Sub

        Private Sub SetAutoStart()
            Try
                Dim shortCutFile As String = "xScreen.lnk"
                Dim startupPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
                Dim shortCut As String = IO.Path.Combine(startupPath, shortCutFile)

                If (Model.Configuration.Current.AutoStart) Then
                    If (Not IO.File.Exists(shortCut)) Then
                        Dim wsh As New IWshRuntimeLibrary.IWshShell_Class()
                        Dim link As IWshRuntimeLibrary.IWshShortcut_Class = CType(wsh.CreateShortcut(shortCut), IWshRuntimeLibrary.IWshShortcut_Class)
                        link.TargetPath = Application.ExecutablePath
                        link.Description = "captures screenshots automatically"
                        link.Save()

                        MessageBox.Show(String.Format("Shortcut created: {1}{0}", vbNewLine, shortCut),
                                                             "xScreen", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    If (IO.File.Exists(shortCut)) Then
                        IO.File.Delete(shortCut)

                        MessageBox.Show(String.Format("Shortcut deleted: {1}{0}", vbNewLine, shortCut),
                                                             "xScreen", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                Throw New System.Exception("Error while creating autostart shortcut.", ex)
            End Try
        End Sub

        Private Sub ShowOrHideMainWindow()
            If (Model.Configuration.Current.HideMainWindow) Then
                Me.Visible = False
                Me.NotifyIcon.ShowBalloonTip(7000, "xScreen", "You can access xScreen via tray icon here.", ToolTipIcon.Info)
                Me.ContextMenuItemShowHide.Text = "show window"
            Else
                Me.Visible = True
                Me.ContextMenuItemShowHide.Text = Me.ButtonHideToTray.Text
            End If
        End Sub

        Private Sub ShowConfig()
            Dim config As FormConfig = Nothing
            Dim isRunning As Boolean

            isRunning = Me._IsRunning
            If (isRunning) Then Me.StopCycle()

            config = New FormConfig()
            config.ShowDialog(Me)
            Me.ApplyConfiguration(False)

            If (isRunning) Then Me.StartCycle()
        End Sub

        Private Sub ToggleCycle()
            If (Me._IsRunning) Then
                Me.StopCycle()
            Else
                Me.StartCycle()
            End If
        End Sub

        Private Sub StartCycle()
            Try
                Me.TimerCaptureScreen.Start()
                Me.TimerUpdateProgress.Start()
                Me.ButtonRunStop.Text = "stop capturing"
                Me.ButtonRunStop.Image = Global.My.Resources.media_stop_red
                Me.ContextMenuItemRunStop.Image = Global.My.Resources.media_stop_red
                Me.ContextMenuItemRunStop.Text = "stop capturing"
                Me.NotifyIcon.Text = "xScreen (running)"
                Me.NotifyIcon.Icon = Global.My.Resources.videocamera_run
                Me.StatusLabelIcon.Image = Global.My.Resources.videocamera_run1
                Me.CaptureScreenShot() 'ersten Screenshot sofort aufnehmen
                Me._IsRunning = True

                Model.Util.WriteLogFileEntry("Cycle started.", True)
            Catch ex As Exception
                Me.StopCycle()
                Throw New Exception("Error while starting cycle.", ex)
            End Try
        End Sub

        Private Sub StopCycle()
            Try
                Me.TimerCaptureScreen.Stop()
                Me.ButtonRunStop.Text = "start capturing"
                Me.ButtonRunStop.Image = My.Resources.media_play_green
                Me.ContextMenuItemRunStop.Image = My.Resources.media_play_green
                Me.ContextMenuItemRunStop.Text = "start capturing"
                Me.NotifyIcon.Text = "xScreen (stopped)"
                Me.NotifyIcon.Icon = Global.My.Resources.videocamera_stop
                Me.StatusLabelIcon.Image = Global.My.Resources.videocamera_stop1
                Me._IsRunning = False

                Model.Util.WriteLogFileEntry("Cycle stopped.", True)
            Catch ex As Exception
                Throw New Exception("Error while stopping cycle.", ex)
            End Try
        End Sub

        Private Sub CaptureScreenShot()
            Dim similarImage As Boolean

            Try
                If (String.IsNullOrEmpty(Model.Configuration.Current.DirectoryPath) OrElse
                    Not System.IO.Directory.Exists(Model.Configuration.Current.DirectoryPath)) Then
                    MessageBox.Show("First, choose a valid directory path where your screenshots should be saved.")
                    Me.ShowConfig()
                    Return
                End If

                Me.Cursor = Cursors.WaitCursor

                Dim screenshot As Model.ScreenShot

                screenshot = Model.ScreenShot.CaptureNew()

                If (screenshot Is Nothing) Then
                    Model.Util.WriteLogFileEntry($"Screenshot skipped (session locked?).", True)
                    Me._LastScreenShot = New Model.ScreenShot(Nothing, Date.Now) 'Leeren Screenshot erstellen.
                    Return
                End If

                If (Not screenshot.IsSimilarImage(Me._LastScreenShot)) Then
                    screenshot.SaveAsNewFile()
                    similarImage = False
                Else
                    similarImage = True
                End If

                Me._LastScreenShot?.Dispose()

                Me._LastScreenShot = screenshot
                Me.PictureBoxLastPicture.Image = Me._LastScreenShot.Image
                Me.LabelLastScreenShotTime.Text = Me._LastScreenShot.ImageDate.ToString("u")
                Me.LabelLastScreenFilename.Text = Me._LastScreenShot.Filename

                GC.Collect()

                If (similarImage) Then
                    Model.Util.WriteLogFileEntry($"Screenshot skipped (similar image).", True)
                Else
                    Model.Util.WriteLogFileEntry($"Screenshot captured: {screenshot.Filename}", True)
                End If
            Catch ex As Exception
                Me.StopCycle()
                Throw New Exception("Error while capturing screen shot.", ex)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub QuitProgramm()
            Me.Close()
            Me.NotifyIcon.Dispose()
        End Sub

        Private Sub UpdateGui()
            If (Not Me._IsRunning OrElse Me._LastScreenShot Is Nothing) Then
                Me.StatusLabelProgress.Text = String.Empty
                Me.StatusProgressBar.Value = 0
                Return
            End If

            Try
                Dim nextTake As Date
                Dim secondesLeft As Integer

                nextTake = Me._LastScreenShot.ImageDate.AddSeconds(Model.Configuration.Current.Cycle)
                secondesLeft = CInt(New TimeSpan(nextTake.Subtract(Date.Now).Ticks).TotalSeconds)

                If (secondesLeft < 0) Then Return

                Me.StatusLabelProgress.Text = CStr(secondesLeft)
                Me.StatusProgressBar.Maximum = Model.Configuration.Current.Cycle
                Me.StatusProgressBar.Value = secondesLeft
            Catch ex As Exception
                Throw New Exception("Error while updating GUI.", ex)
            End Try
        End Sub

        Private Sub OpenFile(Filename As String)
            Try
                Dim proc As New Process()

                proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                proc.StartInfo.CreateNoWindow = False
                proc.StartInfo.Verb = "Open"
                proc.StartInfo.FileName = Filename
                proc.Start()
            Catch ex As Exception
                Throw New Exception(String.Format("Error while opening file {0}.", Filename), ex)
            End Try
        End Sub

#Region " Event handlers "
        Private Sub ButtonShowHide_Click(sender As Object, e As EventArgs) Handles ButtonHideToTray.Click
            Model.Configuration.Current.HideMainWindow = Not Model.Configuration.Current.HideMainWindow
            Me.ShowOrHideMainWindow()
        End Sub

        Private Sub ContextMenuItemShowHide_Click(sender As Object, e As EventArgs) Handles ContextMenuItemShowHide.Click
            Model.Configuration.Current.HideMainWindow = Not Model.Configuration.Current.HideMainWindow
            Me.ShowOrHideMainWindow()
        End Sub

        Private Sub ButtonShowConfig_Click(sender As Object, e As EventArgs) Handles ButtonShowConfig.Click
            Me.ShowConfig()
        End Sub

        Private Sub ButtonRunStop_Click(sender As Object, e As EventArgs) Handles ButtonRunStop.Click
            Me.ToggleCycle()
        End Sub

        Private Sub ButtonScreenNow_Click(sender As Object, e As EventArgs) Handles ButtonScreenNow.Click
            Me.CaptureScreenShot()
        End Sub

        Private Sub ButtonInfo_Click(sender As Object, e As EventArgs) Handles ButtonInfo.Click
            Dim info As New FormInfo()
            info.Show(Me)
        End Sub

        Private Sub ButtonOpenLogFile_Click(sender As Object, e As EventArgs) Handles ButtonOpenLogFile.Click
            Me.OpenFile(Model.Util.LogFilePath)
        End Sub

        Private Sub TimerTakeScreen_Tick(sender As Object, e As EventArgs) Handles TimerCaptureScreen.Tick
            Me.CaptureScreenShot()
        End Sub

        Private Sub CatchUnhandledException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
            Me.Cursor = Cursors.Default

            Model.Util.HandleError("", e.Exception)
        End Sub

        Private Sub NotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
            Model.Configuration.Current.HideMainWindow = False
            Me.ShowOrHideMainWindow()

            Me.WindowState = FormWindowState.Normal
            Me.Activate()
        End Sub

        Private Sub ContextMenuItemConfig_Click(sender As Object, e As EventArgs) Handles ContextMenuItemConfig.Click
            Me.ShowConfig()
        End Sub

        Private Sub ContextMenuItemTakeNow_Click(sender As Object, e As EventArgs) Handles ContextMenuItemScreenNow.Click
            Me.CaptureScreenShot()
        End Sub

        Private Sub ContextMenuItemRunStop_Click(sender As Object, e As EventArgs) Handles ContextMenuItemRunStop.Click
            Me.ToggleCycle()
        End Sub

        Private Sub ContextMenuItemQuit_Click(sender As Object, e As EventArgs) Handles ContextMenuItemQuit.Click
            Me.QuitProgramm()
        End Sub

        Private Sub FormMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            Me.Initialize()
        End Sub

        Private Sub TimerUpdateProgress_Tick(sender As Object, e As EventArgs) Handles TimerUpdateProgress.Tick
            Me.UpdateGui()
        End Sub

        Private Sub ContextMenuStripLinkLabel_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStripLinkLabel.Opening
            Me.ContextMenuItemOpenFile.Enabled = Me._LastScreenShot IsNot Nothing
        End Sub

        Private Sub ToolStripMenuItemOpenFile_Click(sender As Object, e As EventArgs) Handles ContextMenuItemOpenFile.Click
            Me.OpenFile(Me._LastScreenShot.Filename)
        End Sub

        Private Sub ContextMenuItemOpenDir_Click(sender As Object, e As EventArgs) Handles ContextMenuItemOpenDir.Click
            Me.OpenFile(Model.Configuration.Current.DirectoryPath)
        End Sub

        Private Sub PictureBoxLastPicture_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBoxLastPicture.MouseClick
            If (e.Button = MouseButtons.Right) Then
                Me.ContextMenuStripLinkLabel.Show(System.Windows.Forms.Cursor.Position)
            End If

            If (e.Button = MouseButtons.Left) Then
                If (Me._LastScreenShot IsNot Nothing) Then
                    Me.OpenFile(Me._LastScreenShot.Filename)
                End If
            End If
        End Sub

        Private Sub FormMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
            Model.Util.WriteLogFileEntry("Program closed.", True)
            Model.Util.WriteLogFileEntry("------------------------------------------------------------------------------------", True)
        End Sub

        Private Sub PictureBoxLastPicture_MouseEnter(sender As Object, e As EventArgs) Handles PictureBoxLastPicture.MouseEnter
            Me.Cursor = Cursors.Hand
        End Sub

        Private Sub PictureBoxLastPicture_MouseLeave(sender As Object, e As EventArgs) Handles PictureBoxLastPicture.MouseLeave
            Me.Cursor = Cursors.Default
        End Sub

#End Region

#End Region

#Region " Properties "

#End Region

    End Class

End Namespace

