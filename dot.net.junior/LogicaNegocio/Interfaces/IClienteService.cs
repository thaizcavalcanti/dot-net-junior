using Model.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicaNegocio.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> GetById(Guid id);
        Task Save(Cliente obj);
        Task Update(Cliente obj);
        Task Delete(Cliente obj);
        Task<IEnumerable<Cliente>> GetAll();
    }
}
