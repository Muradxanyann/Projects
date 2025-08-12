/* Task 4:
Create a system for managing employee records where you can quickly
 copy an existing employee and modify only specific fields like name or address. */

using System.Reflection.Metadata.Ecma335;

namespace Task4
{
    interface IPrototype<out T>
    {
        T Clone();
    }

    class Employee : IPrototype<Employee>
    {
        public required string Name { get; set; }
        public int Age { get; set; }

        public required Address Addr { get; set; }

        public Employee Clone()
        {
            return new Employee
            {
                Name = Name,
                Age = Age,
                Addr = new Address(Addr.City, Addr.Region)
            };
            
        }
    }

    class Address
    {
        public  string  City { get; set;}
        public  string Region { get; set; }
        public Address (string city, string region)
        {
            City = city; Region = region;
        }
        public Address (Address address)
        {
            City = address.City; Region = address.Region;
        }
    }

}

