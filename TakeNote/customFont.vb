'Importing namespaces for use in the module
Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Module customFont

    'We create our own font collection to eventually replace the default font collection
    Private _pfc As PrivateFontCollection = Nothing


    Public ReadOnly Property GetInstance(ByVal Size As Single, ByVal style As FontStyle) As Font
        Get
            'If our private collection is Nothing then we load the font from our resources
            If _pfc Is Nothing Then LoadFont()

            'Here we obtain a font object based on the size and style passed in
            Return New Font(_pfc.Families(0), Size, style)

        End Get
    End Property

    Private Sub LoadFont()

        'The private font collection is initialised
        _pfc = New PrivateFontCollection

        'We create a memory pointer for our font resource
        Dim fontMemPointer As IntPtr = Marshal.AllocCoTaskMem(My.Resources.segoeui.Length)

        'Our data is copied into the location specified by the memory pointer
        Marshal.Copy(My.Resources.segoeui, 0, fontMemPointer, My.Resources.segoeui.Length)

        'The memory font is then loaded into the private font collection
        _pfc.AddMemoryFont(fontMemPointer, My.Resources.segoeui.Length)

        'Any leftover memory is released
        Marshal.FreeCoTaskMem(fontMemPointer)

    End Sub

    Public Sub setFont()

        'The font from the private font collection overrides what would normally be the font
        'In operating sytems prior to Windows 8 Microsoft Sans Serif would be used instead of Segoi UI. Resulting in misplaced form elements due to the difference in size
        'This will no longer occur
        If Welcome.IsHandleCreated = True Then
            Welcome.lblWelcome.Font = customFont.GetInstance(Welcome.lblWelcome.Font.Size, FontStyle.Regular)
            Welcome.lblStart.Font = customFont.GetInstance(Welcome.lblStart.Font.Size, FontStyle.Regular)
        End If

        If About.IsHandleCreated = True Then
            About.lblAboutLine1.Font = customFont.GetInstance(About.lblAboutLine1.Font.Size, FontStyle.Regular)
            About.lblAboutLine2.Font = customFont.GetInstance(About.lblAboutLine2.Font.Size, FontStyle.Regular)
        End If

        If NoteSelection.IsHandleCreated = True Then
            NoteSelection.lblWelcome.Font = customFont.GetInstance(NoteSelection.lblWelcome.Font.Size, FontStyle.Regular)
            NoteSelection.cmdNewNote.Font = customFont.GetInstance(NoteSelection.cmdNewNote.Font.Size, FontStyle.Regular)
            NoteSelection.lblNoNotes.Font = customFont.GetInstance(NoteSelection.lblNoNotes.Font.Size, FontStyle.Regular)
            NoteSelection.lblNoNotes1.Font = customFont.GetInstance(NoteSelection.lblNoNotes1.Font.Size, FontStyle.Regular)

            For i = 0 To loopCondition
                textfilePreviewButton(i).Font = customFont.GetInstance(NoteSelection.lblWelcome.Font.Size, FontStyle.Regular)
                lastModificationDateButton(i).Font = customFont.GetInstance(NoteSelection.lblWelcome.Font.Size, FontStyle.Regular)
            Next
        End If

        If NoteViewer.IsHandleCreated = True Then
            NoteViewer.cmdDelete.Font = customFont.GetInstance(NoteViewer.cmdDelete.Font.Size, FontStyle.Regular)
            NoteViewer.cmdSave.Font = customFont.GetInstance(NoteViewer.cmdSave.Font.Size, FontStyle.Regular)
            NoteViewer.txtTextFromFile.Font = customFont.GetInstance(NoteViewer.txtTextFromFile.Font.Size, FontStyle.Regular)
        End If

        If Settings.IsHandleCreated = True Then
            Settings.lblLanguage.Font = customFont.GetInstance(Settings.lblLanguage.Font.Size, FontStyle.Regular)
            Settings.lblTheme.Font = customFont.GetInstance(Settings.lblTheme.Font.Size, FontStyle.Regular)
            Settings.lblPassword.Font = customFont.GetInstance(Settings.lblPassword.Font.Size, FontStyle.Regular)
            Settings.lblSettings.Font = customFont.GetInstance(Settings.lblSettings.Font.Size, FontStyle.Regular)
        End If

        If OutputFramework.IsHandleCreated = True Then
            OutputFramework.lblEnterPassword.Font = customFont.GetInstance(OutputFramework.lblEnterPassword.Font.Size, FontStyle.Regular)
            OutputFramework.txtInput.Font = customFont.GetInstance(12, FontStyle.Regular)
        End If




    End Sub
End Module
