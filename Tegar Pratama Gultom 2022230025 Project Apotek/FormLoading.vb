Public Class FormLoading
    Private Sub FormLoading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "Loading"
        Me.Size = New Size(300, 200)
        Me.BackColor = Color.LightSkyBlue

        ' Set GroupBox properties
        Me.GroupBox1.Text = "Please wait..."
        Me.GroupBox1.Font = New Font("Arial", 12, FontStyle.Bold)
        Me.GroupBox1.ForeColor = Color.DarkBlue
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Location = New Point((Me.ClientSize.Width - Me.GroupBox1.Width) / 2, (Me.ClientSize.Height - Me.GroupBox1.Height) / 2)
        Me.GroupBox1.Padding = New Padding(10)
        Me.GroupBox1.BackColor = Color.White

        ' Set Label properties
        Me.Label1.Text = "Exiting, please wait..."
        Me.Label1.Font = New Font("Arial", 10, FontStyle.Regular)
        Me.Label1.ForeColor = Color.DarkRed
        Me.Label1.AutoSize = True
        Me.Label1.Location = New Point(20, 30)

        ' Set ProgressBar properties
        Me.ProgressBar1.Style = ProgressBarStyle.Marquee
        Me.ProgressBar1.MarqueeAnimationSpeed = 30
        Me.ProgressBar1.Size = New Size(240, 30)
        Me.ProgressBar1.Location = New Point(20, 60)
        Me.ProgressBar1.ForeColor = Color.Green
        Me.ProgressBar1.BackColor = Color.White

        ' Add controls to GroupBox
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)

        ' Add GroupBox to form
        Me.Controls.Add(Me.GroupBox1)

        ' Center GroupBox on form
        CenterGroupBox()
    End Sub

    Private Sub CenterGroupBox()
        Me.GroupBox1.Location = New Point((Me.ClientSize.Width - Me.GroupBox1.Width) / 2, (Me.ClientSize.Height - Me.GroupBox1.Height) / 2)
    End Sub
End Class
