namespace Model.Entidades.Util
{
    public static class Validacoes
    {
        public static bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            {
                return false;
            }

            int[] digitos = new int[11];
            int primeiroDigitoVerificador, segundoDigitoVerificador;

            for (int i = 0; i < 11; i++)
            {
                if (!int.TryParse(cpf[i].ToString(), out digitos[i]))
                {
                    return false;
                }
            }

            primeiroDigitoVerificador = ((digitos[0] * 10) + (digitos[1] * 9) + (digitos[2] * 8) + (digitos[3] * 7) + (digitos[4] * 6) + (digitos[5] * 5) + (digitos[6] * 4) + (digitos[7] * 3) + (digitos[8] * 2)) % 11;
            if (primeiroDigitoVerificador < 2)
            {
                primeiroDigitoVerificador = 0;
            }
            else
            {
                primeiroDigitoVerificador = 11 - primeiroDigitoVerificador;
            }

            segundoDigitoVerificador = ((digitos[0] * 11) + (digitos[1] * 10) + (digitos[2] * 9) + (digitos[3] * 8) + (digitos[4] * 7) + (digitos[5] * 6) + (digitos[6] * 5) + (digitos[7] * 4) + (digitos[8] * 3) + (primeiroDigitoVerificador * 2)) % 11;
            if (segundoDigitoVerificador < 2)
            {
                segundoDigitoVerificador = 0;
            }
            else
            {
                segundoDigitoVerificador = 11 - segundoDigitoVerificador;
            }

            return digitos[9] == primeiroDigitoVerificador && digitos[10] == segundoDigitoVerificador;
        }

        public static bool ValidarCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
