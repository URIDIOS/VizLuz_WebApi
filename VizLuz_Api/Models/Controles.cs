namespace VizLuz_Api.Models
{
	//perfil
	public class Controles
	{
		public int ID_Controles { get; set; }
		public string? NombreControl { get; set; }
		public string? Estado { get; set; }
		public int ID_Ubicacion { get; set; }
		public virtual Ubicacion UbicacionReferencia { get; set; }
	}
}
