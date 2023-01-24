using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dto;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{

    [ApiController]
	[Route("[controller]")]
	public class CadastroController : ControllerBase
	{
		private CadastroService _cadastroService;

		public CadastroController(CadastroService service)
		{
			this._cadastroService = service;
		}

		[HttpPost]
		public IActionResult CadastroUsuario(CreateUsuarioDto dto)
		{
			Result resultado = _cadastroService.CadastroUsuario(dto);
			if (resultado.IsFailed) return StatusCode(500);
			return Ok();
		}
	}
}
