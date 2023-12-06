using SistemaGerenciadorDeTransportes.Model;

namespace SistemaGerenciadorDeTransportes.UI
{
    internal partial class Formulario : Form
    {

        public static Usuario? UsuarioLogado;
        public static Usuario.Tipo UsuarioTipo;

        public static EntrarPainel EntrarPainel;
        public static CadastroOpcaoPainel CadastroOpcaoPainel;
        public static CadastroExtraPainel CadastroExtraPainel;

        public static PassageiroPainel PassageiroPainel;
        public static PesquisarViagensPainel PesquisarViagensPainel;
        public static PassageiroGerenciarViagensPainel PassageiroGerenciarViagensPainel;

        public static EmpresaPainel EmpresaPainel;
        public static GerenciarVeiculosPainel GerenciarVeiculosPainel;
        public static CadastrarVeiculoPainel CadastrarVeiculoPainel;
        public static AtualizarVeiculoPainel AtualizarVeiculoPainel;
        public static EmpresaGerenciarViagensPainel EmpresaGerenciarViagensPainel;
        public static CadastrarViagemPainel CadastrarViagemPainel;

        public static AlterarSenhaPainel AlterarSenhaPainel;
        public static ConfirmarDelecaoPainel ConfirmarDelecaoPainel;

        public Formulario()
        {
            InicializarComponentes();
            Size = EntrarPainel.Size;
            EntrarPainel.Visible = true;
        }
        private void InicializarComponentes()
        {
            Text = "Sistema Gerenciador de Transportes";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            EntrarPainel = new EntrarPainel();
            EntrarPainel.Visible = false;
            Controls.Add(EntrarPainel);

            CadastroOpcaoPainel = new CadastroOpcaoPainel();
            CadastroOpcaoPainel.Visible = false;
            Controls.Add(CadastroOpcaoPainel);

            CadastroExtraPainel = new CadastroExtraPainel();
            CadastroExtraPainel.Visible = false;
            Controls.Add(CadastroExtraPainel);

            PassageiroPainel = new PassageiroPainel();
            PassageiroPainel.Visible = false;
            Controls.Add(PassageiroPainel);

            PesquisarViagensPainel = new PesquisarViagensPainel();
            PesquisarViagensPainel.Visible = false;
            Controls.Add(PesquisarViagensPainel);

            PassageiroGerenciarViagensPainel = new PassageiroGerenciarViagensPainel();
            PassageiroGerenciarViagensPainel.Visible = false;
            Controls.Add(PassageiroGerenciarViagensPainel);

            EmpresaPainel = new EmpresaPainel();
            EmpresaPainel.Visible = false;
            Controls.Add(EmpresaPainel);

            GerenciarVeiculosPainel = new GerenciarVeiculosPainel();
            GerenciarVeiculosPainel.Visible = false;
            Controls.Add(GerenciarVeiculosPainel);

            CadastrarVeiculoPainel = new CadastrarVeiculoPainel();
            CadastrarVeiculoPainel.Visible = false;
            Controls.Add(CadastrarVeiculoPainel);

            AtualizarVeiculoPainel = new AtualizarVeiculoPainel();
            AtualizarVeiculoPainel.Visible = false;
            Controls.Add(AtualizarVeiculoPainel);

            EmpresaGerenciarViagensPainel = new EmpresaGerenciarViagensPainel();
            EmpresaGerenciarViagensPainel.Visible = false;
            Controls.Add(EmpresaGerenciarViagensPainel);

            CadastrarViagemPainel = new CadastrarViagemPainel();
            CadastrarViagemPainel.Visible = false;
            Controls.Add(CadastrarViagemPainel);

            AlterarSenhaPainel = new AlterarSenhaPainel();
            AlterarSenhaPainel.Visible = false;
            Controls.Add(AlterarSenhaPainel);

            ConfirmarDelecaoPainel = new ConfirmarDelecaoPainel();
            ConfirmarDelecaoPainel.Visible = false;
            Controls.Add(ConfirmarDelecaoPainel);

        }
    }
}
