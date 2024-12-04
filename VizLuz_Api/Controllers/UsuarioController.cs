using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using VizLuz_Api.Context;
using VizLuz_Api.DTOS;
using VizLuz_Api.Service;

namespace VizLuz_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly UsuarioService _usuarioService;
		public UsuarioController(UsuarioService usuarioService)
		{
			_usuarioService = usuarioService;
		}
		[HttpGet]
		[Route("Lista")]
		public async Task<ActionResult<List<UsuarioDTO>>> Get()
		{
			return Ok(await _usuarioService.lista());
		}


	}
}
