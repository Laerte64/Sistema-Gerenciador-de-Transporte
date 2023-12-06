using SistemaGerenciadorDeTransportes.Model;
using SistemaGerenciadorDeTransportes.Repository;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class AtualizarVeiculoPainel : Panel
    {
        public Label IdentificacaoRotulo;
        public TextBox IdentificacaoCaixa;
        public Label IdentificacaoErroRotulo;

        public Button ConfirmarBotao;
        public Button CancelarBotao;

        public AtualizarVeiculoPainel()
        {
            InicializarComponentes();
        }

        public void InicializarComponentes()
        {
            Size = new Size(600, 250);

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

            ConfirmarBotao = new Button();
            ConfirmarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ConfirmarBotao.Text = "Confirmar";
            ConfirmarBotao.Location = new Point(150, 120);
            ConfirmarBotao.Size = new Size(130, 50);
            ConfirmarBotao.Click += ConfirmarClick;
            Controls.Add(ConfirmarBotao);

            CancelarBotao = new Button();
            CancelarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CancelarBotao.Text = "Cancelar";
            CancelarBotao.Location = new Point(320, 120);
            CancelarBotao.Size = new Size(130, 50);
            CancelarBotao.Click += CancelarClick;
            Controls.Add(CancelarBotao);

        }

        public void ConfirmarClick(object sender, EventArgs e)
        {
            string identificacao = IdentificacaoCaixa.Text;
            IdentificacaoErroRotulo.Text = "";

            Empresa empresa = Formulario.UsuarioLogado as Empresa;

            if (identificacao.Length == 0)
            {
                IdentificacaoErroRotulo.Text = "Identificacao vazia";
                return;
            }
            else if (empresa!.Veiculos.Find(v => v.Identificacao == identificacao) != null)
            {
                IdentificacaoErroRotulo.Text = "Ident. já cadastrada";
                return;
            }

            DataGridView tabela = Formulario.GerenciarVeiculosPainel.VeiculosTabela;
            string identificacaoAntiga = tabela.SelectedRows[0].Cells["IdentificacaoColuna"].Value as string;
            Veiculo veiculo = VeiculoRepositorio.Listar().Find(v => v.Identificacao == identificacaoAntiga);
            VeiculoRepositorio.Atualizar(veiculo, identificacao);

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
