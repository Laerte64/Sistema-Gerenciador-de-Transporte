using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorDeTransportes.Data;
using SistemaGerenciadorDeTransportes.Model;
using System.Collections.Immutable;

namespace SistemaGerenciadorDeTransportes.Repository
{
    internal static class PassageiroRepositorio
    {
        public static ImmutableList<Passageiro> Listar()
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            return contexto.Passageiros.Include(p => p.Viagens).ToImmutableList();
        }

        public static bool Cadastrar(Passageiro passageiro)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            contexto.Passageiros.Add(passageiro);
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

        public static bool Atualizar(Passageiro passageiro, string? senha, string? cpf)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            if (senha != null) 
                passageiro.Senha = senha;
            if (cpf != null)
                passageiro.CPF = cpf;
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

        public static bool Deletar(Passageiro passageiro)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            contexto.Passageiros.Remove(passageiro);
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
