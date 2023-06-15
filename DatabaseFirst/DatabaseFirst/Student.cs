//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public partial class Student
    {
        [Required(ErrorMessage ="Id is Required Please Fill")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required Please Fill")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Required Please Fill")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile Number is Required Please Fill")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Not Valid mobile number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Address is Required Please Fill")]
        public string Address { get; set; }

    }
}
