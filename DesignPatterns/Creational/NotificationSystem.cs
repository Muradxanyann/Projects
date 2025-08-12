/* Design a system where depending on the user input,
 you can create different types of Notification objects (EmailNotification, SMSNotification, PushNotification).
Each notification type should have a method to send the notification. */

using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.Arm;

namespace Task3
{
    public interface INotificationSystem
    {
        void SendNotification();
    }

    class EmailNotification : INotificationSystem
    {  
        
        public void SendNotification()
        {
            Console.WriteLine("Notif send by Email successfully");
        }
    }

    class SmsNotification : INotificationSystem
    {
        public void SendNotification()
        {
            Console.WriteLine("Notif send by Sms successfully");
        }
    }

    class PushNotification : INotificationSystem
    {
        
        public void SendNotification()
        {
             Console.WriteLine("Push Notif send successfully");
        }   
        
    }

    public static class NotificationFactory
    {
        public static INotificationSystem CreateNotification(string type)
        {
        
            string lowerType = type.ToLower();
            switch (lowerType)
            {
                case "email":
                    return new EmailNotification(); 
                case "sms":
                    return new SmsNotification(); 
                case "push":
                    return new PushNotification(); 
                default:
                    throw new ArgumentException($"Unknown type: {type}");
            }
        }
    }

   

}
