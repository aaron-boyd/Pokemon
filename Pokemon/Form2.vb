Imports System.IO
Public Class Form2
    Public myform1 As Form1
    Public arrPics(6) As PictureBox
    Public arrLabels(6) As Label
    Public arrProg(6) As ProgressBar
    Public arrRadio(6) As RadioButton
    Public flag As Integer
    Public selected As Integer
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        arrPics(1) = PictureBox1
        arrPics(2) = PictureBox2
        arrPics(3) = PictureBox3
        arrPics(4) = PictureBox4
        arrPics(5) = PictureBox5
        arrPics(6) = PictureBox6
        arrLabels(1) = Label1
        arrLabels(2) = Label2
        arrLabels(3) = Label3
        arrLabels(4) = Label4
        arrLabels(5) = Label5
        arrLabels(6) = Label6
        arrProg(1) = ProgressBar1
        arrProg(2) = ProgressBar2
        arrProg(3) = ProgressBar3
        arrProg(4) = ProgressBar4
        arrProg(5) = ProgressBar5
        arrProg(6) = ProgressBar6
        For i = 1 To 6
            arrPics(i).Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Images\Bits\" & Form1.Ash.Bag(i).Name & ".png")
            arrLabels(i).Text = Form1.Ash.Bag(i).Name
            arrProg(i).Value = (Form1.Ash.Bag(i).Health * 100) / Form1.arrOrigPlayerHealth(i)
        Next
        flag = 1
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For i = 1 To 6
            If flag = 1 Then
                arrPics(i).Top -= 5
            End If
        Next

        For i = 1 To 6
            If flag = -1 Then
                arrPics(i).Top += 5
            End If
        Next
        flag *= -1
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        SendOut(1)
    End Sub
    Sub LoadNewPokemon(num As Integer)
        Form1.picPlayerPoke.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Images\" & Form1.Ash.Bag(num).Name & ".png")
        Form1.PlayerBeingUsed = num
        For i = 1 To 4
            Form1.arrMoves(i).Text = Form1.Ash.Bag(num).Moves(i).Name
        Next
        Form1.progPlayer.Value = (Form1.Ash.Bag(num).Health * 100) / Form1.arrOrigPlayerHealth(num)
        Form1.lblPlayer.Text = Form1.Ash.Bag(num).Name
        Form1.PlayerBeingUsed = num
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        SendOut(2)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        SendOut(3)
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        SendOut(4)
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        SendOut(5)
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        SendOut(6)
    End Sub
    Sub SendOut(num As Integer)
        If Form3.Revive = 0 Then
            If Form1.Ash.Bag(num).Health = 0 Then
                MessageBox.Show(Form1.Ash.Bag(num).Name & " is not able to battle.")
            Else
                LoadNewPokemon(num)
                Me.Hide()
                Form1.Show()
            End If
        ElseIf Form3.Revive = 1 And Form1.Ash.Bag(num).Health = 0 Then
            Form1.Ash.Bag(num).Health = Form1.arrOrigPlayerHealth(num) * 0.5
            arrProg(num).Value = (Form1.Ash.Bag(num).Health * 100) / Form1.arrOrigPlayerHealth(num)
            Form1.PlayerLeft += 1
            Form3.ReviveCount -= 1
            Me.Hide()
            Form3.Hide()
        Else
            MessageBox.Show("This will have no effect")
        End If
    End Sub
End Class