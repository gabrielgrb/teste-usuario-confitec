using System.Collections.Generic;

namespace Teste.Confitec.Domain.Confitec.Usuario.Dto
{
    public class BaseResponseDto
    {
        public List<string> ErrorMessages { get; set; }
        public object Modelo { get; set; }
    }
}
