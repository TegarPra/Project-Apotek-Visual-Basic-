Imports MySql.Data.MySqlClient

Module Module1
    ' Ganti connectionString dengan informasi koneksi database Anda
    Private connectionString As String = "server=localhost;userid=root;password=;database=apotek"
    Public connection As MySqlConnection

    ' Fungsi untuk membuka koneksi ke database
    Public Sub OpenConnection()
        If connection Is Nothing Then
            connection = New MySqlConnection(connectionString)
        End If
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If
    End Sub

    ' Fungsi untuk menutup koneksi ke database
    Public Sub CloseConnection()
        If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub

    ' Fungsi untuk registrasi user
    Public Function RegisterUser(firstName As String, lastName As String, username As String, password As String) As Boolean
        Try
            OpenConnection()
            Dim query As String = "INSERT INTO users (first_name, last_name, username, password) VALUES (@first_name, @last_name, @username, @password)"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@first_name", firstName)
                cmd.Parameters.AddWithValue("@last_name", lastName)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password) ' Pastikan password di-hash untuk keamanan

                cmd.ExecuteNonQuery()
                Return True
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    ' Fungsi untuk login user
    Public Function LoginUser(username As String, password As String) As Boolean
        Try
            OpenConnection()
            Dim query As String = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@username", username)
                cmd.Parameters.AddWithValue("@password", password) ' Pastikan password di-hash untuk keamanan

                Dim userExists As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                If userExists > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    ' Fungsi untuk menyimpan data obat ke database
    Public Function SaveObat(kodeObat As String, namaObat As String, kategoriObat As String, tanggalKadaluwarsa As String, stokAwal As String, hargaSatuan As String, brand As String, dosis As String, penyimpanan As String, bentukObat As String, indikasiObat As String, efekSamping As String) As Boolean
        Try
            OpenConnection()
            Dim query As String = "INSERT INTO obat (kode_obat, nama_obat, kategori_obat, tanggal_kadaluwarsa, stok_awal, harga_satuan, brand, dosis, penyimpanan, bentuk_obat, indikasi_obat, efek_samping) VALUES (@kodeObat, @namaObat, @kategoriObat, @tanggalKadaluwarsa, @stokAwal, @hargaSatuan, @brand, @dosis, @penyimpanan, @bentukObat, @indikasiObat, @efekSamping)"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@kodeObat", kodeObat)
            cmd.Parameters.AddWithValue("@namaObat", namaObat)
            cmd.Parameters.AddWithValue("@kategoriObat", kategoriObat)
            cmd.Parameters.AddWithValue("@tanggalKadaluwarsa", tanggalKadaluwarsa)
            cmd.Parameters.AddWithValue("@stokAwal", stokAwal)
            cmd.Parameters.AddWithValue("@hargaSatuan", hargaSatuan)
            cmd.Parameters.AddWithValue("@brand", brand)
            cmd.Parameters.AddWithValue("@dosis", dosis)
            cmd.Parameters.AddWithValue("@penyimpanan", penyimpanan)
            cmd.Parameters.AddWithValue("@bentukObat", bentukObat)
            cmd.Parameters.AddWithValue("@indikasiObat", indikasiObat)
            cmd.Parameters.AddWithValue("@efekSamping", efekSamping)
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As MySqlException
            MessageBox.Show("Gagal menyimpan data: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    ' Fungsi untuk menghapus semua data obat dari database
    Public Sub DeleteAllObat()
        Try
            OpenConnection()
            Dim query As String = "DELETE FROM obat"
            Dim cmd As New MySqlCommand(query, connection)
            cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show("Gagal menghapus data: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' Fungsi untuk mengambil semua data obat dari database
    Public Function GetObat() As DataTable
        Dim dt As New DataTable
        Try
            OpenConnection()
            Dim query As String = "SELECT * FROM obat"
            Dim adapter As New MySqlDataAdapter(query, connection)
            adapter.Fill(dt)
        Catch ex As MySqlException
            MessageBox.Show("Gagal mengambil data: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CloseConnection()
        End Try
        Return dt
    End Function
    Public Function SavePembeli(kodePembeli As String, namaPembeli As String, alamatPembeli As String, noTelepon As String, emailPembeli As String, jenisKelamin As String) As Boolean
        Try
            OpenConnection()
            Dim query As String = "INSERT INTO pembeli (kode_pembeli, nama_pembeli, alamat_pembeli, no_telepon, email_pembeli, jenis_kelamin) VALUES (@kode_pembeli, @nama_pembeli, @alamat_pembeli, @no_telepon, @email_pembeli, @jenis_kelamin)"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@kode_pembeli", kodePembeli)
                cmd.Parameters.AddWithValue("@nama_pembeli", namaPembeli)
                cmd.Parameters.AddWithValue("@alamat_pembeli", alamatPembeli)
                cmd.Parameters.AddWithValue("@no_telepon", noTelepon)
                cmd.Parameters.AddWithValue("@email_pembeli", emailPembeli)
                cmd.Parameters.AddWithValue("@jenis_kelamin", jenisKelamin)

                cmd.ExecuteNonQuery()
                Return True
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
            Return False
        Finally
            CloseConnection()
        End Try
    End Function
    ' Fungsi untuk mengambil data pembeli
    Public Function GetPembeli() As DataTable
        Dim dt As New DataTable()
        Try
            OpenConnection()
            Dim query As String = "SELECT * FROM pembeli"
            Using cmd As New MySqlCommand(query, connection)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CloseConnection()
        End Try
        Return dt
    End Function
    ' Fungsi untuk menghapus data pembeli berdasarkan kode pembeli
    Public Function DeletePembeli(kodePembeli As String) As Boolean
        Try
            OpenConnection()
            Dim query As String = "DELETE FROM pembeli WHERE kode_pembeli = @kode_pembeli"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@kode_pembeli", kodePembeli)
                cmd.ExecuteNonQuery()
                Return True
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    ' Fungsi untuk menghapus semua data pembeli
    Public Sub DeleteAllPembeli()
        Try
            OpenConnection()
            Dim query As String = "DELETE FROM pembeli"
            Using cmd As New MySqlCommand(query, connection)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    ' Fungsi untuk mengambil data pembeli berdasarkan kode pembeli
    Public Function GetPembeliByKode(kodePembeli As String) As DataTable
        Dim dt As New DataTable()
        Try
            OpenConnection()
            Dim query As String = "SELECT * FROM pembeli WHERE kode_pembeli = @kode_pembeli"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@kode_pembeli", kodePembeli)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CloseConnection()
        End Try
        Return dt
    End Function

    ' Fungsi untuk mengambil data obat berdasarkan kode obat
    Public Function GetObatByKode(kodeObat As String) As DataTable
        Dim dt As New DataTable()
        Try
            OpenConnection()
            Dim query As String = "SELECT * FROM obat WHERE kode_obat = @kode_obat"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@kode_obat", kodeObat)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CloseConnection()
        End Try
        Return dt
    End Function

    Public Function SaveKasir(idKasir As String, namaLengkap As String, alamat As String, nomorTelepon As String, email As String, tanggalLahir As Date, tanggalBergabung As Date, shiftKerja As String, gaji As Decimal) As Boolean
        Try
            OpenConnection()
            Dim query As String = "INSERT INTO kasir (id_kasir, nama_lengkap, alamat, nomor_telepon, email, tanggal_lahir, tanggal_bergabung, shift_kerja, gaji) VALUES (@idKasir, @namaLengkap, @alamat, @nomorTelepon, @email, @tanggalLahir, @tanggalBergabung, @shiftKerja, @gaji)"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@idKasir", idKasir)
                cmd.Parameters.AddWithValue("@namaLengkap", namaLengkap)
                cmd.Parameters.AddWithValue("@alamat", alamat)
                cmd.Parameters.AddWithValue("@nomorTelepon", nomorTelepon)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@tanggalLahir", tanggalLahir)
                cmd.Parameters.AddWithValue("@tanggalBergabung", tanggalBergabung)
                cmd.Parameters.AddWithValue("@shiftKerja", shiftKerja)
                cmd.Parameters.AddWithValue("@gaji", gaji)
                cmd.ExecuteNonQuery()
                Return True
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
            Return False
        Finally
            CloseConnection()
        End Try
    End Function

    Public Sub DeleteAllKasir()
        Try
            OpenConnection()
            Dim query As String = "DELETE FROM kasir"
            Using cmd As New MySqlCommand(query, connection)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CloseConnection()
        End Try
    End Sub

    Public Function GetKasir() As DataTable
        Dim dt As New DataTable()
        Try
            OpenConnection()
            Dim query As String = "SELECT * FROM kasir"
            Using cmd As New MySqlCommand(query, connection)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CloseConnection()
        End Try
        Return dt
    End Function

End Module
