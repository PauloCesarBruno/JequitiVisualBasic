<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRelatorioVendas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRelatorioVendas))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.BancoNaturaDataSet = New Natura.BancoNaturaDataSet()
        Me.VendasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VendasTableAdapter = New Natura.BancoNaturaDataSetTableAdapters.VendasTableAdapter()
        CType(Me.BancoNaturaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VendasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.VendasBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Natura.RptVendas.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(831, 434)
        Me.ReportViewer1.TabIndex = 0
        '
        'BancoNaturaDataSet
        '
        Me.BancoNaturaDataSet.DataSetName = "BancoNaturaDataSet"
        Me.BancoNaturaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VendasBindingSource
        '
        Me.VendasBindingSource.DataMember = "Vendas"
        Me.VendasBindingSource.DataSource = Me.BancoNaturaDataSet
        '
        'VendasTableAdapter
        '
        Me.VendasTableAdapter.ClearBeforeFill = True
        '
        'FrmRelatorioVendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 434)
        Me.Controls.Add(Me.ReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRelatorioVendas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultor(a) Jequiti  (Relatório de Vendas"
        CType(Me.BancoNaturaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VendasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents VendasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BancoNaturaDataSet As Natura.BancoNaturaDataSet
    Friend WithEvents VendasTableAdapter As Natura.BancoNaturaDataSetTableAdapters.VendasTableAdapter
End Class
