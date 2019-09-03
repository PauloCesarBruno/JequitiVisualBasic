Public Class FrmClientes
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
    Private Sub ClientesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles ClientesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ClientesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.BancoNaturaDataSet)

    End Sub

    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        RemoveXButton(Me.Handle())
        'TODO: This line of code loads data into the 'BancoNaturaDataSet.Clientes' table. You can move, or remove it, as needed.
        Me.ClientesTableAdapter.Fill(Me.BancoNaturaDataSet.Clientes)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        IdClienteTextBox.Text = ""
        NomeTextBox.Text = ""
        EnderecoTextBox.Text = ""
        TelConvencionalTextBox.Text = ""
        TelCelularTextBox.Text = ""
        IdClienteTextBox.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.ClientesTableAdapter.Alterar(IdClienteTextBox.Text, NomeTextBox.Text, EnderecoTextBox.Text, TelConvencionalTextBox.Text, TelCelularTextBox.Text, IdClienteTextBox.Text)
            Me.ClientesTableAdapter.Fill(Me.BancoNaturaDataSet.Clientes)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Me.ClientesTableAdapter.Excluir(IdClienteTextBox.Text)
            Me.ClientesTableAdapter.Fill(Me.BancoNaturaDataSet.Clientes)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.ClientesTableAdapter.Fill(Me.BancoNaturaDataSet.Clientes)
        TextBox1.Text = ""
        IdClienteTextBox.Text = ""
        NomeTextBox.Text = ""
        EnderecoTextBox.Text = ""
        TelConvencionalTextBox.Text = ""
        TelCelularTextBox.Text = ""
        Button1.Focus()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ClientesBindingSource.Filter = "Nome LIKE '%" + TextBox1.Text + "%'" ' BUSCA INTELIGENTE POR NOME
       
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim dt As String = ""
        dt &= "      Hora: " & DateAndTime.Now.ToLongTimeString
        DataLabel.Text = dt
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

    Private Sub ProgramaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgramaToolStripMenuItem.Click
        MessageBox.Show("Sistema Consultoria JEQUITI Verssão 1.0.0 - Desenvolvido para auxiliar o(a) Consultor(a) Jequiti a Controlar suas vendas e suas comissões de maneira prática e eficiente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ProgramadorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProgramadorToolStripMenuItem1.Click
        MessageBox.Show("Elaborado e Desenvolvido por Paulo Cesar C. Bruno. (TODOS OS DIREITOS RESERVADOS).", "Programador", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub InstruçoesDeBuscaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstruçoesDeBuscaToolStripMenuItem.Click
        MessageBox.Show("Para Excluir ou Alterar o Registro de um Cliente, basta digitar o Nome do Cliente no CAMPO em Cor Amarelo Claro, com uma LUPA (Buscar Cliente), escolher o Cliente a ser Excluido ou Alterado, e clicar no Botão Excluir ou Alterar, No caso de alteração de algum Campo do registro modificar (alterar) o Campo antes de clicar no Botão de Alterar.", "INFORMAÇÃO!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Me.ClientesTableAdapter.Fill(Me.BancoNaturaDataSet.Clientes)
        TextBox1.Text = ""
        IdClienteTextBox.Text = ""
        NomeTextBox.Text = ""
        EnderecoTextBox.Text = ""
        TelConvencionalTextBox.Text = ""
        TelCelularTextBox.Text = ""

    End Sub

    Private Sub ToolStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form1.Show()
        Me.Hide()
    End Sub

    

    Private Sub NomeTextBox_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SairToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub VendasBindingSource_CurrentChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub MenuStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip2.ItemClicked
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        FrmRelatorioClientes.ShowDialog()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        FrmRelatorioClientes.ShowDialog()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub TelCelularTextBox_LostFocus(sender As Object, e As EventArgs) Handles TelCelularTextBox.LostFocus
        Try
            Me.ClientesTableAdapter.Inserir(IdClienteTextBox.Text, NomeTextBox.Text, EnderecoTextBox.Text, TelConvencionalTextBox.Text, TelCelularTextBox.Text)
            Me.ClientesTableAdapter.Fill(Me.BancoNaturaDataSet.Clientes)

        Catch ex As Exception
            Button1.Focus()
        End Try

    End Sub

   
    
End Class