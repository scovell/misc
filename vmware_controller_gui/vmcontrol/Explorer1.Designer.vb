<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Explorer1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    Friend WithEvents ToolStripContainer As System.Windows.Forms.ToolStripContainer
    Friend WithEvents TreeNodeImageList As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeView As System.Windows.Forms.TreeView
    Friend WithEvents ListView As System.Windows.Forms.ListView
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ListViewLargeImageList As System.Windows.Forms.ImageList
    Friend WithEvents ListViewSmallImageList As System.Windows.Forms.ImageList

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Explorer1))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.TreeNodeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripContainer = New System.Windows.Forms.ToolStripContainer
        Me.SplitContainer = New System.Windows.Forms.SplitContainer
        Me.TreeView = New System.Windows.Forms.TreeView
        Me.ListView = New System.Windows.Forms.ListView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ListViewLargeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ListViewSmallImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip.SuspendLayout()
        Me.ToolStripContainer.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer.ContentPanel.SuspendLayout()
        Me.ToolStripContainer.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(686, 22)
        Me.StatusStrip.TabIndex = 6
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(38, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'TreeNodeImageList
        '
        Me.TreeNodeImageList.ImageStream = CType(resources.GetObject("TreeNodeImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.TreeNodeImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.TreeNodeImageList.Images.SetKeyName(0, "ClosedFolder")
        Me.TreeNodeImageList.Images.SetKeyName(1, "OpenFolder")
        '
        'ToolStripContainer
        '
        '
        'ToolStripContainer.BottomToolStripPanel
        '
        Me.ToolStripContainer.BottomToolStripPanel.Controls.Add(Me.StatusStrip)
        '
        'ToolStripContainer.ContentPanel
        '
        Me.ToolStripContainer.ContentPanel.Controls.Add(Me.SplitContainer)
        Me.ToolStripContainer.ContentPanel.Size = New System.Drawing.Size(686, 378)
        Me.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer.Name = "ToolStripContainer"
        Me.ToolStripContainer.Size = New System.Drawing.Size(686, 425)
        Me.ToolStripContainer.TabIndex = 7
        Me.ToolStripContainer.Text = "ToolStripContainer1"
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.TreeView)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.ListView)
        Me.SplitContainer.Size = New System.Drawing.Size(686, 378)
        Me.SplitContainer.SplitterDistance = 227
        Me.SplitContainer.TabIndex = 0
        Me.SplitContainer.Text = "SplitContainer1"
        '
        'TreeView
        '
        Me.TreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView.ImageIndex = 0
        Me.TreeView.ImageList = Me.TreeNodeImageList
        Me.TreeView.Location = New System.Drawing.Point(0, 0)
        Me.TreeView.Name = "TreeView"
        Me.TreeView.SelectedImageIndex = 1
        Me.TreeView.ShowLines = False
        Me.TreeView.Size = New System.Drawing.Size(227, 378)
        Me.TreeView.TabIndex = 0
        '
        'ListView
        '
        Me.ListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView.LargeImageList = Me.ImageList1
        Me.ListView.Location = New System.Drawing.Point(0, 0)
        Me.ListView.MultiSelect = False
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(455, 378)
        Me.ListView.SmallImageList = Me.ImageList1
        Me.ListView.TabIndex = 0
        Me.ListView.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "vmapputil_11845.ico")
        Me.ImageList1.Images.SetKeyName(1, "vmapputil_11846.ico")
        Me.ImageList1.Images.SetKeyName(2, "vmapputil_11847.ico")
        '
        'ListViewLargeImageList
        '
        Me.ListViewLargeImageList.ImageStream = CType(resources.GetObject("ListViewLargeImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListViewLargeImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ListViewLargeImageList.Images.SetKeyName(0, "Graph1")
        Me.ListViewLargeImageList.Images.SetKeyName(1, "Graph2")
        Me.ListViewLargeImageList.Images.SetKeyName(2, "Graph3")
        '
        'ListViewSmallImageList
        '
        Me.ListViewSmallImageList.ImageStream = CType(resources.GetObject("ListViewSmallImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListViewSmallImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ListViewSmallImageList.Images.SetKeyName(0, "Graph1")
        Me.ListViewSmallImageList.Images.SetKeyName(1, "Graph2")
        Me.ListViewSmallImageList.Images.SetKeyName(2, "Graph3")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(124, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(123, 22)
        Me.ToolStripMenuItem1.Text = "Refresh"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem6})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(196, 48)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(195, 22)
        Me.ToolStripMenuItem2.Text = "New Virtual Machine"
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem8, Me.ToolStripMenuItem9, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem10, Me.ToolStripMenuItem7, Me.ToolStripMenuItem3})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(192, 180)
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem8.Text = "Start"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem9.Text = "Stop"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem4.Text = "Pause"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem5.Text = "Unpause"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem3.Text = "Delete Virtual Machine"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(195, 22)
        Me.ToolStripMenuItem6.Text = "Active Virtual Machines"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem7.Text = "Task Manager"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(191, 22)
        Me.ToolStripMenuItem10.Text = "Screenshot"
        '
        'Explorer1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 425)
        Me.Controls.Add(Me.ToolStripContainer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Explorer1"
        Me.Text = "Virtual Machine Controller"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ToolStripContainer.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer.ResumeLayout(False)
        Me.ToolStripContainer.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem

End Class
