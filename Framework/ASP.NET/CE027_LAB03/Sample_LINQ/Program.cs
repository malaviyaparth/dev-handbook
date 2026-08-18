namespace LINQLab
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

    class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double OrderAmount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer { CustomerId = 1, Name = "Amit Shah", City = "Ahmedabad" },
                new Customer { CustomerId = 2, Name = "Narendra Modi", City = "Ahmedabad" },
                new Customer { CustomerId = 3, Name = "Sachin Tendulkar", City = "Mumbai" },
                new Customer { CustomerId = 4, Name = "Parth Malaviya", City = "Junagadh" },
                new Customer { CustomerId = 5, Name = "Jethalal Gada", City = "Bhachau" },
            };

            List<Order> orders = new List<Order>()
            {
                new Order { OrderId = 101, CustomerId = 1, ProductName = "Laptop",     Category = "Electronics", OrderAmount = 65000 },
                new Order { OrderId = 102, CustomerId = 1, ProductName = "Mouse",      Category = "Accessories", OrderAmount = 1200 },

                new Order { OrderId = 103, CustomerId = 2, ProductName = "Mobile",     Category = "Electronics", OrderAmount = 32000 },
                new Order { OrderId = 104, CustomerId = 2, ProductName = "Headphones", Category = "Accessories", OrderAmount = 3500 },

                new Order { OrderId = 105, CustomerId = 3, ProductName = "Keyboard",   Category = "Accessories", OrderAmount = 1800 },

                new Order { OrderId = 106, CustomerId = 5, ProductName = "Monitor",    Category = "Electronics", OrderAmount = 14500 },
                new Order { OrderId = 107, CustomerId = 5, ProductName = "Printer",    Category = "Office",      OrderAmount = 9800 },
                new Order { OrderId = 108, CustomerId = 5, ProductName = "Tablet",     Category = "Electronics", OrderAmount = 28000 },

                new Order { OrderId = 109, CustomerId = 4, ProductName = "Chair",      Category = "Furniture",   OrderAmount = 7500 },
                new Order { OrderId = 110, CustomerId = 4, ProductName = "Desk",       Category = "Furniture",   OrderAmount = 12500 },
            };

            // Query 1:
            // Display the names of all customers along with the products they have ordered.
            // (Use Join)

            var result1 = customers.Join(
                            orders,
                            c => c.CustomerId,
                            o => o.CustomerId,
                            (c, o) => new
                            {
                                CustomerName = c.Name,
                                Product = o.ProductName
                            });

            Console.WriteLine("The names of all customers along with the products they have ordered : ");
            foreach (var item in result1)
            {
                Console.WriteLine($"{item.CustomerName} - {item.Product}");
            }

            var result2 = orders.FirstOrDefault(o => o.OrderAmount > 20000);

            Console.WriteLine("\nThe details of the first order whose amount is greater than ₹20,000 : ");
            if (result2 != null)
            {
                Console.WriteLine($"Order ID      : {result2.OrderId}");
                Console.WriteLine($"Customer ID   : {result2.CustomerId}");
                Console.WriteLine($"Product Name  : {result2.ProductName}");
                Console.WriteLine($"Category      : {result2.Category}");
                Console.WriteLine($"Order Amount  : {result2.OrderAmount}");
            }
            else
            {
                Console.WriteLine("No order found.");
            }

            var result3 = customers.Join(
                            orders,
                            c => c.CustomerId,
                            o => o.CustomerId,

                            (c, o) => new
                            {
                                c.Name,
                                c.City,
                                o.OrderAmount
                            }
                            )
                           .Where(x => x.City == "Ahmedabad")
                           .GroupBy(x => x.Name)
                           .Select(y => new
                           {
                               CustomerName = y.Key,
                               TotalSpent = y.Sum(x => x.OrderAmount)
                           });

            Console.WriteLine("\nAll customers from Ahmedabad along with the total amount they have spent on orders : ");
            foreach (var item in result3)
            {
                Console.WriteLine($"{item.CustomerName} - Total Spent: {item.TotalSpent}");
            }

            var result4 = customers.Join(
                            orders,
                            c => c.CustomerId,
                            o => o.CustomerId,

                            (c, o) => new
                            {
                                c.Name,
                                c.City,
                                o.ProductName,
                                o.OrderAmount,
                            })
                            .OrderByDescending(x => x.OrderAmount)
                            .FirstOrDefault();

            Console.WriteLine("\nThe customer who has placed the highest-value order along with the product name and order amount : ");
            if (result4 != null)
            {
                Console.WriteLine($"Customer Name : {result4.Name}");
                Console.WriteLine($"City          : {result4.City}");
                Console.WriteLine($"Product Name  : {result4.ProductName}");
                Console.WriteLine($"Order Amount  : {result4.OrderAmount}");
            }
            else
            {
                Console.WriteLine("No order found.");
            }

            Console.ReadKey();
        }
    }
}
