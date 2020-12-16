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
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.Include(x => x.Category).ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id){
            var product = await context.Products.Include(x => x.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        [HttpGet]
        [Route("products/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] DataContext context, int id){
            var products = await context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .Where(x => x.Category.Id == id)
                .ToListAsync();
            return products;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Product>> Post(
            [FromServices] DataContext context,
            [FromBody]Product model)
            {
                if (ModelState.IsValid){
                    context.Products.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
                else{
                    return BadRequest(ModelState);
                }
            }
            [HttpPut]
            [Route("{id:int}")]
            public async Task<ActionResult<Product>> Update(
            int id, 
            [FromServices] DataContext context,
            [FromBody] Product model
            )
            {
            var productToUpdate = await context.Products
            .FirstOrDefaultAsync(x => x.Id == id);
            
            productToUpdate.Title = model.Title;
            productToUpdate.Price = model.Price;
            productToUpdate.CategoryId = model.Id;
            await context.SaveChangesAsync();
            return productToUpdate;
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<ActionResult<Product>> Delete(int id, 
            [FromServices] DataContext context,
            bool? saveChangesError = false)
            {

            var productToRemove = await context.Products.FirstOrDefaultAsync(a => a.Id == id);
            context.Remove(productToRemove);
            await context.SaveChangesAsync();
            return productToRemove;
            }

    }
}