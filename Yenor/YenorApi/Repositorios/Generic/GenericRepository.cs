using Microsoft.EntityFrameworkCore;
using YenorApi.Contextos;
using YenorApi.Repositorios.UsuarioRepository;
using YenorApiModels;

namespace YenorApi.Repositorios.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly YenorApiDataBaseContext DbContext;

        //dataset genérico para pegar o tipo dinamicamente
        private readonly DbSet<T> DataSet;

        public GenericRepository(YenorApiDataBaseContext db)
        {
            DbContext = db;

            //passar contexto do banco para dataset genérico
            DataSet = DbContext.Set<T>();
        }

        public T Get(int id)
        {
            return DataSet.FirstOrDefault(a => a.Id == id)!;
        }
        public List<T> GetAll()
        {
            return DataSet.OrderBy(a => a.Id).ToList();
        }
        public T Create(T item)
        {
            try
            {
                DataSet.Add(item);
                DbContext.SaveChanges();

                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public T Update(T item)
        {
            var itemExists = DataSet.FirstOrDefault(p => p.Id == item.Id);

            if (itemExists != null)
            {
                try
                {  /* aqui é para limpar a instância que fica do exists 
                    * se não colocar isso, ele da erro de duplicidade de instancias
                    * do mesmo objeto que está sendo passdo
                    */
                    DbContext.Entry(itemExists).State = EntityState.Detached;

                    DataSet.Update(item);
                    DbContext.SaveChanges();

                    return item;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }

        }
        public void Delete(int id)
        {
            var item = DataSet.FirstOrDefault(p => p.Id == id);

            if (item != null)
            {
                try
                {
                    DataSet.Remove(item);
                    DbContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }

}
