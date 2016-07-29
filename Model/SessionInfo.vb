Option Explicit On
Option Strict On

Namespace xScreen.Model
    ''' <summary>
    ''' Gibt Infos zur aktuellen Windows-Sitzung an.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SessionInfo

#Region " Members "
        Private Shared _SessionLocked As Boolean = False
#End Region

#Region " Construction "
        ''' <summary>
        ''' Initialisiert eine neue Instanz der Klasse
        ''' xScreen.Model.SessionInfo
        ''' </summary>
        Private Sub New()

        End Sub

        Shared Sub New()
            AddHandler Microsoft.Win32.SystemEvents.SessionSwitch, AddressOf Session_Switched
            AddHandler AppDomain.CurrentDomain.ProcessExit, Sub(Sender As Object, e As System.EventArgs)
                                                                RemoveHandler Microsoft.Win32.SystemEvents.SessionSwitch, AddressOf Session_Switched
                                                            End Sub
        End Sub
#End Region

#Region " Methods "
        Private Shared Sub Session_Switched(sender As Object, e As Microsoft.Win32.SessionSwitchEventArgs)
            If (e.Reason = Microsoft.Win32.SessionSwitchReason.SessionLock OrElse e.Reason = Microsoft.Win32.SessionSwitchReason.SessionLogoff) Then
                SessionInfo._SessionLocked = True
                'IO.File.WriteAllText("c:\temp\screens\locked", " ")
            End If
            If (e.Reason = Microsoft.Win32.SessionSwitchReason.SessionUnlock OrElse e.Reason = Microsoft.Win32.SessionSwitchReason.SessionLogon) Then
                SessionInfo._SessionLocked = False
                'IO.File.WriteAllText("c:\temp\screens\unlocked", " ")
            End If
        End Sub
#End Region

#Region " Properties "
        ''' <summary>
        ''' Gibt an, ob die aktuelle Windows-Sitzung gesperrt ist.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property SessionLocked() As Boolean
            Get
                Return SessionInfo._SessionLocked
            End Get
        End Property
#End Region

    End Class

End Namespace

