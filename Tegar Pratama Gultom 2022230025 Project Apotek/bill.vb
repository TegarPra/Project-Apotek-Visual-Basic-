Public Class bill
    Private countdown As Integer = 20 ' Atur waktu mundur dalam detik

    Public Sub SetBillData(tanggalTransaksi As String, namaPembeli As String, metodePembayaran As String, namaObat As String, hargaSatuan As Decimal, jumlahObat As Integer, totalBayar As Decimal, cashBayar As Decimal, kembalian As Decimal, namaKasir As String)
        Label12.Text = tanggalTransaksi
        Label13.Text = namaPembeli
        Label14.Text = metodePembayaran
        Label15.Text = namaObat
        Label16.Text = hargaSatuan.ToString("C")
        Label17.Text = jumlahObat.ToString()
        Label18.Text = totalBayar.ToString("C")
        Label19.Text = cashBayar.ToString("C")
        Label20.Text = kembalian.ToString("C")
        Label23.Text = namaKasir
    End Sub

    Private Sub bill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Text = "Selesai"

        ' Setting form properties
        Me.Text = "Bill Apotek"
        Me.Size = New Size(400, 650)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        ' Setting labels
        Label1.Text = "BILL APOTEK"
        Label1.Font = New Font("Arial", 16, FontStyle.Bold)
        Label1.Location = New Point(130, 20)
        Label1.AutoSize = True

        Label11.Text = "Terima Kasih"
        Label11.Font = New Font("Arial", 12, FontStyle.Italic)
        Label11.Location = New Point(150, 500)
        Label11.AutoSize = True

        Dim labels As New List(Of Label) From {Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, Label10, Label22}
        Dim values As New List(Of Label) From {Label12, Label13, Label14, Label15, Label16, Label17, Label18, Label19, Label20, Label23}

        Dim yPos As Integer = 60
        For i As Integer = 0 To labels.Count - 1
            labels(i).Font = New Font("Arial", 10, FontStyle.Regular)
            labels(i).Location = New Point(30, yPos)
            labels(i).AutoSize = True
            yPos += 30

            values(i).Font = New Font("Arial", 10, FontStyle.Regular)
            values(i).Location = New Point(200, yPos - 30)
            values(i).AutoSize = True
        Next

        Label2.Text = "Tanggal Transaksi"
        Label3.Text = "Nama Pembeli"
        Label4.Text = "Metode Pembayaran"
        Label5.Text = "Nama Obat"
        Label6.Text = "Harga Satuan"
        Label7.Text = "Jumlah Obat"
        Label8.Text = "Total Bayar"
        Label9.Text = "Cash Bayar"
        Label10.Text = "Kembalian"
        Label22.Text = "Nama Kasir"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Memulai timer untuk hitungan mundur
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Mengurangi waktu mundur setiap detik
        countdown -= 1

        ' Memperbarui label waktu mundur
        Label21.Text = "Waktu mundur: " & countdown.ToString() & " detik"

        ' Memeriksa apakah waktu mundur telah mencapai 0
        If countdown <= 0 Then
            ' Menutup form saat waktu mundur habis
            Timer1.Stop()
            Me.Close()

            ' Membuka Form1 (halaman awal)
            Dim apotek As New apotek()
            apotek.Show()
        End If
    End Sub
End Class
