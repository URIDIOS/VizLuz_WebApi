using Microsoft.EntityFrameworkCore;
using VizLuz_Api.Context;
using VizLuz_Api.DTOS;

namespace VizLuz_Api.Service
{
	public class UsuarioService
	{
		private readonly AppDbContext _context;
		public UsuarioService(AppDbContext context)
		{
			_context = context;
		}
		public async Task<List<UsuarioDTO>> lista()
		{
			var listaDTO = new List<UsuarioDTO>();

			foreach (var item in await _context.Usuarios.ToListAsync())
			{
				listaDTO.Add(new UsuarioDTO
				{
					ID_Usuario = item.ID_Usuario,
					Nombres = item.Nombres,

				});
			}

			return (listaDTO);
		}

		public static implicit operator UsuarioService(UbicacionService v)
		{
			throw new NotImplementedException();
		}
	}
}
