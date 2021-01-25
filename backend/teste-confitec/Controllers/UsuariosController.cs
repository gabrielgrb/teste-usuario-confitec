using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teste.Confitec.Domain.Confitec.Usuario;
using Teste.Confitec.Domain.Confitec.Usuario.Dto;
using Teste.Confitec.Domain.Confitec.Usuario.Interfaces;

namespace Teste.Confitec.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IArmazenadorDeUsuario _armazenadorDeUsuario;
        private readonly IExclusorDeUsuario _exclusorDeUsuario;
        public UsuariosController(
            IUsuarioService usuarioService, 
            IArmazenadorDeUsuario armazenadorDeUsuario,
            IExclusorDeUsuario exclusorDeUsuario)
        {
            _usuarioService = usuarioService;
            _armazenadorDeUsuario = armazenadorDeUsuario;
            _exclusorDeUsuario = exclusorDeUsuario;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<List<UsuariosParaExibicaoDto>> Get()
        {
            var usuarios = await _usuarioService.ListarAsync();
            return usuarios;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<UsuarioDto>> Get(int id)
        {
            var usuario = await _usuarioService.GetById(id);
            return usuario;
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] UsuarioDto usuario)
        {
            if (ModelState.IsValid)
            {
                var responseDto = await _armazenadorDeUsuario.Armazenar(usuario);

                if (responseDto.ErrorMessages?.Count() == 0)
                    return Ok(responseDto);

                return BadRequest(responseDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var responseDto = await _exclusorDeUsuario.ExcluirAsync(id);

            if (responseDto.ErrorMessages?.Count() == 0)
                return Ok(responseDto);

            return BadRequest(responseDto);
        }
    }
}
