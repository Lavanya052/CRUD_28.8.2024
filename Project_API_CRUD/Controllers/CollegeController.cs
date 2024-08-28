using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_API_CRUD.Models;

namespace api_CRUD.Controllers
{
    [Route("api/[controller]")]  //controller is College
    [ApiController]
    //It automatically handles model binding, validation, and response formatting, making it easier to build RESTful APIs.
    public class CollegeController : ControllerBase
    {
        //interact with the underlying database within the class

        private readonly CollegeDbContext _context; //variable to hold data from COllegeDbContext

        //readonly means value assign only once in constructor

        public CollegeController(CollegeDbContext context)  //constructor
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Students>> Get()  //get all value from table
        {
            // asyn prg give await keyword ,IEnumerable ->return seq of ele
            return await _context.Student.ToListAsync();  //await allow other program to run
        }

        [HttpPost]
        public async Task<IActionResult> Post(Students studentData)   // create new row in table
        {
            _context.Add(studentData);
            await _context.SaveChangesAsync();
            return Ok("Successfully added");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Students studentData)   //modify existing table content
        {

            var student = await _context.Student.FindAsync(studentData.Id);
            if (student == null)
                return NotFound();
            student.Id = studentData.Id;
            student.Name = studentData.Name;
            student.Gender = studentData.Gender;
            student.MarkPer = studentData.MarkPer;
            await _context.SaveChangesAsync();
            return Ok("successfully updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)  // delete content
        {
            if (id < 1)
                return BadRequest();
            var student = await _context.Student.FindAsync(id);
            if (student == null)
                return NotFound();
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return Ok("Successfully deleted");
        }

    }
}
