using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace TaskModel
{
    enum TaskPriority
    {
        Low, Medium, High
    }
     class TaskItem
    {
        public int Id { get; }
        public string Title { get; private set; }
        public TaskPriority Priority { get; private set; }
        public DateTime DeadLine { get; private set; }
        public bool IsCompleted { get; private set; } = false;

        private static int _counter = 0;
        public TaskItem(string title, TaskPriority priority, DateTime deadline, bool isCompleted)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty", nameof(title));

            if (deadline < DateTime.Now)
                throw new ArgumentException("Deadline cannot be in the past", nameof(deadline));

            Id = _counter++;
            Title = title;
            Priority = priority;
            DeadLine = deadline;
            IsCompleted = isCompleted;
        }

        public void MarkTaskAsCompleted()
        {
            IsCompleted = true;
        }
        public override string ToString()
        {
            var completed = IsCompleted ? "✓" : " ";
            return $"[{completed}] ({Priority}) (Id){Id} - {Title} - Deadline: {DeadLine}";
        }
    }



    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private const string Format = "dd-MM-yyyy"; 

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), Format, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }


}
