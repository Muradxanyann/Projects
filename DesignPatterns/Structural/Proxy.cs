using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace StructuralTask7
{
    interface IPaymentService
    {
        void MakePayment(int amount);
        void RefundPayment(int amount);
    }

    class RealPaymentService : IPaymentService
    {
        public void MakePayment(int amount)
        {
            Console.WriteLine($"Making payment... {amount}");
        }

        public void RefundPayment(int amount)
        {
            Console.WriteLine($"Refunding payment... {amount}");
        }
    }

    enum UserRole
    {
        Admin, User
    }

    class User
    {
        public string Name { get; set; }
        public UserRole role;
        public User (string name, UserRole role)
        {
            Name = name;
            this.role = role;
        }
    }

    class ProxyPaymentService : IPaymentService
    {
        private  RealPaymentService service;
        private readonly User user;
        public ProxyPaymentService(User user)  => this.user = user;
        public void MakePayment(int amount)
        {
            service = new RealPaymentService();
            Console.WriteLine($"The user {user.Name} making payment...");
            service.MakePayment(amount);
        }

        public void RefundPayment(int amount)
        {
            if(user.role != UserRole.Admin)
            {
                Console.WriteLine($"The user {user.Name} dont have enoght role");
                return;
            }
            service.RefundPayment(amount);
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            var user = new User("Bob", UserRole.User);
            var admin = new User("Job", UserRole.Admin);
            var proxy = new ProxyPaymentService(user);
            proxy.MakePayment(100);
            proxy.RefundPayment(100);


        }
    }
}