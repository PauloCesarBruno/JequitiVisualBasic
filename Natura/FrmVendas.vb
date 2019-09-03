Public Class FrmVendas

    Private Property PorcentagemLabel As Object

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal bRevert As Integer) As Integer

    Private Declare Function RemoveMenu Lib "user32" (ByVal hMenu As Integer, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer

    Private Const SC_CLOSE = &HF060&

    Private Const MF_BYCOMMAND = &H0&

    Function RemoveXButton(ByVal iHWND As Integer) As Integer

        Dim iSysMenu As Integer

        iSysMenu = GetSystemMenu(iHWND, False)

        Return RemoveMenu(iSysMenu, SC_CLOSE, MF_BYCOMMAND)

    End Function
    Private Sub FrmVendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemoveXButton(Me.Handle())
        Label2.Visible = False
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        TotalTextBox.Visible = True
        QuantidadeTextBox.Visible = True
        SubTotalTextBox.Visible = True
        PorcentagemTextBox.Visible = True
        ClienteTextBox.Visible = True

        'INNER JOIN PARA CHAMAR O CÓDIGO DO PRODUTO NO FORM DE CADASTRO DE PRODUTOS E JOGAR NESSE FORM OS CAMPOS
        'TODO: This line of code loads data into the 'BancoNaturaDataSet.Produtos' table. You can move, or remove it, as needed.
        Me.ProdutosTableAdapter.Fill(Me.BancoNaturaDataSet.Produtos)
        'TODO: This line of code loads data into the 'BancoNaturaDataSet.Vendas' table. You can move, or remove it, as needed.
        Me.VendasTableAdapter.Fill(Me.BancoNaturaDataSet.Vendas)
        IdTextBox.Text = ""
        IdVendasTextBox.Text = ""
        ProdutoTextBox.Text = ""
        SubTotalTextBox.Text = ""

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim dt As String = ""
        dt &= "      Hora: " & DateAndTime.Now.ToLongTimeString 'HORA NO RODAPÉ
        DataLabel.Text = dt
    End Sub

    Private Sub DataLabel_Click(sender As Object, e As EventArgs) Handles DataLabel.Click

    End Sub

    Private Sub CalculadoraToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Shell("calc.exe")
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Shell("notepad.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        FrmCalendario.Show()
    End Sub

    Private Sub ProgramaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgramaToolStripMenuItem.Click
        MessageBox.Show("Sistema Consultoria JEQUITI Verssão 1.0.0 - Desenvolvido para auxiliar o(a) Consultor(a) Jequiti a Controlar suas vendas e suas comissões de maneira prática e eficiente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ProgramadorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProgramadorToolStripMenuItem1.Click
        MessageBox.Show("Elaborado e Desenvolvido por Paulo Cesar C. Bruno. (TODOS OS DIREITOS RESERVADOS).", "Programador", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub InstruçoesDeBuscaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstruçoesDeBuscaToolStripMenuItem.Click
        MessageBox.Show("Para Excluir o Registro de uma Venda, basta digitar o Nome do Cliente no CAMPO em Azul, com uma LUPA (Buscar Cliente), escolher o Cliente a ser Excluido, e clicar no Botão Excluir.", "INFORMAÇÃO!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Shell("calc.exe")
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Shell("notepad.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub CalendárioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalendárioToolStripMenuItem.Click
        FrmCalendario.Show()
    End Sub

    Private Sub VendasBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles VendasBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.VendasBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BancoNaturaDataSet)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim st As Double ' calcula o total = SubTotal*Quantidade e joga Para Caita TotalTextbox.Text
            Dim tt As Double
            st = SubTotalTextBox.Text
            tt = (st * QuantidadeTextBox.Text)
            TotalTextBox.Text = tt
            '--------------------------------------------------------------------------------------------

            Dim porc As Double ' calcula a porcentagem de 30% da comissão do vendedor sobre o total
            porc = (tt / 100) * 30
            PorcentagemTextBox.Text = porc
            '--------------------------------------------------------------------------------------------
        Catch ex As Exception

        End Try

        Try

            Me.VendasTableAdapter.Inserir(IdVendasTextBox.Text, ProdutoTextBox.Text, ClienteTextBox.Text, QuantidadeTextBox.Text, SubTotalTextBox.Text, TotalTextBox.Text, PorcentagemTextBox.Text)
            Me.VendasTableAdapter.Fill(Me.BancoNaturaDataSet.Vendas)
        Catch ex As Exception

        End Try
        SubTotalTextBox.Visible = False
        Label4.Visible = False
        IdVendasTextBox.Text = ""
        ProdutoTextBox.Text = ""
        ClienteTextBox.Text = ""
        QuantidadeTextBox.Text = ""
        SubTotalTextBox.Text = ""
        TotalTextBox.Text = ""
        PorcentagemTextBox.Text = ""
        ClienteTextBox.Visible = False
        QuantidadeTextBox.Visible = False
        Label2.Visible = True
        PictureBox3.Visible = True
        Label3.Visible = False
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        
        ClienteTextBox.Text = ""
        QuantidadeTextBox.Text = ""
        Try
            Me.ProdutosTableAdapter.FillBy(Me.BancoNaturaDataSet.Produtos, IdTextBox.Text)
            IdTextBox.Text = ""
            ClienteTextBox.Focus()
        Catch ex As Exception
        End Try

        If IdVendasTextBox.Text = "" Then
            MessageBox.Show("Ainda não Existe Registro(s) de produto(s) Cadastrado(s), ou especificamente deste Produto que vc Digitou , Você será direcionado ao Cadastro de Produtos Para verificação", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form2.Show()
            Me.Hide()



        End If
    End Sub

    Private Sub IdVendasTextBox_TextChanged(sender As Object, e As EventArgs) Handles IdVendasTextBox.TextChanged

    End Sub

    Private Sub QuantidadeTextBox_LostFocus(sender As Object, e As EventArgs) Handles QuantidadeTextBox.LostFocus
        Button1.Enabled = True
        Button1.Focus()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Try

            Me.VendasTableAdapter.Excluir(ClienteTextBox.Text)
            Me.VendasTableAdapter.Fill(Me.BancoNaturaDataSet.Vendas)
        Catch ex As Exception

        End Try
        IdVendasTextBox.Text = ""
        ProdutoTextBox.Text = ""
        QuantidadeTextBox.Text = ""
        SubTotalTextBox.Text = ""
        ClienteTextBox.Text = ""
        ClienteTextBox.Visible = False
        QuantidadeTextBox.Visible = False
        Label2.Visible = True
        PictureBox3.Visible = True
    End Sub

    Private Sub IdTextBox_TextChanged(sender As Object, e As EventArgs) Handles IdTextBox.TextChanged
        Label2.Visible = False
        PictureBox3.Visible = False
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        TotalTextBox.Visible = True
        QuantidadeTextBox.Visible = True
        SubTotalTextBox.Visible = True
        PorcentagemTextBox.Visible = True
        ClienteTextBox.Visible = True

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Me.VendasTableAdapter.Fill(Me.BancoNaturaDataSet.Vendas)
        SubTotalTextBox.Visible = True
        Label4.Visible = False
        TextBox4.Text = ""
        IdVendasTextBox.Text = ""
        ProdutoTextBox.Text = ""
        QuantidadeTextBox.Text = ""
        SubTotalTextBox.Text = ""
        ClienteTextBox.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        IdTextBox.Text = ""
        TotalTextBox.Text = ""
        PorcentagemTextBox.Text = ""
        ClienteTextBox.Visible = False
        QuantidadeTextBox.Visible = False
        Label3.Visible = False
        Label2.Visible = True
        PictureBox3.Visible = True
    End Sub


    Private Sub QuantidadeTextBox_TextChanged(sender As Object, e As EventArgs) Handles QuantidadeTextBox.TextChanged
        SubTotalTextBox.Visible = False
        Label4.Visible = False
        Label6.Visible = False
        PorcentagemTextBox.Visible = False
        TotalTextBox.Visible = False
        Label5.Visible = False
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ClienteTextBox_TextChanged(sender As Object, e As EventArgs) Handles ClienteTextBox.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim valor As Double

        For Each col As DataGridViewRow In VendasDataGridView.Rows
            valor = valor + col.Cells(4).Value ' Rotina para somar colunas do DataGridView
        Next

        TextBox1.Text = Format(valor, "c")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim valor As Double

        For Each col As DataGridViewRow In VendasDataGridView.Rows
            valor = valor + col.Cells(5).Value ' Rotina para somar colunas do DataGridView
        Next

        TextBox2.Text = Format(valor, "c")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim valor As Double

        For Each col As DataGridViewRow In VendasDataGridView.Rows
            valor = valor + col.Cells(6).Value ' Rotina para somar colunas do DataGridView
        Next

        TextBox3.Text = Format(valor, "c")
    End Sub
    ' Toda a rotina Abaixo é para trazer valores as text box quando for consultado pela busca inteligente
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Label3.Visible = True
        Label5.Visible = True
        TotalTextBox.Visible = True
        ClienteTextBox.Visible = True
        QuantidadeTextBox.Visible = True
        Label2.Visible = False
        SubTotalTextBox.Visible = False
        Label4.Visible = False

        Dim valor As Integer
        Dim valor2 As String

        For Each col As DataGridViewRow In VendasDataGridView.Rows
            valor = col.Cells(0).Value
        Next
        IdVendasTextBox.Text = valor

        For Each col As DataGridViewRow In VendasDataGridView.Rows
            valor2 = col.Cells(1).Value
        Next

        ProdutoTextBox.Text = valor2

        For Each col As DataGridViewRow In VendasDataGridView.Rows
            valor = col.Cells(5).Value
        Next
        TotalTextBox.Text = Format(valor, "#,##0.00")
        ' Fim dessa rotina de trazer valores do DGV para os textBox´s
        VendasBindingSource.Filter = "Cliente LIKE '%" + TextBox4.Text + "%'" ' Busca Inteligente Pelo Nome

    End Sub

    ' Rotina para mudar foco com tecla Enter (modificar na propriedade do Form "KeyPreviw para TRUE" 
    ' E ainda em Propriedades do form onde tem um Raio com icone procurar por KeyDown e dar duplo Click
    ' e ira aparecer no KeyDown -> Form1_KeyDown, pronto assim já podera focar com a tecla Enter ao 
    ' ivés da tecla Tab.......
    ' Finalizando é só digitar o códico abaixo:
    '====================================================================================================

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{Tab}")
        End Select

        ' Fim da Rotina de mudar foco com a tecla Enter.
        '==================================================

        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        ' Rotina para Tirar o "Beep" quando a tecla enter for precionada.
        '================================================================

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    ' Fim da Rotina de tirar o "Beep" quando a tecla enter for precionada.
    '=====================================================================

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Me.VendasTableAdapter.Fill(Me.BancoNaturaDataSet.Vendas)
        SubTotalTextBox.Visible = True
        Label4.Visible = False
        TextBox4.Text = ""
        IdVendasTextBox.Text = ""
        ProdutoTextBox.Text = ""
        QuantidadeTextBox.Text = ""
        SubTotalTextBox.Text = ""
        ClienteTextBox.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        IdTextBox.Text = ""
        TotalTextBox.Text = ""
        PorcentagemTextBox.Text = ""
        ClienteTextBox.Visible = False
        QuantidadeTextBox.Visible = False
        Label3.Visible = False
        Label2.Visible = True
        PictureBox3.Visible = True
    End Sub

    Private Sub CadastrarClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CadastrarClienteToolStripMenuItem.Click
        FrmClientes.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try

            TextBox5.Text = Format(TextBox2.Text - TextBox3.Text, "c")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SubTotalTextBox_TextChanged(sender As Object, e As EventArgs) Handles SubTotalTextBox.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        FrmRelatorioVendas.ShowDialog()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        FrmRelatorioVendas.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ' limpa toda minha tabela vendas (todos os Registros) 
        Me.VendasTableAdapter.Fill(Me.BancoNaturaDataSet.Vendas)
        For i = 0 To Me.VendasBindingSource.Count - 1
            Me.VendasBindingSource.RemoveCurrent()
        Next
        Me.Validate()
        Me.VendasBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BancoNaturaDataSet)
        MessageBox.Show("Tabela de vendas apagada com Sucesso !!!", "Informação.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Button9.Enabled = False
        Button11.Enabled = False
    End Sub
    'Rotina abaixo de Certificação se vai mesmo excluir a tabela toda
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        MessageBox.Show("Ao Clicar neste botão, você fechara seu ciclo de vendas, apagando todos os registros de vendas existentes, por isso, a SUGESTÃO é que antes de Clicar no Botão e Apagar Suas vendas, você Imprima e/ou Exporte o relatório das vendas deste ciclo, para eventual consulta. Se isso já foi feito, então prossiga clicando no Botão (FECHAR VENDAS)", "ATENÇÃO!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Button9.Enabled = True
        Button11.Enabled = True
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        MessageBox.Show("Ok, Imprima e/ou Exporte seu Relatório primeiro.", "Informação.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Button9.Enabled = False
        Button11.Enabled = False
    End Sub
End Class