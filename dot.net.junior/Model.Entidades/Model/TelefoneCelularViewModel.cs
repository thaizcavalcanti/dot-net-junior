using Model.Entidades.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Entidades.Model
{
    public class TelefoneCelularViewModel
    {
        public Guid IdTelefoneCelular { get; set; }

        [DisplayName("Tipo")]
        [Required(ErrorMessage = "Preenchimento do campo '{0}' obrigatório.")]
        public int TipoContato { get; set; }

        public string NumeroFixo { get; set; }

        public string NumeroCelular { get; set; }

        [DisplayName("Número")]
        public string NumeroFormatado
        {
            get
            {
                if (TipoContato == (int)TipoContatoEnum.Fixo)
                    return string.Format(@"{0:00 0000-0000}", double.Parse(NumeroFixo));
                else
                    return string.Format(@"{0:00 0 0000-0000}", double.Parse(NumeroCelular));
            }
        }
    }
}
    
