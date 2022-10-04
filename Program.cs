using System;
using System.Collections.Generic;
using Allegies.Models;

namespace Allegies
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Allergy Checker");
            Console.WriteLine();
            Console.WriteLine("Input a number to check what you are allergic to");
            int answer = int.Parse(Console.ReadLine());
            Health health = new Health(answer);
            List<string> result = health.GetAllegies();
            Console.WriteLine("You are allergic to;");
            foreach(string allergy in result)
            {
                Console.WriteLine(allergy);
            }
        }
    }
}