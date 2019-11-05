using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public  class AppUserMap:BaseMap<AppUser>
    {
        //DantexCrypt.CryptPassword("123");

        //asdasd_12a_asdasd?asdasd*asdasd

        //DantexCrypt.DeCryptPassword("asdasd_12a_asdasd?asdasd*asdasd")


        public AppUserMap()
        {
            ToTable("Kullanıcılar");

            Property(x => x.UserName).HasColumnName("Kullanıcı İsmi").IsRequired().HasMaxLength(50);

            Property(x => x.Password).HasColumnName("Sifre");

            Property(x => x.IsActive).HasColumnName("Akftif").IsOptional();

            Property(x => x.ActivationCode).HasColumnName("Aktivasyon Kodu").IsOptional();

            Property(x => x.Role).HasColumnName("Kullanıcı Rolü").IsOptional();

            HasOptional(x => x.Profile).WithRequired(x => x.AppUser);//AppUser'in Profile özelligi bos gecilebilir ancak Profil'in AppUser özelligi bos gecilemez. (1'e 1 ilişkiyi tamamlamamız icin gereken ifade)
        }
    }
}
