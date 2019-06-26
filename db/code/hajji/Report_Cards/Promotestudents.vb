Imports MySql.Data.MySqlClient
Public Class Promotestudents
    Public Sub fill_classes()
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select * from reportcards.classes ;", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()

            While (myReader.Read())
                Dim classes As String = myReader.GetString("class").ToString()
                txt_class.Items.Add(classes)
                txt_to.Items.Add(classes)
            End While

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try


    End Sub
    Private Sub Promotestudents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fill_classes()
    End Sub

    Private Sub PromoteStudentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PromoteStudentsToolStripMenuItem.Click
        Dim Aa As String

        Aa = MsgBox("are you sure u want to promote students?", vbYesNo, "Question")

        If Aa = vbYes Then

            If (txt_to.Text.Length > 0 And txt_class.Text.Length > 0) Then

                Try




                    Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
                    Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
                    Dim SelectCommand As MySqlCommand = New MySqlCommand("update reportcards.students set class='" + txt_to.Text + "',year='" + txt_yearnew.Text + "' where class='" + txt_class.Text + "' and year='" + txt_yearprev.Text + "' ", mycon)
                    Dim myReader As MySqlDataReader

                    mycon.Open()

                    myReader = SelectCommand.ExecuteReader()
                    MessageBox.Show("Data has been updated students have been promoted")


                    txt_class.Text = ""
                    txt_to.Text = ""
                    txt_yearnew.Text = ""
                    txt_yearprev.Text = ""

                    mycon.Close()


                Catch ex As Exception
                    MessageBox.Show(ex.Message)




                End Try
            Else
                MessageBox.Show("None of the fields should be blank")
            End If


        Else



        End If
    End Sub
End Class