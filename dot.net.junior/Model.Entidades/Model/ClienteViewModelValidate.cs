using Model.Entidades.Util;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entidades.Model
{
    public class ClienteViewModelValidate : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cnpj = "";
            string cpf = "";

            if (validationContext.ObjectType.GetProperty("CPF").GetValue(validationContext.ObjectInstance) != null)
                cpf = validationContext.ObjectType.GetProperty("CPF").GetValue(validationContext.ObjectInstance).ToString();
            if (validationContext.ObjectType.GetProperty("CNPJ").GetValue(validationContext.ObjectInstance) != null)
                cnpj = validationContext.ObjectType.GetProperty("CNPJ").GetValue(validationContext.ObjectInstance).ToString();

            if (string.IsNullOrEmpty(cpf) && string.IsNullOrEmpty(cnpj))
                return new ValidationResult("CPF é de preenchimento obrigatório!");

            if (validationContext.DisplayName == "CPF" && !string.IsNullOrEmpty(cpf))
                if (!Validacoes.ValidarCPF(cpf))
                    return new ValidationResult("CPF inválido!");

            if (validationContext.DisplayName == "CNPJ" && !string.IsNullOrEmpty(cnpj))
                if (!Validacoes.ValidarCNPJ(cnpj))
                    return new ValidationResult("CNPJ inválido!");

            return ValidationResult.Success;
        }
    }
}