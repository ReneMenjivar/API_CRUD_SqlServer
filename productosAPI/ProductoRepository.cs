
using productosAPI.Data;
using productosAPI.Models;
using productosAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;


namespace productosAPI.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AplicacionDBContext _context;

        public ProductoRepository(AplicacionDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<productos>> GetProductos() => await _context.Productos.ToListAsync();

        public async Task<productos> GetProducto(int id) => await _context.Productos.FindAsync(id);

        public async Task<productos> AddProducto(productos producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto> UpdateProducto(int id, Producto producto)
        {
            var existing = await _context.Productos.FindAsync(id);
            if (existing == null) return null;

            existing.Nombre = producto.Nombre;
            existing.Precio = producto.Precio;
            existing.Stock = producto.Stock;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}