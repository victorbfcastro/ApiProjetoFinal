using ApiProjetoFinal.Data;
using ApiProjetoFinal.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
 
namespace RestauranteApi.Controllers
{
    [Route("api/stocks")]
    public class EstoqueController : Controller
    {
 
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Stock>>> Get([FromServices] DataContext context)
        {
            var stocks = await context.Stocks.Include(x => x.Product.Category).ToListAsync();
            return stocks;
        }
 
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Stock>> Post(
            [FromServices] DataContext context,
            [FromBody] Stock model
        )
        {
            if (ModelState.IsValid)
            {
                context.Stocks.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
 
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Stock>> FindById(
            [FromServices] DataContext context,
            int id)
        {
            var product = await context.Stocks
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }
    }
}