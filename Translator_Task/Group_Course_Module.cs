using System;
using System.ComponentModel;
using System.Text;

/* Առաջադրանք:
Ստեղծել, Course, Group, Module կլասները
Course - ինֆորմացիա է պարունակում դասընթացի մասին
(անուն,  ամսավճար, մոդուլներ)
Module - ինֆորմացիա է պարունակում դասընթացի առանձին կտորի մասին
(վերնագիր, տևողություն)
Group - Ներկայացնում է խմբի տվյլաները
(անուն, ուսանողների քանակ, կուրս)
Course կլասից ժառանգվում են Web, Game, AI  կլասները
ընդ որում Web-ը ունի նաև type դաշտ, որը կարող է լինել frontend, backend, fullstack
Game-ը ունի engine դաշտ, որը կարող է լինել unity, unreal:
Course,Module և Group, Course կապը has a է, իսկ Course=>Web,Game,Ai -ը is a: 


գտնել վեբ սովորող ուսանողների քանակը (ենթադրվում է, որ կարող են լինել տարբեր վեբի խմբեր)
գտնել որքան գումար կկուտակվի մեկ ամսում Unreal engine-ի շրջանակներում Game Dev սովորող ուսանողների վճարած գումարից
գտնել ամենապահանջված դասընթացը (ուսանողների քանակով)

*/

class Module
{
    public string Title { get; private set; }
    public int Duration { get; private set; }

    public Module (string title, int duration /* in months */)
    {
        Title = title;
        Duration = duration;
    }
    public override string ToString() => $"{Title} ({Duration} months)";
}
class Course 
{
    public  string CourseName { get; protected set; }
    public  int Payment {get; protected set; }

    public  Module[] Modules { get; protected set; }


    

    public Course (string courseName, int payment, Module[] modules) // for agregation
    {
        CourseName = courseName;
        Payment = payment;
        Modules = modules;
    }

    public Module this [int index]
    {
        get
        {
            if (index < 0 || index >= Modules.Length)
            {
                throw new ArgumentException("Index out of range");
            }
            return Modules [index];
        }
    }

    public override string ToString() 
    {
        return $"Course name: {CourseName} || Payment amount: {Payment} || Modules: {Modules}";
    }

}

class Group
{
    public string Name { get; private set;}
    public int StudentCount {get; private set;}

    public Course Course{ get; private set; }

    public Group(string name, int studentCount, Course course)
    {
        Name = name;
        StudentCount = studentCount;
        this.Course = course;
    }

    public override string ToString ()
    {
        return $"Group name: {Name}\nStudent Count: {StudentCount}\nCourse: {Course}";
    }

}

class Web : Course 
{
    private string? _type;
    public string? Type
    {
        get { return _type; }
        set 
        {
            if (value == "Backend" || value == "Frontend" || value == "Fullstack")
                _type = value;
            else
                throw new ArgumentException("Course type can be only 'Backend' - 'Frontend' - 'Fullstack'");
        }
    }

    public Web (string courseName, string type, int payment, Module[] modules) : base (courseName, payment, modules) => Type = type;
}
class GameDev : Course 
{
    private string? _engine ;
    public string? Engine
    {
        get { return _engine; }
        set 
        {
            if (value == "Unity" || value == "Unreal" )
                _engine = value;
            else
                throw new ArgumentException("Course type can be only 'Unity' - 'Unreal'");
        }
    }

    public GameDev (string courseName, string engine, int payment, Module[] modules) : base (courseName, payment, modules) => Engine = engine;

    public override string ToString() => $"Course name: {CourseName} || Payment amount: {Payment} || Modules: {Modules}";
    
}

class AI : Course 
{
    private string? _type;
    public string? Type
    {
        get { return _type; }
        set 
        {
            if (value?.ToLower() == "Neural Network".ToLower() || value?.ToLower() == "Machine Learning".ToLower())
                _type = value;
            else
                throw new ArgumentException("Course type can be only 'Neural Network' - 'Machine Learning''");
        }
    }

    public AI (string courseName, string type, int payment, Module[] modules) : base (courseName, payment, modules) => Type = type;

    public override string ToString() => $"Course name: {CourseName} || Payment amount: {Payment} || Modules: {Modules}";
    
}

class Program 
{
    public static void Main (string[] args)
    {
        Course[] courses = 
        {
            new Web("Web Development", "Frontend", 59000, new Module[]
            {
                new Module ("Fundamental", 3),
                new Module ("Language part", 3),
                new Module ("Advanced", 3),
            }),

            new Web("Web Development", "Backend", 59000, new Module[]
            {
                new Module ("Fundamental", 3),
                new Module ("Language part", 3),
                new Module ("Advanced", 3),
            }),

            new Web("Web Development", "Fullstack", 79000, new Module[]
            {
                new Module ("Fundamental", 3),
                new Module ("Language part", 5),
                new Module ("Advanced", 4),
            }),

            new AI("AI", "Machine Learning", 79000, new Module[]
            {
                new Module ("Fundamental", 3),
                new Module ("Advanced Math", 5),
                new Module ("Language Part", 4),
            }), 

            new GameDev("GameDev", "Unity", 65000, new Module[]
            {
                new Module ("Fundamental", 3),
                new Module ("C#", 5),
                new Module ("Games with unity", 4),
            }),

            new GameDev("GameDev", "Unreal", 65000, new Module[]
            {
                new Module ("Fundamental", 3),
                new Module ("C#", 5),
                new Module ("Games with Unreal", 4),
            }), 
             
            new AI("AI", "Neural Network", 79000, new Module[]
            {
                new Module ("Fundamental", 3),
                new Module ("Advanced Math", 5),
                new Module ("Language Part", 4),
            })

            
        };
        Group[] groups = 
        {
            new Group("Frontend Group 1", 15, courses[0]),   // Frontend Development
            new Group("Fullstack Group 1", 12, courses[2]), // BackEnd Dev
            new Group ("BackEnd Group 1", 17, courses[1]),  // Fullstack Development
            new Group("AI Group 1", 10, courses[3]),    // Machine Learning
            new Group ("AI Group 2", 19, courses[6]),     // Neural Network
            new Group("GameDev Group 1 ", 30, courses[4]), // Unity 
            new Group ("GameDev Group 2", 20, courses[5])// Unreal

        };
        //գտնել վեբ սովորող ուսանողների քանակը (ենթադրվում է, որ կարող են լինել տարբեր վեբի խմբեր)
        int studentsCount = 0;
        foreach(var item in groups)
        {
            if (item.Course is Web)
            {
                studentsCount += item.StudentCount;
            }
        }
        System.Console.WriteLine(studentsCount);
        //գտնել որքան գումար կկուտակվի մեկ ամսում Unreal engine-ի շրջանակներում Game Dev սովորող ուսանողների վճարած գումարից
        int totalIncome = 0;
        foreach(var item in groups)
        {
            if (item.Course is GameDev other)
            {
                if (other.Engine == "Unreal")
                    totalIncome += item.Course.Payment * item.StudentCount;
            }
            
        }
        System.Console.WriteLine(totalIncome);
        //գտնել ամենապահանջված դասընթացը (ուսանողների քանակով)
        int maxStudent = 0;
        StringBuilder sb = new StringBuilder();
        foreach(var item in groups)
        {
            if (item.StudentCount > maxStudent)
            {
                maxStudent = item.StudentCount;
                sb.Clear();
                sb.Append(item.Course.CourseName);
            }
        }
        string name = sb.ToString();
        System.Console.WriteLine($"The most famous course is {name} with {maxStudent} students");
    }
}


