/* /* Use LINQ to join the three lists and filter for courses with a difficulty level > 3.
Select the student name, course name, and difficulty level.
Order the results by student name.
Output the results to the console in the format: 
"[Name] is enrolled in [CourseName] (Difficulty: [Difficulty])". 

namespace Linq
{
    static class Program
    {
        static void Main(string[] args)
        {
            var students = new List<(int Id, string Name)>
            {
                (1, "Alice"),
                (2, "Bob"),
                (3, "Charlie")
            };

            var enrollments = new List<(int StudentId, int CourseId)>
            {
                (1, 101),
                (1, 102),
                (2, 102),
                (3, 103)
            };

            var courses = new List<(int CourseId, string CourseName, int Difficulty)>
            {
                (101, "Math", 4),
                (102, "Science", 4),
                (103, "History", 2)
            };

            var result = courses.Where(c => c.Difficulty > 3)
            .Join(
                enrollments,
                course => course.CourseId,
                enrollment => enrollment.CourseId,
                (course, enrollment) => new {StudentId = enrollment.StudentId, CourseName = course.CourseName, Difficulty = course.Difficulty})
                .Join(
                    students,
                    type => type.StudentId,
                    student => student.Id,
                    (type, student) => new {Name = student.Name, Course = type.CourseName, Difficulty = type.Difficulty})
                    .OrderBy(n => n.Name);
            foreach (var info in result)
            {
                Console.WriteLine($"{info.Name} is enrolled in {info.Course} (Difficulty: {info.Difficulty})");
            }
                    

                   
                
                
                
                

        }
    }
} */