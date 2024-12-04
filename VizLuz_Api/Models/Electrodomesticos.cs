namespace VizLuz_Api.Models
{
	public class Electrodomesticos
	{
		public int ID_Electrodomestico { get; set; }
		public string? NombreElectrodomestico { get; set; }
		public string? Estado { get; set; }
		public int ID_Usuario { get; set; }

		public virtual Usuario UsuarioReferencia { set; get; }
	}
}
