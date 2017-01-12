Module Themes

    Public highlightedColour As Color
    Public previousColour As Color
    Public isThemeBeingSaved As Boolean = False
    Public colourChangedFailed As Boolean = False


    Public Sub setTheme()


        'IsHandleCreated is an alternative of "form.Open". This is used over "form.Open" as "form.Open" was found to be unreliable when used in other aspects of the program
        'All the code below simply modifies aspects of the form when the form is launched and before the user can see it
        'Try prevents crashing when a user enters an invalid colour
        'The code between catch and try runs when an error is encountered

        'A flag is set to tell the user invalid data has been entered when the sub completes
        If Welcome.IsHandleCreated = True Then

            Welcome.BackColor = My.Settings.theme
            Welcome.lblWelcome.BackColor = My.Settings.theme
            Welcome.lblStart.BackColor = My.Settings.theme

            'Goldenrod is not very visible with a white theme so black is used instead
            If My.Settings.theme = Color.White Then
                Welcome.lblWelcome.ForeColor = Color.Black
            Else
                Welcome.lblWelcome.ForeColor = Color.Goldenrod
            End If
        End If

        If About.IsHandleCreated = True Then

            If My.Settings.theme = Color.White Then
                About.BackColor = My.Settings.theme
                About.lblAboutLine1.BackColor = My.Settings.theme
                About.lblAboutLine1.ForeColor = Color.Black
                About.lblAboutLine2.BackColor = My.Settings.theme
                About.lblAboutLine2.ForeColor = Color.Black
            Else
                About.BackColor = My.Settings.theme
                About.lblAboutLine1.BackColor = My.Settings.theme
                About.lblAboutLine1.ForeColor = Color.Goldenrod
                About.lblAboutLine2.BackColor = My.Settings.theme
                About.lblAboutLine2.ForeColor = Color.Goldenrod
            End If
        End If

        If NoteSelection.IsHandleCreated = True Then

            NoteSelection.lblWelcome.BackColor = My.Settings.theme
            NoteSelection.cmdNewNote.BackColor = My.Settings.theme
            NoteSelection.cmdNewNote.FlatAppearance.BorderColor = My.Settings.theme
            NoteSelection.BackColor = My.Settings.theme

            'Sets the backcolor of NoteSelections buttons to the users chosen colour
            For i = 0 To databaseManagement.ds.Tables(0).Rows.Count - 1

                textfilePreviewButton(i).BackColor = My.Settings.theme
                lastModificationDateButton(i).BackColor = My.Settings.theme
                textfilePreviewButton(i).FlatAppearance.BorderColor = My.Settings.theme
                lastModificationDateButton(i).FlatAppearance.BorderColor = My.Settings.theme

                If My.Settings.theme = Color.White Then
                    textfilePreviewButton(i).ForeColor = Color.Black
                    lastModificationDateButton(i).ForeColor = Color.Black
                    NoteSelection.lblNoNotes.ForeColor = Color.Black
                    NoteSelection.lblNoNotes1.ForeColor = Color.Black
                Else
                    textfilePreviewButton(i).ForeColor = Color.Goldenrod
                    lastModificationDateButton(i).ForeColor = Color.Goldenrod
                    NoteSelection.lblNoNotes.ForeColor = Color.Goldenrod
                    NoteSelection.lblNoNotes1.ForeColor = Color.Goldenrod
                End If


                'Black lines is not visible with a black theme so white is used instead
                If My.Settings.theme = Color.Black Then
                    generatedLines(i).BackColor = Color.White
                    NoteSelection.txtFirstLine.BackColor = Color.White
                    Settings.txtFirstLine.BackColor = Color.White
                    Settings.txtSecondLine.BackColor = Color.White
                    Settings.txtThirdLine.BackColor = Color.White
                Else
                    generatedLines(i).BackColor = Color.Black
                    NoteSelection.txtFirstLine.BackColor = Color.Black
                    Settings.txtFirstLine.BackColor = Color.Black
                    Settings.txtSecondLine.BackColor = Color.Black
                    Settings.txtThirdLine.BackColor = Color.Black
                End If

            Next
        End If

        If NoteViewer.IsHandleCreated = True Then
            NoteViewer.BackColor = My.Settings.theme
            NoteViewer.txtTextFromFile.BackColor = My.Settings.theme
            NoteViewer.txtTextFromFile.ForeColor = Color.Goldenrod
            NoteViewer.cmdSave.FlatAppearance.BorderColor = My.Settings.theme
            NoteViewer.cmdDelete.FlatAppearance.BorderColor = My.Settings.theme
        End If


        If Settings.IsHandleCreated = True Then
            Settings.BackColor = My.Settings.theme
            'Goldenrod is not very visible with a white theme so black is used instead
            If My.Settings.theme = Color.White Then
                Settings.lblTheme.ForeColor = Color.Black
                Settings.lblPassword.ForeColor = Color.Black
                Settings.lblLanguage.ForeColor = Color.Black
            End If
        End If

        If OutputFramework.IsHandleCreated = True Then
            OutputFramework.BackColor = My.Settings.theme
            OutputFramework.lblEnterPassword.BackColor = My.Settings.theme

            'Goldenrod is not very visible with a white theme so black is used instead
            If My.Settings.theme = Color.White Then
                OutputFramework.lblEnterPassword.ForeColor = Color.Black
            Else
                OutputFramework.lblEnterPassword.ForeColor = Color.Goldenrod
            End If
        End If


    End Sub


    Public Sub saveTheme()


        'Prevents colour change when the MouseLeave event is triggered
        isThemeBeingSaved = True

        'Writes changes so that these changes will be applied despite the program being closed and opened
        My.Settings.theme = highlightedColour
        My.Settings.Save()
        'The theme is applied to the currently open form(s)
        setTheme()


        'As their are only two languages being used in the program the output language can be easily determined by an If statement
        If My.Settings.language = "En" And colourChangedFailed = False Then
            MsgBox("Changes saved successfully!")
            Settings.Dispose()
        End If


    End Sub

End Module
