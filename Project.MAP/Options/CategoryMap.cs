using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class CategoryMap:BaseMap<Category>
    {
        public CategoryMap()
        {
            ToTable("Kategoriler"); //ilgili tablo adı
            Property(x => x.CategoryName).HasColumnName("Kategori İsmi").IsRequired().HasMaxLength(100);

            Property(x => x.Description).HasColumnName("Acıklaması").HasMaxLength(500);
        }
    }
}
