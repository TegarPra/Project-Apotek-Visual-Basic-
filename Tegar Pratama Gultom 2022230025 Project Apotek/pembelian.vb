Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports MySql.Data.MySqlClient

Public Class pembelian
    Private Sub pembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadObatComboBox()
        Me.Text = "Transaksi Pembelian"
        Me.BackColor = Color.LightSteelBlue
        ' Setting labels
        Label1.Text = "TRANSAKSI PEMBELIAN"
        Label2.Text = "Pencarian Kode Pembeli"
        Label3.Text = "Kode Pembeli"
        Label4.Text = "Nama Pembeli"
        Label5.Text = "Alamat Pembeli"
        Label6.Text = "No Telepon"
        Label7.Text = "Email Pembeli"
        Label8.Text = "Jenis Kelamin"
        Label9.Text = ""
        Label10.Text = ""
        Label11.Text = ""
        Label12.Text = ""
        Label13.Text = ""
        Label14.Text = ""
        Label15.Text = "Cari Obat"
        Label16.Text = "Kode Obat"
        Label17.Text = "Nama Obat"
        Label18.Text = "Kategori Obat"
        Label19.Text = "Tanggal Kadaluwarsa"
        Label20.Text = "Harga Satuan"
        Label21.Text = "Dosis"
        Label22.Text = "Penyimpanan"
        Label23.Text = "Bentuk Obat"
        Label24.Text = "Indikasi Obat"
        Label25.Text = "Efek Samping"
        Label26.Text = "Jumlah pembelian"
        Label27.Text = ""
        Label28.Text = ""
        Label29.Text = ""
        Label30.Text = ""
        Label31.Text = ""
        Label32.Text = ""
        Label33.Text = ""
        Label34.Text = ""
        Label35.Text = ""
        Label36.Text = ""
        GroupBox1.Text = "Data Pembeli"
        GroupBox2.Text = "Data Obat"
        Button1.Text = "Selanjutnya"
        Button2.Text = "Kembali"

        'Setting buttons
        SetButtonProperties(Button1, "Selanjutnya", New Point(312, 373), Color.DarkGreen, Color.White)
        SetButtonProperties(Button2, "Kembali", New Point(441, 373), Color.DarkBlue, Color.White)

    End Sub

    Private Sub SetButtonProperties(btn As Button, text As String, location As Point, backColor As Color, foreColor As Color)
        btn.BackColor = backColor
        btn.ForeColor = foreColor
    End Sub

    Private Sub LoadObatComboBox()
        Try
            Dim dtObat As DataTable = Module1.GetObat()
            ComboBox1.DataSource = dtObat
            ComboBox1.DisplayMember = "nama_obat"
            ComboBox1.ValueMember = "kode_obat"
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data obat: " & ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If Not String.IsNullOrEmpty(TextBox1.Text) Then
            LoadPembeliData(TextBox1.Text)
        End If
    End Sub

    Private Sub LoadPembeliData(kodePembeli As String)
        Try
            Dim dtPembeli As DataTable = Module1.GetPembeliByKode(kodePembeli)
            If dtPembeli.Rows.Count > 0 Then
                Dim row As DataRow = dtPembeli.Rows(0)
                Label9.Text = row("kode_pembeli").ToString()
                Label10.Text = row("nama_pembeli").ToString()
                Label11.Text = row("alamat_pembeli").ToString()
                Label12.Text = row("no_telepon").ToString()
                Label13.Text = row("email_pembeli").ToString()
                Label14.Text = row("jenis_kelamin").ToString()
            Else
                MessageBox.Show("Kode pembeli tidak ditemukan.")
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data pembeli: " & ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedValue IsNot Nothing Then
            LoadObatData(ComboBox1.SelectedValue.ToString())
        End If
    End Sub

    Private Sub LoadObatData(kodeObat As String)
        Try
            Dim dtObat As DataTable = GetObatByKode(kodeObat)
            If dtObat.Rows.Count > 0 Then
                Dim row As DataRow = dtObat.Rows(0)
                Label27.Text = row("kode_obat").ToString()
                Label28.Text = row("nama_obat").ToString()
                Label29.Text = row("kategori_obat").ToString()
                Label30.Text = row("tanggal_kadaluwarsa").ToString()
                Label31.Text = row("harga_satuan").ToString()
                Label32.Text = row("dosis").ToString()
                Label33.Text = row("penyimpanan").ToString()
                Label34.Text = row("bentuk_obat").ToString()
                Label35.Text = row("indikasi_obat").ToString()
                Label36.Text = row("efek_samping").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data obat: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Create an instance of the pembayaran form
        Dim pembayaranForm As New pembayaran()

        ' Pass data to pembayaran form
        Dim namaPembeli As String = Label10.Text
        Dim namaObat As String = Label28.Text
        Dim hargaSatuan As Decimal = Convert.ToDecimal(Label31.Text)
        Dim jumlahObat As Integer = Convert.ToInt32(TextBox2.Text)
        Dim kodeObat As String = Label27.Text

        ' Debugging: Cek nilai yang akan dikirim
        MessageBox.Show("Nama Pembeli: " & namaPembeli & ", Nama Obat: " & namaObat & ", Harga Satuan: " & hargaSatuan & ", Jumlah Obat: " & jumlahObat)

        pembayaranForm.SetPembelianData(namaPembeli, namaObat, hargaSatuan, jumlahObat, kodeObat)

        ' Show pembayaran form
        pembayaranForm.Show()

        ' Hide current form
        Me.Hide()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Kembali ke menu
        Dim apotek As New apotek()
        apotek.Show()
        Me.Hide() ' Sembunyikan form login saat membuka form selanjutnya
    End Sub
End Class
