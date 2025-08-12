namespace StructuralTask3
{
    interface ITaskItem
    {
        string GetName();
        void Display(int intend = 0);
        int GetTotalTasksCount();
    }

    class SimpleTask : ITaskItem
    {
        public string Name { get; }

        public SimpleTask(string name) => Name = name;

        public string GetName() => Name;
        public void Display(int intend = 0)
        {
            Console.WriteLine(new string('-', intend) + $"SimpleTask - Name : {Name}");
        }
        public int GetTotalTasksCount() => 1;
    }

    class CompositeTask : ITaskItem
    {
        private readonly string name;
        private readonly List<ITaskItem> list = new();

        public CompositeTask(string name) => this.name = name;

        public string GetName() => name;
        public void Add(ITaskItem item) => list.Add(item);

        public void Display(int intend = 0)
        {
            Console.WriteLine(new string('-', intend) + $"Composite task - Name : {name}");
            foreach (var item in list)
            {
                item.Display(intend + 2);
            }
        }

        public int GetTotalTasksCount()
        {
            int count = 0;
            foreach (var item in list)
            {
               count += item.GetTotalTasksCount(); 
            }
            return count;
        }
    }

    
}