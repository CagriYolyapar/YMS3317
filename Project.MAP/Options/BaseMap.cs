using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public abstract class BaseMap<T>:EntityTypeConfiguration<T> where T:BaseEntity
    {
        public BaseMap()
        {
            Property(x => x.CreatedDate).HasColumnName("Yaratma Tarihi").HasColumnType("datetime2");

            Property(x => x.DeletedDate).HasColumnType("datetime2").HasColumnName("Silme Tarihi");

            Property(x => x.ModifiedDate).HasColumnName("Güncelleme Tarihi").HasColumnType("datetime2");

            Property(x => x.Status).HasColumnName("Veri Durumu").IsOptional();

            Property(x => x.CreatedBy).HasColumnName("Ekleyen Kişi");

            Property(x => x.ModifiedBy).HasColumnName("Değiştiren Kişi");
        }
    }
}
