using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = StudentService.Get();
            Console.WriteLine(data[10].Name);
        }
    }
}
