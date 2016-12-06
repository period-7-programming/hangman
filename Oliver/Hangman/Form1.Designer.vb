<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Hangman
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblLetters = New System.Windows.Forms.Label()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.txtGuess = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblWrongGuesses = New System.Windows.Forms.Label()
        Me.btnNewGame = New System.Windows.Forms.Button()
        Me.ptbHangman = New System.Windows.Forms.PictureBox()
        CType(Me.ptbHangman, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLetters
        '
        Me.lblLetters.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLetters.Location = New System.Drawing.Point(12, 19)
        Me.lblLetters.Name = "lblLetters"
        Me.lblLetters.Size = New System.Drawing.Size(263, 50)
        Me.lblLetters.TabIndex = 0
        Me.lblLetters.Text = "Label1"
        Me.lblLetters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(175, 108)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(75, 23)
        Me.btnCheck.TabIndex = 2
        Me.btnCheck.Text = "Check"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'txtGuess
        '
        Me.txtGuess.Location = New System.Drawing.Point(235, 73)
        Me.txtGuess.MaxLength = 1
        Me.txtGuess.Name = "txtGuess"
        Me.txtGuess.Size = New System.Drawing.Size(20, 20)
        Me.txtGuess.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(166, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Your guess:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(167, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Incorrect Guesses:"
        '
        'lblWrongGuesses
        '
        Me.lblWrongGuesses.Location = New System.Drawing.Point(151, 169)
        Me.lblWrongGuesses.Name = "lblWrongGuesses"
        Me.lblWrongGuesses.Size = New System.Drawing.Size(124, 57)
        Me.lblWrongGuesses.TabIndex = 6
        '
        'btnNewGame
        '
        Me.btnNewGame.Location = New System.Drawing.Point(175, 229)
        Me.btnNewGame.Name = "btnNewGame"
        Me.btnNewGame.Size = New System.Drawing.Size(75, 23)
        Me.btnNewGame.TabIndex = 7
        Me.btnNewGame.Text = "New Game"
        Me.btnNewGame.UseVisualStyleBackColor = True
        '
        'ptbHangman
        '
        Me.ptbHangman.Location = New System.Drawing.Point(12, 77)
        Me.ptbHangman.Name = "ptbHangman"
        Me.ptbHangman.Size = New System.Drawing.Size(125, 175)
        Me.ptbHangman.TabIndex = 8
        Me.ptbHangman.TabStop = False
        '
        'Hangman
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.ptbHangman)
        Me.Controls.Add(Me.btnNewGame)
        Me.Controls.Add(Me.lblWrongGuesses)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtGuess)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.lblLetters)
        Me.Name = "Hangman"
        Me.Text = "Hangman"
        CType(Me.ptbHangman, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblLetters As Label
    Friend WithEvents btnCheck As Button
    Friend WithEvents txtGuess As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblWrongGuesses As Label
    Friend WithEvents btnNewGame As Button
    Friend WithEvents ptbHangman As PictureBox
End Class
