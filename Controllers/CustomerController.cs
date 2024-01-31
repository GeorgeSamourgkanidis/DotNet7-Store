using Microsoft.AspNetCore.Mvc;
using ASP_DotNet7_products.Models;

namespace ASP_DotNet7_products.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly StoreContext _DBContext;

    public CustomerController(StoreContext dBContext)
    {
        this._DBContext = dBContext;
    }

    [HttpPost("create")]
    public IActionResult CreateCustomer([FromBody] Customer _customer)
    {
        //Find by name let's say it's unique
        var customer = this._DBContext.Customers.FirstOrDefault(p => p.Name == _customer.Name);
        if(customer != null) {
            // Already Exists
            return BadRequest("Customer already exists");
        }else {
            this._DBContext.Add(_customer);
            this._DBContext.SaveChanges();
             return Ok(true);
        }
    }

    [HttpPut("edit/{id}")]
    public IActionResult EditCustomer([FromBody] Customer _customer)
    {
        var customer = this._DBContext.Customers.FirstOrDefault(p => p.Id == _customer.Id);
        if(customer != null) {
            customer.Name = _customer.Name;
            customer.Email = _customer.Email;
            customer.Phone = _customer.Phone;
            this._DBContext.SaveChanges();
            return Ok(true);
        }else {
            // Doesn't Exists
            return NotFound();
        }
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var customer = this._DBContext.Customers.FirstOrDefault(p => p.Id == id);
        if(customer != null) {
            this._DBContext.Remove(customer);
            this._DBContext.SaveChanges();
            return Ok(true);
        }
        return Ok(false);
    }
}
