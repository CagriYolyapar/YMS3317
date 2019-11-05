using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class OrderDetailMap:BaseMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("Satışlar");

            Ignore(x => x.ID); //Ignore komutu Sql'e ilgili property'i gönderme demektir.

            HasKey(x => new { x.OrderID, x.ProductID }); //OrderID ve ProductID'yi composite key yaptık.
        }
    }
}
