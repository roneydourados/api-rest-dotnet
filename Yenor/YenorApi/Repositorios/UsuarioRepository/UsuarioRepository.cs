using YenorApi.Contextos;
using YenorApiModels;

namespace YenorApi.Repositorios.UsuarioRepository
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly IRepository<Usuario> userRepository;

        public List<Usuario> GetAll()
        {
            return userRepository.GetAll();
        }
        public Usuario Get(int id)
        {
            return userRepository.Get(id)!;
        }
        public Usuario Create(Usuario usuario)
        {
            usuario.CreatedAt = DateTime.UtcNow;   
            usuario.UpdatedAt = DateTime.UtcNow;   

            userRepository.Create(usuario);

            return usuario;
        }
        public Usuario Update(Usuario usuario)
        {
            usuario.UpdatedAt = DateTime.UtcNow;

            userRepository.Update(usuario);

            return usuario;
        }
        public void Delete(int id)
        {
            userRepository.Delete(id);
        }

    }
}
