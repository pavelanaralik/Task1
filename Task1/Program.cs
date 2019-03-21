using CustomClassLibrary;
using System;


namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an string....");
            while (true)
            {            
                var str = Console.ReadLine();
                try
                {
                    Console.WriteLine($"it is integer number: { Parse.ParseToInt32(str)}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
