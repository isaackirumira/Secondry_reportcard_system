Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.ColumnCount = 3
        DataGridView1.Columns(0).Name = "First Name"
        DataGridView1.Columns(0).DataPropertyName = "Object"
        DataGridView1.Columns(1).Name = "Last Name"
        DataGridView1.Columns(2).Name = "Occupation"

        DataGridView1.Rows.Add(New Object() {"Rod", "Stephens", "Nerd"})
        DataGridView1.Rows.Add(New Object() {"Sergio", "Aragones", "Cartoonist"})
        DataGridView1.Rows.Add(New Object() {"Eoin", "Colfer", "Author"})
        DataGridView1.Rows.Add(New Object() {"Terry", "Pratchett", "?"})
    End Sub

    Private WithEvents m_EditingControl As DataGridViewTextBoxEditingControl

    ' Set the editing control so we can catch its events.
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        Debug.WriteLine("Editing")
        m_EditingControl = e.Control
    End Sub

    ' Unset the editing control so we no longer catch its events.
    Private Sub m_EditingControl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_EditingControl.LostFocus
        m_EditingControl = Nothing
        Debug.WriteLine("Done")
    End Sub

    ' Catch the editing control's TextChanged event.
    Private Sub m_EditingControl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_EditingControl.TextChanged
        Dim ctl As DataGridViewTextBoxEditingControl = _
            DirectCast(sender, DataGridViewTextBoxEditingControl)
        Debug.WriteLine(ctl.Text)
    End Sub
End Class
