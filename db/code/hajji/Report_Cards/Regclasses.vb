Imports MySql.Data.MySqlClient.MySqlDbType
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.DBNull
Public Class Regclasses


    'image
    Dim myReader As MySqlDataReader
    Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
    Dim con As MySqlConnection = New MySqlConnection(myConnection)
    Dim count As Integer
    Dim cmd As MySqlCommand
    Dim PicutureBox1 As PictureBox
    Public Sub updateimage()

        Try
            If txt_classteacher.Text = "" Then
                MsgBox("Fill teacher`s Name ")
            Else
                Dim cmd As New MySqlCommand("update reportcards.signature set name=@name,image=@photo,class=@class where name=@name", con)
                cmd.Parameters.AddWithValue("@name", txt_classteacher.Text)
                cmd.Parameters.AddWithValue("@class", txt_class.Text)
                Dim ms As New MemoryStream()
                PictureBox1.BackgroundImage.Save(ms, PictureBox1.BackgroundImage.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New MySqlParameter("@photo", MySqlDbType.Blob)
                p.Value = data
                cmd.Parameters.Add(p)
                con.Open()

                cmd.ExecuteNonQuery()

                MessageBox.Show("Updated", "signiture", MessageBoxButtons.OK)


                PictureBox1.Image = Nothing
                con.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)




        End Try
    End Sub

    Public Sub deletephoto()

        Try
            If txt_classteacher.Text = "" Then
                MsgBox("Fil teachers`s name")
            Else
                Dim cmd As New MySqlCommand("delete from reportcards.signature where name=@name", con)
                cmd.Parameters.AddWithValue("@name", txt_classteacher.Text)

                con.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("signiture", "deleted", MessageBoxButtons.OK)


                PictureBox1.Image = Nothing
                con.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)




        End Try
    End Sub
    Public Sub Savephoto()
        Try
            If txt_classteacher.Text = "" Then
                MsgBox("Fill teachers`s name")
            Else
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.signature(name,image,class) VALUES(@name,@photo,@class)", con)
                cmd.Parameters.AddWithValue("@name", txt_classteacher.Text)
                cmd.Parameters.AddWithValue("@class", txt_class.Text)
                Dim ms As New MemoryStream()
                PictureBox1.BackgroundImage.Save(ms, PictureBox1.BackgroundImage.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New MySqlParameter("@photo", MySqlDbType.Blob)
                p.Value = data
                cmd.Parameters.Add(p)
                con.Open()
                cmd.ExecuteNonQuery()

                MessageBox.Show("Name & signiture has been saved", "Save", MessageBoxButtons.OK)


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
            Dim adptr As MySqlDataAdapter = New MySqlDataAdapter("select image from reportcards.signature where name= '" & txt_classteacher.Text & "'", mycon)
            Dim cmd As MySqlCommandBuilder = New MySqlCommandBuilder
            Dim dt As DataTable = New DataTable
            adptr.Fill(dt)
            Dim lb() As Byte = dt.Rows(0).Item("image")
            Dim lstr As New System.IO.MemoryStream(lb)
            PictureBox1.Image = Image.FromStream(lstr)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            lstr.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    'image


    Public Sub fill_data_grid()
        Try
            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select * from reportcards.classes ;", conDatabase)
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
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim Aa As String

        Aa = MsgBox("are you sure u want to save?", vbYesNo, "Question")

        If Aa = vbYes Then

            If (txt_class.Text.Length > 0) Then

                Try




                    Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
                    Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
                    Dim SelectCommand As MySqlCommand = New MySqlCommand("insert into reportcards.classes(class,term,year,Class_Teacher,class_total) values('" & txt_class.Text & "','" & txt_term.Text & "','" & txt_year.Text & "','" + txt_classteacher.Text + "','" + txt_classtotal.Text + "') ", mycon)
                    Dim myReader As MySqlDataReader

                    mycon.Open()

                    myReader = SelectCommand.ExecuteReader()
                    MessageBox.Show("Data has been saved")
                    Savephoto()
                    fill_data_grid()


                    txt_class.Text = ""
                    txt_id.Text = ""
                    txt_classteacher.Text = ""
                    txt_classtotal.Text = ""
                    txt_term.Text = ""
                    txt_year.Text = ""
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


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        Me.txt_id.Text = DataGridView1.Item(0, i).Value
        Me.txt_class.Text = DataGridView1.Item(1, i).Value
        Me.txt_term.Text = DataGridView1.Item(2, i).Value
        Me.txt_year.Text = DataGridView1.Item(3, i).Value
        Me.txt_classteacher.Text = DataGridView1.Item(4, i).Value
        Me.txt_classtotal.Text = DataGridView1.Item(5, i).Value
        fill_image()
    End Sub

    Private Sub Regclasses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fill_data_grid()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        Dim Aa As String

        Aa = MsgBox("are you sure u want to update?", vbYesNo, "Question")

        If Aa = vbYes Then

            If (txt_class.Text.Length > 0) Then

                Try




                    Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
                    Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
                    Dim SelectCommand As MySqlCommand = New MySqlCommand("update reportcards.classes set class='" & txt_class.Text & "',Class_Teacher='" + txt_classteacher.Text + "',class_total='" + txt_classtotal.Text + "',year='" + txt_year.Text + "',term='" + txt_term.Text + "' where id='" + txt_id.Text + "' ", mycon)
                    Dim myReader As MySqlDataReader

                    mycon.Open()

                    myReader = SelectCommand.ExecuteReader()
                    MessageBox.Show("Data has been updated")
                    updateimage()

                    fill_data_grid()


                    txt_class.Text = ""
                    txt_id.Text = ""
                    txt_classteacher.Text = ""
                    txt_classtotal.Text = ""
                    txt_term.Text = ""
                    txt_year.Text = ""
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

            If (txt_class.Text.Length > 0) Then

                Try




                    Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
                    Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
                    Dim SelectCommand As MySqlCommand = New MySqlCommand("delete from reportcards.classes where id='" + txt_id.Text + "' ", mycon)
                    Dim myReader As MySqlDataReader

                    mycon.Open()

                    myReader = SelectCommand.ExecuteReader()
                    MessageBox.Show("Data has been deleted")
                    deletephoto()
                    fill_data_grid()


                    txt_class.Text = ""
                    txt_id.Text = ""
                    txt_classtotal.Text = ""
                    txt_classteacher.Text = ""
                    txt_term.Text = ""
                    txt_year.Text = ""
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            fill_data_grid()
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            PictureBox1.Image.Dispose()
            PictureBox1.Image = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
End Class