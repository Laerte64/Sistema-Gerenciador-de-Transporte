using SistemaGerenciadorDeTransportes.Model;
using SistemaGerenciadorDeTransportes.Repository;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class CadastrarVeiculoPainel : Panel
    {
        public Label IdentificacaoRotulo;
        public TextBox IdentificacaoCaixa;
        public Label IdentificacaoErroRotulo;

        public Label ModalidadeRotulo;
        public TextBox ModalidadeCaixa;
        public Label ModalidadeErroRotulo;

        public Label CapacidadeRotulo;
        public TextBox CapacidadeCaixa;
        public Label CapacidadeErroRotulo;

        public Button ConfirmarBotao;
        public Button CancelarBotao;

        public CadastrarVeiculoPainel() 
        { 
            InicializarComponentes();
        }

        public void InicializarComponentes()
        {
            Size = new Size(600, 400);

            IdentificacaoRotulo = new Label();
            IdentificacaoRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            IdentificacaoRotulo.Text = "Identificacao:";
            IdentificacaoRotulo.Location = new Point(150, 40);
            IdentificacaoRotulo.Size = new Size(120, 20);
            Controls.Add(IdentificacaoRotulo);

            IdentificacaoCaixa = new TextBox();
            IdentificacaoCaixa.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            IdentificacaoCaixa.Location = new Point(150, 60);
            IdentificacaoCaixa.Size = new Size(300, 30);
            Controls.Add(IdentificacaoCaixa);

            IdentificacaoErroRotulo = new Label();
            IdentificacaoErroRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            IdentificacaoErroRotulo.TextAlign = ContentAlignment.MiddleRight;
            IdentificacaoErroRotulo.ForeColor = Color.Red;
            IdentificacaoErroRotulo.Text = "";
            IdentificacaoErroRotulo.Location = new Point(250, 40);
            IdentificacaoErroRotulo.Size = new Size(200, 20);
            Controls.Add(IdentificacaoErroRotulo);

            ModalidadeRotulo = new Label();
            ModalidadeRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ModalidadeRotulo.Text = "Modalidade:";
            ModalidadeRotulo.Location = new Point(150, 110);
            ModalidadeRotulo.Size = new Size(120, 20);
            Controls.Add(ModalidadeRotulo);

            ModalidadeCaixa = new TextBox();
            ModalidadeCaixa.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ModalidadeCaixa.Location = new Point(150, 130);
            ModalidadeCaixa.Size = new Size(300, 30);
            Controls.Add(ModalidadeCaixa);

            ModalidadeErroRotulo = new Label();
            ModalidadeErroRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ModalidadeErroRotulo.TextAlign = ContentAlignment.MiddleRight;
            ModalidadeErroRotulo.ForeColor = Color.Red;
            ModalidadeErroRotulo.Text = "";
            ModalidadeErroRotulo.Location = new Point(250, 110);
            ModalidadeErroRotulo.Size = new Size(200, 20);
            Controls.Add(ModalidadeErroRotulo);

            CapacidadeRotulo = new Label();
            CapacidadeRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CapacidadeRotulo.Text = "Capacidade:";
            CapacidadeRotulo.Location = new Point(150, 180);
            CapacidadeRotulo.Size = new Size(130, 20);
            Controls.Add(CapacidadeRotulo);

            CapacidadeCaixa = new TextBox();
            CapacidadeCaixa.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CapacidadeCaixa.Location = new Point(150, 200);
            CapacidadeCaixa.Size = new Size(300, 30);
            Controls.Add(CapacidadeCaixa);

            CapacidadeErroRotulo = new Label();
            CapacidadeErroRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CapacidadeErroRotulo.TextAlign = ContentAlignment.MiddleRight;
            CapacidadeErroRotulo.ForeColor = Color.Red;
            CapacidadeErroRotulo.Text = "";
            CapacidadeErroRotulo.Location = new Point(250, 180);
            CapacidadeErroRotulo.Size = new Size(200, 20);
            Controls.Add(CapacidadeErroRotulo);

            ConfirmarBotao = new Button();
            ConfirmarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ConfirmarBotao.Text = "Confirmar";
            ConfirmarBotao.Location = new Point(150, 260);
            ConfirmarBotao.Size = new Size(130, 50);
            ConfirmarBotao.Click += ConfirmarClick;
            Controls.Add(ConfirmarBotao);

            CancelarBotao = new Button();
            CancelarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CancelarBotao.Text = "Cancelar";
            CancelarBotao.Location = new Point(320, 260);
            CancelarBotao.Size = new Size(130, 50);
            CancelarBotao.Click += CancelarClick;
            Controls.Add(CancelarBotao);
        }

        public void ConfirmarClick(object sender, EventArgs e)
        {
            bool valido = true;

            string identificacao = IdentificacaoCaixa.Text;
            string modalidade = ModalidadeCaixa.Text;
            string capacidade = CapacidadeCaixa.Text;
            IdentificacaoErroRotulo.Text = "";
            ModalidadeErroRotulo.Text = "";
            CapacidadeErroRotulo.Text = "";

            Empresa empresa = Formulario.UsuarioLogado as Empresa;

            if (identificacao.Length == 0)
            {
                IdentificacaoErroRotulo.Text = "Identificacao vazia";
                valido = false;
            }
            else if (empresa!.Veiculos.Find(v => v.Identificacao == identificacao) != null)
            {
                IdentificacaoErroRotulo.Text = "Ident. já cadastrada";
                valido = false;
            }

            if (modalidade.Length == 0) 
            {
                ModalidadeErroRotulo.Text = "Modalidade vazia";
                valido = false;
            }
            else if (ModalidadeRepositorio.Listar().Find(m => m.Nome == modalidade) == null)
            {
                ModalidadeErroRotulo.Text = "Modalidade invalida";
                valido = false;
            }

            int capacidadeNumero = 0;
            if (capacidade.Length == 0)
            {
                CapacidadeErroRotulo.Text = "Capacidade vazia";
                valido = false;
            }
            else if (!int.TryParse(capacidade,out capacidadeNumero))
            {
                CapacidadeErroRotulo.Text = "Numero invalido";
                valido = false;
            }

            if (!valido)
                return;

            Modalidade modalidadeClasse = ModalidadeRepositorio.Listar().Find(m => m.Nome == modalidade);
            Veiculo veiculo = new Veiculo(identificacao, empresa!, modalidadeClasse!, capacidadeNumero);
            VeiculoRepositorio.Cadastrar(veiculo);

            Visible = false;
            Parent!.Size = Formulario.GerenciarVeiculosPainel.Size;
            Formulario.GerenciarVeiculosPainel.CarregarInfo();
            Formulario.GerenciarVeiculosPainel.Visible = true;
        }

        public void CancelarClick(object sender, EventArgs e)
        {
            Visible = false;
            Parent!.Size = Formulario.GerenciarVeiculosPainel.Size;
            Formulario.GerenciarVeiculosPainel.Visible = true;
        }
    }
}
