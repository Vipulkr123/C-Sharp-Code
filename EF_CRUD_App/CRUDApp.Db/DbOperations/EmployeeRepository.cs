using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDApp.Models;

namespace CRUDApp.Db.DbOperations
{
	public class EmployeeRepository
	{
		public int AddEmployee(EmployeeModel employeeModel)
		{
			using(var context = new EmployeeDbEntities())
			{
				Random random = new Random();
				Employee employee = new Employee()
				{
					Name = employeeModel.Name,
					Email = employeeModel.Email,
					PhoneNo = employeeModel.PhoneNo,
					Address = employeeModel.Address
				};
				context.Employees.Add(employee);
				context.SaveChanges();
				return employee.Id;
			}
		}

		public List<EmployeeModel> GetEmployees()
		{
			using(var context = new EmployeeDbEntities())
			{
				#region Without store procedure 
				//var AllEmployees = context.Employees.Select(x => new EmployeeModel()
				//{
				//	Id = x.Id,
				//	Name = x.Name,
				//	Email = x.Email,
				//	PhoneNo = x.PhoneNo,
				//	Address = x.Address
				//}).ToList();

				//return AllEmployees;
				#endregion

				#region using Store procedure
				var Result = context.Database.SqlQuery<EmployeeModel>("EXEC usp_getEmp;");
				return Result.ToList();
				#endregion
			}
		}

		public EmployeeModel GetEmployee(int id)
		{
			using (var context = new EmployeeDbEntities())
			{
				var EmployeeDetails = context.Employees.Where(x => x.Id == id).Select(x => new EmployeeModel()
				{
					Id = x.Id,
					Name = x.Name,
					Email = x.Email,
					PhoneNo = x.PhoneNo,
					Address = x.Address
				}).FirstOrDefault();

				return EmployeeDetails;
			}
		}

		public bool UpdateEmployee(int id , EmployeeModel employeeModel)
		{
			using(var context = new EmployeeDbEntities())
			{
				#region General way to update table
				//var employee = context.Employees.FirstOrDefault(x => x.Id == id);
				//if(employee != null)
				//{
				//	employee.Name = employeeModel.Name;
				//	employee.Email = employeeModel.Email;
				//	employee.PhoneNo = employeeModel.PhoneNo;
				//	employee.Address = employeeModel.Address;
				//}
				//context.SaveChanges();
				//return true;
				#endregion

				#region Update table data using Entity State
				var employee = new Employee();
				if(employee != null)
				{
					employee.Id = employeeModel.Id;
					employee.Name = employeeModel.Name;
					employee.Email = employeeModel.Email;
					employee.PhoneNo = employeeModel.PhoneNo;
					employee.Address = employeeModel.Address;
				}
				context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
				context.SaveChanges();
				return true;
				#endregion
			}
		}

		public bool DeleteEmployee(int id)
		{
			using (var context = new EmployeeDbEntities())
			{
				#region General Way to Delete
				//var employee = context.Employees.FirstOrDefault(x => x.Id == id);
				//if (employee != null)
				//{
				//	context.Employees.Remove(employee);
				//	context.SaveChanges();
				//	return true;
				//}
				//return false;
				#endregion

				#region Delete using Entity State
				var employee = new Employee()
				{
					Id = id
				};
				context.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
				context.SaveChanges();
				return true;
				#endregion
			}
		}

		public string GetTotalEmployee()
		{
			using (var context = new EmployeeDbEntities())
			{
				//var param = new SqlParameter
				//{
				//	ParameterName = "@TotalRow",
				//	DbType = DbType.String,
				//	Size = 30,
				//	Direction = System.Data.ParameterDirection.Output
				//};

				//var result = context.Database.SqlQuery<string>("EXEC usp_GetEmpWithOutput @TotalCount = @TotalRow", param);
				//string TotalEmployee = param.Value.ToString();
				//return TotalEmployee;

				string procedureName = "Declare @Param3 INT Exec usp_GetEmpWithOutput @Param3";
				var sqlParameterOut = new SqlParameter
				{
					ParameterName = "@Param3",
					SqlDbType = SqlDbType.Int,
					Direction = ParameterDirection.Output
				};
				context.Database.SqlQuery<int>(procedureName,sqlParameterOut);
				string TotalRow = Convert.ToString(sqlParameterOut.Value);
				return TotalRow;
			}
		}
	}
}
