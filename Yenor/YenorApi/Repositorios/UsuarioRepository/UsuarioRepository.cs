using YenorApi.Contextos;
using YenorApiModels;

namespace YenorApi.Repositorios.UsuarioRepository
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private readonly IRepository<Usuario> _db;

        public List<Usuario> GetAll()
        {
            return _db.GetAll();
        }

        public Usuario Get(int id)
        {
            return _db.Get(id)!;
        }

        public Usuario Create(Usuario usuario)
        {
            usuario.CreatedAt = DateTime.UtcNow;   
            usuario.UpdatedAt = DateTime.UtcNow;   

            _db.Create(usuario);

            return usuario;
        }

        public void Delete(int id)
        {
            _db.Delete(id);
        }


        public Usuario Update(Usuario usuario)
        {
            usuario.UpdatedAt = DateTime.UtcNow;
            _db.Update(usuario);

            return usuario;
        }
    }
}
