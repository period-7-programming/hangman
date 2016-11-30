﻿Imports System.IO
Public Class Form1

    Dim randomWordStream As New FileStream("dictionary.txt", FileMode.Open, FileAccess.Read)
    Dim randomWordReader As New StreamReader(randomWordStream)

    Dim word() As String
    Dim displayed() As String
    Dim wrongGuesses As String
    Dim bodyParts As Integer = 0 'when its equal to 7 you lose

    Public Sub btnGuess_Click(sender As Object, e As EventArgs) Handles btnGuess.Click
        Dim Input As String = UCase(txtInput.Text)
        lblWord.Text = Nothing
        Dim GuessedWrong As Boolean = True 'assuming the person guessed wrong
        Dim gameWon As Boolean = True 'assuming game is one unitl code below proves this wrong
        For i As Integer = 0 To word.Length - 1
            If Input = word(i) Then 'checks if input is equal to any of the letters in the word, if so it adds the input to the displayed word
                lblWord.Text += Input + " "
                displayed(i) = Input + " "
                GuessedWrong = False 'used in below if, set to false when the person guessed right
            ElseIf (displayed(i) Is "- ") Then 'checks if there a letter in displayed(i), if not it adds a dash to the displayed word
                lblWord.Text += "- "
            Else 'if there is already a letter in displayed(i) it adds that letter to the displayed word
                lblWord.Text += displayed(i)
            End If
        Next
        If GuessedWrong = True Then
            wrongGuesses += UCase(txtInput.Text) + " "
            lblWrongGuesses.Text += UCase(txtInput.Text) + " "
            bodyParts += 1
        End If
        For i As Integer = 0 To word.Length - 1
            If displayed(i) = "- " Then
                gameWon = False
            End If
        Next
        lblWord.Text = RTrim(lblWord.Text)
        txtInput.Text = Nothing
        draw()
        If gameWon = True Then 'pops up message box with restart, quit on game win
            MessageBox.Show("You Win" & Space(45), "You Are A Winner")
        End If
        If bodyParts >= 7 Then 'pops up message box with restart, quit on game lose
            MessageBox.Show("You Lose" & Space(45), "You Are A Loser")
        End If
    End Sub

    Private Sub draw()
        Dim brownPen As New Pen(Color.Brown, 3)
        Dim thickPen As New Pen(Color.Black, 3)
        Dim BlackPen As New Pen(Color.Black, 1)
        Dim blackFill As New SolidBrush(Color.Black)
        Dim whiteFill As New SolidBrush(Color.White)
        Dim formSurface As Graphics = PictureBox1.CreateGraphics
        If bodyParts = 1 Then 'draws stand, head
            'draws stand
            formSurface.DrawLine(brownPen, 95, 100, 95, 50)
            formSurface.DrawLine(brownPen, 97, 50, 29, 50)
            formSurface.DrawEllipse(brownPen, 90, 100, 10, 20)

            formSurface.DrawLine(brownPen, 30, 50, 30, 250)
            formSurface.DrawLine(brownPen, 20, 250, 120, 250)
            'draws head
            formSurface.FillEllipse(whiteFill, 82, 90, 25, 25)
            formSurface.DrawEllipse(BlackPen, 82, 90, 25, 25)
        ElseIf bodyParts = 2 Then 'draws body
            formSurface.DrawLine(BlackPen, 95, 115, 95, 170)
        ElseIf bodyParts = 3 Then 'draws left arm
            formSurface.DrawLine(BlackPen, 95, 120, 80, 160)
        ElseIf bodyParts = 4 Then ' draws right arm
            formSurface.DrawLine(BlackPen, 95, 120, 110, 160)
        ElseIf bodyParts = 5 Then 'draws left leg
            formSurface.DrawLine(BlackPen, 95, 170, 80, 210)
        ElseIf bodyParts = 6 Then 'draws right leg
            formSurface.DrawLine(BlackPen, 95, 170, 110, 210)
        ElseIf bodyParts = 7 Then 'draws hat
            formSurface.DrawLine(thickPen, 80, 95, 110, 95)
            formSurface.FillRectangle(blackFill, 85, 70, 20, 25)
        End If
    End Sub

    Private Function RandomWords()
        Randomize()
        Dim randomword As String = Nothing
        Dim lineAmmount As Integer = File.ReadAllLines("dictionary.txt").Length
        Dim linenumber As Integer = Math.Floor((lineAmmount - 1) * Rnd())
        For i As Integer = 0 To linenumber
            randomword = randomWordReader.ReadLine()
        Next
        Return randomword
    End Function

    
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim inputWord As String = InputBox("InputWord", "Input Word",)

        Dim randomword As String = RandomWords()
        If inputword.Length < 1 Then 'takes the inputbox input and puts it into word() if input is longer than one letter
            ReDim word(randomword.Length - 1)
            ReDim displayed(word.Length)
            For inputIndex As Integer = 0 To randomword.Length - 1
                word(inputIndex) = UCase(randomword.Chars(inputIndex))
            Next
            'loads the displayed array with "- " for however long the word is
            For i As Integer = 0 To word.Length - 1
                displayed(i) = "- "
                lblWord.Text += displayed(i)
            Next
            lblWord.Text = RTrim(lblWord.Text)
        Else
            ReDim word(inputWord.Length - 1)
            ReDim displayed(word.Length)
            For inputIndex As Integer = 0 To inputword.Length - 1
                word(inputIndex) = UCase(inputWord.Chars(inputIndex))
            Next
            'loads the displayed array with "- " for however long the word is
            For i As Integer = 0 To word.Length - 1
                displayed(i) = "- "
                lblWord.Text += displayed(i)
            Next
            lblWord.Text = RTrim(lblWord.Text)
        End If
    End Sub

    Public Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        lblWord.Text = Nothing
        wrongGuesses = Nothing
        lblWrongGuesses.Text = Nothing
        PictureBox1.Image = Nothing
        bodyParts = 0
        Dim inputWord As String = InputBox("InputWord", "Input Word",)
        Dim randomword As String = RandomWords()
        If inputWord.Length < 1 Then 'takes the inputbox input and puts it into word() if input is longer than one letter
            ReDim word(randomword.Length - 1)
            ReDim displayed(word.Length)
            For inputIndex As Integer = 0 To randomword.Length - 1
                word(inputIndex) = UCase(randomword.Chars(inputIndex))
            Next
            'loads the displayed array with "- " for however long the word is
            For i As Integer = 0 To word.Length - 1
                displayed(i) = "- "
                lblWord.Text += displayed(i)
            Next
            lblWord.Text = RTrim(lblWord.Text)
        Else
            ReDim word(inputWord.Length - 1)
            ReDim displayed(word.Length)
            For inputIndex As Integer = 0 To inputWord.Length - 1
                word(inputIndex) = UCase(inputWord.Chars(inputIndex))
            Next
            'loads the displayed array with "- " for however long the word is
            For i As Integer = 0 To word.Length - 1
                displayed(i) = "- "
                lblWord.Text += displayed(i)
            Next
            lblWord.Text = RTrim(lblWord.Text)
        End If
    End Sub
End Class