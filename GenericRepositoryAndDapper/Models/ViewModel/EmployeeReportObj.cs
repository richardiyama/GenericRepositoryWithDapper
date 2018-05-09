using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericRepositoryAndDapper.Models.ViewModel
{
    public class EmployeeReportObj
    {
        public int EmployeesID { get; set; }
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public int Age { get; set; }
        public decimal Income { get; set; }
        public int DepartmentID { get; set; }
        public string Department { get; set; }
        public string Comments { get; set; }
    }
}