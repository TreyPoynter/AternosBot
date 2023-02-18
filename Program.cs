using Python.Runtime;
using Python.Runtime.Codecs;
namespace AternosBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}