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
	public class ElectrodomesticosController : ControllerBase
	{
		private readonly AppDbContext _context;
		public ElectrodomesticosController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Route("listar")]
		public async Task<ActionResult<List<ElectrodomesticosDTO>>>Get()
		{
			var listaDTO = new List<ElectrodomesticosDTO>();
			var listaBD = await _context.Electrodomesticos.Include(p => p.UsuarioReferencia).ToListAsync();

			foreach(var item in listaBD)
			{
				listaDTO.Add(new ElectrodomesticosDTO
				{
					ID_Electrodomestico = item.ID_Electrodomestico,
					NombreElectrodomestico = item.NombreElectrodomestico,
					Estado = item.Estado,
					ID_Usuario = item.ID_Usuario,
					Nombres = item.UsuarioReferencia.Nombres

				});
			}
			return Ok(listaDTO);
		}
		[HttpGet]
		[Route("Buscar/{id}")]
		public async Task<ActionResult<ElectrodomesticosDTO>>Get(int id)
		{
			var electrodomesticoDTO = new ElectrodomesticosDTO();
			var electrodomesticoDB = await _context.Electrodomesticos.Include(p => p.UsuarioReferencia)
				.Where(e => e.ID_Electrodomestico == id).FirstAsync();

			electrodomesticoDTO.ID_Electrodomestico = id;
			electrodomesticoDTO.NombreElectrodomestico = electrodomesticoDB.NombreElectrodomestico;
			electrodomesticoDTO.Estado = electrodomesticoDB.Estado;
			electrodomesticoDTO.ID_Usuario = electrodomesticoDB.ID_Usuario;
			electrodomesticoDTO.Nombres = electrodomesticoDB.UsuarioReferencia.Nombres;
			return Ok(electrodomesticoDTO);
		}
		[HttpPost]
		[Route("Guardar")]
		public async Task<ActionResult<ElectrodomesticosDTO>>Guardar(ElectrodomesticosDTO electrodomesticosDTO)
		{
			var electrodomesticoDB = new Electrodomesticos
			{
				NombreElectrodomestico = electrodomesticosDTO.NombreElectrodomestico,
				Estado = electrodomesticosDTO.Estado,
				ID_Usuario = electrodomesticosDTO.ID_Usuario,
			};
			await _context.Electrodomesticos.AddAsync(electrodomesticoDB);
			await _context.SaveChangesAsync();
			return Ok("Electrodomestico agregado");
		}
		[HttpPut]
		[Route("Editar")]	
		public async Task<ActionResult<ElectrodomesticosDTO>>Editar(ElectrodomesticosDTO electrodomesticosDTO)
		{
			var electrodomesticoDB = await _context.Electrodomesticos.Include(p => p.UsuarioReferencia)
				.Where(e => e.ID_Electrodomestico == electrodomesticosDTO.ID_Electrodomestico).FirstAsync();

			electrodomesticoDB.NombreElectrodomestico = electrodomesticosDTO.NombreElectrodomestico;
			electrodomesticoDB.Estado = electrodomesticosDTO.Estado;
			electrodomesticoDB.ID_Usuario = electrodomesticosDTO.ID_Usuario;

			_context.Electrodomesticos.Update(electrodomesticoDB);
			await _context.SaveChangesAsync();
			return Ok("Electrodomestico Modificado");
		}
		[HttpDelete]
		[Route("Eliminar/{id}")]
		public async Task<ActionResult<ElectrodomesticosDTO>>Eliminar(int id)
		{
			var electrodomesticosDB = await _context.Electrodomesticos.FindAsync(id);
			

			if(electrodomesticosDB is null) return NotFound("Electrodomestico no encontrado");

			_context.Electrodomesticos.Remove(electrodomesticosDB);
			await _context.SaveChangesAsync();

			return Ok("Electronico Eliminado");
		}
	}
}
