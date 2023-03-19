using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace N7CodeFirst.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public TeachersController(SchoolDbContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //[Route("teachers")]


        // I wrote this method without giving it an argument,
        // because I only want taechers List that teaches Giorgi.
        // In swagger when you execute code it shows all the teachers who teach Giorgi ,
        // without giving it an argument


        //public ActionResult<Teacher[]> GetAllTeachersByStudent() 
        //{
        //    var teachers = _context.Teachers
        //        .Where(t => t.TeacherPupils.Any(tp => tp.Pupil.FirstName == "Giorgi"))
        //        .ToArray();

        //    if (teachers.Length == 0)
        //    {
        //        return NotFound();
        //    }

        //    return teachers;
        //}


        //we are given the method that takes an argument, so this is the second code i provided 


        [HttpGet("{studentName}")]
        public Teacher[] GetAllTeachersByStudent(string studentName)
        {
            if (studentName != "Giorgi")
            {
                return new Teacher[0];
            }

            var giorgiTeachers = _context.Teachers
                .Where(t => t.TeacherPupils.All(tp => tp.Pupil.FirstName == studentName))
                .OrderBy(t => t.LastName)
                .ToArray();

            return giorgiTeachers;
        }

    }
}