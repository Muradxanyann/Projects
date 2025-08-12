namespace BehaviouralTask3
{
    class EmployeeProfile
    {
        public string Name { get; private set; }
        public double Salary { get; private set; }
        public string Position { get; private set; }

        public EmployeeProfile(string name, double salary, string position)
        {
            Name = name;
            Salary = salary;
            Position = position;
        }

        public void Promote(string newPosition, int newSalary)
        {
            Position = newPosition;
            Salary = newSalary;
        }

        public Memento CreateMemento()
        {
            return new Memento(Name, Salary, Position);
        }

        public void Restore(Memento memento)
        {
            Name = memento.Name;
            Salary = memento.Salary;
            Position = memento.Position;
        }
        public override string ToString() => $"{Name} : {Salary} : {Position}";
    }

    internal class Memento
    {
        public string Name { get; private set; }
        public double Salary { get; private set; }
        public string Position { get; private set; }

        public Memento(string name, double salary, string position)
        {
            Name = name;
            Salary = salary;
            Position = position;
        }
    }

    



}