using System.Net.Security;
using System.Text.RegularExpressions;
namespace BehaviouralTask5
{
    interface IAuthStrategy
    {
        bool Authenticate(User user);
    }
    class PasswordAuthStrategy : IAuthStrategy
    {
        public bool Authenticate(User user)
        {
            Console.WriteLine("Authenticating using password...");
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
            if (!Regex.IsMatch(user.Password, pattern))
            {
                Console.WriteLine("Invalid password");
                return false;
            }
            Console.WriteLine("Valid password");
            return true;
        }
    }
    public class OtpAuthStrategy : IAuthStrategy
    {
        private readonly string _expectedOtp;

        public OtpAuthStrategy(string expectedOtp)
        {
            _expectedOtp = expectedOtp;
        }

        public bool Authenticate(User user)
        {
            Console.WriteLine($"Проверка OTP для {user.Name}...");
            Console.WriteLine("Please write here the code");
            var answer = Console.ReadLine();
            if (answer == _expectedOtp)
            {
                Console.WriteLine("Valid OTP");
                return true;
            }
            Console.WriteLine("Unvalid OTP");
            return false;
        }
    }
    public class FaceIdAuthStrategy : IAuthStrategy
    {
        public bool Authenticate(User user)
        {
            Console.WriteLine($"Распознавание лица пользователя {user.Name}...");
            return user.FaceId == "face_ok";
        }
    }       

    class AuthService
    {
        private IAuthStrategy strategy;
        public AuthService(IAuthStrategy strategy) => this.strategy = strategy;
        public void SetStrategy(IAuthStrategy strategy) => this.strategy = strategy;

        public bool Authenticate(User user)
        {
            return strategy.Authenticate(user);
        }
    }
    public class User
    {
        public string Name { get; private set; }
        public string Password { get; private set; }

        public string PhoneNumber { get; private set; }
        public string FaceId { get; private set; }


        public User(string name, string password, string phoneNumber, string faceId)
        {
            Name = name;
            Password = password;
            PhoneNumber = phoneNumber;
            FaceId = faceId;
        }
    }

    /* static class Program
    {
        static void Main(string[] args)
        {
            var user = new User("john", "12345", "+374999999", "face-ok");

            var authService = new AuthService(new PasswordAuthStrategy());
            bool isPasswordAuthSuccess = authService.Authenticate(user);

            authService.SetStrategy(new OtpAuthStrategy("1111"));
            bool isOtpAuthSuccess = authService.Authenticate(user);

            authService.SetStrategy(new FaceIdAuthStrategy());
            bool isFaceAuthSuccess = authService.Authenticate(user);

        }
    } */
}