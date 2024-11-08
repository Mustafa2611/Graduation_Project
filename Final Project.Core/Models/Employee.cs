using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Core.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Job_Title { get; set; }
        public string Resume { get; set; }

        public Department Department { get; set; }

        public Unit? Unit { get; set; }
    }
}
