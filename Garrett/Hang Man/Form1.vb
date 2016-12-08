Imports System.IO
Imports System.Diagnostics
Public Class HangManGarrett

    'get the drawing to work

    Dim randomWordStream As New FileStream("dictionary.txt", FileMode.Open, FileAccess.Read)
    Dim randomWordReader As New StreamReader(randomWordStream)

    Dim word() As String
    Dim displayedBoolean() As Boolean ' true = its been guessed - false it hasn't been guessed
    Dim wrongGuesses As String
    Dim bodyParts As Integer = 0 'when its equal to 7 you lose
    Dim gamelost As Boolean = False

    Public Sub btnGuess_Click(sender As Object, e As EventArgs) Handles btnGuess.Click
        If gamelost = False Then
            Dim Input As String = UCase(txtInput.Text)
            Dim GuessedWrong As Boolean = True 'assuming the person guessed wrong
            Dim gameWon As Boolean = True 'assuming game is one/won/1 unitl code below proves this wrong
            Dim sameGuess As Boolean = False 'assuming that they guessed right

            If wrongGuesses IsNot Nothing Then
                If wrongGuesses.Contains(Input) Then
                    sameGuess = True
                End If
            End If

            For i As Integer = 0 To word.Length - 1
                If (displayedBoolean(i) = True) And (word(i) = Input) Then
                    sameGuess = True
                End If
            Next

            If sameGuess = False Then

                lblWord.Text = Nothing
                For i As Integer = 0 To word.Length - 1
                    If Input = word(i) Then 'checks if input is equal to any of the letters in the word, if so it adds the input to the displayed word
                        displayedBoolean(i) = True
                        GuessedWrong = False 'used in below if, set to false when the person guessed right
                    End If
                Next

            Else

                MessageBox.Show("Duplicate Guess" & Space(45), "You Already Guessed That Character.")

            End If

            If ((GuessedWrong = True) And (sameGuess = False)) Then
                bodyParts += 1
                lblWrongGuesses.Text += UCase(txtInput.Text) + " "
                wrongGuesses += UCase(txtInput.Text) + " "
            End If



            For i As Integer = 0 To word.Length - 1
                If displayedBoolean(i) = False Then
                    gameWon = False
                End If
            Next

            lblWord.Text = RTrim(lblWord.Text)
            txtInput.Text = Nothing
            lblWordUpdate()


            If gameWon = True Then 'pops up message box with restart, quit on game win
                MessageBox.Show("You Win" & Space(45), "You Are A Winner, Press Restart If You Want To Play Again.")
            End If
            If bodyParts >= 7 Then 'pops up message box with restart, quit on game lose
                MessageBox.Show("You Lose" & Space(45), "You Are A Loser, Press Restart If You Want To Play Again.")
                gamelost = True
            End If
        End If

        If gamelost = True Then
            lblWord.Text = Nothing
            For i As Integer = 0 To word.Length - 1
                displayedBoolean(i) = True
            Next
            lblWordUpdate()
        End If
        Refresh()
    End Sub

    Private Function RandomWords()
        Randomize()
        Dim randomword As String = Nothing
        Dim lineAmmount As String() = File.ReadAllLines("dictionary.txt")
        Dim linenumber As Integer = Math.Floor((lineAmmount.Length - 1) * Rnd())
        Debug.Print(linenumber)

        randomword = lineAmmount(linenumber)

        Return randomword
    End Function

    Private Sub lblWordUpdate()
        lblWord.Text = Nothing
        For i As Integer = 0 To word.Length - 1
            If displayedBoolean(i) = False Then
                lblWord.Text += "- "
            Else
                lblWord.Text += word(i) + " "
            End If
        Next

    End Sub



    Private Sub LoadForm()
        gamelost = False
        lblWord.Text = Nothing
        wrongGuesses = Nothing
        lblWrongGuesses.Text = Nothing
        PictureBox1.Image = Nothing
        bodyParts = 0

        Dim inputWord As String = InputBox("Input your own word or a random word will be slected.", "Input Word",)
        Dim chosenWord As String

        If inputWord.Length < 1 Then 'takes the inputbox input and puts it into word() if input is longer than one letter
            chosenWord = RandomWords()
        Else
            chosenWord = inputWord
        End If


        ReDim word(chosenWord.Length - 1) 'the length is always 1 more than the length of the string that i give it that is why i have3 the, -1
        ReDim displayedBoolean(word.Length)

        For inputIndex As Integer = 0 To chosenWord.Length - 1
            word(inputIndex) = UCase(chosenWord.Chars(inputIndex))
        Next
        'loads the displayed array with "- " for however long the word is
        For i As Integer = 0 To word.Length - 1
            displayedBoolean(i) = False

        Next
        lblWordUpdate()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadForm()
    End Sub

    Public Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        LoadForm()
    End Sub

    Private Sub HangManGarrett_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim brownPen As New Pen(Color.Brown, 3)
        Dim thickPen As New Pen(Color.Black, 3)
        Dim BlackPen As New Pen(Color.Black, 1)
        Dim blackFill As New SolidBrush(Color.Black)
        Dim whiteFill As New SolidBrush(Color.White)
        Dim formSurface As Graphics = PictureBox1.CreateGraphics
        'draws stand
        formSurface.DrawLine(brownPen, 95, 100, 95, 50)
        formSurface.DrawLine(brownPen, 97, 50, 29, 50)
        formSurface.DrawEllipse(brownPen, 90, 100, 10, 20)
        formSurface.DrawLine(brownPen, 30, 50, 30, 250)
        formSurface.DrawLine(brownPen, 20, 250, 120, 250)
        If bodyParts >= 1 Then 'draws head
            formSurface.FillEllipse(whiteFill, 82, 90, 25, 25)
            formSurface.DrawEllipse(BlackPen, 82, 90, 25, 25)
        End If
        If bodyParts >= 2 Then 'draws body
            formSurface.DrawLine(BlackPen, 95, 115, 95, 170)
        End If
        If bodyParts >= 3 Then 'draws left arm
            formSurface.DrawLine(BlackPen, 95, 120, 80, 160)
        End If
        If bodyParts >= 4 Then ' draws right arm
            formSurface.DrawLine(BlackPen, 95, 120, 110, 160)
        End If
        If bodyParts >= 5 Then 'draws left leg
            formSurface.DrawLine(BlackPen, 95, 170, 80, 210)
        End If
        If bodyParts >= 6 Then 'draws right leg
            formSurface.DrawLine(BlackPen, 95, 170, 110, 210)
        End If
        If bodyParts >= 7 Then 'draws hat
            formSurface.DrawLine(thickPen, 80, 95, 110, 95)
            formSurface.FillRectangle(blackFill, 85, 70, 20, 25)
        End If
    End Sub
End Class