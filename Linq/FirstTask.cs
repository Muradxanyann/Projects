using System.Xml;

namespace Linq
{
    public class Student
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public int Age { get;  set; }
        public int DepartmentId { get; set; }
        public List<int> EnrolledCourseIds { get; set; } = new();
    }
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        
    }
    public class Course
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        
    }
    class Subject
    {
        public required string Name { get; set; }
        public int DepartmentId { get; set; }
        public Subject(string name, int departmentId)
        {
            Name = name;
            DepartmentId = departmentId;
        }
    }
    /* static class Program
    {
        static void Main()
        {
            var departments = new List<Department>
            {
                new Department { Id = 1, Name = "Computer Science" },
                new Department { Id = 2, Name = "Mathematics" },
                new Department { Id = 3, Name = "Physics" },
                new Department { Id = 4, Name = "Biology" },
                new Department { Id = 5, Name = "Literature" },
            };

            var courses = new List<Course>
            {
                new Course { Id = 1, Title = "Algorithms", Credits = 3, DepartmentId = 1 },
                new Course { Id = 2, Title = "Calculus", Credits = 4, DepartmentId = 1 },
                new Course { Id = 3, Title = "Quantum Mechanics", Credits = 4, DepartmentId = 3 },
                new Course { Id = 4, Title = "Genetics", Credits = 3, DepartmentId = 2 },
                new Course { Id = 5, Title = "Shakespearean Literature", Credits = 2, DepartmentId = 1 },
            };

            var students = new List<Student>
            {
                new Student { Id = 1, FullName = "Alice Johnson", Age = 18, DepartmentId = 1, EnrolledCourseIds = new List<int> { 1, 2 } },
                new Student { Id = 2, FullName = "Bob Smith", Age = 15, DepartmentId = 1, EnrolledCourseIds = new List<int> { 2 } },
                new Student { Id = 3, FullName = "Charlie Brown", Age = 19, DepartmentId = 1, EnrolledCourseIds = new List<int> { 3, 1 } },
                new Student { Id = 4, FullName = "Diana Prince", Age = 20, DepartmentId = 4, EnrolledCourseIds = new List<int> { 4 } },
                new Student { Id = 5, FullName = "Edward Blake", Age = 21, DepartmentId = 5, EnrolledCourseIds = new List<int> { 4 } },
            };

            //Գտնել Computer Science դեպարտամենտի ուսանողներին            
            var csStudents = departments.Join(
                students,
                d => d.Id,
                s => s.DepartmentId,
                (d, s) => new {Department = d, Student = s})
                .Where(x => x.Department.Name == "Computer Science").Select(x => x.Student).ToList();
                //Գտնել այն կուրսերը, որտեղ ոչ մի ուսանող չկա
            var uniqueCourses = students
                .SelectMany(s => s.EnrolledCourseIds)
                .Distinct();
            var emptyCourses = courses.Where(x => !uniqueCourses.Contains(x.Id)).ToList();
           

            //Computer Science -ի բաժնում դասավանդվող առարկաների ցուցակը
            var csCourses = departments.Join(
                courses,
                departament => departament.Id,
                course => course.DepartmentId,
                (department, course) => new {Departament = department, Course = course})
                .Where(x => x.Departament.Name == "Computer Science")
                .Select(x => x.Course).ToList();
            //Գտնել այն դեպարտամենտները, որտեղ 2-ից ավել ուսանող կա
            var moreThanTwo = students.GroupBy(x => x.DepartmentId)
            .Where(g => g.Count() > 2)
            .Join(
                departments,
                g => g.Key,
                d => d.Id,
                (g, d) => d
            ).ToList();
            foreach (var item in moreThanTwo)
            {
                Console.WriteLine(item.Name);
            }
            //Գտնել տարիքով ամենափոքր ուսանողի դեպարտմանետի անունը
            var departamentName = students.Where(x => x.Age == students.Min(x => x.Age))
            .Join(
                departments,
                s => s.DepartmentId,
                d => d.Id,
                (s, d) => d.Name
            ).FirstOrDefault();
            
            //Ո՞ր դեպարտամենտում են ամենաշատ առարկաները դասավանդվում 
            var famousCourseId = courses.GroupBy(x => x.DepartmentId).OrderByDescending(y => y.Count()).First();
            var id = famousCourseId.Key;
            var famousCourse = departments.Where(d => d.Id == id).Select(d => d.Name).FirstOrDefault();
           


        }
    } */
}
