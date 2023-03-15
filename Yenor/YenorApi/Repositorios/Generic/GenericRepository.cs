using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YenorApi.Contextos;
using YenorApi.Repositorios.UsuarioRepository;
using YenorApiModels;

namespace YenorApi.Repositorios.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly YenorApiDataBaseContext _db;

        //dataset genérico para pegar o tipo dinamicamente
        private DbSet<T> dataset;

        public GenericRepository(YenorApiDataBaseContext db)
        {
            _db = db;

            //passar contexto do banco para dataset genérico
            dataset = _db.Set<T>();
        }

        public T Get(int id)
        {
            return dataset.FirstOrDefault(a => a.Id == id)!;
        }
        public List<T> GetAll()
        {
            return dataset.OrderBy(a => a.Id).ToList();
        }
        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _db.SaveChanges();

                return item;
            }catch (Exception) 
            {
                throw;
            }
        }
        public T Update(T item)
        {
            var itemExists = dataset.FirstOrDefault(p => p.Id == item.Id);

            if (itemExists != null)
            {
                try
                {
                    dataset.Update(item);
                    _db.SaveChanges();

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
            var item = dataset.FirstOrDefault(p => p.Id == id);

            if (item != null)
            {
                try
                {
                    dataset.Remove(item);
                    _db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }

}
