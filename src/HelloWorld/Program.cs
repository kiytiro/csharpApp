using System;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static object Passthrough(object obj)
        {
            return obj;
        }
    }
}
