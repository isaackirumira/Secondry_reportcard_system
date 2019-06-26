Imports MySql.Data.MySqlClient
Public Class EditMarks
    Dim WithEvents txt1 As TextBox
    ''' olevel grading
    Dim v1 As String = "D1"
    Dim s1 As String = "1"
    Dim r1 As String = "Excellent"
    Dim v2 As String = "D2"
    Dim s2 As String = "2"
    Dim r2 As String = "Very Good"
    Dim v3 As String = "C3"
    Dim s3 As String = "3"
    Dim r3 As String = "Good"
    Dim v4 As String = "C4"
    Dim s4 As String = "4"
    Dim r4 As String = "Fair Good"
    Dim v5 As String = "C5"
    Dim s5 As String = "5"
    Dim r5 As String = "Fair"
    Dim v6 As String = "C6"
    Dim s6 As String = "6"
    Dim r6 As String = "Improve"
    Dim v7 As String = "P7"
    Dim s7 As String = "7"
    Dim r7 As String = "More Effort"
    Dim v8 As String = "P8"
    Dim s8 As String = "8"
    Dim r8 As String = "More Effort"
    Dim v9 As String = "F9"
    Dim s9 As String = "9"
    Dim r9 As String = "Pull Up"
    ''' olevel grading ends
    ''' alevel grading
    Dim a1 As String = "A"
    Dim b1 As String = "6"
    Dim c1 As String = "Excellent"
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

    Dim m1 As String
    Dim m2 As String
    Dim m3 As String
    Dim m4 As String
    Dim m5 As String
    Dim m6 As String

    Public Sub alevelgrading()
        Try


            Dim i2 As Integer
            i2 = DataGridView1.CurrentRow.Index


            DataGridView1.Item(3, i2).Value = (Double.Parse(DataGridView1.Item(1, i2).Value) + Double.Parse(DataGridView1.Item(2, i2).Value)) / 2

            If (Double.Parse(DataGridView1.Item(3, i2).Value) >= 90 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 100) Then
                DataGridView1.Item(4, i2).Value = a1
                DataGridView1.Item(5, i2).Value = b1
                DataGridView1.Item(6, i2).Value = c1
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 80 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 89.5) Then
                DataGridView1.Item(4, i2).Value = a2
                DataGridView1.Item(5, i2).Value = b2
                DataGridView1.Item(6, i2).Value = c2
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 70 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 79.5) Then
                DataGridView1.Item(4, i2).Value = a3
                DataGridView1.Item(5, i2).Value = b3
                DataGridView1.Item(6, i2).Value = c3
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 60 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 69.5) Then
                DataGridView1.Item(4, i2).Value = a4
                DataGridView1.Item(5, i2).Value = b4
                DataGridView1.Item(6, i2).Value = c4
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 55 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 59.5) Then
                DataGridView1.Item(4, i2).Value = a5
                DataGridView1.Item(5, i2).Value = b5
                DataGridView1.Item(6, i2).Value = c5
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 50 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 54.5) Then
                DataGridView1.Item(4, i2).Value = a6
                DataGridView1.Item(5, i2).Value = b6
                DataGridView1.Item(6, i2).Value = c6
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 45 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 49.5) Then
                DataGridView1.Item(4, i2).Value = a7
                DataGridView1.Item(5, i2).Value = b7
                DataGridView1.Item(6, i2).Value = c7

            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 40 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 44.5) Then
                DataGridView1.Item(4, i2).Value = a7
                DataGridView1.Item(5, i2).Value = b7
                DataGridView1.Item(6, i2).Value = c7
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 0 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 39.5) Then
                DataGridView1.Item(4, i2).Value = a7
                DataGridView1.Item(5, i2).Value = b7
                DataGridView1.Item(6, i2).Value = c7


            ElseIf (DataGridView1.Item(1, i2).Value = 0) Or (DataGridView1.Item(2, i2).Value = 0) Then
                DataGridView1.Item(4, i2).Value = v10
                DataGridView1.Item(5, i2).Value = s10
                DataGridView1.Item(6, i2).Value = r10




            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub olevelgrading()
        Try


            Dim i2 As Integer
            i2 = DataGridView1.CurrentRow.Index


            DataGridView1.Item(3, i2).Value = (Double.Parse(DataGridView1.Item(1, i2).Value) + Double.Parse(DataGridView1.Item(2, i2).Value)) / 2

            If (Double.Parse(DataGridView1.Item(3, i2).Value) >= 90 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 100) Then
                DataGridView1.Item(4, i2).Value = v1
                DataGridView1.Item(5, i2).Value = s1
                DataGridView1.Item(6, i2).Value = r1
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 80 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 89.5) Then
                DataGridView1.Item(4, i2).Value = v2
                DataGridView1.Item(5, i2).Value = s2
                DataGridView1.Item(6, i2).Value = r2
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 70 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 79.5) Then
                DataGridView1.Item(4, i2).Value = v3
                DataGridView1.Item(5, i2).Value = s3
                DataGridView1.Item(6, i2).Value = r3
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 60 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 69.5) Then
                DataGridView1.Item(4, i2).Value = v4
                DataGridView1.Item(5, i2).Value = s4
                DataGridView1.Item(6, i2).Value = r4
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 55 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 59.5) Then
                DataGridView1.Item(4, i2).Value = v5
                DataGridView1.Item(5, i2).Value = s5
                DataGridView1.Item(6, i2).Value = r5
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 50 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 54.5) Then
                DataGridView1.Item(4, i2).Value = v6
                DataGridView1.Item(5, i2).Value = s6
                DataGridView1.Item(6, i2).Value = r6
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 45 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 49.5) Then
                DataGridView1.Item(4, i2).Value = v7
                DataGridView1.Item(5, i2).Value = s7
                DataGridView1.Item(6, i2).Value = r7
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 40 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 44.5) Then
                DataGridView1.Item(4, i2).Value = v8
                DataGridView1.Item(5, i2).Value = s8
                DataGridView1.Item(6, i2).Value = r8
            ElseIf (Double.Parse(DataGridView1.Item(3, i2).Value) >= 0 And Double.Parse(DataGridView1.Item(3, i2).Value) <= 39.5) Then
                DataGridView1.Item(4, i2).Value = v9
                DataGridView1.Item(5, i2).Value = s9
                DataGridView1.Item(6, i2).Value = r9



            ElseIf (DataGridView1.Item(1, i2).Value = 0) Or (DataGridView1.Item(2, i2).Value = 0) Then
                DataGridView1.Item(4, i2).Value = v10
                DataGridView1.Item(5, i2).Value = s10
                DataGridView1.Item(6, i2).Value = r10




            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try
    End Sub


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
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select name,mid,end,average,grade,aggregate,remark,id from reportcards.marks where name='" + txt_name.Text + "' and subject='" + RecordMarks.txt_subject.Text + "' ;", conDatabase)
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
        If e.KeyCode = Keys.Enter Then
            Dim ri As Integer = DataGridView1.CurrentCell.RowIndex
            Dim ci As Integer = DataGridView1.CurrentCell.ColumnIndex
            e.SuppressKeyPress = True
            FindNextCell(DataGridView1, ri, ci + 1)  'checking from Next  
        End If
    End Sub

    Sub FindNextCell(ByVal dgv As DataGridView, ByVal rowindex As Integer, ByVal columnindex As Integer)
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
    End Sub
  
    Public Sub calculateaverage()

        If (RecordMarks.txt_level.Text = "O LEVEL") Then
            olevelgrading()

        ElseIf (RecordMarks.txt_level.Text = "A LEVEL") Then
            ' alevelgrading()
            olevelgrading()
        End If




    End Sub

    Public Sub fill_grid2()


        Try


            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select name,mid,end,average,grade,aggregate,remark,id from reportcards.marks where subject='" + RecordMarks.txt_subject.Text + "' and class='" + RecordMarks.txt_class.Text + "' and year='" + RecordMarks.txt_year.Text + "';", conDatabase)
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
            ' MessageBox.Show("Fill password , class and year to search records")


        End Try

    End Sub

    Private Sub EditMarks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fill_names()
        txt_name.AutoCompleteMode = AutoCompleteMode.Suggest
        txt_name.AutoCompleteSource = AutoCompleteSource.CustomSource
        Dim combData As New AutoCompleteStringCollection()
        getData(combData)
        txt_name.AutoCompleteCustomSource = combData
        fill_grid2()
    End Sub

 
    Private Sub DataGridView1_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        calculateaverage()
    End Sub

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
      
        calculateaverage()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        Dim Aa As String

        Aa = MsgBox("are you sure u want to update?", vbYesNo, "Question")

        If Aa = vbYes Then



            Try

                Dim i2 As Integer
                i2 = DataGridView1.CurrentRow.Index
                m1 = DataGridView1.Item(1, i2).Value
                m2 = DataGridView1.Item(2, i2).Value
                m3 = DataGridView1.Item(3, i2).Value
                m4 = DataGridView1.Item(4, i2).Value
                m5 = DataGridView1.Item(5, i2).Value
                m6 = DataGridView1.Item(6, i2).Value


                Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
                Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
                Dim SelectCommand As MySqlCommand = New MySqlCommand("update reportcards.marks set mid='" + m1 + "',end='" + m2 + "',average='" + m3 + "',grade='" + m4 + "',aggregate='" + m5 + "',remark='" + m6 + "'  where id='" + txt_entryid.Text + "' ", mycon)
                Dim myReader As MySqlDataReader

                mycon.Open()

                myReader = SelectCommand.ExecuteReader()
                MessageBox.Show("Data has been updated")

                fill_grid2()


                mycon.Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message)




            End Try
        Else
            MessageBox.Show("Update terminated")
        End If



    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim Aa As String

        Aa = MsgBox("are you sure u want to delete?", vbYesNo, "Question")

        If Aa = vbYes Then



            Try




                Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
                Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
                Dim SelectCommand As MySqlCommand = New MySqlCommand("delete from reportcards.marks  where id='" + txt_entryid.Text + "' ", mycon)
                Dim myReader As MySqlDataReader

                mycon.Open()

                myReader = SelectCommand.ExecuteReader()
                MessageBox.Show("Data has been deleted")

                fill_grid2()


                mycon.Close()


            Catch ex As Exception
                MessageBox.Show(ex.Message)




            End Try
        Else
            MessageBox.Show("Delete terminated")
        End If







    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        Me.txt_entryid.Text = DataGridView1.Item(7, i).Value
        
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_name.SelectedIndexChanged
        autofillgrid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try


            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select name,mid,end,average,grade,aggregate,remark,id from reportcards.marks where subject='" + RecordMarks.txt_subject.Text + "' and class='" + RecordMarks.txt_class.Text + "' and year='" + RecordMarks.txt_year.Text + "';", conDatabase)
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
            ' MessageBox.Show("Fill password , class and year to search records")


        End Try
    End Sub
End Class