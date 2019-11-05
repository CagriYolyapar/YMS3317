using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.COMMON.MyTools;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class SystemRegisterController : Controller
    {

        AppUserRepository aRep;
        ProfileRepository pRep;
        public SystemRegisterController()
        {
            aRep = new AppUserRepository();
            pRep = new ProfileRepository();
        }
        // GET: SystemRegister
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Register([Bind(Prefix ="Item1")] AppUser item,[Bind(Prefix ="Item2")] Profile item2 )
        {
            if (aRep.Any(x=> x.UserName == item.UserName))
            {
                ViewBag.ZatenVar = "Lutfen baska bir kullanıcı ismi giriniz";
                return View();
            }
            else if(aRep.Any(x=>x.Email == item.Email))
            {
                ViewBag.ZateVar = "Bu Email bizde zaten kayıtlıdır";
            }

            //KUllanıcı basarılı bir şekilde register işlemini tamamlıyorsa ona mail göndermemiz gerekir

            string gonderilecekMail = "Tebrikler hesabınız olusturulmustur. Hesabınızı aktive etmek icin http://localhost:53456/SystemRegister/Aktivasyon/" + item.ActivationCode + " linkine tıklayabilirsiniz";

            MailSender.Send(item.Email, body: gonderilecekMail, subject: "Hesap Aktivasyon!");

            aRep.Add(item); //buradan sonra item'in id'si olusmus oluyor.. O yüzden dilerseniz item2'nin id'sini verebilirsiniz

            item2.ID = item.ID;
            pRep.Add(item2);
            return View("RegisterOk");
        }


        public ActionResult RegisterOk()
        {
            return View();
        }



        public ActionResult Aktivasyon(Guid id)
        {
            if (aRep.Any(x=>x.ActivationCode == id))
            {
                AppUser aktiveEdilecek = aRep.FirstOrDefault(x => x.ActivationCode == id);
                aktiveEdilecek.IsActive = true;

                aRep.Update(aktiveEdilecek);

                TempData["HesapAktif"] = "Hesabınız aktif hale getirildi";

                return RedirectToAction("Index", "Member");
            }
            TempData["HesapAktif"] = "Aktif edilecek hesap bulunamadı";
            return RedirectToAction("Register");
        }





    }
}