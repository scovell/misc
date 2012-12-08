VERSION 5.00
Begin VB.Form frmCmdWindow 
   BackColor       =   &H00000000&
   BorderStyle     =   5  'Sizable ToolWindow
   Caption         =   "cmdWindowControl"
   ClientHeight    =   3510
   ClientLeft      =   7260
   ClientTop       =   2475
   ClientWidth     =   9855
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3510
   ScaleWidth      =   9855
   ShowInTaskbar   =   0   'False
   Begin VB.TextBox txtCmd 
      BeginProperty Font 
         Name            =   "Trebuchet MS"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   285
      Left            =   120
      TabIndex        =   2
      Top             =   3120
      Width           =   8295
   End
   Begin VB.CommandButton cmdExecute 
      Caption         =   "cmdExec"
      Height          =   255
      Left            =   8640
      TabIndex        =   1
      Top             =   3120
      Width           =   1095
   End
   Begin VB.TextBox txtDisplay 
      BackColor       =   &H00000000&
      BeginProperty Font 
         Name            =   "Trebuchet MS"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FF00&
      Height          =   3015
      HideSelection   =   0   'False
      Left            =   0
      Locked          =   -1  'True
      MultiLine       =   -1  'True
      ScrollBars      =   3  'Both
      TabIndex        =   0
      Top             =   0
      Width           =   9855
   End
End
Attribute VB_Name = "frmCmdWindow"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdExecute_Click()
Dim cmdSend As String
If txtCmd.Text = "exit" Or txtCmd.Text = "EXIT" Then
GoTo exitCmd
End If
cmdSend = txtCmd + vbCrLf
frmMainServer.sockServer(frmMainServer.lstConn.SelectedItem.Index).SendData cmdSend
exitCmd:
txtCmd.Text = ""
End Sub

Private Sub Form_Activate()
txtCmd.SetFocus
End Sub

Private Sub Form_Unload(Cancel As Integer)
frmMainServer.sockServer(frmMainServer.lstConn.SelectedItem.Index).Close
frmMainServer.lstConn.listItems.Remove frmMainServer.lstConn.SelectedItem.Index
frmMainServer.Show
End Sub

Private Sub txtCmd_KeyPress(KeyAscii As Integer)
If KeyAscii = 13 Then
Call cmdExecute_Click
End If
End Sub

Private Sub txtDisplay_Change()
txtDisplay.SelStart = Len(txtDisplay.Text)
End Sub
