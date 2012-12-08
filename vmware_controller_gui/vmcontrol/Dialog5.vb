Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class Dialog5

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim key As RegistryKey
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If TextBox1.Text = "" Then
            MsgBox("Select the vmrun.exe Path", MsgBoxStyle.Critical)
            Return
        End If

        Explorer1.vmrun_path = TextBox1.Text

        key = Registry.LocalMachine.OpenSubKey("SOFTWARE", True)
        key.CreateSubKey("vmcontrol")
        key.Close()
        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\vmcontrol", "vmrun", TextBox1.Text, RegistryValueKind.String)
        Explorer1.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "vmrun.exe (*.exe)|*.exe"
        OpenFileDialog.ShowDialog(Me)
        TextBox1.Text = OpenFileDialog.FileName()
    End Sub

    Private Sub Dialog5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterParent
    End Sub
End Class
