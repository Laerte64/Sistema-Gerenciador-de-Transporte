using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGerenciadorDeTransportes.Model
{
    [Table("tb_viagem")]
    internal class Viagem
    {
        [Key]
        public int ViagemId { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public int CidadePartidaId { get; set; }
        public Cidade CidadePartida { get; set; }
        public int CidadeChegadaId { get; set; }
        public Cidade CidadeChegada { get; set; }
        public DateTime Data { get; set; }
        public List<Passageiro> Passageiros { get; set; }

        public Viagem() { }

        public Viagem(Veiculo veiculo, Cidade cidadePartida, Cidade cidadeChegada, DateTime data) 
        {
            Veiculo = veiculo;
            CidadePartida = cidadePartida;
            CidadeChegada = cidadeChegada;
            Data = data;
        }
    }
}
