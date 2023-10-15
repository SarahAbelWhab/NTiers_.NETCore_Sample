using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class ActivityyyLog : BaseEntity.BaseEntity
    {
        public string URL { get; set; }

        public string Action { get; set; }

        public string IPAddress { get; set; }

        public string UserName { get; set; }


        //public Guid UserId { get; set; }

        //[ForeignKey("UserId")]
        //public User User { get; set; }
    }
}
