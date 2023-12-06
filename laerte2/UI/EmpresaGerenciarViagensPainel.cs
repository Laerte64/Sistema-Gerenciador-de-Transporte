using SistemaGerenciadorDeTransportes.Model;
using SistemaGerenciadorDeTransportes.Repository;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class EmpresaGerenciarViagensPainel : Panel
    {
        public DataGridView ViagensTabela;
        public DataGridViewColumn ViagemColuna;
        public DataGridViewColumn VeiculoColuna;
        public DataGridViewColumn DataColuna;
        public DataGridViewColumn CidadePartidaColuna;
        public DataGridViewColumn CidadeChegadaColuna;
        public DataGridViewColumn PassageirosColuna;
        public Button CadastrarViagemBotao;
        public Button DeletarViagemBotao;
        public Button VoltarBotao;

        public EmpresaGerenciarViagensPainel() 
        {
            InicializarComponentes();
        }

        public void InicializarComponentes()
        {
            Size = new Size(760, 610);

            ViagensTabela = new DataGridView();
            ViagensTabela.Location = new Point(50, 50);
            ViagensTabela.Size = new Size(643, 400);
            ViagensTabela.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ViagensTabela.MultiSelect = false;
            ViagensTabela.RowHeadersVisible = false;
            ViagensTabela.AllowUserToAddRows = false;
            ViagensTabela.ReadOnly = true;
            Controls.Add(ViagensTabela);

            ViagemColuna = new DataGridViewTextBoxColumn();
            ViagemColuna.Name = "ViagemColuna";
            ViagemColuna.Visible = false;
            ViagensTabela.Columns.Add(ViagemColuna);

            VeiculoColuna = new DataGridViewTextBoxColumn();
            VeiculoColuna.Name = "VeiculoColuna";
            VeiculoColuna.HeaderText = "Veiculo";
            VeiculoColuna.Width = 120;
            ViagensTabela.Columns.Add(VeiculoColuna);

            DataColuna = new DataGridViewTextBoxColumn();
            DataColuna.Name = "DataColuna";
            DataColuna.HeaderText = "Data";
            DataColuna.Width = 160;
            ViagensTabela.Columns.Add(DataColuna);
            
            CidadePartidaColuna = new DataGridViewTextBoxColumn();
            CidadePartidaColuna.Name = "CidadePartidaColuna";
            CidadePartidaColuna.HeaderText = "Cidade Partida";
            CidadePartidaColuna.Width = 120;
            ViagensTabela.Columns.Add(CidadePartidaColuna);

            CidadeChegadaColuna = new DataGridViewTextBoxColumn();
            CidadeChegadaColuna.Name = "CidadeChegadaColuna";
            CidadeChegadaColuna.HeaderText = "Cidade Chegada";
            CidadeChegadaColuna.Width = 120;
            ViagensTabela.Columns.Add(CidadeChegadaColuna);

            PassageirosColuna = new DataGridViewTextBoxColumn();
            PassageirosColuna.Name = "PassageirosColuna";
            PassageirosColuna.HeaderText = "Passageiros";
            PassageirosColuna.Width = 120;
            ViagensTabela.Columns.Add(PassageirosColuna);

            CadastrarViagemBotao = new Button();
            CadastrarViagemBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CadastrarViagemBotao.Text = "Cadastrar Viagem";
            CadastrarViagemBotao.Location = new System.Drawing.Point(50, 480);
            CadastrarViagemBotao.Size = new Size(130, 50);
            CadastrarViagemBotao.Click += CadastrarClick;
            Controls.Add(CadastrarViagemBotao);

            DeletarViagemBotao = new Button();
            DeletarViagemBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            DeletarViagemBotao.Text = "Deletar Viagem";
            DeletarViagemBotao.Location = new System.Drawing.Point(220, 480);
            DeletarViagemBotao.Size = new Size(130, 50);
            DeletarViagemBotao.Click += DeletarClick;
            Controls.Add(DeletarViagemBotao);

            VoltarBotao = new Button();
            VoltarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            VoltarBotao.Text = "Voltar";
            VoltarBotao.Location = new System.Drawing.Point(570, 480);
            VoltarBotao.Size = new Size(130, 50);
            VoltarBotao.Click += VoltarClick;
            Controls.Add(VoltarBotao);
        }

        public void CarregarInfo()
        {
            ViagensTabela.Rows.Clear();

            Empresa empresa = Formulario.UsuarioLogado as Empresa;
            var viagens = ViagemRepositorio.Listar();
            var veiculos = VeiculoRepositorio.Listar();
            var cidades = CidadeRepositorio.Listar();

            foreach (var veiculo in empresa.Veiculos)
                foreach (var viagem in veiculo.Viagens)
                    ViagensTabela.Rows.Add(viagem, veiculo.Identificacao, viagem.Data, viagem.CidadePartida.Nome, viagem.CidadeChegada.Nome, $"{viagem.Passageiros.Count}/{viagem.Veiculo.Capacidade}");
            
        }

        public void CadastrarClick(object sender, EventArgs e)
        {
            Visible = false;
            Parent!.Size = Formulario.CadastrarViagemPainel.Size;
            Formulario.CadastrarViagemPainel.CarregarPaises();
            Formulario.CadastrarViagemPainel.IdentificacaoCaixa.Text = "";
            Formulario.CadastrarViagemPainel.Visible = true;
        }

        public void DeletarClick(object sender, EventArgs e)
        {
            if (ViagensTabela.SelectedRows == null)
                return;
            Viagem viagem = ViagensTabela.SelectedRows[0].Cells["ViagemColuna"].Value as Viagem;
            ViagemRepositorio.Deletar(viagem);
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
