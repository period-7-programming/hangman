' SUGGEST: Make sure you add spacing to your code for readability.
Public Class Form1
    ' SUGGEST: Be careful when calling user interface "things" with global variables. It is hard to predict when this inputbox will occur. Consider moving this elsewhere.
    Dim inputWord As String = InputBox("Input word", "Select Word",)
    Dim word(inputWord.Length - 1) As String
    ' SUGGEST: Consider using a boolean array here. As a general practice don't use strings (or arrays of them) to store data.
    Dim displayed(word.Length) As String
    ' SUGGEST: This may be better as a list. We'll discuss this in class on Tuesday.
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
            ' SUGGEST: Store this in a list. We'll discuss this in class on Tuesday.
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
        ' SUGGEST: Why the spaces? Also, if you are going to create lots of spaces look into visual basic's space function!
        If gameWon = True Then 'pops up message box with restart, quit on game win
            MessageBox.Show("You Win                                             ", "You Are A Winner")
        End If
        If bodyParts >= 7 Then 'pops up message box with restart, quit on game lose
            MessageBox.Show("You Lose                                             ", "You Are A Loser")
        End If
    End Sub
    ' SUGGEST: Make sure to paint in OnPaint events. Otherwise odd things can happen if the window gets updated by the system.
    Private Sub draw()
        Dim brownPen As New Pen(Color.Brown, 3)
        Dim thickPen As New Pen(Color.Black, 3)
        Dim BlackPen As New Pen(Color.Black, 1)
        Dim blackFill As New SolidBrush(Color.Black)
        Dim whiteFill As New SolidBrush(Color.White)
        Dim formSurface As Graphics = CreateGraphics()
        If bodyParts = 1 Then 'draws stand, head
            'draws stand
            formSurface.DrawLine(brownPen, 95, 150, 95, 100)
            formSurface.DrawLine(brownPen, 97, 100, 29, 100)
            formSurface.DrawEllipse(brownPen, 90, 150, 10, 20)
            formSurface.DrawLine(brownPen, 30, 100, 30, 300)
            formSurface.DrawLine(brownPen, 20, 300, 120, 300)
            'draws head
            formSurface.FillEllipse(whiteFill, 82, 140, 25, 25)
            formSurface.DrawEllipse(BlackPen, 82, 140, 25, 25)
        ElseIf bodyParts = 2 Then 'draws body
            formSurface.DrawLine(BlackPen, 95, 165, 95, 220)
        ElseIf bodyParts = 3 Then 'draws left arm
            formSurface.DrawLine(BlackPen, 95, 170, 80, 210)
        ElseIf bodyParts = 4 Then ' draws right arm
            formSurface.DrawLine(BlackPen, 95, 170, 110, 210)
        ElseIf bodyParts = 5 Then 'draws left leg
            formSurface.DrawLine(BlackPen, 95, 220, 80, 260)
        ElseIf bodyParts = 6 Then 'draws right leg
            formSurface.DrawLine(BlackPen, 95, 220, 110, 260)
        ElseIf bodyParts = 7 Then 'draws hat
            formSurface.DrawLine(thickPen, 80, 145, 110, 145)
            formSurface.FillRectangle(blackFill, 85, 120, 20, 25)
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim randomWords() As String = {"Hello", "Cat", "Car", "Moist", "Cake", "Confuse", "Internet Explorer", "Slop", "Evasive", "Trade"}
        Randomize()
        Dim randomword As String = randomWords(Math.Floor(10 * Rnd()))
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
    ' SUGGEST: You might not need to restart the entire application...
    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        Application.Restart()
    End Sub
End Class