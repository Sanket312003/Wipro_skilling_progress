// IN a publisher subcriber model, the publisher is responsible for sending messages or
// events to subscribers.
// The publisher does not need to know who the subscribers are or how they will handle
// the messages.
// The subscribers can choose to subscribe to specific types of messages or events that
// they are interested in.

// Problemstatement based on real world use case :
// Consider a news agency that publishes news articles on various topics such as sports,
// politics, and entertainment.
// The news agency acts as the publisher, while the readers who subscribe to the news
// articles are the subscribers.
// The news agency can publish articles on different topics, and the readers can choose
// to subscribe to the topics they are interested in.

// Step by step implementation of publisher subscriber model:
//Step bystep implementation of publisher subscriber model in C#:
//Step 1: Define the Publisher class ex : NewsAgency
//Step 2: Define the Subscriber class ex : Reader
//Step 3: Implement the subscription mechanism in the Publisher class ex: Subscribe method
//Step 4: Implement the notification mechanism in the Publisher class ex: Publish method
//Step 5: Create instances of the Publisher and Subscriber classes and
//demonstrate the functionality.

using _3_News_Agency_Publisher_Subscriber_Model;
using System.Reflection.Metadata;

Console.WriteLine("=== News Agency Publisher-subsriber Demo ===");


// Srtep 7:- Create Publisher (News Agency)
NewsAgency NDTV = new NewsAgency("NDTV news Agency");
NewsAgency BBC = new NewsAgency("BBC news Agency");

// Step 8:- Create Subscriber (Readers)
Reader rish = new Reader("Rishabh");
Reader glory = new Reader("Glory");
Reader akansha = new Reader("Akansha");
Reader shalini = new Reader("Shalini");
Reader anil = new Reader("Anil");

// Step 9:- Readers subcribe to specific topics.

rish.SubscribeToTopic("Sports");
rish.SubscribeToTopic("Technology");
rish.SubscribeToTopic("Space");
rish.SubscribeToTopic("Politics");

glory.SubscribeToTopic("Drawing");
glory.SubscribeToTopic("Singing");
glory.SubscribeToTopic("Art");
glory.SubscribeToTopic("Artifacts");
glory.SubscribeToTopic("Entertainment");
glory.SubscribeToTopic("Drama");

akansha.SubscribeToTopic("Fashion");
akansha.SubscribeToTopic("Management");
akansha.SubscribeToTopic("Entertainment");
akansha.SubscribeToTopic("Hollywood");

shalini.SubscribeToTopic("Books");
shalini.SubscribeToTopic("Poetry");
shalini.SubscribeToTopic("Writing Skills");
shalini.SubscribeToTopic("Food");
shalini.SubscribeToTopic("Food");

anil.SubscribeToTopic("Politics");
anil.SubscribeToTopic("Daily feeds");
anil.SubscribeToTopic("Stocks and Market");
anil.SubscribeToTopic("Law");
anil.SubscribeToTopic("Business");


// Step 10:- News Agency adds Readers(Subscribers)
NDTV.Subscribe(rish);
NDTV.Subscribe(anil);

BBC.Subscribe(rish);
BBC.Subscribe(glory);
BBC.Subscribe(akansha);
BBC.Subscribe(shalini);


Console.WriteLine($"\n📊 Subscriber Statistics:");
Console.WriteLine($"BBC News has {BBC.GetSubscriberCount()} active listeners");
Console.WriteLine($"NDTV has {NDTV.GetSubscriberCount()} active listeners\n");


// Step 11: Publish different types of news
Console.WriteLine("=== PUBLISHING NEWS ARTICLES ===\n");

// Publish Sports news
BBC.PublishNews("Sports", "World Cup Final",
    "Exciting match ends with a stunning victory in overtime!");
Thread.Sleep(1000); // Small delay for readability

// Publish Politics news
BBC.PublishNews("Politics", "Election Results",
    "New government announces major policy changes.");
Thread.Sleep(1000);

// Publish Technology news
BBC.PublishNews("Technology", "AI Breakthrough",
    "New AI model achieves human-level performance in complex tasks.");
Thread.Sleep(1000);

// Publish Entertainment news
BBC.PublishNews("Entertainment", "Movie Awards",
    "Surprise winner takes home best picture at annual awards.");
Thread.Sleep(1000);

// Publish Sports news from CNN
NDTV.PublishNews("Sports", "Olympic Updates",
    "New world record set in swimming competition.");

// Step 12: Demonstrate unsubscribe functionality
Console.WriteLine("\n=== DEMONSTRATING UNSUBSCRIBE ===\n");
Console.WriteLine("Bob decides to unsubscribe from Politics news");
anil.UnsubscribeFromTopic("Politics");

Console.WriteLine("\nPublishing Politics news after Bob unsubscribed:");
BBC.PublishNews("Politics", "International Summit",
    "World leaders gather to discuss climate change policies.");

Console.WriteLine("\n=== DEMO COMPLETE ===");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

