Public Class Hangman
    Dim inputWord As String = InputBox("Input your word. Leave blank if you want to use a random word.", "Select a Word", )
    Dim wordArray(inputWord.Length - 1) As String
    Dim displayWordArray(inputWord.Length * 2 - 1) As String
    Dim incorrectGuesses As Integer = 0
    Dim randomWords() As String = {"rich", "wage", "cat", "exit", "hay", "tube", "inside", "urgency", "company", "team", "art", "rice", "plane", "fear", "talk"}

    Private Sub Hangman_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim displayString As String = Nothing
        Dim randomNumber As Integer
        If inputWord = Nothing Then 'Sets random word if no word is specified
            Randomize()
            randomNumber = Math.Floor((15) * Rnd())
            inputWord = randomWords(randomNumber)
            ReDim displayWordArray(inputWord.Length * 2 - 1)
            ReDim wordArray(inputWord.Length - 1)
        End If
        lblLetters.Text = Nothing
        For stringIndex As Integer = 0 To inputWord.Length - 1 'Defines arrays for the word and for the progress
            wordArray(stringIndex) = UCase(inputWord.Chars(stringIndex))
            displayWordArray((stringIndex + 1) * 2 - 2) = "_"
            displayWordArray(stringIndex * 2 + 1) = " "
            displayString = displayString & "_ "
        Next stringIndex
        lblLetters.Text = RTrim(displayString)
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim correct As Boolean = False
        Dim labelOutput As String = Nothing
        ' SUGGEST: Empty if statement? Use the 'not equal' operator.
        If txtGuess.Text = Nothing Then

        Else
            For arrayIndex As Integer = 0 To (inputWord.Length - 1) 'Check Guess
                If UCase(txtGuess.Text) = wordArray(arrayIndex) Then
                    ' SUGGEST: I would suggest not using a string array to store the "output".
                    ' Instead, consider generating the output based on a boolean array or something similar.
                    ' Relying on spaces to be in the array, etc. can get messy and hard to debug quickly.
                    displayWordArray(arrayIndex * 2) = wordArray(arrayIndex)
                    correct = True
                End If
                labelOutput = labelOutput & displayWordArray(arrayIndex * 2) & " "
            Next arrayIndex
            lblLetters.Text = RTrim(labelOutput)
            If correct = False Then 'Deals with incorrect guess
                incorrectGuesses += 1
                If lblWrongGuesses.Text = Nothing Then 'Adds guess to label of wrong guesses
                    lblWrongGuesses.Text = UCase(txtGuess.Text)
                Else
                    lblWrongGuesses.Text = lblWrongGuesses.Text & ", " & UCase(txtGuess.Text)
                End If
            End If
            txtGuess.Text = Nothing
        End If
        CheckWin()
        ' SUGGEST: Only paint in a paint method, so the painting persists between window updates.
        DisplayHangman()
    End Sub

    Private Sub DisplayHangman()
        If incorrectGuesses = 1 Then 'Updates drawing depending on number of wrong guesses
            Stand()
        ElseIf incorrectGuesses = 2 Then
            StandArm()
        ElseIf incorrectGuesses = 3 Then
            HeadAndTorso()
        ElseIf incorrectGuesses = 4 Then
            Legs()
        ElseIf incorrectGuesses = 5 Then
            Arms()
        ElseIf incorrectGuesses = 6 Then
            Eyes()
        End If
    End Sub

    Private Sub Stand()
        Dim surface As Graphics = Me.CreateGraphics
        Dim pen1 As New Pen(Color.Black, 5)
        surface.DrawLine(pen1, 10, 250, 60, 250)
        surface.DrawLine(pen1, 35, 250, 35, 75)
        surface.DrawLine(pen1, 20, 250, 35, 230)
        surface.DrawLine(pen1, 35, 230, 50, 250)
    End Sub

    Private Sub StandArm()
        Dim surface As Graphics = Me.CreateGraphics
        Dim pen1 As New Pen(Color.Black, 5)
        surface.DrawLine(pen1, 35, 75, 87, 75)
        surface.DrawLine(pen1, 85, 75, 85, 100)
        surface.DrawLine(pen1, 35, 105, 65, 75)
    End Sub

    Private Sub HeadAndTorso()
        Dim surface As Graphics = Me.CreateGraphics
        Dim pen1 As New Pen(Color.Black, 4)
        surface.DrawEllipse(pen1, 70, 100, 30, 30)
        surface.DrawLine(pen1, 85, 130, 85, 184)
    End Sub

    Private Sub Arms()
        Dim surface As Graphics = Me.CreateGraphics
        Dim pen1 As New Pen(Color.Black, 4)
        surface.DrawLine(pen1, 85, 140, 55, 135)
        surface.DrawLine(pen1, 85, 140, 115, 135)

    End Sub

    Private Sub Legs()
        Dim surface As Graphics = Me.CreateGraphics
        Dim pen1 As New Pen(Color.Black, 4)
        surface.DrawLine(pen1, 85, 180, 65, 210) 'legs
        surface.DrawLine(pen1, 85, 180, 105, 210)
    End Sub

    Private Sub Eyes()
        Dim surface As Graphics = Me.CreateGraphics
        Dim pen1 As New Pen(Color.Black, 2)
        Dim output As String = Nothing
        surface.DrawLine(pen1, 76, 109, 82, 115) 'eye1
        surface.DrawLine(pen1, 76, 115, 82, 109)
        surface.DrawLine(pen1, 87, 109, 93, 115) 'eye2
        surface.DrawLine(pen1, 87, 115, 93, 109)
        For index As Integer = 0 To inputWord.Length - 1 'Finishes word
            output = output & wordArray(index) & " "
        Next index
        lblLetters.Text = RTrim(output)
        ' SUGGEST: Don't mix game logic with painting. Keep things seperate if possible.
        MessageBox.Show("You lose                                   ", "Game Over") 'Lose popup
    End Sub

    Private Sub CheckWin()
        If Array.IndexOf(displayWordArray, "_") = -1 Then 'Check if they won
            MessageBox.Show("You Win                                   ", "Victory") 'Win popup
        End If
    End Sub

    Private Sub btnNewGame_Click(sender As Object, e As EventArgs) Handles btnNewGame.Click
        ' SUGGEST: Do you need to restart the whole application?
        Application.Restart()
    End Sub
End Class