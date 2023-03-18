using YenorApiModels;

namespace YenorApi.Repositorios.UsuarioRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T Get(int id);
        T Create(T item);
        T Update(T item);
        void Delete(int id);
    }
}
