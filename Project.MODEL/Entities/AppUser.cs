using Project.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class AppUser:BaseEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public Guid? ActivationCode { get; set; }

        public UserRole Role { get; set; }

        //Relational Properties
        public virtual Profile Profile { get; set; }

        public virtual List<Order> Orders { get; set; }

        public AppUser()
        {
            ActivationCode = Guid.NewGuid();
            Role = UserRole.Member;
        }


    }
}
