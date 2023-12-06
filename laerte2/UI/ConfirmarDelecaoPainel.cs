using SistemaGerenciadorDeTransportes.Model;
using SistemaGerenciadorDeTransportes.Repository;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class ConfirmarDelecaoPainel : Panel
    {
        public Label ConfirmacaoRotulo;
        public Button ConfirmarBotao;
        public Button CancelarBotao;

        public ConfirmarDelecaoPainel() 
        {
            InicializarComponentes();
        }

        public void InicializarComponentes()
        {
            Size = new Size(400, 200);

            ConfirmacaoRotulo = new Label();
            ConfirmacaoRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ConfirmacaoRotulo.Text = "Tem certeza que deseja deletar pemanentemente essa conta?";
            ConfirmacaoRotulo.Location = new Point(50, 20);
            ConfirmacaoRotulo.Size = new Size(300, 50);
            Controls.Add(ConfirmacaoRotulo);

            ConfirmarBotao = new Button();
            ConfirmarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ConfirmarBotao.Text = "Confirmar";
            ConfirmarBotao.Location = new Point(50, 80);
            ConfirmarBotao.Size = new Size(130, 50);
            ConfirmarBotao.Click += ConfirmarClick;
            Controls.Add(ConfirmarBotao);

            CancelarBotao = new Button();
            CancelarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CancelarBotao.Text = "Cancelar";
            CancelarBotao.Location = new Point(220, 80);
            CancelarBotao.Size = new Size(130, 50);
            CancelarBotao.Click += CancelarClick;
            Controls.Add(CancelarBotao);
        }

        public void ConfirmarClick(object sender, EventArgs e)
        {
            Usuario usuario = Formulario.UsuarioLogado;

            if (Formulario.UsuarioTipo == Usuario.Tipo.Passageiro)
                PassageiroRepositorio.Deletar(usuario as Passageiro);

            if (Formulario.UsuarioTipo == Usuario.Tipo.Empresa)
                EmpresaRepositorio.Deletar(usuario as Empresa);

            Visible = false;
            Parent!.Size = Formulario.EntrarPainel.Size;
            Formulario.EntrarPainel.NomeUsuarioCaixa.Text = "";
            Formulario.EntrarPainel.SenhaUsuarioCaixa.Text = "";
            Formulario.EntrarPainel.Visible = true;
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
