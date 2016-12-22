#Region "Imports"
Imports System.Net
Imports System.IO
Imports System.Xml.Linq
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Globalization
Imports Ionic.Zip
Imports System.Net.Sockets
Imports MahApps.Metro
Imports System.Reflection
Imports System.Windows.Threading
Imports System.Text.RegularExpressions
Imports MahApps.Metro.Accent
Imports MahApps.Metro.Controls
Imports MahApps.Metro.Controls.Dialogs
Imports Microsoft.Win32
Imports Ookii.Dialogs.Wpf
Imports System.Xml
Imports fNbt
Imports System.Threading
Imports System.Security.Cryptography
Imports Craft.Net
Imports System.Threading.Tasks
Imports System.ComponentModel
Imports System.Windows.Media
Imports System
Imports System.Windows.Markup
Imports McMetroLauncher.Models
Imports System.Runtime.ExceptionServices
Imports System.Text
Imports System.Resources
Imports McMetroLauncher.JBou.Authentication
Imports McMetroLauncher.JBou.Authentication.Session
Imports System.Collections.ObjectModel
Imports System.Runtime.CompilerServices
Imports McMetroLauncher.Forge

#End Region

Public Class MainWindow
#Region "Variables"
    '****************Webclients*****************
    WithEvents wcmod As New System.Net.WebClient
    '*************Minecraft Prozess*************
    WithEvents mc As New Process
    '**************Mods Download****************
    Private modsdownloadingversion As String
    Private moddownloading As Boolean = False
    Private modsdownloadlist As IList(Of Modifications.Mod) = New List(Of Modifications.Mod)
    Private modsdownloadindex As Integer
    Private Modsfilename As String
    Private modslist As IList(Of Modifications.Mod)
    Private modsfolderPath As String
    '********************UI*********************
    Public controller As ProgressDialogController
    Public toolscontroller As ProgressDialogController
    '******************Others*******************
#End Region

#Region "Mainwindow Events"
    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        AddHandler ThemeManager.IsThemeChanged, AddressOf IsThemeChanged
        Me.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Theme
    End Sub

    Private Sub MainWindow_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try
            For i = 0 To startedversions.Count - 1
                If IO.Directory.Exists(startedversions.Item(i).ToString) = True Then
                    IO.Directory.Delete(startedversions.Item(i).ToString, True)
                End If
            Next
            If cachefolder.Exists = True Then
                cachefolder.Delete(True)
            End If
        Catch ex As Exception
        End Try
        Environment.Exit(Environment.ExitCode)
    End Sub

    Private Async Sub MainWindow_Loaded(sender As Object, e As EventArgs) Handles Me.Loaded
        'Set the Webbrowser Source:
        Webcontrol_news.WebSession = WebCore.CreateWebSession(New WebPreferences() With {.CustomCSS = Scrollbarcss})
        'wc_mod_video.WebSession = WebCore.CreateWebSession(New WebPreferences() With {.CustomCSS = Scrollbarcss})
        While Webcontrol_news.IsLoading = True
            Await Task.Delay(10)
        End While
        Webcontrol_news.Visibility = Windows.Visibility.Visible
        lbl_news_loading.Visibility = Windows.Visibility.Collapsed
        pb_news_loading.Visibility = Windows.Visibility.Collapsed
    End Sub
#End Region

    Sub IsThemeChanged(sender As Object, e As OnThemeChangedEventArgs)
        MainViewModel.Instance.Settings.Theme = e.AppTheme.Name
        MainViewModel.Instance.Settings.Accent = e.Accent.Name
        MainViewModel.Instance.Settings.Save()
    End Sub

    Private Sub ShowSettings(sender As Object, e As RoutedEventArgs)
        'Contrrols auf ihre Einstellungen setzen
        ToggleFlyout(0)
    End Sub

    Public Sub Open_Website()
        Process.Start(GlobalInfos.Website)
    End Sub

    Public Sub Open_Github()
        Process.Start(GlobalInfos.Github)
    End Sub

    Private Sub ToggleFlyout(index As Integer)
        Dim flyout As Flyout = CType(Me.Flyouts.Items(index), Controls.Flyout)
        If flyout Is Nothing Then
            Return
        End If

        If flyout.IsOpen = True Then
            flyout.IsOpen = False
        Else
            flyout.IsOpen = True
        End If
    End Sub

    Private Sub Help()
        'Zeige Hilfe
    End Sub

    ''' <summary>
    ''' Registriert ein benutzerdefiniertes URL-Protokoll für die Verwendung mit der
    ''' Windows-Shell, dem Internet Explorer und Office.
    ''' 
    ''' Beispiel für einen URL eines benutzerdefinierten URL-Protokolls:
    ''' 
    '''   rainbird://RemoteControl/OpenFridge/GetBeer
    ''' </summary>
    ''' <param name="protocolName">Name des Protokolls (z.B. "rainbird" für "rainbird://...")</param>
    ''' <param name="applicationPath">Vollständiger Dateisystem-Pfad zur EXE-Datei, die den URL bei Aufruf verarbeitet (Der komplette URL wird als Befehlszeilenparameter übergteben)</param>
    ''' <param name="description">Beschreibung (z.B. "URL:Rainbird Custom URL")</param>
    ''' +
    ''' 
    Public Sub RegisterURLProtocol(protocolName As String, applicationPath As String, description As String)
        ' Neuer Schlüssel für das gewünschte URL Protokoll erstellen
        Dim myKey As RegistryKey = Registry.ClassesRoot.CreateSubKey(protocolName)

        ' Protokoll zuweisen
        myKey.SetValue(Nothing, description)
        myKey.SetValue("URL Protocol", String.Empty)

        ' Shellwerte eintragen
        Registry.ClassesRoot.CreateSubKey(protocolName & "\Shell")
        Registry.ClassesRoot.CreateSubKey(protocolName & "\Shell\open")
        myKey = Registry.ClassesRoot.CreateSubKey(protocolName & "\Shell\open\command")

        ' Anwendung festlegen, die das URL-Protokoll behandelt
        myKey.SetValue(Nothing, Chr(34) & applicationPath & Chr(34) & " %1")
    End Sub

    Async Function Unzip() As Task
        Await Task.Run(New Action(Sub()
                                      Try
                                          Write(Application.Current.FindResource("UnpackingNatives").ToString)
                                          UnpackDirectory = Path.Combine(versionsfolder.FullName, Startinfos.Version.id, Startinfos.Version.id & "-natives-" & DateTime.Now.Ticks.ToString)
                                          If startedversions.Contains(UnpackDirectory) = False Then
                                              startedversions.Add(UnpackDirectory)
                                          End If
                                          For Each item In Startinfos.Versionsinfo.libraries.Where(Function(p) p.natives IsNot Nothing) 'TODO Resolve VersionsInfo
                                              With item
                                                  'Rules überprüfen
                                                  Dim allowdownload As Boolean = True
                                                  If .rules Is Nothing Then
                                                      allowdownload = True
                                                  Else
                                                      If .rules.Select(Function(p) p.action).Contains("allow") Then
                                                          If .rules.Where(Function(p) p.action = "allow").First.os IsNot Nothing Then
                                                              If .rules.Where(Function(p) p.action = "allow").First.os.name = "windows" Then
                                                                  allowdownload = True
                                                              Else
                                                                  allowdownload = False
                                                              End If
                                                          End If
                                                      ElseIf .rules.Select(Function(p) p.action).Contains("disallow") Then
                                                          If .rules.Where(Function(p) p.action = "disallow").First.os IsNot Nothing Then
                                                              If .rules.Where(Function(p) p.action = "disallow").First.os.name = "windows" Then
                                                                  allowdownload = False
                                                              Else
                                                                  allowdownload = True
                                                              End If
                                                          End If
                                                      End If
                                                  End If
                                                  If .natives IsNot Nothing AndAlso .natives.windows IsNot Nothing AndAlso allowdownload = True Then
                                                      Dim librarypath As New FileInfo(IO.Path.Combine(librariesfolder.FullName, .path.Replace("/", "\")))
                                                      If IO.Directory.Exists(librarypath.DirectoryName) = False Then
                                                          IO.Directory.CreateDirectory(librarypath.DirectoryName)
                                                      End If
                                                      Try
                                                          Using zip1 As ZipFile = ZipFile.Read(librarypath.FullName)
                                                              ' here, we extract every entry, but we could extract conditionally,
                                                              ' based on entry name, size, date, checkbox status, etc.   
                                                              For Each e As ZipEntry In zip1
                                                                  Dim ls As IList(Of String) = .extract.exclude
                                                                  For Each file As String In ls
                                                                      If e.FileName.StartsWith(file) = False Then
                                                                          e.Extract(UnpackDirectory, ExtractExistingFileAction.OverwriteSilently)
                                                                      End If
                                                                  Next
                                                              Next
                                                          End Using
                                                      Catch ex As ZipException
                                                          Write(Application.Current.FindResource("ErrorUnpackingNatives").ToString & ": " & ex.Message, LogLevel.ERROR)
                                                      End Try
                                                  End If
                                              End With
                                          Next
                                      Catch ex As Exception
                                          Write(Application.Current.FindResource("ErrorUnpackingNativesLibraryMissing").ToString & Environment.NewLine & ex.Message & Environment.NewLine & ex.StackTrace, LogLevel.ERROR)
                                      End Try
                                  End Sub))
    End Function

    Async Function Get_Startinfos() As Task 'TODO Move to Version?
        Await Unzip()
        Write(Application.Current.FindResource("GettingStartInfos").ToString)
        Dim mainClass As String = Startinfos.Versionsinfo.mainClass
        Dim minecraftArguments As List(Of String) = Startinfos.Versionsinfo.minecraftArguments.Split(Chr(32)).ToList
        Dim libraries As String = Nothing
        Dim gamedir As String = Nothing
        Dim argumentreplacements As List(Of String()) = New List(Of String())
        Dim natives As String = """" & UnpackDirectory & """"
        Dim javaargs As String = Nothing
        Dim height As String = Nothing
        Dim width As String = Nothing
        Dim Teil_Arguments As String = Nothing

        Await Task.Run(New Action(Async Sub()
                                      'TODO
                                      'Split by Space --> (Chr(32))
                                      If Startinfos.Versionsinfo Is Nothing Then
                                          Startinfos.Versionsinfo = Await MinecraftDownloadManager.ParseVersionsInfo(Startinfos.Version)
                                      End If
                                      Versionsjar = """" & Path.Combine(versionsfolder.FullName, Startinfos.Versionsinfo.getJar, Startinfos.Versionsinfo.getJar & ".jar") & """"
                                      For i = 0 To Startinfos.Versionsinfo.libraries.Count - 1
                                          Dim librarytemp As Library = Startinfos.Versionsinfo.libraries.Item(i)
                                          If librarytemp.natives Is Nothing OrElse librarytemp.natives.windows IsNot Nothing Then
                                              libraries &= """" & Path.Combine(librariesfolder.FullName, librarytemp.path.Replace("/", "\")) & """" & ";"
                                          End If
                                      Next

                                      If Startinfos.Profile.gameDir <> Nothing Then
                                          gamedir = Startinfos.Profile.gameDir
                                      Else
                                          gamedir = mcpfad.FullName
                                      End If

                                      If IO.Directory.Exists(gamedir) = False Then
                                          IO.Directory.CreateDirectory(gamedir)
                                      End If
                                      Dim assets_dir As String = assetspath.FullName
                                      Dim assets_index_name = If(Startinfos.Versionsinfo.assets, "legacy")
                                      Dim resourcesindex As resourcesindex = Await MinecraftDownloadManager.ParseResources(assets_index_name) 'TODO Don't Parse it again, just parsed when resources where downloaded
                                      If resourcesindex.virtual Then
                                          assets_dir = Path.Combine(assetspath.FullName, "virtual", assets_index_name)
                                      End If
                                      argumentreplacements.Add(New String() {"${auth_player_name}", Startinfos.Session.SelectedProfile.Name})
                                      argumentreplacements.Add(New String() {"${version_name}", Startinfos.Version.id})
                                      argumentreplacements.Add(New String() {"${game_directory}", """" & gamedir & """"})
                                      argumentreplacements.Add(New String() {"${game_assets}", """" & assets_dir & """"})
                                      argumentreplacements.Add(New String() {"${assets_root}", """" & assets_dir & """"})
                                      argumentreplacements.Add(New String() {"${assets_index_name}", assets_index_name})
                                      argumentreplacements.Add(New String() {"${user_properties}", New JObject().ToString})

                                      If Startinfos.Session.OnlineMode = True Then
                                          'session username
                                          argumentreplacements.Add(New String() {"${auth_uuid}", Startinfos.Session.SelectedProfile.Id})
                                          argumentreplacements.Add(New String() {"${auth_access_token}", Startinfos.Session.AccessToken})
                                          argumentreplacements.Add(New String() {"${auth_session}", "token:" & Startinfos.Session.AccessToken & ":" & Startinfos.Session.SelectedProfile.Id})
                                          Dim jo As New JObject
                                          If Startinfos.Session.User.Properties IsNot Nothing Then
                                              For Each item As authenticationDatabase.Userproperty In Startinfos.Session.User.Properties
                                                  jo.Add(New JProperty(item.name, item.value))
                                              Next
                                          End If
                                          argumentreplacements.Add(New String() {"${user_properties}", jo.ToString})
                                          'TODO:
                                          'argumentreplacements.Add(New String() {"${user_type}", "mojang/legacy"})
                                          'Vielleicht twitch token aus einstellungen, so kann man auch cracked streamen
                                      End If

                                      For Each item As String() In argumentreplacements
                                          For i = 0 To minecraftArguments.Count - 1
                                              minecraftArguments.Item(i) = minecraftArguments.Item(i).Replace(item(0), item(1))
                                          Next
                                      Next

                                      If Startinfos.Server.ServerAdress <> Nothing Then
                                          minecraftArguments.Add("--server")
                                          minecraftArguments.Add(Startinfos.Server.ServerAdress)
                                          If Startinfos.Server.ServerPort <> Nothing Then
                                              minecraftArguments.Add("--port")
                                              minecraftArguments.Add(Startinfos.Server.ServerPort)
                                          End If
                                      End If

                                      If Startinfos.Profile.javaArgs <> Nothing Then
                                          javaargs = Startinfos.Profile.javaArgs
                                      Else
                                          'javaargs = "-Xmx" & RamCheck() & "M"
                                          javaargs = "-Xmx" & "1024" & "M"
                                      End If

                                      If Startinfos.Profile.resolution.height <> Nothing AndAlso Startinfos.Profile.resolution.height <> "0" Then
                                          height = "--height " & Startinfos.Profile.resolution.height
                                      Else
                                          height = Nothing
                                      End If

                                      If Startinfos.Profile.resolution.width <> Nothing AndAlso Startinfos.Profile.resolution.width <> "0" Then
                                          width = "--width " & Startinfos.Profile.resolution.width
                                      Else
                                          width = Nothing
                                      End If

                                      Teil_Arguments = String.Join(Chr(32), mainClass, String.Join(Chr(32), minecraftArguments), height, width)
                                      'TODO
                                      Arguments = javaargs & " -Djava.library.path=" & natives & " -cp " & libraries & Versionsjar & " " & Teil_Arguments
                                      If Startinfos.IsStarting = True Then
                                          Start_MC_Process(Teil_Arguments)
                                      End If
                                  End Sub))
    End Function

#Region "MinecraftStart"

    Async Sub Start_MC_Process(Optional Teil_Arguments As String = Nothing)
        If Teil_Arguments = Nothing Then Teil_Arguments = Arguments
        Write(Application.Current.FindResource("StartingMinecraft").ToString & " (" & String.Format(Application.Current.FindResource("JavaArchitecture").ToString, Await GetJavaArch()) & "): " & Teil_Arguments)
        mc = New Process()
        With mc.StartInfo
            .FileName = Startcmd(Startinfos.Profile)
            .Arguments = Arguments
            ' Arbeitsverzeichnis setzen falls nötig
            .WorkingDirectory = mcpfad.FullName
            ' kein Window erzeugen
            .CreateNoWindow = True
            ' UseShellExecute auf false setzen
            .UseShellExecute = False
            ' StandardOutput von Console umleiten
            .RedirectStandardError = True
            .RedirectStandardOutput = True
        End With
        ' Prozess starten
        mc.Start()
        mc.BeginErrorReadLine()
        mc.BeginOutputReadLine()
        If Startinfos.IsStarting = True Then
            Startinfos.IsStarting = False
            Startinfos.Server.JustStarted = False
            Startinfos.Versionsinfo = Nothing
            Startinfos.Profile = Nothing
            Startinfos.Version = Nothing
        End If
    End Sub

    Public Sub StartfromServerlist()
        If Startinfos.Server.JustStarted = False Then
            If MainViewModel.Instance.Directjoinaddress.Contains(":") = False Then
                Startinfos.Server.ServerAdress = MainViewModel.Instance.Directjoinaddress
            Else
                Dim address As String() = MainViewModel.Instance.Directjoinaddress.Split(CChar(":"))
                Startinfos.Server.ServerAdress = address(0)
                Startinfos.Server.ServerPort = address(1)
            End If
            Startinfos.Server.JustStarted = True
        End If
    End Sub

    Public Async Sub StartMC()
        If Startinfos.IsStarting = True Then
            Await Me.ShowMessageAsync(Application.Current.FindResource("Attention").ToString, Application.Current.FindResource("MinecraftAlreadyStarting").ToString & "!", MessageDialogStyle.Affirmative, New MetroDialogSettings() With {.AffirmativeButtonText = Application.Current.FindResource("OK").ToString, .ColorScheme = MetroDialogColorScheme.Accented})
        ElseIf cb_profiles.SelectedIndex = -1 Then
            Await Me.ShowMessageAsync(Nothing, Application.Current.FindResource("PleaseSelectProfile").ToString & "!", MessageDialogStyle.Affirmative, New MetroDialogSettings() With {.AffirmativeButtonText = Application.Current.FindResource("OK").ToString, .ColorScheme = MetroDialogColorScheme.Accented})
            'ElseIf tb_username.Text = Nothing Then
            '    Await Me.ShowMessageAsync(Nothing, "Gib bitte einen Usernamen ein!", MessageDialogStyle.Affirmative, New MetroDialogSettings() With {.AffirmativeButtonText = "Ok", .ColorScheme = MetroDialogColorScheme.Accented})
        Else
            If Startinfos.Profile Is Nothing Then
                Startinfos.Profile = Await Profiles.FromName(MainViewModel.Instance.selectedProfile)
            End If
            Await Versions_Load()
            tabitem_console.IsSelected = True
            mc = New Process
            If Await Check_Account() Then
                If Startinfos.Server.JustStarted = False Then
                    If cb_direct_join.IsChecked = True Then
                        If MainViewModel.Instance.Directjoinaddress <> Nothing Then
                            If Startinfos.Server.JustStarted = False Then
                                If MainViewModel.Instance.Directjoinaddress.Contains(":") = False Then
                                    Startinfos.Server.ServerAdress = MainViewModel.Instance.Directjoinaddress
                                Else
                                    Dim address As String() = MainViewModel.Instance.Directjoinaddress.Split(CChar(":"))
                                    Startinfos.Server.ServerAdress = address(0)
                                    Startinfos.Server.ServerPort = address(1)
                                End If
                                Startinfos.Server.JustStarted = True
                            End If
                        End If
                    Else
                        Startinfos.Server.ServerAdress = Nothing
                    End If
                End If


                If Startinfos.Version Is Nothing Then
                    If Startinfos.Profile.lastVersionId <> Nothing Then
                        'TODO
                        If Versions.versions.Select(Function(p) p.id).Contains(Startinfos.Profile.lastVersionId) Then
                            Startinfos.Version = Versions.versions.Where(Function(p) p.id = Startinfos.Profile.lastVersionId).First
                        Else
                            Write(String.Format(Application.Current.FindResource("JarOrJsonNotFound").ToString, Startinfos.Profile.lastVersionId, Startinfos.Profile.lastVersionId) & Environment.NewLine & Application.Current.FindResource("ReinstallForgeIfStarted").ToString & "!", LogLevel.ERROR)
                            Startinfos.Profile = Nothing
                            Exit Sub
                        End If
                    Else
                        If Startinfos.Profile.allowedReleaseTypes Is Nothing Then
                            Startinfos.Profile.allowedReleaseTypes = New List(Of String)
                        End If
                        'Wenn snapshots aktiviert sind, dann index 0, sonst latestrelease
                        If Startinfos.Profile.allowedReleaseTypes.Count > 0 Then
                            If Startinfos.Profile.allowedReleaseTypes.Contains("snapshot") = True Then
                                'Version mit Index 0 auslesen
                                Startinfos.Version = Versions.latest_version
                            Else
                                Startinfos.Version = Versions.versions.Where(Function(p) p.id = Versions.latest.release).First
                            End If
                        Else
                            Startinfos.Version = Versions.versions.Where(Function(p) p.id = Versions.latest.release).First
                        End If
                    End If
                End If
                Clear()
                Startinfos.IsStarting = True
                If Await MinecraftDownloadManager.DownloadVersion(Startinfos.Version) Then
                    If Startinfos.Versionsinfo Is Nothing Then
                        Startinfos.Versionsinfo = Await MinecraftDownloadManager.ParseVersionsInfo(Startinfos.Version)
                        If Startinfos.Versionsinfo.minimumLauncherVersion > supportedLauncherVersion Then
                            Main.Write(Application.Current.FindResource("VersionNotSupported").ToString, MainWindow.LogLevel.ERROR)
                        End If
                    End If
                    Startinfos.Versionsinfo = Await Startinfos.Versionsinfo.resolve
                    If Await MinecraftDownloadManager.DownloadResources() Then
                        If Await MinecraftDownloadManager.DownloadLibraries(Startinfos.Versionsinfo) Then
                            Await Get_Startinfos()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btn_startMC_Click(sender As Object, e As RoutedEventArgs) Handles btn_startMC.Click
        StartMC()
    End Sub

    Private Sub mc_ErrorDataReceived(sender As Object, e As DataReceivedEventArgs) Handles mc.ErrorDataReceived
        Try
            Write(e.Data)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub p_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs) Handles mc.OutputDataReceived
        Try
            Write(e.Data)
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "LOG"
    Public Sub Append(ByVal Line As String, rtb As RichTextBox, Optional Color As Brush = Nothing)
        Me.Dispatcher.Invoke(New Action(Sub()
                                            Dim tr As New TextRange(rtb.Document.ContentEnd, rtb.Document.ContentEnd)
                                            tr.Text = Line & Environment.NewLine
                                            If Color IsNot Nothing Then
                                                tr.ApplyPropertyValue(TextElement.ForegroundProperty, Color)
                                            End If
                                            rtb.ScrollToEnd()
                                        End Sub))
    End Sub
    ''' <summary>
    ''' Schreibt eine Zeile in die tb_ausgabe
    ''' </summary>
    ''' <param name="Line">Die Zeile, die geschrieben werden soll</param>
    ''' <param name="LogLevel">Das Level der Nachricht</param>
    ''' <remarks></remarks>
    Public Sub Write(ByVal Line As String, Optional LogLevel As LogLevel = LogLevel.INFO)
        Select Case LogLevel
            Case MainWindow.LogLevel.INFO
                Dispatcher.Invoke(New WriteA(AddressOf Append), Line, tb_ausgabe)
            Case MainWindow.LogLevel.WARNING
                Dispatcher.Invoke(New WriteColored(AddressOf Append), "[" & Application.Current.FindResource("Warning").ToString & "] " & Line, tb_ausgabe, Brushes.Orange)
            Case MainWindow.LogLevel.ERROR
                Dispatcher.Invoke(New WriteColored(AddressOf Append), "[" & Application.Current.FindResource("Error").ToString & "] " & Line, tb_ausgabe, Brushes.Red)
        End Select
        '-Dfml.ignoreInvalidMinecraftCertificates=true -Dfml.ignorePatchDiscrepancies=true

        'Error:

        '2014-04-08 16:06:25 [Schwerwiegend] [ForgeModLoader] Technical information: The class net.minecraft.client.ClientBrandRetriever should have been associated with the minecraft jar file,
        'and should have returned us a valid, intact minecraft jar location. This did not work. Either you have modified the minecraft jar file (if so run the forge installer again),
        'or you are using a base editing jar that is changing this class (and likely others too). If you REALLY want to run minecraft in this configuration,
        'add the flag -Dfml.ignoreInvalidMinecraftCertificates=true to the 'JVM settings' in your launcher profile.
        If Line.Contains("add the flag -Dfml.ignoreInvalidMinecraftCertificates=true to the 'JVM settings' in your launcher profile") Then
            Write(Application.Current.FindResource("ignoreInvalidMinecraftCertificatesMessage").ToString, MainWindow.LogLevel.ERROR)
        End If
    End Sub
    Public Enum LogLevel
        INFO
        WARNING
        [ERROR]
    End Enum
    Public Sub Clear()
        Me.Dispatcher.Invoke(New Action(Sub()
                                            tb_ausgabe.SelectAll()
                                            tb_ausgabe.Selection.Text = Environment.NewLine
                                        End Sub))
    End Sub
#End Region
    Public Shared Function Startcmd(profile As Profiles.Profile) As String
        If profile.javaDir <> Nothing Then
            Return profile.javaDir
        Else
            Return GetJavaPath()
        End If
    End Function
    Public Shared Async Function GetJavaVersionInformation() As Task(Of String)
        Try
            Dim profile As Profiles.Profile = Nothing
            If Startinfos.IsStarting = True Then
                profile = Startinfos.Profile
            Else
                profile = Await Profiles.FromName(MainViewModel.Instance.selectedProfile)
            End If
            Dim procStartInfo As New System.Diagnostics.ProcessStartInfo(Startcmd(profile), "-version")

            procStartInfo.RedirectStandardOutput = True
            procStartInfo.RedirectStandardError = True
            procStartInfo.UseShellExecute = False
            procStartInfo.CreateNoWindow = True
            Dim proc As System.Diagnostics.Process = New Process()
            proc.StartInfo = procStartInfo
            proc.Start()

            Return proc.StandardError.ReadToEnd()
        Catch objException As Exception
            Return Nothing
        End Try
    End Function
    Public Shared Async Function GetJavaArch() As Task(Of Integer)
        Dim version As String = Await GetJavaVersionInformation()
        If version.Contains("64-Bit") Then
            Return 64
        Else
            Return 32
        End If
    End Function

    Private Sub tb_ausgabe_TextChanged(sender As Object, e As TextChangedEventArgs) Handles tb_ausgabe.TextChanged
        tb_ausgabe.ScrollToEnd()
    End Sub

    Private Sub btn_new_profile_Click(sender As Object, e As RoutedEventArgs) Handles btn_new_profile.Click
        Newprofile = True
        Dim frm_ProfileEditor As New ProfileEditor
        frm_ProfileEditor.ShowDialog()
    End Sub

    Private Sub btn_edit_profile_Click(sender As Object, e As RoutedEventArgs) Handles btn_edit_profile.Click
        Newprofile = False
        Dim frm_ProfileEditor As New ProfileEditor
        frm_ProfileEditor.ShowDialog()
    End Sub

    Private Async Sub btn_delete_profile_Click(sender As Object, e As RoutedEventArgs) Handles btn_delete_profile.Click
        If MainViewModel.Instance.Profiles.Count > 1 Then
            Profiles.Remove(MainViewModel.Instance.selectedProfile)
            MainViewModel.Instance.selectedProfile = MainViewModel.Instance.Profiles.First
            Profiles.Get_Profiles()
        Else
            Await Me.ShowMessageAsync(Application.Current.FindResource("Error").ToString, Application.Current.FindResource("CannotDeleteLastProfile").ToString & "!", MessageDialogStyle.Affirmative, New MetroDialogSettings() With {.AffirmativeButtonText = Application.Current.FindResource("OK").ToString, .ColorScheme = MetroDialogColorScheme.Accented})
        End If
    End Sub


    Private Sub cb_direct_join_Click(sender As Object, e As RoutedEventArgs) Handles cb_direct_join.Click
        MainViewModel.Instance.Settings.DirectJoin = cb_direct_join.IsChecked.Value
        MainViewModel.Instance.Settings.Save()
    End Sub

#Region "Tools"

    Private Sub forge_installer()
        Dim frg As New Forge_installer
        frg.Show()
    End Sub

    Sub liteloader_installer()
        Dim frg As New LiteLoader_installer
        frg.Show()
    End Sub

    Private Async Sub download_feedthebeast()
        toolscontroller = Await Me.ShowProgressAsync(Application.Current.FindResource("DownloadingFTB").ToString, Application.Current.FindResource("PleaseWait").ToString)
        Dim url As New Uri(Downloads.Downloadsjo("feedthebeast").Value(Of String)("url"))
        Dim filename As String = Downloads.Downloadsjo("feedthebeast").Value(Of String)("filename")
        Dim path As New FileInfo(IO.Path.Combine(mcpfad.FullName, "tools", filename))
        If path.Directory.Exists = False Then
            path.Directory.Create()
        End If
        Try
            btn_start_feedthebeast.IsEnabled = False
            'progressbar lädt herunter
            Dim a As New WebClient
            AddHandler a.DownloadProgressChanged, AddressOf Toolsdownloadpreogresschanged
            Await a.DownloadFileTaskAsync(url, path.FullName)
            Await toolscontroller.CloseAsync()
            btn_start_feedthebeast.IsEnabled = True
        Catch ex As Exception
            Try
                If path.Exists Then
                    path.Delete()
                End If
            Catch
            End Try
            btn_start_feedthebeast.IsEnabled = False
            Me.ShowMessageAsync("Fehler", ex.Message, MessageDialogStyle.Affirmative, New MetroDialogSettings() With {.AffirmativeButtonText = "Ok", .ColorScheme = MetroDialogColorScheme.Accented})
        End Try
    End Sub

    Sub Toolsdownloadpreogresschanged(sender As Object, e As DownloadProgressChangedEventArgs)
        toolscontroller.SetProgress(e.ProgressPercentage / 100)
    End Sub

    Private Sub start_feedthebeast()
        Dim filename As String = Downloads.Downloadsjo("feedthebeast").Value(Of String)("filename")
        Dim path As New FileInfo(IO.Path.Combine(mcpfad.FullName, "tools", filename))
        Process.Start(path.FullName)
    End Sub

    Private Async Sub download_techniclauncher()
        toolscontroller = Await Me.ShowProgressAsync(Application.Current.FindResource("DownloadingTechnicLauncher").ToString, Application.Current.FindResource("PleaseWait").ToString)
        Dim url As String = "http://launcher.technicpack.net/launcher/{0}/TechnicLauncher.jar"
        Dim filename As String = "TechnicLauncher.jar"
        Dim path As New FileInfo(IO.Path.Combine(mcpfad.FullName, "tools", filename))
        If path.Directory.Exists = False Then
            path.Directory.Create()
        End If
        Try
            btn_start_techniclauncher.IsEnabled = False
            'progressbar lädt herunter
            Dim laststablebuild As String = Await New WebClient().DownloadStringTaskAsync("http://build.technicpack.net/job/TechnicLauncher/Stable/buildNumber")
            url = String.Format(url, laststablebuild)
            Dim a As New WebClient
            AddHandler a.DownloadProgressChanged, AddressOf Toolsdownloadpreogresschanged
            Await a.DownloadFileTaskAsync(url, path.FullName)
            Await toolscontroller.CloseAsync()
            btn_start_techniclauncher.IsEnabled = True
        Catch ex As Exception
            Try
                If path.Exists Then
                    path.Delete()
                End If
            Catch
            End Try
            btn_start_techniclauncher.IsEnabled = True
            Me.ShowMessageAsync("Fehler", ex.Message, MessageDialogStyle.Affirmative, New MetroDialogSettings() With {.AffirmativeButtonText = "Ok", .ColorScheme = MetroDialogColorScheme.Accented})
        End Try
    End Sub

    Private Sub start_techniclauncher()
        Dim filename As String = "TechnicLauncher.jar"
        Dim path As New FileInfo(IO.Path.Combine(mcpfad.FullName, "tools", filename))
        Process.Start(path.FullName)
        'TechnicLauncher starten
    End Sub

    Sub Check_Tools_Downloaded()
        'For Each item As Stirng in
        'TechnicLauncher
        Dim technicfilename As String = "TechnicLauncher.jar"
        Dim feedthebeastfilename As String = Downloads.Downloadsjo("feedthebeast").Value(Of String)("filename").ToString
        If File.Exists(Path.Combine(mcpfad.FullName, "tools", technicfilename)) = True Then
            btn_start_techniclauncher.IsEnabled = True
        Else
            btn_start_techniclauncher.IsEnabled = False
        End If
        If File.Exists(Path.Combine(mcpfad.FullName, "tools", feedthebeastfilename)) = True Then
            btn_start_feedthebeast.IsEnabled = True
        Else
            btn_start_feedthebeast.IsEnabled = False
        End If
    End Sub

#End Region

    Private Sub MainWindow_StateChanged(sender As Object, e As EventArgs) Handles Me.StateChanged
        MainViewModel.Instance.Settings.WindowState = Me.WindowState
        MainViewModel.Instance.Settings.Save()
    End Sub

#Region "Auth"
    Private Async Sub cb_profiles_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cb_profiles.SelectionChanged
        Await Check_Account()
    End Sub

    ''' <summary>
    ''' Login with accesstoken. Returns true if successfully logged in, otherwise false.
    ''' </summary>
    ''' <returns>Returns true if successfully logged in, otherwise false.</returns>
    ''' <remarks></remarks>
    Async Function Check_Account() As Task(Of Boolean)
        If cb_profiles.SelectedIndex <> -1 Then
            Await authenticationDatabase.Load()
            Dim profile As Profiles.Profile = Await Profiles.FromName(MainViewModel.Instance.selectedProfile)
            If profile.playerUUID = Nothing Then
                LoginScreen.Open()
                TabControl_main.Visibility = Windows.Visibility.Collapsed
                Return False
            Else
                Dim capturedException As MinecraftAuthenticationException = Nothing
                'Login with access token
                Try
                    If authenticationDatabase.List.Select(Function(p) p.uuid.Replace("-", "")).Contains(profile.playerUUID) Then
                        Dim Account = authenticationDatabase.List.Where(Function(p) p.uuid.Replace("-", "") = profile.playerUUID).First
                        If Guid.TryParse(Account.userid, New Guid) Then
                            If Startinfos.Session Is Nothing Then
                                Startinfos.Session = New Session() With {.AccessToken = Account.accessToken,
                                                                         .ClientToken = authenticationDatabase.clientToken,
                                                                         .SelectedProfile = Nothing}
                            End If
                            If MainViewModel.Instance.Account Is Nothing OrElse Not MainViewModel.Instance.Account.uuid = Account.uuid Then
                                Startinfos.Session = New Session() With {.AccessToken = Account.accessToken,
                                      .ClientToken = authenticationDatabase.clientToken,
                                      .SelectedProfile = Nothing}
                                Write(Application.Current.FindResource("LoggingInWithAccessToken").ToString)
                                Await Startinfos.Session.Refresh()
                                authenticationDatabase.List.Where(Function(p) p.uuid.Replace("-", "") = profile.playerUUID).First.accessToken = Startinfos.Session.AccessToken
                                Await authenticationDatabase.Save()
                            Else
                                'Just logged in
                                Startinfos.Session.AccessToken = Account.accessToken
                                Startinfos.Session.ClientToken = authenticationDatabase.clientToken
                            End If
                        Else
                            Startinfos.Session = New Session() With {.ClientToken = authenticationDatabase.clientToken,
                                                                  .SelectedProfile = New Profile() With {.Name = Account.displayName}}
                        End If
                        'This comes last:
                        MainViewModel.Instance.Account = Account
                        Return True
                    Else
                        LoginScreen.Open()
                        TabControl_main.Visibility = Windows.Visibility.Collapsed
                        Return False
                    End If
                Catch ex As MinecraftAuthenticationException
                    capturedException = ex
                End Try
                If capturedException IsNot Nothing Then
                    Await Me.ShowMessageAsync(capturedException.Error, capturedException.ErrorMessage, MessageDialogStyle.Affirmative)
                    If capturedException.ErrorMessage = "Invalid token." Then
                        If MainViewModel.Instance.Account IsNot Nothing Then
                            Dim Account = MainViewModel.Instance.Account
                            authenticationDatabase.List.Remove(authenticationDatabase.List.Where(Function(p) p.uuid = Account.uuid).First)
                            Await authenticationDatabase.Save()
                        End If
                    End If
                    LoginScreen.Open()
                    TabControl_main.Visibility = Windows.Visibility.Collapsed
                End If
                Return False
                End If
        Else
                Return False
        End If
    End Function

    'Async Function ShowUsername_Avatar(Account As authenticationDatabase.Account) As Task
    '    lbl_Username.Text = Account.displayName
    '    lbl_user_state.Text = If(Guid.TryParse(Account.userid, New Guid), Application.Current.FindResource("Premium").ToString, Application.Current.FindResource("Cracked").ToString)
    '    lbl_user_state.Foreground = If(Guid.TryParse(Account.userid, New Guid), Brushes.Green, Brushes.Red)
    '    Try
    '        Dim WebRequest As HttpWebRequest = DirectCast(HttpWebRequest.Create("https://minotar.net/avatar/" & Account.displayName & "/100"), HttpWebRequest)
    '        Using WebReponse As HttpWebResponse = DirectCast(Await WebRequest.GetResponseAsync, HttpWebResponse)
    '            Using stream As Stream = WebReponse.GetResponseStream
    '                img_avatar.Source = ImageConvert.GetImageStream(System.Drawing.Image.FromStream(stream))
    '            End Using
    '        End Using
    '    Catch ex As WebException
    '        'Failed to load Avatar
    '    End Try
    'End Function

    Private Async Sub btn_logout_Click(sender As Object, e As RoutedEventArgs) Handles btn_logout.Click
        'logout / invalidate session
        Dim capturedException As MinecraftAuthenticationException = Nothing
        Try
            Dim profile As Profiles.Profile = Await Profiles.FromName(MainViewModel.Instance.selectedProfile)
            profile.playerUUID = Nothing
            Await Profiles.Edit(MainViewModel.Instance.selectedProfile, profile)
            LoginScreen.Open()
            TabControl_main.Visibility = Windows.Visibility.Collapsed
        Catch ex As MinecraftAuthenticationException
            capturedException = ex
        End Try
        If capturedException IsNot Nothing Then
            Await Me.ShowMessageAsync(capturedException.Error, capturedException.ErrorMessage, MessageDialogStyle.Affirmative)
        End If
    End Sub

#End Region
    
End Class