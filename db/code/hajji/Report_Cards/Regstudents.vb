Imports MySql.Data.MySqlClient.MySqlDbType
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.DBNull
Public Class Regstudents



    'image
    Dim myReader As MySqlDataReader
    Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
    Dim con As MySqlConnection = New MySqlConnection(myConnection)
    Dim count As Integer
    Dim cmd As MySqlCommand
    Dim PicutureBox1 As PictureBox
    Public Sub suppressduplicatenames()
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select * from reportcards.students where name='" & txt_name.Text & "' and class='" & txt_class.Text & "' and year='" & txt_year.Text & "';", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()
            Dim count As Integer = 0
            If (myReader.HasRows()) Then
                count = count + 1

            End If

            If (count < 1) Then
                savedata()
            ElseIf (count = 1) Then
                MessageBox.Show("Student Exists , add an identifier")
            End If

           
            mycon.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)


        End Try
    End Sub
    Public Sub savedata()
        Dim Aa As String

        Aa = MsgBox("are you sure u want to save?", vbYesNo, "Question")

        If Aa = vbYes Then

            If (txt_name.Text.Length > 0 And txt_year.Text.Length > 0 And txt_class.Text.Length > 0) Then

                Try




                    Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
                    Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
                    Dim SelectCommand As MySqlCommand = New MySqlCommand("insert into reportcards.students(name,class,year,combination) values('" & txt_name.Text & "','" + txt_class.Text + "','" + txt_year.Text + "','" + txt_combination.Text + "') ", mycon)
                    Dim myReader As MySqlDataReader

                    mycon.Open()

                    myReader = SelectCommand.ExecuteReader()
                    MessageBox.Show("Data has been saved")
                    ' Savephoto()
                    fill_data_grid()


                    txt_name.Text = ""
                    txt_id.Text = ""
                    ' txt_class.Text = ""
                    ' txt_year.Text = ""
                    txt_combination.Text = ""
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
    Public Sub fillcombination()
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select distinct(combination) from reportcards.students  ;", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()

            While (myReader.Read())
                Dim combination As String = myReader.GetString("combination").ToString()
                txt_combination.Items.Add(combination)

            End While

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Public Sub getDatacombination(ByVal dataCollection As AutoCompleteStringCollection)

        Dim connetionString As String = Nothing
        Dim connection As MySqlConnection
        Dim command As MySqlCommand
        Dim adapter As New MySqlDataAdapter()
        Dim ds As New DataSet()
        connetionString = "datasource=localhost;port=3306;username=root;"
        Dim sql As String = "Select distinct(combination) from reportcards.students"
        connection = New MySqlConnection(connetionString)
        Try
            connection.Open()
            command = New MySqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()


        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
        End Try
    End Sub
    Public Sub updateimage()

        Try
            If txt_name.Text = "" Then
                MsgBox("Fill student`s Name ")
            Else
                Dim cmd As New MySqlCommand("update reportcards.photo set name=@name,image=@photo where name=@name", con)
                cmd.Parameters.AddWithValue("@name", txt_name.Text)
                Dim ms As New MemoryStream()
                PictureBox1.BackgroundImage.Save(ms, PictureBox1.BackgroundImage.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New MySqlParameter("@photo", MySqlDbType.Blob)
                p.Value = data
                cmd.Parameters.Add(p)
                con.Open()

                cmd.ExecuteNonQuery()

                MessageBox.Show("Updated", "photo", MessageBoxButtons.OK)


                PictureBox1.Image = Nothing
                con.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)




        End Try
    End Sub

    Public Sub deletephoto()

        Try
            If txt_name.Text = "" Then
                MsgBox("Fill student`s name")
            Else
                Dim cmd As New MySqlCommand("delete from reportcards.photo where name=@name", con)
                cmd.Parameters.AddWithValue("@name", txt_name.Text)

                con.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("Image", "deleted", MessageBoxButtons.OK)


                PictureBox1.Image = Nothing
                con.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)




        End Try
    End Sub
    Public Sub Savephoto()
        Try
            If txt_name.Text = "" Then
                MsgBox("Fill students`s name")
            Else
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.photo(name,image) VALUES(@name,@photo)", con)
                cmd.Parameters.AddWithValue("@name", txt_name.Text)
                Dim ms As New MemoryStream()
                PictureBox1.BackgroundImage.Save(ms, PictureBox1.BackgroundImage.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New MySqlParameter("@photo", MySqlDbType.Blob)
                p.Value = data
                cmd.Parameters.Add(p)
                con.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("Name & Image has been saved", "Save", MessageBoxButtons.OK)


                PictureBox1.Image = Nothing


                con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)




        End Try
    End Sub
    Public Sub fill_image()

        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim adptr As MySqlDataAdapter = New MySqlDataAdapter("select image from reportcards.photo where name= '" & txt_name.Text & "'", mycon)
            Dim cmd As MySqlCommandBuilder = New MySqlCommandBuilder
            Dim dt As DataTable = New DataTable
            adptr.Fill(dt)
            Dim lb() As Byte = dt.Rows(0).Item("image")
            Dim lstr As New System.IO.MemoryStream(lb)
            PictureBox1.Image = Image.FromStream(lstr)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            lstr.Close()


        Catch ex As Exception

        End Try


    End Sub
    'image







    Public Sub fill_names()
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select * from reportcards.students ;", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()

            While (myReader.Read())
                Dim name As String = myReader.GetString("name").ToString()
                txt_name.Items.Add(name)

            End While

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try


    End Sub
    Public Sub autofillgrid()
        Try
            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select * from reportcards.students where name='" + txt_name.Text + "' ;", conDatabase)
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

            MessageBox.Show(ex.Message)

        End Try

    End Sub
    Private Sub getData(ByVal dataCollection As AutoCompleteStringCollection)

        Dim connetionString As String = Nothing
        Dim connection As MySqlConnection
        Dim command As MySqlCommand
        Dim adapter As New MySqlDataAdapter()
        Dim ds As New DataSet()
        connetionString = "datasource=localhost;port=3306;username=root;"
        Dim sql As String = "Select distinct(name) from reportcards.students"
        connection = New MySqlConnection(connetionString)
        Try
            connection.Open()
            command = New MySqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            For Each row As DataRow In ds.Tables(0).Rows
                dataCollection.Add(row(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
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

            MessageBox.Show(ex.Message)

        End Try


    End Sub
    Public Sub fill_data_grid()
        Try
            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select * from reportcards.students ;", conDatabase)
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

            MessageBox.Show(ex.Message)

        End Try


    End Sub
    Private Sub Regstudents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fill_classes()
            fill_data_grid()
            fill_names()

            txt_name.AutoCompleteMode = AutoCompleteMode.Suggest
            txt_name.AutoCompleteSource = AutoCompleteSource.CustomSource
            Dim combData As New AutoCompleteStringCollection()
            getData(combData)
            txt_name.AutoCompleteCustomSource = combData


            fillcombination()

            txt_combination.AutoCompleteMode = AutoCompleteMode.Suggest
            txt_combination.AutoCompleteSource = AutoCompleteSource.CustomSource
            Dim combDatacombination As New AutoCompleteStringCollection()
            getDatacombination(combDatacombination)
            txt_combination.AutoCompleteCustomSource = combDatacombination



        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try

        
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        Me.txt_id.Text = DataGridView1.Item(0, i).Value
        Me.txt_name.Text = DataGridView1.Item(1, i).Value
        Me.txt_class.Text = DataGridView1.Item(2, i).Value
        Me.txt_year.Text = DataGridView1.Item(3, i).Value
            Me.txt_combination.Text = DataGridView1.Item(4, i).Value
            fill_image()
        Catch ex As Exception



        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        suppressduplicatenames()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        Dim Aa As String

        Aa = MsgBox("are you sure u want to update?", vbYesNo, "Question")

        If Aa = vbYes Then

            If (txt_name.Text.Length > 0 And txt_year.Text.Length > 0 And txt_class.Text.Length > 0) Then

                Try




                    Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
                    Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
                    Dim SelectCommand As MySqlCommand = New MySqlCommand("update reportcards.students set name='" & txt_name.Text & "',class='" + txt_class.Text + "',year='" + txt_year.Text + "',combination='" + txt_combination.Text + "' where id='" + txt_id.Text + "' ", mycon)
                    Dim myReader As MySqlDataReader

                    mycon.Open()

                    myReader = SelectCommand.ExecuteReader()
                    MessageBox.Show("Data has been updated")
                    updateimage()
                    fill_data_grid()


                    txt_name.Text = ""
                    txt_id.Text = ""
                    txt_class.Text = ""
                    txt_year.Text = ""
                    txt_combination.Text = ""
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

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim Aa As String

        Aa = MsgBox("are you sure u want to delete?", vbYesNo, "Question")

        If Aa = vbYes Then

            If (txt_name.Text.Length > 0 And txt_year.Text.Length > 0 And txt_class.Text.Length > 0) Then

                Try




                    Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
                    Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
                    Dim SelectCommand As MySqlCommand = New MySqlCommand("delete from reportcards.students  where id='" + txt_id.Text + "' ", mycon)
                    Dim myReader As MySqlDataReader

                    mycon.Open()

                    myReader = SelectCommand.ExecuteReader()
                    MessageBox.Show("Data has been deleted")
                    deletephoto()
                    fill_data_grid()


                    txt_name.Text = ""
                    txt_id.Text = ""
                    txt_class.Text = ""
                    txt_year.Text = ""
                    txt_combination.Text = ""
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

    Private Sub PromoteStudentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PromoteStudentsToolStripMenuItem.Click
        Me.Close()
        Promotestudents.Show()
    End Sub

    Private Sub txt_name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            fill_data_grid()
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub txt_name_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_name.SelectedIndexChanged
        autofillgrid()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            PictureBox1.Image.Dispose()
            PictureBox1.Image = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txt_combination_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_combination.SelectedIndexChanged

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        importexcel.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select * from reportcards.students WHERE YEAR='""' ;", conDatabase)
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

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub txt_class_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_class.SelectedIndexChanged
        Try
            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select * from reportcards.students where class='" + txt_class.Text + "' ;", conDatabase)
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

            MessageBox.Show(ex.Message)

        End Try
    End Sub
End Class