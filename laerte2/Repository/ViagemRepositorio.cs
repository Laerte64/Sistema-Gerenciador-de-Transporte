using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorDeTransportes.Data;
using SistemaGerenciadorDeTransportes.Model;
using System.Collections.Immutable;

namespace SistemaGerenciadorDeTransportes.Repository
{
    internal class ViagemRepositorio
    {
        public static ImmutableList<Viagem> Listar()
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            return contexto.Viagens
                .Include(v => v.Veiculo)
                .Include(v => v.CidadePartida)
                .Include(v => v.CidadeChegada)
                .Include(v => v.Passageiros)
                .ToImmutableList();
        }

        public static bool Cadastrar(Viagem viagem)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            contexto.Viagens.Add(viagem);
            try
            {
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool Atualizar(Viagem viagem, Veiculo? veiculo)
        {
            if (veiculo != null)
                viagem.Veiculo = veiculo;
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            try
            {
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool AdicionarPassageiro(Viagem viagem, Passageiro passageiro)
        {
            if (viagem.Passageiros.Count == viagem.Veiculo.Capacidade)
                return false;
            if (viagem.Passageiros.Contains(passageiro))
                return false;
            viagem.Passageiros.Add(passageiro);
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            try
            {
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool RemoverPassageiro(Viagem viagem, Passageiro passageiro)
        {
            if (!viagem.Passageiros.Contains(passageiro))
                return false;
            viagem.Passageiros.Remove(passageiro);
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            try
            {
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool Deletar(Viagem viagem)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            contexto.Viagens.Remove(viagem);
            try
            {
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
