Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text


Module Authentication
    Public enteredPasswordCounter As Integer = 0
    Public previousHash As String
    Public passwordForVerification As String = ""
    Public calculatedHashForVerification As String = ""



    'Our program verifies the password by repeating the process the intital password went through
    'The only difference being that a new salt is not created. The salt used is from the database
    'If the salt is wdnd&dw2 and the users entered password is test
    'Then testwdnd&dw2 will always produce the same hash
    'Meaning that we can compare the two hashes (i.e. the hash generated in the code below and the hash in the database) and allow the user to proceed if they match

    'The process works indentically for a password change/new password except that rather than a database copy being verified a variable containing the hash generated from attempt 1 is compared with the hash for attempt 2

    Public Sub cmdAuthentication()

        'Declare miscellaneous variables

        Dim decryptedPassword As String = ""
        Dim enteredPassword As String = OutputFramework.txtInput.Text

        Dim receivedHash As String = ""
        Dim receivedSalt As String = ""

        isGeneratedPassword = False
        'Running the subroutine that takes in the hash and salt from the database
        databaseManagement.cmdReceiveHashAndSaltFromDatabase(databaseManagement.myConnection, databaseManagement.dr, receivedHash, receivedSalt)

        'The received salt is concatenated with the users password in the same manner as it would if the password was being created
        passwordForVerification = enteredPassword + receivedSalt

        'A slightly modified version of the GetSHA256 subroutine runs. The only difference being the database is not written to
        GetSHA256Verification(passwordForVerification, EncryptionProcess.SHAedstr, calculatedHashForVerification)

        'This is our 2nd entry of entering our new password. This is the attempt where the password is encrypted and written to the database if it matches the password used in the first attempt
        If enteredPasswordCounter = 1 And passwordChange = True Then
            Do
                'If the hashes match from attempt 1 and attempt 2 we display a message
                If calculatedHashForVerification = previousHash Then
                    'A salt is generated and the password is encrypted via SHA-256. The encrypted password is also written to the database
                    EncryptionProcess.GetSalty(enteredPassword, filenameoutput, databaseManagement.myConnection, generatedUnencryptedPassword, salty, isGeneratedPassword, plaintextPasswordCombinedWithSalt)
                    EncryptionProcess.GetSHA256(SHAedstr, databaseManagement.myConnection, plaintextPasswordCombinedWithSalt)
                    If My.Settings.language = "Es" Then
                        MsgBox("La contraseña se establece!")
                    Else
                        MsgBox("Your password is set!")
                    End If
                    enteredPasswordCounter = 0
                    NoteSelection.Show()
                    Welcome.Hide()
                    OutputFramework.Close()
                Else
                    If My.Settings.language = "Es" Then
                        MsgBox("Tus contraseñas no coinciden. Por favor, vuelva a intentarlo.")
                    Else
                        MsgBox("Your passwords do not match. Please try again.")
                    End If
                    'This simply clears our text box
                    OutputFramework.txtInput.Text = ""
                    Exit Sub
                End If
            Loop Until calculatedHashForVerification = previousHash
        Else
            'Where the user has entered their new password for the first time and the program is requesting the user enters it again a second time
            If passwordChange = True Then
                'Our hash is stored so that it can be compared to the typed password on the 2nd password entry
                previousHash = calculatedHashForVerification
                'We can determine if the password is being processed for the first time or the 2nd
                enteredPasswordCounter = enteredPasswordCounter + 1
                If My.Settings.language = "Es" Then
                    OutputFramework.lblEnterPassword.Text = "Por favor re ingrese su contraseña."
                End If
                OutputFramework.txtInput.Text = ""
                'The code on the ElseIf block only runs during a normal runthrough where no password changes are occuring
            ElseIf receivedHash = calculatedHashForVerification Then
                NoteSelection.Show()
                Welcome.Hide()
                OutputFramework.Close()
            Else
                If My.Settings.language = "Es" Then
                    MsgBox("Tu contraseña es incorrecta. Por favor, inténtalo de nuevo")
                Else
                    MsgBox("Your password is incorrect. Please try again.")
                End If
                'This simply clears our text box
                OutputFramework.txtInput.Text = ""
                Exit Sub
            End If
        End If
    End Sub

    Public Sub GetSHA256Verification(ByVal passwordForVerification As String, ByRef SHAedstr As String, ByRef calculatedHashForVerification As String)

        'Declare variables associated with encryption

        'The SHA256Managed class will allow us to compute the SHA256 hash based on the users password
        Dim SHA256 As New SHA256Managed

        'The line below simply converts the users password into an array of bytes
        Dim strBytes() As Byte = Encoding.Default.GetBytes(passwordForVerification)

        'The line below generates the SHA-256 hash by using the byte array "strBytes" and the SHA256Managed class
        Dim hash() As Byte = SHA256.ComputeHash(strBytes)

        'The subroutine below converts our byte array into a hexadecimal format
        EncryptionProcess.convertByteArrayToHexadecimal(hash, passwordForVerification, EncryptionProcess.SHAedstr)

        'calculatedHashForVerification is given the value of SHAedstr
        calculatedHashForVerification = SHAedstr
    End Sub
End Module
