using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Entidades.Model
{
    public class EnderecoViewModel
    {
        public Guid IdEndereco { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "Preenchimento do campo 'Número' obrigatório.")]
        public string Numero { get; set; }

        [DisplayName("Rua")]
        [Required(ErrorMessage = "Preenchimento do campo '{0}' obrigatório.")]
        public string Rua { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "Preenchimento do campo 'CEP' obrigatório.")]
        public string Cep { get; set; }

        [DisplayName("Bairro")]
        [Required(ErrorMessage = "Preenchimento do campo '{0}' obrigatório.")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Preenchimento do campo '{0}' obrigatório.")]
        public string Cidade { get; set; }

        [DisplayName("Tipo")]
        [Required(ErrorMessage = "Preenchimento do campo {0} obrigatório.")]
        public int TipoEndereco { get; set; }

    }
}