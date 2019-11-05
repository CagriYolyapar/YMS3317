using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using Project.MVCUI.AdminAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Administrator.Controllers
{
    [AdminControl]
    public class CategoryController : Controller
    {
        CategoryRepository crep;
        public CategoryController()
        {
            crep = new CategoryRepository();
        }
        // GET: Administrator/Category
        public ActionResult CategoryList()
        {
            return View(crep.GetAll());
        }


        public ActionResult ActiveCategories()
        {
            return View(crep.GetActives());

        }

        //ToDO: Attribute crud,Login, Register,Mail Gonderme, Resim Yükleme,ProductAttribute Admin paneli işlemleri,Authentication,Sipariş Modülü, Banka ödeme sistemi

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddCategory(Category item)
        {
            crep.Add(item);
            return RedirectToAction("CategoryList");
        }


        public ActionResult UpdateCategory(int id)
        {

            return View(crep.Find(id));
        }

        [HttpPost]

        public ActionResult UpdateCategory(Category item)
        {
            crep.Update(item);
            return RedirectToAction("CategoryList");
        }



        public ActionResult DeleteCategory(int id)
        {
            crep.Delete(crep.Find(id));
            return RedirectToAction("CategoryList");
        }





    }
}