using System;
using System.Collections.Generic;
using System.Text;

namespace Day4_Assignment
{
    internal class SocialMediaService
    {
        private List<string> posts = new List<string>();
        private Dictionary<string, int> likes = new Dictionary<string, int>();
        private HashSet<int> users = new HashSet<int>();
        private Stack<string> actions = new Stack<string>();
        private Queue<string> notifications = new Queue<string>();

        // Add user (HashSet ensures uniqueness)
        public void AddUser(int userId)
        {
            if (users.Add(userId))
                Console.WriteLine("User added.");
            else
                Console.WriteLine("User already exists.");
        }

        // Add post
        public void AddPost()
        {
            Console.Write("Enter post: ");
            string post = Console.ReadLine();

            posts.Add(post);
            likes[post] = 0;

            actions.Push($"POST:{post}");
            notifications.Enqueue($"New post added: {post}");

            Console.WriteLine("Post added.");
        }

        // Like a post
        public void LikePost()
        {
            Console.Write("Enter post to like: ");
            string post = Console.ReadLine();

            if (likes.ContainsKey(post))
            {
                likes[post]++;
                actions.Push($"LIKE:{post}");
                notifications.Enqueue($"Post liked: {post}");
                Console.WriteLine("Post liked.");
            }
            else
            {
                Console.WriteLine("Post not found.");
            }
        }

        // View posts with likes
        public void ViewPosts()
        {
            foreach (var post in posts)
            {
                Console.WriteLine($"{post} | Likes: {likes[post]}");
            }
        }

        // Undo last action (Stack)
        public void UndoAction()
        {
            if (actions.Count == 0)
            {
                Console.WriteLine("Nothing to undo.");
                return;
            }

            string last = actions.Pop();
            string[] parts = last.Split(':');

            string actionType = parts[0];
            string post = parts[1];

            if (actionType == "POST")
            {
                posts.Remove(post);
                likes.Remove(post);
                Console.WriteLine("Undo: Post removed.");
            }
            else if (actionType == "LIKE")
            {
                if (likes.ContainsKey(post) && likes[post] > 0)
                    likes[post]--;

                Console.WriteLine("Undo: Like removed.");
            }
        }

        // Process notifications (Queue FIFO)
        public void ProcessNotification()
        {
            if (notifications.Count == 0)
            {
                Console.WriteLine("No notifications.");
                return;
            }

            string note = notifications.Dequeue();
            Console.WriteLine("Processing: " + note);
        }

        // View unique users
        public void ViewUsers()
        {
            Console.WriteLine("Users:");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }

}
