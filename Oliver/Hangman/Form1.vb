Public Class Hangman
    Dim inputWord As String = InputBox("Input your word. Leave blank if you want to use a random word.", "Select a Word", )
    Dim displayWordArray(inputWord.Length * 2) As String
    Dim wordArray(inputWord.Length) As String

    Private Sub Hangman_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim displayString As String
        lblLetters.Text = Nothing

        If inputWord = Nothing Then
            'inputWord =    is set to random word
        End If

        For stringIndex As Integer = 0 To inputWord.Length - 1
            wordArray(stringIndex) = UCase(inputWord.Chars(stringIndex))
            displayWordArray((stringIndex + 1) * 2 - 1) = "_"
            displayWordArray((stringIndex + 1) * 2) = " "
            displayString = displayString & "_ "
        Next stringIndex

        lblLetters.Text = RTrim(displayString)
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim correct As Boolean = False
        Dim labelOutput As String = Nothing
        If txtGuess.Text = Nothing Then

        Else
            For arrayIndex As Integer = 0 To (inputWord.Length - 1)
                If UCase(txtGuess.Text) = wordArray(arrayIndex) Then
                    displayWordArray((arrayIndex + 1) * 2 - 1) = wordArray(arrayIndex)
                    correct = True
                End If
                labelOutput = labelOutput & displayWordArray((arrayIndex + 1) * 2 - 1) & " "
            Next arrayIndex
            lblLetters.Text = RTrim(labelOutput)
            If correct = False Then
                'loose life
                If lblWrongGuesses.Text = Nothing Then
                    lblWrongGuesses.Text = UCase(txtGuess.Text)
                Else
                    lblWrongGuesses.Text = lblWrongGuesses.Text & ", " & UCase(txtGuess.Text)
                End If
            End If
            txtGuess.Text = Nothing
        End If
    End Sub

End Class