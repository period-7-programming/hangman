Public Class Form1

    Dim inputWord As String = InputBox("Input word", "Select Word",)

    Dim word() = New String() {"H", "E", "L", "L", "O"}
    Dim displayed() = New String(word.Length) {}



    Public Sub btnGuess_Click(sender As Object, e As EventArgs) Handles btnGuess.Click

        Dim Input As String = UCase(txtInput.Text)

        Dim wrongGuess As Boolean = False
        Dim Checked As Boolean = False

        lblWord.Text = Nothing


        Do Until i As Integer = 0 To word.Length - 1

            If Checked = False Then

                If Input = word(i) Then

                    displayed(i) = Input + " "
                    Checked = True

                Else

                    wrongGuess = True
                    Checked = True

                End If

            End If
            lblWord.Text += displayed(i)
        Loop

        If wrongGuess = True Then
            lblWrongGuesses.Text += Input + " "
            wrongGuess = False
        End If

        Checked = False

        lblWord.Text = RTrim(lblWord.Text)
        txtInput.Text = Nothing

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        For i As Integer = 0 To word.Length - 1
            displayed(i) = "- "
            lblWord.Text += displayed(i)

        Next

        lblWord.Text = RTrim(lblWord.Text)

    End Sub

End Class