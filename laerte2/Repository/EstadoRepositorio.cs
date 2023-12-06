using Microsoft.EntityFrameworkCore;
using SistemaGerenciadorDeTransportes.Data;
using SistemaGerenciadorDeTransportes.Model;
using System.Collections.Immutable;

namespace SistemaGerenciadorDeTransportes.Repository
{
    internal static class EstadoRepositorio
    {
        public static ImmutableList<Estado> Listar()
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            return contexto.Estados.Include(e => e.Pais).Include(e => e.Cidades).ToImmutableList();
        }
    }
}
