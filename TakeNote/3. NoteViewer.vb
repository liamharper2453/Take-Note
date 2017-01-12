Imports System.Data.OleDb

Public Class NoteViewer



    'Declare miscellaneous variables
    Dim generatedLines(10) As TextBox

    Private Sub NoteViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Upon initialisation of the form the program runs two sub-routines which are located in the Languages and Themes modules
        'These sub-routines establish the language and theme the user has selected from a previous execution (if first execution the default language is English etc)
        'These sub-routines are in control of all aspects of the form including the colour and the text itself.
        languageCheck()
        'setFont ensures that the font used in the program will ALWAYS be Segoi UI. This prevents form elements being misplaced around forms due to different sizes of fonts
        setFont()
        setTheme()

        'The text property of the note the user clicked on is passed onto this form and becomes the value of txtTextFromFile
        txtTextFromFile.AppendText(NoteSelection.noteBeingOpened)
        'Here we are transferring the dataset from the previous form to this form
        transferredDS = databaseManagement.ds
        'Here we are transferring the index from the previous form to this form
        'An if condition is added as if the user clicks new then no already existing note was chosen meaning the value for NoteSelection.trimmedButtonName will be nothing and will crash the program
        If NoteSelection.trimmedButtonName <> "" Then
            transferredIndex = NoteSelection.trimmedButtonName
        End If
        'Here we are transferring the property determining whether the note is a newly created note or not from the previous form to this form
        transferredIsNew = NoteSelection.isNew

        'If the note is new and does not exist in the database it cannot be deleted, hence the delete button will be hidden from the user in this context
        If transferredIsNew = True Then
            cmdDelete.Visible = False
        End If

        'Here we are completely disposing of the NoteSelection form
        NoteSelection.Dispose()

        'Here we are creating lines (flattened textboxes as no line shape is available) and covering the form with them in a calculated pattern. This aims to give the form a similar look to an actual notepad
        For i = 0 To 10
            With generatedLines

                generatedLines(i) = New TextBox
                generatedLines(i).BringToFront()
                generatedLines(i).Parent = Me

                'Black lines is not visible with a black theme so white is used instead
                If My.Settings.theme = Color.Black Then
                    generatedLines(i).BackColor = Color.White
                Else
                    generatedLines(i).BackColor = Color.Black
                End If

                generatedLines(i).Size = New Size(353, 1)
                generatedLines(i).Top = 40 + 25.2 * i
                generatedLines(i).Left = -8
                generatedLines(i).Name = "line" & i
                generatedLines(i).Multiline = True
            End With
        Next

        'The text containing our note is sent to the back in order to prevent the text appearing on top of the generated lines
        txtTextFromFile.SendToBack()

    End Sub


    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        'Input validation so that the program does not crash if no text is present in the note
        'The appropriate message is displayed based on the language before ending the sub
        If txtTextFromFile.Text = "" Then
            If My.Settings.language = "Es" Then
                MsgBox("Por favor, introduzca una nota antes de grabar!")
                Exit Sub
            Else
                MsgBox("Please enter a note before saving!")
                Exit Sub
            End If
        End If

        'Ultimately adds an entry to the database and in turn makes changes to the NoteSelection form showing the modifications
        databaseManagement.addEntryToDatabase()

        'The message displayed to the user is modified based on their chosen language
        If My.Settings.language = "En" Then
            MsgBox("Changes saved successfully!")
            Me.Close()
        Else
            MsgBox("Los cambios han guardado correctamente!")
            Me.Close()
        End If

    End Sub

    Private Sub NoteViewer_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'If the NoteViewer form is closing then the NoteSelection form will be reloaded
        NoteSelection.Show()
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click

        'Ultimately removes an entry from the database and in turn makes changes to the NoteSelection form showing the modifications'Declare miscellaneous variables
        Dim deletionConfirmation As MsgBoxResult
        'Makes sure user does not delete note due to a misclick
        If My.Settings.language = "Es" Then
            deletionConfirmation = MsgBox("¿Estás seguro que quieres eliminar esta nota?", MsgBoxStyle.YesNo)
        Else
            deletionConfirmation = MsgBox("Are you sure you want to delete this note?", MsgBoxStyle.YesNo)
        End If

        If deletionConfirmation = MsgBoxResult.Yes = True Then
            databaseManagement.deleteEntryFromDatabase()
        Else
            Exit Sub
        End If
    End Sub

End Class