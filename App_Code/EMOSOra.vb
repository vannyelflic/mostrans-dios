Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports Oracle.DataAccess.Client
Imports Oracle.ManagedDataAccess.Client

Public Class Emosora

    Public oraDB As String = "Data Source=PROD_R12;User Id=apps;Password=M1ckyM0useCLUBHOUSE2017;"
    Public oraConn As New OracleConnection(oraDB) ' VB.NET
    Public oraCmd As New OracleCommand
    Public oraDR As OracleDataReader

    Sub OpenOracleConnection()
        If oraConn.State = Data.ConnectionState.Closed Then
            oraConn.Open()
        End If
    End Sub

    Sub CloseOracleConnection()
        If oraConn.State = Data.ConnectionState.Open Then
            oraConn.Close()
        End If
    End Sub

    Public Function BuildCommand(ByVal strSQL As String) As OracleCommand

        OpenOracleConnection()

        Dim oraCmd As New OracleCommand(strSQL, oraConn)
        oraCmd.CommandTimeout = 600

        With oraCmd
            .Connection = oraConn
            .CommandType = CommandType.Text
            .CommandText = strSQL
            .BindByName = True
        End With

        BuildCommand = oraCmd

        Return BuildCommand
    End Function


    Function ExecuteDataSQLMulti(ByVal DataSQL As Data.DataSet) As String

        Dim strSQL As String = ""
        Dim i As Integer
        'Dim trans As OracleTransaction

        OpenOracleConnection()
        oraCmd = New OracleCommand
        oraConn.BeginTransaction()

        Try
            With oraCmd
                .Connection = oraConn
                For i = 0 To DataSQL.Tables(0).Rows.Count - 1
                    .CommandType = CommandType.Text
                    .CommandText = DataSQL.Tables(0).Rows(i).Item(0)  'strSQL
                    .ExecuteNonQuery()
                Next
                oraCmd.CommandText = "COMMIT"
                oraCmd.ExecuteNonQuery()
            End With
            Return "1"
        Catch ex As Exception
            Dim SQLDummy As String = oraCmd.CommandText
            oraCmd.CommandText = "ROLLBACK"
            oraCmd.ExecuteNonQuery()
            Return "0" & ex.Message & "|" & SQLDummy
        End Try

        CloseOracleConnection()
    End Function

    Public Sub AddParameter(ByVal cmd As OracleCommand, ByVal strParamName As String, ByVal strParamValue As String, ByVal OracleDbType As String)
        Dim OraParam As New OracleParameter(strParamName, OracleDbType.ToString)
        OraParam.Value = strParamValue.ToString
        OraParam.Direction = ParameterDirection.Input
        cmd.Parameters.Add(OraParam)
    End Sub

    Public Function GetDataSet(ByVal cmd As OracleCommand) As DataSet


        ' A SqlDataAdapter uses the oracleCommand object to fill a DataSet.
        Dim oraDA As New OracleDataAdapter(cmd)

        ' Create and Fill a new DataSet.
        Dim oraDS As New Data.DataSet
        oraDA.Fill(oraDS, "0")
        CloseOracleConnection()
        Return oraDS
    End Function

    Function GetDataReader2(ByVal cmd As OracleCommand, ByVal iFieldIndex As Int16) As String
        Try
            GetDataReader2 = ""

            Dim DR As OracleDataReader = cmd.ExecuteReader()


            If DR.RecordsAffected = -1 Then
                While DR.Read
                    If IsDBNull(DR.Item(iFieldIndex)) Then
                        GetDataReader2 = 0
                    Else
                        GetDataReader2 = DR.Item(iFieldIndex)
                    End If
                End While
            End If

            Return GetDataReader2
        Catch er As Exception
            Return er.Message
        End Try
        CloseOracleConnection()
    End Function

    Public Function CreateDataSet(ByVal strSQL As String) As DataSet

        OpenOracleConnection()

        Dim scnnNW As New OracleConnection(oraDB)


        ' A SqlCommand object is used to execute the SQL commands.
        Dim oraCmd As New OracleCommand(strSQL, oraConn)
        oraCmd.CommandTimeout = 600

        ' A SqlDataAdapter uses the SqlCommand object to fill a DataSet.
        Dim oraDA As New OracleDataAdapter(oraCmd)

        ' Create and Fill a new DataSet.
        Dim oraDS As New Data.DataSet
        oraDA.Fill(oraDS, "0")
        CloseOracleConnection()
        Return oraDS
    End Function

    Function CreateDataReader(ByVal strSQL As String) As OracleDataReader
        OpenOracleConnection()

        Dim oraCmd As New OracleCommand
        With oraCmd
            .Connection = oraConn
            .CommandType = CommandType.Text
            .CommandText = strSQL
            oraDR = .ExecuteReader
        End With
        'Dim oraDR As OracleDataReader = oraCmd.ExecuteReader

        CreateDataReader = oraDR

        Return oraDR
    End Function

    Function GetDataReader(ByVal strSQL As String, ByVal iFieldIndex As Int16) As String
        GetDataReader = ""
        OpenOracleConnection()

        Dim oraCmd As New OracleCommand
        With oraCmd
            .Connection = oraConn
            .CommandType = CommandType.Text
            .CommandText = strSQL
            oraDR = .ExecuteReader
        End With

        If oraDR.RecordsAffected = -1 Then
            While oraDR.Read
                If IsDBNull(oraDR.Item(iFieldIndex)) Then
                    GetDataReader = 0
                Else
                    GetDataReader = oraDR.Item(iFieldIndex)
                End If
            End While
        End If

        CloseOracleConnection()

        Return GetDataReader
    End Function

    Function CreateDataReader2(ByVal strSQL As String) As OracleDataReader
        OpenOracleConnection()

        Dim oraCmd As New OracleCommand
        With oraCmd
            .Connection = oraConn
            .CommandType = CommandType.StoredProcedure
            .CommandText = strSQL
            oraDR = .ExecuteReader
        End With
        'Dim oraDR As OracleDataReader = oraCmd.ExecuteReader

        CreateDataReader2 = oraDR
        'oDR.Close()
        '        CloseConnection()
        Return oraDR
    End Function

    Sub ExecuteDataReader(ByVal strSQL As String)

        OpenOracleConnection()

        Dim oraCmd As New OracleCommand
        With oraCmd
            .Connection = oraConn
            .CommandType = CommandType.Text
            .CommandText = strSQL
            oraDR = .ExecuteReader
        End With

        CloseOracleConnection()

    End Sub
    Function GetDataReaderNum(ByVal strSQL As String, ByVal iFieldIndex As Int16) As Double
        GetDataReaderNum = 0
        OpenOracleConnection()

        Dim oraCmd As New OracleCommand
        With oraCmd
            .Connection = oraConn
            .CommandType = CommandType.Text
            .CommandText = strSQL
            oraDR = .ExecuteReader
        End With

        If oraDR.RecordsAffected = -1 Then
            While oraDR.Read
                If IsDBNull(oraDR.Item(iFieldIndex)) Then
                    GetDataReaderNum = 0
                Else
                    GetDataReaderNum = oraDR.Item(iFieldIndex)
                End If
            End While
        End If

        CloseOracleConnection()

        Return GetDataReaderNum
    End Function

    Function ExecuteDataSQLMultiModif(ByVal DataSQL As Data.DataSet) As String

        Dim strSQL As String = ""
        Dim i As Integer
        'Dim trans As OracleTransaction

        OpenOracleConnection()
        oraCmd = New OracleCommand
        oraConn.BeginTransaction()

        Try
            With oraCmd
                .Connection = oraConn
                For i = 0 To DataSQL.Tables(0).Rows.Count - 1
                    .CommandType = CommandType.Text
                    .CommandText = DataSQL.Tables(0).Rows(i).Item(0)  'strSQL
                    .ExecuteNonQuery()
                    oraCmd.CommandText = "COMMIT"
                    oraCmd.ExecuteNonQuery()
                Next
                '                oraCmd.CommandText = "COMMIT"
                '               oraCmd.ExecuteNonQuery()
            End With
            Return "1"
        Catch ex As Exception
            Dim SQLDummy As String = oraCmd.CommandText
            oraCmd.CommandText = "ROLLBACK"
            oraCmd.ExecuteNonQuery()
            Return "0" & ex.Message & "|" & SQLDummy
        End Try

        CloseOracleConnection()
    End Function


End Class
