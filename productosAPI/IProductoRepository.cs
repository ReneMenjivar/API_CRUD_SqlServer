using System;
using productosAPI;
using System.Collections.Generic;
using System.Threading.Tasks;
using productosAPI.Models;

namespace productosAPI.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<productos>> GetAllProductoAsync();
		Task<productos> GetProductoAsync(int id);
		Task AddProductoAsync(productos Productos);
		Task DeleteProductoAsync(int id);
		Task UpdateProductoAsync(productos Productos);
	}
}