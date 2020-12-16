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
    [Route("api/clients")]
    public class ClientController : Controller
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Client>>> Get([FromServices] DataContext context)
        {
            var products = await context.Clients.ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<Client>> FindById([FromServices] DataContext context, int id){
            var client = await context.Clients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return client;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Client>> Post(
            [FromServices] DataContext context,
            [FromBody] Client model
        )
        {
            if (ModelState.IsValid)
            {
                context.Clients.Add(model);
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
            public async Task<ActionResult<Client>> Update(
            int id, 
            [FromServices] DataContext context,
            [FromBody] Client model
            )
            {
            var clientToUpdate = await context.Clients
            .FirstOrDefaultAsync(x => x.Id == id);
            
            clientToUpdate.Title = model.Title;

            await context.SaveChangesAsync();
            return clientToUpdate;
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<ActionResult<Client>> Delete(int id, 
            [FromServices] DataContext context,
            bool? saveChangesError = false)
            {

            var clientToRemove = await context.Clients.FirstOrDefaultAsync(a => a.Id == id);
            context.Remove(clientToRemove);
            await context.SaveChangesAsync();
            return clientToRemove;
            }
    }
}