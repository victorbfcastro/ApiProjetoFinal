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
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Employee>>> Get([FromServices] DataContext context)
        {
            var products = await context.Employees.ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<ActionResult<Employee>> FindById([FromServices] DataContext context, int id){
            var employee = await context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return employee;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Employee>> Post(
            [FromServices] DataContext context,
            [FromBody] Employee model
        )
        {
            if (ModelState.IsValid && model.Occupation == "Cozinheiro" || 
                model.Occupation == "Chapeiro" || 
                model.Occupation == "Garçom" || 
                model.Occupation == "Entregador")
            {
                context.Employees.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest("Funcionário inválido! Utilize: Cozinheiro, Chapeiro, Garçom ou Entregador");
            }
        }

            [HttpPut]
            [Route("{id:int}")]
            public async Task<ActionResult<Employee>> Update(
            int id, 
            [FromServices] DataContext context,
            [FromBody] Employee model
            )
            {
            var employeeToUpdate = await context.Employees
            .FirstOrDefaultAsync(x => x.Id == id);
            
            employeeToUpdate.Title = model.Title;
            employeeToUpdate.Occupation = model.Occupation;
            employeeToUpdate.Salary = model.Salary;
            await context.SaveChangesAsync();
            return employeeToUpdate;
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<ActionResult<Employee>> Delete(int id, 
            [FromServices] DataContext context,
            bool? saveChangesError = false)
            {

            var employeeToRemove = await context.Employees.FirstOrDefaultAsync(a => a.Id == id);
            context.Remove(employeeToRemove);
            await context.SaveChangesAsync();
            return employeeToRemove;
            }
    }
}