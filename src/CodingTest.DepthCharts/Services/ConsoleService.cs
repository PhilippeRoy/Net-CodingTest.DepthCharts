using CodingTest.DepthCharts.Services.Interfaces;

namespace CodingTest.DepthCharts.Services
{
    public class ConsoleService : IConsoleService
    {
        public void WriteLine(string s)
        {
            System.Console.WriteLine(s);
        }
    }
}