using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Administrator.Controllers
{
    public class EntityAttributeController : Controller
    {
        EARepository eaRep;
        public EntityAttributeController()
        {
            eaRep = new EARepository();
        }
        // GET: Administrator/EntityAttribute
        public ActionResult AttributeList()
        {
            return View(eaRep.GetAll());
        }


        public ActionResult ActiveAttributes()
        {
            return View(eaRep.GetActives());

        }


        public ActionResult AddAttribute()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddAttribute(EntityAttribute item)
        {
            eaRep.Add(item);
            return RedirectToAction("AttributeList");
        }


        public ActionResult UpdateAttribute(int id)
        {
            
            return View(eaRep.Find(id));
        }

        [HttpPost]

        public ActionResult UpdateAttribute(EntityAttribute item)
        {
            eaRep.Update(item);
            return RedirectToAction("AttributeList");
        }


        public ActionResult DeleteAttribute(int id)
        {
            eaRep.Delete(eaRep.Find(id));
            return RedirectToAction("AttributeList");
        }










    }
}