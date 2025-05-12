/* /* Use a LINQ query with a nested subquery to find the highest score for each student.
Filter for students who have at least one score > 80.
Select the student name and their highest score.
Output the results to the console in the format: "[Name]: Highest Score = [Score]". 
namespace Linq2
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
            var assignments = new List<(int StudentId, string AssignmentName, int Score)>
            {
                (1, "Math HW1", 85),
                (1, "Math HW2", 90),
                (2, "Science HW1", 75),
                (2, "Science HW2", 70),
                (3, "History HW1", 95)
            };
            var result = assignments.Where(x => x.Score > 80)
            .Join(
                students,
                ass => ass.StudentId,
                student => student.Id,
                (ass, student) => new {Name = student.Name, Score = ass.Score})
                .GroupBy(n => n.Name).Select(x => x.MaxBy(x => x.Score)).ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item?.Name} || Score: {item?.Score}");
            }
            
            

        }
    }
}
 */