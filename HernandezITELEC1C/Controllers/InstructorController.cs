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
               Id = 1, FirstName = "Don", LastName = "Monterp", IsTenured = "Yes",
                DateHired = DateTime.Now, Rank = Rank.Instructor
            },
            new Instructor()
            {
               Id = 2, FirstName = "Leomord", LastName = "Polska", IsTenured = "Yes",
                DateHired= DateTime.Now, Rank= Rank.AssistProf
            },
            new Instructor()
            {
               Id = 3, FirstName = "Zxy", LastName = "Qertw", IsTenured = "No",
                DateHired = DateTime.Now, Rank = Rank.AssociateProf
            },
            new Instructor()
            {
               Id = 4, FirstName = "Jor", LastName = "Noel", IsTenured = "No",
                DateHired = DateTime.Now, Rank = Rank.Prof
            }
        };


        public IActionResult Index()
        {
            return View(InstructorList);

            
        }
        public IActionResult ShowDetail(int id)
        {

            Instructor? instructor = InstructorList.FirstOrDefault(inst => inst.Id == id);
            if (instructor != null)
                return View(instructor);

            return NotFound();
        }
    }
}
