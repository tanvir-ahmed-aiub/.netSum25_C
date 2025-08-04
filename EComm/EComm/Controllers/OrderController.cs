using AutoMapper;
using EComm.Auth;
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

            var exp = (from pro in cart where pro.Id == pr.Id select pro).SingleOrDefault();
            if (exp == null)
            {
                cart.Add(pr);
                Session["cart"] = cart;
            }
            else {
                exp.Qty++;
            }
            
            return RedirectToAction("Index");

        }
        public ActionResult Cart() { 
            var cart = (List<ProductDTO>)Session["cart"];//unboxing cart from session
            return View(cart);
        }
        [HttpPost]
        [Logged]
        public ActionResult PlaceOrder(decimal gTotal) {
            
            var user = (User)Session["user"];
            var o = new Order() { 
                StatusId = 1,
                Date = DateTime.Now,
                CustomerId = (int) user.CustomerId,
                Total = gTotal
            };
            db.Orders.Add(o);
            db.SaveChanges();

            var cart = (List<ProductDTO>)Session["cart"];
            foreach (var item in cart) {
                var od = new OrderDetail() {
                    PId = item.Id,
                    Qty  = item.Qty,
                    Price = item.Price,
                    OId = o.Id
                };
                db.OrderDetails.Add(od);
            }
            db.SaveChanges();
            TempData["Msg"] = "Order Placed Successfully";
            Session["cart"] = null;
            return RedirectToAction("Index");
        }
        public ActionResult Decrease(int id) {
            var cart = (List<ProductDTO>)Session["cart"];
            var p = (from pr in cart where pr.Id == id select pr).SingleOrDefault();
            p.Qty--;
            return RedirectToAction("Cart");
        }
        public ActionResult Increase(int id)
        {
            var cart = (List<ProductDTO>)Session["cart"];
            var p = (from pr in cart where pr.Id == id select pr).SingleOrDefault();
            p.Qty++;
            return RedirectToAction("Cart");
        }
    }
}