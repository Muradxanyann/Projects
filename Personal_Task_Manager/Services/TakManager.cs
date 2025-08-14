using System.Threading.Tasks;
using System.Text.Json;
using TaskModel;
using System.Threading.Tasks.Dataflow;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Linq;


namespace App
{
    static class TaskManager
    {
        private static HashSet<TaskItem> tasks = new();
        public static async Task RunAsync()
        {
            tasks = new HashSet<TaskItem>();
            string folder = Environment.CurrentDirectory;
            string path = Path.Combine(folder, "tasks.json");//will find the path in the current environment
            if (!File.Exists(path))
            {
                await File.WriteAllTextAsync(path, "[]");
                tasks = new HashSet<TaskItem>();
            }
            else
            {
                var jsonText = await File.ReadAllTextAsync(path);
                try
                {
                    //for getting format dd-mm-yyyy
                    var options = new JsonSerializerOptions();
                    options.Converters.Add(new DateTimeConverter());
                    tasks = JsonSerializer.Deserialize<HashSet<TaskItem>>(jsonText, options);
                }
                catch (JsonException) //protect program - during deserialize can be throw JsonException
                {
                    tasks = new HashSet<TaskItem>();
                    Console.WriteLine("File tasks.json corrupted. A new empty task lsit has been created.");
                }
            }
            int operation;
            bool success;
            do
            {
                Console.WriteLine("""
                Choose the operation:
                1 - Read
                2 - Write
                3 - Update
                4 - Delete
                """);
                string answer = Console.ReadLine();
                success = int.TryParse(answer, out operation);
                if (!success)
                    Console.WriteLine("Incorrect input. Enter a number between 1 and 4.");
            } while (!success || operation < 1 || operation > 4);
            switch (operation)
            {
                case 1:
                    await Read();
                    break;
                case 2:
                    await Write();
                    break;
                case 3:
                    await Update();
                    break;
                case 4:
                    await Delete();
                    break;
            }
        
        }
        public async static Task Read()
        {
            await ReadHelper();
        }
        public static async Task Write()
        {
            var (title, priority, deadline) = WriteHelper();
            var task = new TaskItem(title, priority, deadline, false);
            tasks.Add(task);
            Console.WriteLine(tasks.Count);
            await SaveTasksToFile(tasks);
        }



        public static async Task Update()
        {
            await UpdateHelper();
        }

        private static async Task UpdateHelper()
        {
            int id;
            bool succeed;
            do
            {
                Console.WriteLine("Give an id of the task for update");
                string answer = Console.ReadLine();
                succeed = int.TryParse(answer, out id);
                if (!succeed)
                    Console.WriteLine("WARNING!!! Enter valid id");
            } while (!succeed);
            var updatedTask = tasks.Select(c => c).First();
            if (updatedTask == null)
            {
                Console.WriteLine($"There is not any task with id {id}");
                return;
            }
            updatedTask.MarkTaskAsCompleted();
            await SaveTasksToFile(tasks);
        }

        public static async Task Delete()
        {
            await DeleteHelper();
        }

        private static async Task DeleteHelper()
        {
            int id;
            bool succeed;
            do
            {
                Console.WriteLine("Give an id of the task for delete");
                string answer = Console.ReadLine();
                succeed = int.TryParse(answer, out id);
                if (!succeed)
                    Console.WriteLine("WARNING!!! Enter valid id");
            } while (!succeed);
            var updatedTask = tasks.Where(c => c.Id == id).First();
            if (updatedTask == null)
            {
                Console.WriteLine($"There is not any task with id {id}");
                return;
            }
            tasks.Remove(updatedTask);
            await SaveTasksToFile(tasks);
        }

        private static (string title, TaskPriority priority, DateTime deadline) WriteHelper()
        {
            //Write Helper function
            string title;
            do
            {
                Console.WriteLine("Input name for task");
                title = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(title) || string.IsNullOrEmpty(title));

            TaskPriority priority = default;
            int operation;
            bool succeed;
            do
            {
                Console.WriteLine("""
                Choose the priority:
                1 - Low
                2 - Medium 
                3 - High
                """);
                string answer = Console.ReadLine();
                succeed = int.TryParse(answer, out operation);
            } while (!succeed || operation < 1 || operation > 3);
            switch (operation)
            {
                case 1:
                    priority = TaskPriority.Low;
                    break;
                case 2:
                    priority = TaskPriority.Medium;
                    break;
                case 3:
                    priority = TaskPriority.High;
                    break;
                
            }

            DateTime parsedDateTime;
            bool isValid;
            do
            {
                Console.WriteLine("Enter the deadline for this task(Format. dd-MM-yyyy)");

                string dateString = Console.ReadLine();
                isValid = DateTime.TryParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDateTime);
            } while (!isValid);
            return (title, priority, parsedDateTime);

        }
        private static Task ReadHelper()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("There isn't any task in the file");
                return Task.CompletedTask;
            }
            Console.WriteLine("Sorting By");
            int operation;
            bool success;
            do
            {
                Console.WriteLine("""
                1 - By Priority
                2 - By Deadline
                """);
                string answer = Console.ReadLine();
                success = int.TryParse(answer, out operation);
                if (!success)
                    Console.WriteLine("Incorrect input. Enter a number between 1 and 2.");
            } while (!success || operation < 1 || operation > 2);
            if (operation == 1)
            {
                var list = tasks.OrderBy(t => t.Priority).ToList();
                list.ForEach(Console.WriteLine);
            }
            else if (operation == 2)
            {
                var list = tasks.OrderBy(t => t.DeadLine).ToList();
                list.ForEach(Console.WriteLine);
            }
            return Task.CompletedTask;
        }
        public static async Task SaveTasksToFile(HashSet<TaskItem> list)
        {
            //Automatic task saver in tasks.Json
            string folder = Environment.CurrentDirectory;
            string path = Path.Combine(folder, "tasks.json");
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                }; // for getting format "dd-MM-yyyy"
                options.Converters.Add(new DateTimeConverter());

                var json = JsonSerializer.Serialize(list, options);
                await File.WriteAllTextAsync(path, json);
            }
            catch (IOException)
            {
                Console.WriteLine("Some problem during serilazation");
                return;
            }
            Console.WriteLine("File updated succsessfully");

        }
    }

}