using System;

namespace productosAPI.Models
{

	public class productos
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public decimal Precio { get; set; }
		public int Stock { get; set; }
	}
}