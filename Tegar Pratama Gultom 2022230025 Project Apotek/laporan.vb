Imports MySql.Data.MySqlClient

Public Class Laporan
    Private Sub Laporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "Laporan Data Apotek"
        Me.Size = New Size(800, 600)
        Me.BackColor = Color.LightBlue

        ' Set label properties
        Label1.Text = "LAPORAN DATA OBAT"
        Label1.Font = New Font("Arial", 16, FontStyle.Bold)
        Label1.Location = New Point(20, 20)
        Label1.ForeColor = Color.DarkBlue

        Label2.Text = "LAPORAN DATA PEMBELI"
        Label2.Font = New Font("Arial", 16, FontStyle.Bold)
        Label2.Location = New Point(20, 300)
        Label2.ForeColor = Color.DarkBlue

        ' Set button properties
        Button1.Text = "Refresh"
        Button1.Font = New Font("Arial", 12, FontStyle.Regular)
        Button1.Size = New Size(100, 40)
        Button1.Location = New Point(650, 20)
        Button1.BackColor = Color.LightGreen
        Button1.ForeColor = Color.Black

        Button2.Text = "Kembali"
        Button2.Font = New Font("Arial", 12, FontStyle.Regular)
        Button2.Size = New Size(100, 40)
        Button2.Location = New Point(650, 500)
        Button2.BackColor = Color.LightYellow
        Button2.ForeColor = Color.Black

        ' Set DataGridView properties
        DataGridView1.Location = New Point(20, 60)
        DataGridView1.Size = New Size(740, 200)
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        DataGridView2.Location = New Point(20, 340)
        DataGridView2.Size = New Size(740, 150)
        DataGridView2.BackgroundColor = Color.White
        DataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        ' Load data into DataGridViews
        LoadDataObat()
        LoadDataPembeli()
    End Sub

    Private Sub LoadDataObat()
        Dim dtObat As DataTable = Module1.GetObat()
        DataGridView1.DataSource = dtObat
    End Sub

    Private Sub LoadDataPembeli()
        Dim dtPembeli As DataTable = Module1.GetPembeli()
        DataGridView2.DataSource = dtPembeli
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Refresh data
        LoadDataObat()
        LoadDataPembeli()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Kembali ke menu
        Dim apotek As New apotek()
        apotek.Show()
        Me.Hide()
    End Sub

    Private Sub UpdateStock(kodeObat As String, jumlahDibeli As Integer)
        Try
            Module1.OpenConnection()
            Dim query As String = "UPDATE obat SET stok_awal = stok_awal - @jumlahDibeli WHERE kode_obat = @kodeObat"
            Using cmd As New MySqlCommand(query, Module1.connection)
                cmd.Parameters.AddWithValue("@jumlahDibeli", jumlahDibeli)
                cmd.Parameters.AddWithValue("@kodeObat", kodeObat)
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("Stok obat berhasil diperbarui.")
        Catch ex As MySqlException
            MessageBox.Show("Error updating stock: " & ex.Message)
        Finally
            Module1.CloseConnection()
        End Try
    End Sub
End Class
