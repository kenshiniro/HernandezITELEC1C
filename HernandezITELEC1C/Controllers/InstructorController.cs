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
               Id = 1, FirstName = "Krap", LastName = "Doroteo", IsTenured= IsTenured.Yes,
                DateHired = DateTime.Now, Rank = Rank.Instructor
            },
            new Instructor()
            {
               Id = 2, FirstName = "Leomord", LastName = "Polska", IsTenured= IsTenured.Yes,
                DateHired= DateTime.Now, Rank= Rank.AssistProf
            },
            new Instructor()
            {
               Id = 3, FirstName = "Yamato", LastName = "Kaido", IsTenured= IsTenured.No,
                DateHired = DateTime.Now, Rank = Rank.AssociateProf
            },
            new Instructor()
            {
               Id = 4, FirstName = "Jor", LastName = "Noel" ,IsTenured= IsTenured.No,
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

        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }
        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {

            Instructor? instructor = InstructorList.FirstOrDefault(inst => inst.Id == id);

            if (instructor != null)//was an instructor found?
                return View(instructor);

            return NotFound();


        }
        [HttpPost]


        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(inst => inst.Id == instructorChanges.Id);
            if (instructor != null)
            {
                instructor.FirstName = instructorChanges.FirstName;
                instructor.LastName = instructorChanges.LastName;
                instructor.DateHired = instructorChanges.DateHired;
                instructor.IsTenured = instructorChanges.IsTenured;
                instructor.Rank = instructorChanges.Rank;
            }
            return View("Index", InstructorList);
        }


    }
}
