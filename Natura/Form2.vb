' Criar um Módulo com esses mesmos parâmetros + esta função no módulo :  (Public Function GetConnection() As OleDbConnection
'Dim sql As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Tudo De VB\Banco de Dados em Access\BancoNatura.mdb"
' Return New OleDbConnection(sql)
' End Function)
' (Provider=Microsoft.Jet.OLEDB.4.0) é o padrão do banco de dados em Acssess... O Restante é o diretório onde esta o Banco de dados
'===================================================================================================================================

'importar antes do form public class, como esta logo abaixo:
Imports System.Data
Imports System.Data.OleDb

Public Class Form2
    ' O Sub abaixo é o da BindNavigator que deve estar invisivel nas propriedades:
    Private Sub ProdutosBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles ProdutosBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProdutosBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BancoNaturaDataSet)

    End Sub
    'A Função abaixo é para desabilira o X de fechar o Form.

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal bRevert As Integer) As Integer

    Private Declare Function RemoveMenu Lib "user32" (ByVal hMenu As Integer, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer

    Private Const SC_CLOSE = &HF060&

    Private Const MF_BYCOMMAND = &H0&

    Function RemoveXButton(ByVal iHWND As Integer) As Integer

        Dim iSysMenu As Integer

        iSysMenu = GetSystemMenu(iHWND, False)

        Return RemoveMenu(iSysMenu, SC_CLOSE, MF_BYCOMMAND)

    End Function
    ' Termina a função de desabilitar o X.
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PCarregaGridView() ' Carrega o DataGrid
        IdTextBox.Text = ""
        NomeTextBox.Text = ""
        ValorTextBox.Text = ""
        IdTextBox.Focus()
    End Sub
    ' O Sub Abaixo é tipo um Padrão para carregar dados do SQL.
    Private Sub PCarregaGridView()

        Using con As OleDbConnection = GetConnection()
            Try
                con.Open()
                Dim sql As String
                sql = "SELECT Produtos.Id, Produtos.Nome, Produtos.Valor"
                Dim cdm As OleDbCommand = New OleDbCommand(sql, con)
                Dim da As OleDbDataAdapter = New OleDbDataAdapter(cdm)
                Dim dt As DataTable = New DataTable
                da.Fill(dt)
                ProdutosDataGridView.DataSource = dt

            Catch ex As Exception

            Finally

                con.Close()

            End Try
        End Using

        Me.ProdutosTableAdapter.Fill(Me.BancoNaturaDataSet.Produtos)
        RemoveXButton(Me.Handle()) ' Ainda faz Parte de desabilitar o X de fechar o Form.
        Timer1.Start()
        FrmVendas.Button8.Focus()
        FrmVendas.Label2.Visible = True
        FrmVendas.Label3.Visible = False
        FrmVendas.Label4.Visible = False
        FrmVendas.Label5.Visible = False
        FrmVendas.Label6.Visible = False
        FrmVendas.QuantidadeTextBox.Visible = False
        FrmVendas.TotalTextBox.Visible = False
        FrmVendas.SubTotalTextBox.Visible = False
        FrmVendas.PorcentagemTextBox.Visible = False
        FrmVendas.ClienteTextBox.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        IdTextBox.Text = ""
        NomeTextBox.Text = ""
        ValorTextBox.Text = ""
        IdTextBox.Focus()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Botão Alterar dados: Configurar o DataSet, conforme Video nos videos tutoriais 
        ' e colocar código abaixo.
       
        Try
            Me.ProdutosTableAdapter.Alterar(IdTextBox.Text, NomeTextBox.Text, ValorTextBox.Text, IdTextBox.Text)
            Me.ProdutosTableAdapter.Fill(Me.BancoNaturaDataSet.Produtos)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Botão Excluir dados: Configurar o DataSet, conforme Video nos videos tutoriais 
        ' e colocar código abaixo.
       
        Try
            Me.ProdutosTableAdapter.Excluir(IdTextBox.Text)
            Me.ProdutosTableAdapter.Fill(Me.BancoNaturaDataSet.Produtos)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.ProdutosTableAdapter.Fill(Me.BancoNaturaDataSet.Produtos)
        'Botão para limpar os Campos (textbox´s)
        TextBox1.Text = ""
        NomeTextBox.Text = ""
        ValorTextBox.Text = ""
        IdTextBox.Text = ""
       
    End Sub

    Private Sub ProdutosDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        ' Só tem que existir
    End Sub

    Private Sub DataLabel_Click(sender As Object, e As EventArgs) Handles DataLabel3.Click
        ' Só tem que existir
    End Sub

    ' O Sub abaixo é para colocar a hora no sistema 
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim dt As String = ""
        dt &= "      Hora: " & DateAndTime.Now.ToLongTimeString
        DataLabel3.Text = dt

    End Sub

    Private Sub CalculadoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculadoraToolStripMenuItem.Click
        Shell("calc.exe") 'Chamar Calculadora do windows / Isto esta repedido no resto do código porque há outros botões
    End Sub

    Private Sub BlocoDeNotasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Shell("notepad.exe", AppWinStyle.NormalFocus) ' Chamar Bloco de notas do windows Isto esta repedido no resto do código porque há outros botões

    End Sub


    Private Sub ProgramaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgramaToolStripMenuItem.Click
        MessageBox.Show("Sistema Consultoria JEQUITI Versão 1.0.0 - Desenvolvido para auxiliar o(a) Consultor(a) Jequiti a Controlar suas vendas e suas comissões de maneira prática e eficiente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        Form1.Button2.Enabled = True
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Shell("calc.exe")
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Shell("notepad.exe", AppWinStyle.NormalFocus)
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

    Private Sub TocarMusicaDeFundoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        My.Computer.Audio.Play(My.Resources.Marcelo_Crivella_01_Vai_Arrebentar, AudioPlayMode.BackgroundLoop)
    End Sub

    Private Sub PararMusicaDeFundoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        My.Computer.Audio.Stop()
    End Sub

    ' Chamar Form3, que no caso é o forme de impressão onde esta o Report
    ' Isso se repete por ter outros botões com a mesma função
   
    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        Form3.ShowDialog()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Form3.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Shell("calc.exe")
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Shell("notepad.exe", AppWinStyle.NormalFocus)
    End Sub

    ' De novo botão para limpar os Campos (textbox´s)
    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Me.ProdutosTableAdapter.Fill(Me.BancoNaturaDataSet.Produtos)
        'Botão para limpar os Campos (textbox´s)
        TextBox1.Text = ""
        NomeTextBox.Text = ""
        ValorTextBox.Text = ""
        IdTextBox.Text = "   "
    End Sub
    Private Sub CalendárioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalendárioToolStripMenuItem.Click
        FrmCalendario.Show()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        FrmCalendario.Show()
    End Sub

    Private Sub ProgramadorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProgramadorToolStripMenuItem1.Click
        MessageBox.Show("Elaborado e Desenvolvido por Paulo Cesar C. Bruno. (TODOS OS DIREITOS RESERVADOS).", "Programador", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub InstruçoesDeBuscaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstruçoesDeBuscaToolStripMenuItem.Click
        MessageBox.Show("Para Alterar ou Excluir um Registro, digitar o Nome do Produto  no CAMPO em Azul, Abaixo de (Busca P/ Nome), escolher o produto a ser Alterado ou Excluido, no caso de Alterar é só modificar o campo a ser alterado e clicar no Botão Alterar, no caso de exclusão é só escolher o código a ser excluido e clicar no Botão Excluir.", "INFORMAÇÃO!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    ' Este Sub Cria Um Link com uma página Web Escolhida através da tool "LinkLabel"
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        LinkLabel1.LinkVisited = True
        'ativa o metodo Process.Start para abrir o navegador padrão com a url
        System.Diagnostics.Process.Start("https://www.jequiti.com.br/")

        IdTextBox.Focus() ' volta o foco para a caixa de inserção de código
        LinkLabel1.LinkVisited = False ' desmarca o link limpando e voltando a cor original
    End Sub

    Private Sub ProdutosDataGridView_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles ProdutosDataGridView.CellContentClick

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ProdutosBindingSource.Filter = "Nome LIKE '%" + TextBox1.Text + "%'"
    End Sub


    Private Sub ValorTextBox_LostFocus(sender As Object, e As EventArgs) Handles ValorTextBox.LostFocus
        '  Configurar o DataSet, conforme Video nos videos tutoriais 
        ' e colocar código abaixo.
        Try

            Me.ProdutosTableAdapter.Inserir(IdTextBox.Text, NomeTextBox.Text, ValorTextBox.Text)
            Me.ProdutosTableAdapter.Fill(Me.BancoNaturaDataSet.Produtos)
        Catch ex As Exception

        End Try
        Button1.Focus()
    End Sub
    Private Sub IdTextBox_TextChanged(sender As Object, e As EventArgs) Handles IdTextBox.TextChanged

    End Sub

    Private Sub UtilitáriosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UtilitáriosToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs)

    End Sub
End Class