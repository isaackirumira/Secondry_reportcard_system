Imports MySql.Data.MySqlClient
Public Class AlevelTotalpoints
    Dim DivA As String = "A"
    Dim DivB As String = "B"

    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean

        Dim key As Keys = keyData And Keys.KeyCode

        If key = Keys.Enter Then
            MyBase.OnKeyDown(New KeyEventArgs(keyData))
            Return True
        Else
            Return MyBase.ProcessDialogKey(keyData)
        End If
    End Function

    Private Sub DataGridView3_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView3.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim ri As Integer = DataGridView3.CurrentCell.RowIndex
                Dim ci As Integer = DataGridView3.CurrentCell.ColumnIndex
                e.SuppressKeyPress = True
                FindNextCell(DataGridView3, ri, ci + 1)  'checking from Next  
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


    Private Sub DataGridView3_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView3.CurrentCellDirtyStateChanged
        Try
            DataGridView3.CommitEdit(DataGridViewDataErrorContexts.Commit)


            setfinalpoints()


        Catch ex As Exception



        End Try
    End Sub

    Private Sub DataGridView3_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView3.CurrentCellChanged
        Try


            setfinalpoints()


        Catch ex As Exception



        End Try
    End Sub


    Public Sub automovecusor()

        Try
            SendKeys.Send("{down}")



        Catch ex As Exception



        End Try



    End Sub
    ''' <summary>
    ''' Agricpoints
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setAgricpoints()


        Try


            Dim i3 As Integer
            i3 = DataGridView3.CurrentRow.Index


            Dim i13 As Integer
            i13 = DataGridView13.CurrentRow.Index

            Dim i14 As Integer
            i14 = DataGridView14.CurrentRow.Index

            Dim i15 As Integer
            i15 = DataGridView15.CurrentRow.Index


            If ((DataGridView13.Item(0, i13).Value < 3) And (DataGridView14.Item(0, i14).Value < 3) And (DataGridView15.Item(0, i15).Value <= 3)) Then

                DataGridView3.Item(0, i3).Value = DivA
                automovecusor()


            ElseIf ((DataGridView13.Item(0, i13).Value <= 3) And (DataGridView14.Item(0, i14).Value < 3) And (DataGridView15.Item(0, i15).Value < 3)) Then

                DataGridView3.Item(0, i3).Value = DivA
                automovecusor()


            ElseIf ((DataGridView13.Item(0, i13).Value < 3) And (DataGridView14.Item(0, i14).Value <= 3) And (DataGridView15.Item(0, i15).Value < 3)) Then

                DataGridView3.Item(0, i3).Value = DivA
                automovecusor()


            End If





        Catch ex As Exception





        End Try
    End Sub
    ''' <summary>
    ''' End agricpoints
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub setfinalpoints()

        setAgricpoints()
    End Sub



    Public Sub mathp1()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS MATHP1 FROM(reportcards.marks) WHERE SUBJECT = 'MATHEMATICS P1' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView32.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub mathp2()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS MATHP2 FROM(reportcards.marks) WHERE SUBJECT = 'MATHEMATICS P2' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView33.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub math()
        mathp1()
        mathp2()
    End Sub

    Public Sub submathp1()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS SUBMATHP1 FROM(reportcards.marks) WHERE SUBJECT = 'SUB-MATH P1' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView12.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub

    Public Sub submathp2()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS SUBMATHP2 FROM(reportcards.marks) WHERE SUBJECT = 'SUB-MATH P2' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView31.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub selectsubmath()
        submathp1()
        submathp2()
    End Sub
    Public Sub geogp1()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS GEOG FROM(reportcards.marks) WHERE SUBJECT = 'GEOGRAPHY P1'  and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView11.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub geogp2()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS GEOG FROM(reportcards.marks) WHERE SUBJECT = 'GEOGRAPHY P2' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView29.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub geogp3()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS GEOG FROM(reportcards.marks) WHERE SUBJECT = 'GEOGRAPHY P3' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView30.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub selectGeo()
        geogp1()
        geogp2()
        geogp3()
    End Sub


    Public Sub artp1()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS ARTP1 FROM(reportcards.marks) WHERE SUBJECT = 'FINE ART P1' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView10.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub artp2()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS ARTP2 FROM(reportcards.marks) WHERE SUBJECT = 'FINE ART P2' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView25.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub artp3()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS ARTP3 FROM(reportcards.marks) WHERE SUBJECT = 'FINE ART P3' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView26.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub artp4()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS ARTP4 FROM(reportcards.marks) WHERE SUBJECT = 'FINE ART P4' AND  class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView27.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub artp6()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS ARTP6 FROM(reportcards.marks) WHERE SUBJECT = 'FINE ART P6' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView28.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub selectART()
        artp1()
        artp2()
        artp3()
        artp4()
        artp6()
    End Sub


    Public Sub citp1()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE  AS ICTP1 FROM(reportcards.marks) WHERE SUBJECT = 'ICT P1'  and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView23.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub citp2()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE  AS ICTP2 FROM(reportcards.marks) WHERE SUBJECT = 'ICT P2'  and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView24.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub selectICT()
        citp1()
        citp2()
    End Sub
    Public Sub entp1()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE  AS ENTP1 FROM(reportcards.marks) WHERE SUBJECT = 'ENTRPRENUERSHIP P1' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView9.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub

    Public Sub entp2()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE  AS ENTP2 FROM(reportcards.marks) WHERE SUBJECT = 'ENTRPRENUERSHIP P2'  and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView22.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub selectENT()
        entp1()
        entp2()
    End Sub


    Public Sub econp1()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE  AS ECONP1 FROM(reportcards.marks) WHERE SUBJECT = 'ECONOMICS P1'  and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView20.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub econp2()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE  AS ECONP2 FROM(reportcards.marks) WHERE SUBJECT = 'ECONOMICS P2'  and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView21.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub selectECON()
        econp1()
        econp2()
    End Sub


    Public Sub selectGP()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE  AS GP FROM(reportcards.marks) WHERE SUBJECT='GP' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView8.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub



    Public Sub phyp1()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS PHYP1 FROM(reportcards.marks) WHERE SUBJECT = 'PHYSICS P1' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
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
    Public Sub phyp2()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS PHYP2 FROM(reportcards.marks) WHERE SUBJECT = 'PHYSICS P2' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView18.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try

    End Sub
    Public Sub phyp3()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS PHYP3 FROM(reportcards.marks) WHERE SUBJECT = 'PHYSICS P3'  and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView19.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try

    End Sub

    Public Sub selectphysics()
        phyp1()
        phyp2()
        phyp3()
    End Sub

    Public Sub fillnames()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT Name,Class,Term,Year  FROM(reportcards.marks) WHERE   class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
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
    Public Sub chemp1()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE  AS CHEMP1 FROM(reportcards.marks) WHERE SUBJECT = 'CHEMISTRY P1' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
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

    Public Sub chemp2()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS CHEMP2 FROM(reportcards.marks) WHERE SUBJECT ='CHEMISTRY P2' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
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
    Public Sub chemp3()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS CHEMP3 FROM(reportcards.marks) WHERE SUBJECT = 'CHEMISTRY P3' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
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
    Public Sub selectcheistry()
        chemp1()
        chemp2()
        chemp3()
    End Sub

    Public Sub biop1()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS BIOP1 FROM(reportcards.marks) WHERE SUBJECT = 'BIOLOGY P1' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
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
    Public Sub biop2()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS BIOP2 FROM(reportcards.marks) WHERE SUBJECT = 'BIOLOGY P2' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView16.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub biop3()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS BIOP3 FROM(reportcards.marks) WHERE SUBJECT = 'BIOLOGY P3' and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)
            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView17.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub

    Public Sub selectbio()
        biop1()
        biop2()
        biop3()
    End Sub





    Public Sub agricp1()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS AGRICP1 FROM reportcards.marks  WHERE SUBJECT = 'AGRICULTURE P1'  and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)

            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView13.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub agricp2()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS AGRICP2 FROM reportcards.marks  WHERE SUBJECT = 'AGRICULTURE P2'  and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)

            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView14.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub
    Public Sub agricp3()
        Try

            Dim constring As String = "datasource=localhost;port=3306;username=root;allowuservariables=True;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("SELECT AGGREGATE AS AGRICP3 FROM reportcards.marks  WHERE SUBJECT = 'AGRICULTURE P3'  and class='" + RecordMarks.txt_class.Text + "' and term='" + RecordMarks.txt_term.Text + "' and year='" + RecordMarks.txt_year.Text + "'   GROUP BY name  ", conDatabase)

            Dim sda As MySqlDataAdapter = New MySqlDataAdapter()
            sda.SelectCommand = cmdDatabase
            Dim dbDataset As DataTable = New DataTable()
            sda.Fill(dbDataset)
            Dim bSource As BindingSource = New BindingSource()
            bSource.DataSource = dbDataset
            DataGridView15.DataSource = bSource
            sda.Update(dbDataset)
            conDatabase.Close()



        Catch ex As Exception



        End Try
    End Sub


    Public Sub selectAgric()
        agricp1()
        agricp2()
        agricp3()
    End Sub






    Public Sub savetotalpointsAgric()

        Try



            For Each row As DataGridViewRow In DataGridView2.Rows


                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.aleveltotalpointsAgric(name,class,term,year,agric) VALUES(@name,@class,@term,@year,@agric)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)

                cmd.Parameters.AddWithValue("@agric", row.Cells("AGRIC").Value)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next

            MessageBox.Show("Records saved.")



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub





    Public Sub savetotalpointsMATH()

        Try



            For Each row As DataGridViewRow In DataGridView13.Rows


                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.aleveltotalpointsMATH(name,class,term,year,MATH) VALUES(@name,@class,@term,@year,@MATH)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)

                cmd.Parameters.AddWithValue("@MATH", row.Cells("MATH").Value)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next





        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Public Sub savetotalpointsSUBMATH()

        Try



            For Each row As DataGridViewRow In DataGridView12.Rows


                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.aleveltotalpointsSUBMATH(name,class,term,year,SUBMATH) VALUES(@name,@class,@term,@year,@SUBMATH)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)

                cmd.Parameters.AddWithValue("@SUBMATH", row.Cells("SUBMATH").Value)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next





        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Public Sub savetotalpointsGEOG()

        Try



            For Each row As DataGridViewRow In DataGridView11.Rows


                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.aleveltotalpointsGEOG(name,class,term,year,GEOG) VALUES(@name,@class,@term,@year,@GEOG)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)

                cmd.Parameters.AddWithValue("@GEOG", row.Cells("GEOG").Value)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next





        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Public Sub savetotalpointsART()

        Try



            For Each row As DataGridViewRow In DataGridView10.Rows


                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.aleveltotalpointsART(name,class,term,year,ART) VALUES(@name,@class,@term,@year,@ART)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)

                cmd.Parameters.AddWithValue("@ART", row.Cells("ART").Value)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next





        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub



    Public Sub savetotalpointsICT()

        Try



            For Each row As DataGridViewRow In DataGridView9.Rows


                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.aleveltotalpointsICT(name,class,term,year,ICT) VALUES(@name,@class,@term,@year,@ICT)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)

                cmd.Parameters.AddWithValue("@ICT", row.Cells("ICT").Value)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next





        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Public Sub savetotalpointsENT()

        Try



            For Each row As DataGridViewRow In DataGridView8.Rows


                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.aleveltotalpointsENT(name,class,term,year,ENT) VALUES(@name,@class,@term,@year,@ENT)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)

                cmd.Parameters.AddWithValue("@ENT", row.Cells("ENT").Value)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next





        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Public Sub savetotalpointsECON()

        Try



            For Each row As DataGridViewRow In DataGridView7.Rows


                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.aleveltotalpointsECON(name,class,term,year,ECON) VALUES(@name,@class,@term,@year,@ECON)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)

                cmd.Parameters.AddWithValue("@ECON", row.Cells("ECON").Value)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next





        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Public Sub savetotalpointsGP()

        Try



            For Each row As DataGridViewRow In DataGridView6.Rows


                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.aleveltotalpointsGP(name,class,term,year,GP) VALUES(@name,@class,@term,@year,@GP)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)

                cmd.Parameters.AddWithValue("@GP", row.Cells("GP").Value)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next





        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Public Sub savetotalpointsBIO()

        Try



            For Each row As DataGridViewRow In DataGridView3.Rows


                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.aleveltotalpointsBIO(name,class,term,year,BIO) VALUES(@name,@class,@term,@year,@BIO)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)

                cmd.Parameters.AddWithValue("@BIO", row.Cells("BIO").Value)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next





        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub



    Public Sub savetotalpointsCHEM()

        Try



            For Each row As DataGridViewRow In DataGridView4.Rows


                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.aleveltotalpointsCHEM(name,class,term,year,CHEM) VALUES(@name,@class,@term,@year,@CHEM)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)

                cmd.Parameters.AddWithValue("@CHEM", row.Cells("CHEM").Value)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next





        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub


    Public Sub savetotalpointsPHY()

        Try



            For Each row As DataGridViewRow In DataGridView5.Rows


                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.aleveltotalpointsPHY(name,class,term,year,PHY) VALUES(@name,@class,@term,@year,@PHY)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@class", row.Cells("Class").Value)
                cmd.Parameters.AddWithValue("@term", row.Cells("Term").Value)
                cmd.Parameters.AddWithValue("@year", row.Cells("Year").Value)

                cmd.Parameters.AddWithValue("@PHY", row.Cells("PHY").Value)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()



            Next





        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub




    Public Sub setdefault()

        Try

            Dim i2 As Integer
            i2 = DataGridView2.CurrentRow.Index

            Dim i3 As Integer
            i3 = DataGridView3.CurrentRow.Index


            Dim i4 As Integer
            i4 = DataGridView4.CurrentRow.Index


            Dim i5 As Integer
            i5 = DataGridView5.CurrentRow.Index

            Dim i6 As Integer
            i6 = DataGridView6.CurrentRow.Index

            Dim i7 As Integer
            i7 = DataGridView7.CurrentRow.Index

            Dim i8 As Integer
            i8 = DataGridView8.CurrentRow.Index

            Dim i9 As Integer
            i9 = DataGridView9.CurrentRow.Index

            Dim i10 As Integer
            i10 = DataGridView10.CurrentRow.Index

            Dim i11 As Integer
            i11 = DataGridView11.CurrentRow.Index

            Dim i12 As Integer
            i12 = DataGridView12.CurrentRow.Index

            Dim i13 As Integer
            i13 = DataGridView13.CurrentRow.Index




        Catch ex As Exception



        End Try
    End Sub


    Public Sub deletefromtotalpoints()

        Try




            Dim myConnection As String = "datasource=localhost;port=3306;username=root;"
            Dim mycon As MySqlConnection = New MySqlConnection(myConnection)
            Dim SelectCommand As MySqlCommand = New MySqlCommand("delete from reportcards.aleveltotalpoints where class='" + RecordMarks.txt_class.Text + "' and year='" + RecordMarks.txt_year.Text + "' and term='" + RecordMarks.txt_term.Text + "' ", mycon)
            Dim myReader As MySqlDataReader

            mycon.Open()

            myReader = SelectCommand.ExecuteReader()




            mycon.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)




        End Try
    End Sub



    Private Sub AlevelTotalpoints_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try



            setdefault()
            fillnames()
            selectphysics()
            selectAgric()
            selectbio()
            selectcheistry()
            selectGP()
            selectECON()
            selectENT()
            selectICT()
            selectART()
            selectGeo()
            selectsubmath()
            math()
            setfinalpoints()








        Catch ex As Exception
            MessageBox.Show(ex.Message)


        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click




    End Sub

    Private Sub DataGridView14_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub


End Class