using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericRepositoryAndDapper.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<Employees>Employee { get; set; }
    }
}