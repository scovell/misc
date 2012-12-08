Imports System.Windows.Forms
Imports System.Xml

Public Class Dialog1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("name cannot be empty", MsgBoxStyle.Exclamation, "Empty Name")
            End
        End If

        Dim config As XmlDocument
        Dim vm As XmlElement
        Dim vmname As XmlElement
        Dim vmpath As XmlElement

        config = New XmlDocument
        config.Load(Application.StartupPath & "\config.xml")

        vm = config.CreateElement("vm")
        vm.SetAttribute("folder", ComboBox1.SelectedItem.ToString)
        vmname = config.CreateElement("name")
        vmname.InnerText = TextBox1.Text
        vmpath = config.CreateElement("path")
        vmpath.InnerText = TextBox2.Text
        vm.AppendChild(vmname)
        vm.AppendChild(vmpath)

        config.DocumentElement.AppendChild(vm)
        config.Save(Application.StartupPath & "\config.xml")
        MsgBox(TextBox1.Text & " Added Sucessfully", MsgBoxStyle.Information)

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
        Call Explorer1.GetConfig()
        Call Explorer1.ListVM(ComboBox1.SelectedItem.ToString)
    End Sub

    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = Explorer1.Location + New Point(100, 100)
        ComboBox1.Items.Add("Windows")
        ComboBox1.Items.Add("Linux")
        ComboBox1.Items.Add("FreeBSD")
        ComboBox1.Items.Add("Novell Netware")
        ComboBox1.Items.Add("Sun Solaris")
        ComboBox1.SelectedIndex = 0

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "VMX (*.vmx)|*.vmx"
        OpenFileDialog.ShowDialog(Me)
        TextBox2.Text = OpenFileDialog.FileName()
    End Sub
End Class
