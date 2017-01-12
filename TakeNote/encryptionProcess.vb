'Using import allows certain type names to be used within the program. An example of this is System.Security.Cryptography.RNGCryptoServiceProvider() which gives us a more secure method of generating a random number.
Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text

Module EncryptionProcess

    'Declare miscellaneous variables that are used throughout several subroutines
    Public plaintextPasswordCombinedWithSalt As String = ""
    Public SHAedstr As String = ""
    Public generatedUnencryptedPassword As String = ""
    Public salty As String = ""
    Public passwordToBeReentered As Boolean = False
    Public enteredPassword As String = OutputFramework.lblEnterPassword.Text
    Public isGeneratedPassword As Boolean
    Public filenameoutput As String = ""


    Public Sub passwordProcessing()

        'Declare miscellaneous variable(s) 
        'Choice is a string here so that the program does not crash when a non-number is entered using the choice input box
        Dim choice As String = ""

        'Block below only runs if the password does not exist or is being reset
        If databaseManagement.passwordExists = 0 Then

            Do
                'An input box is presented to the user
                'If the user inputs "1" then they can use their own password otherwise a password is generated for them
                If My.Settings.language = "En" Then
                    choice = InputBox("Hello new user! Please enter 1 to enter your own custom password or enter 2 to receive a randomly generated password for use in the program!")
                Else
                    choice = InputBox("Hola nuevo usuario ! Introduzca 1 para introducir su propia contraseña personalizada o introduzca 2 para recibir una contraseña generada aleatoriamente para su uso en el programa!")
                End If

                'Input validation is used so that the user cannot enter a null value for choice
                If choice <> "1" Or choice <> "2" Then
                    If My.Settings.language = "En" Then
                        MsgBox("Please enter a number consisting of 1 or 2.")
                    Else
                        MsgBox("Por favor, introduzca un número que consta de 1 ó 2.")
                    End If
                End If
            Loop Until choice = "1" Or choice = "2"

            'If choice is "1" then only the minimal subroutines are ran to process the users new password
            If choice = "1" Then
                If My.Settings.language = "En" Then

                    OutputFramework.Show()
                    OutputFramework.BringToFront()
                    OutputFramework.lblEnterPassword.Text = "Please enter your new password."
                    enteredPassword = OutputFramework.txtInput.Text
                Else

                    OutputFramework.Show()
                    OutputFramework.BringToFront()
                    OutputFramework.lblEnterPassword.Text = "Por favor, introduzca su nueva contraseña."
                    enteredPassword = OutputFramework.txtInput.Text
                End If

                'If choice is "2" then additional subroutines are ran that generates a password and isGeneratedPassword is set to True in order for other subroutines to recognise the password has been generated
            ElseIf choice = "2" Then
                'If the user inputs "2" then a password is randomly generated via the execution of the password generator sub-routine
                'After the password generator sub-routine runs the encryption sub-routines then undergo execution to encrypt the randomly generated password
                Welcome.cmdPasswordGenerator(generatedUnencryptedPassword, databaseManagement.connString, databaseManagement.dr, databaseManagement.myConnection)
                'Flag set so that the GetSalty subroutine changes it behaviour based on the password being generated
                isGeneratedPassword = True
                EncryptionProcess.GetSalty(enteredPassword, filenameoutput, databaseManagement.myConnection, generatedUnencryptedPassword, salty, isGeneratedPassword, plaintextPasswordCombinedWithSalt)
                'The verifcation variant of the hash generation subroutine is ran so that nothing is written to the database
                Authentication.GetSHA256Verification(passwordForVerification, EncryptionProcess.SHAedstr, calculatedHashForVerification)
                'Sets values so we program thinks we are on the 2nd entry of password input ("Please re-enter your password)
                isGeneratedPassword = False
                enteredPasswordCounter = 1
                passwordChange = True
                OutputFramework.Show()
                If My.Settings.language = "Es" Then
                    OutputFramework.lblEnterPassword.Text = "Por favor re ingrese su contraseña."
                End If
            Else
                'If an invalid input is entered (neither 1 or 2) then an error message is displaying resulting in the user re-entering their choice until it meets the specified criteria
                If My.Settings.language = "En" Then
                    MsgBox("Please enter a number consisting of 1 or 2.")
                Else
                    MsgBox("Por favor, introduzca un número que consta de 1 ó 2.")
                End If
            End If
        End If

    End Sub
    Public Sub GetSalty(ByRef enteredPassword As String, ByRef filenameOutput As String, ByVal myConnection As OleDbConnection, ByRef generatedUnencryptedPassword As String, ByVal salty As String, ByVal isGeneratedPassword As Boolean, ByRef plaintextPasswordCombinedWithSalt As String)

        'Declare miscellaneous variables

        'In the line below the program sets up commonly used drive letters to browse through to find the database. However this method can be difficult to implement as each system has different drive letters
        'The main issue is that if the program attempts to browse a drive letter that represents a particular drive (such as a DVD drive) the program will crash. This is simply because the system does indeed consider the DVD drive as an existing drive regardless of whether a DVD is inserted...
        'But however as there is literally no data to scan through (provided no DVD is inserted) the program will encounter a NullReferenceException error and crash
        'It should be noted that this crash is not exclusive to DVD drives. Another example is a network drive to which the user is prohibited to.
        'Thus it would be ideal if a more concrete method was used to process all system drives to search for a directory without resulting in a crash
        Dim drivesToWriteTo As String = "CEGHN"
        Dim driveWriteArray(5) As Char


        'Declare variables associated with generated random output
        'System.Security.Cryptography.RNGCryptoServiceProvider() allows us to use a secure method that in the contect of the program will generate random bytes
        Dim rng As New System.Security.Cryptography.RNGCryptoServiceProvider()
        'Our salt will be 32 bits
        Dim byteRNG(31) As Byte

        'Below line fills an array with a random selection of bytes in a secure manner
        rng.GetBytes(byteRNG)

        'These random bytes are then converted to a Base64String comprised of letters, numbers and symbols)
        salty = Convert.ToBase64String(byteRNG)

        'If the plaintext password has been generated then the variable containing it will be concatenated with the randomly generated salt
        If isGeneratedPassword = True Then
            passwordForVerification = generatedUnencryptedPassword + salty
        Else
            'If the plaintext password has not been generated then the variable containing the users typed password will be concatenated with the randomly generated salt
            plaintextPasswordCombinedWithSalt = enteredPassword + salty
        End If

        'At this point the program now has a password and a salt.
        'For example "testGjjw&722"

        driveWriteArray = drivesToWriteTo.ToCharArray


        If databaseManagement.passwordChange = True Then
            'Our database is cleared out
            databaseManagement.clearDatabase()
        End If

        'The salt we create is inserted into the database here
        databaseManagement.insertSaltIntoDatabase(salty)

    End Sub

    Public Sub GetSHA256(ByVal SHAedstr As String, ByVal myconnection As OleDbConnection, ByRef plaintextPasswordCombinedWithSalt As String)

        'Declare variables associated with encryption

        'The SHA256Managed class will allow us to compute the SHA256 hash based on the users password
        Dim SHA256 As New SHA256Managed

        'The line below simply converts the users password into an array of bytes
        Dim strBytes() As Byte = Encoding.Default.GetBytes(plaintextPasswordCombinedWithSalt)

        'The line below generates the SHA-256 hash by using the byte array "strBytes" and the SHA256Managed class
        Dim hash() As Byte = SHA256.ComputeHash(strBytes)

        'The subroutine below converts our byte array into a hexadecimal format
        convertByteArrayToHexadecimal(hash, plaintextPasswordCombinedWithSalt, SHAedstr)

        'The hash we create is inserted into the database here
        databaseManagement.insertHashIntoDatabase(SHAedstr)
    End Sub

    Public Sub convertByteArrayToHexadecimal(ByVal hash() As Byte, ByVal salty As String, ByRef SHAedstr As String)

        'The below line changes the dimensions of the strBuilder based on the length of the hash
        Dim strBuilder As New StringBuilder(hash.Length)
        'The loop runs based on the number of characters in the hash
        For i As Integer = 0 To hash.Length - 1
            'The below line appends the created hash together and "X2" converts the bytes into a hexadecimal format
            strBuilder.Append(hash(i).ToString("X2"))
        Next

        'Converts strBuilder to a string and gives its value to SHAedstr
        'At this point we have our complete hash
        SHAedstr = (strBuilder.ToString())

        'Our hash is stored so that it can be compared to the typed password on the 2nd password entry
        If isGeneratedPassword = True Then
            previousHash = SHAedstr
        End If
    End Sub

End Module