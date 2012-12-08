Public Class LoginForm1

    Public caller As String

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click '

        If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Then
            Return
        End If

        If caller = "task" Then
            Dialog3.username = UsernameTextBox.Text
            Dialog3.password = PasswordTextBox.Text
            Dialog3.Show()
            Me.Close()
        End If


        If caller = "screen" Then
            Dialog4.username = UsernameTextBox.Text
            Dialog4.password = PasswordTextBox.Text
            Dialog4.Show()
            Me.Close()
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Login to " & Explorer1.ListView.SelectedItems.Item(0).Text
    End Sub
End Class
