Imports MySql.Data.MySqlClient
Public Class Form2

    Private Sub RegisterClassesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterClassesToolStripMenuItem.Click
        Regclasses.Show()
    End Sub

    Private Sub ManageSubjectsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageSubjectsToolStripMenuItem.Click
        Regsubjects.Show()
    End Sub

    Private Sub ManageTeachersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageTeachersToolStripMenuItem.Click
        Regteachers.Show()
    End Sub

    Private Sub ManageStudentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageStudentsToolStripMenuItem.Click
        Regstudents.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Visible = False
        Login.cmboxLoginType.Text = ""
        Login.txtPass.Text = ""
        Login.txtUserID.Text = ""
        Me.RegisterClassesToolStripMenuItem.Enabled = True
        Me.ManageStudentsToolStripMenuItem.Enabled = True
        Me.ManageSubjectsToolStripMenuItem.Enabled = True
        Me.ManageTeachersToolStripMenuItem.Enabled = True
        Me.ManageDatesToolStripMenuItem.Enabled = True
        RecordMarks.RankStudentsToolStripMenuItem.Enabled = True
        Login.Show()

    End Sub

    Private Sub RecordMarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecordMarksToolStripMenuItem.Click

        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select max(year) from reportcards.students ;", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()

            While (myReader.Read())
                Dim maxyear As String = myReader.GetString("max(year)").ToString()
                If (maxyear < 2020) Then
                    RecordMarks.Show()
                ElseIf (maxyear >= 2020) Then
                    MessageBox.Show("System needs to be updated contact developer on 0759939936")
                End If

            End While
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub ManageDatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageDatesToolStripMenuItem.Click
        ManageDates.Show()
    End Sub


    Private Sub RecordMarksALevelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecordMarksALevelToolStripMenuItem.Click
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select max(year) from reportcards.students ;", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()

            While (myReader.Read())
                Dim maxyear As String = myReader.GetString("max(year)").ToString()
                If (maxyear < 2020) Then
                    RecordMarksALevel.Show()
                ElseIf (maxyear >= 2020) Then
                    MessageBox.Show("System needs to be updated contact  system developer on 0759939936")
                End If

            End While
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
        'RecordMarksALevel.Show()
    End Sub

    Private Sub ANALYSISToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ANALYSISToolStripMenuItem.Click
        analysis.Show()
    End Sub
End Class