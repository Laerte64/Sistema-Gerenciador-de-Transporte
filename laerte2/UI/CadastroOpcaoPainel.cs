using SistemaGerenciadorDeTransportes.Model;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal class CadastroOpcaoPainel : Panel
    {

        public Label OpcaoRotulo;
        public Button OpcaoPassageiroBotao;
        public Button OpcaoEmpresaBotao;
        public Button CancelarBotao;
        public Usuario.Tipo Opcao;

        public CadastroOpcaoPainel() 
        {
            InicializarComponentes();
        }

        public void InicializarComponentes()
        {
            Size = new System.Drawing.Size(600, 420);

            OpcaoRotulo = new Label();
            OpcaoRotulo.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            OpcaoRotulo.Text = "Qual tipo de Usuario deseja criar:";
            OpcaoRotulo.Location = new Point(150, 100);
            OpcaoRotulo.Size = new Size(300, 20);
            Controls.Add(OpcaoRotulo);

            OpcaoPassageiroBotao = new Button();
            OpcaoPassageiroBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            OpcaoPassageiroBotao.Text = "Passageiro";
            OpcaoPassageiroBotao.Location = new Point(150, 160);
            OpcaoPassageiroBotao.Size = new Size(130, 50);
            OpcaoPassageiroBotao.Click += PassageiroClick;
            Controls.Add(OpcaoPassageiroBotao);

            OpcaoEmpresaBotao = new Button();
            OpcaoEmpresaBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            OpcaoEmpresaBotao.Text = "Empresa";
            OpcaoEmpresaBotao.Location = new Point(320, 160);
            OpcaoEmpresaBotao.Size = new Size(130, 50);
            OpcaoEmpresaBotao.Click += EmpresaClick;
            Controls.Add(OpcaoEmpresaBotao);

            CancelarBotao = new Button();
            CancelarBotao.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
            CancelarBotao.Text = "Cancelar";
            CancelarBotao.Location = new Point(235, 250);
            CancelarBotao.Size = new Size(130, 50);
            CancelarBotao.Click += CancelarClick;
            Controls.Add(CancelarBotao);
        }

        private void PassageiroClick(object sender, EventArgs e)
        {
            Opcao = Usuario.Tipo.Passageiro;
            Visible = false;
            Parent.Size = Formulario.CadastroExtraPainel.Size;
            Formulario.CadastroExtraPainel.ExtraRotulo.Text = "Insira seu CPF";
            Formulario.CadastroExtraPainel.Visible = true;
        }

        private void EmpresaClick(object sender, EventArgs e) 
        {
            Opcao = Usuario.Tipo.Empresa;
            Visible = false;
            Parent.Size = Formulario.CadastroExtraPainel.Size;
            Formulario.CadastroExtraPainel.ExtraRotulo.Text = "Insira seu CNPJ";
            Formulario.CadastroExtraPainel.Visible = true;
        }

        private void CancelarClick(object sender, EventArgs e) 
        {
            Visible = false;
            Parent.Size = Formulario.EntrarPainel.Size;
            Formulario.EntrarPainel.NomeUsuarioCaixa.Text = "";
            Formulario.EntrarPainel.SenhaUsuarioCaixa.Text = "";
            Formulario.EntrarPainel.Visible = true;
        }
    }
}
