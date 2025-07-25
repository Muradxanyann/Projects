namespace BehaviouralTask4
{
    public enum NewsCategory
    {
        Politics,
        Sports,
        Tech
    }

    class NewsAgency
    {
        private readonly Dictionary<NewsCategory, Action<string>> handlers = new();
        public void Subscribe(NewsCategory category, Action<string> handler)
        {
            if (handlers.ContainsKey(category))
            {
                handlers[category] += handler;
            }
            else
            {
                handlers.Add(category, handler);
            }

        }
        public void Unsubscribe(NewsCategory category, Action<string> handler)
        {
            if (handlers.ContainsKey(category))
            {
                handlers.Remove(category);
            }
        }

        public void Publish(NewsCategory category, string headline)
        {
            if (handlers.TryGetValue(category, out var handler))
            {
                handler?.Invoke(headline);
            }
        }

    }

    class Subscriber
    {
        public string Name { get; private set; }
        public Subscriber(string name) => Name = name;

        public void Receive(string headline)
        {
            Console.WriteLine($"[{Name}] [{headline}]");
        }
    }

   /*  static class Program
    {
        static void Main(string[] args)
        {
            var agency = new NewsAgency();

            var alice = new Subscriber("Alice");
            var bob = new Subscriber("Bob");
            var chris = new Subscriber("Chris");

            // Subscriptions
            agency.Subscribe(NewsCategory.Tech, headline => alice.Receive($"Tech {headline}"));
            agency.Subscribe(NewsCategory.Politics, headline => alice.Receive($"Politics: {headline}"));

            agency.Subscribe(NewsCategory.Sports, headline => bob.Receive($"Sport: {headline}"));
            agency.Subscribe(NewsCategory.Tech, headline => bob.Receive($"Tech: {headline}"));

            agency.Subscribe(NewsCategory.Politics, chris.Receive);

            // Publishing news
            agency.Publish(NewsCategory.Tech, "🧠 AI Beats Human in Chess Again");
            agency.Publish(NewsCategory.Politics, "🗳 New Election Date Announced");
            agency.Publish(NewsCategory.Sports, "⚽ Local Team Wins Championship");

            // Alice unsubscribes from Politics
            agency.Unsubscribe(NewsCategory.Politics, alice.Receive);

            agency.Publish(NewsCategory.Politics, "🏛 Parliament Passes New Law");
        }
    } */

}