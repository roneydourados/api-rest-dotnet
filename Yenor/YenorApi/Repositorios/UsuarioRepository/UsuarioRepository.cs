using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YenorApi.Contextos;
using YenorApiModels;

namespace YenorApi.Repositorios.UsuarioRepository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly YenorApiDataBaseContext _db;

        public UsuarioRepository(YenorApiDataBaseContext db)
        {
            _db = db;
        }

        public List<Usuario> GetUsuarios()
        {
            return _db.Usuarios.OrderBy(a => a.Id).ToList();
        }

        public Usuario Get(int id)
        {
            return _db.Usuarios.FirstOrDefault(a => a.Id == id)!;
        }

        public Usuario Create(Usuario usuario)
        {
            _db.Usuarios.Add(usuario);
            _db.SaveChanges();

            return usuario;
        }

        public void Delete(int id)
        {
            _db.Usuarios.Remove(Get(id));
            _db.SaveChanges();
        }


        public Usuario Update(Usuario usuario)
        {
            _db.Usuarios.Update(usuario);
            _db.SaveChanges();

            return usuario;
        }
    }
}
