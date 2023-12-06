using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorDeTransportes.Data;
using SistemaGerenciadorDeTransportes.Model;
using System.Collections.Immutable;

namespace SistemaGerenciadorDeTransportes.Repository
{
    internal class VeiculoRepositorio
    {
        public static ImmutableList<Veiculo> Listar()
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            return contexto.Veiculos.Include(v => v.Modalidade).Include(v => v.Empresa).Include(v => v.Viagens).ToImmutableList();
        }

        public static bool Cadastrar(Veiculo veiculo)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            contexto.Veiculos.Add(veiculo);
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

        public static bool Atualizar (Veiculo veiculo, string identificacao)
        {
            veiculo.Identificacao = identificacao;
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

        public static bool Deletar(Veiculo veiculo)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            contexto.Veiculos.Remove(veiculo);
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
