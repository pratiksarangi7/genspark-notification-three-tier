using NotificationApp.BLLibrary;

namespace NotificationApp.ConsoleApp
{
    /// <summary>
    /// Entry point: console menu for the notification system.
    /// </summary>
    public class ConsoleApp
    {
        static void Main(string[] args)
        {
            // Initialize all BLL services
            UserService userService = new();
            NotificationService notificationService = new();
            string userIdInp;
            INotificationSender notificationSender;

            // Main menu loop
            while (true)
            {
                Console.WriteLine("\n== CHOICES ==");
                Console.WriteLine("\n1: Create new user");
                Console.WriteLine("2: Send Email");
                Console.WriteLine("3: Send SMS");
                Console.WriteLine("4: Update user details");
                Console.WriteLine("5: delete user");
                Console.WriteLine("6: Get all users");
                Console.WriteLine("7: Get all sent notifications");
                Console.WriteLine("8: Get notification by id");
                Console.WriteLine("9: Get all notifications sent to a particular user");
                Console.WriteLine("10: Exit");

                Console.Write("Select option: ");
                string choice = Console.ReadLine() ?? "";
                try
                {
                    switch (choice)
                    {
                        case "1":  // Create new user
                            Console.Write("Enter Name: ");
                            string createName = Console.ReadLine() ?? "";
                            Console.Write("Enter Email: ");
                            string createEmail = Console.ReadLine() ?? "";
                            Console.Write("Enter Phone Number: ");
                            string createPhone = Console.ReadLine() ?? "";
                            var result = userService.CreateUser(createName, createEmail, createPhone);
                            Console.WriteLine($"New User: {result.Name}, {result.Email}, {result.PhoneNumber} created successfully! \n");
                            break;

                        case "2":  // Send email
                            Console.Write("Enter user id: ");
                            userIdInp = Console.ReadLine() ?? "";
                            Console.Write("Enter email message: ");
                            string emailMsg = Console.ReadLine() ?? "";
                            notificationSender = new EmailNotificationService();
                            notificationService.NotifyUser(userIdInp, emailMsg, notificationSender, userService);
                            break;

                        case "3":  // Send SMS
                            Console.Write("Enter user id: ");
                            userIdInp = Console.ReadLine() ?? "";
                            Console.Write("Enter SMS message: ");
                            string smsMessage = Console.ReadLine() ?? "";
                            notificationSender = new SmsNotificationService();
                            notificationService.NotifyUser(userIdInp, smsMessage, notificationSender, userService);
                            break;

                        case "4":  // Update user
                            Console.Write("Enter user id for whom you want to update details: ");
                            string id = Console.ReadLine() ?? "";
                            var currUser = userService.GetUser(id);
                            Console.WriteLine($"User Details Are: {currUser.Name}, {currUser.PhoneNumber}, {currUser.Email}");
                            Console.WriteLine("Enter new user details");
                            Console.Write("Enter Name: ");
                            string newName = Console.ReadLine() ?? "";
                            Console.Write("Enter Email: ");
                            string newEmail = Console.ReadLine() ?? "";
                            Console.Write("Enter Phone Number: ");
                            string newPhone = Console.ReadLine() ?? "";
                            var updatedResult = userService.UpdateUser(id, newName, newEmail, newPhone);
                            Console.WriteLine($"New user details are: {updatedResult.Name}, {updatedResult.Email}, {updatedResult.PhoneNumber} \n");
                            break;
                        case "5":  // Delete user
                            Console.Write("Enter user id who you want to delete: ");
                            string deleteUserId = Console.ReadLine() ?? "";
                            var deletedUser = userService.DeleteUser(deleteUserId);
                            Console.WriteLine($"The user with details: {deletedUser.Name}, {deletedUser.Email}, {deletedUser.PhoneNumber} has been deleted \n");
                            break;

                        case "6":  // List all users
                            var users = userService.GetAllUsers();
                            Console.WriteLine("All User details:");
                            foreach (var user in users)
                            {
                                Console.WriteLine($"{user.Name}, {user.Email}, {user.PhoneNumber}");
                            }
                            Console.WriteLine("");
                            break;
                        case "7":  // List all notifications
                            Console.WriteLine("Printing all notifications: ");
                            var notifs = notificationService.GetAllNotifications();
                            foreach (var notif in notifs)
                            {
                                Console.WriteLine($"Message: {notif.Message}. Sent on {notif.SentDate}");
                            }
                            break;
                        case "8":  // Get notification by ID
                            Console.Write("Enter id of notification you want details of: ");
                            string notifId = Console.ReadLine() ?? "";
                            var resNotif = notificationService.GetSentNotificationDetails(notifId);
                            Console.WriteLine($"The notification details are: {resNotif.Message}, sent on {resNotif.SentDate}");
                            return;
                        case "9": // Get notifications sent to particular user
                            Console.Write("Enter user id for whom you want all the notifications that are sent:");
                            string userId = Console.ReadLine() ?? "";
                            var resNotifs = notificationService.GetNotificationsByUserId(userId);
                            Console.WriteLine($"All notifications sent to userId {userId} are: ");
                            foreach (var notif in resNotifs)
                            {
                                Console.WriteLine($"Message: {notif.Message}, sent date: {notif.SentDate}");
                            }
                            break;
                        case "10":  // Exit
                            Console.WriteLine("\nExiting program!\n");
                            return;

                        default:
                            Console.WriteLine("Invalid input. Please try again \n");
                            break;
                    }

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error occured: {e.Message}. Please try again");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Somethinw went wrong. {e.Message}");
                }
            }
        }
    }
}