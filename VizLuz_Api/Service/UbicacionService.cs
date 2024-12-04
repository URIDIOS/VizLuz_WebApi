using Microsoft.EntityFrameworkCore;
using VizLuz_Api.Context;
using VizLuz_Api.DTOS;

namespace VizLuz_Api.Service
{
	public class UbicacionService
	{
		private readonly AppDbContext _context;
		public UbicacionService(AppDbContext context)
		{
			_context = context;
		}
		public async Task<List<UbicacionDTO>> lista()
		{
			var listaDTO = new List<UbicacionDTO>();

			foreach (var item in await _context.Ubicaciones.ToListAsync())
			{
				listaDTO.Add(new UbicacionDTO
				{
					ID_Ubicacion = item.ID_Ubicacion,
					NombreUbicacion = item.NombreUbicacion,

				});
			}

			return (listaDTO);
		}
	}
}
