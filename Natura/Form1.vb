Public Class Form1
    'Desabilita o X de fechar o Form

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal bRevert As Integer) As Integer

    Private Declare Function RemoveMenu Lib "user32" (ByVal hMenu As Integer, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer

    Private Const SC_CLOSE = &HF060&

    Private Const MF_BYCOMMAND = &H0&

    Function RemoveXButton(ByVal iHWND As Integer) As 

        Dim iSysMenu As Integer

        iSysMenu = GetSystemMenu(iHWND, False)

        Return RemoveMenu(iSysMenu, SC_CLOSE, MF_BYCOMMAND)

    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Form2.Button5.Focus()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemoveXButton(Me.Handle()) ' Ainda para desabilitar o X de fechar o Form só que aqui no form_load
        MessageBox.Show("Seja Bem Vindo Consultor(a) !!!", "SAUDAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Obrigado e Volte Sempre !!!", "Sair", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MessageBox.Show("Até a Próxima Venda !!!", "Sair", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        FrmVendas.Show()
        FrmVendas.Button8.Focus()
        FrmVendas.Label2.Visible = True
        FrmVendas.PictureBox3.Visible = True
        FrmVendas.Label3.Visible = False
        FrmVendas.Label4.Visible = False
        FrmVendas.Label5.Visible = False
        FrmVendas.Label6.Visible = False
        FrmVendas.QuantidadeTextBox.Visible = False
        FrmVendas.TotalTextBox.Visible = False
        FrmVendas.SubTotalTextBox.Visible = False
        FrmVendas.PorcentagemTextBox.Visible = False
        FrmVendas.ClienteTextBox.Visible = False

        Me.Hide()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FrmClientes.Show()
        Me.Hide()
    End Sub
End Class
