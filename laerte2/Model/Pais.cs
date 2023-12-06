using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGerenciadorDeTransportes.Model
{
    [Table("tb_pais")]
    internal class Pais
    {
        [Key]
        public int PaisId { get; set; }
        public string Nome { get; set; }
        public List<Estado> Estados { get; set; }
    }
}
