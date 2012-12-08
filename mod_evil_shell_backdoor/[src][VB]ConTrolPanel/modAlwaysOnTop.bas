Attribute VB_Name = "modAlwaysOnTop"
Public Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Long, ByVal hWndInsertAfter As Long, ByVal x As Long, ByVal y As Long, ByVal cx As Long, ByVal cy As Long, ByVal wFlags As Long) As Long
Const HWND_TOPMOST = -1
Const SWP_SHOWWINDOW = &H40

Public Function AlwaysOnTop(ByVal wndHwnd As Long, ByVal wndWidth As Long, ByVal wndHeight As Long)
Dim MyWidth As Long, MyHeight As Long
Dim MyTop As Long, MyLeft As Long
  
MyWidth = wndWidth
MyHeight = wndHeight
MyWidth = MyWidth / Screen.TwipsPerPixelX
MyHeight = MyHeight / Screen.TwipsPerPixelY
MyLeft = Screen.Width / (4 * Screen.TwipsPerPixelX)
MyTop = Screen.Height / (4 * Screen.TwipsPerPixelY)

SetWindowPos wndHwnd, HWND_TOPMOST, MyLeft, MyTop, MyWidth, MyHeight, SWP_SHOWWINDOW
End Function
