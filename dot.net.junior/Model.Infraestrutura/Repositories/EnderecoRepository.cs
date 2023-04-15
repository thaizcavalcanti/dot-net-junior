using Model.Entidades.Entidades;
using Model.Infraestrutura.Interfaces;
using System.Data.Entity;

namespace Model.Infraestrutura.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
