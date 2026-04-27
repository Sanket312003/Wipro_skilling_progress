using System;
using System.Collections.Generic;

namespace Day4_Assignment
{
    class Program
    {
        static void Main()
        {
            SocialMediaService service = new SocialMediaService();

            while (true)
            {
                Console.WriteLine("\n1. Add User");
                Console.WriteLine("2. Add Post");
                Console.WriteLine("3. Like Post");
                Console.WriteLine("4. View Posts");
                Console.WriteLine("5. Undo Action");
                Console.WriteLine("6. Process Notification");
                Console.WriteLine("7. View Users");
                Console.WriteLine("8. Exit");

                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter User ID: ");
                        int userId = int.Parse(Console.ReadLine());
                        service.AddUser(userId);
                        break;

                    case 2:
                        service.AddPost();
                        break;

                    case 3:
                        service.LikePost();
                        break;

                    case 4:
                        service.ViewPosts();
                        break;

                    case 5:
                        service.UndoAction();
                        break;

                    case 6:
                        service.ProcessNotification();
                        break;

                    case 7:
                        service.ViewUsers();
                        break;

                    case 8:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}