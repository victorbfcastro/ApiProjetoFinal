using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProjetoFinal.Data;
using ApiProjetoFinal.Models;
using System.Linq;


namespace ApiProjetoFinal.Controllers
{
    [ApiController]
    [Route("api/purchases")]

    public class ShopController : Controller
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Stock>> Post(
            [FromServices] DataContext context,
            [FromBody]Stock model)
            {
                if (ModelState.IsValid){
                    context.Stocks.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
                else{
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
            
            stockToUpdate.Quantity += model.Quantity;
            await context.SaveChangesAsync();
            return stockToUpdate;
        }
    }
}