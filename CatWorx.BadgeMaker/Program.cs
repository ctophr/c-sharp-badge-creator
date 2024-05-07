using System;
using System.Collections.Generic;

namespace Catworx.BadgeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call GetEmployees method
            List<string> employees = GetEmployees();

            // Call PrintEmployees method
            PrintEmployees(employees);


        }
        static List<string> GetEmployees()
        {
            // Return a list of strings
            List<string> employees = new List<string>();
            // Collect user values until the value is an empty string
            while (true)
            {
                Console.WriteLine("Please enter employee name, or enter blank to quit: ");
                // Read a name from the console and assign it to a variable
                // ?? is a coalescing operator that tells ReadLine how to handle a null input value,
                // if null is found, it is replaced with ""
                // necessary because our list can only have string values ... not nulls
                // won't run without it apparently.
                string input = Console.ReadLine() ?? "";

                // Break if user enters an empty string
                if (input == "")
                {
                    break;
                }
                employees.Add(input);
            }
            return employees;
        }
        static void PrintEmployees(List<string> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i]);
            }
        }
    }
}