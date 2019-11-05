using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class ProfileMap:BaseMap<Profile>
    {
        public ProfileMap()
        {
            ToTable("Profiller");

            Property(x => x.FirstName).HasColumnName("İsim").IsRequired();

            Property(x => x.LastName).HasColumnName("SoyIsim").IsRequired();

            Property(x => x.IdentityNo).HasColumnName("Kimlik No");

            Property(x => x.Address).HasColumnName("İkamet Adresi");
        }
    }
}
