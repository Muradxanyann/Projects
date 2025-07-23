enum EmployeRole
{
    Cleaner,
    Instructor,
    Bookkeeper,
    Deputy_Director, 
    Director
}



class School
{
    private string _name;
    
    private string _email;

    private string _phoneNumber;

    private  List<Student> _students = new List<Student>();
    private List<Instructor> _instructors = new List<Instructor>();

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
    public string Email 
    {
        get { return _email; }
        set 
        {
            if (value.EndsWith("@mail.com") || value.EndsWith("@gmail.com") || value.EndsWith("@mail.ru"))
            {
                _email = value;
                return;
            }
                
            throw new ArgumentException("Invlaid email");
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

   

    public School(string name, string email, string phoneNumber)
    {
        Name = name;
        Email  = email;
        PhoneNumber = phoneNumber;
        
    }

    public Student this[int index, EmployeRole userRole]
    {
        get
        {
            if (index < 0 || index >= _students.Count)
                throw new IndexOutOfRangeException("Invalid index");

            if (userRole == EmployeRole.Cleaner)
                throw new Exception("Not Enough Role");

            return _students[index];
        }
    }


    public Instructor this[string name, EmployeRole userRole]
    {
        get
        {
            var instructor = _instructors.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (instructor == null)
                throw new Exception("Instructor not found");

            if (userRole != EmployeRole.Deputy_Director && userRole != EmployeRole.Director)
                throw new Exception("Not enough role");
        
            return instructor;
        }
    }
    

    public void AddStudent (Student student)
    {
        
        _students.Add(student);
    }

    public void RemoveStudent (int id)
    {
        int index =_students.FindIndex(i => i.Id.Equals(id));
        if (index == -1) 
        {
            System.Console.WriteLine("Student id not found");
        }
        _students.RemoveAt(index);
    }

    public void AddCourse (Course course)
    {
        
        _courses.Add(course);
    }

    public void AddInstructor (Instructor instructor)
    {
        _instructors.Add(instructor);
    }


    public void RemoveInstructor (int id)
    {
        int index =_instructors.FindIndex(i => i.Id.Equals(id));
        if (index == -1) 
        {
            Console.WriteLine("Student id not found");
        }
        _instructors.RemoveAt(index);
    }

    public void DisplayStudentInfo(int id)
    {
        foreach (Student student in _students)
        {
            if (student.Id.Equals(id))
                student.ShowStudentInfo();
        }
    }

    public void DisplayInstructorInfo(int id)
    {
        foreach (Instructor instructor in _instructors)
        {
            if (instructor.Id.Equals(id))
                instructor.ShowInstructorInfo();
        }
    }

    public void DisplaySchoolInfo()
    {
        Console.WriteLine($"""
            School Name: {Name}
            Email: {Email}
            Number: {PhoneNumber}
            Students: {_students.Count()}
            Instructor: {_instructors.Count()}
        """);
    }
}