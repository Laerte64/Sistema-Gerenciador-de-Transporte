using SistemaGerenciadorDeTransportes.Model;
using SistemaGerenciadorDeTransportes.Repository;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class CadastroExtraPainel : Panel
    {
        public string Extra;
        public Label ExtraRotulo;
        public TextBox ExtraCaixa;
        public Label ExtraErroRotulo;
        public Button ConfirmarBotao;
        public Button CancelarBotao;

        public CadastroExtraPainel() 
        {
            InicializarComponentes();
        }

        public void InicializarComponentes()
        {
            Size = new System.Drawing.Size(600, 420);

            ExtraRotulo = new Label();
            ExtraRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ExtraRotulo.Text = "Insira seu {Extra}:";
            ExtraRotulo.Location = new Point(150, 120);
            ExtraRotulo.Size = new Size(150, 20);
            Controls.Add(ExtraRotulo);

            ExtraCaixa = new TextBox();
            ExtraCaixa.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ExtraCaixa.Location = new Point(150, 140);
            ExtraCaixa.Size = new Size(300, 30);
            Controls.Add(ExtraCaixa);

            ExtraErroRotulo = new Label();
            ExtraErroRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ExtraErroRotulo.TextAlign = ContentAlignment.MiddleRight;
            ExtraErroRotulo.ForeColor = Color.Red;
            ExtraErroRotulo.Text = "";
            ExtraErroRotulo.Location = new Point(300, 120);
            ExtraErroRotulo.Size = new Size(150, 20);
            Controls.Add(ExtraErroRotulo);

            ConfirmarBotao = new Button();
            ConfirmarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ConfirmarBotao.Text = "Confirmar";
            ConfirmarBotao.Location = new Point(150, 270);
            ConfirmarBotao.Size = new Size(130, 50);
            ConfirmarBotao.Click += ConfirmarClick;
            Controls.Add(ConfirmarBotao);

            CancelarBotao = new Button();
            CancelarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CancelarBotao.Text = "Cancelar";
            CancelarBotao.Location = new Point(320, 270);
            CancelarBotao.Size = new Size(130, 50);
            CancelarBotao.Click += CancelarClick;
            Controls.Add(CancelarBotao);
        }

        public void ConfirmarClick(object sender, EventArgs e)
        {
            string nome = Formulario.EntrarPainel.NomeUsuarioCaixa.Text;
            string senha = Formulario.EntrarPainel.SenhaUsuarioCaixa.Text;
            string extra = ExtraCaixa.Text;
            ExtraCaixa.Text = "";
            ExtraErroRotulo.Text = "";

            if (Formulario.CadastroOpcaoPainel.Opcao == Usuario.Tipo.Passageiro)
            {
                if (extra.Length == 0)
                {
                    ExtraErroRotulo.Text = "CPF vazio";
                    return;
                }

                var passageiros = PassageiroRepositorio.Listar();
                Passageiro? passageiro = passageiros.Find(p => p.CPF == extra);
                if (passageiro != null)
                {
                    ExtraErroRotulo.Text = "CPF já cadastrado";
                    return;
                }

                Passageiro usuario = new Passageiro(nome, senha, extra);
                PassageiroRepositorio.Cadastrar(usuario);
                Formulario.UsuarioLogado = usuario;
                Formulario.UsuarioTipo = Usuario.Tipo.Passageiro;
                Formulario.PassageiroPainel.CarregarInformacoesUsuario();

                Visible = false;
                Parent.Size = Formulario.PassageiroPainel.Size;
                Formulario.PassageiroPainel.Visible = true;
            }
            else
            {
                if (extra.Length == 0)
                {
                    ExtraErroRotulo.Text = "CNPJ vazio";
                    return;
                }

                var empresas = EmpresaRepositorio.Listar();
                Empresa? empresa = empresas.Find(e => e.CNPJ == extra);
                if (empresa != null) 
                {
                    ExtraErroRotulo.Text = "CNPJ já cadastrado";
                    return;
                }

                Empresa usuario = new Empresa(nome, senha, extra);
                EmpresaRepositorio.Cadastrar(usuario);
                Formulario.UsuarioLogado = usuario;
                Formulario.UsuarioTipo = Usuario.Tipo.Empresa;
                Formulario.EmpresaPainel.CarregarInformacoesUsuario();

                Visible = false;
                Parent.Size = Formulario.EmpresaPainel.Size;
                Formulario.EmpresaPainel.Visible = true;
            }
        }

        public void CancelarClick(object sender, EventArgs e) 
        {
            Visible = false;
            ExtraCaixa.Text = "";
            ExtraErroRotulo.Text = "";
            Formulario.EntrarPainel.NomeUsuarioCaixa.Text = "";
            Formulario.EntrarPainel.SenhaUsuarioCaixa.Text = "";
            Parent.Size = Formulario.EntrarPainel.Size;
            Formulario.EntrarPainel.Visible = true;
        }
    }
}
