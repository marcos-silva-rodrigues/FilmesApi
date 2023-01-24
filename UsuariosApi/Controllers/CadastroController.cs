using Microsoft.AspNetCore.Mvc;

namespace UsuariosApi.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class CadastroController : ControllerBase
	{

		[HttpPost]
		public IActionResult CadastroUsuario(CreateUsuarioDto dto)
		{
			return Ok();
		}
	}
}
