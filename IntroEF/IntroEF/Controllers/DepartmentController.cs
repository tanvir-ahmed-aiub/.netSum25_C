using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class DepartmentController : Controller
    {
        Sum25_CEntities db = new Sum25_CEntities();
        // GET: Department
        public ActionResult Index()
        {
            
            return View(db.Departments.ToList());
        }
        [HttpGet]
        public ActionResult Create() { 
            return View();  
        }
        [HttpPost]
        public ActionResult Create(Department d)
        {
            db.Departments.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id) {

            var dept = (from d in db.Departments.Include("Students")
                        where d.Id == id
                        select d).SingleOrDefault();
            return View(dept);
        }
    }
}