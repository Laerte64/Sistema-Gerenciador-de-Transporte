using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorDeTransportes.Data;
using SistemaGerenciadorDeTransportes.Model;
using System.Collections.Immutable;

namespace SistemaGerenciadorDeTransportes.Repository
{
    internal static class PaisRepositorio
    {
        public static ImmutableList<Pais> Listar()
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            return contexto.Paises.Include(p => p.Estados).ToImmutableList();
        }
    }
}
