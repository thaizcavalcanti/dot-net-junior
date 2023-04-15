using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Entidades.Model
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            Endereco = new EnderecoViewModel();
            TelefoneCelular = new TelefoneCelularViewModel();
            TelefoneCelular.TipoContato = 1;
        }

        public Guid? IdCliente { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Preenchimento do campo 'Nome do cliente' obrigatório.")]
        public string NomeCliente { get; set; }

        public string CPFSemMascara
        {
            get
            {
                if (CPF != null)
                    return CPF.Replace(".", "").Replace("-", "");
                else
                    return null;
            }
            set { }
        }
        public string CPFComMascara
        {
            get
            {
                if (CPF != null)
                    return string.Format(@"{0:000\.000\.000\-00}", double.Parse(CPF));
                else return "";
            }
        }
        [ClienteViewModelValidate]
        public string CPF { get; set; }

        [ClienteViewModelValidate]
        public string CNPJ { get; set; }

        public string CNPJSemMascara
        {
            get
            {
                if (CNPJ != null)
                    return CNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
                else
                    return null;
            }
        }
        public string CNPJComMascara
        {
            get
            {
                if (CNPJ != null)
                    return string.Format(@"{0:00\.000\.000\/0000\-00}", double.Parse(CNPJ));
                else return "";
            }
        }

        public Guid? IdEndereco { get; set; }
        public EnderecoViewModel Endereco { get; set; }

        public Guid? IdTelefoneCelular { get; set; }
        public TelefoneCelularViewModel TelefoneCelular { get; set; }

        [DisplayName("Tipo")]
        public bool TipoPessoaFisica
        {
            get { return !string.IsNullOrEmpty(CPF); }
        }

        public string Mensagem;
    }
}