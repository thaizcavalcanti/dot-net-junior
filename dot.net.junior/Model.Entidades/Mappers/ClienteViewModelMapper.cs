using Model.Entidades.Entidades;
using Model.Entidades.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Entidades.Mappers
{
    public static class ClienteViewModelMapper
    {
        public static ClienteViewModel MapEntityToModel(Cliente cliente)
        {
            return new ClienteViewModel
            {
                IdCliente = cliente.IdCliente,
                NomeCliente = cliente.NomeCliente,
                CPF = cliente.CPF,
                CNPJ = cliente.CNPJ,
                IdEndereco = cliente.Endereco.IdEndereco,
                IdTelefoneCelular = cliente.TelefoneCelular.IdTelefoneCelular,
                Endereco = new EnderecoViewModel
                {
                    IdEndereco = cliente.Endereco.IdEndereco,
                    Cep = cliente.Endereco.Cep,
                    Cidade = cliente.Endereco.Cidade,
                    Rua = cliente.Endereco.Rua,
                    Numero = cliente.Endereco.Numero,
                    Bairro = cliente.Endereco.Bairro,
                    TipoEndereco = cliente.Endereco.TipoEndereco,
                },
                TelefoneCelular = new TelefoneCelularViewModel
                {
                    IdTelefoneCelular = cliente.TelefoneCelular.IdTelefoneCelular,
                    NumeroCelular = cliente.TelefoneCelular.DDD + cliente.TelefoneCelular.Numero,
                    NumeroFixo = cliente.TelefoneCelular.DDD + cliente.TelefoneCelular.Numero,
                    TipoContato = cliente.TelefoneCelular.TipoContato,
                }
            };
        }

        public static Cliente MapModelToEntity(ClienteViewModel model)
        {
            var numero = model.TelefoneCelular.TipoContato == 1 ? model.TelefoneCelular.NumeroFixo : model.TelefoneCelular.NumeroCelular;

            return new Cliente
            {
                IdCliente = model.IdCliente.HasValue ? model.IdCliente.Value : Guid.NewGuid(),
                IdEndereco = model.IdEndereco.HasValue ? model.IdEndereco.Value : Guid.NewGuid(),
                IdTelefoneCelular = model.IdTelefoneCelular.HasValue ? model.IdTelefoneCelular.Value : Guid.NewGuid(),
                NomeCliente = model.NomeCliente,
                CPF = model.CPFSemMascara,
                CNPJ = model.CNPJSemMascara,
                Endereco = new Endereco
                {
                    IdEndereco = model.IdEndereco.HasValue ? model.IdEndereco.Value : Guid.NewGuid(),
                    Cep = model.Endereco.Cep.Replace(".", "").Replace("-", ""),
                    Cidade = model.Endereco.Cidade,
                    Rua = model.Endereco.Rua,
                    Numero = model.Endereco.Numero,
                    Bairro = model.Endereco.Bairro,
                    TipoEndereco = model.Endereco.TipoEndereco,
                },
                TelefoneCelular = new TelefoneCelular
                {
                    IdTelefoneCelular = model.IdTelefoneCelular.HasValue ? model.IdTelefoneCelular.Value : Guid.NewGuid(),
                    DDD = numero.Substring(0, 2),
                    Numero = numero.Substring(2, numero.Length - 2).Replace(" ", "").Replace("-", ""),
                    TipoContato = model.TelefoneCelular.TipoContato,
                }
            };
        }

        public static List<ClienteViewModel> MapEntityToModelList(List<Cliente> clientes)
        {
            return clientes.Select(x => new ClienteViewModel
            {
                IdCliente = x.IdCliente,
                NomeCliente = x.NomeCliente,
                CPF = x.CPF,
                CNPJ = x.CNPJ
            }).ToList();
        }
    }
}
