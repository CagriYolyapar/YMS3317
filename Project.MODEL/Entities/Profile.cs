﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Profile:BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdentityNo { get; set; }

        public string Address { get; set; }

        //Relational Properties

        public virtual AppUser AppUser { get; set; }


    }
}
