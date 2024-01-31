using Microsoft.AspNetCore.Mvc;
using ASP_DotNet7_products.Models;

namespace ASP_DotNet7_products.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly StoreContext _DBContext;

    public ProductController(StoreContext dBContext)
    {
        this._DBContext = dBContext;
    }

    [HttpPost("create")]
    public IActionResult CreateProduct([FromBody] Product _product)
    {
        
        var product = this._DBContext.Products.FirstOrDefault(p => p.Id == _product.Id);
        if(product != null) {
            // Already Exists
            return BadRequest("Product already exists");
        }else {
            this._DBContext.Add(_product);
            this._DBContext.SaveChanges();
             return Ok(true);
        }
    }

    [HttpPut("edit/{id}")]
    public IActionResult EditProduct([FromBody] Product _product)
    {
        var product = this._DBContext.Products.FirstOrDefault(p => p.Id == _product.Id);
        if(product != null) {
            // Already Exists
            product.Name = _product.Name;
            product.Price = _product.Price;
            this._DBContext.SaveChanges();
            return Ok(true);
        }else {
            // Doesn't Exists
            return NotFound();
        }
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = this._DBContext.Products.FirstOrDefault(p => p.Id == id);
        if(product != null) {
            this._DBContext.Remove(product);
            return Ok(true);
        }
        return Ok(false);
    }
}
