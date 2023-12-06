using SistemaGerenciadorDeTransportes.Model;
using SistemaGerenciadorDeTransportes.Repository;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class PesquisarViagensPainel : Panel
    {
        public DataGridView ViagensTabela;
        public DataGridViewColumn ViagemColuna;
        public DataGridViewColumn EmpresaColuna;
        public DataGridViewColumn VeiculoColuna;
        public DataGridViewColumn DataColuna;
        public DataGridViewColumn PartidaColuna;
        public DataGridViewColumn ChegadaColuna;
        public DataGridViewColumn PassageirosColuna;
        public Button InscreverseBotao;
        public Button VoltarBotao;

        public PesquisarViagensPainel()
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

            InscreverseBotao = new Button();
            InscreverseBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            InscreverseBotao.Text = "Cadastrar Viagem";
            InscreverseBotao.Location = new System.Drawing.Point(50, 480);
            InscreverseBotao.Size = new Size(130, 50);
            InscreverseBotao.Click += InscreverseClick;
            Controls.Add(InscreverseBotao);

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
            
            foreach (var viagem in viagens.FindAll(v => v.Data > hoje))
            {
                Veiculo veiculo = viagem.Veiculo;
                Empresa empresa = viagem.Veiculo.Empresa;
                Cidade partida = viagem.CidadePartida;
                Cidade chegada = viagem.CidadeChegada;
                var passageiros = viagem.Passageiros;
                if (passageiros.Contains(Formulario.UsuarioLogado as Passageiro))
                    continue;
                ViagensTabela.Rows.Add(viagem, empresa.Nome, veiculo.Identificacao, viagem.Data, partida.Nome, chegada.Nome, $"{passageiros.Count}/{veiculo.Capacidade}");
            }
        }

        public void InscreverseClick(object sender, EventArgs ev)
        {
            if (ViagensTabela.SelectedRows == null)
                return;
            Viagem viagem = ViagensTabela.SelectedRows[0].Cells["ViagemColuna"].Value as Viagem;
            var passageiros = PassageiroRepositorio.Listar();
            var veiculos = VeiculoRepositorio.Listar();
            if (viagem.Passageiros.Count() == viagem.Veiculo.Capacidade)
                return;
            ViagemRepositorio.AdicionarPassageiro(viagem, Formulario.UsuarioLogado as Passageiro);
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
