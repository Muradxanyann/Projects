
class Test
{
    public static void Main()
    {
        List<int> numbers = new(){ 1, 2, 3 };

        foreach (var n in numbers)
        {
            // Пытаемся увеличить каждый элемент на 10
            System.Console.WriteLine(n);
        }

        
    }
}
