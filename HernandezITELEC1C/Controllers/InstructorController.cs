using Microsoft.AspNetCore.Mvc;
using HernandezITELEC1C.Models;

namespace HernandezITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>()
        {
            new Instructor()
            {
              Id= 2, FirstName = "Jobre", LastName="Barrack" , DateHired = DateTime.Now, InstructorEmail="jobre@gmail.com", Rank= Rank.Instructor, IsTenured="Yes"

            },


            new Instructor()
            {
              Id= 3, FirstName = "Dean", LastName="Poscka" , DateHired = DateTime.Parse("25/04/2020"), InstructorEmail="leao@gmail.com", Rank= Rank.AssistProf, IsTenured="No"
            },

            new Instructor()
            {
              Id= 4, FirstName = "Joe", LastName="Over" , DateHired = DateTime.Parse("16/06/2020"), InstructorEmail="latkw@gmail.com", Rank= Rank.Prof, IsTenured="Yes"
            },


        };


        public IActionResult Index()
        {
            return View(InstructorList);

            
        }
        public IActionResult ShowDetails(int id)
        {

            Instructor? instructor = InstructorList.FirstOrDefault(inst => inst.Id == id);
            if (instructor != null)
                return View(instructor);

            return NotFound();
        }
    }
}
