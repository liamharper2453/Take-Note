Public Class colourPreview

    Shared Sub colourPreview()

        'Establishes previous colour so that the user can revert when the mouse is no longer over the colour
        previousColour = My.Settings.theme

        'Elements of both forms are adjusted to that of the backcolor of the label the users mouse is over
        NoteSelection.lblWelcome.BackColor = highlightedColour
        NoteSelection.cmdNewNote.BackColor = highlightedColour
        NoteSelection.cmdNewNote.FlatAppearance.BorderColor = highlightedColour
        NoteSelection.BackColor = highlightedColour

        Settings.BackColor = highlightedColour

        'Goldenrod is not very visible with a white theme so black is used instead
        'Change aspects of the form regardless of how many buttons are present
        If highlightedColour = Color.White Then
            NoteSelection.lblNoNotes.ForeColor = Color.Black
            NoteSelection.lblNoNotes1.ForeColor = Color.Black
            Settings.lblTheme.ForeColor = Color.Black
            Settings.lblPassword.ForeColor = Color.Black
            Settings.lblLanguage.ForeColor = Color.Black
        Else
            NoteSelection.lblNoNotes.ForeColor = Color.Goldenrod
            NoteSelection.lblNoNotes1.ForeColor = Color.Goldenrod
            Settings.lblTheme.ForeColor = Color.Goldenrod
            Settings.lblPassword.ForeColor = Color.Goldenrod
            Settings.lblLanguage.ForeColor = Color.Goldenrod
        End If


        For i = 0 To databaseManagement.ds.Tables(0).Rows.Count - 1
            'A loop is created here to change the colour of the buttons backcolor and also the bordercolor to that of the label the users mouse is over
            textfilePreviewButton(i).BackColor = highlightedColour
            lastModificationDateButton(i).BackColor = highlightedColour
            textfilePreviewButton(i).FlatAppearance.BorderColor = highlightedColour
            lastModificationDateButton(i).FlatAppearance.BorderColor = highlightedColour

            'Goldenrod is not very visible with a white theme so black is used instead
            If highlightedColour = Color.White Then
                textfilePreviewButton(i).ForeColor = Color.Black
                lastModificationDateButton(i).ForeColor = Color.Black
            Else
                textfilePreviewButton(i).ForeColor = Color.Goldenrod
                lastModificationDateButton(i).ForeColor = Color.Goldenrod
            End If

            'Black lines is not visible with a black theme so white is used instead
            If highlightedColour = Color.Black Then
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

    End Sub

    Shared Sub colourPreviewRevert()

        'Only runs if the MouseLeave event is ran without the user saving the colour they previewed
        If isThemeBeingSaved = False Then
            'Sets form elements to colours before preview was initiated
            NoteSelection.lblWelcome.BackColor = previousColour
            NoteSelection.cmdNewNote.BackColor = previousColour
            NoteSelection.cmdNewNote.FlatAppearance.BorderColor = previousColour
            NoteSelection.BackColor = previousColour
            Settings.BackColor = previousColour

            'Sets the backcolor of NoteSelections buttons to before preview was initiated
            For i = 0 To databaseManagement.ds.Tables(0).Rows.Count - 1
                textfilePreviewButton(i).BackColor = previousColour
                lastModificationDateButton(i).BackColor = previousColour
                NoteSelection.lblNoNotes.ForeColor = previousColour
                NoteSelection.lblNoNotes1.ForeColor = previousColour
                textfilePreviewButton(i).FlatAppearance.BorderColor = previousColour
                lastModificationDateButton(i).FlatAppearance.BorderColor = previousColour

                'Goldenrod is not very visible with a white theme so black is used instead
                If My.Settings.theme = Color.White Then
                    textfilePreviewButton(i).ForeColor = Color.Black
                    lastModificationDateButton(i).ForeColor = Color.Black
                    NoteSelection.lblNoNotes.ForeColor = Color.Black
                    NoteSelection.lblNoNotes1.ForeColor = Color.Black
                    Settings.lblTheme.ForeColor = Color.Black
                    Settings.lblPassword.ForeColor = Color.Black
                    Settings.lblLanguage.ForeColor = Color.Black
                Else
                    textfilePreviewButton(i).ForeColor = Color.Goldenrod
                    lastModificationDateButton(i).ForeColor = Color.Goldenrod
                    NoteSelection.lblNoNotes.ForeColor = Color.Goldenrod
                    NoteSelection.lblNoNotes1.ForeColor = Color.Goldenrod
                    Settings.lblTheme.ForeColor = Color.Goldenrod
                    Settings.lblPassword.ForeColor = Color.Goldenrod
                    Settings.lblLanguage.ForeColor = Color.Goldenrod
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

        'Resets flag
        isThemeBeingSaved = False
    End Sub

End Class
