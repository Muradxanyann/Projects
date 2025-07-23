class Instructor
{
    private string _name;
    private static int _id;
    private string _email;
    private string _phoneNumber;

    
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


    public Instructor (string name, string email, string phoneNumber )
    {
        Name = name;
        Email  = email;
        PhoneNumber = phoneNumber;
        Id = ++_id;
    }

    public void ShowInstructorInfo()
    {
        Console.WriteLine($"""
                           Name: {Name}
                           Id: {Id}
                           Email: {Email}
                           Phone Number: {PhoneNumber}
                           """);
    }

   

}