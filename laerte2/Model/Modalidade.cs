using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGerenciadorDeTransportes.Model
{
    [Table("tb_modalidade")]
    internal class Modalidade
    {
        [Key]
        public int ModalidadeId { get; set; }
        public string Nome { get; set; }
        public List<Veiculo> Veiculos { get; set; }
    }
}
