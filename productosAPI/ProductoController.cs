using Microsoft.AspNetCore.Mvc;
using productosAPI.Models;

[Route("api/productos")]
[ApiController]
public class ProductoController : ControllerBase
{
    private readonly IProductoRepository _repository;

    public ProductoController(IProductoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<productos>>> GetProductos()
    {
        return Ok(await _repository.GetProductos());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<productos>> GetProducto(int id)
    {
        var producto = await _repository.GetProducto(id);
        if (producto == null) return NotFound();
        return Ok(producto);
    }

    [HttpPost]
    public async Task<ActionResult<productos>> AddProducto([FromBody] productos producto)
    {
        var newProducto = await _repository.AddProducto(producto);
        return CreatedAtAction(nameof(GetProducto), new { id = newProducto.Id }, newProducto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProducto(int id, [FromBody] productos producto)
    {
        var updated = await _repository.UpdateProducto(id, producto);
        if (updated == null) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        var deleted = await _repository.DeleteProducto(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
