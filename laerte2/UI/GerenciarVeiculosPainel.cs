using SistemaGerenciadorDeTransportes.Model;
using SistemaGerenciadorDeTransportes.Repository;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class GerenciarVeiculosPainel : Panel
    {
        public DataGridView VeiculosTabela;
        public DataGridViewTextBoxColumn IdentificacaoColuna;
        public DataGridViewTextBoxColumn ModalidadeColuna;
        public DataGridViewTextBoxColumn CapacidadeColuna;
        public DataGridViewTextBoxColumn ViagensColuna;
        public Button CadastrarVeiculoBotao;
        public Button AtualizarVeiculoBotao;
        public Button DeletarVeiculoBotao;
        public Button VoltarBotao;
        public Label ErroRotulo;

        public GerenciarVeiculosPainel()
        {
            InicializarComponentes();
        }

        public void InicializarComponentes()
        {
            Size = new System.Drawing.Size(580, 670);

            VeiculosTabela = new DataGridView();

            VeiculosTabela.Location = new Point(50, 50);
            VeiculosTabela.Size = new Size(483, 400);
            VeiculosTabela.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            VeiculosTabela.MultiSelect = false;
            VeiculosTabela.RowHeadersVisible = false;
            VeiculosTabela.AllowUserToAddRows = false;
            VeiculosTabela.ReadOnly = true;
            Controls.Add(VeiculosTabela);

            IdentificacaoColuna = new DataGridViewTextBoxColumn();
            IdentificacaoColuna.Name = "IdentificacaoColuna";
            IdentificacaoColuna.HeaderText = "Identificacao";
            IdentificacaoColuna.Width = 120;
            VeiculosTabela.Columns.Add(IdentificacaoColuna);

            ModalidadeColuna = new DataGridViewTextBoxColumn();
            ModalidadeColuna.Name = "ModalidadeColuna";
            ModalidadeColuna.HeaderText = "Modalidade";
            ModalidadeColuna.Width= 120;
            VeiculosTabela.Columns.Add(ModalidadeColuna);

            CapacidadeColuna = new DataGridViewTextBoxColumn();
            CapacidadeColuna.Name = "CapacidadeColuna";
            CapacidadeColuna.HeaderText = "Capacidade";
            CapacidadeColuna.Width = 120;
            VeiculosTabela.Columns.Add(CapacidadeColuna);

            ViagensColuna = new DataGridViewTextBoxColumn();
            ViagensColuna.Name = "ViagensColuna";
            ViagensColuna.HeaderText = "Viagens";
            ViagensColuna.Width = 120;
            VeiculosTabela.Columns.Add(ViagensColuna);

            CadastrarVeiculoBotao = new Button();
            CadastrarVeiculoBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CadastrarVeiculoBotao.Text = "Cadastrar Veiculo";
            CadastrarVeiculoBotao.Location = new System.Drawing.Point(50, 480);
            CadastrarVeiculoBotao.Size = new Size(130, 50);
            CadastrarVeiculoBotao.Click += CadastrarClick;
            Controls.Add(CadastrarVeiculoBotao);

            AtualizarVeiculoBotao = new Button();
            AtualizarVeiculoBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            AtualizarVeiculoBotao.Text = "Atualizar Veiculo";
            AtualizarVeiculoBotao.Location = new System.Drawing.Point(220, 480);
            AtualizarVeiculoBotao.Size = new Size(130, 50);
            AtualizarVeiculoBotao.Click += AtualizarClick;
            Controls.Add(AtualizarVeiculoBotao);

            DeletarVeiculoBotao = new Button();
            DeletarVeiculoBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            DeletarVeiculoBotao.Text = "Deletar Veiculo";
            DeletarVeiculoBotao.Location = new System.Drawing.Point(390, 480);
            DeletarVeiculoBotao.Size = new Size(130, 50);
            DeletarVeiculoBotao.Click += DeletarClick;
            Controls.Add(DeletarVeiculoBotao);

            VoltarBotao = new Button();
            VoltarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            VoltarBotao.Text = "Voltar";
            VoltarBotao.Location = new System.Drawing.Point(220, 540);
            VoltarBotao.Size = new Size(130, 50);
            VoltarBotao.Click += VoltarClick;
            Controls.Add(VoltarBotao);
        }

        public void CarregarInfo()
        {
            VeiculosTabela.Rows.Clear();

            var veiculos = VeiculoRepositorio.Listar();
            foreach (Veiculo veiculo in veiculos.FindAll(v => v.Empresa == Formulario.UsuarioLogado as Empresa))
                VeiculosTabela.Rows.Add(veiculo.Identificacao, veiculo.Modalidade.Nome, veiculo.Capacidade, veiculo.Viagens.Count);
        }

        public void CadastrarClick(object sender, EventArgs e)
        {
            Visible = false;
            Parent!.Size = Formulario.CadastrarVeiculoPainel.Size;
            Formulario.CadastrarVeiculoPainel.Visible = true;
        }

        public void AtualizarClick(object sender, EventArgs e) 
        {
            string identificacao = VeiculosTabela.SelectedRows[0].Cells["IdentificacaoColuna"].Value as string;
            Veiculo veiculo = VeiculoRepositorio.Listar().Find(v => v.Identificacao == identificacao);
            if (veiculo == null)
                return;

            Visible = false;
            Parent!.Size = Formulario.AtualizarVeiculoPainel.Size;
            Formulario.AtualizarVeiculoPainel.Visible = true;
        }

        public void DeletarClick(object sender, EventArgs e) 
        { 
            string identificacao = VeiculosTabela.SelectedRows[0].Cells["IdentificacaoColuna"].Value as string;
            Veiculo veiculo = VeiculoRepositorio.Listar().Find(v => v.Identificacao == identificacao);
            if (veiculo == null)
                return;

            VeiculoRepositorio.Deletar(veiculo);
            CarregarInfo();
        }

        public void VoltarClick(object sender, EventArgs e)
        {
            Visible = false;
            Parent!.Size = Formulario.EmpresaPainel.Size;
            Formulario.EmpresaPainel.Visible = true;
        }
    }
}
