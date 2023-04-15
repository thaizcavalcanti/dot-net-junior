using Model.Entidades.Entidades;
using Model.Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Model.Infraestrutura.Repositories
{
    /// <summary>
    /// Classe para implemetar os métodos de repositório de dados para Cliente
    /// </summary>
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DbContext dbContext) : base(dbContext)
        {
        }
        
        public virtual async Task<Cliente> GetById(Guid id)
        {
            return await _dbContext.Set<Cliente>()
                .Include(x => x.Endereco)
                .Include(x => x.TelefoneCelular)
                .FirstOrDefaultAsync(x => x.IdCliente == id);
        }

        public async Task<Cliente> GetByCPFCNPJ(string cpfcnpj)
        {
            return await Get(x => x.CPF == cpfcnpj || x.CNPJ == cpfcnpj).FirstOrDefaultAsync();
        }


        public override async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _dbContext.Set<Cliente>()
                .Include(x => x.Endereco)
                .Include(x => x.TelefoneCelular)
                .ToListAsync();
        }
    }
}
