using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTutorial
{
	public class EmployeeModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = String.Empty;

		public string Email { get; set; } = String.Empty;

		public string PhoneNo { get; set; } = String.Empty;

		public string Address { get; set; } = String.Empty;

		public int DeptId { get; set; }
	}
}
