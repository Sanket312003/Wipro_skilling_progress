using System;
using System.Collections.Generic;
using System.Text;

namespace _3_News_Agency_Publisher_Subscriber_Model {
    public class NewsArticle {
        public string Topic { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }

        public NewsArticle(string topic, string title, string content) {
            Topic = topic;
            Title = title;
            Content = content;
            PublishedDate = DateTime.Now;
        }

        public override string ToString() {
            return $"[{Topic.ToUpper()}] {Title}\nPublished: {PublishedDate:HH:mm:ss}\n{Content}\n";
        }
    }
}
