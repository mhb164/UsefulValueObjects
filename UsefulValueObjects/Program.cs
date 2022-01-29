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
            Console.WriteLine($"IranNationalCode: {new IranNationalCode("7491254713")}");
            Console.WriteLine($"MobileNumber: {new MobileNumber("+989123456789")}");
            Console.ReadKey();
        }
    }
}
