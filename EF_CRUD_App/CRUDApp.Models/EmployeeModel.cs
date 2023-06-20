using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Models
{
	public class EmployeeModel
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is Required Please Fill")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Email is Required Please Fill")]
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Mobile Number is Required Please Fill")]
		[RegularExpression(@"^(\d{10})$", ErrorMessage = "Not Valid mobile number")]
		public string PhoneNo { get; set; }
		[Required(ErrorMessage = "Address is Required Please Fill")]
		public string Address { get; set; }
	}
}
