using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class User : BaseEntity.BaseEntity
    {      
        public string UserName { get; set; }

        public string UserIP { get; set; }
    }
}
