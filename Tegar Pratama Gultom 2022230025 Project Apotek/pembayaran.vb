Imports System.Reflection.Emit
Imports MySql.Data.MySqlClient

Public Class pembayaran
    Private totalHarga As Decimal
    Private hargaSatuan As Decimal
    Private jumlahObat As Integer
    Private kodeObat As String ' Menyimpan kode obat

    Public Sub SetPembelianData(namaPembeli As String, namaObat As String, hargaSatuan As Decimal, jumlahObat As Integer, kodeObat As String)
        Label11.Text = namaPembeli
        Label12.Text = namaObat
        Label13.Text = hargaSatuan.ToString("C") ' Format as currency
        Label14.Text = jumlahObat.ToString()
        totalHarga = hargaSatuan * jumlahObat
        Label15.Text = totalHarga.ToString("C")
        Me.kodeObat = kodeObat ' Simpan kode obat
    End Sub

    Private Sub pembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Transaksi Pembelian"
        Me.BackColor = Color.LightSteelBlue
        ' Setting labels
        Label1.Text = "PEMBAYARAN PEMBELIAN"
        Label2.Text = "Nama Pembeli"
        Label3.Text = "Nama Obat"
        Label4.Text = "Harga Satuan"
        Label5.Text = "Jumlah Obat"
        Label6.Text = "Total Harga"
        Label7.Text = "Tanggal Transaksi"
        Label8.Text = "Cash Bayar"
        Label9.Text = "No Credit"
        Label10.Text = "Kembalian"
        Label16.Text = ""
        Label17.Text = "Nama Kasir"
        CheckBox1.Text = "Cash"
        CheckBox2.Text = "Credit"
        Button1.Text = "Proses"
        Button2.Text = "Cetak Bill"

        ' Add handlers
        AddHandler CheckBox1.CheckedChanged, AddressOf CheckBox_CheckedChanged
        AddHandler CheckBox2.CheckedChanged, AddressOf CheckBox_CheckedChanged

        'Setting buttons
        SetButtonProperties(Button1, "Proses", New Point(20, 380), Color.DarkGreen, Color.White)
        SetButtonProperties(Button2, "Cetak Bill", New Point(130, 380), Color.DarkBlue, Color.White)


        ' Populate Kasir combobox
        LoadKasirData()
    End Sub

    Private Sub SetButtonProperties(btn As Button, text As String, location As Point, backColor As Color, foreColor As Color)
        btn.BackColor = backColor
        btn.ForeColor = foreColor
    End Sub

    Private Sub LoadKasirData()
        Try
            Module1.OpenConnection()
            Dim query As String = "SELECT nama_lengkap FROM kasir"
            Using cmd As New MySqlCommand(query, Module1.connection)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ComboBox1.Items.Add(reader("nama_lengkap").ToString())
                    End While
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error loading kasir data: " & ex.Message)
        Finally
            Module1.CloseConnection()
        End Try
    End Sub

    Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs)
        If sender Is CheckBox1 Then
            TextBox1.Enabled = CheckBox1.Checked
            If CheckBox1.Checked Then
                CheckBox2.Checked = False
            End If
        ElseIf sender Is CheckBox2 Then
            TextBox2.Enabled = CheckBox2.Checked
            If CheckBox2.Checked Then
                CheckBox1.Checked = False
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked Then ' Cash payment
            Dim cashBayar As Decimal
            If Decimal.TryParse(TextBox1.Text, cashBayar) Then
                If cashBayar >= totalHarga Then
                    Dim kembalian As Decimal = cashBayar - totalHarga
                    Label16.Text = kembalian.ToString("C")
                    MessageBox.Show("Pembayaran berhasil! Kembalian: " & kembalian.ToString("C"))
                Else
                    MessageBox.Show("Uang yang dibayarkan kurang.")
                End If
            Else
                MessageBox.Show("Masukkan jumlah bayar tunai yang valid.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf CheckBox2.Checked Then ' Credit payment
            Dim noCredit As String = TextBox2.Text
            If Not String.IsNullOrEmpty(noCredit) Then
                Label16.Text = "0" ' Tidak ada kembalian untuk kredit
                MessageBox.Show("Pembayaran dengan credit berhasil!")
            Else
                MessageBox.Show("Masukkan nomor kredit yang valid.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Pilih metode pembayaran.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Create an instance of the bill form
        Dim billForm As New bill()

        ' Pass data to bill form
        Dim namaPembeli As String = Label11.Text
        Dim namaObat As String = Label12.Text
        Dim hargaSatuan As Decimal = Decimal.Parse(Label13.Text, Globalization.NumberStyles.Currency)
        Dim jumlahObat As Integer = Integer.Parse(Label14.Text)
        Dim totalBayar As Decimal = Decimal.Parse(Label15.Text, Globalization.NumberStyles.Currency)
        Dim kembalian As Decimal = Decimal.Parse(Label16.Text, Globalization.NumberStyles.Currency)
        Dim metodePembayaran As String = If(CheckBox1.Checked, "Cash", "Credit")
        Dim tanggalTransaksi As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim namaKasir As String = ComboBox1.SelectedItem.ToString()

        ' Debugging: Display data to ensure correctness
        MessageBox.Show($"Data untuk bill: Tanggal Transaksi={tanggalTransaksi}, Nama Pembeli={namaPembeli}, Metode Pembayaran={metodePembayaran}, Nama Obat={namaObat}, Harga Satuan={hargaSatuan}, Jumlah Obat={jumlahObat}, Total Bayar={totalBayar}, Cash Bayar={totalBayar - kembalian}, Kembalian={kembalian}, Nama Kasir={namaKasir}")

        ' Set the bill data
        billForm.SetBillData(tanggalTransaksi, namaPembeli, metodePembayaran, namaObat, hargaSatuan, jumlahObat, totalBayar, totalBayar - kembalian, kembalian, namaKasir)

        ' Show the bill form
        billForm.Show()

        ' Update stock in the database
        UpdateStock(kodeObat, jumlahObat)

        ' Hide current form
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
