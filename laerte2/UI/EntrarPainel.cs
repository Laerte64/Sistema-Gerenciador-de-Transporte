using SistemaGerenciadorDeTransportes.Model;
using SistemaGerenciadorDeTransportes.Repository;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class EntrarPainel: Panel
    {

        public Label Titulo;

        public Label NomeUsuarioRotulo;
        public TextBox NomeUsuarioCaixa;
        public Label NomeUsuarioErroRotulo;

        public Label SenhaUsuarioRotulo;
        public TextBox SenhaUsuarioCaixa;
        public Label SenhaUsuarioErroRotulo;

        public Button EntrarBotao;
        public Button CadastrarBotao;

        public EntrarPainel() 
        {
            InicializarComponentes();
        }
        private void InicializarComponentes()
        {
            Size = new System.Drawing.Size(600, 420);

            Titulo = new Label();
            Titulo.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            Titulo.TextAlign = ContentAlignment.MiddleCenter;
            Titulo.Text = "Sistema Gerenciador de Transportes";
            Titulo.Location = new Point(50, 50);
            Titulo.Size = new Size(500, 30);
            Controls.Add(Titulo);

            NomeUsuarioRotulo = new Label();
            NomeUsuarioRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            NomeUsuarioRotulo.Text = "Nome:";
            NomeUsuarioRotulo.Location = new Point(150, 120);
            NomeUsuarioRotulo.Size = new Size(100, 20);
            Controls.Add(NomeUsuarioRotulo);

            NomeUsuarioCaixa = new TextBox();
            NomeUsuarioCaixa.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            NomeUsuarioCaixa.Location = new Point(150, 140);
            NomeUsuarioCaixa.Size = new Size(300, 30);
            Controls.Add(NomeUsuarioCaixa);


            NomeUsuarioErroRotulo = new Label();
            NomeUsuarioErroRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            NomeUsuarioErroRotulo.TextAlign = ContentAlignment.MiddleRight;
            NomeUsuarioErroRotulo.ForeColor = Color.Red;
            NomeUsuarioErroRotulo.Text = "";
            NomeUsuarioErroRotulo.Location = new Point(250, 120);
            NomeUsuarioErroRotulo.Size = new Size(200, 20);
            Controls.Add(NomeUsuarioErroRotulo);

            SenhaUsuarioRotulo = new Label();
            SenhaUsuarioRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            SenhaUsuarioRotulo.Text = "Senha:";
            SenhaUsuarioRotulo.Location = new Point(150, 190);
            SenhaUsuarioRotulo.Size = new Size(100, 20);
            Controls.Add(SenhaUsuarioRotulo);

            SenhaUsuarioCaixa = new TextBox();
            SenhaUsuarioCaixa.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            SenhaUsuarioCaixa.Location = new Point(150, 210);
            SenhaUsuarioCaixa.Size = new Size(300, 30);
            SenhaUsuarioCaixa.PasswordChar = '*';
            Controls.Add(SenhaUsuarioCaixa);

            SenhaUsuarioErroRotulo = new Label();
            SenhaUsuarioErroRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            SenhaUsuarioErroRotulo.TextAlign = ContentAlignment.MiddleRight;
            SenhaUsuarioErroRotulo.ForeColor = Color.Red;
            SenhaUsuarioErroRotulo.Text = "";
            SenhaUsuarioErroRotulo.Location = new Point(250, 190);
            SenhaUsuarioErroRotulo.Size = new Size(200, 20);
            Controls.Add(SenhaUsuarioErroRotulo);

            EntrarBotao = new Button();
            EntrarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            EntrarBotao.Text = "Entrar";
            EntrarBotao.Location = new Point(150, 270);
            EntrarBotao.Size = new Size(130, 50);
            EntrarBotao.Click += EntrarClick;
            Controls.Add(EntrarBotao);

            CadastrarBotao = new Button();
            CadastrarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CadastrarBotao.Text = "Cadastrar";
            CadastrarBotao.Location = new Point(320, 270);
            CadastrarBotao.Size = new Size(130, 50);
            CadastrarBotao.Click += CadastrarClick;
            Controls.Add(CadastrarBotao);
        }
        private void EntrarClick(object sender, EventArgs e)
        {
            string nome = NomeUsuarioCaixa.Text;
            string senha = SenhaUsuarioCaixa.Text;

            NomeUsuarioErroRotulo.Text = "";
            SenhaUsuarioErroRotulo.Text = "";

            if (nome.Length == 0)
            {
                NomeUsuarioErroRotulo.Text = "Nome vazio";
                return;
            }
            var usuarios = UsuarioRepositorio.Listar();
            Usuario? usuario = usuarios.Find(u => u.Nome == nome);
            if (usuario == null) 
            {
                NomeUsuarioErroRotulo.Text = "Usuario inválido";
                return;
            }

            if (senha.Length == 0) 
            {
                SenhaUsuarioErroRotulo.Text = "Senha vazia";
                return;
            }
            if (usuario.Senha != senha) 
            {
                SenhaUsuarioErroRotulo.Text = "Senha incorreta";
                return;
            }

            var passageiros = PassageiroRepositorio.Listar();
            Passageiro? passageiro = passageiros.Find(p => p.UsuarioId == usuario.UsuarioId);
            if (passageiro != null) 
            {
                Formulario.UsuarioLogado = passageiro;
                Formulario.UsuarioTipo = Usuario.Tipo.Passageiro;
                Formulario.PassageiroPainel.CarregarInformacoesUsuario();

                Visible = false;
                Parent!.Size = Formulario.PassageiroPainel.Size;
                Formulario.PassageiroPainel.Visible = true;
            }

            var empresas = EmpresaRepositorio.Listar();
            Empresa? empresa = empresas.Find(e => e.UsuarioId == usuario.UsuarioId);
            if (empresa != null) 
            {
                Formulario.UsuarioLogado = empresa;
                Formulario.UsuarioTipo = Usuario.Tipo.Empresa;
                Formulario.EmpresaPainel.CarregarInformacoesUsuario();

                Visible = false;
                Parent!.Size = Formulario.EmpresaPainel.Size;
                Formulario.EmpresaPainel.Visible = true;
            }
        }

        private void CadastrarClick(object sender, EventArgs e)
        {
            bool valido = true;
            string nome = NomeUsuarioCaixa.Text;
            string senha = SenhaUsuarioCaixa.Text;

            NomeUsuarioErroRotulo.Text = "";
            SenhaUsuarioErroRotulo.Text = "";

            if (nome.Length == 0) 
            {
                valido = false;
                NomeUsuarioErroRotulo.Text = "Nome vazio";
            }
            else
            {
                var usuarios = UsuarioRepositorio.Listar();
                if (usuarios.Find(u => u.Nome == nome) != null)
                {
                    valido = false;
                    NomeUsuarioErroRotulo.Text = "Nome já cadastrado";
                }
            }

            if (senha.Length == 0)
            {
                valido = false;
                SenhaUsuarioErroRotulo.Text = "Senha vazia";
            }
            else if (senha.Length < 6) 
            {
                valido = false;
                SenhaUsuarioErroRotulo.Text = "Senha curta demais";
            }

            if (!valido)
                return;

            Visible = false;
            Parent!.Size = Formulario.CadastroOpcaoPainel.Size;
            Formulario.CadastroOpcaoPainel.Visible = true;
        }
    }
}
