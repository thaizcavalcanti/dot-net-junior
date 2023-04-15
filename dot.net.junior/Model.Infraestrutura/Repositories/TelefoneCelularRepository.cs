using Model.Entidades.Entidades;
using Model.Infraestrutura.Interfaces;
using System.Data.Entity;

namespace Model.Infraestrutura.Repositories
{
    public class TelefoneCelularRepository : BaseRepository<TelefoneCelular>, ITelefoneCelularRepository
    {
        public TelefoneCelularRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
