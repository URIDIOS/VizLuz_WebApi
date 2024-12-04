namespace VizLuz_Api.Models
{
	public class Usuario
	{
		public int ID_Usuario { get; set; }
		public string? Nombres { get; set; }	

		//Relacion con Electrodomesticos
		public virtual ICollection<Electrodomesticos> ElectrodomesticosReferencia { set; get; }
	}
}
