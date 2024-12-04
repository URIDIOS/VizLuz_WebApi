using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VizLuz_Api.Context;
using VizLuz_Api.DTOS;
using VizLuz_Api.Models;

namespace VizLuz_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ControlesController : ControllerBase
	{
		private readonly AppDbContext _context;
		public ControlesController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Route("listar")]
		public async Task<ActionResult<List<ControlesDTO>>>Get()
		{
			var listaDTO = new List<ControlesDTO>();
			var listaBD = await _context.Controless.Include(p => p.UbicacionReferencia).ToListAsync();

			foreach (var item in listaBD)
			{
				listaDTO.Add(new ControlesDTO
				{
					ID_Controles = item.ID_Controles,
					NombreControl = item.NombreControl,
					Estado = item.Estado,
					ID_Ubicacion = item.ID_Ubicacion,
					NombreUbicacion = item.UbicacionReferencia.NombreUbicacion

				});
			}
			return Ok(listaDTO);
		}
		[HttpGet]
		[Route("Buscar/{id}")]
		public async Task<ActionResult<ControlesDTO>>Get(int id)
		{
			var controlDTO = new ControlesDTO();
			var controlBD = await _context.Controless.Include(p => p.UbicacionReferencia)
				.Where(e => e.ID_Controles == id).FirstAsync();

			controlDTO.ID_Controles = id;
			controlDTO.NombreControl = controlBD.NombreControl;
			controlDTO.Estado = controlBD.Estado;
			controlDTO.ID_Ubicacion = controlBD.ID_Ubicacion;
			controlDTO.NombreUbicacion = controlBD.UbicacionReferencia.NombreUbicacion;
			return Ok(controlDTO);
		}
		[HttpPost]
		[Route("Guardar")]
		public async Task<ActionResult<ControlesDTO>>Guardar(ControlesDTO controlesDTO)
		{
			var controlBD = new Controles
			{
				NombreControl = controlesDTO.NombreControl,
				Estado = controlesDTO.Estado,
				ID_Ubicacion = controlesDTO.ID_Ubicacion,
			};
			await _context.Controless.AddAsync(controlBD);
			await _context.SaveChangesAsync();
			return Ok("Control Agregado");
		}
		[HttpPut]
		[Route("Editar")]
		public async Task<ActionResult<ControlesDTO>>Editar(ControlesDTO controlesDTO)
		{
			var controlBD = await _context.Controless.Include(p => p.UbicacionReferencia)
				.Where(e => e.ID_Controles == controlesDTO.ID_Controles).FirstAsync();

			controlBD.NombreControl = controlesDTO.NombreControl;
			controlBD.Estado = controlesDTO.Estado;
			controlBD.ID_Ubicacion = controlesDTO.ID_Ubicacion;

			_context.Controless.Update(controlBD);
			await _context.SaveChangesAsync();
			return Ok("Control Modificacado");
		}
		[HttpDelete]
		[Route("Eliminar/{id}")]
		public async Task<ActionResult<ControlesDTO>>Eliminar(int id)
		{
			var controlDB = await _context.Controless.FindAsync(id);


			if (controlDB is null) return NotFound("Control no encontrado");

			_context.Controless.Remove(controlDB);
			await _context.SaveChangesAsync();

			return Ok("Control Eliminado");
		}
	}
}
