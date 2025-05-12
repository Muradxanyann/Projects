/* You have two lists: students and submissions. Not all students have submitted assignments.
 Write a LINQ query to list all students and their submission count (0 if none),
  including students with no submissions.
Use LINQ to simulate a left join, counting the number of submissions per student.
Select the student name and their submission count (0 for students with no submissions).
Order the results by submission count (descending).
Output the results to the console in the format: "[Name]: [SubmissionCount] submissions". */

namespace task3
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
            var submissions = new List<(int StudentId, string AssignmentName)>
            {
                (1, "Math HW1"),
                (1, "Math HW2"),
                (2, "Science HW1")
            };
            var result = students.GroupJoin(
                submissions,
                student => student.Id,
                ass => ass.StudentId,
                (student, ass) => 
                new 
                {
                    Name = student.Name,
                    SubmissionsCount = ass.Count()
                }           
            ).OrderByDescending(x => x.SubmissionsCount);
            foreach (var item in result)
            {
                Console.WriteLine($"Name: {item.Name} || Sub count { item.SubmissionsCount} ");
            }
        }
    }
}
