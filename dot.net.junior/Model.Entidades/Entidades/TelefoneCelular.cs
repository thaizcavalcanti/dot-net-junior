using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entidades.Entidades
{
    [Table("TelefoneCelular")]
    public class TelefoneCelular
    {
        public Guid IdTelefoneCelular { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public int TipoContato { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}
