using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.COMMON.MyTools;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        ProductRepository prep;
        CategoryRepository crep;
        public HomeController()
        {
            prep = new ProductRepository();
            crep = new CategoryRepository();
        }

        // GET: Administrator/Home
        public ActionResult Index()
        {
            return View(prep.GetAll());
        }



        public ActionResult AddProduct()
        {
            ViewBag.Categories = crep.GetActives();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product item,HttpPostedFileBase resim)
        {
            item.ImagePath = ImageUploader.UploadImage("~/Images/", resim);
            prep.Add(item);
            return RedirectToAction("Index");
        }


        public ActionResult UpdateProduct(int id)
        {
            ViewBag.Categories = crep.GetActives();
            return View(prep.Find(id));
        }

        [HttpPost]

        public ActionResult UpdateProduct(Product item, HttpPostedFileBase resim)
        {
            item.ImagePath = ImageUploader.UploadImage("~/Images/", resim);
            prep.Update(item);
            return RedirectToAction("Index");
        }


        public ActionResult DeleteProduct(int id)
        {
            prep.Delete(prep.Find(id));
            return RedirectToAction("Index");
        }






    }
}