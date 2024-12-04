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
	public class UbicacionController : ControllerBase
	{
		private readonly UbicacionService _ubicacionService;
		public UbicacionController(UbicacionService ubicacionService)
		{
			_ubicacionService = ubicacionService;
		}
		[HttpGet]
		[Route("Lista")]
		public async Task<ActionResult<List<UbicacionDTO>>> Get()
		{
			return Ok(await _ubicacionService.lista());
		}


	}
}
