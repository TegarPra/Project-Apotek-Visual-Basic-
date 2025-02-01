Imports System.Drawing
Imports System.Windows.Forms

Public Class apotek

    ' Event handler untuk item menu Data Obat diklik
    Private Sub dataobatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataObatToolStripMenuItem.Click
        ' Membuat instance baru dari form dataobat
        Dim T As New dataobat
        ' Mengatur apotek sebagai container MDI
        Me.IsMdiContainer = True
        ' Mengatur parent form dataobat menjadi apotek
        T.MdiParent = Me
        ' Menampilkan form dataobat sebagai child form di dalam apotek
        T.Show()
    End Sub

    ' Event handler untuk item menu Data Pembeli diklik
    Private Sub datapembeliToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataPembeliToolStripMenuItem.Click
        ' Membuat instance baru dari form datapembeli
        Dim a As New datapembeli
        ' Mengatur apotek sebagai container MDI
        Me.IsMdiContainer = True
        ' Mengatur parent form datapembeli menjadi apotek
        a.MdiParent = Me
        ' Menampilkan form datapembeli sebagai child form di dalam apotek
        a.Show()
    End Sub

    Private Sub datakasirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataKasirToolStripMenuItem.Click
        ' Membuat instance baru dari form datapembeli
        Dim u As New datakasir
        ' Mengatur apotek sebagai container MDI
        Me.IsMdiContainer = True
        ' Mengatur parent form datapembeli menjadi apotek
        u.MdiParent = Me
        ' Menampilkan form datapembeli sebagai child form di dalam apotek
        u.Show()
    End Sub

    ' Event handler untuk item menu Transaksi diklik
    Private Sub transaksiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransaksiToolStripMenuItem.Click
        ' Membuat instance baru dari form pembelian
        Dim m As New pembelian
        ' Mengatur apotek sebagai container MDI
        Me.IsMdiContainer = True
        ' Mengatur parent form pembelian menjadi apotek
        m.MdiParent = Me
        ' Menampilkan form pembelian sebagai child form di dalam apotek
        m.Show()
    End Sub

    ' Event handler untuk item menu Log Out diklik
    Private Sub logoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        ' Membuat instance baru dari form login
        Dim s As New login
        ' Mengatur apotek sebagai container MDI
        Me.IsMdiContainer = True
        ' Mengatur parent form login menjadi apotek
        s.MdiParent = Me
        ' Menampilkan form login sebagai child form di dalam apotek
        s.Show()
    End Sub

    ' Event handler untuk item menu Laporan diklik
    Private Sub laporanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanToolStripMenuItem.Click
        ' Membuat instance baru dari form laporan
        Dim k As New Laporan
        ' Mengatur apotek sebagai container MDI
        Me.IsMdiContainer = True
        ' Mengatur parent form laporan menjadi apotek
        k.MdiParent = Me
        ' Menampilkan form laporan sebagai child form di dalam apotek
        k.Show()
    End Sub

    ' Event handler untuk item menu Exit diklik
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        ' Menampilkan form loading
        Dim loadingForm As New FormLoading()
        loadingForm.Show()
        loadingForm.Refresh()

        ' Menggunakan timer untuk menunda keluar
        Dim exitTimer As New Timer()
        AddHandler exitTimer.Tick, Sub(s, args)
                                       exitTimer.Stop()
                                       loadingForm.Close()
                                       Application.Exit()
                                   End Sub
        exitTimer.Interval = 3000 ' Menetapkan penundaan 3 detik (3000 milidetik)
        exitTimer.Start()
    End Sub

    ' Setting up the form's appearance
    Private Sub apotek_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        ' Form properties
        Me.Text = "Apotek Management System"
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.LightGray

        ' Ubah warna MenuStrip
        MenuStrip1.BackColor = Color.DarkBlue
        MenuStrip1.ForeColor = Color.White
    End Sub
End Class
