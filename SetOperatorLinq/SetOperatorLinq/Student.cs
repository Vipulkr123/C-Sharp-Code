using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SetOperatorLinq
{
	internal class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }

		//bool IEquatable<Student>.Equals(Student? other)
		//{
		//	if(object.ReferenceEquals(other, null)) return false;
		//	if(object.ReferenceEquals(this, other)) return true;
		//	return Id.Equals(other.Id) && Name.Equals(other.Name);
		//}
		//public override int GetHashCode()
		//{
		//	int idHashCode = Id.GetHashCode();
		//	int nameHashCode = Name.GetHashCode();
		//	return idHashCode ^ nameHashCode;
		//}
	}

	public class StudentComparer : IEqualityComparer<Student>
	{
		bool IEqualityComparer<Student>.Equals(Student x, Student y)
		{
			return x.Id.Equals(y.Id) && x.Name.Equals(y.Name);
		}

		int IEqualityComparer<Student>.GetHashCode(Student obj)
		{
			int idHashCode = obj.Id.GetHashCode();
			int nameHashCode = obj.Name.GetHashCode();
			return idHashCode ^ nameHashCode;
		}
	}
}
