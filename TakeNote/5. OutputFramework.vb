Public Class OutputFramework

    'The below method is an alternative to an input box
    'This is used in order to mask enter characters with a *
    'A feature unavailable with input boxes


    'The subroutines responsible for the following initialise here:
    'Password creation/generation
    'Encryption of password and generation of salt
    'Generation of hash via appending SHA-256 encrypted password with randomly generated salt
    'Outputting above data into database
    'Repeating the process again for authentication purposes however the program uses the salt from the database rather than generating a new one
    'The two hashes created are compared. If identical the check succeeds, otherwise it fails


    Private Sub OutputFramework_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Upon initialisation of the form the program runs two sub-routines which are located in the Languages and Themes modules
        'These sub-routines establish the language and theme the user has selected from a previous execution (if first execution the default language is English etc)
        'These sub-routines are in control of all aspects of the form including the colour and the text itself.
        languageCheck()
        'setFont ensures that the font used in the program will ALWAYS be Segoi UI. This prevents form elements being misplaced around forms due to different sizes of fonts
        setFont()
        setTheme()

        'Allows the text box to be automatically selected when the form opens to save the user manually selecting it
        txtInput.Select()

        'An easter egg plays if the user changes their language to Spanish
        'The OutputFramework handles both the input box replacement and the easter egg. Rather than using two forms 
        If isEasterEggUsed = True Then
            'An image is displayed
            pctOutput.Image = My.Resources.Spanish_Pug
            'A sound file is played
            My.Computer.Audio.Play(My.Resources.Spanish_Music, AudioPlayMode.BackgroundLoop)
            'All aspects representing the input box alternative are hidden
            lblEnterPassword.Visible = False
            txtInput.Visible = False
            OK_Button.Visible = False
            Cancel_Button.Visible = False
            tlpOutput.Visible = False
        Else
            'If the easter egg is not playing then the form is resized to fit the size of an average input box
            Me.Size = New System.Drawing.Size(458, 148)
        End If

        'If we have no password the below subroutine runs
        If passwordExists = 0 Then
            passwordProcessing()
        End If

        If My.Settings.language = "Es" And passwordChange = False Then
            lblEnterPassword.Text = "Por favor, introduzca su nueva contraseña."
        End If

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        'enteredPassword is set to what is in the textbox on the form
        enteredPassword = Me.txtInput.Text

        'Input validation is created so that a null password cannot be submitted
        If enteredPassword = "" Then
            If My.Settings.language = "Es" Then
                MsgBox("Por favor, introduzca una contraseña antes de enviar.")
                Exit Sub
            Else
                MsgBox("Please enter a password before submitting.")
                Exit Sub
            End If

        End If
        'The enteredPassword undergoes authentication processes

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Authentication.cmdAuthentication()


    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Clicking the cancel button simply closes the form
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Dispose()
    End Sub

    Private Sub tmrPug_Tick(sender As System.Object, e As System.EventArgs) Handles tmrPug.Tick

        'If the user changes their language to Spanish on the settings menu then the OutputFramework form will 
        'begin to move around the screen randomly to fit the music that plays in the background
        If My.Settings.language = "Es" And Settings.IsHandleCreated = True And isEasterEggUsed = True Then
            Dim TopY, LeftX As Integer
            Dim Rnd As New Random
            TopY = Rnd.Next(0, 600)
            LeftX = Rnd.Next(0, 800)
            Me.Top = TopY
            Me.Left = LeftX
        End If
    End Sub

    'The below two sub-routines are used to allow the user to directly press the enter key instead of manually clicking the Ok button to submit their password for processing

    Private Sub txtInput_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInput.KeyDown
        'If the text box has focus and the user presses a key the EnterClick sub-routine is called to see if the key pressed is Enter, if so the click event for the Ok button is launched
        Call EnterClick(sender, e)
    End Sub


    Private Sub EnterClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'The click event for the Ok button is launched only if the user has pressed enter
        If e.KeyCode.Equals(Keys.Enter) Then
            OK_Button_Click(sender, e)
        End If
    End Sub

End Class
