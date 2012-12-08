Imports System.Windows.Forms
Imports System.Xml

Public Class Dialog2
    Private Sub Dialog2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim cmd As Process
        Dim str() As String
        Dim config As XmlDocument
        Dim vmpath As XmlElement

        ListView1.Width = Me.Width
        ListView1.View = View.List
        ListView1.SmallImageList = Explorer1.ImageList1

        config = New XmlDocument
        cmd = New Process()
        cmd.StartInfo.FileName = Explorer1.vmrun_path
        cmd.StartInfo.Arguments = "list"
        cmd.StartInfo.CreateNoWindow = True
        cmd.StartInfo.UseShellExecute = False
        cmd.StartInfo.RedirectStandardOutput = True
        cmd.Start()
        str = cmd.StandardOutput.ReadToEnd.Trim(vbCr).Split(vbLf)
        cmd.WaitForExit()

        For i As Integer = 1 To str.Length - 2
            config.Load(Application.StartupPath & "\config.xml")
            vmpath = config.SelectSingleNode("/machines/vm[path=" & Chr(39) & str(i).Trim(vbCrLf) & Chr(39) & "]")
            If Not vmpath Is Nothing Then
                ListView1.Items.Add(vmpath.ChildNodes.Item(0).InnerText)
            Else
                ListView1.Items.Add(str(i).Trim(vbCrLf))
            End If
            ListView1.Items(0).ImageKey = Explorer1.ImageList1.Images.Keys(0)

        Next

    End Sub
End Class
