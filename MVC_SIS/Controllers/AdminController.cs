using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            MajorRepository.Add(major.MajorName);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            if (ModelState.IsValid)
            {
                MajorRepository.Edit(major);
                return RedirectToAction("Majors"); 
            }
            else
            {
                return View(major);
            }
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model);
        }
        public ActionResult AddState()
        {

            return View(new State());
        }
        [HttpPost]
        public ActionResult AddState(State state)
        {
            StateRepository.Add(state);
            return RedirectToAction("States");
        }

        public ActionResult EditState(string stateAbbreviation)
        {

            State state = StateRepository.Get(stateAbbreviation);

            return View(state);
        }

        [HttpPost]
        public ActionResult EditState(State state)
        {
            if (ModelState.IsValid)
            {
                StateRepository.Edit(state);
                return RedirectToAction("States"); 
            }
            else
            {
                return View(state);
            }
        }

        public ActionResult DeleteState(string stateAbbreviation)
        {

            State state = StateRepository.Get(stateAbbreviation);

            return View(state);
        }
        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("States");
        }

        //--------------------------------------------
        //--------------------------------------------
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model);
        }
        public ActionResult AddCourse()
        {

            return View(new Course());
        }
        [HttpPost]
        public ActionResult AddCourse(string courseName)
        {
            CourseRepository.Add(courseName);
            return RedirectToAction("Courses");
        }

        public ActionResult EditCourse(int courseId)
        {

            Course course = CourseRepository.Get(courseId);

            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Edit(course);
                return RedirectToAction("Courses"); 
            }
            else
            {
                return View(course);
            }
        }

        public ActionResult DeleteCourse(int courseId)
        {

            Course course = CourseRepository.Get(courseId);

            return View(course);
        }
        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }
    }
}