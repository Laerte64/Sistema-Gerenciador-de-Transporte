using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGerenciadorDeTransportes.Model
{
    [Table("tb_estado")]
    internal class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public List<Cidade> Cidades { get; set; }
    }
}
