using ApiProjetoFinal.Data;
using ApiProjetoFinal.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RestauranteApi.Controllers
{
    [Route("api/sales")]
    public class SellController : Controller
    {
        
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Sell>>> Get([FromServices] DataContext context)
        {
            var sales = await context.Sales.ToListAsync();
            return sales;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Sell>> Post(
            [FromServices] DataContext context,
            [FromBody] Sell model
        )
        {
            if (ModelState.IsValid)
            {
                context.Sales.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Stock>> Put(
            int id,
            [FromServices] DataContext context,
            [FromBody] Stock model
        )
        {

            var stockToUpdate = await context.Stocks
            .FirstOrDefaultAsync(x => x.Id == id);
            
            stockToUpdate.Quantity -= model.Quantity;
            await context.SaveChangesAsync();
            return stockToUpdate;
            
        }
    }
}