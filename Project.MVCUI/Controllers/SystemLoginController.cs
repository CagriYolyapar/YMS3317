using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class SystemLoginController : Controller
    {
        AppUserRepository apRep;
        public SystemLoginController()
        {
            apRep = new AppUserRepository();
        }
        // GET: SystemLogin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(AppUser item)
        {
            if (apRep.Any(
                x=>x.UserName == item.UserName &&
                x.Password == item.Password &&
                x.Status != MODEL.Enums.DataStatus.Deleted &&
                x.Role == MODEL.Enums.UserRole.Admin
                ))
            {

                AppUser girisYapan = apRep.FirstOrDefault(x => x.UserName == item.UserName && x.Password == item.Password);
                Session["admin"] = girisYapan;

                return RedirectToAction("CategoryList","Category",new { area="Administrator"});
            }

            else if (apRep.Any(
                x =>x.UserName ==item.UserName &&
                x.Password == item.Password &&
                x.Status != MODEL.Enums.DataStatus.Deleted &&
                x.Role == MODEL.Enums.UserRole.Member

                
                ))
            {
                AppUser girisYapan = apRep.FirstOrDefault(x=>x.UserName == item.UserName && x.Password == item.Password);
                if (girisYapan.IsActive == false)
                {
                    ViewBag.AktifDegil = "Lutfen hesabınızı aktif hale getiriniz";
                    return View("RegisterOk","SystemRegister");
                }
                return View("Index", "Member");

            }
            ViewBag.KullaniciBulunamadi = "Böyle bir kullanıcı yoktur";
            return View();
           
        }


    }
}