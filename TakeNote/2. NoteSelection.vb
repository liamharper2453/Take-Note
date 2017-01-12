Imports System.Data.OleDb

Public Class NoteSelection

    'Declare miscellaneous variable(s)
    Public isNew As Boolean = False
    Public noteBeingOpened As String = ""
    Public trimmedButtonName As String = ""

    'Declare variables related to searching
    Public textSearchResults(99) As String
    Public lastWriteTimeSearchResults(99) As String
    Public searchInProgress As Boolean = False
    Public searchMatches As Integer = 0


    Private Sub NoteSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'The validation here prevents duplicate entries being added to the dataset when the NoteSelection form is loaded more than once during runtime
        If databaseManagement.hasDatasetBeenFilled = False Then
            databaseManagement.datasetFill()
            'Sets the flag so that upon the next load of the NoteSelection form the dataset will not be filled again
            'This will only change if a deletion/addition to the dataset occurs
            databaseManagement.hasDatasetBeenFilled = True
        End If

        'We now have everything we need to build the form. The module below is ran to begin this process
        buildNoteSelectionSub()

        'Upon initialisation of the form the program runs two sub-routines which are located in the Languages and Themes modules
        'These sub-routines establish the language and theme the user has selected from a previous execution (if first execution the default language is English etc)
        'These sub-routines are in control of all aspects of the form including the colour and the text itself.
        languageCheck()
        'setFont ensures that the font used in the program will ALWAYS be Segoi UI. This prevents form elements being misplaced around forms due to different sizes of fonts
        setFont()
        setTheme()

    End Sub

    Private Sub cmdNewNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewNote.Click

        'If the "New" button is clicked in the program the flag that tells the program the note is not a modification of a previous note and is new is set
        isNew = True
        'Opens the NoteViewer form
        NoteViewer.Show()

    End Sub


    Public Sub openTextFile(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Because our program has two available sources of opening our note (clicking the note itself or clicking the last write time) a simple solution such as "noteBeingOpened = sender.text" isn't possible
        'This is because when we click the date the note that would display when opening the NoteViewer form would be the date and not the note
        'Because of this a work-around must be achieved


        'Fortunately when the buildNoteSelection module runs all control are set to be able to be uniquely identified 
        'The first note is called note1 and the second is called note2 etc
        'The same system works for the dates with dates1 and dates2

        'Because of this system we can use sender.Name.Remove (sender being our button we have clicked so in the line below we are removing the first 5 characters of the name of the button)
        'And from this we will get our index!

        trimmedButtonName = sender.Name.Remove(0, 5)

        'Now that we have our index we can simply use that to refer to our initial array created at the load of the NoteSelection form and get our note regardless of whether the note or date button is clicked
        noteBeingOpened = notesFromDatabase(trimmedButtonName)
        isNew = False
        'Opens the NoteViewer form
        NoteViewer.Show()

    End Sub


    Private Sub NoteSelection_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        'For an unknown reason the program will not close correctly without the block of code below
        'The program appears as it has closed when the user has clicked the cross but in reality the program is still residing in memory
        'An unsuspecting user may open and close the program several times and considering that the program currently has an approx 20mb footprint this can add up quickly!

        'Application.Exit is a cleaner alternative to End and Me.Close will result in a crash. So Application.Exit is the best option
        'Me.ActiveControl.Name <> "cmdNewNote" prevents the program closing when the user closes the NoteSelection form to create a new note
        If e.CloseReason = CloseReason.UserClosing Then
            Application.Exit()
        End If

    End Sub

    Private Sub pctSettings_Click(sender As Object, e As EventArgs) Handles pctSettings.Click


        'The blocks of code below only run depending on whether the search box is or is not visible
        'This is added here in addition to the search button itself in order to make sure the search box is disabled when the user leaves the form
        If rtxtSearch.Visible = True Then
            'Text of message depends on user language
            If My.Settings.language = "En" Then
                lblWelcome.Text = "Hello " & Environment.UserName & "!" & vbCrLf & "Today's date is: " & Date.Now.Date & "."
            Else
                lblWelcome.Text = "Hola " & Environment.UserName & "!" & vbCrLf & "La fecha de hoy es: " & Date.Now.Date & "."
            End If
            rtxtSearch.Visible = False
        End If

        'Opens the settings form
        Settings.Show()
    End Sub

    Private Sub rtxtSearch_TextChanged(sender As Object, e As EventArgs) Handles rtxtSearch.TextChanged

        'All code here will only run when the textbox designed for searching receives a keystroke from the user

        'Declare miscellaneous variable(s)
        Dim isQueryFound As Integer = 0

        'Set a flag so the program can know a search is in progress and act accordingly
        searchInProgress = True

        'Wipes all buttons from the form to act as a refresh
        For i = 0 To textfilePreviewButton.Length - 1
            Me.Controls.Remove(textfilePreviewButton(i))
            Me.Controls.Remove(lastModificationDateButton(i))
        Next

        'The loop runs based on the number of rows in the database (eg how many notes exist)
        For i = 0 To databaseManagement.ds.Tables(0).Rows.Count - 1

            'The line below compares notesFromDatabase(i) and rtxtSearch.Text (the users query) for matching letters
            'If there is a match isQueryFound becomes 1
            isQueryFound = InStr(1, LCase(notesFromDatabase(i)), LCase(rtxtSearch.Text))

            'The code below only runs if isQueryFound is not 0 (a match has been made)
            If isQueryFound <> 0 Then

                'We create another array which will contain our matched notes and their corresponding last write times
                textSearchResults(searchMatches) = notesFromDatabase(i)
                lastWriteTimeSearchResults(searchMatches) = writeTimesFromDatabase(i)
                'A counter is also setup to record how many matches have been made
                searchMatches = searchMatches + 1
            Else
                'If a match has not been made the button that is not needed is removed
                Me.Controls.Remove(textfilePreviewButton(i))
                Me.Controls.Remove(lastModificationDateButton(i))
            End If

        Next

        'We rebuild the NoteSelection form with our search results
        buildNoteSelectionSub()

        'Here we reset our variables to their starting values so the process can repeat afresh
        isQueryFound = 0
        searchInProgress = False
        searchMatches = 0

    End Sub

    Private Sub pctSearch_Click(sender As Object, e As EventArgs) Handles pctSearch.Click

        'The blocks of code below only run depending on whether the search box is or is not visible

        If rtxtSearch.Visible = False Then
            'Text of message depends on user language
            If My.Settings.language = "En" Then
                lblWelcome.Text = "       Please search below!"
                rtxtSearch.Visible = True
            Else
                lblWelcome.Text = "             Busque aquí!"
                rtxtSearch.Visible = True
            End If
        Else
            If My.Settings.language = "En" Then
                lblWelcome.Text = "Hello " & Environment.UserName & "!" & vbCrLf & "Today's date is: " & Date.Now.Date & "."
            Else
                lblWelcome.Text = "Hola " & Environment.UserName & "!" & vbCrLf & "La fecha de hoy es: " & Date.Now.Date & "."
            End If
            rtxtSearch.Visible = False
        End If
    End Sub

End Class