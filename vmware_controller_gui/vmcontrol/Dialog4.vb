Imports System.Windows.Forms

Public Class Dialog4
    Public username As String
    Public password As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim cmd As Process
        Dim str As String

        cmd = New Process()
        cmd.StartInfo.FileName = Explorer1.vmrun_path
        cmd.StartInfo.Arguments = "-gu " & username & " -gp " & password & " captureScreen " & Explorer1.ListView.SelectedItems.Item(0).SubItems(1).Text & " " & Chr(34) & TextBox1.Text & Chr(34)
        cmd.StartInfo.CreateNoWindow = True
        cmd.StartInfo.UseShellExecute = False
        cmd.StartInfo.RedirectStandardOutput = True
        cmd.Start()
        str = cmd.StandardOutput.ReadToEnd
        If str <> "" Then
            MsgBox(str, MsgBoxStyle.Critical)
        End If
        cmd.WaitForExit()

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim OpenFileDialog As New SaveFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "png (*.png)|*.png"
        OpenFileDialog.ShowDialog(Me)
        TextBox1.Text = OpenFileDialog.FileName()
    End Sub
End Class
