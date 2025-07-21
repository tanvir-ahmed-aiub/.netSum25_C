﻿using FormSubmission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormSubmission.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create() { 
            return View(new Student());
        }
        [HttpPost]

        public ActionResult Create(Student s) {
            if (ModelState.IsValid) {
                return RedirectToAction("Index","Home");
            }
            return View(s);
        }
        //[HttpPost]
        //public ActionResult Create(string Name, string Id, string Address) {
        //    ViewBag.Name = Name;
        //    ViewBag.Id = Id;
        //    ViewBag.Address = Address;
        //    return View();

        //}
        //[HttpPost]
        //public ActionResult Create(FormCollection obj) {

        //    ViewBag.Name = obj["Name"];
        //    ViewBag.Id = obj["Id"];
        //    ViewBag.Email = obj["Email"];
        //    ViewBag.Address = obj["Address"];
        //    return View();
        //}

        //public ActionResult Create() {
        //    string n = Request["Name"];
        //    return View();
        //}
    }
}