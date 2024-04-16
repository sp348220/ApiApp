using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudByApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudByApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public ValuesController(DocumentDbContext context) {
            Context = context;
        }

        public DocumentDbContext Context { get; }

        //[HttpGet("{Id}")]
        //public IActionResult GetEmp(int Id)
        //{
        //    var data = Context.AppUsers.Find(Id);                     //Alternate Way
        //    return Ok(data);
        //}
        //[HttpGet()
        //public IActionResult GetEmp(int Id)
        //{
        //    var data = Context.AppUsers;
        //    return Ok(data);
        //}
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartments()
        {
            var data = await Context.Departments.ToListAsync();
            return Ok(data);
        }
        //[HttpGet("{Id}")]
        //public async Task<ActionResult<List<Department>>> GetDepartmentsById(String Id)
        //{
        //    int x = Convert.ToInt32(Id);
        //    var data = await Context.Departments.FindAsync(x);
        //    if (data == null)
        //    {
        //        return NotFound();
        //    }
        //    else { return Ok(data); }

        //}
        [HttpPost]
        public ActionResult CreateDepartment(Department department)
        {
            Context.Departments.Add(department);
            Context.SaveChanges();
            return Ok(department);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<Department>>> UpdateDepartment(int Id, Department depart)
        {
            //depart.Id = Id;
            var data = await Context.Departments.FindAsync(Id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                Context.Entry(depart).State = EntityState.Modified;
                await Context.SaveChangesAsync();

            }
            return Ok(depart);

        }
        //[HttpPut]

        //   public async Task<ActionResult<List<AppUser>>> updateAppUser(AppUser appUser,int Id)
        //{ 
        //    var data= await Context.AppUsers.FindAsync(Id);
        //    Context.Entry(appUser).State = EntityState.Modified;    
        //    return Ok(data);    
        //}
        [HttpDelete("DeleteEmployeeMaster")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployeeMaster(int Id)
        {

           // int x = Convert.ToInt32(Id);
            var data = await Context.EmployeeMaster.FindAsync(Id);
            if(data== null)
            {
                return BadRequest();
            }
            Context.Remove(data);
            ; await Context.SaveChangesAsync();
            return Ok(data);
        }


    }


}
