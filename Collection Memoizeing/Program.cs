using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;


/*Գրել Memoize մեթոդը, որն իբրև պարամետր ստանում է Func<T, T> և վերադարձնում Func<T,T> -ի memoize արված տարբերակը
    Օրինակ՝
Func<int,int> factorial = (int p) => {...};
var memoFact = Memoize(factorial);
//memoFact-ն այլևս իրականացնում է ֆակտորիալի հաշվարկը memoizing-ով*/

public static class Memoizer
{
    public static Func<T, T> Memoize<T>(Func<T, T> function)
    {
        Dictionary<T, T> dic = new();
        return (T item) =>
        {
            if (dic.ContainsKey(item))
                return dic[item];
            else
            {
                T temp = function(item);
                dic[item] = temp;
                return temp;
            }
        };
    }
}


/*
2.  Գրել ManagedCache ֆունկցիան, որը վերադարձնում է Tuple՝ երկու դելեգատներից
    (Func<int,bool> IsPrime, Action ClearCache):
*/
/*------------------------------------------------------------------------------------*/
public class Memoaizer
{
    public static (Func<int, bool> isPrimeWithCache, Action clearCache) ManagedCache(Func<int, bool> function)
    {
        var dictionary = new Dictionary<int, bool>();
        Func<int, bool> isPrimeWithCache = (int number) =>
        {
            if (dictionary.ContainsKey(number))
                return dictionary[number];
            bool temp = function(number);
            dictionary[number] = temp;
            return temp;
        };
        Action someAction = () => dictionary.Clear();

        return (isPrimeWithCache, someAction);
    }
}

class Program
{
    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
            if (number % i == 0) return false;
        return true;
    }
    
    static void Main(string[] args)
    {
        var (isPrimeWithCache, clearCache) = Memoaizer.ManagedCache(IsPrime);
        Console.WriteLine(isPrimeWithCache(4));
        Console.WriteLine(isPrimeWithCache(4));
    }
}
/*------------------------------------------------------------------------------------*/
/*3. List<T>-ի համար ընդլալնել Filter մեթոդը, որը Func<T,bool> դելեգատի միջոցով վերադարձնում է ֆունկցիային բավարարող տարրերը.
    Օրինակ՝
List<Student> students = new List<Student>(){...};
var temp = students.Filter(a => a.age > 20);


4.<T>-ի համար ընդլալնել Map մեթոդը, որը Func<T,T> դելեգատի միջոցով վերադարձնում է նոր List , որի ամեն տարր փոխված է
Օրինակ՝
List<int> list = new List<int>(){1,2,3,4,5,6};
var temp = list.Map(a => a+1);
c.w(temp[2])) //4
5.List<T>-ի համար ընդլալնել Every մեթոդը, որը Func<T,bool> դելեգատի միջոցով վերադարձնում է  true,  եթե բոլոր տարրերը բավարարում են նշված դելեգատին
Օրինակ՝
List<int> list = new List<int>(){1,2,3,4,5,6};
cw(list.Every(a => a > 0)) //True
6. List<T>-ի համար ընդլալնել Some մեթոդը, որը Func<T,bool> դելեգատի միջոցով վերադարձնում է  true,  եթե գոնե մեկ տարր կա, որը բավարարում է նշված դելեգատին
Օրինակ՝
List<int> list = new List<int>(){1,2,3,4,5,6};
cw(list.Some(a => a < 0)) //False

*/



public static class Extentions
{
    public static IEnumerable<T> Filter<T>(this List<T> list, Func<T, bool> func)
    {
        List<T> temp = new();
        foreach (var item in list)
        {
            if (func(item))
                temp.Add(item);
        }

        return temp;
    }

    public static List<T> Map<T>(this List<T> list, Func<T, T> func)
    {
        List<T> temp = new();
        foreach (var item in list)
        {
            temp.Add(func(item));
        }

        return temp;
    }

    public static bool Every<T>(this List<T> list, Func<T, bool> func)
    {
        foreach (var item in list)
        {
            if (!func(item))
                return false;
        }

        return true;
    }

    public static bool Some<T>(this List<T> list, Func<T, bool> func)
    {
        foreach (var item in list)
        {
            if (func(item))
                return true;
        }

        return false;
    }
    
}

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
class Program
{
    static void Main(string[] args)
    {
        #region Example1
        /*var student = new Student("Ash", 18);
        
        var student2 = new Student("Kar", 15);
        List<Student> students = new();
        students.Add(student);
        students.Add(student2);
        var result = students.Filter(x => x.Age > 12);
        foreach (var VARIABLE in result)
        {
            Console.WriteLine(VARIABLE.Name);
        }*/
        

        #endregion

        List<int> numbers = new List<int>() { 6, 2, 8, 3 };
        var result = numbers.Map(x => x * 2);
        //Console.WriteLine(string.Join(",", result));
        Console.WriteLine(numbers.Some(x => x % 2 != 0));
        var student = new Student("Ash", 18);

        var student2 = new Student("Kar", 15);
        List<Student> students = new();
        students.Add(student);
        students.Add(student2);
        
        foreach (var VARIABLE in students)
        {
            Console.WriteLine(VARIABLE);
        }
        

    }
}
