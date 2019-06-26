Imports MySql.Data.MySqlClient
Public Class RecordMarks

    Dim WithEvents txt1 As TextBox
    ''' olevel grading
    Dim v1 As String = "D1"
    Dim s1 As String = "1"
    Dim r1 As String = "Good Attemp"
    Dim v2 As String = "D2"
    Dim s2 As String = "2"
    Dim r2 As String = "Very Good"
    Dim v3 As String = "C3"
    Dim s3 As String = "3"
    Dim r3 As String = "Aim higher"
    Dim v4 As String = "C4"
    Dim s4 As String = "4"
    Dim r4 As String = "Aim higher"
    Dim v5 As String = "C5"
    Dim s5 As String = "5"
    Dim r5 As String = "Aim higher"
    Dim v6 As String = "C6"
    Dim s6 As String = "6"
    Dim r6 As String = "Aim higher"
    Dim v7 As String = "P7"
    Dim s7 As String = "7"
    Dim r7 As String = "More Effort"
    Dim v8 As String = "P8"
    Dim s8 As String = "8"
    Dim r8 As String = "Pull up"
    Dim v9 As String = "F9"
    Dim s9 As String = "9"
    Dim r9 As String = "Double Effort"
    ''' olevel grading ends
    ''' alevel grading
    Dim a1 As String = "A"
    Dim b1 As String = "6"
    Dim c1 As String = "Good Attemp"
    Dim a2 As String = "B"
    Dim b2 As String = "5"
    Dim c2 As String = "Very Good"
    Dim a3 As String = "C"
    Dim b3 As String = "4"
    Dim c3 As String = "Good"
    Dim a4 As String = "D"
    Dim b4 As String = "3"
    Dim c4 As String = "Fair Good"
    Dim a5 As String = "E"
    Dim b5 As String = "2"
    Dim c5 As String = "Fair"
    Dim a6 As String = "O"
    Dim b6 As String = "1"
    Dim c6 As String = "Improve"
    Dim a7 As String = "F9"
    Dim b7 As String = "0"
    Dim c7 As String = "More Effort"
   
    ''' alevel grading ends



    Dim v10 As String = "-"
    Dim s10 As String = "-"
    Dim r10 As String = "Missed Paper"

    Dim tb As TextBox
    Dim maxid As String
    Dim entryid As String


    Public Sub deletemarksgrades()

        Try




            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("delete from reportcards.grades where class='" + txt_class.Text + "' and year='" + txt_year.Text + "' and term='" + txt_term.Text + "' and subject='" + txt_subject.Text + "' ", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()

            myReader = SelectCommand.ExecuteReader()




            mycon.Close()


        Catch ex As Exception
            'MessageBox.Show(ex.Message)




        End Try
    End Sub
    Public Sub Savedatagrades()
        If (txt_subject.Text = "" And txt_level.Text = "") Then
            MessageBox.Show("Subject or level Missing")
        Else




            Try
                Dim i2 As Integer
                i2 = DataGridView1.CurrentRow.Index



                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim constring As String = "datasource=localhost;port=3306;username=root;"
                    Dim con As New MySqlConnection(constring)
                    Dim cmd As New MySqlCommand("INSERT INTO reportcards.grades(class,Class_Teacher,year,name,subject,term,date,initial,password,mid,end,average,grade,aggregate,remark,entryid) VALUES(@class,@classteacher,@year,@name, @subject, @term, @date, @initial, @password, @mid,@end,@average,@grade,@aggregate,@remark,@entryid)", con)
                    cmd.Parameters.AddWithValue("@class", txt_class.Text)
                    cmd.Parameters.AddWithValue("@classteacher", txt_classteacher.Text)
                    cmd.Parameters.AddWithValue("@year", txt_year.Text)
                    cmd.Parameters.AddWithValue("@name", row.Cells("name").Value)
                    cmd.Parameters.AddWithValue("@subject", txt_subject.Text)
                    cmd.Parameters.AddWithValue("@term", txt_term.Text)
                    cmd.Parameters.AddWithValue("@date", DateTimePicker1.Text)
                    cmd.Parameters.AddWithValue("@initial", txt_initial.Text)
                    cmd.Parameters.AddWithValue("@password", txt_password.Text)

                    cmd.Parameters.AddWithValue("@mid", row.Cells("MID").Value)
                    cmd.Parameters.AddWithValue("@end", row.Cells("EOT").Value)
                    cmd.Parameters.AddWithValue("@average", row.Cells("AVERAGE").Value)

                    cmd.Parameters.AddWithValue("@grade", row.Cells("GRADE").Value)

                    cmd.Parameters.AddWithValue("@aggregate", row.Cells("AGGREGATE").Value)
                    cmd.Parameters.AddWithValue("@remark", row.Cells("REMARK").Value)
                    cmd.Parameters.AddWithValue("@entryid", txt_entryid.Text)

                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                Next
                MessageBox.Show("Records Inserted.")





            Catch ex As Exception
                'MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub





    Public Sub fetchexistingmarks()

        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT  MID,END AS EOT ,AVERAGE,GRADE,AGGREGATE,REMARK,NAME  FROM reportcards.marks where name in (SELECT distinct name from reportcards.marks) and class='" + txt_class.Text + "' and year='" + txt_year.Text + "' and term='" + txt_term.Text + "' and subject='" + txt_subject.Text + "' GROUP BY name ;", conDatabase)
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
            MessageBox.Show("Fill all fields")
            'MessageBox.Show(ex.Message)

        End Try



    End Sub
    Public Sub deletemarks()

        Try




            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("delete from reportcards.marks where class='" + txt_class.Text + "' and year='" + txt_year.Text + "' and term='" + txt_term.Text + "' and subject='" + txt_subject.Text + "' ", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()

            myReader = SelectCommand.ExecuteReader()




            mycon.Close()


        Catch ex As Exception
            'MessageBox.Show(ex.Message)




        End Try
    End Sub

    Public Sub checktoseeifmarksexists()
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select * from reportcards.marks where class='" + txt_class.Text + "' and year='" + txt_year.Text + "' and term='" + txt_term.Text + "' and subject='" + txt_subject.Text + "';", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()
            Dim count As Integer = 0
            If (myReader.HasRows()) Then
                count = count + 1

            End If


            If (count = 0) Then
                Checkexistingsubjects()
            ElseIf (count = 1) Then
                updatemarks()

            End If


            mycon.Close()


        Catch ex As Exception
            'MessageBox.Show(ex.Message)


        End Try


    End Sub
    Public Sub updatemarks()

        If (txt_subject.Text = "" And txt_level.Text = "") Then
            MessageBox.Show("Subject or level Missing")
        Else
            deletemarks()
            deletemarksgrades()
            Savedata()
            Savedatagrades()


        End If
    End Sub




    Public Sub alevelgradingmid()
        Try


            Dim i2 As Integer
            i2 = DataGridView1.CurrentRow.Index
            ' If (Double.Parse(DataGridView1.Item(0, i2).Value) > 30.0 Or Double.Parse(DataGridView1.Item(1, i2).Value) > 70.0) Then

            'MessageBox.Show("Mid Must be out of 30 and End out of 70")

            ' DataGridView1.Item(0, i2).Value = "-"
            ' DataGridView1.Item(1, i2).Value = "-"

            ' Else

            DataGridView1.Item(2, i2).Value = (Double.Parse(DataGridView1.Item(0, i2).Value))

            If (Double.Parse(DataGridView1.Item(2, i2).Value) >= 80 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 100) Then
                DataGridView1.Item(3, i2).Value = v1
                DataGridView1.Item(4, i2).Value = s1
                DataGridView1.Item(5, i2).Value = r1
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 70 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 79.5) Then
                DataGridView1.Item(3, i2).Value = v2
                DataGridView1.Item(4, i2).Value = s2
                DataGridView1.Item(5, i2).Value = r2
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 65 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 69.5) Then
                DataGridView1.Item(3, i2).Value = v3
                DataGridView1.Item(4, i2).Value = s3
                DataGridView1.Item(5, i2).Value = r3
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 60 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 64.5) Then
                DataGridView1.Item(3, i2).Value = v4
                DataGridView1.Item(4, i2).Value = s4
                DataGridView1.Item(5, i2).Value = r4
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 55 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 59.5) Then
                DataGridView1.Item(3, i2).Value = v5
                DataGridView1.Item(4, i2).Value = s5
                DataGridView1.Item(5, i2).Value = r5
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 50 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 54.5) Then
                DataGridView1.Item(3, i2).Value = v6
                DataGridView1.Item(4, i2).Value = s6
                DataGridView1.Item(5, i2).Value = r6
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 45 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 49.5) Then
                DataGridView1.Item(3, i2).Value = v7
                DataGridView1.Item(4, i2).Value = s7
                DataGridView1.Item(5, i2).Value = r7
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 40 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 44.5) Then
                DataGridView1.Item(3, i2).Value = v8
                DataGridView1.Item(4, i2).Value = s8
                DataGridView1.Item(5, i2).Value = r8
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 0 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 39.5) Then
                DataGridView1.Item(3, i2).Value = v9
                DataGridView1.Item(4, i2).Value = s9
                DataGridView1.Item(5, i2).Value = r9







            ElseIf (DataGridView1.Item(0, i2).Value = 0) Or (DataGridView1.Item(1, i2).Value = 0) Then
                DataGridView1.Item(3, i2).Value = v10
                DataGridView1.Item(4, i2).Value = s10
                DataGridView1.Item(5, i2).Value = r10



            End If
            ' End If
        Catch ex As Exception
            ' 'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub olevelgradingmid()
        Try


            Dim i2 As Integer
            i2 = DataGridView1.CurrentRow.Index

            ' If (Double.Parse(DataGridView1.Item(0, i2).Value) > 30.0) Then

            'MessageBox.Show("Mid Must be out of 30 and End out of 70")

            ' DataGridView1.Item(0, i2).Value = "-"
            'DataGridView1.Item(1, i2).Value = "-"

            ' Else

            DataGridView1.Item(2, i2).Value = (Double.Parse(DataGridView1.Item(0, i2).Value))

            If (Double.Parse(DataGridView1.Item(2, i2).Value) >= 80 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 100) Then
                DataGridView1.Item(3, i2).Value = v1
                DataGridView1.Item(4, i2).Value = s1
                DataGridView1.Item(5, i2).Value = r1
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 70 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 79.5) Then
                DataGridView1.Item(3, i2).Value = v2
                DataGridView1.Item(4, i2).Value = s2
                DataGridView1.Item(5, i2).Value = r2
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 65 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 69.5) Then
                DataGridView1.Item(3, i2).Value = v3
                DataGridView1.Item(4, i2).Value = s3
                DataGridView1.Item(5, i2).Value = r3
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 60 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 64.5) Then
                DataGridView1.Item(3, i2).Value = v4
                DataGridView1.Item(4, i2).Value = s4
                DataGridView1.Item(5, i2).Value = r4
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 55 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 59.5) Then
                DataGridView1.Item(3, i2).Value = v5
                DataGridView1.Item(4, i2).Value = s5
                DataGridView1.Item(5, i2).Value = r5
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 50 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 54.5) Then
                DataGridView1.Item(3, i2).Value = v6
                DataGridView1.Item(4, i2).Value = s6
                DataGridView1.Item(5, i2).Value = r6
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 45 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 49.5) Then
                DataGridView1.Item(3, i2).Value = v7
                DataGridView1.Item(4, i2).Value = s7
                DataGridView1.Item(5, i2).Value = r7
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 40 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 44.5) Then
                DataGridView1.Item(3, i2).Value = v8
                DataGridView1.Item(4, i2).Value = s8
                DataGridView1.Item(5, i2).Value = r8
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 0 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 39.5) Then
                DataGridView1.Item(3, i2).Value = v9
                DataGridView1.Item(4, i2).Value = s9
                DataGridView1.Item(5, i2).Value = r9







            ElseIf (DataGridView1.Item(0, i2).Value = 0) Or (DataGridView1.Item(1, i2).Value = 0) Then
                DataGridView1.Item(3, i2).Value = v10
                DataGridView1.Item(4, i2).Value = s10
                DataGridView1.Item(5, i2).Value = r10



                'End If
            End If
        Catch ex As Exception
            ' 'MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub setdefault()
        Try


            Dim dgval As String = "-"
            Dim dgvalf As String = "X"
            For Each row As DataGridViewRow In DataGridView1.Rows


                row.Cells("MID").Value = dgval

                row.Cells("EOT").Value = dgval

                row.Cells("AVERAGE").Value = dgval
                row.Cells("GRADE").Value = dgval
                row.Cells("AGGREGATE").Value = dgvalf
                row.Cells("REMARK").Value = dgval

            Next


        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
    End Sub
    Public Sub alevelgrading()
        Try


            Dim i2 As Integer
            i2 = DataGridView1.CurrentRow.Index


            DataGridView1.Item(2, i2).Value = (Double.Parse(DataGridView1.Item(0, i2).Value) + Double.Parse(DataGridView1.Item(1, i2).Value)) / 2

            If (Double.Parse(DataGridView1.Item(2, i2).Value) >= 80 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 100) Then
                DataGridView1.Item(3, i2).Value = v1
                DataGridView1.Item(4, i2).Value = s1
                DataGridView1.Item(5, i2).Value = r1
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 70 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 79.5) Then
                DataGridView1.Item(3, i2).Value = v2
                DataGridView1.Item(4, i2).Value = s2
                DataGridView1.Item(5, i2).Value = r2
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 65 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 69.5) Then
                DataGridView1.Item(3, i2).Value = v3
                DataGridView1.Item(4, i2).Value = s3
                DataGridView1.Item(5, i2).Value = r3
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 60 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 64.5) Then
                DataGridView1.Item(3, i2).Value = v4
                DataGridView1.Item(4, i2).Value = s4
                DataGridView1.Item(5, i2).Value = r4
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 55 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 59.5) Then
                DataGridView1.Item(3, i2).Value = v5
                DataGridView1.Item(4, i2).Value = s5
                DataGridView1.Item(5, i2).Value = r5
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 50 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 54.5) Then
                DataGridView1.Item(3, i2).Value = v6
                DataGridView1.Item(4, i2).Value = s6
                DataGridView1.Item(5, i2).Value = r6
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 45 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 49.5) Then
                DataGridView1.Item(3, i2).Value = v7
                DataGridView1.Item(4, i2).Value = s7
                DataGridView1.Item(5, i2).Value = r7
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 40 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 44.5) Then
                DataGridView1.Item(3, i2).Value = v8
                DataGridView1.Item(4, i2).Value = s8
                DataGridView1.Item(5, i2).Value = r8
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 0 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 39.5) Then
                DataGridView1.Item(3, i2).Value = v9
                DataGridView1.Item(4, i2).Value = s9
                DataGridView1.Item(5, i2).Value = r9



            ElseIf (DataGridView1.Item(0, i2).Value = 0) Or (DataGridView1.Item(1, i2).Value = 0) Then
                DataGridView1.Item(3, i2).Value = v10
                DataGridView1.Item(4, i2).Value = s10
                DataGridView1.Item(5, i2).Value = r10




            End If
        Catch ex As Exception
            ' 'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub olevelgrading()
        Try


            Dim i2 As Integer
            i2 = DataGridView1.CurrentRow.Index
            'If (Double.Parse(DataGridView1.Item(0, i2).Value) > 30.0 Or Double.Parse(DataGridView1.Item(1, i2).Value) > 70.0) Then

            'MessageBox.Show("Mid Must be out of 30 and End out of 70")

            ' DataGridView1.Item(0, i2).Value = "-"
            ' DataGridView1.Item(1, i2).Value = "-"

            'Else
            If (DataGridView1.Item(1, i2).Value = "-" Or DataGridView1.Item(0, i2).Value = "-" And DataGridView1.Item(0, i2).Value >= 0) Then

                DataGridView1.Item(2, i2).Value = DataGridView1.Item(0, i2).Value
                DataGridView1.Item(2, i2).Value = (Double.Parse(DataGridView1.Item(0, i2).Value) + Double.Parse(DataGridView1.Item(1, i2).Value)) / 2

            Else

                DataGridView1.Item(2, i2).Value = (Double.Parse(DataGridView1.Item(0, i2).Value) + Double.Parse(DataGridView1.Item(1, i2).Value)) / 2
            End If

            If (Double.Parse(DataGridView1.Item(2, i2).Value) >= 80 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 100) Then
                DataGridView1.Item(3, i2).Value = v1
                DataGridView1.Item(4, i2).Value = s1
                DataGridView1.Item(5, i2).Value = r1
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 70 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 79.5) Then
                DataGridView1.Item(3, i2).Value = v2
                DataGridView1.Item(4, i2).Value = s2
                DataGridView1.Item(5, i2).Value = r2
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 65 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 69.5) Then
                DataGridView1.Item(3, i2).Value = v3
                DataGridView1.Item(4, i2).Value = s3
                DataGridView1.Item(5, i2).Value = r3
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 60 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 64.5) Then
                DataGridView1.Item(3, i2).Value = v4
                DataGridView1.Item(4, i2).Value = s4
                DataGridView1.Item(5, i2).Value = r4
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 55 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 59.5) Then
                DataGridView1.Item(3, i2).Value = v5
                DataGridView1.Item(4, i2).Value = s5
                DataGridView1.Item(5, i2).Value = r5
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 50 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 54.5) Then
                DataGridView1.Item(3, i2).Value = v6
                DataGridView1.Item(4, i2).Value = s6
                DataGridView1.Item(5, i2).Value = r6
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 45 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 49.5) Then
                DataGridView1.Item(3, i2).Value = v7
                DataGridView1.Item(4, i2).Value = s7
                DataGridView1.Item(5, i2).Value = r7
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 40 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 44.5) Then
                DataGridView1.Item(3, i2).Value = v8
                DataGridView1.Item(4, i2).Value = s8
                DataGridView1.Item(5, i2).Value = r8
            ElseIf (Double.Parse(DataGridView1.Item(2, i2).Value) >= 0 And Double.Parse(DataGridView1.Item(2, i2).Value) <= 39.5) Then
                DataGridView1.Item(3, i2).Value = v9
                DataGridView1.Item(4, i2).Value = s9
                DataGridView1.Item(5, i2).Value = r9



            ElseIf (DataGridView1.Item(0, i2).Value = 0) Or (DataGridView1.Item(1, i2).Value = 0) Then
                DataGridView1.Item(3, i2).Value = v10
                DataGridView1.Item(4, i2).Value = s10
                DataGridView1.Item(5, i2).Value = r10


                'End If

            End If
        Catch ex As Exception
            ' 'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Savedata()
        If (txt_subject.Text = "" And txt_level.Text = "") Then
            MessageBox.Show("Subject or level Missing")
        Else




            Try
                Dim i2 As Integer
                i2 = DataGridView1.CurrentRow.Index



                For Each row As DataGridViewRow In DataGridView1.Rows
                    Dim constring As String = "datasource=localhost;port=3306;username=root;"
                    Dim con As New MySqlConnection(constring)
                    Dim cmd As New MySqlCommand("INSERT INTO reportcards.marks(class,Class_Teacher,year,name,subject,term,date,initial,password,mid,end,average,grade,aggregate,remark,entryid) VALUES(@class,@classteacher,@year,@name, @subject, @term, @date, @initial, @password, @mid,@end,@average,@grade,@aggregate,@remark,@entryid)", con)





                    cmd.Parameters.AddWithValue("@class", txt_class.Text)
                    cmd.Parameters.AddWithValue("@classteacher", txt_classteacher.Text)
                    cmd.Parameters.AddWithValue("@year", txt_year.Text)
                    cmd.Parameters.AddWithValue("@name", row.Cells("name").Value)
                    cmd.Parameters.AddWithValue("@subject", txt_subject.Text)
                    cmd.Parameters.AddWithValue("@term", txt_term.Text)
                    cmd.Parameters.AddWithValue("@date", DateTimePicker1.Text)
                    cmd.Parameters.AddWithValue("@initial", txt_initial.Text)
                    cmd.Parameters.AddWithValue("@password", txt_password.Text)

                    cmd.Parameters.AddWithValue("@mid", row.Cells("MID").Value)
                    cmd.Parameters.AddWithValue("@end", row.Cells("EOT").Value)
                    cmd.Parameters.AddWithValue("@average", row.Cells("AVERAGE").Value)

                    cmd.Parameters.AddWithValue("@grade", row.Cells("GRADE").Value)

                    cmd.Parameters.AddWithValue("@aggregate", row.Cells("AGGREGATE").Value)
                    cmd.Parameters.AddWithValue("@remark", row.Cells("REMARK").Value)
                    cmd.Parameters.AddWithValue("@entryid", txt_entryid.Text)

                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()


                Next

                MessageBox.Show("Records Inserted.")





            Catch ex As Exception
                'MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub
    Public Sub Checkexistingsubjects()
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select * from reportcards.marks where subject='" & txt_subject.Text & "' and term='" & txt_term.Text & "' and year='" & txt_year.Text & "' and class='" + txt_class.Text + "';", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()
            Dim count As Integer = 0
            If (myReader.HasRows()) Then
                count = count + 1

            End If

            If (count > 0) Then

                MessageBox.Show("You already uploaded your marks")

            ElseIf (count = 0) Then
                Savedata()

            End If



            mycon.Close()


        Catch ex As Exception
            'MessageBox.Show(ex.Message)


        End Try
    End Sub


    Public Sub getmaxid()

        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select max(id) from reportcards.marks ;", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()

            If (myReader.Read()) Then
                maxid = myReader.GetString("max(id)")
                entryid = "E" & maxid
                txt_entryid.Text = entryid
            End If

            mycon.Close()


        Catch ex As Exception
            'MessageBox.Show(ex.Message)


        End Try

    End Sub
    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean

        Dim key As Keys = keyData And Keys.KeyCode

        If key = Keys.Enter Then
            MyBase.OnKeyDown(New KeyEventArgs(keyData))
            Return True
        Else
            Return MyBase.ProcessDialogKey(keyData)
        End If
    End Function

    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim ri As Integer = DataGridView1.CurrentCell.RowIndex
                Dim ci As Integer = DataGridView1.CurrentCell.ColumnIndex
                e.SuppressKeyPress = True
                FindNextCell(DataGridView1, ri, ci + 1)  'checking from Next  
            End If
        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try

    End Sub

    Sub FindNextCell(ByVal dgv As DataGridView, ByVal rowindex As Integer, ByVal columnindex As Integer)
        Try
            Dim found As Boolean = False

            While dgv.RowCount > rowindex
                While dgv.Columns.Count > columnindex
                    If Not (dgv.Rows(rowindex).Cells(columnindex)).ReadOnly Then
                        dgv.CurrentCell = dgv.Rows(rowindex).Cells(columnindex)
                        Exit Sub
                    Else
                        columnindex += 1
                    End If
                End While
                rowindex += 1
                columnindex = 0
            End While

        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
    End Sub


    Private Sub DataGridView1_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        Try
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            calculateaverage()
        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
        Try
            calculateaverage()
        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
    End Sub

    Public Sub fill_classteachers()
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select * from reportcards.classes where class='" + txt_class.Text + "' ;", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()

            While (myReader.Read())
                Dim classteachers As String = myReader.GetString("Class_Teacher").ToString()


                txt_classteacher.Text = classteachers

            End While

        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try


    End Sub


    Public Sub calculateaverage()

        If (txt_level.Text = "O LEVEL" And txt_report.Text = "MID") Then
            olevelgradingmid()
        ElseIf (txt_level.Text = "O LEVEL" And txt_report.Text = "FULL") Then
            olevelgrading()

        ElseIf (txt_level.Text = "A LEVEL" And txt_report.Text = "MID") Then
            alevelgradingmid()

        ElseIf (txt_level.Text = "A LEVEL" And txt_report.Text = "FULL") Then
            alevelgrading()
        End If




    End Sub
    Public Sub fill_subjects()
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select * from reportcards.teachers where password='" + txt_password.Text + "' ;", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()

            If (myReader.Read()) Then
                Dim subject As String = myReader.GetString("subject").ToString()
                Dim initial As String = myReader.GetString("initial").ToString()
                txt_subject.Text = subject
                txt_initial.Text = initial

            Else
                MessageBox.Show("Re-Enter Password & Try Again")
            End If

        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try


    End Sub

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

            End While

        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try


    End Sub
    Public Sub fill_name()
        Try
            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select name AS NAME from reportcards.students where class='" + txt_class.Text + "' and year='" + txt_year.Text + "' ORDER BY name asc ;", conDatabase)
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
            MessageBox.Show("Please Select Term and Year")


        End Try
    End Sub

    Public Sub fillinitial()
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select initial from reportcards.teachers where subject='" + txt_subject.Text + "' ;", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()

            While (myReader.Read())
                Dim classes As String = myReader.GetString("initial").ToString()


                txt_initial.Text = classes

            End While

        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
    End Sub

    Public Sub FILLSUBJECT()
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select subject from reportcards.subjects ;", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()

            While (myReader.Read())
                Dim classes As String = myReader.GetString("subject").ToString()


                txt_subject.Items.Add(classes)

            End While

        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub RecordMarks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fill_classes()

            FILLSUBJECT()

            getmaxid()

        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try



    End Sub

    Private Sub txt_class_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_class.SelectedIndexChanged
        Try
            fill_name()
            fill_classteachers()
        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
        setdefault()
    End Sub

    Private Sub txt_year_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_year.SelectedIndexChanged
        Try
            fill_name()
        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
        setdefault()
    End Sub

    Private Sub MenuStrip2_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip2.ItemClicked

    End Sub

    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        Try
            fill_subjects()
        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If (txt_subject.Text = "" Or txt_level.Text = "" Or txt_class.Text = "" Or txt_term.Text = "" Or txt_year.Text = "") Then
            MessageBox.Show("Please you must fill the class , term , year , subject and level to continue")
        Else
            checktoseeifmarksexists()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub



    Private Sub DataGridView1_MarginChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.MarginChanged
        Try
            calculateaverage()
        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
    End Sub



    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub OverRollPerformanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OverRollPerformanceToolStripMenuItem.Click
        Try
            If (txt_subject.Text = "" Or txt_level.Text = "" Or txt_class.Text = "" Or txt_term.Text = "" Or txt_year.Text = "") Then
                MessageBox.Show("Please you must fill the class , term , year , subject and level to continue")

            Else

                OverRollPerformance.Show()
            End If
        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub txt_subject_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_subject.SelectedIndexChanged
        fillinitial()
    End Sub

    Private Sub RankStudentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RankStudentsToolStripMenuItem.Click
        Try
            If (txt_subject.Text = "" Or txt_level.Text = "" Or txt_class.Text = "" Or txt_term.Text = "" Or txt_year.Text = "") Then
                MessageBox.Show("Please you must fill the class , term , year , subject and level to continue")
            Else

                RankStudents.Show()
            End If
        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub EditMarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditMarksToolStripMenuItem.Click
        Try
            If (txt_subject.Text = "" Or txt_level.Text = "" Or txt_class.Text = "" Or txt_term.Text = "" Or txt_year.Text = "") Then
                MessageBox.Show("Please you must fill the class , term , year , subject and level to continue")
            Else

                EditMarks.Show()
            End If

        Catch ex As Exception

            'MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub CLASSREPORTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLASSREPORTToolStripMenuItem.Click
        If (txt_subject.Text = "" Or txt_level.Text = "" Or txt_class.Text = "" Or txt_term.Text = "" Or txt_year.Text = "") Then
            MessageBox.Show("Please you must fill the class , term , year , subject and level to continue")
        Else
            ClassReport.Show()
        End If
    End Sub

    Private Sub BestEightAggregatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BestEightAggregatesToolStripMenuItem.Click
        If (txt_subject.Text = "" Or txt_level.Text = "" Or txt_class.Text = "" Or txt_term.Text = "" Or txt_year.Text = "") Then
            MessageBox.Show("Please you must fill the class , term , year , subject and level to continue")
        Else
            Testbest8.Show()
        End If
    End Sub

    Private Sub txt_level_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_level.SelectedIndexChanged
        If (txt_level.Text.Length > 0 And txt_report.Text.Length > 0) Then
            DataGridView1.Enabled = True
        Else

        End If
    End Sub

    Private Sub OlevelClassReportsS3AndS4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OlevelClassReportsS3AndS4ToolStripMenuItem.Click
        If (txt_subject.Text = "" Or txt_level.Text = "" Or txt_class.Text = "" Or txt_term.Text = "" Or txt_year.Text = "") Then
            MessageBox.Show("Please you must fill the class , term , year , subject and level to continue")
        Else
            Generalclassreports3s4.Show()
        End If
    End Sub

    Private Sub AlevelClassReportsArtsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (txt_subject.Text = "" Or txt_level.Text = "" Or txt_class.Text = "" Or txt_term.Text = "" Or txt_year.Text = "") Then
            MessageBox.Show("Please you must fill the class , term , year , subject and level to continue")
        Else


        End If
    End Sub

    Private Sub ALevelClassReportsSciencesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (txt_subject.Text = "" Or txt_level.Text = "" Or txt_class.Text = "" Or txt_term.Text = "" Or txt_year.Text = "") Then
            MessageBox.Show("Please you must fill the class , term , year , subject and level to continue")
        Else


        End If
    End Sub

    Private Sub GenerateTotalPointsForEachStudentByClassTermAndYearEssentialForS5AndS6ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (txt_subject.Text = "" Or txt_level.Text = "" Or txt_class.Text = "" Or txt_term.Text = "" Or txt_year.Text = "") Then
            MessageBox.Show("Please you must fill the class , term , year , subject and level to continue")
        Else
            AlevelTotalpoints.Show()

        End If
    End Sub

    Private Sub CLASSLISTSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub txt_password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_password.TextChanged
        If (txt_password.Text = "one17") Then
            txt_class.Text = "S1"
        ElseIf (txt_password.Text = "two17") Then
            txt_class.Text = "S2"
        ElseIf (txt_password.Text = "three17") Then
            txt_class.Text = "S3"
        ElseIf (txt_password.Text = "four17") Then
            txt_class.Text = "S4"
        ElseIf (txt_password.Text = "five17") Then
            txt_class.Text = "S5"
        ElseIf (txt_password.Text = "six17") Then
            txt_class.Text = "S5"
        End If
    End Sub

    Private Sub txt_report_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_report.SelectedIndexChanged
        If (txt_level.Text.Length > 0 And txt_report.Text.Length > 0) Then
            DataGridView1.Enabled = True
        Else

        End If
    End Sub

    Private Sub FecthMarksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FecthMarksToolStripMenuItem.Click
        If (txt_subject.Text = "" Or txt_level.Text = "" Or txt_class.Text = "" Or txt_term.Text = "" Or txt_year.Text = "") Then
            MessageBox.Show("Please you must fill the class , term , year , subject and level to continue")
        Else
            DataGridView1.Columns.Clear()
            fetchexistingmarks()
        End If
    End Sub

    Private Sub ClassListsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClassListsToolStripMenuItem.Click
        If (txt_subject.Text = "" Or txt_level.Text = "" Or txt_class.Text = "" Or txt_term.Text = "" Or txt_year.Text = "") Then
            MessageBox.Show("Please you must fill the class , term , year , subject and level to continue")
        Else

        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        SINGLECLASSREPORTS1S2.Show()
    End Sub

    Private Sub SINGLESTUDENTSREPORTS3ANDS4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SINGLESTUDENTSREPORTS3ANDS4ToolStripMenuItem.Click
        SINGLECLASSREPORTS3S4.Show()
    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add(MID)
        DataGridView1.Columns.Add(EOT)
        DataGridView1.Columns.Add(AVERAGE)
        DataGridView1.Columns.Add(GRADE)
        DataGridView1.Columns.Add(AGGREGATE)
        DataGridView1.Columns.Add(REMARK)
        fill_name()
        setdefault()



    End Sub

    Private Sub S1ANDS2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S1ANDS2ToolStripMenuItem.Click
        marksheets1s2.Show()
    End Sub

    Private Sub S3ANDS4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S3ANDS4ToolStripMenuItem.Click
        marksheets3s4.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Aa As String

        Aa = MsgBox("are you sure u want to add on this student?", vbYesNo, "Question")

        If Aa = vbYes Then
            Try

                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
                Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT  MID,END AS EOT ,AVERAGE,GRADE,AGGREGATE,REMARK,NAME  FROM reportcards.marks where name in (SELECT distinct name from reportcards.marks) and class='" + txt_class.Text + "' and year='" + txt_year.Text + "' and term='" + txt_term.Text + "' and subject='" + txt_subject.Text + "' GROUP BY name ;", conDatabase)
                Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
                sda.SelectCommand = cmdDatabase
                Dim dbDataset As DataTable = New DataTable()

                DataGridView1.DataSource = dbDataset

                'add row
                dbDataset.Rows.Add()



                sda.Fill(dbDataset)
                Dim bSource As BindingSource = New BindingSource()
                bSource.DataSource = dbDataset
                DataGridView1.DataSource = bSource
                sda.Update(dbDataset)
                conDatabase.Close()




            Catch ex As Exception

                'MessageBox.Show(ex.Message)

            End Try
        End If


    End Sub

    Private Sub S1ANDS2ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S1ANDS2ToolStripMenuItem1.Click
        GENERALMARKSHEETS1ANDS2.Show()
    End Sub

    Private Sub S3ANDS4ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S3ANDS4ToolStripMenuItem1.Click
        GENERALMAEKSHEETS3ANDS4.Show()
    End Sub

    Private Sub ANALYSISToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        analysis.Show()
    End Sub
End Class