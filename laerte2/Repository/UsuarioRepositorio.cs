using System.Collections.Immutable;
using SistemaGerenciadorDeTransportes.Data;
using SistemaGerenciadorDeTransportes.Model;

namespace SistemaGerenciadorDeTransportes.Repository
{
    internal static class UsuarioRepositorio
    {
        public static ImmutableList<Usuario> Listar()
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            return contexto.Usuarios.ToImmutableList();
        }

        public static bool Atualizar(Usuario usuario, string? senha)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            if (senha != null)
                usuario.Senha = senha;
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

        public static bool Deletar(Usuario usuario)
        {
            var contexto = SistemaTransporteContexto.AdquirirContexto();
            contexto.Usuarios.Remove(usuario);
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
