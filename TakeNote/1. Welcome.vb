'Using import allows certain type names to be used within the program. An example of this is System.Security.Cryptography.RNGCryptoServiceProvider() which gives us a more secure method of generating a random number.
Imports System.Data.OleDb
Public Class Welcome
    'WORK IN PROGRESS
    '"LE COMPLETE MESS"
    'BY LIAM HARPER

    Private Sub Welcome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Upon initialisation of the form the program runs two sub-routines which are located in the Languages and Themes modules
        'These sub-routines establish the language and theme the user has selected from a previous execution (if first execution the default language is English etc)
        'These sub-routines are in control of all aspects of the form including the colour and the text itself.
        languageCheck()
        'setFont ensures that the font used in the program will ALWAYS be Segoi UI. This prevents form elements being misplaced around forms due to different sizes of fonts
        setFont()
        setTheme()
    End Sub

    Private Sub cmdAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbout.Click
        'Upon click of the button the 'About' form will be opened
        About.Show()
    End Sub

    Private Sub pctOpening_Click(sender As Object, e As EventArgs) Handles pctWelcome.Click
        'If the picturebox is clicked the program will initialise the subroutine that handles the setting up of the database and the encryption/authentication side of the program
        cmdIntitialisation()
    End Sub

    Private Sub lblStart_Click(sender As Object, e As EventArgs) Handles lblStart.Click
        'If the label containing the title is clicked the program will initialise the subroutine that handles the setting up of the database and the encryption/authentication side of the program
        cmdIntitialisation()
    End Sub


    Private Sub cmdIntitialisation()

        'The database is initialised and the directory determining its location is set to allow the program to connect back and forth with the database
        databaseManagement.initialiseDatabase()

        'Checks if hash already exists in database (is user new or not). If so flags are set accordingly
        databaseManagement.doesHashExistInDatabase()

        'The if statements below simply changes the message box text in accordance with whether or not the user is creating a new password. If they are then the text is "re-enter" rather than "enter"

        'Afterwards the OutputFramework form is opened to ask the user for their password

        OutputFramework.Show()


    End Sub

    Public Sub cmdPasswordGenerator(ByRef generatedUnencryptedPassword As String, ByVal connString As String, ByVal dr As OleDbDataReader, ByVal myConnection As OleDbConnection)


        'Declare variables associated with the database
        searchString = "Select * FROM tableOfStrings "
        Dim cmd As OleDbCommand = New OleDbCommand(searchString, myConnection)

        'Declare other miscellaneous variables
        'The password array is 2 - dimensional
        Dim password(99, 99) As String
        Dim y As Integer = 0
        Dim z As Integer = 0
        Dim txtName(99) As String
        Dim txtRandomNumber(99) As String
        Dim txtCountry(99) As String
        Dim counter As String = 0

        'We establish the connection with the database
        myConnection.Open()

        'We begin to read from the database
        dr = cmd.ExecuteReader

        'The program fills the below arrays with the contents of the fields from the database
        For i = 0 To 99
            While dr.Read()
                txtName(i) = dr("name").ToString
                txtRandomNumber(i) = dr("randomNumber").ToString
                txtCountry(i) = dr("country").ToString
                'Using a 2-D array we can sort our data into sections WITHIN the array
                'For example "0, counter" will always contain a name etc
                password(0, counter) = txtName(i)
                password(1, counter) = txtRandomNumber(i)
                password(2, counter) = txtCountry(i)
                'We increase the value of counter by one each time the block of code is ran
                counter = counter + 1

            End While

        Next

        'The connection with the database is closed
        myConnection.Close()

        Dim generatedString(2) As String

        'For purposes of explanation our 2-D array will become y and z.
        'The values for y and z are randomly generated from the data obtained from the database so we receive a unique password
        'y is equal to the value of the section of the password (name is section 1, country is section 3 etc)
        'z is randomly given a value between 0 and 99

        'Once y and z have had values generated we then concatenate y and z together to create a combined string
        'The concatenated string becomes our un-encrypted generated password

        'A loop is created that runs three times
        For i = 0 To 2

            'Our password is intended to be based on 3 sections
            'These sections are divided into 3 based on our y value (0, 1 and 2)

            'Section 1 (y = 0)
            'The "Randomize" method ensures that the values generated are random across different executions of the program
            'Without it the first iteration of the loop would always result in z being 2 for example!
            Randomize()
            'Section 1
            y = 0
            'Value of z given value between 0 and 99
            z = CInt(Int((99 * Rnd()) + 0))
            'generatedString is the section of the password we have just generated
            generatedString(i) = password(y, z)
            i = i + 1
            'Section 2 (y = 1)
            y = 1
            'Value of z given value between 0 and 99
            z = CInt(Int((99 * Rnd()) + 0))
            generatedString(i) = password(y, z)
            i = i + 1
            'Section 3 (y = 2)
            y = 2
            'Value of z given value between 0 and 99
            z = CInt(Int((99 * Rnd()) + 0))
            generatedString(i) = password(y, z)
            i = i + 1
            'The "Join" method simply combines the values of each index together. Creating a concatenated string
            generatedUnencryptedPassword = Join(generatedString, "")
            'The concatenated, generated password is displayed to the user here to note down for further reference. Prior to the following encryption
            If My.Settings.language = "Es" Then
                MsgBox("La contraseña es " & generatedUnencryptedPassword & ". Por favor anótelo ya que esta será la última vez que lo veo en su forma actual!")
            Else
                MsgBox("Your password is " & generatedUnencryptedPassword & ". Please write it down as this will be the last time you see it in its current form!")
            End If
            'The next iteration of the loop occurs
        Next
    End Sub


End Class

