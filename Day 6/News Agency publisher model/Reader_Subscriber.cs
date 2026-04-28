using System;
using System.Collections.Generic;
using System.Text;

namespace _3_News_Agency_Publisher_Subscriber_Model {
    public class Reader {
        public string Name { get; private set; }

        private List<string> subscribedTopics = new List<string>();

        public Reader(string name) {
            Name = name;
        }

        public void SubscribeToTopic(string topic) {
            if (!subscribedTopics.Contains(topic)) {
                subscribedTopics.Add(topic);
                Console.WriteLine($"{Name} subscribed to {topic} news");
            }
        }

        public void UnsubscribeFromTopic(string topic) {
            if (subscribedTopics.Contains(topic)) {
                subscribedTopics.Remove(topic);
                Console.WriteLine($"{Name} unsubscribed from {topic} news");
            }
        }

        // This method is called when a news article is published
        public void ReceiveNews(NewsArticle article) {
            if (subscribedTopics.Contains(article.Topic)) {
                Console.WriteLine($"\n📰 {Name} received news:");
                Console.WriteLine(article.ToString());
            }
        }

        public List<string> GetSubscribedTopics() {
            return new List<string>(subscribedTopics);
        }
    }
}
