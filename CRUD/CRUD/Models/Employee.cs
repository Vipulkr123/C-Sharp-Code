namespace CRUD.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public double Salary{ get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
