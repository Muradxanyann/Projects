class Module
{
    public CourseCategory Category { get; private set; }
    public CourseType Type{ get; private set; }
    

    public Instructor instructor{ get; private set; }
    public int Duration { get; private set; }
    public double Price{ get; private set; }
 
    public Module (CourseCategory category, CourseType type, Instructor instructor,  int duration, double price )
    {
        Category = category;
        Type = type;
        Duration = duration;
        Price = price;
        this.instructor = instructor;
    }

    public void ShowModuleInfo()
    {
        System.Console.WriteLine($"""
                                      Category: {Category}
                                      Type: {Type}
                                      Duration: {Duration}
                                      Price: {Price}
                                      Instructor: {instructor.Name}
                                  """);
    }
}