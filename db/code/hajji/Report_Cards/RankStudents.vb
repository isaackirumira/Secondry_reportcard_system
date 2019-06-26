Imports MySql.Data.MySqlClient
Public Class RankStudents
    Public Sub deletetotals()

        Try




            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("delete from reportcards.totals where class='" + RecordMarks.txt_class.Text + "' and year='" + RecordMarks.txt_year.Text + "' and term='" + RecordMarks.txt_term.Text + "' ", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()

            myReader = SelectCommand.ExecuteReader()




            mycon.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)




        End Try
    End Sub
    Public Sub deleteranks()

        Try




            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("delete from reportcards.positions where class='" + RecordMarks.txt_class.Text + "' and year='" + RecordMarks.txt_year.Text + "' and term='" + RecordMarks.txt_term.Text + "' ", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()

            myReader = SelectCommand.ExecuteReader()




            mycon.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)




        End Try
    End Sub

    Public Sub savetotals()

        Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.totals(name,class,term,year,TotalMark) VALUES(@name,@class,@term,@year, @TotalMark)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("year").Value)
                cmd.Parameters.AddWithValue("@TotalMark", row.Cells("TotalMark").Value)


                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

            Next
            MessageBox.Show("Totals have been saved now make ranks.")



            'fill_data_grid()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Public Sub checktoseeifrankisdone()
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select * from reportcards.positions where class='" + RecordMarks.txt_class.Text + "' and year='" + RecordMarks.txt_year.Text + "' and term='" + RecordMarks.txt_term.Text + "';", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()
            Dim count As Integer = 0
            If (myReader.HasRows()) Then
                count = count + 1

            End If


            If (count = 0) Then
                savetotals()
            ElseIf (count > 0) Then


                deletetotals()
                deleteranks()

                savetotals()

            End If


            mycon.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)


        End Try


    End Sub
    Public Sub fill_students_torank()
        Try


            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT  name,class,term,year ,sum(average) as TotalMark  FROM reportcards.marks where name in (SELECT distinct name from reportcards.marks) and class='" + RecordMarks.txt_class.Text + "' and year='" + RecordMarks.txt_year.Text + "' and term='" + RecordMarks.txt_term.Text + "' GROUP BY name", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView1.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Private Sub RankStudents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fill_students_torank()

        checktoseeifrankisdone()

        FinalRank.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class