Public Class FmMain
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Visible = True
        ProgressBar1.Value = ProgressBar1.Value + 1
        If (ProgressBar1.Value = 2) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Reading program files......."

        ElseIf (ProgressBar1.Value = 5) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Reading program files......."
        ElseIf (ProgressBar1.Value = 10) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Reading program files......."
        ElseIf (ProgressBar1.Value = 15) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Turning on program......."
        ElseIf (ProgressBar1.Value = 20) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Turning on program......."
        ElseIf (ProgressBar1.Value = 25) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Turning on program......."
        ElseIf (ProgressBar1.Value = 30) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Turning on program......."
        ElseIf (ProgressBar1.Value = 35) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Turning on program......."
        ElseIf (ProgressBar1.Value = 40) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Starting database connection......."
        ElseIf (ProgressBar1.Value = 45) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Starting database connection......."
        ElseIf (ProgressBar1.Value = 50) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Starting database connection......."
        ElseIf (ProgressBar1.Value = 55) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Starting database connection......."
        ElseIf (ProgressBar1.Value = 60) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Starting database connection......."
        ElseIf (ProgressBar1.Value = 65) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Starting database connection......."
        ElseIf (ProgressBar1.Value = 70) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Loading the database files.."
        ElseIf (ProgressBar1.Value = 75) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Done Loading the program prerequisites........."
        ElseIf (ProgressBar1.Value = 80) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Done Loading the program prerequisites........."
        ElseIf (ProgressBar1.Value = 85) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Done Loading the program prerequisites........."
        ElseIf (ProgressBar1.Value = 90) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Done Loading the program prerequisites........."
        ElseIf (ProgressBar1.Value = 95) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Done Loading the program prerequisites........."
        ElseIf (ProgressBar1.Value = 99) Then
            Label3.Text = ProgressBar1.Value.ToString() & "%" & " " & "Done Loading the program prerequisites........."
        ElseIf (ProgressBar1.Value = 100) Then
            Login.Show()
            Timer1.Enabled = False
            Me.Hide()
        End If
    End Sub


    Private Sub FmSplash_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Label3.Text = ""
        Timer1.Start()

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
