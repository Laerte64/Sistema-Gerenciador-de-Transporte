using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGerenciadorDeTransportes.Model
{
    [Table("tb_veiculo")]
    internal class Veiculo
    {
        [Key]
        public int VeiculoId { get; set; }
        public string Identificacao { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int ModalidadeId { get; set; }
        public Modalidade Modalidade { get; set; }
        public int Capacidade { get; set; }
        public List<Viagem> Viagens { get; set; }

        public Veiculo() { }

        public Veiculo(string identificacao, Empresa empresa, Modalidade modalidade, int capacidade) 
        {
            Identificacao = identificacao;
            Empresa = empresa;
            Modalidade = modalidade;
            Capacidade = capacidade;
        }
    }
}
