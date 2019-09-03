Public Class FrmRelatorioClientes

    Private Sub FrmRelatorioClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'BancoNaturaDataSet.Clientes' table. You can move, or remove it, as needed.
        Me.ClientesTableAdapter.Fill(Me.BancoNaturaDataSet.Clientes)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class