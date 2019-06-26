Imports MySql.Data.MySqlClient
Public Class Login

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select * from reportcards.login where username='" & txtUserID.Text & "' and password='" & txtPass.Text & "' and usertype='" & cmboxLoginType.Text & "';", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()
            Dim count As Integer = 0
            If (myReader.HasRows()) Then
                count = count + 1

            End If
            If (cmboxLoginType.Text = "admin") Then

                If (count = 1) Then

                    MessageBox.Show("username and password correct , access granted")
                    txtPass.Text = ""
                    txtUserID.Text = ""

                    Form2.Show()
                    Me.Visible = False


                ElseIf (count > 1) Then

                    MessageBox.Show("Duplicate user in the database and access denied")


                Else
                    MessageBox.Show("username and password do not match")

                End If
            ElseIf (cmboxLoginType.Text = "user") Then

                If (count = 1) Then

                    MessageBox.Show("username and password correct , access granted")
                    txtPass.Text = ""
                    txtUserID.Text = ""

                    Form2.RegisterClassesToolStripMenuItem.Enabled = False
                    Form2.ManageStudentsToolStripMenuItem.Enabled = False
                    Form2.ManageSubjectsToolStripMenuItem.Enabled = False
                    Form2.ManageTeachersToolStripMenuItem.Enabled = False
                    Form2.ManageDatesToolStripMenuItem.Enabled = False
                    RecordMarks.RankStudentsToolStripMenuItem.Enabled = False
                    Form2.Show()









                    Me.Visible = False


                ElseIf (count > 1) Then

                    MessageBox.Show("Duplicate user in the database and access denied")


                Else
                    MessageBox.Show("username and password combination does not macth")

                End If
            End If
            mycon.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)


        End Try
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class
