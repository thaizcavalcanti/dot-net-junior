using Model.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model.Infraestrutura.Interfaces
{
    /// <summary>
    /// Interface para operações de repositório de tarefa
    /// </summary>
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente> GetById(Guid id);
        Task<Cliente> GetByCPFCNPJ(string cpfcnpj);
        Task<IEnumerable<Cliente>> GetAll();
    }
}
