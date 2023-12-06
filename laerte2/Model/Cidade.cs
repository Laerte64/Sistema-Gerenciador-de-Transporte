using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGerenciadorDeTransportes.Model
{
    [Table("tb_cidade")]
    internal class Cidade
    {
        [Key]
        public int CidadeId { get; set; }
        public string Nome { get; set;}
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
    }
}
