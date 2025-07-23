public enum CourseCategory
{
    WebDevelopment,
    CSharpDevelopment,
    CPlusPlusDevelopment
}

public enum CourseType
{
    FrontEnd,
    BackEnd,
    FullStack,
    GameDev,
    GUI,
    GameDevUnreal
}



class Course 
{
    public string Name { get; private set; }
    public int Duration => CalculateCourseDuration();
    public double Price => CalculateCoursePrice();

    private List <Module>  _modules = new List<Module>();

    public int MaxCountOfStudents { get; private set; }

    public int CurrentCountOfStudents {get; set; }


    public Course (string name,  int maxCountOfStudents, int currentCountOfStudents = 0)
    {
        if (string.IsNullOrEmpty (name) ||  maxCountOfStudents <= 0)
            throw new ArgumentException ("invalid parameters for this object");

        if (currentCountOfStudents > maxCountOfStudents)
            throw new ArgumentException("Current count of students cannot exceed the maximum count.");

        Name = name;
        MaxCountOfStudents = maxCountOfStudents;
    }  

    private int CalculateCourseDuration()
    {
        return _modules.Sum(module => module.Duration);
    }
    private double CalculateCoursePrice()
    {
        double totalPrice = _modules.Sum(module => module.Price);
        return totalPrice * 0.8; 
    }

    public void ShowCourseInfo ()
    {
        Console.WriteLine($"""
                               Course Name: {Name}
                               Duration: {CalculateCourseDuration()} month
                               Price: {CalculateCoursePrice()} AMD
                               Modules: {ShowModules()}
                               MaxCountOfStudents: {MaxCountOfStudents}
                               Current count of students: {CurrentCountOfStudents}
                           """);
    }

    private string ShowModules()
    {
        return _modules.Count > 0 ? string.Join(", ", _modules.Select(c => c.Type)) : "No modules";
    }

    public void AddModule(Module module)
    {
        _modules.Add(module);
    }

}