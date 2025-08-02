using AutoMapper;
using IntroEF.DTOs;
using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class StudentController : Controller
    {
        Sum25_CEntities db = new Sum25_CEntities();

        Mapper GetMapper() {
            
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentDTO, Student>().ReverseMap();

            });
            var mapper = new Mapper(config);
            return mapper;
        }
        // GET: Student
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            var st = GetMapper().Map<List<StudentDTO>>(data);
            return View(st);
        }
        [HttpGet]
        public ActionResult Create() { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentDTO s) {
                       
            var st= GetMapper().Map<Student>(s);
            db.Students.Add(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id) {
            var st = db.Students.Find(id);
            return View(st);
        }
    }
}