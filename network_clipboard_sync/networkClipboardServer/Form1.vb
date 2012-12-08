Imports System.Net
Imports System.Net.Sockets

Public Class Form1

    Dim cbPort As Integer = 1991
    Dim _remote As New TcpClient()
    Dim _local As New TcpListener(cbPort)
    Dim _io As NetworkStream
    Dim origClip As String = Clipboard.GetText()
    Dim btnClick As Boolean = False

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        _local.Stop()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _local.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick


        If _local.Pending() = True Then
            _remote = _local.AcceptTcpClient
            _io = _remote.GetStream()
            If _io.DataAvailable Then
                Dim size As Integer = _remote.ReceiveBufferSize
                Dim txtClip(size) As Byte
                _io.Read(txtClip, 0, size)
                Clipboard.SetText(System.Text.UTF8Encoding.UTF8.GetString(txtClip))
                _io.Close()
                _remote.Close()
                origClip = Clipboard.GetText()
            End If
        End If

        If origClip <> Clipboard.GetText() Then
            origClip = Clipboard.GetText()
            _remote = New TcpClient()
            _remote.Connect(TextBox1.Text, cbPort)
            If _remote.Connected Then
                _io = _remote.GetStream()
                _io.Write(System.Text.UTF8Encoding.UTF8.GetBytes(Clipboard.GetText()), 0, Clipboard.GetText().Length)
            End If
            _io.Close()
            _remote.Close()
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If btnClick = False Then
            Timer1.Enabled = True
            btnClick = True
            Button1.Text = "Stop"
            'TextBox1.Enabled = False
        Else
            Timer1.Enabled = False
            btnClick = False
            Button1.Text = "Start"
            'TextBox1.Enabled = True
        End If

    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If Me.WindowState = FormWindowState.Minimized Then

            Me.WindowState = FormWindowState.Minimized
            NotifyIcon1.Visible = True
            Me.Visible = False

        End If

    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick

        Me.WindowState = FormWindowState.Maximized
        Me.Visible = True
        NotifyIcon1.Visible = False


    End Sub
End Class
