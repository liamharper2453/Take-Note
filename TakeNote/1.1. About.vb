Public Class About
    'This form simply displays text that is already set via labels

    'For some strange reason the picture of the pug with horns makes my anti-virus quarantine the file.

    'Formatting is all over the place here. Centering message boxes isn't possible unfortunately.

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Upon initialisation of the form the program runs two sub-routines which are located in the Languages and Themes modules
        'These sub-routines establish the language and theme the user has selected from a previous execution (if first execution the default language is English etc)
        'These sub-routines are in control of all aspects of the form including the colour and the text itself.
        languageCheck()
        'setFont ensures that the font used in the program will ALWAYS be Segoi UI. This prevents form elements being misplaced around forms due to different sizes of fonts
        setFont()
        setTheme()
    End Sub

    Private Sub PctPug_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctPug.Click
        MsgBox("            Fun fact: During development this little guy triggered my anti-virus..." & vbCrLf & "                             Resulting in the executable being quarantined." & vbCrLf & "                     WHAT DO THEY HAVE AGAINST PUGS. #FREETHEPUGS2015")
    End Sub


End Class