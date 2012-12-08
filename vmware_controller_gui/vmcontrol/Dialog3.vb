Imports System.Windows.Forms

Public Class Dialog3
    Public username As String
    Public password As String

    Private Sub Dialog3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Task Manager : " & Explorer1.ListView.SelectedItems.Item(0).Text
        Call Timer1_Tick(sender, e)
        ListView1.Width = Me.Width
        ListView1.View = View.Details
        Timer1.Interval = 100000
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim cmd As Process
        Dim str() As String
        Dim pline As String

        ListView1.Items.Clear()
        cmd = New Process()
        cmd.StartInfo.FileName = Explorer1.vmrun_path
        cmd.StartInfo.Arguments = "-gu " & username & " -gp " & password & " listProcessesInGuest " & Explorer1.ListView.SelectedItems.Item(0).SubItems(1).Text
        cmd.StartInfo.CreateNoWindow = True
        cmd.StartInfo.UseShellExecute = False
        cmd.StartInfo.RedirectStandardOutput = True
        cmd.Start()
        str = cmd.StandardOutput.ReadToEnd.Split(vbLf)
        cmd.WaitForExit()
        For i As Integer = 1 To str.Length - 2
            pline = str(i).Trim(vbCrLf)
            ListView1.Items.Add(pline.Split(",")(0).Split("=")(1))
            ListView1.Items(i - 1).SubItems.Add(pline.Split(",")(1).Split("=")(1))
            ListView1.Items(i - 1).SubItems.Add(pline.Split(",")(2).Split("=")(1))
        Next

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

        Dim cmd As Process
        Dim str As String

        cmd = New Process()
        cmd = New Process()
        cmd.StartInfo.FileName = Explorer1.vmrun_path
        cmd.StartInfo.Arguments = "-gu " & username & " -gp " & password & " killProcessInGuest " & Explorer1.ListView.SelectedItems.Item(0).SubItems(1).Text & " " & ListView1.SelectedItems.Item(0).Text
        cmd.StartInfo.CreateNoWindow = True
        cmd.StartInfo.UseShellExecute = False
        cmd.StartInfo.RedirectStandardOutput = True
        cmd.Start()
        str = cmd.StandardOutput.ReadToEnd
        If str <> "" Then
            MsgBox(str, MsgBoxStyle.Critical)
        End If
        cmd.WaitForExit()
        Call Timer1_Tick(sender, e)

    End Sub

    Private Sub ListView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If ListView1.SelectedIndices.Count = 0 Then
                ContextMenuStrip2.Show(sender, New Point(e.X, e.Y))
            Else
                ContextMenuStrip1.Show(sender, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Call Timer1_Tick(sender, e)
    End Sub
End Class
