using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CatWorx.BadgeMaker;

namespace Catworx.BadgeMaker
{
    class Program
    {

        // static List<Employee> GetEmployees()
        // {
        //     // Return a list of Employee instances
        //     List<Employee> employees = new List<Employee>();
        //     // Collect user values until the value is an empty string
        //     while (true)
        //     {
        //         Console.WriteLine("Please enter employee first name, or enter blank to quit: ");
        //         // Read a name from the console and assign it to a variable
        //         // ?? is a coalescing operator that tells ReadLine how to handle a null input value,
        //         // if null is found, it is replaced with ""
        //         // necessary because our list can only have string values ... not nulls
        //         // won't run without it apparently.
        //         string inputFirstName = Console.ReadLine() ?? "";

        //         // Break if user enters an empty string
        //         if (inputFirstName == "")
        //         {
        //             break;
        //         }

        //         Console.WriteLine("Enter employee last name:");
        //         string inputLastName = Console.ReadLine() ?? "";

        //         Console.WriteLine("Enter employee ID:");
        //         int inputId = Int32.Parse(Console.ReadLine() ?? "");

        //         Console.WriteLine("Enter employee photo url:");
        //         string inputUrl = Console.ReadLine() ?? "";



        //         // Create new Employee instance
        //         Employee currentEmployee = new Employee(inputFirstName, inputLastName, inputId, inputUrl);

        //         employees.Add(currentEmployee);
        //     }
        //     return employees;
        // }
        // static void PrintEmployees(List<Employee> employees)
        // {
        //     for (int i = 0; i < employees.Count; i++)
        //     {
        //         string template = "{0,-10}\t{1,-20}\t{2}";
        //         Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
        //     }
        // }

        static void Main(string[] args)
        {
            // Call GetEmployees method
            List<Employee> employees = Util.GetEmployees();

            // Call PrintEmployees method
            Util.PrintEmployees(employees);


        }
    }
}