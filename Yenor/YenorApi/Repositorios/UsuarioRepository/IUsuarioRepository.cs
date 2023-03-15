using YenorApiModels;

namespace YenorApi.Repositorios.UsuarioRepository
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetUsuarios();
        Usuario Get(int id);
        Usuario Create(Usuario usuario);
        Usuario Update(Usuario usuario);
        void Delete(int id);

    }
}
