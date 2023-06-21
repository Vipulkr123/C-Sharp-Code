using Dapper;
using System.Data;
using System.Data.SqlClient;
using Z.Dapper.Plus;

namespace DapperTutorial
{
	public static class HomeController
	{
		// used in mapping with model
		public static void MappingToModel()
		{
			using (SqlConnection connection = new("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				// query will convert to model which are passed in generic format!
				var result = connection.Query<EmployeeModel>("select * from Employee");

				foreach (var item in result)
				{
					Console.WriteLine($"id : {item.Id} :: name : {item.Name} :: Email : {item.Email} :: Phone No : {item.PhoneNo} :: Address : {item.Address}");
				}
			}
		}

		// It return a single row and a single column
		public static void ExecuteScalarMethod()
		{
			using (var connection = new SqlConnection("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				var sql = "SELECT COUNT(*) FROM Employee";
				var count = connection.ExecuteScalar(sql);

				Console.WriteLine($"Total Employees: {count}");
			}
		}

		//only one row is expected to be returned
		// It returns a dynamic type
		public static void QuerySingleMethod()
		{
			using (SqlConnection connection = new("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				// explicit type cast
				//var result = connection.QuerySingle<EmployeeModel>("select * from Employee where Id = 1");

				// dynamic return type
				//var result = connection.QuerySingle("select * from Employee where Id = 1");

				// nothing is fetched because no data is related to 1001 id
				// var result = connection.QuerySingleOrDefault<EmployeeModel>("select * from Employee where ID = 1001");

				// query first return the first element when multiple is fetched
				// var result = connection.QueryFirst<EmployeeModel>("select * from Employee");

				// query will not return a null when nothing is there in table
				var result = connection.QueryFirstOrDefault<EmployeeModel>("select * from Employee where Id = 1");

				if (result != null)
				{
					Console.WriteLine($"id : {result.Id} :: name : {result.Name} :: Email : {result.Email} :: Phone No : {result.PhoneNo} :: Address : {result.Address}");
				}
				else
				{
					Console.WriteLine("nothing is fetched!");
				}
			}
		}

		// Multiple Tables read at one time!
		public static void QueryMultipleMethod()
		{
			using (SqlConnection connection = new("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				string command = "select * from Employee; select * from Department;";

				var result = connection.QueryMultiple(command);

				//EmployeeModel model = result.ReadFirst<EmployeeModel>();
				//Console.WriteLine(model.Id); Console.WriteLine(model.Name);


				var test = result.Read<EmployeeModel>();
				var test1 = result.Read<DepartmentModel>();

				foreach (var item in test)
				{
					Console.WriteLine($"id : {item.Id} :: name : {item.Name} :: Email : {item.Email} :: Phone No : {item.PhoneNo} :: Address : {item.Address}");
				}

				foreach (var item in test1)
				{
					Console.WriteLine($"id : {item.DeptId} :: Department : {item.DeptName}");
				}
			}
		}
		// Select Sepecific Columns 
		public static void SelectSpecificColumn()
		{
			using (var connection = new SqlConnection("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				var sql = "SELECT Name, Email FROM Employee WHERE Id = 1";
				var employees = connection.Query(sql);

				foreach (var employee in employees)
				{
					Console.WriteLine($"{employee.Id} {employee.Name}: {employee.Email}");
				}
			}
		}

		// Executing Non-Query Commands
		public static void Insert()
		{
			string sql = "INSERT INTO Employee Values(@Name, @Email, @PhoneNo, @Address, @DeptId);";
			object[] parameters = { new { Name = "Jay", Email = "jay@example.com", PhoneNo = "23786423", Address = "Morbi, Gujarat", DeptId = 1} };

			using (var connection = new SqlConnection("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				var Result = connection.Execute(sql, parameters);
				Console.WriteLine($"{Result} Row Affected");
			}
		}

		// Update Method 
		public static void Update()
		{
			string sql = "Update Employee SET Name = @Name, Email = @Email WHERE Id = 5";
			object[] parameters = { new { Name = "Abhay", Email = "abhay@example.com"} };

			using (var connection = new SqlConnection("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				var Result = connection.Execute(sql, parameters);
				Console.WriteLine($"{Result} Row Affected");
			}
		}

		//Delete Method 
		public static void Delete()
		{
			string sql = "DELETE FROM Employee WHERE Id = 5";

			using (var connection = new SqlConnection("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				var Result = connection.Execute(sql);
				Console.WriteLine($"{Result} Row Deleted");
			}
		}

		// Executing Reader
		public static void ExecuteReaderMethod()
		{
			using (SqlConnection connection = new("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				string command = "select * from Employee";

				var reader = connection.ExecuteReader(command);

				while (reader.Read())
				{
					Console.WriteLine($"Id : {reader.GetInt32(0)} :: Name : {reader.GetString(1)}");
				}

			}
		}

		// Reader Method with table
		public static void ExecuteReaderMethodUsingDataTable()
		{
			using (SqlConnection connection = new("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				string command = "SELECT * FROM Employee";

				var reader = connection.ExecuteReader(command);

				DataTable table = new DataTable();

				table.Load(reader);

				foreach (DataRow dataRow in table.Rows)
				{
					Console.WriteLine($"Id : {dataRow[0]} :: Name : {dataRow[1]}");
				}
			}
		}

		// Calling Stored Procedure without params
		public static void CallingStoredProcedure()
		{
			using (SqlConnection connection = new("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				string command = "usp_showAllEmployee";

				var result = connection.Query<EmployeeModel>(command, commandType: CommandType.StoredProcedure);

				foreach (var item in result)
				{
					Console.WriteLine($"Id : {item.Id} :: Name : {item.Name}  :: Email : {item.Email}");
				}
			}
		}
		// Join Using Spliton
		public static void JoinUsingSplitOnOption()
		{
			string sql = "SELECT " + "e.Id, e.Name, e.Email , d.DeptName " +
						 "FROM " +
						 "Employee e left join Department d " +
						 "on e.DeptId = d.DeptId";

			using (SqlConnection connection = new("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				var employeesWithData = connection.Query<EmployeeModel, DepartmentModel, EmployeeDepartmentModel>(sql,
					(employee, department) =>
					{
						employee.DeptId = department.DeptId;
						return new EmployeeDepartmentModel() 
						{
							Id = employee.Id,
							Name = employee.Name, 
							Email = employee.Email, 
							DeptName = department.DeptName 
						};
					},
				splitOn: "Email").ToList();

				foreach (var item in employeesWithData)
				{
					Console.WriteLine($"id : {item.Id} Name : {item.Name} Email {item.Email} Department Name : {item.DeptName}");
				}
			}

		}
		// Bulk Insert Method
		public static void BulkMethod()
		{

			using (SqlConnection connection = new("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				List<DepartmentModel> dept = BulkData.DataForDeptModel();

				DapperPlusManager.Entity<DepartmentModel>().Table("Department");

				connection.BulkInsert<DepartmentModel>(dept);
			}

			Console.WriteLine("Inserting Complete");
		}

		// Bulk Update 
		public static void BulkUpdateMethod()
		{
			using (SqlConnection connection = new("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				DapperPlusManager.Entity<DepartmentModel>().Table("Department");
				List<DepartmentModel> department = BulkData.DataForDeptModel();

				connection.BulkUpdate(department);
			}
			Console.WriteLine("Update Complete");
		}
		// Bulk Delete Method
		public static void BulkDeleteMethod()
		{

			using (SqlConnection connection = new("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				List<DepartmentModel> department = BulkData.DataForDeptModel();
				DapperPlusManager.Entity<DepartmentModel>().Table("Department");

				connection.BulkDelete<DepartmentModel>(department);

			}

			Console.WriteLine("Delete Complete");
		}

		// Bulk Merge
		public static void BulkMergeMethod()
		{
			using (SqlConnection connection = new("Data Source=SF-CPU-015\\SQLEXPRESS;Initial Catalog=newdb;User ID=Vipulkr;Password=123;"))
			{
				List<DepartmentModel> department = BulkData.DataForDeptModel();

				DapperPlusManager.Entity<DepartmentModel>().Table("Department");

				connection.BulkMerge(department);

			}

			Console.WriteLine("Merge Complete");
		}


	}
}
