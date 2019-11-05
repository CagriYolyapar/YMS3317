using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class ProductMap : BaseMap<Product>
    {
        public ProductMap()
        {
           
            Property(x => x.ProductName).HasColumnName("Ürün İsmi").IsRequired().HasMaxLength(100);

            Property(x => x.UnitPrice).HasColumnName("Ürün Fiyatı").HasColumnType("money").IsRequired();

            ToTable("Ürünler");

            Property(x => x.UnitsInStock).HasColumnName("Ürün Stok Miktarı").IsRequired();
        }
    }
}
