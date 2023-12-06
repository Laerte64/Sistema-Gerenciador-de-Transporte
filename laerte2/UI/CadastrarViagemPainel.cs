using SistemaGerenciadorDeTransportes.Model;
using SistemaGerenciadorDeTransportes.Repository;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class CadastrarViagemPainel : Panel
    {
        public Label IdentificacaoRotulo;
        public TextBox IdentificacaoCaixa;
        public Label IdentificacaoErroRotulo;

        public Label LocalPartidaRotulo;
        public ComboBox PaisPartidaCaixa;
        public ComboBox EstadoPartidaCaixa;
        public ComboBox CidadePartidaCaixa;
        public Label LocalPartidaErroRotulo;

        public Label LocalChegadaRotulo;
        public ComboBox PaisChegadaCaixa;
        public ComboBox EstadoChegadaCaixa;
        public ComboBox CidadeChegadaCaixa;
        public Label LocalChegadaErroRotulo;

        public Label DataRotulo;
        public DateTimePicker DataSelecao;

        public Button ConfirmarBotao;
        public Button CancelarBotao;

        public CadastrarViagemPainel()
        {
            InicializarComponentes();
        }

        public void InicializarComponentes()
        {
            Size = new Size(600, 630);

            IdentificacaoRotulo = new Label();
            IdentificacaoRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            IdentificacaoRotulo.Text = "Veiculo:";
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

            LocalPartidaRotulo = new Label();
            LocalPartidaRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            LocalPartidaRotulo.Text = "Local de Partida:";
            LocalPartidaRotulo.Location = new Point(150, 110);
            LocalPartidaRotulo.Size = new Size(150, 20);
            Controls.Add(LocalPartidaRotulo);

            PaisPartidaCaixa = new ComboBox();
            PaisPartidaCaixa.Location = new Point(150, 130);
            PaisPartidaCaixa.Size = new Size(300, 30);
            PaisPartidaCaixa.DropDownStyle = ComboBoxStyle.DropDownList;
            PaisPartidaCaixa.Enabled = false;
            PaisPartidaCaixa.SelectedIndexChanged += CarregarEstadoPartida;
            Controls.Add(PaisPartidaCaixa);

            EstadoPartidaCaixa = new ComboBox();
            EstadoPartidaCaixa.Location = new Point(150, 170);
            EstadoPartidaCaixa.Size = new Size(300, 30);
            EstadoPartidaCaixa.DropDownStyle = ComboBoxStyle.DropDownList;
            EstadoPartidaCaixa.Enabled = false;
            EstadoPartidaCaixa.SelectedIndexChanged += CarregarCidadePartida;
            Controls.Add(EstadoPartidaCaixa);

            CidadePartidaCaixa = new ComboBox();
            CidadePartidaCaixa.Location = new Point(150, 210);
            CidadePartidaCaixa.Size = new Size(300, 30);
            CidadePartidaCaixa.DropDownStyle= ComboBoxStyle.DropDownList;
            CidadePartidaCaixa.Enabled = false;
            Controls.Add(CidadePartidaCaixa);

            LocalPartidaErroRotulo = new Label();
            LocalPartidaErroRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            LocalPartidaErroRotulo.TextAlign = ContentAlignment.MiddleRight;
            LocalPartidaErroRotulo.ForeColor = Color.Red;
            LocalPartidaErroRotulo.Text = "";
            LocalPartidaErroRotulo.Location = new Point(250, 110);
            LocalPartidaErroRotulo.Size = new Size(200, 20);
            Controls.Add(LocalPartidaErroRotulo);

            LocalChegadaRotulo = new Label();
            LocalChegadaRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            LocalChegadaRotulo.Text = "Local de Partida:";
            LocalChegadaRotulo.Location = new Point(150, 260);
            LocalChegadaRotulo.Size = new Size(150, 20);
            Controls.Add(LocalChegadaRotulo);

            PaisChegadaCaixa = new ComboBox();
            PaisChegadaCaixa.Location = new Point(150, 280);
            PaisChegadaCaixa.Size = new Size(300, 30);
            PaisChegadaCaixa.DropDownStyle = ComboBoxStyle.DropDownList;
            PaisChegadaCaixa.Enabled = false;
            PaisChegadaCaixa.SelectedIndexChanged += CarregarEstadoChegada;
            Controls.Add(PaisChegadaCaixa);

            EstadoChegadaCaixa = new ComboBox();
            EstadoChegadaCaixa.Location = new Point(150, 320);
            EstadoChegadaCaixa.Size = new Size(300, 30);
            EstadoChegadaCaixa.DropDownStyle = ComboBoxStyle.DropDownList;
            EstadoChegadaCaixa.Enabled = false;
            EstadoChegadaCaixa.SelectedIndexChanged += CarregarCidadeChegada;
            Controls.Add(EstadoChegadaCaixa);

            CidadeChegadaCaixa = new ComboBox();
            CidadeChegadaCaixa.Location = new Point(150, 360);
            CidadeChegadaCaixa.Size = new Size(300, 30);
            CidadeChegadaCaixa.DropDownStyle = ComboBoxStyle.DropDownList;
            CidadeChegadaCaixa.Enabled = false;
            Controls.Add(CidadeChegadaCaixa);

            LocalChegadaErroRotulo = new Label();
            LocalChegadaErroRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            LocalChegadaErroRotulo.TextAlign = ContentAlignment.MiddleRight;
            LocalChegadaErroRotulo.ForeColor = Color.Red;
            LocalChegadaErroRotulo.Text = "";
            LocalChegadaErroRotulo.Location = new Point(250, 260);
            LocalChegadaErroRotulo.Size = new Size(200, 20);
            Controls.Add(LocalChegadaErroRotulo);

            DataRotulo = new Label();
            DataRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            DataRotulo.Text = "Data:";
            DataRotulo.Location = new Point(150, 410);
            DataRotulo.Size = new Size(120, 20);
            Controls.Add(DataRotulo);

            DataSelecao = new DateTimePicker();
            DataSelecao.Location = new Point(150, 430);
            DataSelecao.Size = new Size(300, 20);
            DataSelecao.Format = DateTimePickerFormat.Short;
            DataSelecao.MinDate = DateTime.Today;
            Controls.Add(DataSelecao);

            ConfirmarBotao = new Button();
            ConfirmarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            ConfirmarBotao.Text = "Confirmar";
            ConfirmarBotao.Location = new Point(150, 490);
            ConfirmarBotao.Size = new Size(130, 50);
            ConfirmarBotao.Click += ConfirmarClick;
            Controls.Add(ConfirmarBotao);

            CancelarBotao = new Button();
            CancelarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CancelarBotao.Text = "Cancelar";
            CancelarBotao.Location = new Point(320, 490);
            CancelarBotao.Size = new Size(130, 50);
            CancelarBotao.Click += CancelarClick;
            Controls.Add(CancelarBotao);
        }

        public void CarregarPaises()
        {
            PaisPartidaCaixa.Items.Clear();
            EstadoPartidaCaixa.Items.Clear();
            CidadePartidaCaixa.Items.Clear();
            PaisChegadaCaixa.Items.Clear();
            EstadoChegadaCaixa.Items.Clear();
            CidadeChegadaCaixa.Items.Clear();

            var paises = PaisRepositorio.Listar();
            foreach ( var pais in paises )
            {
                PaisPartidaCaixa.Items.Add(pais.Nome);
                PaisChegadaCaixa.Items.Add(pais.Nome);
            }

            PaisPartidaCaixa.SelectedIndex = -1;
            PaisChegadaCaixa.SelectedIndex = -1;

            PaisPartidaCaixa.Enabled = true;
            EstadoPartidaCaixa.Enabled = false;
            CidadePartidaCaixa.Enabled = false;
            PaisChegadaCaixa.Enabled = true;
            EstadoChegadaCaixa.Enabled = false;
            CidadeChegadaCaixa.Enabled = false;
        }

        public void CarregarEstadoPartida(object sender, EventArgs e)
        {
            EstadoPartidaCaixa.Items.Clear();
            CidadePartidaCaixa.Items.Clear();

            string paisPartidaNome = PaisPartidaCaixa.SelectedItem.ToString();
            var paises = PaisRepositorio.Listar();
            Pais paisPartida = paises.Find(p => p.Nome == paisPartidaNome);

            var estados = EstadoRepositorio.Listar();
            foreach(var estado in paisPartida!.Estados) 
            { 
                EstadoPartidaCaixa.Items.Add(estado.Nome);
            }

            EstadoPartidaCaixa.SelectedIndex = -1;

            EstadoPartidaCaixa.Enabled = true;
            CidadePartidaCaixa.Enabled = false;
        }
        
        public void CarregarCidadePartida(object sender, EventArgs e)
        {
            CidadePartidaCaixa.Items.Clear();

            string estadoPartidaNome = EstadoPartidaCaixa.SelectedItem.ToString();
            var estados = EstadoRepositorio.Listar();
            Estado estadoPartida = estados.Find(e => e.Nome == estadoPartidaNome);

            var cidades = CidadeRepositorio.Listar();
            foreach (var cidade in estadoPartida.Cidades)
            {
                CidadePartidaCaixa.Items.Add(cidade.Nome);
            }

            CidadePartidaCaixa.SelectedIndex = -1;
            CidadePartidaCaixa.Enabled = true;
        }

        public void CarregarEstadoChegada(object sender, EventArgs e)
        {
            EstadoChegadaCaixa.Items.Clear();
            CidadeChegadaCaixa.Items.Clear();

            string paisChegadaNome = PaisChegadaCaixa.SelectedItem.ToString();
            var paises = PaisRepositorio.Listar();
            Pais paisChegada = paises.Find(p => p.Nome == paisChegadaNome);

            var estados = EstadoRepositorio.Listar();
            foreach (var estado in paisChegada!.Estados)
            {
                EstadoChegadaCaixa.Items.Add(estado.Nome);
            }

            EstadoChegadaCaixa.SelectedIndex = -1;

            EstadoChegadaCaixa.Enabled = true;
            CidadeChegadaCaixa.Enabled = false;
        }

        public void CarregarCidadeChegada(object sender, EventArgs e)
        {
            CidadeChegadaCaixa.Items.Clear();

            string estadoChegadaNome = EstadoChegadaCaixa.SelectedItem.ToString();
            var estados = EstadoRepositorio.Listar();
            Estado estadoChegada = estados.Find(e => e.Nome == estadoChegadaNome);

            var cidades = CidadeRepositorio.Listar();
            foreach (var cidade in estadoChegada.Cidades)
            {
                CidadeChegadaCaixa.Items.Add(cidade.Nome);
            }

            CidadeChegadaCaixa.SelectedIndex = -1;
            CidadeChegadaCaixa.Enabled = true;
        }

        public void ConfirmarClick(object sender, EventArgs e)
        {
            string veiculoIdentificacao = IdentificacaoCaixa.Text;
            int cidadePartidaIndice = CidadePartidaCaixa.SelectedIndex;
            int cidadeChegadaIndice = CidadeChegadaCaixa.SelectedIndex;
            DateTime horario = DataSelecao.Value;
            LocalPartidaErroRotulo.Text = "";
            LocalChegadaErroRotulo.Text = "";
            IdentificacaoErroRotulo.Text = "";

            bool valido = true;
            if (veiculoIdentificacao.Length == 0)
            {
                IdentificacaoErroRotulo.Text = "Veiculo vazio";
                valido = false;
            }
            else if (VeiculoRepositorio.Listar().Find(v => v.Identificacao == veiculoIdentificacao) == null)
            {
                IdentificacaoErroRotulo.Text = "Veiculo invalido";
                valido = false;
            }

            if (cidadePartidaIndice == -1)
            {
                LocalPartidaErroRotulo.Text = "Campo obrigatorio";
                valido = false;
            }

            if (cidadeChegadaIndice == -1)
            {
                LocalChegadaErroRotulo.Text = "Campo obrigatorio";
                valido = false;
            }

            if (!valido)
                return;

            var veiculos = VeiculoRepositorio.Listar();
            Veiculo veiculo = veiculos.Find(v => v.Identificacao == veiculoIdentificacao);

            var cidades = CidadeRepositorio.Listar();
            Cidade cidadePartida = cidades.Find(c => c.Nome == CidadePartidaCaixa.SelectedItem.ToString());
            Cidade cidadeChegada = cidades.Find(c => c.Nome == CidadeChegadaCaixa.SelectedItem.ToString());

            Viagem viagem = new Viagem(veiculo!, cidadePartida!, cidadeChegada!, horario);
            ViagemRepositorio.Cadastrar(viagem);

            Visible = false;
            Parent!.Size = Formulario.EmpresaGerenciarViagensPainel.Size;
            Formulario.EmpresaGerenciarViagensPainel.CarregarInfo();
            Formulario.EmpresaGerenciarViagensPainel.Visible = true;
        }

        public void CancelarClick(object sender, EventArgs e)
        {
            Visible = false;
            Parent!.Size = Formulario.EmpresaGerenciarViagensPainel.Size;
            Formulario.EmpresaGerenciarViagensPainel.CarregarInfo();
            Formulario.EmpresaGerenciarViagensPainel.Visible = true;
        }
    }
}
