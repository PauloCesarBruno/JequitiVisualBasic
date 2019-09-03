Public Class FrmSenha

    ' ESSE É MEU CÓDICO COMPLETO E PADRÃO PARA ROTINA DE CADASTRO LOGIN E SENHA 
    ' para os parametros das propriedades, pois cada caso é um Caso.
    '===========================================================================
    ' ==========================================================================
  
    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal bRevert As Integer) As Integer

    Private Declare Function RemoveMenu Lib "user32" (ByVal hMenu As Integer, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer

    Private Const SC_CLOSE = &HF060&

    Private Const MF_BYCOMMAND = &H0&

    Function RemoveXButton(ByVal iHWND As Integer) As Integer

        Dim iSysMenu As Integer

        iSysMenu = GetSystemMenu(iHWND, False)

        Return RemoveMenu(iSysMenu, SC_CLOSE, MF_BYCOMMAND)

    End Function


    Private Sub FrmSenha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemoveXButton(Me.Handle())
        If CheckBox2.Checked = True Then
            CheckBox2.Visible = False
        Else
        End If
        TextBox1.Enabled = False
        TextBox2.Enabled = False

        If System.IO.Directory.Exists("c:\Login") Then
            PictureBox2.Visible = False
            Label7.Visible = False

            CheckBox2.Visible = False
            Button1.Visible = True
            Button1.Enabled = True
            Button2.Visible = False
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            Button4.Visible = True
            Label3.Visible = False
            Label4.Visible = False
            Label5.Visible = False

            Dim t As Integer
            t = 365
            Me.Size = New Size(407, t)
            TextBox1.Focus()

        Else
            Button3.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button4.Enabled = True
        ' Rotina de entrar caso ja tenha sido feito Cadastro de Login e senha: Button1.
        '=========================================================================================

        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

        '=========================================================================================
        Try ' esse try Impede o Erro de execussão casso o Button Enter esteja Habilitado e o
            ' Usuario nao digitou nada na caixa, impede que o programa trave.
            '======================================================================================

            If System.IO.Directory.Exists("c:\Login\" & TextBox1.Text) Then
                Dim sr As New System.IO.StreamReader("c:\Login\" & TextBox1.Text & "\user.data")
                Dim name2 As String = sr.ReadLine
                Dim pass2 As String = sr.ReadLine
                sr.Close()
                If name2 = TextBox1.Text And pass2 = TextBox2.Text Then
                    MessageBox.Show("Nome e Senha Corretos !!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Form1.Show()
                    Me.Hide()

                Else
                    MessageBox.Show("Nome e/ou Senha Incorretos  !!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox1.Focus()
                    If TextBox1.Text = "" Then


                    Else
                        Button1.Enabled = False
                    End If
                End If
            Else
                MessageBox.Show("Este Usuário não Existe !!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox1.Focus()

            End If

        Catch ex As Exception
            MessageBox.Show("Erro - As Caixas de Login e Senha devem ser preenchidas !!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
        End Try
        '===============================================================================================
        'Fim da Rotina tray/Catch que impede o Travamento do programa caso o Usuário não tenha digitado
        'nada na textBox com o Button ENTER habilitado.
        '===============================================================================================

        ' Fim da Rotina de Entrar caso o Cadastro de Login e senha ja tenham sido Feitos.
        '=====================================================================================

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Button3 -> Simplesmente Sair.
        '==============================
        Me.Close()


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Rotina para amarrar que antes do usuário dar Enter algo tera que ser preenchido na textbox.text.
        '=================================================================================================

        If TextBox1.Text <> "" Then

            Button2.Enabled = True
            Button3.Enabled = True
        End If

        'Fim da Rotimna de amarração.
        '============================
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus

        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        Button1.Focus()

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Rotina se caso após o usuário ja tiver cadastrado Login e Senha e não se lembrar
        ' o Programa emite mensagem e fecha.
        '==================================================================================

        MessageBox.Show("Entrar Em Contato Com O Desenvolvedor: P_Bruno001@hotmail.com / Te.: 3899-9910", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        MessageBox.Show("O Soft será Encerrado...", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        'Fim dessa rotina.
        '=================
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        Button2.Enabled = True
        TextBox1.Enabled = False
        TextBox2.Enabled = True
        TextBox1.Enabled = True
        TextBox1.Focus()

        ' Rotina Para Verificar se o Usuário e a Senha Ja existem 
        '=========================================================

        Dim logDirectoryProperties As System.IO.DirectoryInfo
        If My.Computer.FileSystem.DirectoryExists("C:\Login\") Then
            logDirectoryProperties = My.Computer.FileSystem.GetDirectoryInfo("C:\backup\logs")
            MessageBox.Show("Login e Senha Já foram Registrados pelo responsável do Sistema, Digite-os para Entrar!!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Button2.Visible = False
            Button1.Visible = True
            Button4.Visible = True

            CheckBox2.Visible = False
            PictureBox2.Visible = False
            Label7.Visible = False

            ' Final da Rotina.
            '===================

            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            ' Se Usuario e Senha Não existirem, permite cadastro
            ' ==================================================

        ElseIf System.IO.Directory.Exists("c:\Login\use.data") Then
            System.IO.Directory.CreateDirectory("c:\Login\")

            Button2.Visible = True
        End If

        ' Fim da Rotina
        '====================================================

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

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

    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    ' Rotinas Abaixo para mostrar ou ocultar Senha
    '==============================================
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox2.UseSystemPasswordChar = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox2.UseSystemPasswordChar = True
    End Sub
    'Fim da Rotina Mostrar/Ocultar Senha
    '====================================
    Private Sub instead()
        Throw New NotImplementedException
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Button 2 é a Rotina de Registro ( Botão Registrar), Código Padra abaixo:
        '=======================================================================================
        ' ATENÇÃO:
        ' APÓS CADASTRO FUI NA PASTA LOGIN NO C:\LOGIN (ONDE ESTA CADASTRADO O LOGIN E A SENHA)
        ' E OCULTEI O ARQUIVO PARA QUE USUÁRIOS NÃO CREDENCIADOS NÃO SAIBAM ONDE ESTA A PASTA
        ' LOGIN E SENHA E NÃO TENHAM ACESSO A ELA ....
        '========================================================================================
        ' ATENÇÃO 2: NO DRIVE D:\VIDEOS\FREE INSTANT YOUTUBE DOWNLOADER TEM UM VIDE DE COMO
        ' EXIBIR ARQUIVOS OCULTOS CASO EU (O PROGRAMADOR TENHA ESQUECIDO).
        '========================================================================================

        Button4.Enabled = True
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Algum(s) Campo(s) não foi(ram) preenchido(s), clique NOVAMENTE na caixa Registrar, preencha o(s) campo(s) e  Clique no Botão Registrar !!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Button2.Visible = True

            TextBox1.Focus()
        Else
            If System.IO.Directory.Exists("c:\Login\" & TextBox1.Text) Then
                MessageBox.Show("Este Usuário Já Existe !!!")
            Else
                MkDir("c:\Login\" & TextBox1.Text)
                Try
                    Dim sw As New System.IO.StreamWriter("c:\Login\" & TextBox1.Text & "\user.data")
                    sw.Write(TextBox1.Text & vbNewLine & TextBox2.Text)
                    sw.Close()
                    MessageBox.Show("Cadastro realizado com Sucesso; O Programa será fechado. Entre novamente no programa, digite  o LOGIN e a SENHA Cadastrados Para confirmação e Entrada no Sistema (ISSO SÓ SERA SOLICITADO ESTA ÚNICA VEZ)", "ATENÇÃO!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Application.Exit()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
            End If
        End If
        If TextBox1.Text = "" Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
        Button2.Visible = False
        Button1.Visible = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
        ' Fim da Rotina do Button 2 (Registrar).
    End Sub

End Class