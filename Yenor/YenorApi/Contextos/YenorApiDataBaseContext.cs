using Microsoft.EntityFrameworkCore;
using YenorApiModels;

namespace YenorApi.Contextos
{
    public class YenorApiDataBaseContext: DbContext
    {
        //construtor que vai receber os dados do program, no caso aqui a string de conexão com banco de dados
        public YenorApiDataBaseContext(DbContextOptions<YenorApiDataBaseContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
