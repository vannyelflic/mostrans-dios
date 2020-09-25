Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography

Public Class Mysql
    Public strConn As String = "Data Source=sql2016-01\epm;Initial Catalog=DC_Monitoring;Persist Security Info=True;User ID=RDCMon;Password=Monitoring2018;pooling=false;"
    Public oConn As New SqlConnection(strConn)
    Public oDa As SqlDataAdapter
    Public oDs As New DataSet
    Public oCmd As SqlCommand
    Public oDR As SqlDataReader
    Public trans As SqlTransaction


    Public Sub OpenConnection()

        If oConn.State = ConnectionState.Open Then
            oConn.Close()
        End If
        oConn.Open()

    End Sub

    Public Sub CloseConnection()
        If oConn.State = ConnectionState.Open Then
            oConn.Close()
        End If
    End Sub


    Public Function CreateDataSet(ByVal strSQL As String,
          Optional ByVal sqlParam As SqlParameter = Nothing) As DataSet

        OpenConnection()

        Dim scnnNW As New SqlConnection(strConn)

        Dim scmd As New SqlCommand(strSQL, scnnNW)
        scmd.CommandTimeout = 600
        If Not IsNothing(sqlParam) Then
            scmd.Parameters.Add(sqlParam)
        End If

        Dim sda As New SqlDataAdapter(scmd)

        Dim ds As New DataSet
        sda.Fill(ds)

        Return ds
        CloseConnection()
    End Function

    Function CreateDataReader(ByVal strSQL As String) As SqlDataReader
        OpenConnection()
        oCmd = New SqlCommand

        With oCmd
            .Connection = oConn
            .CommandType = CommandType.Text
            .CommandText = strSQL
            oDR = .ExecuteReader
        End With

        CreateDataReader = oDR
        oCmd.Dispose()

        Return CreateDataReader
    End Function

    Function GetDataReader(ByVal strSQL As String, ByVal iFieldIndex As Int16) As String
        GetDataReader = ""
        OpenConnection()
        oCmd = New SqlCommand

        With oCmd
            .Connection = oConn
            .CommandType = CommandType.Text
            .CommandText = strSQL
            oDR = .ExecuteReader
        End With


        If oDR.RecordsAffected = -1 Then
            While oDR.Read
                If IsDBNull(oDR.Item(iFieldIndex)) Then
                    GetDataReader = ""
                Else
                    GetDataReader = oDR.Item(iFieldIndex).ToString
                End If
            End While
        End If

        CloseConnection()

        Return GetDataReader
    End Function

    Function GetDataReaderNum(ByVal strSQL As String, ByVal iFieldIndex As Int16) As Integer
        GetDataReaderNum = 0
        OpenConnection()
        oCmd = New SqlCommand

        With oCmd
            .Connection = oConn
            .CommandType = CommandType.Text
            .CommandText = strSQL
            oDR = .ExecuteReader
        End With

        If oDR.RecordsAffected = -1 Then
            While oDR.Read
                If IsDBNull(oDR.Item(iFieldIndex)) Then
                    GetDataReaderNum = 0
                Else
                    GetDataReaderNum = oDR.Item(iFieldIndex)
                End If
            End While
        End If

        CloseConnection()

        Return GetDataReaderNum
    End Function

    Sub ExecuteDataReader(ByVal strSQL As String)

        OpenConnection()
        oCmd = New SqlCommand

        With oCmd
            .Connection = oConn
            .CommandType = CommandType.Text
            .CommandText = strSQL
            oDR = .ExecuteReader
        End With

        CloseConnection()

    End Sub

    Function ExecuteDataSQL(ByVal strSQL As String) As Integer

        OpenConnection()
        oCmd = New SqlCommand
        trans = oConn.BeginTransaction()

        Try
            With oCmd
                .Transaction = trans
                .Connection = oConn
                .CommandType = CommandType.Text
                .CommandText = strSQL
                .ExecuteNonQuery()
                trans.Commit()
            End With
            Return 1
        Catch ex As Exception
            trans.Rollback()
            Return 0
        End Try

        CloseConnection()
    End Function





    Function GetSplit(ByVal sParam As String) As String
        Dim i As Integer
        Dim j As Integer = 0
        Dim x As String

        GetSplit = ""

        For i = 0 To Len(sParam) - 1
            x = sParam.Substring(i, 1)
            If x = "," Then
                j = j + 1
            End If
        Next
        GetSplit = "('"
        If j > 0 Then
            For i = 0 To j
                GetSplit = GetSplit + sParam.Split(",")(i)
                If i <> j Then
                    GetSplit = GetSplit + "','"
                End If
            Next
        ElseIf j = 0 Then
            GetSplit = GetSplit + sParam
        End If
        GetSplit = GetSplit + "')"

        Return GetSplit
    End Function


    Function EEncryp(ByVal mystr As String) As String

        Try


            Dim enc As System.Text.UTF8Encoding
            Dim encryptor As ICryptoTransform
            Dim decryptor As ICryptoTransform

            Dim KEY_128 As Byte() = {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}
            Dim IV_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}
            Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC

            enc = New System.Text.UTF8Encoding
            encryptor = symmetricKey.CreateEncryptor(KEY_128, IV_128)
            decryptor = symmetricKey.CreateDecryptor(KEY_128, IV_128)

            Dim sPlainText As String = mystr
            If Not String.IsNullOrEmpty(sPlainText) Then
                Dim memoryStream As MemoryStream = New MemoryStream()
                Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
                cryptoStream.Write(enc.GetBytes(sPlainText), 0, sPlainText.Length)
                cryptoStream.FlushFinalBlock()
                EEncryp = Convert.ToBase64String(memoryStream.ToArray())
                memoryStream.Close()
                cryptoStream.Close()
            Else
                EEncryp = ""
            End If

        Catch ex As Exception
            EEncryp = "                    "
        End Try

    End Function

    Function EDecrypt(ByVal mystr As String) As String

        Try


            Dim enc As System.Text.UTF8Encoding
            Dim encryptor As ICryptoTransform
            Dim decryptor As ICryptoTransform

            Dim KEY_128 As Byte() = {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}
            Dim IV_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}
            Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC

            enc = New System.Text.UTF8Encoding
            encryptor = symmetricKey.CreateEncryptor(KEY_128, IV_128)
            decryptor = symmetricKey.CreateDecryptor(KEY_128, IV_128)
            Dim cypherTextBytes As Byte() = Convert.FromBase64String(mystr)
            Dim memoryStream As MemoryStream = New MemoryStream(cypherTextBytes)
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
            Dim plainTextBytes(cypherTextBytes.Length) As Byte
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            memoryStream.Close()
            cryptoStream.Close()
            EDecrypt = enc.GetString(plainTextBytes, 0, decryptedByteCount)

        Catch ex As Exception
            EDecrypt = "                    "

        End Try

    End Function

    Function ERndSTr() As String
        Dim mystr As String
        mystr = Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "")
        ERndSTr = mystr
    End Function

    Function mydefault() As StringBuilder
        Dim myhtml As New StringBuilder
        myhtml.Append("<ul class='cb-slideshow`>")
        myhtml.Append("<li><span>Image 01</span><div><h1></h1></div></li>")
        myhtml.Append("<li><span>Image 02</span><div><h3></h3></div></li>")
        myhtml.Append("<li><span>Image 03</span><div><h3></h3></div></li>")
        myhtml.Append("</ul>")
        mydefault = myhtml
    End Function

    Function bersih(ByVal mystr As String) As String
        Dim nstr As String
        nstr = mystr.Replace("'", "''")
        nstr = nstr.Replace("--", "")
        nstr = nstr.Replace("!-", "")
        nstr = nstr.Replace("<", "")
        nstr = nstr.Replace(">", "")
        bersih = nstr
    End Function

    Function bersihU(ByVal mystr As String) As String
        Dim nstr As String
        nstr = UCase(bersih(mystr))
        bersihU = nstr
    End Function

End Class
