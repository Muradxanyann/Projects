class Student
{
    private string _name;

    private static int _id;
    private string _email;

    private string _phoneNumber;

    private string _parentPhoneNumber;

    private List<Course> _courses = new List<Course>();
    
    public string Name 
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Any(char.IsDigit) || value.Length < 2)
                throw new ArgumentException("Invalid input");
            _name = value;
        }
    }
    public int Id {get; private set;}
    public string Email 
    {
        get { return _email; }
        set 
        {
            if (value.EndsWith("@mail.com") || value.EndsWith("@gmail.com") || value.EndsWith("@mail.ru") || value.EndsWith("@yahoo.com") || value.EndsWith("@outlook.com"))
            {
                _email = value;
                return;
            }
                
            throw new ArgumentException("Invalid email");
        }
    }

    public string PhoneNumber 
    {
        get { return _phoneNumber; }
        set
        {
            if (!(value.StartsWith("+374") && value.Length == 12) && !(value.StartsWith("0") && value.Length == 9))
                throw new ArgumentException("Invalid Number"); 
            _phoneNumber = value;
        }
    }

    public string ParentPhoneNumber 
    {
        get { return _parentPhoneNumber; }
        set
        {
            if (!(value.StartsWith("+374") && value.Length == 12) && !(value.StartsWith("0") && value.Length == 9))
                throw new ArgumentException("Invalid Number");
            _parentPhoneNumber = value;
        }
    }

    public Student(string name, string email, string phoneNumber, string parentPhoneNumber)
    {
        Name = name;
        Email  = email;
        PhoneNumber = phoneNumber;
        ParentPhoneNumber = parentPhoneNumber;
        Id = ++_id;
    }

     public void ShowStudentInfo()
    {
        Console.WriteLine($"""
            Name: {Name}
            Id: {Id}
            Email: {Email}
            Phone Number: {PhoneNumber}
            Parent Phone Number: {ParentPhoneNumber}
            Courses: {ShowCourses()}
            """);
    }

    private string ShowCourses()
    {
        return _courses.Count > 0 ? string.Join(", ", _courses.Select(c => c.Name)) : "No courses";
    }
    public void AddCourse(Course course)
    {
        _courses.Add(course);
        course.CurrentCountOfStudents++;
    }
    

}