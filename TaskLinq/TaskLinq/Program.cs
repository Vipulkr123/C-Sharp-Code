namespace TaskLinq
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var firstQuery = (from cust in Data.Customers
							  join order in Data.Orders
							  on cust.CustomerID equals order.CustomerId
							  join item in Data.Items
							  on order.ItemID equals item.ItemID
							  select new
							  {
								  Name = cust.CustomerName,
								  ItemWeek = order.OrderDate.Month,
								  ItemYear = order.OrderDate.Year,
							  }).GroupBy(x => x).ToList();

			var le = Data.Customers.Join(Data.Orders,
										 cust => cust.CustomerID,
										 order => order.CustomerId,
										 (cust, order) => new
										 {
											 cust, order
										 }).Where(w => w.order.OrderDate.Year == 2023).GroupBy(g => g.order.OrderDate.Month).ToList();

			foreach (var item in firstQuery)
            {
				Console.WriteLine($"Name : {item.Key}");
                foreach (var item1 in item)
                {
                    Console.WriteLine($"");
                }
            }
        }
	}
}