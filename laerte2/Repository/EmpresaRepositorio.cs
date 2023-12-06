using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorDeTransportes.Data;
using SistemaGerenciadorDeTransportes.Model;
using System.Collections.Immutable;

namespace SistemaGerenciadorDeTransportes.Repository
{
    internal static class EmpresaRepositorio
    {
        public static ImmutableList<Empresa> Listar()
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            return contexto.Empresas.Include(e => e.Veiculos).ToImmutableList();
        }

        public static bool Cadastrar(Empresa empresa)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            contexto.Empresas.Add(empresa);
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

        public static bool Atualizar(Empresa empresa, string? senha, string? cnpj) 
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            if(senha != null)
                empresa.Senha = senha;
            if (cnpj != null)
                empresa.CNPJ = cnpj;
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

        public static bool Deletar(Empresa empresa)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            contexto.Empresas.Remove(empresa);
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
