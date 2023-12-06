using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorDeTransportes.Data;
using SistemaGerenciadorDeTransportes.Model;

namespace SistemaGerenciadorDeTransportes.Repository
{
    internal static class CidadeRepositorio
    {
        public static ImmutableList<Cidade> Listar()
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            return contexto.Cidades.Include(c => c.Estado).ToImmutableList();
        }
    }
}
