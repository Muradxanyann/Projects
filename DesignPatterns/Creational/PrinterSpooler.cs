/* Task 5:
You need to create a PrinterSpooler class that manages printing jobs in the system.
Ensure that only one spooler exists to avoid conflicts between print jobs. */

using System.Collections;
using System.Dynamic;

namespace Task5
{
    public enum PrinterJobs
    {
        Print, Scan, ConvertToPdf
    }
    public class PrinterSpooler : IEnumerable<PrinterJobs>
    {
        private static PrinterSpooler _instance = default!;
        private readonly Queue<PrinterJobs> _jobs = new();

        private PrinterSpooler() { }

        public static PrinterSpooler GetInstance()
        {
            if (_instance == null)
                _instance = new PrinterSpooler();
            return _instance;
        }

        public void PrintJobs()
        {
            if (_jobs.Count == 0)
            {
                Console.WriteLine("There are not any job");
                return;
            }
            foreach (var item in _jobs)
            {
                Console.WriteLine(item);
            }
        }
        public void AddJob(PrinterJobs job)
        {
            _jobs.Enqueue(job);
        }
        public void ProcessJobs()
        {
            if (_jobs.Count == 0)
            {
                Console.WriteLine("There are not any job");
                return;
            }

            Console.WriteLine("Proccesing...");

            while (_jobs.Count > 0)
            {

                PrinterJobs currentJob = _jobs.Dequeue();
                Console.WriteLine($"Process job: {currentJob}");
            }
            Console.WriteLine("Procces complected.");
        }

        IEnumerator<PrinterJobs> IEnumerable<PrinterJobs>.GetEnumerator()
        {
            return _jobs.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return _jobs.GetEnumerator();
        }
    }
}

