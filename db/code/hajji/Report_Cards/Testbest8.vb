Imports MySql.Data.MySqlClient
Public Class Testbest8
    Dim Div1 As String = "ONE"
    Dim Div2 As String = "TWO"
    Dim Div3 As String = "THREE"
    Dim Div4 As String = "FOUR"
    Dim DivU As String = "U"
    Dim subjectEng = "English"
    Dim subjectMath = "MATHEMATICS"
    Dim subjectPhysics = "PHYSICS"
    Dim subjectChemistry = "CHEMISTRY"
    Dim subjectBiology = "BIOLOGY"
    Public Sub fillcount()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT count(aggregate) as Subjects  FROM reportcards.marks WHERE term = '" + RecordMarks.txt_term.Text + "' AND year = '" + RecordMarks.txt_year.Text + "' and class='" + RecordMarks.txt_class.Text + "' AND AGGREGATE BETWEEN 1 AND 9 GROUP BY NAME  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView7.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub

    Public Sub selectbiology()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT aggregate as Biology from reportcards.grades WHERE subject='" + subjectBiology + "' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView6.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub

    Public Sub selectchemistry()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT aggregate as Chemistry from reportcards.grades WHERE subject='" + subjectChemistry + "' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView5.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub

    Public Sub selectphysics()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT aggregate as Physics from reportcards.grades WHERE subject='" + subjectPhysics + "' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView4.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub selectmath()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT aggregate as Math from reportcards.marks WHERE subject='" + subjectMath + "' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView3.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub selecteng()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT aggregate as English from reportcards.marks WHERE subject='" + subjectEng + "' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView2.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub

    Public Sub updatediv()
        Try
            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.best8(DIVI,Name,Class,Term,Year,Best_Eight_AGGREGATES) VALUES(@DIV,@name,@class,@term,@year, @best8)", con)

                cmd.Parameters.AddWithValue("@DIV", row.Cells("DV").Value)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)
                cmd.Parameters.AddWithValue("@best8", row.Cells("Best_Eight").Value)


                con.Open()
                cmd.ExecuteNonQuery()

                con.Close()

            Next
            MessageBox.Show("Best 8 Ranks Generated And Save To Database.")





        Catch ex As Exception

        End Try
    End Sub
    
    Public Sub setfinaldivisions()
        Try



            Dim i2 As Integer
            i2 = DataGridView1.CurrentRow.Index




            If ((DataGridView1.Item(5, i2).Value) > 60 And (DataGridView1.Item(5, i2).Value) <= 72 And DataGridView7.Item(0, i2).Value >= 8) Then

                DataGridView1.Item(0, i2).Value = DivU
                automovecusor()
            End If


            If ((DataGridView1.Item(5, i2).Value) > 54 And (DataGridView1.Item(5, i2).Value) <= 60 And DataGridView7.Item(0, i2).Value >= 8) Then

                DataGridView1.Item(0, i2).Value = Div4
                automovecusor()

            End If



            If (DataGridView2.Item(0, i2).Value = "X") Then

                DataGridView1.Item(0, i2).Value = "X"
                automovecusor()
            End If


            If (DataGridView3.Item(0, i2).Value = "X") Then

                DataGridView1.Item(0, i2).Value = "X"
                automovecusor()
            End If

            If (DataGridView7.Item(0, i2).Value < 8) Then

                DataGridView1.Item(0, i2).Value = "X"
                automovecusor()
            End If

           







            If ((DataGridView1.Item(5, i2).Value) >= 8 And (DataGridView1.Item(5, i2).Value) <= 32 And (DataGridView2.Item(0, i2).Value < 9 And DataGridView3.Item(0, i2).Value < 9) And DataGridView7.Item(0, i2).Value >= 8) Then

                DataGridView1.Item(0, i2).Value = Div1
                automovecusor()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ElseIf ((DataGridView1.Item(5, i2).Value) >= 8 And (DataGridView1.Item(5, i2).Value) <= 32 And (DataGridView2.Item(0, i2).Value = 9 Or DataGridView3.Item(0, i2).Value = 9) And DataGridView7.Item(0, i2).Value >= 8) Then

                DataGridView1.Item(0, i2).Value = Div2
                automovecusor()


                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ElseIf ((DataGridView1.Item(5, i2).Value) > 32 And (DataGridView1.Item(5, i2).Value) <= 49 And (DataGridView2.Item(0, i2).Value < 9 And DataGridView3.Item(0, i2).Value < 9) And DataGridView7.Item(0, i2).Value >= 8) Then

                DataGridView1.Item(0, i2).Value = Div2
                automovecusor()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ElseIf ((DataGridView1.Item(5, i2).Value) > 32 And (DataGridView1.Item(5, i2).Value) <= 49 And (DataGridView2.Item(0, i2).Value = 9 Or DataGridView3.Item(0, i2).Value = 9) And DataGridView7.Item(0, i2).Value >= 8) Then

                DataGridView1.Item(0, i2).Value = Div3
                automovecusor()



                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            ElseIf ((DataGridView1.Item(5, i2).Value) > 49 And (DataGridView1.Item(5, i2).Value) <= 54 And (DataGridView2.Item(0, i2).Value < 9 And DataGridView3.Item(0, i2).Value < 9) And DataGridView7.Item(0, i2).Value >= 8) Then

                DataGridView1.Item(0, i2).Value = Div3
                automovecusor()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            ElseIf ((DataGridView1.Item(5, i2).Value) > 49 And (DataGridView1.Item(5, i2).Value) <= 54 And (DataGridView2.Item(0, i2).Value = 9 Or DataGridView3.Item(0, i2).Value = 9) And DataGridView7.Item(0, i2).Value >= 8) Then

                DataGridView1.Item(0, i2).Value = Div4
                automovecusor()



                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




            ElseIf ((DataGridView1.Item(5, i2).Value) < 8) Then

                DataGridView1.Item(0, i2).Value = "X"
                automovecusor()



            End If











        Catch ex As Exception





        End Try

    End Sub



    Public Sub deletebest8()

        Try




            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("delete from reportcards.best8 where class='" + RecordMarks.txt_class.Text + "' and year='" + RecordMarks.txt_year.Text + "' and term='" + RecordMarks.txt_term.Text + "' ", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()

            myReader = SelectCommand.ExecuteReader()




            mycon.Close()


        Catch ex As Exception





        End Try
    End Sub
    Public Sub checktoseeiftemporalbest8isdone()
        Try
            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("Select * from reportcards.best8 where class='" + RecordMarks.txt_class.Text + "' and year='" + RecordMarks.txt_year.Text + "' and term='" + RecordMarks.txt_term.Text + "';", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()
            myReader = SelectCommand.ExecuteReader()
            Dim count As Integer = 0
            If (myReader.HasRows()) Then
                count = count + 1

            End If


            If (count = 0) Then
                updatediv()
            ElseIf (count > 0) Then

                deletebest8()
                updatediv()

            End If


            mycon.Close()


        Catch ex As Exception



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



        End Try
    End Sub


    Private Sub DataGridView1_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        Try
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)


            setfinaldivisions()


        Catch ex As Exception



        End Try
    End Sub

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
        Try


            setfinaldivisions()


        Catch ex As Exception



        End Try
    End Sub


    Public Sub automovecusor()

        Try
            SendKeys.Send("{down}")


        Catch ex As Exception



        End Try



    End Sub




    Public Sub getbesteightaggregates()
        Try


            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT Name,Class,Term,Year,best8 As Best_Eight FROM reportcards.marks WHERE  class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'    GROUP BY name  ", conDatabase)
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
    Public Sub autosave()
        Try
            checktoseeiftemporalbest8isdone()
        Catch ex As Exception



        End Try
    End Sub
    Private Sub Testbest8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DataGridView1.ForeColor = Color.Blue
            DataGridView7.ForeColor = Color.Blue

            DataGridView2.ForeColor = Color.Red

            DataGridView3.ForeColor = Color.Red



            selectmath()
            selecteng()
            fillcount()
            'selectbiology()
            'selectchemistry()
            'selectphysics()
            getbesteightaggregates()


            setfinaldivisions()



        Catch ex As Exception



        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
    End Sub

    Private Sub SAVEDIVISIONSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEDIVISIONSToolStripMenuItem.Click
        Try
            checktoseeiftemporalbest8isdone()
        Catch ex As Exception



        End Try
    End Sub

    Private Sub MenuStrip2_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip2.ItemClicked

    End Sub

    Private Sub Testbest8_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (MessageBox.Show("Have you saved?", "Report card wizard", MessageBoxButtons.YesNo) = DialogResult.Yes) Then

        Else
            e.Cancel = True

        End If

    End Sub

   
    Private Sub UPDATToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UPDATToolStripMenuItem.Click
        UpdateDivision.Show()
    End Sub

    Private Sub DataGridView7_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView7.CellContentClick

    End Sub
End Class

