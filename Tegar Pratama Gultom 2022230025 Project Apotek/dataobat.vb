Imports System.Windows.Forms
Imports System.Drawing

Public Class dataobat
    Private Sub dataobat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tambahkan ContextMenuStrip ke ListView
        Dim contextMenu As New ContextMenuStrip()
        Dim deleteMenuItem As New ToolStripMenuItem("Hapus Data", Nothing, AddressOf HapusDataMenuItem_Click)
        contextMenu.Items.Add(deleteMenuItem)
        ListView1.ContextMenuStrip = contextMenu

        Me.Text = "Data Obat"
        Me.BackColor = Color.LightCyan
        Me.Size = New Size(800, 600)

        ' Setting labels
        Label1.Text = "DATA OBAT"
        Label2.Text = "Kode Obat"
        Label3.Text = "Nama Obat"
        Label4.Text = "Kategori Obat"
        Label5.Text = "Tanggal Kadaluwarsa"
        Label6.Text = "Stock Awal"
        Label7.Text = "Harga Satuan"
        Label8.Text = "Brand"
        Label9.Text = "Dosis"
        Label10.Text = "Penyimpanan"
        Label11.Text = "Bentuk Obat"
        Label12.Text = "Indikasi Obat"
        Label13.Text = "Efek Samping"

        ' Initializing RadioButtons
        RadioButton1.Text = "Sejuk"
        RadioButton2.Text = "Kering"

        ' Initializing CheckBoxes
        CheckBox1.Text = "Tablet"
        CheckBox2.Text = "Sirup"

        ' Initializing Buttons
        SetButtonProperties(Button1, "Simpan", New Point(20, 500), Color.Green)
        SetButtonProperties(Button2, "Hapus Semuanya", New Point(120, 500), Color.Red)
        SetButtonProperties(Button3, "Hapus Inputan", New Point(250, 500), Color.Orange)
        SetButtonProperties(Button4, "Kembali Menu", New Point(370, 500), Color.Blue)

        ' Setting ListView properties
        ListView1.Location = New Point(20, 350)
        ListView1.Size = New Size(740, 140)
        ListView1.BackColor = Color.White
        ListView1.ForeColor = Color.Black
        ListView1.Font = New Font("Arial", 10, FontStyle.Regular)

        ' ListView Columns
        ListView1.Columns.Add("Kode Obat", 110, HorizontalAlignment.Center)
        ListView1.Columns.Add("Nama Obat", 110, HorizontalAlignment.Center)
        ListView1.Columns.Add("Kategori Obat", 110, HorizontalAlignment.Center)
        ListView1.Columns.Add("Tanggal Kadaluwarsa", 110, HorizontalAlignment.Center)
        ListView1.Columns.Add("Stock Awal", 110, HorizontalAlignment.Center)
        ListView1.Columns.Add("Harga Satuan", 110, HorizontalAlignment.Center)
        ListView1.Columns.Add("Brand", 110, HorizontalAlignment.Center)
        ListView1.Columns.Add("Dosis", 110, HorizontalAlignment.Center)
        ListView1.Columns.Add("Penyimpanan", 110, HorizontalAlignment.Center)
        ListView1.Columns.Add("Bentuk Obat", 110, HorizontalAlignment.Center)
        ListView1.Columns.Add("Indikasi Obat", 110, HorizontalAlignment.Center)
        ListView1.Columns.Add("Efek Samping", 110, HorizontalAlignment.Center)

        ' ListView Settings
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.GridLines = True

        ' Kategori Obat ComboBox items
        Dim kategoriobat() As String =
            {"Antibiotik",
            "Vitamin",
            "Analgesik",
            "Antipiretik",
            "Antiinflamasi",
            "Antihipertensi",
            "Antihistamin",
            "Antidepresan",
            "Antidiabetik",
            "Antivirus",
            "Antijamur"}
        ComboBox1.Items.AddRange(kategoriobat)

        ' Load data from database into ListView
        LoadDataFromDatabase()
    End Sub

    Private Sub SetButtonProperties(btn As Button, text As String, location As Point, backColor As Color)
        btn.Text = text
        btn.Location = location
        btn.BackColor = backColor
        btn.ForeColor = Color.White
    End Sub

    Private Sub LoadDataFromDatabase()
        Dim dt As DataTable = Module1.GetObat()
        For Each row As DataRow In dt.Rows
            Dim item As New ListViewItem(row("kode_obat").ToString())
            item.SubItems.Add(row("nama_obat").ToString())
            item.SubItems.Add(row("kategori_obat").ToString())
            item.SubItems.Add(DateTime.Parse(row("tanggal_kadaluwarsa").ToString()).ToString("yyyy-MM-dd"))
            item.SubItems.Add(row("stok_awal").ToString())
            item.SubItems.Add(row("harga_satuan").ToString())
            item.SubItems.Add(row("brand").ToString())
            item.SubItems.Add(row("dosis").ToString())
            item.SubItems.Add(row("penyimpanan").ToString())
            item.SubItems.Add(row("bentuk_obat").ToString())
            item.SubItems.Add(row("indikasi_obat").ToString())
            item.SubItems.Add(row("efek_samping").ToString())
            ListView1.Items.Add(item)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Mengambil nilai dari form
        Dim kodeObat As String = TextBox1.Text
        Dim namaObat As String = TextBox2.Text
        Dim kategoriObat As String = If(ComboBox1.SelectedItem IsNot Nothing, ComboBox1.SelectedItem.ToString(), "")
        Dim tanggalKadaluwarsa As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim stokAwal As String = TextBox3.Text
        Dim hargaSatuan As String = TextBox4.Text
        Dim brand As String = TextBox5.Text
        Dim dosis As String = TextBox6.Text
        Dim penyimpanan As String = If(RadioButton1.Checked, "Sejuk", If(RadioButton2.Checked, "Kering", ""))
        Dim bentukObat As String = If(CheckBox1.Checked, "Tablet", If(CheckBox2.Checked, "Sirup", ""))
        Dim indikasiObat As String = RichTextBox1.Text
        Dim efekSamping As String = TextBox7.Text

        ' Validasi input sebelum menambahkan ke ListView
        If String.IsNullOrEmpty(kodeObat) OrElse String.IsNullOrEmpty(namaObat) OrElse String.IsNullOrEmpty(kategoriObat) OrElse String.IsNullOrEmpty(tanggalKadaluwarsa) OrElse String.IsNullOrEmpty(stokAwal) OrElse String.IsNullOrEmpty(hargaSatuan) OrElse String.IsNullOrEmpty(brand) OrElse String.IsNullOrEmpty(dosis) OrElse String.IsNullOrEmpty(penyimpanan) OrElse String.IsNullOrEmpty(bentukObat) OrElse String.IsNullOrEmpty(indikasiObat) OrElse String.IsNullOrEmpty(efekSamping) Then
            MessageBox.Show("Mohon lengkapi semua data sebelum menyimpan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Simpan data ke database
        If Module1.SaveObat(kodeObat, namaObat, kategoriObat, tanggalKadaluwarsa, stokAwal, hargaSatuan, brand, dosis, penyimpanan, bentukObat, indikasiObat, efekSamping) Then
            MessageBox.Show("Data obat berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Tambahkan data ke ListView
            Dim item As New ListViewItem(kodeObat)
            item.SubItems.Add(namaObat)
            item.SubItems.Add(kategoriObat)
            item.SubItems.Add(tanggalKadaluwarsa)
            item.SubItems.Add(stokAwal)
            item.SubItems.Add(hargaSatuan)
            item.SubItems.Add(brand)
            item.SubItems.Add(dosis)
            item.SubItems.Add(penyimpanan)
            item.SubItems.Add(bentukObat)
            item.SubItems.Add(indikasiObat)
            item.SubItems.Add(efekSamping)
            ListView1.Items.Add(item)

            ' Bersihkan input setelah data ditambahkan
            ClearInputs()
        Else
            MessageBox.Show("Gagal menyimpan data obat.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Hapus semua data di ListView
        ListView1.Items.Clear()
        ' Hapus semua data di database
        Module1.DeleteAllObat()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Hapus input
        ClearInputs()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Kembali ke menu
        Dim apotek As New apotek()
        apotek.Show()
        Me.Hide() ' Sembunyikan form saat membuka form selanjutnya
    End Sub

    Private Sub ClearInputs()
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.SelectedIndex = -1
        DateTimePicker1.Value = DateTime.Now
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        RichTextBox1.Clear()
        TextBox7.Clear()
    End Sub

    Private Sub HapusDataMenuItem_Click(sender As Object, e As EventArgs)
        ' Hapus item yang dipilih di ListView
        If ListView1.SelectedItems.Count > 0 Then
            ListView1.Items.Remove(ListView1.SelectedItems(0))
        Else
            MessageBox.Show("Silakan pilih data yang ingin dihapus.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class
