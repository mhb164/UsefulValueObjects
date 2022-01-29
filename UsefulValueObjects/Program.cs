using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulValueObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inc01 = new IranNationalCode("7491254713");

            Console.WriteLine(inc01);
            Console.ReadKey();
        }
    }
}
