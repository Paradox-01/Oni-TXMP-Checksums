Imports System.IO

' tested only with Oni PC retail on Windows 10
' built with .NET framework 4.6.1

Public Class Form1
    Dim inputPath As String = ""
    Dim VerifiedByUser As String = ""
    Dim Plateform As String = ""
    Dim Language As String = ""
    Dim StandAloneOrBundled As String = ""
    Dim ISBN As String = ""
    Dim SpecialNote As String = ""

    ' idea for a future version
    'Dim OffsetPcRetail As Integer = 40
    'Dim OffsetPcDemo As Integer = 40
    'Dim OffsetPcAlpha As Integer = 40
    'Dim OffsetMacRetail As Integer = 40
    'Dim OffsetMacDemo As Integer = 40
    'Dim OffsetMacAlpha As Integer = 40

    ' for now always start with 40
    ' see function "getTxmpStats"
    ' which has FileStream1.Position = 40

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim appLocation As String = Application.StartupPath & Path.DirectorySeparatorChar


        If My.Settings.LastUsedFolder.Length > 0 Then
            tbInput.Text = My.Settings.LastUsedFolder
            inputPath = My.Settings.LastUsedFolder
        Else
            tbInput.Text = appLocation
            inputPath = appLocation
        End If

        If My.Settings.UserNameOrAlias.Length > 0 Then
            tbUser.Text = My.Settings.UserNameOrAlias
            VerifiedByUser = My.Settings.UserNameOrAlias
        Else
            'tbUser.Text = Environment.UserName
            'VerifiedByUser = Environment.UserName
        End If

        ' set default
        cbPlateform.SelectedIndex = 0
        cbLanguage.SelectedIndex = 0
        cbStandAloneOrBundled.SelectedIndex = 0
    End Sub

    Private Sub btWriteChecksums_Click(sender As Object, e As EventArgs) Handles btWriteChecksums.Click
        inputPath = tbInput.Text
        If inputPath.Length <= 1 Then
            MsgBox("Too short path.")
            Exit Sub
        End If

        ' is valid path ? does it end with a "\" ?
        If Directory.Exists(inputPath) Then
            If Not tbInput.Text.Substring(inputPath.Length - 1) = "\" Then
                inputPath = inputPath & Path.DirectorySeparatorChar
            End If
            My.Settings.LastUsedFolder = inputPath
        Else
            Exit Sub
        End If

        'is GDF the last folder of input path ?
        Dim folderArray As Array = Split(inputPath, "\")
        ' due to last character "\" the last item is empty, ergo we substract 1
        If LCase(folderArray(UBound(folderArray) - 1)) = "gamedatafolder" Then
            writeChecksumsOfAllLevelFolders(inputPath)
            Exit Sub
        End If
        ' if not GDF continue with this simpler checksum getter function

        ' ####################################################################

        If My.Settings.UserNameOrAlias <> tbUser.Text Then
            My.Settings.UserNameOrAlias = tbUser.Text
        End If
        VerifiedByUser = tbUser.Text
        Console.WriteLine(tbUser.Text)
        Console.WriteLine(My.Settings.UserNameOrAlias)

        Plateform = cbPlateform.Text
        Language = cbLanguage.Text
        StandAloneOrBundled = cbStandAloneOrBundled.Text
        ISBN = tbISBN.Text
        SpecialNote = tbSpecialNote.Text

        Dim di As DirectoryInfo = New DirectoryInfo(inputPath)
        Dim enc As New System.Text.UTF8Encoding
        Dim XMLobj As Xml.XmlTextWriter = New Xml.XmlTextWriter(inputPath & "checksums.xml", enc)
        With XMLobj
            .Formatting = Xml.Formatting.Indented
            .Indentation = 4
            .WriteStartDocument()
            .WriteStartElement("Files")
            .WriteAttributeString("VerifiedByUser", VerifiedByUser)
            .WriteAttributeString("Plateform", Plateform)
            .WriteAttributeString("Language", Language)
            .WriteAttributeString("BoughtAs", StandAloneOrBundled)
            .WriteAttributeString("ISBN", ISBN)
            .WriteAttributeString("SpecialNote", SpecialNote)

            For Each fi In di.GetFiles()
                ' skip file if name does not start with prefix "txmp"
                If Not LCase(fi.Name.ToString.Substring(0, 4)) = LCase("txmp") Then Continue For

                Dim infoReader As System.IO.FileInfo
                infoReader = My.Computer.FileSystem.GetFileInfo(inputPath & fi.Name)

                'MsgBox(Math.Round(infoReader.Length / 1024 / 1024, 4) & " MB")
                If Not fi.Name = "checksums.xml" And Not Math.Round(infoReader.Length / 1024 / 1024, 4) > 2000 Then
                    .WriteStartElement("File")
                    .WriteAttributeString("Name", fi.Name)
                    Dim bytes2 = My.Computer.FileSystem.ReadAllBytes(inputPath & fi.Name)
                    .WriteAttributeString("CheckSum", createChecksum(bytes2))
                    .WriteAttributeString("TxmpStats", getTxmpStats(fi.FullName))
                    Console.WriteLine(fi.FullName)
                    .WriteEndElement()
                End If
            Next
            .WriteEndElement()
            .Close()
        End With
        Console.WriteLine("done")
    End Sub

    Private Function writeChecksumsOfAllLevelFolders(GDF As String)
        Dim levelFolders
        levelFolders = My.Computer.FileSystem.GetDirectories(GDF, FileIO.SearchOption.SearchTopLevelOnly, "level*_Final")
        If levelFolders.count = 0 Then
            Exit Function
        End If

        If My.Settings.UserNameOrAlias <> tbUser.Text Then
            My.Settings.UserNameOrAlias = tbUser.Text
        End If
        VerifiedByUser = tbUser.Text
        Console.WriteLine(tbUser.Text)
        Console.WriteLine(My.Settings.UserNameOrAlias)

        Plateform = cbPlateform.Text
        Language = cbLanguage.Text
        StandAloneOrBundled = cbStandAloneOrBundled.Text
        ISBN = tbISBN.Text
        SpecialNote = tbSpecialNote.Text

        Dim di As DirectoryInfo ' = New DirectoryInfo(inputPath)

        Dim enc As New System.Text.UTF8Encoding
        Dim XMLobj As Xml.XmlTextWriter = New Xml.XmlTextWriter(inputPath & "checksums.xml", enc)

        With XMLobj
            .Formatting = Xml.Formatting.Indented
            .Indentation = 4
            .WriteStartDocument()
            .WriteStartElement("GDF")
            .WriteAttributeString("VerifiedByUser", VerifiedByUser)
            .WriteAttributeString("Plateform", Plateform)
            .WriteAttributeString("Language", Language)
            .WriteAttributeString("BoughtAs", StandAloneOrBundled)
            .WriteAttributeString("ISBN", ISBN)
            .WriteAttributeString("SpecialNote", SpecialNote)

            For Each lf In levelFolders
                di = New DirectoryInfo(lf)

                .WriteStartElement("Level") ' start level tag
                .WriteAttributeString("Name", Path.GetFileName(lf))

                For Each fi In di.GetFiles()
                    ' skip file if name does not start with prefix "txmp"
                    If Not LCase(fi.Name.ToString.Substring(0, 4)) = LCase("txmp") Then Continue For

                    Dim infoReader As System.IO.FileInfo
                    infoReader = My.Computer.FileSystem.GetFileInfo(lf & "\" & fi.Name)

                    'MsgBox(Math.Round(infoReader.Length / 1024 / 1024, 4) & " MB")
                    If Not fi.Name = "checksums.xml" And Not Math.Round(infoReader.Length / 1024 / 1024, 4) > 2000 Then
                        .WriteStartElement("File")
                        .WriteAttributeString("Name", fi.Name)
                        Dim bytes2 = My.Computer.FileSystem.ReadAllBytes(lf & "\" & fi.Name)
                        .WriteAttributeString("CheckSum", createChecksum(bytes2))
                        .WriteAttributeString("TxmpStats", getTxmpStats(fi.FullName))
                        Console.WriteLine(fi.FullName)
                        .WriteEndElement()
                    End If
                Next

                .WriteEndElement() ' end level tag

            Next
            .WriteEndElement()
            .Close()
        End With
        Console.WriteLine("done")
    End Function

    Private Function createChecksum(filebytes() As Byte) As String
        Dim sha1Obj As New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = sha1Obj.ComputeHash(filebytes)
        Dim strResult As String = ""
        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function

    Private Sub tbInput_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tbInput.MouseDoubleClick
        If Directory.Exists(inputPath) Then
            ' show folder that contains the xml file
            Process.Start(inputPath)
        End If
    End Sub

    Private Function getTxmpStats(txmpFilePath As String) As String
        'txmpFilePath = "C:\Users\ggp\Desktop\Oniverse\Oni 1 game\GameDataFolder\level19_Final\TXMPA3_FLATBED.oni" ' test
        Dim FileStream1 As New IO.FileStream(txmpFilePath, IO.FileMode.Open)
        Dim txmpStats As String = ""
        Dim txmpOffsetToContent As Integer


        'txmp headers can have different sizes so we need to see where actual content starts
        FileStream1.Position = 40
        'points to actual content
        txmpOffsetToContent = CInt("&H" & Hex(FileStream1.ReadByte))
        ' skip 167 positions of no interest
        txmpOffsetToContent = txmpOffsetToContent + 167
        Console.WriteLine(txmpOffsetToContent)


        FileStream1.Position = txmpOffsetToContent
        Console.WriteLine("flag1: " & Hex(FileStream1.ReadByte))
        txmpStats = "flags(" & Hex(FileStream1.ReadByte) & "-"
        FileStream1.Position = txmpOffsetToContent + 1
        Console.WriteLine("flag2: " & Hex(FileStream1.ReadByte))
        txmpStats = txmpStats & Hex(FileStream1.ReadByte) & "-"
        FileStream1.Position = txmpOffsetToContent + 2
        Console.WriteLine("flag3: " & Hex(FileStream1.ReadByte))
        txmpStats = txmpStats & Hex(FileStream1.ReadByte) & "-"
        FileStream1.Position = txmpOffsetToContent + 3
        Console.WriteLine("flag4: " & Hex(FileStream1.ReadByte))
        txmpStats = txmpStats & Hex(FileStream1.ReadByte) & "),"

        FileStream1.Position = txmpOffsetToContent + 4
        Console.WriteLine("size1: " & Hex(FileStream1.ReadByte)) ' width
        txmpStats = txmpStats & "size(" & Hex(FileStream1.ReadByte) & "-"
        FileStream1.Position = txmpOffsetToContent + 5
        Console.WriteLine("size2: " & Hex(FileStream1.ReadByte))
        txmpStats = txmpStats & Hex(FileStream1.ReadByte) & "-"
        FileStream1.Position = txmpOffsetToContent + 6
        Console.WriteLine("size3: " & Hex(FileStream1.ReadByte)) ' height
        txmpStats = txmpStats & Hex(FileStream1.ReadByte) & "-"
        FileStream1.Position = txmpOffsetToContent + 7
        Console.WriteLine("size4: " & Hex(FileStream1.ReadByte))
        txmpStats = txmpStats & Hex(FileStream1.ReadByte) & "),"

        FileStream1.Position = txmpOffsetToContent + 8
        Console.WriteLine("format1: " & Hex(FileStream1.ReadByte)) ' 
        txmpStats = txmpStats & "format(" & Hex(FileStream1.ReadByte) & "-"
        FileStream1.Position = txmpOffsetToContent + 9
        Console.WriteLine("format2: " & Hex(FileStream1.ReadByte))
        txmpStats = txmpStats & Hex(FileStream1.ReadByte) & "-"
        FileStream1.Position = txmpOffsetToContent + 10
        Console.WriteLine("format3: " & Hex(FileStream1.ReadByte)) ' 
        txmpStats = txmpStats & Hex(FileStream1.ReadByte) & "-"
        FileStream1.Position = txmpOffsetToContent + 11
        Console.WriteLine("format4: " & Hex(FileStream1.ReadByte))
        txmpStats = txmpStats & Hex(FileStream1.ReadByte) & ")"

        'Console.WriteLine(txmpStats)

        FileStream1.Close()
        FileStream1.Dispose()

        Return txmpStats
    End Function

End Class
