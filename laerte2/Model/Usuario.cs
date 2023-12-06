using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGerenciadorDeTransportes.Model
{
    [Table("tb_usuario")]
    class Usuario
    {
        public enum Tipo
        {
            Passageiro,
            Empresa
        }

        [Key]
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public Usuario() { }

        public Usuario(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }
    }
}
