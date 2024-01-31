using Microsoft.AspNetCore.Mvc;
using ASP_DotNet7_products.Models;

namespace ASP_DotNet7_products.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseController : ControllerBase
{
    private readonly StoreContext _DBContext;

    public PurchaseController(StoreContext dBContext)
    {
        this._DBContext = dBContext;
    }

    [HttpPost("create")]
    public IActionResult CreatePurchase([FromBody] List<Purchase> _purchases)
    {
        foreach (Purchase p in _purchases)
        {
            var purchase = this._DBContext.Purchases.FirstOrDefault(pTable => pTable.Id == p.Id);
            if (purchase != null)
            {
                // Already Exists
                return BadRequest("At least one purchase already exists");
            }
            else
            {
                this._DBContext.Purchases.Add(p);
            }

        }

        this._DBContext.SaveChanges();
        return Ok(true);
    }

}
