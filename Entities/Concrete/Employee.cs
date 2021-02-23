using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public string DepartmentName { get; set; }

    }
}
