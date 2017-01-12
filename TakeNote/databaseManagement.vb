Imports System.Data.OleDb
Module databaseManagement

    'Declare variables associated with the database

    'Public Sub initialiseDatabase()
    'Declare variables that will be involved with connecting with the database
    Dim databaseDirectory As String = ""
    Dim provider As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
    Dim registryKeyDirectory As String = ""
    Public searchString As String = ""
    Public connString As String = ""
    Public myConnection As OleDbConnection = New OleDbConnection
    Public dr As OleDbDataReader

    'Public Sub datasetFill()
    'This contains our database content that will persist after the connection to the database is closed
    Public ds As New DataSet
    Public hasDatasetBeenFilled As Boolean = False
    Public notesFromDatabase(99) As String
    Public writeTimesFromDatabase(99) As String

    'Public Sub doesHashExistInDatabase()
    'Declare variables associated with password management
    Public passwordChange As Boolean = False
    Public passwordExists As Integer = 0

    'Public Sub addEntryToDatabase()/deleteEntryFromDatabase()
    Public transferredDS As DataSet
    Public transferredIndex As Integer = 0
    Public transferredIsNew As Boolean = False


    Public Sub initialiseDatabase()

        'In the line below the program sets up commonly used drive letters to browse through to find the database. However this method can be difficult to implement as each system has different drive letters
        'The main issue is that if the program attempts to browse a drive letter that represents a particular drive (such as a DVD drive) the program will crash. This is simply because the system does indeed consider the DVD drive as an existing drive regardless of whether a DVD is inserted...
        'But however as there is literally no data to scan through (provided no DVD is inserted) the program will encounter a NullReferenceException error and crash
        'It should be noted that this crash is not exclusive to DVD drives. Another example is a network drive to which the user is prohibited to.
        'Thus it would be ideal if a more concrete method was used to process all system drives to search for a directory without resulting in a crash
        Dim driveScan As String = "CEGN"
        'The specified letters above will be split into an array in order to sequentially process each individual letter along with the hard-coded directory to ultimately find a match
        Dim driveScanArray(3) As Char



        'driveScan is converted into an array
        driveScanArray = driveScan.ToCharArray

        'Here the program takes a value from the driveScanArray array and appends it to the hard-coded directory of ":\S6\TakeNote VS 2015\TakeNote.accdb"
        'The Dir function allows us to determine if such a directory exists
        'For example if the program runs through "C:\S6\TakeNote VS 2015\TakeNote.accdb" and Dir function does indeed result in a non-null value then we can create our connString for the database...
        'By concatenating the hard-coded provider ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source =") with the resultant database directory that was found via the Dir function
        'The result will be similar to the following: "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =C:\S6\TakeNote VS 2015\TakeNote.accdb"
        'Because of this we can now use the program to freely interact with the database

        'For debugging purposes the debug version of TakeNote on the USB is prioritised
        For i = 0 To driveScanArray.Length - 1
            If Dir(driveScanArray(i) & ":\S6\TakeNote VS 2015\TakeNote.accdb") <> "" Then
                'Takes the value from the registry directory. If the registry value does not exist (no install has been made) then the value for registryKeyDirectory will be "nothing"
                databaseDirectory = driveScanArray(i) & ":\S6\TakeNote VS 2015\TakeNote.accdb"
            End If
        Next

        'If the debug directory does not exist (release version) the program checks the registry for the directory to use
        If databaseDirectory = "" Then
            'Takes the value from the registry directory. If the registry value does not exist (no install has been made) then the value for registryKeyDirectory will be "nothing"
            registryKeyDirectory = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\TakeNote", "installDir", Nothing)
            databaseDirectory = registryKeyDirectory & "TakeNote.accdb"
        End If


        'If the debug directory exists then the directory from there will be used to be appended to the connString. If not then the drive array will be used to take the directory from the registry
        connString = provider & databaseDirectory

        myConnection.ConnectionString = connString
    End Sub

    Public Sub datasetFill()

        'Clears dataset to prevent duplicate entries
        ds.Clear()

        'We establish the connection with the database
        databaseManagement.myConnection.Open()

        'Declaring variables related to the database
        Dim oledbAdapter As OleDbDataAdapter
        Dim Command As New OleDbCommand("SELECT ID, note, lastWriteTime FROM notes ORDER BY lastWriteTime desc", databaseManagement.myConnection)

        'Here we initialise the variable that will handle our command
        oledbAdapter = New OleDbDataAdapter(Command)

        'The below line takes all content from the notes table and fills the dataset for later use in the program
        oledbAdapter.Fill(databaseManagement.ds)
        'Releases the resources of oledbAdapter
        oledbAdapter.Dispose()

        For i = 0 To databaseManagement.ds.Tables(0).Rows.Count - 1
            'We fill our array with the first column of the dataset. This gives us all of the users notes in an array
            notesFromDatabase(i) = databaseManagement.ds.Tables(0).Rows(i).Item(1)
            'We fill our array with the second column of the dataset. This gives us all of the users last write times in an array
            writeTimesFromDatabase(i) = databaseManagement.ds.Tables(0).Rows(i).Item(2)
        Next

        'Modifies the dimensions of the notesFromDatabase and writeTimesFromDatabase arrays to make them consistent with the number of rows in the database. Reducing memory consumption
        ReDim Preserve notesFromDatabase(databaseManagement.ds.Tables(0).Rows.Count)
        ReDim Preserve writeTimesFromDatabase(databaseManagement.ds.Tables(0).Rows.Count)


        'The connection with the database is closed
        databaseManagement.myConnection.Close()

    End Sub

    Public Sub doesHashExistInDatabase()

        'We establish the connection with the database
        myConnection.Open()

        'The program initialises an enquiry that will search for a hash in the database
        searchString = "Select * FROM gotHash "

        'The parameters for searching the database are initialised
        Dim cmd As OleDbCommand = New OleDbCommand(searchString, myConnection)

        'We begin to read from the database
        dr = cmd.ExecuteReader

        'If the database field that contains the hash is not null AND the flag for changing the user password is set to false the program concludes the user has already set a password
        While dr.Read()
            If dr("calculatedHash").ToString <> "" And passwordChange = False Then
                passwordExists = passwordExists + 1

            End If
        End While

        If passwordExists = 0 Then
            passwordChange = True
        End If
        'The connection with the database is closed
        myConnection.Close()


    End Sub

    Public Sub addEntryToDatabase()

        'Declare variables related to our note
        Dim note As String = ""
        Dim lastWriteTime As String = ""

        'The parameters for writing to the database are initialised
        Dim cmd As New OleDbCommand

        'The parameter determining the directory of the command is established
        cmd.Connection = databaseManagement.myConnection

        'We establish the connection with the database
        databaseManagement.myConnection.Open()

        'Our value for the note that will be written to the database is simply taken from txtTextFromFile.Text
        note = NoteViewer.txtTextFromFile.Text
        'Our value for the lastWriteTime that will be written to the database is the systems current date
        lastWriteTime = Date.Now.Date

        'If the note is simply a modification of a previous one the below block of code will run
        If transferredIsNew = False Then
            'Declaring variables related to the database
            Dim oledbAdapter As OleDbDataAdapter
            Dim Command As New OleDbCommand("SELECT [ID], [note], [lastWriteTime] FROM notes", databaseManagement.myConnection)

            'Here we are modifying the transferred dataset and adding the value for note and lastWriteTime
            'Our transferredIndex allows us to determine which line of the dataset we need to modify while leaving the rest of the data intact
            transferredDS.Tables(0).Rows(transferredIndex).Item(1) = note
            transferredDS.Tables(0).Rows(transferredIndex).Item(2) = lastWriteTime

            'Here we initialise the variable that will handle our command
            oledbAdapter = New OleDbDataAdapter(Command)

            'In order to prevent the program crashing the command we use must be enclosed in brackets before it is ran
            'The code below simply encloses our command with brackets which ultimately prevents the program crashing
            Dim cb As New OleDb.OleDbCommandBuilder(oledbAdapter)
            cb.QuotePrefix = "["
            cb.QuoteSuffix = "]"
            'The below line updates the actual database in line with the newly modified dataset
            oledbAdapter.Update(transferredDS.Tables("Table"))

            'The connection with the database is closed
            databaseManagement.myConnection.Close()
        Else
            'Our command is generated below that aims to insert new values into the database
            cmd.CommandText = "INSERT INTO notes ([note], [lastWriteTime]) VALUES (@note, @lastWriteTime)"

            'The value added to the note field of the database is determined here
            cmd.Parameters.Add("@note", OleDbType.VarWChar, note.Length).Value = note

            'The value added to the lastWriteTime field of the database is determined here
            cmd.Parameters.Add("@lastWriteTime", OleDbType.VarWChar, lastWriteTime.Length).Value = lastWriteTime

            'We create a prepared version of our command
            cmd.Prepare()

            'The values that are created in the lines above are assigned to the parameters representing the fields in the database table
            cmd.Parameters("@note").Value = note
            cmd.Parameters("@lastWriteTime").Value = lastWriteTime

            'The command is executed. Adding our values into the database
            cmd.ExecuteNonQuery()

            'The connection with the database is closed
            databaseManagement.myConnection.Close()
        End If

        'Clears the dataset and sets the flag so that upon the next load of the NoteSelection form the dataset will be filled again. Allowing changes to be shown on the NoteSelection form
        databaseManagement.hasDatasetBeenFilled = False

    End Sub

    Public Sub deleteEntryFromDatabase()

        'The parameters for writing to the database are initialised
        Dim cmd As New OleDbCommand

            'The parameter determining the directory of the command is established
            cmd.Connection = databaseManagement.myConnection

            'We establish the connection with the database
            databaseManagement.myConnection.Open()

            'If the note is simply a modification of a previous one the below block of code will run
            If transferredIsNew = False Then
                'Declaring variables related to the database
                Dim oledbAdapter As OleDbDataAdapter
                Dim Command As New OleDbCommand("SELECT [ID], [note], [lastWriteTime] FROM notes", databaseManagement.myConnection)

                'Here we are modifiying the transferred dataset and deleting the note and lastWriteTime for the users selected note. Removing it from the control array and the database
                'Our transferredIndex allows us to determine which line of the dataset we need to modify while leaving the rest of the data intact
                transferredDS.Tables(0).Rows(transferredIndex).Delete()

                'Here we initialise the variable that will handle our command
                oledbAdapter = New OleDbDataAdapter(Command)

                'In order to prevent the program crashing the command we use must be enclosed in brackets before it is ran
                'The code below simply encloses our command with brackets
                Dim cb As New OleDb.OleDbCommandBuilder(oledbAdapter)
                cb.QuotePrefix = "["
                cb.QuoteSuffix = "]"
                'The below line updates the actual database in line with the newly modified dataset
                oledbAdapter.Update(transferredDS.Tables("Table"))
            End If

        'The connection with the database is closed
        databaseManagement.myConnection.Close()

        'Clears the dataset and sets the flag so that upon the next load of the NoteSelection form the dataset will be filled again. Allowing changes to be shown on the NoteSelection form
        databaseManagement.hasDatasetBeenFilled = False

        'The message displayed to the user is modified based on their chosen language
        If My.Settings.language = "En" Then
            MsgBox("Changes saved successfully!")
            NoteViewer.Close()
        Else
            MsgBox("Los cambios han guardado correctamente!")
            NoteViewer.Close()
        End If
    End Sub


    Public Sub cmdReceiveHashAndSaltFromDatabase(ByVal myConnection As OleDbConnection, ByVal dr As OleDbDataReader, ByRef receivedHash As String, ByRef receivedSalt As String)

        'Declare miscellaneous variables
        Dim searchForHash As String = ""
        Dim searchForSalt As String = ""

        'We establish the connection with the database
        myConnection.Open()

        'The parameters below setup where the other variables will receive their values from in the database

        searchForSalt = "SELECT salty FROM gotSalty "
         searchForHash = "SELECT calculatedHash FROM gotHash "
         Dim cmd As OleDbCommand = New OleDbCommand(searchForHash, myConnection)

        'Hash is only recieved if a normal run through is occuring and a password change is not occuring
        If passwordExists = 1 Then


            'Declaring variable associated with the database


            'We begin to read from the database
            dr = cmd.ExecuteReader

            'The hash is taken from the database and receivedHash receives its value
            While dr.Read()
                receivedHash = dr("calculatedHash")
            End While
        End If

        'The command setup is modified from "searchForHash" to "searchForSalt"
        cmd = New OleDbCommand(searchForSalt, myConnection)

        'We begin to read from the database
        dr = cmd.ExecuteReader

        'The salt is taken from the database and receivedSalt receives its value
        While dr.Read()
            receivedSalt = dr("salty")
        End While

        'The connection with the database is closed
        myConnection.Close()

    End Sub

    Public Sub clearDatabase()
        'Declaring variable associated with the database
        Dim cmd As New OleDbCommand

        'The parameter determining the directory of the command is established
        cmd.Connection = myConnection

        'We establish the connection with the database
        myConnection.Open()

        'BELOW LINE DELETES RECORDS FROM DATABASE
        'THIS IS ONLY NEEDED ON CHANGE OF PASSWORD
        'NOT NEEDED UPON INTIALISATION UNLESS FOR TESTING PURPOSES
        'IT IS ALSO SLOW. VERY SLOW.


        cmd.CommandText = "DELETE * FROM gotHash"
        cmd.ExecuteNonQuery()
        cmd.CommandText = "DELETE * FROM gotSalty"
        cmd.ExecuteNonQuery()

        myConnection.Close()

    End Sub

    Public Sub insertSaltIntoDatabase(ByVal salty As String)

        Dim cmd As New OleDbCommand

        'The parameter determining the directory of the command is established
        cmd.Connection = myConnection

        'We establish the connection with the database
        myConnection.Open()

        'The below lines prepare for adding the salt into the database
        cmd.CommandText = "INSERT INTO gotSalty (salty) VALUES (@salty)"
        cmd.Parameters.Add("@salty", OleDbType.VarWChar, salty.Length).Value = salty

        cmd.Prepare()

        cmd.Parameters("@salty").Value = salty

        'The below line inserts the salt into the gotSalty table in the database
        cmd.ExecuteNonQuery()

        'The connection with the database is closed
        myConnection.Close()
    End Sub

    Public Sub insertHashIntoDatabase(ByVal SHAedstr As String)


        'calculatedHash is given the value of SHAedstr
        Dim calculatedHash As String = SHAedstr

        'Declaring variable associated with the database
        Dim cmd As New OleDbCommand

        'The parameter determining the directory of the command is established
        cmd.Connection = myConnection

        'We establish the connection with the database
        myConnection.Open()

        'The below lines prepare for adding the hash into the database
        cmd.CommandText = "INSERT INTO gotHash(calculatedHash) VALUES (@calculatedHash)"
        cmd.Parameters.Add("@calculatedHash", OleDbType.VarWChar, calculatedHash.Length).Value = calculatedHash

        'We create a prepared version of our command
        cmd.Prepare()

        cmd.Parameters("@calculatedHash").Value = calculatedHash

        'The below line inserts the hash into the gotHash table in the database
        cmd.ExecuteNonQuery()

        'The connection with the database is closed
        myConnection.Close()
    End Sub
End Module