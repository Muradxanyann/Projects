using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
namespace Linq2
{
    static class Program
    {
        public static void Main(string[] args)
        {
            var categories = new List<Category>
            {
                new Category(1, "Books"),
                new Category(2, "Electronics"),
                new Category(3, "Clothing"),
                new Category(4, "Home & Kitchen"),
                new Category(5, "Toys")
            };

            var products = new List<Product>
            {
                new Product(1, "C# Programming Book", 29.99, 1),
                new Product(2, "JavaScript for Beginners", 24.99, 1),
                new Product(3, "Blender", 59.99, 4),
                new Product(4, "Smartphone", 499.99, 2),
                new Product(5, "Laptop", 999.99, 2),
                new Product(6, "Tablet", 199.99, 2),
                new Product(7, "T-Shirt", 14.99, 3),
                new Product(8, "Jeans", 39.99, 3),
                new Product(9, "Jacket", 89.99, 3),
                new Product(10, "Lego Set", 89.99, 5),
                new Product(11, "Action Figure", 19.99, 5),
                new Product(12, "Cooking Pot", 34.99, 4),
                new Product(13, "Electric Kettle", 24.99, 4),
                new Product(14, "Data Structures Book", 34.99, 1),
                new Product(15, "Monitor", 149.99, 2),
                new Product(16, "Keyboard", 49.99, 2),
                new Product(17, "Microwave", 99.99, 4)
            };

            var sections = new List<Marketing>
            {
                new Marketing(1, "Holiday Sale"),
                new Marketing(2, "Buy One Get One"),
                new Marketing(3, "Summer Clearance"),
                new Marketing(4, "New Arrivals Launch"),
                new Marketing(5, "Back to School Promo")
            };

            var employees = new List<Employee>
            {
                new Employee(1, "Alice Johnson", 55000m, 1),
                new Employee(2, "Bob Smith", 62000m, 2),
                new Employee(3, "Catherine Lee", 58000m, 1),
                new Employee(4, "David Brown", 70000m, 3),
                new Employee(5, "Eva Green", 64000m, 2),
                new Employee(6, "Frank Moore", 75000m, 4),
                new Employee(7, "Grace Hall", 53000m, 1),
                new Employee(8, "Henry Scott", 60000m, 3),
                new Employee(9, "Isabella Adams", 72000m, 4),
                new Employee(10, "Jack Turner", 50000m, 2)
            };

            var users = new List<User>
            {
                new User(1, "Anna"),
                new User(2, "Brian"),
                new User(3, "Carla"),
                new User(4, "Derek"),
                new User(5, "Emily")
            };
            var orders = new List<Order>
            {
                new Order(1, 1, OrderStatus.Pending),
                new Order(2, 1, OrderStatus.Deliveried),
                new Order(3, 2, OrderStatus.OnTheWay),
                new Order(4, 3, OrderStatus.Deliveried),
                new Order(5, 3, OrderStatus.Pending),
                new Order(6, 3, OrderStatus.OnTheWay),
                new Order(7, 4, OrderStatus.PaymentRejected),
                new Order(8, 5, OrderStatus.Deliveried)
            };

            var orderDetails = new List<OrderDetails>
            {
                new OrderDetails(1, 1, 2, 1),    // User 1
                new OrderDetails(2, 1, 2, 2),    // User 1
                new OrderDetails(3, 2, 2, 1),    // User 1
                new OrderDetails(4, 3, 4, 5),    // User 2
                new OrderDetails(5, 4, 5, 1),    // User 3
                new OrderDetails(6, 5, 6, 2),    // User 3
                new OrderDetails(7, 5, 7, 1),    // User 3
                new OrderDetails(8, 6, 8, 3),    // User 3
                new OrderDetails(9, 7, 9, 1),    // User 4
                new OrderDetails(10, 8, 10, 7),  // User 5
                new OrderDetails(11, 2, 11, 2),  // User 1
                new OrderDetails(12, 5, 12, 1),  // User 3
                new OrderDetails(13, 6, 13, 1),  // User 3
                new OrderDetails(14, 6, 14, 2),  // User 3
                new OrderDetails(15, 6, 15, 1)   // User 3
            };


            // Գտնել այն user-ներին, որոնք գոնե մեկ պատվեր արել են (հուշում join-ը, արդեն իսկ ներառում է միայն պատվեր արածներին)
            var usersWithOrders = users.Join(
                orders,
                user => user.Id,
                order => order.userId,
                (user, order) => user
            ).Distinct();
            // Տպել յուրաքանչյուր աշխատակցի անունը և department-ի անունը, որտեղ աշխատում են
            var empoyeesSections = employees.Join(
                sections,
                employee => employee.sectionId,
                section => section.Id,
                (employee, section) => new {Name = employee.Name, Section = section.Name}
            ).GroupBy(g => g.Section);
            // Այն ապրանքները, որոնք որևէ պատվերի մեջ եղել են ավելի քան 2 հատ քանակով
            var productsBoughtMoreThanTwo = orderDetails.Where(x => x.count > 2)
            .Join(
                products,
                order => order.productId,
                product => product.Id,
                (order, product) => product
            ).OrderBy(x => x.Name);
            foreach(var product in productsBoughtMoreThanTwo)
            {
                Console.WriteLine(product.Name ?? "Unknown product");
            }
            // Յուրաքանչյուր user-ի համար ցույց տալ նրա կատարած պատվերների քանակը
            var usersAndOrderscount = users.Join(
                orders,
                user => user.Id,
                order => order.userId,
                (user, order) => new {Name = user.Name, order = order.Id}
            ).GroupBy(n => n.Name).Select(x => new{Name = x.Key, OrdersCount = x.Count()});
            /* foreach(var user in usersAndOrderscount)
            {
                Console.WriteLine($"{user.Name} ({user.OrdersCount})");
            } */

            // Գտնել ամենաշատ պատվերներ արած մարդու անունը
            var mostOrderUserName = usersAndOrderscount.OrderByDescending(x => x.OrdersCount).FirstOrDefault();
            // Console.WriteLine(mostOrderUserName?.Name);
            // Գտնել ամենաթանկ պատվերը կատարած userին
            var mostValuableUser = orderDetails.Join(
                products,
                order => order.productId,
                product => product.Id,
                (order, product) => new {OrderId = order.Id, totalSum = order.count * product.Price})
                .Join(
                    orders,
                    n => n.OrderId,
                    o => o.Id,
                    (n, o) => new {userId = o.userId, totalSum = n.totalSum})
                    .Join(
                        users,
                        type => type.userId,
                        user => user.Id,
                        (type, user) => new {userName = user.Name, orderTotalAmount = type.totalSum}
                    ).MaxBy(x => x.orderTotalAmount);
                Console.WriteLine($"The most valuable order has {mostValuableUser?.userName ?? "Unknown user"} - {mostValuableUser?.orderTotalAmount}");

            // 3 ամենահաճախ պատվիրված ապրանքները
            var threeMostSoldProducts = products.GroupJoin(
                orderDetails,
                product => product.Id,
                order => order.productId,
                (product, order) => new {ProductName = product.Name, TotalSold = order.Sum(x => x.count)})
                .OrderByDescending(x => x.TotalSold).Take(3);
                foreach (var item in threeMostSoldProducts)
                {
                    Console.WriteLine($"{item.ProductName} - ({item.TotalSold})");
                }
            // Ապրանքներ, որոնք երբևէ չեն պատվիրվել (կարող եք օգտվել Any մեթոդից)
            var missedProducts = products.Where(x => !orderDetails.Any(order => x.Id == order.Id)).ToList();
            foreach (var product in missedProducts)
            {
                Console.WriteLine($"Items is never ordered: {product.Name}");
            }

            //Յուրաքանչյուր userի անունը և իր ծախսած ընդհանուր գումարը պատվերներում
            var usersSpendMoney = products.Join(
                orderDetails,
                product => product.Id,
                order => order.productId,
                (product, order) => new {OrderID = order.orderId, TotalSum = order.count * product.Price})
                .Join(
                    orders,
                    type => type.OrderID,
                    o => o.userId,
                    (type, o) => new {TotalSum = type.TotalSum, UserId = o.userId})
                    .Join(
                        users,
                        type => type.UserId,
                        user => user.Id,
                        (type, user) => new {TotalSum = type.TotalSum, Name = user.Name})
                        .Distinct().OrderBy(x => x.TotalSum).ToList();

            usersSpendMoney.ForEach(x => Console.WriteLine($"{x.Name} - {x.TotalSum}$"));
        }
    }
}
