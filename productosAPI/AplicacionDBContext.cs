using System;
using Microsoft.EntityFrameworkCore;
using productosAPI;
using productosAPI.Models;

namespace productosAPI.Data
{

	public class AplicacionDBContext : DbContext
	{
		public AplicacionDBContext(DbContextOptions<AplicacionDBContext> options) : base (options) { }
		public DbSet<productos> Productos { get; set; }
	}
}