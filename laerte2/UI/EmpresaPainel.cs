using SistemaGerenciadorDeTransportes.Model;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class EmpresaPainel : Panel
    {
        public Label UsuarioRotulo;
        public Label TituloAtributosRotulo;
        public Label ValorAtributosRotulo;
        public Button GerenciarVeiculosBotao;
        public Button GerenciarViagensBotao;
        public Button AlterarSenhaBotao;
        public Button DeletarContaBotao;
        public Button SairBotao;

        public EmpresaPainel()
        {
            InicializarComponentes();
        }
        private void InicializarComponentes()
        {
            Size = new System.Drawing.Size(600, 400);

            UsuarioRotulo = new Label();
            UsuarioRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            UsuarioRotulo.Text = "Usuario Logado";
            UsuarioRotulo.Location = new Point(150, 40);
            UsuarioRotulo.Size = new Size(200, 30);
            Controls.Add(UsuarioRotulo);

            TituloAtributosRotulo = new Label();
            TituloAtributosRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            TituloAtributosRotulo.Text = "Nome:\nCNPJ:";
            TituloAtributosRotulo.Location = new Point(150, 70);
            TituloAtributosRotulo.Size = new Size(100, 60);
            Controls.Add(TituloAtributosRotulo);

            ValorAtributosRotulo = new Label();
            ValorAtributosRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ValorAtributosRotulo.Text = "";
            ValorAtributosRotulo.Location = new Point(250, 70);
            ValorAtributosRotulo.Size = new Size(200, 60);
            Controls.Add(ValorAtributosRotulo);

            GerenciarVeiculosBotao = new Button();
            GerenciarVeiculosBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            GerenciarVeiculosBotao.Text = "Gerenciar Veiculos";
            GerenciarVeiculosBotao.Location = new Point(150, 130);
            GerenciarVeiculosBotao.Size = new Size(130, 50);
            GerenciarVeiculosBotao.Click += GerenciarVeiculosClick;
            Controls.Add(GerenciarVeiculosBotao);

            GerenciarViagensBotao = new Button();
            GerenciarViagensBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            GerenciarViagensBotao.Text = "Gerenciar Viagens";
            GerenciarViagensBotao.Location = new Point(320, 130);
            GerenciarViagensBotao.Size = new Size(130, 50);
            GerenciarViagensBotao.Click += GerenciarViagensClick;
            Controls.Add(GerenciarViagensBotao);

            AlterarSenhaBotao = new Button();
            AlterarSenhaBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            AlterarSenhaBotao.Text = "Alterar Senha";
            AlterarSenhaBotao.Location = new Point(150, 200);
            AlterarSenhaBotao.Size = new Size(130, 50);
            AlterarSenhaBotao.Click += AlterarSenhaClick;
            Controls.Add(AlterarSenhaBotao);

            DeletarContaBotao = new Button();
            DeletarContaBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            DeletarContaBotao.Text = "Deletar Conta";
            DeletarContaBotao.Location = new Point(320, 200);
            DeletarContaBotao.Size = new Size(130, 50);
            DeletarContaBotao.Click += DeletarClick;
            Controls.Add(DeletarContaBotao);

            SairBotao = new Button();
            SairBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            SairBotao.Text = "Sair";
            SairBotao.Location = new Point(235, 270);
            SairBotao.Size = new Size(130, 50);
            SairBotao.Click += SairClick;
            Controls.Add(SairBotao);
        }
        public void CarregarInformacoesUsuario()
        {
            Empresa empresa = Formulario.UsuarioLogado as Empresa;
            ValorAtributosRotulo.Text = $"{empresa.Nome}\n";
            ValorAtributosRotulo.Text += $"{empresa.CNPJ}";
        }

        public void GerenciarVeiculosClick(object sender, EventArgs e)
        {
            Visible = false;
            Parent!.Size = Formulario.GerenciarVeiculosPainel.Size;
            Formulario.GerenciarVeiculosPainel.CarregarInfo();
            Formulario.GerenciarVeiculosPainel.Visible = true;
        }

        public void GerenciarViagensClick(object sender, EventArgs e) 
        {
            Visible = false;
            Parent!.Size = Formulario.EmpresaGerenciarViagensPainel.Size;
            Formulario.EmpresaGerenciarViagensPainel.CarregarInfo();
            Formulario.EmpresaGerenciarViagensPainel.Visible = true;
        }

        public void AlterarSenhaClick(object sender, EventArgs e)
        {
            Visible = false;
            Parent!.Size = Formulario.AlterarSenhaPainel.Size;
            Formulario.AlterarSenhaPainel.Visible = true;
        }

        public void DeletarClick(object sender, EventArgs e)
        {
            Visible = false;
            Parent!.Size = Formulario.ConfirmarDelecaoPainel.Size;
            Formulario.ConfirmarDelecaoPainel.Visible = true;
        }

        public void SairClick(object sender, EventArgs e)
        {
            Visible = false;
            Parent!.Size = Formulario.EntrarPainel.Size;
            Formulario.EntrarPainel.NomeUsuarioCaixa.Text = "";
            Formulario.EntrarPainel.SenhaUsuarioCaixa.Text = "";
            Formulario.EntrarPainel.Visible = true;
        }
    }
}
