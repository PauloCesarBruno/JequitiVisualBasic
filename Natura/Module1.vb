Imports System.Data
Imports System.Data.OleDb
Module Module1
    Public Function GetConnection() As OleDbConnection
        Dim sql As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Paulo Bruno\sql\Cópia Banco de Dados\BancoNatura.mdb"
        Return New OleDbConnection(sql)
    End Function

End Module
