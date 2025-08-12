namespace ToDoModel
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Body { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;

    }
}
