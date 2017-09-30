Public Class Form3
    Public BasicCount As Integer
    Public SuperCount As Integer
    Public Revive As Integer
    Public ReviveCount As Integer
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BasicCount = 5
        SuperCount = 3
        ReviveCount = 1
        lblBasicPotion.Text = "x" & Str(BasicCount)
        lblSuperPotion.Text = "x" & Str(SuperCount)
        lblRevive.Text = "x" & Str(ReviveCount)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        BasicCount -= 1
        Form1.Ash.Bag(Form1.PlayerBeingUsed).Health += 30
        If Form1.Ash.Bag(Form1.PlayerBeingUsed).Health >= Form1.arrOrigPlayerHealth(Form1.PlayerBeingUsed) Then
            Form1.Ash.Bag(Form1.PlayerBeingUsed).Health = Form1.arrOrigPlayerHealth(Form1.PlayerBeingUsed)
        End If
        Form1.progPlayer.Value = (Form1.Ash.Bag(Form1.PlayerBeingUsed).Health * 100) / Form1.arrOrigPlayerHealth(Form1.PlayerBeingUsed)
        lblBasicPotion.Text = "x" & Str(BasicCount)
        Me.Hide()
        Form1.TimerAttack.Enabled = True
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        SuperCount -= 1
        Form1.Ash.Bag(Form1.PlayerBeingUsed).Health += 50
        If Form1.Ash.Bag(Form1.PlayerBeingUsed).Health >= Form1.arrOrigPlayerHealth(Form1.PlayerBeingUsed) Then
            Form1.Ash.Bag(Form1.PlayerBeingUsed).Health = Form1.arrOrigPlayerHealth(Form1.PlayerBeingUsed)
        End If
        Form1.progPlayer.Value = (Form1.Ash.Bag(Form1.PlayerBeingUsed).Health * 100) / Form1.arrOrigPlayerHealth(Form1.PlayerBeingUsed)
        lblSuperPotion.Text = "x" & Str(BasicCount)
        Me.Hide()
        Form1.TimerAttack.Enabled = True
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If ReviveCount = 1 Then
            Form2.Show()
            Revive = 1

        Else
            MessageBox.Show("You don't have anymore revives!")
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class