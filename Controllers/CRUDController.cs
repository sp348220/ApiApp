using CrudByApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudByApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        public CRUDController(DocumentDbContext context)
        {
            Context = context;
        }

        public DocumentDbContext Context { get; }

        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployeeMaster(int Id)
        {

            // int x = Convert.ToInt32(Id);
            var data = await Context.EmployeeMaster.FindAsync(Id);
            if (data == null)
            {
                return BadRequest();
            }
            Context.Remove(data);
            ; await Context.SaveChangesAsync();
            return Ok(data);
        }
    }
}
