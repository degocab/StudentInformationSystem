using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        //[HttpGet]
        //public ActionResult List()
        //{
        //    IEnumerable<ListStudentViewModel> model = (from student in StudentRepository.GetAll()
        //                                           join address in AddressRepository.GetAll()
        //                                           on student.AddressId equals address.AddressId
        //                                           select new ListStudentViewModel()
        //                                           {
        //                                               StudentId = student.StudentId,
        //                                               FirstName = student.FirstName,
        //                                               LastName = student.LastName,
        //                                               GPA = student.GPA,
        //                                               Major = student.Major,
        //                                               AddressId = address.AddressId
        //                                               //Name = employee.FirstName + " " + employee.LastName,
        //                                               //Department = department.DepartmentName,
        //                                               //Phone = employee.Phone,
        //                                               //EmployeeID = employee.EmployeeId
        //                                           }).ToList();
        //    return View(model);
        //}
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            

                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);
                return RedirectToAction("List"); 



        }

        public ActionResult Edit(int studentId)
        {

            Student student = StudentRepository.Get(studentId);

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentRepository.Edit(student);
                return RedirectToAction("List"); 
            }
            else
            {
                return View(student);
            }
        }

        public ActionResult Delete(int studentId)
        {

            Student student = StudentRepository.Get(studentId);

            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }

        public ActionResult EditAddress()
        {
            return View();
        }
    }

}