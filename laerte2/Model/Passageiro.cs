using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGerenciadorDeTransportes.Model
{
    [Table("tb_passageiro")]
    internal class Passageiro : Usuario
    {
        public string CPF { get; set; }
        public List<Viagem> Viagens { get; set; }

        public Passageiro() { }

        public Passageiro(string nome, string senha, string cpf) : base(nome, senha)
        {
            CPF = cpf;
        }
    }
}
