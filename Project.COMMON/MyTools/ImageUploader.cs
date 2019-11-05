using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Project.COMMON.MyTools
{
    public static class ImageUploader
    {
        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();

                // ~/Images/adsadasdasdasdasdasd.png

                serverPath = serverPath.Replace("~", string.Empty);
                //  /Images/asdadasdasdasdasdasd.png //eger gelen serverPath parametresinde ~(tilda) diye bir karakter varsa onu boslukla degiştir.

                //uzaygemisi.png
                //cagri.starwars.uzaygemisi.png
                //cagri, starwars, uzaygemisi, png
                //string[] isimler= new string[4];
                // isimler[0]
                //isimler[isimler.Length-1];

                string[] fileArray = file.FileName.Split('.');

                string extension = fileArray[fileArray.Length - 1];

                string fileName = $"{uniqueName}.{extension}";

                if (extension=="jpg" || extension =="gif" || extension == "png"|| extension == "jpeg")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+fileName)))
                    {
                        return "Dosya zaten var";
                    }
                    else
                    {
                        string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    return "Secilen dosya bir resim degil";
                }
            }
            else
            {
                return "Dosya bos";
            }
        }
    }
}
