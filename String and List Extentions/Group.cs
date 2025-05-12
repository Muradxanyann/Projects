/*
Ունենք Group և Student կլասները
ընդ որում Group -ը ունի List<Student> զանգվածը
իրականացնել հետևյալ operator-ների գերբեռնումը
true/false => եթե խմբում առկա են ուսանողներ
Group+Group => նոր խումբ, որտեղ ուսանողները միավորված են
Group-Group => Առաջին խմբից հեռացնել այն ուսանողներին, որոնք
 առկա են նաև երկրորդ խմբում,ստացված ուսանողներից ձևավորել նոր խումբ
  */

using System.Numerics;

class Student
{
    public string Name {get; private set;}
    public int Id {get; private set;}

    public Student(string name, int id)
    {
        Name = name;
        Id = id;
    }
}

class Group
{
    List<Student> students = new();
    public Group (List<Student> students) => this.students = students;

    public static bool operator true(Group group)
    {
        return group.students.Count > 0;
    }

    public static bool operator false(Group group)
    {
        return group.students.Count <= 0;
    }

    public static List<Student> operator +(Group group1, Group group2)
    {
        List<Student> newStudents = new List<Student>(group1.students);
        newStudents.AddRange(group2.students);
        return newStudents;
    }

    public static List<Student> operator -(Group group1, Group group2)
    {
        List<Student> newStudents = new();
        for (int i = 0; i < group1.students.Count; i++)
        {
            if (group2.students.Contains(group1.students[i]))
            {
                newStudents.Add(group1.students[i]);
                group1.students.Remove(group1.students[i]);
            }
        }

        return newStudents;
    }
}