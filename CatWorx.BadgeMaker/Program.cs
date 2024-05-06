﻿// See https://aka.ms/new-console-template for more information

using System;
using System.Globalization;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Printing strings
            string greeting = "Hello, ";
            greeting = greeting + "World";
            string more = "Bob";
            Console.WriteLine("greeting: " + greeting);
            Console.WriteLine($"greeting: {greeting}");
            Console.WriteLine("Greeting: {0}, and also {1}", greeting, more);

            // Area of a square
            float side = 3.14F;
            float area = side * side;

            Console.WriteLine("Area " + area);
            Console.WriteLine("area is a {0}", area.GetType());

            // Math operators
            Console.WriteLine(2 * 3);
            Console.WriteLine(10 % 3); // 1
            Console.WriteLine(1 + 2 * 3); // 7? nice. C# does pemdas
            Console.WriteLine(10 / 3.0); //error? Nope 3.33333
            Console.WriteLine(10 / 3); // just 3
            Console.WriteLine("12" + "3"); // 123

            int num = 10;
            num += 100;
            Console.WriteLine(num);
            num++;
            Console.WriteLine(num);

            // booleans
            bool isCold = true;
            Console.WriteLine(isCold ? "drink" : "add ice");
            Console.WriteLine(!isCold ? "add ice" : "drink");

            // type conversions
            string stringNum = "2";
            int intNum = Convert.ToInt32(stringNum);
            Console.WriteLine("stringNum type = " + stringNum.GetType());
            Console.WriteLine(intNum);
            Console.WriteLine("intNum type = " + intNum.GetType());

            // dictionaries
            Dictionary<string, int> myScoreboard = new Dictionary<string, int>(){
                {"firstInning",10},
                {"secondInning", 20},
                {"thirdInning", 30},
                {"fourthInning", 40}
            };

            myScoreboard.Add("fifthInning", 50);

            Console.WriteLine("--------------");
            Console.WriteLine("  Scoreboard  ");
            Console.WriteLine("--------------");
            Console.WriteLine("Inning | Score");
            Console.WriteLine("   1   |   {0}", myScoreboard["firstInning"]);
            Console.WriteLine("   2   |   {0}", myScoreboard["secondInning"]);
            Console.WriteLine("   3   |   {0}", myScoreboard["thirdInning"]);
            Console.WriteLine("   4   |   {0}", myScoreboard["fourthInning"]);
            Console.WriteLine("   5   |   {0}", myScoreboard["fifthInning"]);


            // Arrays
            string[] favFoods = new string[3] { "pizza", "doughnuts", "ice cream" };
            string firstFood = favFoods[0];
            string secondFood = favFoods[1];
            string thirdFood = favFoods[2];
            Console.WriteLine("I like to eat {0}, {1}, and {2}.", firstFood, secondFood, favFoods[2]);

            // Lists
            List<string> employees = new List<string>() { "arrol", "freida" };
            employees.Add("kimona");
            employees.Add("jimmy");

            // Console.WriteLine("employees: {0}, {1}, {2}, {3}", employees[0], employees[1], employees[2], employees[3]);

            // For loop
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i]);
            }


        }

    }
}
