using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Teste.Confitec.Domain.Helper
{
    public static class EmailHelper
    {
        public static bool Validar(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            if (!EmailEhValidoPorRegex(email))
                return false;

            if (EmailPossuiSequeciaDeCaracteresInvalidos(email))
                return false;

            return true;
        }

        private static bool EmailEhValidoPorRegex(string email)
        {
            const string expressao = @"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            var regex = new Regex(expressao, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        private static bool EmailPossuiSequeciaDeCaracteresInvalidos(string email)
        {
            var caracteresValidos = new[] { "@", "." };

            for (int i = 0; i < email.Length; i++)
            {
                var caracter = email.Substring(i, 1);
                if (!caracteresValidos.Contains(caracter))
                    continue;

                var proximoCaracter = email.Substring(i + 1, 1);
                if (caracteresValidos.Contains(proximoCaracter))
                    return true;
            }

            return false;
        }
    }
}
