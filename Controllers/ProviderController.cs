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
    [Route("api/providers")]
    public class ProviderController : Controller
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Provider>>> Get([FromServices] DataContext context)
        {
            var providers = await context.Providers.ToListAsync();
            return providers;
        }
        
        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<Provider>> GetById([FromServices] DataContext context, int id){
            
            var provider = await context.Providers.FindAsync(id);
            if (provider == null){
                return NotFound();
            }
            
            return provider;
        }

        [HttpPost]
        [Route("")]
    
        public async Task<ActionResult<Provider>> Post(
            [FromServices] DataContext context,
            [FromBody]Provider provider)
            {
                if (ModelState.IsValid){
                    context.Providers.Add(provider);
                    await context.SaveChangesAsync();
                    return provider;
                }
                else{
                    return BadRequest(ModelState);
                }
            }

            [HttpPut]
            [Route("{id:int}")]
            public async Task<ActionResult<Provider>> Update(
            int id, 
            [FromServices] DataContext context,
            [FromBody] Provider model
            )
            {
            var providerToUpdate = await context.Providers
            .FirstOrDefaultAsync(x => x.Id == id);
            
            providerToUpdate.Title = model.Title;
            providerToUpdate.Email = model.Email;
            await context.SaveChangesAsync();
            return providerToUpdate;
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<ActionResult<Provider>> Delete(int id, 
            [FromServices] DataContext context,
            bool? saveChangesError = false)
            {

            var providerToRemove = await context.Providers
            .FirstOrDefaultAsync(a => a.Id == id);
            context.Remove(providerToRemove);
            await context.SaveChangesAsync();
            return providerToRemove;
            }
    }
}