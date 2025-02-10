using productosAPI.Models;

public interface IProductoRepository
{
    Task<IEnumerable<productos>> GetProductos();
    Task<productos> GetProducto(int id);
    Task<productos> AddProducto(productos producto);
    Task<productos> UpdateProducto(int id, productos producto);
    Task<bool> DeleteProducto(int id);
}
