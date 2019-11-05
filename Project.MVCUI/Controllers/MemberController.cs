using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using Project.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class MemberController : Controller
    {
        ProductRepository prep;
        OrderRepository oRep;
        OrderDetailRepository odRep;
        CategoryRepository cRep;

        public MemberController()
        {
            prep = new ProductRepository();
            oRep = new OrderRepository();
            odRep = new OrderDetailRepository();
            cRep = new CategoryRepository();

        }

        // GET: Member
        public ActionResult Index()
        {
            return View(prep.GetActives());
        }


        public ActionResult AddToCart(int id)
        {
            //Alt tarafta eger program scart isimli bir Session varsa buradan degeri alıp Cart'a cevirecek yoksa yeni bir Cart nesnesi yaratacak.
            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;


            Product eklenecekUrun = prep.Find(id);
            CartItem ci = new CartItem();
            ci.ID = eklenecekUrun.ID;
            ci.Name = eklenecekUrun.ProductName;
            ci.Price = eklenecekUrun.UnitPrice;
            ci.ImagePath = eklenecekUrun.ImagePath;
            c.SepeteEkle(ci);

            Session["scart"] = c;


            return RedirectToAction("Index");
        }


        public ActionResult CartPage()
        {
            if (Session["scart"]!=null)
            {
                Cart c = Session["scart"] as Cart;
                return View(c);
            }
            TempData["message"] = "Sepetinizde ürün bulunmamaktadır";
            return RedirectToAction("Index");
        }


        public ActionResult DeleteFromCart(int id)
        {

            if (Session["scart"] != null)
            {
                Cart c = Session["scart"] as Cart;
                c.SepettenSil(id);
                if ((Session["scart"] as Cart).Sepetim.Count==0)
                {
                    Session.Remove("scart");
                    TempData["gitti"] = "Sepetiniz bosaltılmıstır";

                    return RedirectToAction("Index");
                }

                return RedirectToAction("CartPage");
            }

            TempData["silinecekYok"] = "Sepetiniz bos oldugu icin bu sayfaya gitmenizde bir mantık yok";
            return RedirectToAction("Index");
        }


        public ActionResult CommitOrder()
        {

            return View(Tuple.Create(new Order(),new PaymentVM()));
        }

        [HttpPost]

        public ActionResult CommitOrder([Bind(Prefix ="Item1")] Order item,[Bind(Prefix ="Item2")] PaymentVM item2)
        {
            //Burada artık bir client olarak bankamızın Api'sine istek göndermemiz lazım (Api Consume).

            return View();
        }










    }
}