using System;
using System.Collections.Generic;
using System.Text;

namespace _3_News_Agency_Publisher_Subscriber_Model {
        // Step 1: Define delegate for event handling
    public delegate void NewsPublishedEventHandler(NewsArticle article);

    public class NewsAgency {
        public string Name { get; private set; }

        // Step 2: Define event that subscribers can listen to
        public event NewsPublishedEventHandler NewsPublished;

        public NewsAgency(string name) {
            Name = name;
        }

        // Step 3: Subscribe method - allows readers to start receiving news
        public void Subscribe(Reader reader) {
            NewsPublished += reader.ReceiveNews;
            Console.WriteLine($"{reader.Name} is now receiving news from {Name}");
        }

        // Step 4: Unsubscribe method - allows readers to stop receiving news
        public void Unsubscribe(Reader reader) {
            NewsPublished -= reader.ReceiveNews;
            Console.WriteLine($"{reader.Name} is no longer receiving news from {Name}");
        }

        // Step 5: Publish method - sends news to all subscribers
        public void PublishNews(string topic, string title, string content) {
            NewsArticle article = new NewsArticle(topic, title, content);
            Console.WriteLine($"\n📢 {Name} Publishing: [{topic}] {title}");

            // Step 6: Trigger the event to notify all subscribers
            OnNewsPublished(article);
        }

        // Protected virtual method to allow derived classes to override the event invocation
        protected virtual void OnNewsPublished(NewsArticle article) {
            NewsPublished?.Invoke(article);
        }

        // Method to show current subscriber count
        public int GetSubscriberCount() {
            return NewsPublished?.GetInvocationList().Length ?? 0;
        }
    }
}
