Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Xml


Public Class Explorer1

    Public vmrun_path As String

    Private Sub Explorer1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        check_vmrun()
        ListView.GridLines = True
        SetUpListViewColumns()
        GetConfig()
        TreeView.SelectedNode = TreeView.Nodes.Item(0).FirstNode

    End Sub

    Public Sub check_vmrun()

        vmrun_path = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\vmcontrol", "vmrun", Nothing)
        If vmrun_path = "" Then
            Me.Hide()
            Dialog5.ShowDialog()
        End If

    End Sub


    Public Sub GetConfig()

        Dim config As XmlDocument
        Dim vm As XmlNodeList
        Dim node As XmlNode
        Dim tvRoot As TreeNode

        TreeView.Nodes.Clear()
        tvRoot = TreeView.Nodes.Add("Virtual Machines")
        config = New XmlDocument()
        config.Load(Application.StartupPath & "\config.xml")
        vm = config.SelectNodes("/machines/vm")

        For Each node In vm
            If Not tvRoot.Nodes.ContainsKey(node.Attributes.GetNamedItem("folder").Value) Then
                tvRoot.Nodes.Add(node.Attributes.GetNamedItem("folder").Value)
                tvRoot.LastNode.Name = node.Attributes.GetNamedItem("folder").Value
            End If
        Next
        TreeView.ExpandAll()
    End Sub


    Private Sub SetUpListViewColumns()

        Dim lvColumnHeader As ColumnHeader
        ListView.View = View.Details
        ListView.SmallImageList = ImageList1
        lvColumnHeader = ListView.Columns.Add("Virtual Machine Name")
        lvColumnHeader.Width = 150
        lvColumnHeader = ListView.Columns.Add("Virtual Machine Path")
        lvColumnHeader.Width = 150

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub ListVM(ByVal folder As String)
        Dim config As XmlDocument
        Dim vm As XmlNodeList
        Dim node As XmlNode
        Dim lvItem As ListViewItem

        ListView.Items.Clear()
        ListView.SmallImageList = ImageList1
        config = New XmlDocument()
        config.Load(Application.StartupPath & "\config.xml")
        vm = config.SelectNodes("/machines/vm")

        For Each node In vm
            If node.Attributes.GetNamedItem("folder").Value = folder Then
                lvItem = ListView.Items.Add(node.ChildNodes.Item(0).InnerText)
                lvItem.ImageKey = ImageList1.Images.Keys(0)
                lvItem.SubItems.Add(node.ChildNodes.Item(1).InnerText)
            End If
        Next

    End Sub

    Private Sub TreeView_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView.AfterSelect

        If TreeView.SelectedNode.Text <> "Virtual Machines" Then
            ListVM(TreeView.SelectedNode.Text)
        Else
            ListView.Items.Clear()
        End If

    End Sub

    Private Sub TreeView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(sender, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub ListView_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If ListView.SelectedIndices.Count = 0 Then
                ContextMenuStrip2.Show(sender, New Point(e.X, e.Y))
            Else
                ContextMenuStrip3.Show(sender, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dialog1.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        GetConfig()
        TreeView.ExpandAll()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Dim config As XmlDocument
        Dim delNode As XmlNode
        Dim rootNode As XmlNode
        Dim folder As String

        config = New XmlDocument()
        config.Load(Application.StartupPath & "\config.xml")

        delNode = config.SelectSingleNode("/machines/vm[name=" & Chr(39) & ListView.SelectedItems.Item(0).Text & Chr(39) & "]")
        rootNode = config.DocumentElement
        folder = delNode.Attributes.GetNamedItem("folder").Value
        rootNode.RemoveChild(delNode)
        config.Save(Application.StartupPath & "\config.xml")

        If Not TreeView.Nodes.ContainsKey(folder) Then
            ListVM(folder)
        Else
            ListView.Items.Clear()
        End If

        GetConfig()
        TreeView.ExpandAll()

    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        Dim vmpath As String
        Dim cmd As String

        If ListView.SelectedItems.Count <> 0 Then
            vmpath = ListView.SelectedItems.Item(0).SubItems(1).Text
            cmd = vmrun_path & " -T ws start " & Chr(34) & vmpath + Chr(34)
            Shell(cmd)
            ListView.SelectedItems.Item(0).ImageKey = ImageList1.Images.Keys(1)
        End If
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Dim vmpath As String
        Dim cmd As String

        If ListView.SelectedItems.Count <> 0 Then
            vmpath = ListView.SelectedItems.Item(0).SubItems(1).Text
            cmd = vmrun_path & " -T ws stop " & Chr(34) & vmpath + Chr(34)
            Shell(cmd)
            ListView.SelectedItems.Item(0).ImageKey = ImageList1.Images.Keys(0)
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Dim vmpath As String
        Dim cmd As String

        If ListView.SelectedItems.Count <> 0 Then
            vmpath = ListView.SelectedItems.Item(0).SubItems(1).Text
            cmd = vmrun_path & " -T ws pause " & Chr(34) & vmpath + Chr(34)
            Shell(cmd)
            ListView.SelectedItems.Item(0).ImageKey = ImageList1.Images.Keys(2)
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Dim vmpath As String
        Dim cmd As String

        If ListView.SelectedItems.Count <> 0 Then
            vmpath = ListView.SelectedItems.Item(0).SubItems(1).Text
            cmd = vmrun_path & " -T ws unpause " & Chr(34) & vmpath + Chr(34)
            Shell(cmd)
            ListView.SelectedItems.Item(0).ImageKey = ImageList1.Images.Keys(1)
        End If
    End Sub

    Private Sub Explorer1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            NotifyIcon1.Visible = True
        End If
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Show()
            Me.WindowState = FormWindowState.Normal
        End If

        If Me.WindowState = FormWindowState.Normal Then
            Return
        End If

    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Dialog2.Show()
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        LoginForm1.caller = "task"
        LoginForm1.Show()
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        LoginForm1.caller = "screen"
        LoginForm1.Show()
    End Sub
End Class



