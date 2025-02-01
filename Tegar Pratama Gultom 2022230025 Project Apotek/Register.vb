Imports MySql.Data.MySqlClient

Public Class Register
    Dim connectionString As String = "server=localhost;userid=root;password=;database=apotek"

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setting up form properties
        Me.Text = "Register"
        Me.Size = New System.Drawing.Size(400, 500)
        Me.BackColor = System.Drawing.Color.LightBlue

        ' Setting up labels
        Label1.Text = "Register"
        Label1.Font = New Font("Arial", 20, FontStyle.Bold)
        Label1.ForeColor = Color.DarkBlue
        Label1.AutoSize = True
        Label1.Location = New Point((Me.ClientSize.Width - Label1.Width) \ 2, 30)

        Label2.Text = "First Name"
        Label2.Location = New Point(50, 80)
        Label2.AutoSize = True

        Label3.Text = "Last Name"
        Label3.Location = New Point(50, 130)
        Label3.AutoSize = True

        Label4.Text = "Username"
        Label4.Location = New Point(50, 180)
        Label4.AutoSize = True

        Label5.Text = "Password"
        Label5.Location = New Point(50, 230)
        Label5.AutoSize = True

        Label6.Text = "Konfirmasi Password"
        Label6.Location = New Point(50, 280)
        Label6.AutoSize = True

        ' Setting up textboxes
        TextBox1.Location = New Point(200, 80)
        TextBox1.Size = New System.Drawing.Size(150, 20)

        TextBox2.Location = New Point(200, 130)
        TextBox2.Size = New System.Drawing.Size(150, 20)

        TextBox3.Location = New Point(200, 180)
        TextBox3.Size = New System.Drawing.Size(150, 20)

        TextBox4.Location = New Point(200, 230)
        TextBox4.Size = New System.Drawing.Size(150, 20)
        TextBox4.PasswordChar = "*"c

        TextBox5.Location = New Point(200, 280)
        TextBox5.Size = New System.Drawing.Size(150, 20)
        TextBox5.PasswordChar = "*"c

        ' Setting up buttons
        Button1.Text = "Masuk"
        Button1.Size = New System.Drawing.Size(80, 30)
        Button1.Location = New Point(100, 350)
        Button1.BackColor = Color.DarkBlue
        Button1.ForeColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat

        Button2.Text = "Login"
        Button2.Size = New System.Drawing.Size(80, 30)
        Button2.Location = New Point(200, 350)
        Button2.BackColor = Color.DarkBlue
        Button2.ForeColor = Color.White
        Button2.FlatStyle = FlatStyle.Flat

        ' Adding controls to the form
        Me.Controls.Add(Label1)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Label6)
        Me.Controls.Add(TextBox1)
        Me.Controls.Add(TextBox2)
        Me.Controls.Add(TextBox3)
        Me.Controls.Add(TextBox4)
        Me.Controls.Add(TextBox5)
        Me.Controls.Add(Button1)
        Me.Controls.Add(Button2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Registrasi pengguna baru
        If TextBox4.Text <> TextBox5.Text Then
            MessageBox.Show("Password dan Konfirmasi Password tidak sama.")
            Return
        End If

        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Dim query As String = "INSERT INTO users (first_name, last_name, username, password) VALUES (@first_name, @last_name, @username, @password)"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@first_name", TextBox1.Text)
                cmd.Parameters.AddWithValue("@last_name", TextBox2.Text)
                cmd.Parameters.AddWithValue("@username", TextBox3.Text)
                cmd.Parameters.AddWithValue("@password", TextBox4.Text) ' Pastikan password di-hash untuk keamanan

                Try
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Registrasi berhasil. Silakan login.")
                    Dim login As New login()
                    login.Show()
                    Me.Hide()
                Catch ex As MySqlException
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim login As New login()
        login.Show()
        Me.Hide()
    End Sub
End Class
