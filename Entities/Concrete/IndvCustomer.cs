using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class IndvCustomer : IEntity
    {
        public int IndvCustomerId { get; set; }
        public int UserId { get; set; }
        public DateTime BirthOfDate { get; set; }
        public string IdentityNumber { get; set; }
    }
}
