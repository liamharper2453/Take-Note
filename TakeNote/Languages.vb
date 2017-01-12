Module Languages


    Public Sub languageCheck()
        'Below block simply determines language via use of the environments setting properties and runs the relevant subroutine
        If My.Settings.language = "En" Then
            setLanguageToEnglish()
        Else
            setLanguageToSpanish()
        End If
    End Sub

    Public Sub setLanguageToEnglish()

        'IsHandleCreated is an alternative of "form.Open". This is used over "form.Open" as "form.Open" was found to be unreliable when used in other aspects of the program
        'All the code below simply modifies aspects of the form when the form is launched and before the user can see it


        If Welcome.IsHandleCreated = True Then
                Welcome.Text = "Welcome!"
            End If

            If About.IsHandleCreated = True Then
            About.lblAboutLine1.Text = "Take Note is an application intended to take notes."
            About.lblAboutLine2.Text = "Also, water is wet."
            About.Text = "About"
            End If

            If NoteSelection.IsHandleCreated = True Then
                NoteSelection.Text = "Please select a note!"
                NoteSelection.cmdNewNote.Text = "New"
                NoteSelection.lblWelcome.Text = "Hello " & Environment.UserName & "!" & vbCrLf & "Today's date is: " & Date.Now.Date & "."

                NoteSelection.cmdNewNote.BringToFront()
            End If

            If NoteViewer.IsHandleCreated = True Then
                NoteViewer.cmdSave.Left = 235
                NoteViewer.cmdSave.Size = New Point(100, 36)
            NoteViewer.cmdSave.Text = "Save"
            NoteViewer.cmdDelete.Text = "Delete"
        End If

            If Settings.IsHandleCreated = True Then
            Settings.Text = "Settings"
            Settings.lblLanguage.Text = "Language:"
            Settings.cmdEnglish.Text = "English"
            Settings.cmdSpanish.Text = "Spanish"
            Settings.lblTheme.Text = "Theme:"
            Settings.cmdChangePassword.Text = "Change Password"
            Settings.cmdCustom.Text = "Custom:"
            Settings.lblSettings.Text = "Configuration"
            End If


    End Sub

    Public Sub setLanguageToSpanish()

        'IsHandleCreated is an alternative of "form.Open". This is used over "form.Open" as "form.Open" was found to be unreliable when used in other aspects of the program
        'All the code below simply modifies aspects of the form when the form is launched and before the user can see it
        If Welcome.IsHandleCreated = True Then
            Welcome.Text = "Bienvenida!"
        End If

        If About.IsHandleCreated = True Then
            About.lblAboutLine1.Text = "Tome nota es una aplicación destinada a tomar notas."
            About.lblAboutLine1.Left = 5
            About.lblAboutLine2.Text = "Además, el agua es húmeda."
            About.lblAboutLine2.Left = 89
            About.Text = "Sobre"
        End If

        If NoteSelection.IsHandleCreated = True Then
            NoteSelection.Text = "Por favor, elija una nota!"
            NoteSelection.cmdNewNote.Text = "Nuevo"
            NoteSelection.lblWelcome.Text = "Hola " & Environment.UserName & "!" & vbCrLf & "La fecha de hoy es: " & Date.Now.Date & "."

            NoteSelection.cmdNewNote.BringToFront()
        End If

        If NoteViewer.IsHandleCreated = True Then
            NoteViewer.cmdSave.Left = 235
            NoteViewer.cmdSave.Size = New Point(100, 36)
            NoteViewer.cmdSave.Text = "Guardar"
            NoteViewer.cmdDelete.Text = "Borrar"
        End If

        If Settings.IsHandleCreated = True Then
            Settings.Text = "Ajustes"
            Settings.lblLanguage.Text = "Idioma:"
            Settings.cmdEnglish.Text = "Inglés"
            Settings.cmdSpanish.Text = "Español"
            Settings.lblTheme.Text = "Tema:"
            Settings.cmdChangePassword.Text = "Cambiar la contraseña"
            Settings.cmdCustom.Text = "Propio"
            Settings.lblSettings.Text = "Configuración"
        End If

        If OutputFramework.IsHandleCreated = True Then
            OutputFramework.Text = "Hola usuario!"

        End If
    End Sub
End Module
