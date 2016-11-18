<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnGuess = New System.Windows.Forms.Button()
        Me.lblWord = New System.Windows.Forms.Label()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.lblWrongGuesses = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnGuess
        '
        Me.btnGuess.Location = New System.Drawing.Point(222, 161)
        Me.btnGuess.Name = "btnGuess"
        Me.btnGuess.Size = New System.Drawing.Size(75, 23)
        Me.btnGuess.TabIndex = 0
        Me.btnGuess.Text = "Guess"
        Me.btnGuess.UseVisualStyleBackColor = True
        '
        'lblWord
        '
        Me.lblWord.Font = New System.Drawing.Font("Courier New", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWord.Location = New System.Drawing.Point(12, 41)
        Me.lblWord.Name = "lblWord"
        Me.lblWord.Size = New System.Drawing.Size(360, 47)
        Me.lblWord.TabIndex = 1
        Me.lblWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(210, 135)
        Me.txtInput.MaxLength = 1
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(100, 20)
        Me.txtInput.TabIndex = 2
        Me.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblWrongGuesses
        '
        Me.lblWrongGuesses.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWrongGuesses.Location = New System.Drawing.Point(162, 221)
        Me.lblWrongGuesses.Name = "lblWrongGuesses"
        Me.lblWrongGuesses.Size = New System.Drawing.Size(210, 131)
        Me.lblWrongGuesses.TabIndex = 3
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(220, 198)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(83, 13)
        Me.lblMessage.TabIndex = 4
        Me.lblMessage.Text = "Wrong Guesses"
        '
        'btnRestart
        '
        Me.btnRestart.Location = New System.Drawing.Point(2, 335)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(55, 23)
        Me.btnRestart.TabIndex = 5
        Me.btnRestart.Text = "Restart"
        Me.btnRestart.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 361)
        Me.Controls.Add(Me.btnRestart)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lblWrongGuesses)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.lblWord)
        Me.Controls.Add(Me.btnGuess)
        Me.Name = "Form1"
        Me.Text = "Hang Man"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGuess As Button
    Friend WithEvents lblWord As Label
    Friend WithEvents txtInput As TextBox
    Friend WithEvents lblWrongGuesses As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents btnRestart As Button
End Class
