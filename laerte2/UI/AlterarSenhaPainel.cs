using SistemaGerenciadorDeTransportes.Model;
using SistemaGerenciadorDeTransportes.Repository;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class AlterarSenhaPainel : Panel
    {
        public Label SenhaOriginalRotulo;
        public TextBox SenhaOriginalCaixa;
        public Label SenhaOriginalErroRotulo;

        public Label SenhaNovaRotulo;
        public TextBox SenhaNovaCaixa;
        public Label SenhaNovaErroRotulo;

        public Button ConfirmarBotao;
        public Button CancelarBotao;

        public AlterarSenhaPainel()
        {
            InicializarComponentes();
        }

        public void InicializarComponentes()
        {
            Size = new Size(600, 320);

            SenhaOriginalRotulo = new Label();
            SenhaOriginalRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            SenhaOriginalRotulo.Text = "Senha Original:";
            SenhaOriginalRotulo.Location = new Point(150, 40);
            SenhaOriginalRotulo.Size = new Size(130, 20);
            Controls.Add(SenhaOriginalRotulo);

            SenhaOriginalCaixa = new TextBox();
            SenhaOriginalCaixa.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            SenhaOriginalCaixa.Location = new Point(150, 60);
            SenhaOriginalCaixa.Size = new Size(300, 30);
            SenhaOriginalCaixa.PasswordChar = '*';
            Controls.Add(SenhaOriginalCaixa);

            SenhaOriginalErroRotulo = new Label();
            SenhaOriginalErroRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            SenhaOriginalErroRotulo.TextAlign = ContentAlignment.MiddleRight;
            SenhaOriginalErroRotulo.ForeColor = Color.Red;
            SenhaOriginalErroRotulo.Text = "";
            SenhaOriginalErroRotulo.Location = new Point(250, 40);
            SenhaOriginalErroRotulo.Size = new Size(200, 20);
            Controls.Add(SenhaOriginalErroRotulo);

            SenhaNovaRotulo = new Label();
            SenhaNovaRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            SenhaNovaRotulo.Text = "Nova Senha:";
            SenhaNovaRotulo.Location = new Point(150, 110);
            SenhaNovaRotulo.Size = new Size(130, 20);
            Controls.Add(SenhaNovaRotulo);

            SenhaNovaCaixa = new TextBox();
            SenhaNovaCaixa.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            SenhaNovaCaixa.Location = new Point(150, 130);
            SenhaNovaCaixa.Size = new Size(300, 30);
            SenhaNovaCaixa.PasswordChar = '*';
            Controls.Add(SenhaNovaCaixa);

            SenhaNovaErroRotulo = new Label();
            SenhaNovaErroRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            SenhaNovaErroRotulo.TextAlign = ContentAlignment.MiddleRight;
            SenhaNovaErroRotulo.ForeColor = Color.Red;
            SenhaNovaErroRotulo.Text = "";
            SenhaNovaErroRotulo.Location = new Point(250, 110);
            SenhaNovaErroRotulo.Size = new Size(200, 20);
            Controls.Add(SenhaNovaErroRotulo);

            ConfirmarBotao = new Button();
            ConfirmarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ConfirmarBotao.Text = "Confirmar";
            ConfirmarBotao.Location = new Point(150, 190);
            ConfirmarBotao.Size = new Size(130, 50);
            ConfirmarBotao.Click += ConfirmarClick;
            Controls.Add(ConfirmarBotao);

            CancelarBotao = new Button();
            CancelarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CancelarBotao.Text = "Cancelar";
            CancelarBotao.Location = new Point(320, 190);
            CancelarBotao.Size = new Size(130, 50);
            CancelarBotao.Click += CancelarClick;
            Controls.Add(CancelarBotao);
        }

        public void ConfirmarClick(object sender, EventArgs e)
        {
            bool valido = true;
            Usuario usuario = Formulario.UsuarioLogado;
            string senhaOriginal = SenhaOriginalCaixa.Text;
            string senhaNova = SenhaNovaCaixa.Text;
            SenhaOriginalErroRotulo.Text = "";
            SenhaNovaErroRotulo.Text = "";

            if (senhaOriginal.Length == 0)
            {
                valido = false;
                SenhaOriginalErroRotulo.Text = "Senha vazia";
            }
            else if (senhaOriginal != usuario.Senha)
            {
                valido = false;
                SenhaOriginalErroRotulo.Text = "Senha incorreta";
            }

            if (senhaNova.Length == 0) 
            {
                valido = false;
                SenhaNovaErroRotulo.Text = "Senha vazia";
            }
            else if (senhaNova.Length < 6)
            {
                valido = false;
                SenhaNovaErroRotulo.Text = "Senha curta demais";
            }

            if (!valido)
                return;

            UsuarioRepositorio.Atualizar(usuario, senhaNova);

            SenhaOriginalCaixa.Text = "";
            SenhaNovaCaixa.Text = "";
            Visible = false;

            if (Formulario.UsuarioTipo == Usuario.Tipo.Passageiro)
            {
                Parent!.Size = Formulario.PassageiroPainel.Size;
                Formulario.PassageiroPainel.Visible = true;
                return;
            }

            if (Formulario.UsuarioTipo == Usuario.Tipo.Empresa)
            {
                Parent!.Size = Formulario.EmpresaPainel.Size;
                Formulario.EmpresaPainel.Visible = true;
                return;
            }
        }

        public void CancelarClick(object sender, EventArgs e) 
        {
            Visible = false;

            if (Formulario.UsuarioTipo == Usuario.Tipo.Passageiro)
            {
                Parent!.Size = Formulario.PassageiroPainel.Size;
                Formulario.PassageiroPainel.Visible = true;
                return;
            }

            if (Formulario.UsuarioTipo == Usuario.Tipo.Empresa)
            {
                Parent!.Size = Formulario.EmpresaPainel.Size;
                Formulario.EmpresaPainel.Visible = true;
                return;
            }
        }
    }
}
