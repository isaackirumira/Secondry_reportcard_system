Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class AlevelGridmarksheet
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    'Change "C:\Users\Jimmy\Documents\Merchandise.accdb" to your database location
    Dim connString As String = "datasource=localhost;port=3306;username=root;"
    'Change "C:\Users\Jimmy\Desktop\test.xlsx" to your excel file location
    Dim excelLocation As String = "D:\export\test.xlsx"
    Dim MyConn As MySqlConnection
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim tables As DataTableCollection
    Dim source1 As New BindingSource
    Dim APP As New Excel.Application
    Dim worksheet As Excel.Worksheet
    Dim workbook As Excel.Workbook

   

    Public Sub fillgrid()
        Try
            Dim constring As String = "datasource=localhost;port=3306;username=root;"
            Dim conDatabase As MySqlConnection = New MySqlConnection(constring)
            Dim cmdDatabase As MySqlCommand = New MySqlCommand("Select Name,subject as Subj,P1MID,P1END,AVGP1,GRADEP1 as GrdP1,AGGREGATEP1 as AggP1,P2MID,P2END,AVGP2,GRADEP2 AS GrdP2,AGGREGATEP2 as AggP2,P3MID,P3END,AVGP3,GRADEP3 as GrdP3,AGGREGATEP3 As AggP3,SCORE as SCR,POINTS AS Pts from reportcards.aleveltotalpoints where class='" + RecordMarksALevel.txt_class.Text + "' and term='" + RecordMarksALevel.txt_term.Text + "' and year='" + RecordMarksALevel.txt_year.Text + "' ;", conDatabase)
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
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        With DataGridView1
            Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
            fmt.LineAlignment = StringAlignment.Center
            fmt.Trimming = StringTrimming.EllipsisCharacter
            Dim y As Single = e.MarginBounds.Top
            Do While mRow < .RowCount
                Dim row As DataGridViewRow = .Rows(mRow)
                Dim x As Single = e.MarginBounds.Left
                Dim h As Single = 0
                For Each cell As DataGridViewCell In row.Cells
                    Dim rc As RectangleF = New RectangleF(x, y, cell.Size.Width, cell.Size.Height)
                    e.Graphics.DrawRectangle(Pens.Black, rc.Left, rc.Top, rc.Width, rc.Height)
                    If (newpage) Then
                        e.Graphics.DrawString(DataGridView1.Columns(cell.ColumnIndex).HeaderText, .Font, Brushes.Black, rc, fmt)
                    Else
                        e.Graphics.DrawString(DataGridView1.Rows(cell.RowIndex).Cells(cell.ColumnIndex).FormattedValue.ToString(), .Font, Brushes.Black, rc, fmt)
                    End If
                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                Next
                newpage = False
                y += h
                mRow += 1
                If y + h > e.MarginBounds.Bottom Then
                    e.HasMorePages = True
                    mRow -= 1
                    newpage = True
                    Exit Sub
                End If
            Loop
            mRow = 0
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintDocument1.DefaultPageSettings.Landscape = True ''''
        PrintPreviewDialog1.ShowDialog()

    End Sub

    Private Sub AlevelGridmarksheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
            workbook = APP.Workbooks.Open(excelLocation)
            worksheet = workbook.Worksheets("sheet1")

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub AlevelGridmarksheet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            workbook.Save()
            workbook.Close()
            APP.Quit()
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            'Export Header Names Start
            Dim columnsCount As Integer = DataGridView1.Columns.Count
            For Each column In DataGridView1.Columns
                worksheet.Cells(1, column.Index + 1).Value = column.Name
            Next
            'Export Header Name End


            'Export Each Row Start
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim columnIndex As Integer = 0
                Do Until columnIndex = columnsCount
                    worksheet.Cells(i + 2, columnIndex + 1).Value = DataGridView1.Item(columnIndex, i).Value.ToString
                    columnIndex += 1
                Loop
            Next
            'Export Each Row End
        Catch ex As Exception

            MessageBox.Show("Data exported check on D in a folder called export")

        End Try

    End Sub
   
   

   
End Class