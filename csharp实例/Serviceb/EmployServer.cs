using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceb
{
    public class EmployServer: IEmployees
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee {Department = "1",Grade = "2",Id="3",Name="4"},
            new Employee {Department = "5",Grade = "6",Id="7",Name="8"}
        };

        public List<Employee> GetAll()
        {
            return Employees;
        }
    }
}
