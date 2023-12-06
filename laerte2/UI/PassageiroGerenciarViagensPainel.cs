using SistemaGerenciadorDeTransportes.Model;
using SistemaGerenciadorDeTransportes.Repository;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class PassageiroGerenciarViagensPainel : Panel
    {
        public DataGridView ViagensTabela;
        public DataGridViewColumn ViagemColuna;
        public DataGridViewColumn EmpresaColuna;
        public DataGridViewColumn VeiculoColuna;
        public DataGridViewColumn DataColuna;
        public DataGridViewColumn PartidaColuna;
        public DataGridViewColumn ChegadaColuna;
        public DataGridViewColumn PassageirosColuna;
        public Button DesinscrisaoBotao;
        public Button VoltarBotao;

        public PassageiroGerenciarViagensPainel()
        {
            InicializarComponentes();
        }

        public void InicializarComponentes()
        {
            Size = new Size(880, 610);

            ViagensTabela = new DataGridView();
            ViagensTabela.Location = new Point(50, 50);
            ViagensTabela.Size = new Size(760, 400);
            ViagensTabela.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ViagensTabela.MultiSelect = false;
            ViagensTabela.RowHeadersVisible = false;
            ViagensTabela.AllowUserToAddRows = false;
            ViagensTabela.CancelEdit();
            Controls.Add(ViagensTabela);

            ViagemColuna = new DataGridViewTextBoxColumn();
            ViagemColuna.Name = "ViagemColuna";
            ViagemColuna.Visible = false;
            ViagensTabela.Columns.Add(ViagemColuna);

            EmpresaColuna = new DataGridViewTextBoxColumn();
            EmpresaColuna.Name = "EmpresaColuna";
            EmpresaColuna.HeaderText = "Empresa";
            EmpresaColuna.Width = 120;
            ViagensTabela.Columns.Add(EmpresaColuna);

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

            PartidaColuna = new DataGridViewTextBoxColumn();
            PartidaColuna.Name = "PartidaColuna";
            PartidaColuna.HeaderText = "Cidade Partida";
            PartidaColuna.Width = 120;
            ViagensTabela.Columns.Add(PartidaColuna);

            ChegadaColuna = new DataGridViewTextBoxColumn();
            ChegadaColuna.Name = "ChegadaColuna";
            ChegadaColuna.HeaderText = "Cidade Chegada";
            ChegadaColuna.Width = 120;
            ViagensTabela.Columns.Add(ChegadaColuna);

            PassageirosColuna = new DataGridViewTextBoxColumn();
            PassageirosColuna.Name = "PassageirosColuna";
            PassageirosColuna.HeaderText = "Passageiros";
            PassageirosColuna.Width = 120;
            ViagensTabela.Columns.Add(PassageirosColuna);

            DesinscrisaoBotao = new Button();
            DesinscrisaoBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            DesinscrisaoBotao.Text = "Cancelar Viagem";
            DesinscrisaoBotao.Location = new System.Drawing.Point(50, 480);
            DesinscrisaoBotao.Size = new Size(130, 50);
            DesinscrisaoBotao.Click += DesinscreverseClick;
            Controls.Add(DesinscrisaoBotao);

            VoltarBotao = new Button();
            VoltarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            VoltarBotao.Text = "Voltar";
            VoltarBotao.Location = new System.Drawing.Point(690, 480);
            VoltarBotao.Size = new Size(130, 50);
            VoltarBotao.Click += VoltarClick;
            Controls.Add(VoltarBotao);
        }

        public void CarregarInfo()
        {
            ViagensTabela.Rows.Clear();

            var empresas = EmpresaRepositorio.Listar();
            var viagens = ViagemRepositorio.Listar();
            var veiculos = VeiculoRepositorio.Listar();
            var cidades = CidadeRepositorio.Listar();
            DateTime hoje = DateTime.Now;

            Passageiro passageiro = Formulario.UsuarioLogado as Passageiro;
            foreach (var viagem in passageiro.Viagens)
            {
                Veiculo veiculo = viagem.Veiculo;
                Empresa empresa = viagem.Veiculo.Empresa;
                Cidade partida = viagem.CidadePartida;
                Cidade chegada = viagem.CidadeChegada;
                var passageiros = viagem.Passageiros;
                ViagensTabela.Rows.Add(viagem, empresa.Nome, veiculo.Identificacao, viagem.Data, partida.Nome, chegada.Nome, $"{passageiros.Count}/{veiculo.Capacidade}");
            }
        }

        public void DesinscreverseClick(object sender, EventArgs ev)
        {
            if (ViagensTabela.SelectedRows == null)
                return;
            Viagem viagem = ViagensTabela.SelectedRows[0].Cells["ViagemColuna"].Value as Viagem;
            if (viagem.Data < DateTime.Now)
                return;
            var passageiros = PassageiroRepositorio.Listar();
            Passageiro passageiro = Formulario.UsuarioLogado as Passageiro;
            ViagemRepositorio.RemoverPassageiro(viagem!, passageiro!);
            CarregarInfo();
        }

        public void VoltarClick(object sender, EventArgs e)
        {
            Visible = false;
            Parent!.Size = Formulario.PassageiroPainel.Size;
            Formulario.PassageiroPainel.Visible = true;
        }
    }
}
