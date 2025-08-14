using TaskModel;
using App;
using System.Threading.Tasks;
static class Program
{
    static async Task Main(string[] args)
    {
        await TaskManager.RunAsync();
    }
}
