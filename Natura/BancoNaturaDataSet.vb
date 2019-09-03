

Partial Public Class BancoNaturaDataSet
    Partial Class ProdutosDataTable

        Private Sub ProdutosDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.NomeColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
