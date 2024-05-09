using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CatWorx.BadgeMaker;

namespace Catworx.BadgeMaker
{
    class Program
    {

        static List<Employee> GetEmployees()
        {
            // Return a list of Employee instances
            List<Employee> employees = new List<Employee>();
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

                // Create new Employee instance
                Employee currentEmployee = new Employee(input, "Smith");

                employees.Add(currentEmployee);
            }
            return employees;
        }
        static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i].GetFullName());
            }
        }

        static void Main(string[] args)
        {
            // Call GetEmployees method
            List<Employee> employees = GetEmployees();

            // Call PrintEmployees method
            PrintEmployees(employees);


        }
    }
}