using IntroMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace IntroMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            /*Student s1 = new Student() {
                Id = 1,
                Name = "S1",
                Email = "e.a@g.c",
                Address = "Dhaka"
            };
            Student s2 = new Student()
            {
                Id = 2,
                Name = "S2",
                Email = "e.a@g.c",
                Address = "Dhaka"
            };*/
            List<Student> students = new List<Student>();
            for (int i = 1; i <= 20; i++) {
                Student s = new Student()
                {
                    Id = i,
                    Name = "S"+i,
                    Email = i+"e.a@g.c",
                    Address = "Dhaka"
                };
                students.Add(s);
            }
            
            

            return View(students);
        }
        public ActionResult Create()
        {
            TempData["Msg"] = "Redirected from Student Create";
            return RedirectToAction("Index","Home");
            
        }
    }
}