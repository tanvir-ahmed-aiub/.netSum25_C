﻿using IntroEF.EF;
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
        // GET: Student
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create() { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s) { 
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id) {
            var st = db.Students.Find(id);
            return View(st);
        }
    }
}