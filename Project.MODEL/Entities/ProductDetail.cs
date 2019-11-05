using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class ProductDetail:BaseEntity
    {
        public int ProductID { get; set; }

        public int EntityAttributeID { get; set; }

        public string Value { get; set; }

        //Relational Properties

        public virtual Product Product { get; set; }

        public virtual EntityAttribute EntityAttribute { get; set; }

    }
}
