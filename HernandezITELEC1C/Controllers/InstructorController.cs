﻿using Microsoft.AspNetCore.Mvc;
using HernandezITELEC1C.Models;
using HernandezITELEC1C.Data;

namespace HernandezITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        /* List<Instructor> InstructorList = new List<Instructor>()
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
         }; */

        private readonly AppDbContext _dbData;

        public InstructorController (AppDbContext dbData)
        {
            _dbData = dbData;

        }
        public IActionResult Index()
        {
            return View(_dbData.Instructors);

            
        }
        public IActionResult ShowDetail(int id)
        {

            Instructor? instructor = _dbData.Instructors.FirstOrDefault(inst => inst.Id == id);
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
            if (!ModelState.IsValid)
                return View();
            _dbData.Instructors.Add(newInstructor);
            _dbData.SaveChanges();

            return View("Index", _dbData.Instructors);
        }
        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {

            Instructor? instructor = _dbData.Instructors.FirstOrDefault(inst => inst.Id == id);

            if (instructor != null)//was an instructor found?
                return View(instructor);

            return NotFound();


        }
        [HttpPost]


        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(inst => inst.Id == instructorChanges.Id);
            if (instructor != null)
            {
                instructor.FirstName = instructorChanges.FirstName;
                instructor.LastName = instructorChanges.LastName;
                instructor.DateHired = instructorChanges.DateHired;
                instructor.IsTenured = instructorChanges.IsTenured;
                instructor.Rank = instructorChanges.Rank;
                _dbData.SaveChanges();

            }
            return View("Index", _dbData.Instructors);
        }


        public IActionResult DeleteInstructor(int id)
        {

            Instructor? instructor = _dbData.Instructors.FirstOrDefault(inst => inst.Id == id);

            if (instructor != null)//was an instructor found?
                return View(instructor);

            return NotFound();


        }
        [HttpPost]
        public IActionResult DeleteInstructor(Instructor newInstructor)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(inst => inst.Id == newInstructor.Id);
            if (instructor != null)
            {
                _dbData.Instructors.Remove(instructor);
                _dbData.SaveChanges();

            }
            return View("Index", _dbData.Instructors);
        }

    }
}
