Imports System.Windows.Forms
Imports System.Drawing

Public Class datapembeli
    Private Sub datapembeli_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Data Pembeli"
        Me.BackColor = Color.LightCyan
        Me.Size = New Size(800, 600)

        ' Setting labels
        Label1.Text = "DATA PEMBELI"
        Label2.Text = "Kode Pembeli"
        Label3.Text = "Nama Pembeli"
        Label4.Text = "Alamat Pembeli"
        Label5.Text = "No Telepon"
        Label6.Text = "Email Pembeli"
        Label7.Text = "Jenis Kelamin"
        RadioButton1.Text = "Laki-Laki"
        RadioButton2.Text = "Perempuan"
        Button1.Text = "Simpan"
        Button2.Text = "Hapus Semuanya"
        Button3.Text = "Hapus Inputan"
        Button4.Text = "Kembali Menu"
        Button5.Text = "Hapus 1 data"

        ' Initializing Buttons
        SetButtonProperties(Button1, "Simpan", New Point(20, 500), Color.Green)
        SetButtonProperties(Button2, "Hapus Semuanya", New Point(120, 500), Color.Red)
        SetButtonProperties(Button3, "Hapus Inputan", New Point(250, 500), Color.Orange)
        SetButtonProperties(Button4, "Kembali Menu", New Point(370, 500), Color.Blue)
        SetButtonProperties(Button5, "Hapus 1 data", New Point(490, 500), Color.Purple)

        ' Setting DataGridView properties
        DataGridView1.Location = New Point(20, 350)
        DataGridView1.Size = New Size(740, 140)
        DataGridView1.BackColor = Color.White
        DataGridView1.ForeColor = Color.Black
        DataGridView1.Font = New Font("Arial", 10, FontStyle.Regular)

        ' Load data pembeli ke DataGridView
        LoadDataPembeli()
    End Sub

    Private Sub SetButtonProperties(btn As Button, text As String, location As Point, backColor As Color)
        btn.Text = text
        btn.Location = location
        btn.BackColor = backColor
        btn.ForeColor = Color.White
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Mengambil nilai dari form
        Dim kodePembeli As String = TextBox1.Text
        Dim namaPembeli As String = TextBox2.Text
        Dim alamatPembeli As String = TextBox3.Text
        Dim noTelepon As String = TextBox4.Text
        Dim emailPembeli As String = RichTextBox1.Text
        Dim jenisKelamin As String = If(RadioButton1.Checked, "Laki-Laki", If(RadioButton2.Checked, "Perempuan", ""))

        ' Validasi input sebelum menyimpan ke database
        If String.IsNullOrEmpty(kodePembeli) OrElse String.IsNullOrEmpty(namaPembeli) OrElse String.IsNullOrEmpty(alamatPembeli) OrElse String.IsNullOrEmpty(noTelepon) OrElse String.IsNullOrEmpty(emailPembeli) OrElse String.IsNullOrEmpty(jenisKelamin) Then
            MessageBox.Show("Mohon lengkapi semua data sebelum menyimpan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Simpan data ke database
        If Module1.SavePembeli(kodePembeli, namaPembeli, alamatPembeli, noTelepon, emailPembeli, jenisKelamin) Then
            MessageBox.Show("Data pembeli berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearInputs()
            LoadDataPembeli() ' Refresh data di DataGridView
        Else
            MessageBox.Show("Gagal menyimpan data pembeli.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ClearInputs()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        RichTextBox1.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
    End Sub

    Private Sub LoadDataPembeli()
        Dim dt As DataTable = Module1.GetPembeli()
        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Hapus semua data pembeli dari database dan DataGridView
        Module1.DeleteAllPembeli()
        LoadDataPembeli()
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Hapus data pembeli yang dipilih dari database dan DataGridView
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim kodePembeli As String = DataGridView1.SelectedRows(0).Cells("kode_pembeli").Value.ToString()
            If Module1.DeletePembeli(kodePembeli) Then
                MessageBox.Show("Data pembeli berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDataPembeli()
            Else
                MessageBox.Show("Gagal menghapus data pembeli.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Pilih data pembeli yang akan dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
