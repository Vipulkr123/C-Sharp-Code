using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTutorial
{
	public static class BulkData
	{
		public static List<DepartmentModel> DataForDeptModel()
		{
			var list = new List<DepartmentModel>();

			for (int i = 2; i < 1200; i++)
			{
				list.Add(new DepartmentModel() { DeptId = i + 1, DeptName = $"Testing{(i * 100) + (110 * 1010)}" });
			}
			return list;
		}
	}
}
