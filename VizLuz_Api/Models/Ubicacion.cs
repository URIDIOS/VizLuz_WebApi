namespace VizLuz_Api.Models
{
	//empleados
	public class Ubicacion
	{
		public int ID_Ubicacion { get; set; }
		public string? NombreUbicacion { get; set; }


		public virtual ICollection<Controles> ControlesReferencia { set; get; }

	}
}

