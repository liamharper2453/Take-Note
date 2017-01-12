Module buildNoteSelection


    'Declare arrays representing our controls
    Public textfilePreviewButton() As Button
    Public lastModificationDateButton() As Button
    Public generatedLines() As TextBox
    Public isEasterEggUsed As Boolean = False
    Public loopCondition As Integer = 0

    Public Sub buildNoteSelectionSub()


        'This combined with ResumeLayout freezes the UI of the NoteSelection of the form in order to prevent flickering upon the elements being updated
        NoteSelection.SuspendLayout()

        'The loopCondition wil ultimately control how many buttons and lines are present on screen
        'This must change depending on if a search is or is not in progress (a search will result in less buttons than to start with)
        'By default we are using how many rows are in the dataset (the number of notes in the database)


        'The dimensions of the arrays are altered to reduce memory consumption
        ReDim textfilePreviewButton(databaseManagement.ds.Tables(0).Rows.Count - 1)
        ReDim lastModificationDateButton(databaseManagement.ds.Tables(0).Rows.Count - 1)
        ReDim generatedLines(databaseManagement.ds.Tables(0).Rows.Count - 1)

        'If a search is in progress the loopCondition is altered based on how many matches were found
        'Meaning that the number of buttons produced will be the same number as how many matches were made
        If NoteSelection.searchInProgress = True Then
            loopCondition = NoteSelection.searchMatches - 1
        Else
            loopCondition = databaseManagement.ds.Tables(0).Rows.Count - 1
        End If

        'The value of the loop below determines our number of buttons and lines
        'All values of the controls are determined at runtime  
        For i = 0 To loopCondition
            With lastModificationDateButton(i)

                lastModificationDateButton(i) = New Button
                lastModificationDateButton(i).BringToFront()
                lastModificationDateButton(i).Parent = NoteSelection
                lastModificationDateButton(i).Size = New Size(113, 32)
                'We multiply by the index in order to have spaces between our buttons
                lastModificationDateButton(i).Top = 74 + (i * 50)
                lastModificationDateButton(i).Left = 160
                'The colour of the button is determined by the value of My.Settings.theme it can either be "light" or "dark"
                lastModificationDateButton(i).FlatStyle = FlatStyle.Flat
                lastModificationDateButton(i).FlatAppearance.BorderColor = My.Settings.theme

                'Goldenrod is not very visible with a white theme so black is used instead
                If My.Settings.theme = Color.White Then
                    lastModificationDateButton(i).ForeColor = Color.Black
                Else
                    lastModificationDateButton(i).ForeColor = Color.Goldenrod
                End If

                'The text of the button is determined based on if a search is in progress. This determines what array we use
                If NoteSelection.searchInProgress = False Then
                    lastModificationDateButton(i).Text = databaseManagement.writeTimesFromDatabase(i)
                Else
                    lastModificationDateButton(i).Text = NoteSelection.lastWriteTimeSearchResults(i)
                End If

                'Here we uniquely identity our button
                lastModificationDateButton(i).Name = "dates" & i
                'A new font is created here due to the fontSize control being read-only; so an alternative must be made
                lastModificationDateButton(i).Font = New System.Drawing.Font("Segoe UI Semilight", 12)
                lastModificationDateButton(i).Anchor = AnchorStyles.Top Or AnchorStyles.Left


                AddHandler lastModificationDateButton(i).Click, AddressOf NoteSelection.openTextFile
            End With


            With textfilePreviewButton(i)


                textfilePreviewButton(i) = New Button
                textfilePreviewButton(i).Parent = NoteSelection
                textfilePreviewButton(i).Size = New Size(113, 32)
                'We multiply by the index in order to have spaces between our buttons
                textfilePreviewButton(i).Top = 74 + (i * 50)
                textfilePreviewButton(i).Left = 16
                'The colour of the button is determined by the value of My.Settings.theme it can either be "light" or "dark"
                textfilePreviewButton(i).FlatStyle = FlatStyle.Flat
                textfilePreviewButton(i).FlatAppearance.BorderColor = My.Settings.theme



                'The language of the button is determined by the value of My.Settings.language it can either be "En" or "Es"
                If textfilePreviewButton(i).Text = "" Then
                    If My.Settings.language = "En" Then
                        textfilePreviewButton(i).Text = "Empty"
                    Else
                        textfilePreviewButton(i).Text = "Vacío"
                    End If
                End If

                'The text of the button is determined based on if a search is in progress. This determines what array we use
                If NoteSelection.searchInProgress = False Then
                    textfilePreviewButton(i).Text = databaseManagement.notesFromDatabase(i)
                Else
                    textfilePreviewButton(i).Text = NoteSelection.textSearchResults(i)
                End If

                'Goldenrod is not very visible with a white theme so black is used instead
                If My.Settings.theme = Color.White Then
                    textfilePreviewButton(i).ForeColor = Color.Black
                Else
                    textfilePreviewButton(i).ForeColor = Color.Goldenrod
                End If

                'We decide if the easter egg is triggered here
                If textfilePreviewButton(i).Text = "I amor pugs" Then
                    isEasterEggUsed = True
                End If

                'Here we uniquely identity our button
                textfilePreviewButton(i).Name = "notes" & i
                'A new font is created here due to the fontSize control being read-only; so an alternative must be made
                textfilePreviewButton(i).Font = New System.Drawing.Font("Segoe UI Semilight", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

                textfilePreviewButton(i).AutoEllipsis = True
                textfilePreviewButton(i).Anchor = AnchorStyles.Top Or AnchorStyles.Left
                AddHandler textfilePreviewButton(i).Click, AddressOf NoteSelection.openTextFile


            End With


            With generatedLines

                generatedLines(i) = New TextBox
                generatedLines(i).BringToFront()
                generatedLines(i).Parent = NoteSelection

                generatedLines(i).BorderStyle = BorderStyle.None

                If i = 0 Then
                    generatedLines(i).Top = 84
                End If
                'We multiply by the index in order to have spaces between our lines
                generatedLines(i).Top = 74 + (i * 50) + 40
                generatedLines(i).Left = -10
                'Here we uniquely identity our line
                generatedLines(i).Name = "line" & i
                generatedLines(i).Multiline = True
                generatedLines(i).Anchor = AnchorStyles.Top Or AnchorStyles.Left
            End With

            'Adjust size of certain form elements based on whether scrollbar is present or not
            'Having more than 5 buttons on screen causes the vertical scrollbar to appear. Modifying the locations of certain elements
            If textfilePreviewButton.Length > 5 Then
                generatedLines(i).Size = New Size(312, 1)
            Else
                NoteSelection.cmdNewNote.Left = (258)
                NoteSelection.lblWelcome.Left = (47)
                NoteSelection.txtFirstLine.Size = New Size(325, 1)
                generatedLines(i).Size = New Size(324, 1)
            End If
        Next

        'If no notes are present the size of the first line is adjusted
        If textfilePreviewButton.Length = 0 Then
            NoteSelection.lblNoNotes.Visible = True
            NoteSelection.lblNoNotes1.Visible = True
            NoteSelection.txtFirstLine.Size = New Size(325, 1)
        End If

        setFont()
        'This combined with SuspendLayout freezes the UI of the NoteSelection of the form in order to prevent flickering upon the elements being updated
        NoteSelection.ResumeLayout()

    End Sub
End Module
