Imports System.IO

Public Class Hangman
    Dim inputWord As String = InputBox("Input your word. Leave blank if you want to use a random word.", "Select a Word", )
    Dim wordArray(inputWord.Length - 1) As String
    Dim displayWordArray(inputWord.Length - 1) As Boolean
    Dim incorrectGuesses As Integer = 0
    Dim playing As Boolean

    Private Sub Hangman_Load(sender As Object, e As EventArgs) Handles Me.Load
        playing = True
        Dim displayString As String = Nothing
        If inputWord = Nothing Then 'Sets random word if no word is specified
            inputWord = randomWord()
            ReDim wordArray(inputWord.Length - 1)
            ReDim displayWordArray(inputWord.Length - 1)
        End If
        lblLetters.Text = Nothing
        For stringIndex As Integer = 0 To inputWord.Length - 1 'Defines arrays for the word and for the progress
            wordArray(stringIndex) = UCase(inputWord.Chars(stringIndex))
            displayWordArray(stringIndex) = False
            displayString = displayString & "_ "
        Next stringIndex
        lblLetters.Text = RTrim(displayString)
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim correct As Boolean = False
        Dim labelOutput As String = Nothing
        Dim output As String = Nothing
        If (txtGuess.Text IsNot Nothing) And (playing = True) And (lblWrongGuesses.Text.Contains(UCase(txtGuess.Text)) = False) And (lblLetters.Text.Contains(UCase(txtGuess.Text)) = False) Then
            For arrayIndex As Integer = 0 To (inputWord.Length - 1) 'Check Guess
                If UCase(txtGuess.Text) = wordArray(arrayIndex) Then
                    displayWordArray(arrayIndex) = True
                    correct = True
                End If
            Next arrayIndex
            For characterIndex As Integer = 0 To (inputWord.Length - 1) 'update label output text
                If displayWordArray(characterIndex) = True Then
                    output = output & wordArray(characterIndex) & " "
                Else
                    output = output & "_ "
                End If
            Next
            lblLetters.Text = RTrim(output)
            If correct = False Then 'Deals with incorrect guess
                incorrectGuesses += 1
                If lblWrongGuesses.Text = Nothing Then 'Adds guess to label of wrong guesses
                    lblWrongGuesses.Text = UCase(txtGuess.Text)
                Else
                    lblWrongGuesses.Text = lblWrongGuesses.Text & ", " & UCase(txtGuess.Text)
                End If
            End If
            CheckWin()
            If incorrectGuesses = 6 Then
                labelOutput = Nothing
                For index As Integer = 0 To inputWord.Length - 1 'Finishes word
                    labelOutput = labelOutput & wordArray(index) & " "
                Next index
                lblLetters.Text = RTrim(labelOutput)
                MessageBox.Show("You lose" & Space(30), "Game Over") 'Lose popup
                playing = False
            End If
            txtGuess.Text = Nothing
        ElseIf (playing = True) And ((txtGuess.Text IsNot "") = True) Then
            MessageBox.Show("You have already guessed this character.", "Notification", MessageBoxButtons.OK)
            txtGuess.Text = Nothing
        ElseIf playing = False Then
            MessageBox.Show("Game is over. Press New Game for a new game.", "Notification", MessageBoxButtons.OK)
            txtGuess.Text = Nothing
        Else
            MessageBox.Show("Please enter a guess.", "Notification", MessageBoxButtons.OK)
        End If
        Refresh()
    End Sub

    Private Sub CheckWin()
        If Array.IndexOf(displayWordArray, False) = -1 Then 'Check if they won
            MessageBox.Show("You Win" & Space(30), "Victory") 'Win popup
            playing = False
        End If
    End Sub

    Private Sub btnNewGame_Click(sender As Object, e As EventArgs) Handles btnNewGame.Click
        inputWord = InputBox("Input your word. Leave blank if you want to use a random word.", "Select a Word", )
        playing = True
        Dim displayString As String = Nothing
        If inputWord = Nothing Then 'Sets random word if no word is specified
            inputWord = randomWord()
            ReDim wordArray(inputWord.Length - 1)
            ReDim displayWordArray(inputWord.Length - 1)
        End If
        ReDim displayWordArray(inputWord.Length - 1)
        ReDim wordArray(inputWord.Length - 1)
        lblLetters.Text = Nothing
        For stringIndex As Integer = 0 To inputWord.Length - 1 'Defines arrays for the word and for the progress
            wordArray(stringIndex) = UCase(inputWord.Chars(stringIndex))
            displayWordArray(stringIndex) = False
            displayString = displayString & "_ "
        Next stringIndex
        lblLetters.Text = RTrim(displayString)
        incorrectGuesses = 0
        lblWrongGuesses.Text = Nothing
    End Sub

    Private Sub Hangman_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim surface As Graphics = ptbHangman.CreateGraphics
        Dim pen1 As New Pen(Color.Black, 5)
        Dim pen2 As New Pen(Color.Black, 2)

        If incorrectGuesses >= 1 Then 'Updates drawing depending on number of wrong guesses
            surface.DrawLine(pen1, 10, 170, 60, 170) 'Stand
            surface.DrawLine(pen1, 35, 170, 35, 15)
            surface.DrawLine(pen1, 20, 170, 35, 150)
            surface.DrawLine(pen1, 35, 150, 50, 170)
        End If
        If incorrectGuesses >= 2 Then
            surface.DrawLine(pen1, 35, 15, 87, 15) 'Stand Arm
            surface.DrawLine(pen1, 85, 15, 85, 30)
            surface.DrawLine(pen1, 35, 25, 65, 15)
        End If
        If incorrectGuesses >= 3 Then 'head & torso
            surface.DrawEllipse(pen1, 70, 30, 30, 30)
            surface.DrawLine(pen1, 85, 60, 85, 115)
        End If
        If incorrectGuesses >= 4 Then 'legs
            surface.DrawLine(pen1, 85, 115, 65, 145)
            surface.DrawLine(pen1, 85, 115, 105, 145)
        End If
        If incorrectGuesses >= 5 Then 'arms
            surface.DrawLine(pen1, 85, 75, 55, 55)
            surface.DrawLine(pen1, 85, 75, 115, 55)
        End If
        If incorrectGuesses >= 6 Then 'eyes
            surface.DrawLine(pen2, 76, 39, 82, 45) 'eye1
            surface.DrawLine(pen2, 76, 45, 82, 39)
            surface.DrawLine(pen2, 87, 39, 93, 45) 'eye2
            surface.DrawLine(pen2, 87, 45, 93, 39)
        End If
    End Sub

    Private Function randomWord()
        Dim randomWordsStream As New FileStream("dictionary.txt", FileMode.Open, FileAccess.Read)
        Dim randomWordsReader As New StreamReader(randomWordsStream)
        Dim lineCount As Integer = File.ReadAllLines("dictionary.txt").Length
        Dim lineNumber As Integer = Math.Floor(lineCount * Rnd()) + 1
        Dim word As String = Nothing

        For currentLineNumber As Integer = 0 To lineNumber
            word = randomWordsReader.ReadLine()
        Next
        Return word
    End Function
End Class