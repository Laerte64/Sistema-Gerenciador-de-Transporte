using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorDeTransportes.Data;
using SistemaGerenciadorDeTransportes.Model;
using System.Collections.Immutable;

namespace SistemaGerenciadorDeTransportes.Repository
{
    internal class ModalidadeRepositorio
    {
        public static ImmutableList<Modalidade> Listar()
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            return contexto.Modalidades.Include(m => m.Veiculos).ToImmutableList();
        }

        public static bool Cadastrar(Modalidade modalidade)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            contexto.Modalidades.Add(modalidade);
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

        public static bool Atualizar(Modalidade modalidade, string? nome)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            if (nome != null)
                modalidade.Nome = nome;
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

        public static bool Deletar(Modalidade modalidade)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            contexto.Modalidades.Remove(modalidade);
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
