Imports System.ComponentModel
Imports System.IO
Public Class Form1
    Public MoveCount As Integer
    Public Count As Integer
    Public GymLeader As Player
    Public Ash As Player
    Public arrTopTen As TopTen
    Public PathLeader As String
    Public PathPlayer As String
    Public prog As Integer
    Public arrChks(12) As CheckBox
    Public arrChosen(6) As Integer
    Public arrMoves(4) As RadioButton
    Public Sprite As Integer
    Public OpponentHealth As Integer, PlayerHealth As Integer
    Public PlayerBeingUsed As Integer, GymBeingUsed, Playerkilled As Integer, GymKilled As Integer
    Public arrOrigPlayerHealth(6) As Integer, arrOrigGymHealth(6) As Integer, LeaderDefeated As Integer
    Public DisplayedText As String, check As Integer, GymLeaderLeft As Integer, PlayerLeft As Integer
    Public arrGymBall(6) As PictureBox, arrPlayerBall(6) As PictureBox
    Public start As Integer, UserScore As Integer

    Structure Player
        Dim Name As String
        Dim Bag() As Pokemon
        Sub FillPokemon(path As String, i As Integer)
            ReDim Preserve Bag(6)
            Bag(i).Fill(path)
        End Sub
        Overloads Function tostring(num As Integer) As String
            Dim str As String
            str = Bag(num).Name & vbCrLf & Bag(num).Health
            For i = 1 To 4
                str = str & vbCrLf & Bag(num).Moves(i).Name & vbCrLf & Bag(num).Moves(i).Damage
            Next
            tostring = str & vbCrLf
        End Function
    End Structure
    Public Structure Pokemon
        Dim Name As String
        Dim Health As Integer
        Dim Moves() As Mve
        Dim Type As String
        Sub Fill(path As String)
            ReDim Moves(4)
            Dim File As New StreamReader(path)
            Name = File.ReadLine
            Type = File.ReadLine
            Health = Val(File.ReadLine)
            For i = 1 To 4
                Moves(i).Name = File.ReadLine
                Moves(i).Type = File.ReadLine
                Moves(i).Damage = Val(File.ReadLine)
                Moves(i).Accuracy = Val(File.ReadLine)
            Next
            File.Close()
        End Sub
    End Structure
    Public Structure Mve
        Dim Name As String
        Dim Damage As Integer
        Dim Type As String
        Dim Accuracy As Integer
    End Structure
    Structure TopTen
        Dim Players() As Record
        Sub FillTopTen()
            ReDim Players(11)
            Dim Path As New StreamReader("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\TopTen\TopTen.txt")
            For i = 1 To 10
                Players(i).Name = Path.ReadLine
                Players(i).Score = Val(Path.ReadLine)
            Next
            Path.Close()
        End Sub
        Sub Sort()
            Dim front As Integer, back As Integer, temp As Record
            For front = 1 To 10
                For back = front + 1 To 11
                    If Players(front).Score < Players(back).Score Then
                        temp = Players(front)
                        Players(front) = Players(back)
                        Players(back) = temp
                    End If
                Next back
            Next front
        End Sub
    End Structure

    Structure Record
        Dim Name As String
        Dim Score As Integer
        Function TopTentostring(num As Integer) As String
            Dim strt As String = String.Empty
            strt = Str(num) & "." & "  " & Name & "      " & Str(Score)
            TopTentostring = strt
        End Function
    End Structure

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Count = 0
        start = 0
        Sprite = 0
        UserScore = 0
        PathPlayer = "D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Player\"
        arrChks(1) = chkBulbasaur
        arrChks(2) = chkVulpix
        arrChks(3) = chkPinsir
        arrChks(4) = chkGeodude
        arrChks(5) = chkGrimer
        arrChks(6) = chkTangela
        arrChks(7) = chkElectabuzz
        arrChks(8) = chkHitmonchan
        arrChks(9) = chkPoliwhirl
        arrChks(10) = chkPonyta
        arrChks(11) = chkKadabra
        arrChks(12) = chkMachoke
        arrMoves(1) = optMove1
        arrMoves(2) = optMove2
        arrMoves(3) = optMove3
        arrMoves(4) = optMove4
        arrGymBall(1) = PictureBox14
        arrGymBall(2) = picBall8
        arrGymBall(3) = picBall9
        arrGymBall(4) = picBall10
        arrGymBall(5) = picBall11
        arrGymBall(6) = picBall12
        arrPlayerBall(1) = picBall1
        arrPlayerBall(2) = picBall2
        arrPlayerBall(3) = picBall3
        arrPlayerBall(4) = picBall4
        arrPlayerBall(5) = picBall5
        arrPlayerBall(6) = picBall6

        arrTopTen.FillTopTen()
        For i = 1 To 10
            Form4.lstTopTen.Items.Add(arrTopTen.Players(i).TopTentostring(i))
        Next
        Me.BackgroundImage = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Images\TitleScreen.jpg")
        For i = 1 To 12
            arrChks(i).Visible = False
        Next
        GymLeaderLeft = 6
        PlayerLeft = 6
    End Sub

    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        Startgame()
        Sprite = 0
    End Sub

    Sub Startgame()
        Dim count As Integer
        count = 0
        For i = 1 To 12
            If arrChks(i).Checked = True Then
                count += 1
            End If
        Next
        If count <> 6 Then
            MessageBox.Show("Please select 6 Pokemon.")
            For x = 1 To 12
                arrChks(x).Checked = False
            Next x
            Exit Sub
        ElseIf count = 6 Then
            Ash.Name = InputBox("Please enter your name.", "Name", "Ash")
            arrTopTen.Players(11).Name = Ash.Name
            count = 1
            For i = 1 To 12
                If arrChks(i).Checked = True Then
                    arrChosen(count) = i
                    count += 1
                End If
            Next
            For i = 1 To 6
                Ash.FillPokemon(PathPlayer & Trim(Str(arrChosen(i))) & ".txt", i)
                arrOrigPlayerHealth(i) = Ash.Bag(i).Health
            Next i
            If cmbLeader.Text = "Blaine" Then
                PathLeader = "D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Blaine\"
                picGymLeader.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Blaine\Blaine.png")
                Me.BackgroundImage = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Blaine\Fire.png")
                GymLeader.Name = "Blaine"
                For i = 1 To 6
                    GymLeader.FillPokemon(PathLeader & Trim(Str(i)) & ".txt", i)
                    arrOrigGymHealth(i) = GymLeader.Bag(i).Health
                Next i
            ElseIf cmbLeader.Text = "Misty" Then
                GymLeader.Name = "Misty"
                PathLeader = "D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Misty\"
                picGymLeader.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Misty\Misty.png")
                Me.BackgroundImage = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Misty\Water.png")
                For i = 1 To 6
                    GymLeader.FillPokemon(PathLeader & Trim(Str(i)) & ".txt", i)
                    arrOrigGymHealth(i) = GymLeader.Bag(i).Health
                Next i
            ElseIf cmbleader.text = "Brock" Then
                GymLeader.Name = "Brock"
                PathLeader = "D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Brock\"
                picGymLeader.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Brock\Brock.png")
                Me.BackgroundImage = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Brock\Rock.png")
                For i = 1 To 6
                    GymLeader.FillPokemon(PathLeader & Trim(Str(i)) & ".txt", i)
                    arrOrigGymHealth(i) = GymLeader.Bag(i).Health
                Next i
            ElseIf cmbLeader.Text = "Erika" Then
                GymLeader.Name = "Erika"
                PathLeader = "D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Erika\"
                picGymLeader.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Erika\Erika.png")
                Me.BackgroundImage = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Erika\Grass.png")
                For i = 1 To 6
                    GymLeader.FillPokemon(PathLeader & Trim(Str(i)) & ".txt", i)
                    arrOrigGymHealth(i) = GymLeader.Bag(i).Health
                Next i
            End If
        End If
        picGymLeader.Visible = True
        Hidethings()
        PlayerHealth = Ash.Bag(1).Health
        OpponentHealth = GymLeader.Bag(1).Health
        For i = 1 To 6
            arrGymBall(i).Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Images\Items\pokeball.png")
        Next i
        PlayerBeingUsed = 1
        GymLeaderLeft = 6
        GymBeingUsed = 1
        TimerMove.Enabled = True
        start = 1
    End Sub
    Sub Hidethings()
        cmdStart.Visible = False
        cmbLeader.Visible = False
        GroupBox1.Visible = False
        cmdTopTen.Visible = False
        For i = 1 To 12
            arrChks(i).Visible = False
            PictureBox1.Visible = False
            PictureBox2.Visible = False
            PictureBox3.Visible = False
            PictureBox4.Visible = False
            PictureBox5.Visible = False
            PictureBox6.Visible = False
            PictureBox7.Visible = False
            PictureBox9.Visible = False
            PictureBox10.Visible = False
            PictureBox11.Visible = False
            PictureBox12.Visible = False
            PictureBox13.Visible = False
            picLeader.Visible = False

        Next
        Button1.Visible = False
    End Sub
    Sub ShowThings()
        lblPlayer.Visible = True
        lblLeader.Visible = True
        For i = 1 To 6
            arrGymBall(i).Visible = True
            arrPlayerBall(i).Visible = True
        Next
        progPlayer.Visible = True
        progLeader.Visible = True
        picPlayerPoke.Visible = True
        picGymLeader.Visible = True
        lblText.Visible = True
        cmdAttack.Visible = True
        cmdBag.Visible = True
        cmdSwitch.Visible = True
        For i = 1 To 4
            arrMoves(i).Visible = True
        Next

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerMove.Tick
        picPlayer.Left -= 25
        picGymLeader.Left -= 25
        If picPlayer.Left < 0 Then
            TimerMove.Enabled = False
            MessageBox.Show("I shall end you" & " " & Ash.Name)
            TimerThrow.Enabled = True
        End If
    End Sub

    Private Sub TimerThrow_Tick(sender As Object, e As EventArgs) Handles TimerThrow.Tick
        Sprite += 1
        If Sprite = 2 Then
            picPlayer.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Player\Sprite2.gif")
            picPlayer.Left -= 10
        ElseIf Sprite = 3 Then
            picPlayer.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Player\Sprite3.gif")
            picPlayer.Left -= 10
        ElseIf Sprite = 4 Then
            picPlayer.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Player\Sprite4.gif")
            picPlayer.Left -= 10
        ElseIf Sprite = 5 Then
            picPlayer.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Player\Sprite5.gif")
            picPlayer.Left -= 10
        ElseIf Sprite = 7 Then
            picPlayer.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Player\Sprite4.gif")
        ElseIf Sprite = 8 Then
            picPlayer.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Player\Sprite1.gif")
        ElseIf Sprite = 13 Then
            picPlayerPoke.Visible = True
            picPlayerPoke.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Images\" & Ash.Bag(PlayerBeingUsed).Name & ".png")
            picGymLeader.Image = Image.FromFile(PathLeader & "1.png")
        ElseIf Sprite > 18 Then
            picPlayer.Top += 15
            picPlayer.Left -= 10
            If picPlayer.Top > 850 Then
                LoadMoves(1)
                ShowThings()
                For i = 1 To 6
                    arrGymBall(i).Visible = True
                    arrPlayerBall(i).Visible = True
                Next
                PictureBox14.Visible = True
            End If
        End If
    End Sub
    Sub LoadMoves(num As Integer)
        TimerThrow.Enabled = False
        lblText.Visible = True
        lblText.SendToBack()
        For i = 1 To 4
            arrMoves(i).Visible = True
            arrMoves(i).Text = Ash.Bag(num).Moves(i).Name
        Next
        cmdAttack.Visible = True
        cmdBag.Visible = True
        cmdSwitch.Visible = True
        lblLeader.Visible = True
        lblPlayer.Visible = True
        lblLeader.Text = GymLeader.Bag(GymBeingUsed).Name
        lblPlayer.Text = Ash.Bag(num).Name
        progLeader.Visible = True
        progPlayer.Visible = True
    End Sub
    Sub PlayerAttack()
        Dim attack As Integer, rnum As Integer, Damage As Integer
        Sprite = 0
        For i = 1 To 4
            If arrMoves(i).Checked = True Then
                attack = i
                Exit For
            End If
        Next
        rnum = Int(Rnd() * Ash.Bag(PlayerBeingUsed).Moves(attack).Accuracy) + 1
        If rnum <= Ash.Bag(PlayerBeingUsed).Moves(attack).Accuracy Then
            'DisplayedText = Ash.Bag(PlayerBeingUsed).Name & " used " & Ash.Bag(PlayerBeingUsed).Moves(attack).Name
            'DisplayText()
            MessageBox.Show(Ash.Bag(PlayerBeingUsed).Name & " used " & Ash.Bag(PlayerBeingUsed).Moves(attack).Name)
            Damage = CheckDamageRate(Ash.Bag(PlayerBeingUsed).Moves(attack).Type, GymLeader.Bag(GymBeingUsed).Type, Ash.Bag(PlayerBeingUsed).Moves(attack).Damage)
            GymLeader.Bag(GymBeingUsed).Health -= Damage
            If GymLeader.Bag(GymBeingUsed).Health <= 0 Then
                MessageBox.Show(GymLeader.Bag(GymBeingUsed).Name & " Defeated")
                GymLeaderLeft -= 1
                arrTopTen.Players(11).Score += 1
                'DisplayedText = GymLeader.Bag(GymBeingUsed).Name & " Defeated"
                'DisplayText()
                For i = (GymLeaderLeft + 1) To 6
                    arrGymBall(i).Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Images\Items\pokeballdark.png")
                Next
                If GymLeaderLeft = 0 Then
                    MessageBox.Show(GymLeader.Name & " has been defeated. Please choose another gym leader")
                    Restart(1)
                    start = 1
                    Exit Sub
                Else
                    GymLeader.Bag(GymBeingUsed).Health = 0
                    progLeader.Value = 0
                    LoadGymPokemon()
                End If
            Else
                progLeader.Value = (GymLeader.Bag(GymBeingUsed).Health * 100) / arrOrigGymHealth(GymBeingUsed)
            End If
        ElseIf rnum > Ash.Bag(PlayerBeingUsed).Moves(attack).Accuracy Then
            MessageBox.Show(Ash.Bag(PlayerBeingUsed).Name & " missed!")
            'DisplayedText = Ash.Bag(PlayerBeingUsed).Name & " missed!"
            'DisplayText()
        End If
        cmdAttack.Enabled = False
        check = 1
        TimerAttack.Enabled = True

    End Sub

    Private Sub TimerAttack_Tick_1(sender As Object, e As EventArgs) Handles TimerAttack.Tick
        Sprite += 1
        If Sprite = 10 Then
            GymAttack(GymBeingUsed)
            TimerAttack.Enabled = False
            Sprite = 0
        End If

    End Sub

    Private Sub cmdBag_Click(sender As Object, e As EventArgs) Handles cmdBag.Click
        Form3.Show()
    End Sub

    Private Sub cmdSwitch_Click(sender As Object, e As EventArgs) Handles cmdSwitch.Click
        Form2.Show()
        Me.Hide()
        For i = 1 To 6
            Form2.arrProg(i).Value = (Ash.Bag(i).Health * 100) / arrOrigPlayerHealth(i)
        Next
        Form3.Revive = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Sprite = 0
        If cmbLeader.Text = "Blaine" Then
            PathLeader = "D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Blaine\"
            picGymLeader.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Blaine\Blaine.png")
            Me.BackgroundImage = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Blaine\Fire.png")
            GymLeader.Name = "Blaine"
            For i = 1 To 6
                GymLeader.FillPokemon(PathLeader & Trim(Str(i)) & ".txt", i)
                arrOrigGymHealth(i) = GymLeader.Bag(i).Health
            Next i
        ElseIf cmbLeader.Text = "Misty" Then
            GymLeader.Name = "Misty"
            PathLeader = "D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Misty\"
            picGymLeader.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Misty\Misty.png")
            Me.BackgroundImage = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Misty\Water.png")
            For i = 1 To 6
                GymLeader.FillPokemon(PathLeader & Trim(Str(i)) & ".txt", i)
                arrOrigGymHealth(i) = GymLeader.Bag(i).Health
            Next i
        ElseIf cmbLeader.Text = "Brock" Then
            GymLeader.Name = "Brock"
            PathLeader = "D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Brock\"
            picGymLeader.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Brock\Brock.png")
            Me.BackgroundImage = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Brock\Rock.png")
            For i = 1 To 6
                GymLeader.FillPokemon(PathLeader & Trim(Str(i)) & ".txt", i)
                arrOrigGymHealth(i) = GymLeader.Bag(i).Health
            Next i
        ElseIf cmbLeader.Text = "Erika" Then
            GymLeader.Name = "Erika"
            PathLeader = "D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Erika\"
            picGymLeader.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Erika\Erika.png")
            Me.BackgroundImage = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Erika\Grass.png")
            For i = 1 To 6
                GymLeader.FillPokemon(PathLeader & Trim(Str(i)) & ".txt", i)
                arrOrigGymHealth(i) = GymLeader.Bag(i).Health
            Next i
        End If
        Hidethings()
        PlayerHealth = Ash.Bag(PlayerBeingUsed).Health
        OpponentHealth = GymLeader.Bag(1).Health
        lblPlayer.Text = Ash.Bag(PlayerBeingUsed).Name
        lblLeader.Text = GymLeader.Bag(1).Name
        progPlayer.Value = (Ash.Bag(PlayerBeingUsed).Health * 100) / arrOrigPlayerHealth(PlayerBeingUsed)
        progLeader.Value = 100
        'picGymLeader.Image = Image.FromFile(PathLeader & "1.png")
        'picPlayerPoke.Image = Image.FromFile("D:\School\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Images\" & Ash.Bag(PlayerBeingUsed).Name & ".png")
        For i = 1 To 6
            arrGymBall(i).Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Images\Items\pokeball.png")
        Next
        TimerMove.Enabled = True
        Button1.Visible = False
        GymLeaderLeft = 6
        GymBeingUsed = 1
    End Sub

    Private Sub cmdTopTen_Click(sender As Object, e As EventArgs) Handles cmdTopTen.Click
        arrTopTen.Sort()
        Form4.lstTopTen.Items.Clear()
        For i = 1 To 10
            Form4.lstTopTen.Items.Add(arrTopTen.Players(i).TopTentostring(i))
        Next
        Form4.Show()
    End Sub

    Sub GymAttack(num As Integer)
        Dim rnum As Integer, RandomMove As Integer, Damage As Integer
        Randomize()
        RandomMove = Int(Rnd() * 4) + 1
        rnum = Int(Rnd() * GymLeader.Bag(GymBeingUsed).Moves(RandomMove).Accuracy) + 1
        If rnum <= GymLeader.Bag(GymBeingUsed).Moves(RandomMove).Accuracy Then
            MessageBox.Show(GymLeader.Bag(GymBeingUsed).Name & " used " & GymLeader.Bag(GymBeingUsed).Moves(RandomMove).Name)
            'DisplayedText = GymLeader.Bag(GymBeingUsed).Name & " used " & GymLeader.Bag(GymBeingUsed).Moves(RandomMove).Name
            'DisplayText()
            Damage = CheckDamageRate(GymLeader.Bag(GymBeingUsed).Moves(RandomMove).Type, Ash.Bag(PlayerBeingUsed).Type, GymLeader.Bag(GymBeingUsed).Moves(RandomMove).Damage)
            Ash.Bag(PlayerBeingUsed).Health -= Damage
            If Ash.Bag(PlayerBeingUsed).Health <= 0 Then
                MessageBox.Show(GymLeader.Bag(GymBeingUsed).Name & " defeated your " & Ash.Bag(PlayerBeingUsed).Name & "!")
                PlayerLeft -= 1
                'DisplayedText = GymLeader.Bag(GymBeingUsed).Name & " defeated your " & Ash.Bag(PlayerBeingUsed).Name & "!"
                'DisplayText()
                For i = (PlayerLeft + 1) To 6
                    arrPlayerBall(i).Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Images\Items\pokeballdark.png")
                Next

                If PlayerLeft = 0 Then
                    MessageBox.Show(Ash.Name & " has run out of usable Pokemon!")
                    Restart(0)
                    start = 0
                    arrTopTen.Players(11).Score = 0
                    Exit Sub
                Else
                    Ash.Bag(PlayerBeingUsed).Health = 0
                    progPlayer.Value = 0
                    PickNewPokemon()
                End If
            Else
                progPlayer.Value = (Ash.Bag(PlayerBeingUsed).Health * 100) / arrOrigPlayerHealth(PlayerBeingUsed)
            End If
        ElseIf rnum > GymLeader.Bag(GymBeingUsed).Moves(RandomMove).Accuracy Then
            MessageBox.Show(GymLeader.Bag(GymBeingUsed).Name & " missed!")
            'DisplayedText = GymLeader.Bag(GymBeingUsed).Name & " missed!"
            'DisplayText()
        End If
        cmdAttack.Enabled = True
        check = 0
    End Sub


    Private Sub cmdAttack_Click(sender As Object, e As EventArgs) Handles cmdAttack.Click
        PlayerAttack()
    End Sub

    Private Sub cmbLeader_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLeader.SelectedIndexChanged
        If cmbLeader.Text = "Blaine" Then
            picLeader.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Blaine\FBlaine.png")
            Me.BackColor = Color.Firebrick
        ElseIf cmbLeader.Text = "Misty" Then
            picLeader.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Misty\FMisty.png")
            Me.BackColor = Color.DeepSkyBlue
        ElseIf cmbLeader.Text = "Brock" Then
            picLeader.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Brock\FBrock.png")
            Me.BackColor = Color.Peru
        ElseIf cmbLeader.Text = "Erika" Then
            picLeader.Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Erika\FErika.png")
            Me.BackColor = Color.Green
        End If
    End Sub

    Private Sub TimerText_Tick(sender As Object, e As EventArgs) Handles TimerText.Tick
        Sprite += 1
        lblText.Text = lblText.Text + Mid(DisplayedText, Sprite, 1)
        If Sprite = Len(DisplayedText) Then
            TimerText.Enabled = False
        End If
    End Sub

    Sub LoadGymPokemon()
        GymBeingUsed += 1
        lblLeader.Text = GymLeader.Bag(GymBeingUsed).Name
        picGymLeader.Image = Image.FromFile(PathLeader & GymBeingUsed & ".png")
        OpponentHealth = GymLeader.Bag(GymBeingUsed).Health
        progLeader.Value = 100
    End Sub
    Sub PickNewPokemon()
        Form2.Show()
        Me.Hide()
        For i = 1 To 6
            Form2.arrProg(i).Value = (Ash.Bag(i).Health * 100) / arrOrigPlayerHealth(i)
        Next
        Form3.Revive = 0
    End Sub
    Function CheckDamageRate(MoveType As String, Pokemontype As String, OriginalDamage As Integer) As Integer
        Dim NewDamage As Integer
        If MoveType = "Grass" And Pokemontype = "Water" Or Pokemontype = "Rock" Then
            NewDamage = OriginalDamage * 2
        ElseIf MoveType = "Fire" And Pokemontype = "Grass" Or Pokemontype = "Bug" Then
            NewDamage = OriginalDamage * 2
        ElseIf MoveType = "Ghost" And Pokemontype = "Psychic" Then
            NewDamage = OriginalDamage * 2
        ElseIf MoveType = "Bug" And Pokemontype = "Grass" Or Pokemontype = "Pyschic" Then
            NewDamage = OriginalDamage * 2
        ElseIf MoveType = "Fighting" And Pokemontype = "Normal" Or Pokemontype = "Rock" Then
            NewDamage = OriginalDamage * 2
        ElseIf MoveType = "Dark" And Pokemontype = "Psychic" Or Pokemontype = "Ghost" Then
            NewDamage = OriginalDamage * 2
        ElseIf MoveType = "Poison" And Pokemontype = "Grass" Then
            NewDamage = OriginalDamage * 2
        ElseIf MoveType = "Dark" And Pokemontype = "Psychic" Then
            NewDamage = OriginalDamage * 2
        ElseIf MoveType = "Electric" And Pokemontype = "Water" Then
            NewDamage = OriginalDamage * 2
        ElseIf MoveType = "Water" And Pokemontype = "Fire" Or Pokemontype = "Rock" Then
            NewDamage = OriginalDamage * 2
        ElseIf MoveType = "Psychic" And Pokemontype = "Fighting" Or Pokemontype = "Poison" Then
            NewDamage = OriginalDamage * 2
        ElseIf MoveType = "Ice" And Pokemontype = "Grass" Or Pokemontype = "Dragon" Then
            NewDamage = OriginalDamage * 2
        ElseIf MoveType = "Grass" And Pokemontype = "Fire" Or Pokemontype = "Grass" Or Pokemontype = "Poison" Or Pokemontype = "Bug" Then
            NewDamage = OriginalDamage * 0.5
        ElseIf MoveType = "Fire" And Pokemontype = "Fire" Or Pokemontype = "Water" Or Pokemontype = "Water" Or Pokemontype = "Rock" Then
            NewDamage = OriginalDamage * 0.5
        ElseIf MoveType = "Bug" And Pokemontype = "Fire" Or Pokemontype = "Fighting" Or Pokemontype = "Posion" Then
            NewDamage = OriginalDamage * 0.5
        ElseIf MoveType = "Fighting" And Pokemontype = "Poison" Or Pokemontype = "Psychic" Or Pokemontype = "Bug" Then
            NewDamage = OriginalDamage * 0.5
        ElseIf MoveType = "Poison" And Pokemontype = "Poison" Or Pokemontype = "Rock" Then
            NewDamage = OriginalDamage * 0.5
        ElseIf MoveType = "Dark" And Pokemontype = "Fighting" Then
            NewDamage = OriginalDamage * 0.5
        ElseIf MoveType = "Electric" And Pokemontype = "Electric" Or Pokemontype = "Grass" Then
            NewDamage = OriginalDamage * 0.5
        ElseIf MoveType = "Water" And Pokemontype = "Water" Or Pokemontype = "Grass" Then
            NewDamage = OriginalDamage * 0.5
        ElseIf MoveType = "Psychic" And Pokemontype = "Psychic" Then
            NewDamage = OriginalDamage * 0.5
        ElseIf MoveType = "Ice" And Pokemontype = "Fire" Or Pokemontype = "Water" Or Pokemontype = "Ice" Then
            NewDamage = OriginalDamage * 0.5
        Else
            NewDamage = OriginalDamage
        End If
        CheckDamageRate = NewDamage
    End Function

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            For i = 1 To 12
                arrChks(i).Visible = True
            Next
            GroupBox1.Visible = True
            cmbLeader.Visible = True
            cmdStart.Visible = True
            PictureBox13.Visible = True
            cmdTopTen.Visible = True
            Me.BackgroundImage = Nothing
            picLeader.Visible = True
            Me.BackColor = Color.Gold
            'Ash.Name = InputBox("Please enter your name.", "Name", "Ash")
        End If
    End Sub
    Sub DisplayText()
        For i = 1 To 4
            arrMoves(i).Visible = False
        Next
        cmdAttack.Visible = False
        cmdBag.Visible = False
        cmdSwitch.Visible = False
        TimerText.Enabled = True
        lblText.Text = Nothing
        Sprite = 0
    End Sub
    Sub Restart(num As Integer)
        If num = 0 Then
            cmdStart.Visible = True
            cmbLeader.Visible = True
            GroupBox1.Visible = True
            Button1.Visible = False
            For i = 1 To 12
                arrChks(i).Visible = True
            Next
            PictureBox1.Visible = True
            PictureBox2.Visible = True
            PictureBox3.Visible = True
            PictureBox4.Visible = True
            PictureBox5.Visible = True
            PictureBox6.Visible = True
            PictureBox7.Visible = True
            PictureBox9.Visible = True
            PictureBox10.Visible = True
            PictureBox11.Visible = True
            PictureBox12.Visible = True
            PictureBox13.Visible = True
            Form3.SuperCount = 3
            Form3.BasicCount = 5
            Form3.ReviveCount = 1
        ElseIf num = 1 Then
            cmbLeader.Visible = True
            cmdStart.Visible = False

            Button1.Visible = True
            'MessageBox.Show("i")

        End If
        For i = 1 To 6
            arrGymBall(i).Visible = False
            arrPlayerBall(i).Visible = False
            arrGymBall(i).Image = Image.FromFile("D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\Images\Items\pokeball.png")
        Next
        picLeader.Visible = True
        PictureBox13.Visible = True
        picPlayerPoke.SendToBack()
        picLeader.Image = Nothing
        picGymLeader.Visible = True
        picGymLeader.Image = Nothing
        picPlayer.Left = 2000
        picPlayer.Top = 369
        picGymLeader.Left = 2507
        picGymLeader.Top = 65
        cmdTopTen.Visible = True
        picPlayerPoke.Image = Nothing
        Me.BackColor = Color.Gold
        Me.BackgroundImage = Nothing
        lblText.Visible = False
        cmdAttack.Visible = False
        cmdSwitch.Visible = False
        cmdBag.Visible = False
        progPlayer.Visible = False
        progLeader.Visible = False
        For i = 1 To 4
            arrMoves(i).Visible = False
        Next
        lblPlayer.Visible = False
        lblLeader.Visible = False
        arrTopTen.Sort()
        Form4.lstTopTen.Items.Clear()
        For i = 1 To 10
            Form4.lstTopTen.Items.Add(arrTopTen.Players(i).TopTentostring(i))
        Next
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Dim x As Integer
        FileOpen(1, "D:\School\Computer Science\Computer Programming II\VB.Net Projects\Pokemon\Pokemon\TopTen\TopTen.txt", OpenMode.Output)
        For i = 1 To 10
            PrintLine(1, arrTopTen.Players(i).Name)
            PrintLine(1, Str(arrTopTen.Players(i).Score))
            'MessageBox.Show(arrTopTen.Players(i).Name)
            'MessageBox.Show(arrTopTen.Players(i).Score)
        Next i
        FileClose(1)

    End Sub
End Class
