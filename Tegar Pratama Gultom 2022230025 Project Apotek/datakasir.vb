Imports System.Windows.Forms
Imports System.Drawing

Public Class datakasir
    Private Sub datakasir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Data Kasir"
        Me.BackColor = Color.LightCyan
        Me.Size = New Size(800, 600)

        ' Setting labels
        Label1.Text = "DATA KASIR"
        Label2.Text = "ID Kasir"
        Label3.Text = "Nama Lengkap"
        Label4.Text = "Alamat"
        Label5.Text = "Nomor Telepon"
        Label6.Text = "Email"
        Label7.Text = "Tanggal Lahir"
        Label8.Text = "Tanggal Bergabung"
        Label9.Text = "Shift Kerja"
        Label10.Text = "Gaji"
        RadioButton1.Text = "Pagi"
        RadioButton2.Text = "Siang"
        RadioButton3.Text = "Malam"
        Button1.Text = "Simpan"
        Button2.Text = "Hapus Semuanya"
        Button3.Text = "Menu"

        ' Initializing Buttons
        SetButtonProperties(Button1, "Simpan", New Point(20, 500), Color.Green)
        SetButtonProperties(Button2, "Hapus Semuanya", New Point(120, 500), Color.Red)
        SetButtonProperties(Button3, "Kembali Menu", New Point(250, 500), Color.Orange)

        ' Setting DataGridView properties
        DataGridView1.Location = New Point(20, 350)
        DataGridView1.Size = New Size(740, 140)
        DataGridView1.BackColor = Color.White
        DataGridView1.ForeColor = Color.Black
        DataGridView1.Font = New Font("Arial", 10, FontStyle.Regular)

        ' Load data kasir ke dalam DataGridView
        LoadKasirData()
    End Sub

    Private Sub SetButtonProperties(btn As Button, text As String, location As Point, backColor As Color)
        btn.Text = text
        btn.Location = location
        btn.BackColor = backColor
        btn.ForeColor = Color.White
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Ambil data dari inputan
        Dim idKasir As String = TextBox1.Text
        Dim namaLengkap As String = TextBox2.Text
        Dim alamat As String = RichTextBox1.Text
        Dim nomorTelepon As String = TextBox3.Text
        Dim email As String = TextBox4.Text
        Dim tanggalLahir As Date = DateTimePicker1.Value
        Dim tanggalBergabung As Date = DateTimePicker2.Value
        Dim shiftKerja As String = If(RadioButton1.Checked, "Pagi", If(RadioButton2.Checked, "Siang", If(RadioButton3.Checked, "Malam", "")))
        Dim gaji As Decimal

        If Not Decimal.TryParse(TextBox5.Text, gaji) Then
            MessageBox.Show("Mohon masukkan gaji yang valid.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Simpan data kasir ke database
        If SaveKasir(idKasir, namaLengkap, alamat, nomorTelepon, email, tanggalLahir, tanggalBergabung, shiftKerja, gaji) Then
            MessageBox.Show("Data kasir berhasil disimpan!")
            LoadKasirData() ' Refresh data
        Else
            MessageBox.Show("Gagal menyimpan data kasir.")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Hapus semua data kasir dari database
        DeleteAllKasir()
        MessageBox.Show("Semua data kasir berhasil dihapus.")
        LoadKasirData() ' Refresh data
        ' Hapus input
        ClearInputs()
    End Sub

    Private Sub ClearInputs()
        TextBox1.Clear()
        TextBox2.Clear()
        RichTextBox1.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Kembali ke menu
        Dim apotek As New apotek()
        apotek.Show()
        Me.Hide() ' Sembunyikan form ini saat membuka form selanjutnya
    End Sub

    Private Sub LoadKasirData()
        ' Ambil data kasir dari database dan tampilkan di DataGridView
        Dim dt As DataTable = GetKasir()
        DataGridView1.DataSource = dt
    End Sub
End Class
