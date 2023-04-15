using AutoMapper;
using LogicaNegocio.Exceptions;
using LogicaNegocio.Interfaces;
using Model.Entidades.Entidades;
using Model.Infraestrutura.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicaNegocio.Servicos
{
    public class ClienteService : IClienteService
    {
        public readonly IClienteRepository _clienteRepository;
        public readonly IEnderecoRepository _enderecoRepository;
        public readonly ITelefoneCelularRepository _telefoeRepository;

        public ClienteService(IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository, ITelefoneCelularRepository telefoeRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _telefoeRepository = telefoeRepository;
        }

        public async Task<Cliente> GetById(Guid id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Save(Cliente obj)
        {
            var cpfcnpj = obj.CPF != null ? obj.CPF : obj.CNPJ;
            var retorno = await _clienteRepository.GetByCPFCNPJ(cpfcnpj);

            if (retorno != null)
                throw new BusinessException("Cliente já existente!");

            _clienteRepository.Add(obj);
            await _clienteRepository.SaveChanges();
        }

        public async Task Update(Cliente obj)
        {
            _clienteRepository.Update(obj);
            _enderecoRepository.Update(obj.Endereco);
            _telefoeRepository.Update(obj.TelefoneCelular);

            await _clienteRepository.SaveChanges();
            await _enderecoRepository.SaveChanges();
            await _telefoeRepository.SaveChanges();
        }

        public async Task Delete(Cliente obj)
        {
            _enderecoRepository.Delete(obj.IdEndereco);
            _telefoeRepository.Delete(obj.IdTelefoneCelular);
            _clienteRepository.Delete(obj.IdCliente);

            await _clienteRepository.SaveChanges();
            await _enderecoRepository.SaveChanges();
            await _telefoeRepository.SaveChanges();
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }
    }
}
