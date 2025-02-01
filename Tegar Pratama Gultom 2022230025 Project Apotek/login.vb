Imports MySql.Data.MySqlClient

Public Class login
    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Mengatur teks untuk label dan tombol pada form saat dimuat
        Label1.Text = "LOGIN FORM"
        Label1.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        Label2.Text = "Username"
        Label3.Text = "Password"
        Label4.Text = "Default Login"
        Label5.Text = "tama"
        Label6.Text = "123"
        Button1.Text = "Login"
        Button1.BackColor = Color.FromArgb(46, 134, 193)
        Button1.ForeColor = Color.White
        Button2.Text = "Reset"
        Button2.BackColor = Color.FromArgb(46, 134, 193)
        Button2.ForeColor = Color.White
        ' Mengatur karakter password untuk TextBox2 agar tidak terlihat saat diketik
        TextBox2.PasswordChar = "*"
        TextBox2.Font = New Font("Segoe UI", 11)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Mengambil nilai dari TextBox1 (username) dan TextBox2 (password)
        Dim username As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text.Trim()

        ' Memeriksa apakah username dan password kosong
        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Username dan password harus diisi.")
            Return
        End If

        ' Memanggil fungsi LoginUser dari Module1
        If Module1.LoginUser(username, password) Then
            ' Jika login berhasil, tampilkan pesan dan buka form selanjutnya
            MessageBox.Show("Login berhasil!")
            ' Gantikan "FormSelanjutnya" dengan nama form selanjutnya yang ingin Anda buka setelah login berhasil
            Dim apotek As New apotek()
            apotek.Show()
            Me.Hide() ' Sembunyikan form login saat membuka form selanjutnya
        Else
            ' Jika login gagal, tampilkan pesan kesalahan
            MessageBox.Show("Login gagal. Periksa kembali username dan password Anda.")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Mengatur ulang nilai TextBox1 (username) dan TextBox2 (password)
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub
End Class
