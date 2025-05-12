/* Ունենք երկու Thread, մեկը նախատեսված է share արված List<int> nums-ը  5 անգամ, 
 10 պատահական թվերով լցնելու համար,
Մյուսն անցնում է գործի,երբ. nums-ում 10 թիվ կա.  վերջինս  գումարում է այս թվերը, 
և տեղակայում մեկ այլ List<int>result-ի մեջ,
Իրականացնել սինքրոնիզացիա.lock, Monitor- ի միջոցով: */

using System.Globalization;

namespace Threds
{
    static class Program
    {
        static object locker = new object();
        static  List<int > resultList = new List<int>();
        private static List<int > numbers = new List<int>();
        private static bool isFinished = false;
        public static void Fill()
        {
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                var temp = new List<int>();
                for (int j = 0; j < 10; j++)
                {
                    temp.Add(rand.Next(0, 100));
                }

                lock(locker)
                {
                    numbers.Clear();
                    numbers.AddRange(temp);
                    Monitor.Pulse(locker);
                }
                Thread.Sleep(200);
            }

            lock (locker)
            {
                isFinished = true;
                Monitor.Pulse(locker);
            }
        }

        public static void Sum()
        {
           while (true)
           {
                lock(locker)
                {
                    while (numbers.Count < 10 && !isFinished)
                    {
                        Monitor.Wait(locker);
                    }
                    if (isFinished && numbers.Count < 10)
                        break;
                    int sum = numbers.Sum();
                    resultList.Add(sum);

                    Console.WriteLine("Sum = " + sum);
                    numbers.Clear();
                }
           }
        }

        static void Main(string[] args)
        {
            Thread thread= new Thread(Fill);
            Thread thread2 = new Thread(Sum);
            thread.Start();
            thread2.Start();
            thread.Join();
            thread2.Join();

            int res = resultList.Sum();
            Console.WriteLine($"Total Sum = {res}");
            
        }
    }
}