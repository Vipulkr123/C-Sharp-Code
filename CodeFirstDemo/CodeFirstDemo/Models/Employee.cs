using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstDemo.Models
{
	public class Employee
	{
		[Key]
        public int EmpId { get; set; }
		[Required]
		public string Name { get; set; }
        public string Dept { get; set; }
        public int Salary { get; set; }
    }
}