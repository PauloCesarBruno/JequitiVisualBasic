Public Class FrmRelatorioVendas

    Private Sub FrmRelatorioVendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'BancoNaturaDataSet.Vendas' table. You can move, or remove it, as needed.
        Me.VendasTableAdapter.Fill(Me.BancoNaturaDataSet.Vendas)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class