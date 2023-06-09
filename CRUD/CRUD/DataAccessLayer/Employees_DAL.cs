using CRUD.Models;
using System.Data.SqlClient;

namespace CRUD.DataAccessLayer
{
    public class Employees_DAL
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        public static IConfiguration Configuration { get; set; }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            return Configuration.GetConnectionString("DefaultConnection");
        }

        public List<Employee> GetAll()
        {
            List<Employee> employeeList = new List<Employee>();
            using(_connection = new SqlConnection(GetConnectionString()))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "[dbo].[usp_GetEmployees]";
                _connection.Open();
                SqlDataReader sqlDataReader = _command.ExecuteReader();
                while(sqlDataReader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    employee.FirstName = sqlDataReader["FirstName"].ToString();
                    employee.LastName = sqlDataReader["LastName"].ToString();
                    employee.DateOfBirth = Convert.ToDateTime(sqlDataReader["LastName"]);
                    employee.Email = sqlDataReader["Email"].ToString();
                    employee.Salary = Convert.ToInt32(sqlDataReader["Salary"]);
                    employeeList.Add(employee);
                }
                _connection.Close();    
            }
            return employeeList;
        }
    }
}
