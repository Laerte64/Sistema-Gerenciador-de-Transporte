using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGerenciadorDeTransportes.Model
{
    [Table("tb_empresa")]
    internal class Empresa : Usuario
    {
        public string CNPJ { get; set; }
        public List<Veiculo> Veiculos { get; set; }

        public Empresa() { }

        public Empresa(string nome, string senha, string cnpj) :base(nome, senha)
        {
            CNPJ = cnpj;
        }
    }
}
