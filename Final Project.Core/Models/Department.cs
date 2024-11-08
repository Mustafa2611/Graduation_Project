using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Core.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public College College { get; set; }

        public Employee Head_Of_Department { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
