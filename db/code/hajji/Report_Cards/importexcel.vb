Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Public Class importexcel
    Private Excel03ConString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"
    Private Excel07ConString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"

    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub importexcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub saveimporteddataintostudentstbl()
        Try

            For Each row As DataGridViewRow In dataGridView1.Rows
                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.students(Name,Class,Year) VALUES(@Name,@Class,@Year)", con)
                cmd.Parameters.AddWithValue("@Name", row.Cells("name").Value)
                cmd.Parameters.AddWithValue("@Class", Regstudents.txt_class.Text)
                cmd.Parameters.AddWithValue("@Year", Regstudents.txt_year.Text)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

            Next
            MessageBox.Show("Students Imported.")




        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub saveimpotreddataintophototbl()
        Try
            For Each row As DataGridViewRow In dataGridView1.Rows
                Dim constring As String = "datasource=localhost;port=3306;username=root;"
                Dim con As New MySqlConnection(constring)
                Dim cmd As New MySqlCommand("INSERT INTO reportcards.photo(name,Occupation,Year) VALUES(@name,@Occupation,@Year)", con)
                cmd.Parameters.AddWithValue("@name", row.Cells("Name").Value)
                cmd.Parameters.AddWithValue("@Occupation", row.Cells("Occupation").Value)
                cmd.Parameters.AddWithValue("@Year", row.Cells("Year").Value)
               
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

            Next
            MessageBox.Show("Data inserted into Photos Table.")




        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub openFileDialog1_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim filePath As String = OpenFileDialog1.FileName
        Dim extension As String = Path.GetExtension(filePath)
        Dim header As String = If(rbHeaderYes.Checked, "YES", "NO")
        Dim conStr As String, sheetName As String

        conStr = String.Empty
        Select Case extension

            Case ".xls"
                'Excel 97-03
                conStr = String.Format(Excel03ConString, filePath, header)
                Exit Select

            Case ".xlsx"
                'Excel 07
                conStr = String.Format(Excel07ConString, filePath, header)
                Exit Select
        End Select

        'Get the name of the First Sheet.
        Using con As New OleDbConnection(conStr)
            Using cmd As New OleDbCommand()
                cmd.Connection = con
                con.Open()
                Dim dtExcelSchema As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                sheetName = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
                con.Close()
            End Using
        End Using

        'Read Data from the First Sheet.
        Using con As New OleDbConnection(conStr)
            Using cmd As New OleDbCommand()
                Using oda As New OleDbDataAdapter()
                    Dim dt As New DataTable()
                    cmd.CommandText = (Convert.ToString("SELECT * From [") & sheetName) + "]"
                    cmd.Connection = con
                    con.Open()
                    oda.SelectCommand = cmd
                    oda.Fill(dt)
                    con.Close()

                    'Populate DataGridView.
                    dataGridView1.DataSource = dt
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        saveimporteddataintostudentstbl()
        'saveimpotreddataintophototbl()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not dataGridView1.CurrentRow.IsNewRow Then
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow)
        End If
    End Sub

    Private Sub dataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

    End Sub
End Class