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
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        [HttpGet]
        [Route("{id:int}")]
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

        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody]Category model)
            {
                if (ModelState.IsValid){
                    context.Categories.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
                else{
                    return BadRequest(ModelState);
                }
            }
    }
}
