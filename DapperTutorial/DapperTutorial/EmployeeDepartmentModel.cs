using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTutorial
{
	public class EmployeeDepartmentModel : EmployeeModel
	{
        public string DeptName { get; set; } = String.Empty;
    }
}
