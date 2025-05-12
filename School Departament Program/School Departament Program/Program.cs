class Program 
{
    static void Main(string[] args)
    {
        School school = new School("High School", "HighSchool@gmail.com", "+37499007744");

        List<Student> students = new List<Student>
        {
            new Student("Leo", "Leo@mail.com", "+37478732293", "093443344"),
            new Student("John", "John@gmail.com", "+37478732293", "093443344")
        };
        
        List<Instructor> instructors = new List<Instructor>
        {
            new Instructor("Ms. Smith", "Smith@gmail.com", "098765432"),
            new Instructor("Ms. Parker", "Parker@gmail.com", "098765432"),
            new Instructor("Ms. Bublik", "Bublik@gmail.com", "098765432")
        };
        

       List<Module> modules = new List<Module>
        {
            new Module(CourseCategory.CSharpDevelopment, CourseType.BackEnd, instructors[0], 6, 49000),
            new Module(CourseCategory.CSharpDevelopment, CourseType.GameDev, instructors[0], 6, 49000),
            new Module(CourseCategory.WebDevelopment, CourseType.FrontEnd, instructors[1], 3, 59000),
            new Module(CourseCategory.WebDevelopment, CourseType.BackEnd, instructors[1], 6, 59000),
            new Module(CourseCategory.WebDevelopment, CourseType.FullStack, instructors[1], 9, 59000),
            new Module(CourseCategory.CPlusPlusDevelopment, CourseType.GameDevUnreal, instructors[2], 8, 79000),
            new Module(CourseCategory.CPlusPlusDevelopment, CourseType.GUI, instructors[2], 10, 79000)
        
        };
        
        List<Course> courses = new List<Course>
        {
            new Course("C#", 30),
            new Course("Web development", 50),
            new Course("C++", 28)
        };
        courses[0].AddModule(modules[0]);
        courses[0].AddModule(modules[1]);

        courses[1].AddModule(modules[2]);
        courses[1].AddModule(modules[3]);
        courses[1].AddModule(modules[4]);

        courses[2].AddModule(modules[5]);
        courses[2].AddModule(modules[6]);

        students[0].AddCourse(courses[0]);

        

        foreach(var sc in students)
        {
            school.AddStudent(sc);
        }
        foreach(var sc in instructors)
        {
            school.AddInstructor(sc);
        }
        foreach(var sc in courses)
        {
            school.AddCourse(sc);
        }
        school.DisplaySchoolInfo();
    
         
    }
}