using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entidades.Entidades
{
    [Table("Endereco")]
    public class Endereco
    {
        public Guid IdEndereco { get; set; }
        public string Numero { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int TipoEndereco { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}
