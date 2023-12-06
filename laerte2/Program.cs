using SistemaGerenciadorDeTransportes.UI;

namespace SistemaGerenciadorDeTransportes
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Formulario());
            
        }
    }
}