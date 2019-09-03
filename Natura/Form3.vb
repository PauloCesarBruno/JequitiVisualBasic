Public Class Form3
    ' Comando padrão para colocação da ferramenta ReportViewer
    ' Atenção para as suas configurações
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'BancoNaturaDataSet.Produtos' table. You can move, or remove it, as needed.
        Me.ProdutosTableAdapter.Fill(Me.BancoNaturaDataSet.Produtos)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class