Namespace xScreen.Gui
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FormMain
        Inherits System.Windows.Forms.Form

        'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
            Me.TimerCaptureScreen = New System.Windows.Forms.Timer(Me.components)
            Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
            Me.ContextMenuStripNotifyIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.ContextMenuItemConfig = New System.Windows.Forms.ToolStripMenuItem()
            Me.ContextMenuItemScreenNow = New System.Windows.Forms.ToolStripMenuItem()
            Me.ContextMenuItemRunStop = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.ContextMenuItemShowHide = New System.Windows.Forms.ToolStripMenuItem()
            Me.ContextMenuItemQuit = New System.Windows.Forms.ToolStripMenuItem()
            Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ButtonHideToTray = New System.Windows.Forms.Button()
            Me.LabelLastScreenShotTime = New System.Windows.Forms.Label()
            Me.TimerUpdateProgress = New System.Windows.Forms.Timer(Me.components)
            Me.ButtonScreenNow = New System.Windows.Forms.Button()
            Me.ButtonShowConfig = New System.Windows.Forms.Button()
            Me.PictureBoxLastPicture = New System.Windows.Forms.PictureBox()
            Me.ButtonRunStop = New System.Windows.Forms.Button()
            Me.StatusStripMain = New System.Windows.Forms.StatusStrip()
            Me.StatusLabelIcon = New System.Windows.Forms.ToolStripStatusLabel()
            Me.StatusProgressBar = New System.Windows.Forms.ToolStripProgressBar()
            Me.StatusLabelProgress = New System.Windows.Forms.ToolStripStatusLabel()
            Me.ToolStripStatusLabelError = New System.Windows.Forms.ToolStripStatusLabel()
            Me.ContextMenuStripLinkLabel = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.ContextMenuItemOpenFile = New System.Windows.Forms.ToolStripMenuItem()
            Me.ContextMenuItemOpenDir = New System.Windows.Forms.ToolStripMenuItem()
            Me.ButtonInfo = New System.Windows.Forms.Button()
            Me.LabelLastScreenFilename = New System.Windows.Forms.Label()
            Me.ButtonOpenLogFile = New System.Windows.Forms.Button()
            Me.ContextMenuStripNotifyIcon.SuspendLayout()
            CType(Me.PictureBoxLastPicture, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.StatusStripMain.SuspendLayout()
            Me.ContextMenuStripLinkLabel.SuspendLayout()
            Me.SuspendLayout()
            '
            'TimerCaptureScreen
            '
            '
            'NotifyIcon
            '
            Me.NotifyIcon.ContextMenuStrip = Me.ContextMenuStripNotifyIcon
            Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
            Me.NotifyIcon.Text = "xScreen"
            Me.NotifyIcon.Visible = True
            '
            'ContextMenuStripNotifyIcon
            '
            Me.ContextMenuStripNotifyIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuItemConfig, Me.ContextMenuItemScreenNow, Me.ContextMenuItemRunStop, Me.ToolStripSeparator1, Me.ContextMenuItemShowHide, Me.ContextMenuItemQuit})
            Me.ContextMenuStripNotifyIcon.Name = "ContextMenuStripMain"
            Me.ContextMenuStripNotifyIcon.Size = New System.Drawing.Size(152, 120)
            '
            'ContextMenuItemConfig
            '
            Me.ContextMenuItemConfig.Image = Global.My.Resources.Resources.gear
            Me.ContextMenuItemConfig.Name = "ContextMenuItemConfig"
            Me.ContextMenuItemConfig.Size = New System.Drawing.Size(151, 22)
            Me.ContextMenuItemConfig.Text = "configurate..."
            '
            'ContextMenuItemScreenNow
            '
            Me.ContextMenuItemScreenNow.Image = Global.My.Resources.Resources.asterisk_orange
            Me.ContextMenuItemScreenNow.Name = "ContextMenuItemScreenNow"
            Me.ContextMenuItemScreenNow.Size = New System.Drawing.Size(151, 22)
            Me.ContextMenuItemScreenNow.Text = "capture now"
            '
            'ContextMenuItemRunStop
            '
            Me.ContextMenuItemRunStop.Image = Global.My.Resources.Resources.media_stop_red
            Me.ContextMenuItemRunStop.Name = "ContextMenuItemRunStop"
            Me.ContextMenuItemRunStop.Size = New System.Drawing.Size(151, 22)
            Me.ContextMenuItemRunStop.Text = "start capturing"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(148, 6)
            '
            'ContextMenuItemShowHide
            '
            Me.ContextMenuItemShowHide.Name = "ContextMenuItemShowHide"
            Me.ContextMenuItemShowHide.Size = New System.Drawing.Size(151, 22)
            Me.ContextMenuItemShowHide.Text = "hide window"
            '
            'ContextMenuItemQuit
            '
            Me.ContextMenuItemQuit.Name = "ContextMenuItemQuit"
            Me.ContextMenuItemQuit.Size = New System.Drawing.Size(151, 22)
            Me.ContextMenuItemQuit.Text = "quit"
            '
            'RunToolStripMenuItem
            '
            Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
            Me.RunToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.RunToolStripMenuItem.Text = "run"
            '
            'ButtonHideToTray
            '
            Me.ButtonHideToTray.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonHideToTray.Location = New System.Drawing.Point(707, 25)
            Me.ButtonHideToTray.Name = "ButtonHideToTray"
            Me.ButtonHideToTray.Size = New System.Drawing.Size(105, 30)
            Me.ButtonHideToTray.TabIndex = 0
            Me.ButtonHideToTray.Text = "hide to tray"
            Me.ButtonHideToTray.UseVisualStyleBackColor = True
            '
            'LabelLastScreenShotTime
            '
            Me.LabelLastScreenShotTime.AutoSize = True
            Me.LabelLastScreenShotTime.Location = New System.Drawing.Point(12, 9)
            Me.LabelLastScreenShotTime.Name = "LabelLastScreenShotTime"
            Me.LabelLastScreenShotTime.Size = New System.Drawing.Size(10, 13)
            Me.LabelLastScreenShotTime.TabIndex = 0
            Me.LabelLastScreenShotTime.Text = "-"
            '
            'TimerUpdateProgress
            '
            Me.TimerUpdateProgress.Interval = 250
            '
            'ButtonScreenNow
            '
            Me.ButtonScreenNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonScreenNow.Image = Global.My.Resources.Resources.asterisk_orange
            Me.ButtonScreenNow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.ButtonScreenNow.Location = New System.Drawing.Point(707, 97)
            Me.ButtonScreenNow.Name = "ButtonScreenNow"
            Me.ButtonScreenNow.Size = New System.Drawing.Size(105, 30)
            Me.ButtonScreenNow.TabIndex = 2
            Me.ButtonScreenNow.Text = "capture now"
            Me.ButtonScreenNow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.ButtonScreenNow.UseVisualStyleBackColor = True
            '
            'ButtonShowConfig
            '
            Me.ButtonShowConfig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonShowConfig.Image = Global.My.Resources.Resources.gear
            Me.ButtonShowConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.ButtonShowConfig.Location = New System.Drawing.Point(707, 61)
            Me.ButtonShowConfig.Name = "ButtonShowConfig"
            Me.ButtonShowConfig.Size = New System.Drawing.Size(105, 30)
            Me.ButtonShowConfig.TabIndex = 1
            Me.ButtonShowConfig.Text = "configurate..."
            Me.ButtonShowConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.ButtonShowConfig.UseVisualStyleBackColor = True
            '
            'PictureBoxLastPicture
            '
            Me.PictureBoxLastPicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PictureBoxLastPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.PictureBoxLastPicture.Location = New System.Drawing.Point(12, 25)
            Me.PictureBoxLastPicture.Name = "PictureBoxLastPicture"
            Me.PictureBoxLastPicture.Size = New System.Drawing.Size(689, 386)
            Me.PictureBoxLastPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.PictureBoxLastPicture.TabIndex = 2
            Me.PictureBoxLastPicture.TabStop = False
            '
            'ButtonRunStop
            '
            Me.ButtonRunStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonRunStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ButtonRunStop.Image = Global.My.Resources.Resources.media_play_green
            Me.ButtonRunStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.ButtonRunStop.Location = New System.Drawing.Point(707, 133)
            Me.ButtonRunStop.Name = "ButtonRunStop"
            Me.ButtonRunStop.Size = New System.Drawing.Size(105, 48)
            Me.ButtonRunStop.TabIndex = 3
            Me.ButtonRunStop.Text = "start capturing"
            Me.ButtonRunStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.ButtonRunStop.UseVisualStyleBackColor = True
            '
            'StatusStripMain
            '
            Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabelIcon, Me.StatusProgressBar, Me.StatusLabelProgress, Me.ToolStripStatusLabelError})
            Me.StatusStripMain.Location = New System.Drawing.Point(0, 414)
            Me.StatusStripMain.Name = "StatusStripMain"
            Me.StatusStripMain.Size = New System.Drawing.Size(824, 22)
            Me.StatusStripMain.TabIndex = 13
            '
            'StatusLabelIcon
            '
            Me.StatusLabelIcon.Image = Global.My.Resources.Resources.videocamera_stop1
            Me.StatusLabelIcon.Name = "StatusLabelIcon"
            Me.StatusLabelIcon.Size = New System.Drawing.Size(16, 17)
            '
            'StatusProgressBar
            '
            Me.StatusProgressBar.Name = "StatusProgressBar"
            Me.StatusProgressBar.Size = New System.Drawing.Size(100, 16)
            '
            'StatusLabelProgress
            '
            Me.StatusLabelProgress.Name = "StatusLabelProgress"
            Me.StatusLabelProgress.Size = New System.Drawing.Size(12, 17)
            Me.StatusLabelProgress.Text = "-"
            '
            'ToolStripStatusLabelError
            '
            Me.ToolStripStatusLabelError.Name = "ToolStripStatusLabelError"
            Me.ToolStripStatusLabelError.Size = New System.Drawing.Size(0, 17)
            '
            'ContextMenuStripLinkLabel
            '
            Me.ContextMenuStripLinkLabel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuItemOpenFile, Me.ContextMenuItemOpenDir})
            Me.ContextMenuStripLinkLabel.Name = "ContextMenuStripLinkLabel"
            Me.ContextMenuStripLinkLabel.Size = New System.Drawing.Size(152, 48)
            '
            'ContextMenuItemOpenFile
            '
            Me.ContextMenuItemOpenFile.Name = "ContextMenuItemOpenFile"
            Me.ContextMenuItemOpenFile.Size = New System.Drawing.Size(151, 22)
            Me.ContextMenuItemOpenFile.Text = "open file"
            '
            'ContextMenuItemOpenDir
            '
            Me.ContextMenuItemOpenDir.Image = Global.My.Resources.Resources.folder2
            Me.ContextMenuItemOpenDir.Name = "ContextMenuItemOpenDir"
            Me.ContextMenuItemOpenDir.Size = New System.Drawing.Size(151, 22)
            Me.ContextMenuItemOpenDir.Text = "open directory"
            '
            'ButtonInfo
            '
            Me.ButtonInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonInfo.Image = Global.My.Resources.Resources.information
            Me.ButtonInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.ButtonInfo.Location = New System.Drawing.Point(707, 381)
            Me.ButtonInfo.Name = "ButtonInfo"
            Me.ButtonInfo.Size = New System.Drawing.Size(105, 30)
            Me.ButtonInfo.TabIndex = 5
            Me.ButtonInfo.Text = "info"
            Me.ButtonInfo.UseVisualStyleBackColor = True
            '
            'LabelLastScreenFilename
            '
            Me.LabelLastScreenFilename.AutoSize = True
            Me.LabelLastScreenFilename.Location = New System.Drawing.Point(164, 9)
            Me.LabelLastScreenFilename.Name = "LabelLastScreenFilename"
            Me.LabelLastScreenFilename.Size = New System.Drawing.Size(10, 13)
            Me.LabelLastScreenFilename.TabIndex = 1
            Me.LabelLastScreenFilename.Text = "-"
            '
            'ButtonOpenLogFile
            '
            Me.ButtonOpenLogFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonOpenLogFile.Image = Global.My.Resources.Resources.page_white_text
            Me.ButtonOpenLogFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.ButtonOpenLogFile.Location = New System.Drawing.Point(707, 345)
            Me.ButtonOpenLogFile.Name = "ButtonOpenLogFile"
            Me.ButtonOpenLogFile.Size = New System.Drawing.Size(105, 30)
            Me.ButtonOpenLogFile.TabIndex = 4
            Me.ButtonOpenLogFile.Text = "open logfile"
            Me.ButtonOpenLogFile.UseVisualStyleBackColor = True
            '
            'FormMain
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(824, 436)
            Me.Controls.Add(Me.ButtonOpenLogFile)
            Me.Controls.Add(Me.ButtonRunStop)
            Me.Controls.Add(Me.LabelLastScreenFilename)
            Me.Controls.Add(Me.ButtonInfo)
            Me.Controls.Add(Me.StatusStripMain)
            Me.Controls.Add(Me.LabelLastScreenShotTime)
            Me.Controls.Add(Me.ButtonHideToTray)
            Me.Controls.Add(Me.ButtonScreenNow)
            Me.Controls.Add(Me.ButtonShowConfig)
            Me.Controls.Add(Me.PictureBoxLastPicture)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "FormMain"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "xScreen"
            Me.ContextMenuStripNotifyIcon.ResumeLayout(False)
            CType(Me.PictureBoxLastPicture, System.ComponentModel.ISupportInitialize).EndInit()
            Me.StatusStripMain.ResumeLayout(False)
            Me.StatusStripMain.PerformLayout()
            Me.ContextMenuStripLinkLabel.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ButtonRunStop As System.Windows.Forms.Button
        Friend WithEvents PictureBoxLastPicture As System.Windows.Forms.PictureBox
        Friend WithEvents TimerCaptureScreen As System.Windows.Forms.Timer
        Friend WithEvents ButtonShowConfig As System.Windows.Forms.Button
        Friend WithEvents ButtonScreenNow As System.Windows.Forms.Button
        Friend WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
        Friend WithEvents ContextMenuStripNotifyIcon As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents ContextMenuItemConfig As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ContextMenuItemScreenNow As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ContextMenuItemQuit As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents RunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ContextMenuItemRunStop As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ContextMenuItemShowHide As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ButtonHideToTray As System.Windows.Forms.Button
        Friend WithEvents LabelLastScreenShotTime As System.Windows.Forms.Label
        Friend WithEvents TimerUpdateProgress As System.Windows.Forms.Timer
        Friend WithEvents StatusStripMain As System.Windows.Forms.StatusStrip
        Friend WithEvents StatusProgressBar As System.Windows.Forms.ToolStripProgressBar
        Friend WithEvents StatusLabelProgress As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents StatusLabelIcon As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents ContextMenuStripLinkLabel As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents ContextMenuItemOpenDir As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ButtonInfo As System.Windows.Forms.Button
        Friend WithEvents ToolStripStatusLabelError As ToolStripStatusLabel
        Friend WithEvents LabelLastScreenFilename As Label
        Friend WithEvents ContextMenuItemOpenFile As ToolStripMenuItem
        Friend WithEvents ButtonOpenLogFile As Button
    End Class

End Namespace
