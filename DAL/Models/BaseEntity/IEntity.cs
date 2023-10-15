using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.BaseEntity
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime CreatedAt { get; set; }
    }
}
