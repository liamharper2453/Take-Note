Imports System.Globalization
Public Class Settings

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Upon initialisation of the form the program runs two sub-routines which are located in the Languages and Themes modules
        'These sub-routines establish the language and theme the user has selected from a previous execution (if first execution the default language is English etc)
        'These sub-routines are in control of all aspects of the form including the colour and the text itself.
        languageCheck()
        'setFont ensures that the font used in the program will ALWAYS be Segoi UI. This prevents form elements being misplaced around forms due to different sizes of fonts
        setFont()
        setTheme()
    End Sub

    Private Sub cmdChangePassword_Click(sender As Object, e As EventArgs) Handles cmdChangePassword.Click

        'The below three lines sets the two values that will ultimately re-run the encryption and authentication modules in a manner like it is being ran for the first time. This will ultimately reset the password

        databaseManagement.passwordChange = True
        databaseManagement.passwordExists = 0
        OutputFramework.Show()


    End Sub

    Private Sub cmdEnglish_Click(sender As Object, e As EventArgs) Handles cmdEnglish.Click

        'In the below two lines we are utilising the Settings property of the Visual Studio environment in order to allow settings to persist between executions
        My.Settings.language = "En"
        My.Settings.Save()


        'The block of code below refreshes the currently open form to show changes to user and also brings the window to the front
        NoteSelection.Dispose()
        'Runs the sub-routine that manages changing the form elements to match the users language at runtime
        setLanguageToEnglish()
        Me.Refresh()
        NoteSelection.Show()
        Me.BringToFront()

        'Display success message
        MsgBox("Changes saved successfully!")
    End Sub

    Private Sub cmdSpanish_Click(sender As Object, e As EventArgs) Handles cmdSpanish.Click

        'Variable that determines if user has clicked a button within a message box
        Dim responseDialogResult As DialogResult

        'In the below two lines we are utilising the Settings property of the Visual Studio environment in order to allow settings to persist between executions
        My.Settings.language = "Es"
        My.Settings.Save()

        'The block of code below refreshes the currently open form to show changes to user and also brings the window to the front
        NoteSelection.Dispose()
        'Runs the sub-routine that manages changing the form elements to match the users language at runtime
        setLanguageToSpanish()
        Me.Refresh()
        NoteSelection.Show()
        Me.BringToFront()

        'Displays easter egg
        If isEasterEggUsed = True Then
            OutputFramework.Show()
        End If

        'Display success message
        responseDialogResult = MsgBox("Los cambios han guardado correctamente!")

        'Closes easter egg is user closes message box
        If responseDialogResult = DialogResult.OK And isEasterEggUsed = True Then
            'Disables moving window to allow user to close and stops audio
            OutputFramework.tmrPug.Enabled = False
            My.Computer.Audio.Stop()
            OutputFramework.Dispose()
        End If

    End Sub


    Private Sub colourLabels_MouseEnter(sender As Object, e As EventArgs) Handles lblDark.MouseEnter, lblLight.MouseEnter, lblFirebrick.MouseEnter, lblSeaGreen.MouseEnter, lblSteelBlue.MouseEnter, lblDarkOrchid.MouseEnter, lblMaroon.MouseEnter, lblDarkPink.MouseEnter, lblBlack.MouseEnter, lblDimGray.MouseEnter, lblDarkGreen.MouseEnter, lblOrange.MouseEnter
        'Multiple event handlers are condensed into one event to save unnecessary code
        'The highlighted colour is simply determined by the backColor of the label that was hovered over
        highlightedColour = sender.BackColor
        'If the mouse hovers over a label the form elements will change in colour so the user can preview the colour 
        colourPreview.colourPreview()
    End Sub

    Private Sub ColourLabels_MouseLeave(sender As Object, e As EventArgs) Handles lblDark.MouseLeave, lblLight.MouseLeave, lblFirebrick.MouseLeave, lblSeaGreen.MouseLeave, lblSteelBlue.MouseLeave, lblDarkOrchid.MouseLeave, lblMaroon.MouseLeave, lblDarkPink.MouseLeave, lblBlack.MouseLeave, lblDimGray.MouseLeave, lblDarkGreen.MouseLeave, lblOrange.MouseLeave
        'Multiple event handlers are condensed into one event to save unnecessary code
        'If the mouse exits the label we revert to the colour used in the users settings
        colourPreview.colourPreviewRevert()
    End Sub



    Private Sub colourLabels_Click(sender As Object, e As EventArgs) Handles lblDark.Click, lblLight.Click, lblFirebrick.Click, lblSeaGreen.Click, lblSteelBlue.Click, lblDarkOrchid.Click, lblMaroon.Click, lblDarkPink.Click, lblBlack.Click, lblDimGray.Click, lblDarkGreen.Click, lblOrange.Click
        'Multiple event handlers are condensed into one event to save unnecessary code
        'The theme is saved so that the theme persists over executions
        Themes.saveTheme()
    End Sub


    Private Sub cmdCustom_Click(sender As Object, e As EventArgs) Handles cmdCustom.Click

        Do
            highlightedColour = System.Drawing.Color.FromName(InputBox("Please enter a colour you are familiar with."))

            'First we see if the users entered colour is valid
            If highlightedColour.IsKnownColor Then
                saveTheme()
                'If not then we see if the name of highlightedColour is "". If so this means that nothing has been entered and the user has canceled the input box. Making the message box unnecessary
            ElseIf highlightedColour.Name <> "" Then
                If My.Settings.language = "Es" Then
                    MsgBox("Su color es válido. Por favor, vuelva a intentarlo.")
                Else
                    MsgBox("Your colour Is invalid. Please try again.")
                End If
                'If the user is about to exit then the sub is simply closed
            Else Exit Sub
            End If
        Loop Until highlightedColour.IsKnownColor
    End Sub

End Class