using AutoMapper;
using EComm.DTOs;
using EComm.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EComm.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        EComm_Sum25_CEntities db = new EComm_Sum25_CEntities();

        static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public ActionResult Index()
        {
            var data = db.Products.ToList();

            var products = GetMapper().Map<List<ProductDTO>>(data);
            return View(products);
        }
        public ActionResult AddtoCart(int id) {
            var p = db.Products.Find(id);
            var pr = GetMapper().Map<ProductDTO>(p);
            List<ProductDTO> cart = null;
            pr.Qty = 1;
            if (Session["cart"] == null)
            {
                cart = new List<ProductDTO>();
            }
            else {
                cart = (List<ProductDTO>)Session["cart"];
            }
            cart.Add(pr);
            Session["cart"] = cart;
            return RedirectToAction("Index");

        }
        public ActionResult Cart() { 
            var cart = (List<ProductDTO>)Session["cart"];//unboxing cart from session
            return View(cart);
        }
    }
}