using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades.Entidades
{
    [Table("Cliente")]
    public class Cliente
    {
        public Guid IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public Guid? IdEndereco { get; set; }
        public Endereco Endereco { get; set; }
        public Guid? IdTelefoneCelular { get; set; }
        public TelefoneCelular TelefoneCelular { get; set; }
    }
}
