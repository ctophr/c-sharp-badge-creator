using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class PeopleFetcher
  {
    public static List<Employee> GetEmployees()
    {
      // Return a list of Employee instances
      List<Employee> employees = new List<Employee>();
      // Collect user values until the firstname value is an empty string
      while (true)
      {
        Console.WriteLine("Please enter employee first name, or enter blank to quit: ");
        // Read a name from the console and assign it to a variable
        // ?? is a coalescing operator that tells ReadLine how to handle a null input value,
        // if null is found, it is replaced with ""
        // necessary because our list can only have string values ... not nulls
        // won't run without it apparently.
        string inputFirstName = Console.ReadLine() ?? "";

        // Break if user enters an empty string
        if (inputFirstName == "")
        {
          break;
        }

        Console.WriteLine("Enter employee last name:");
        string inputLastName = Console.ReadLine() ?? "";

        Console.WriteLine("Enter employee ID:");
        int inputId = Int32.Parse(Console.ReadLine() ?? "");

        Console.WriteLine("Enter employee photo url:");
        string inputUrl = Console.ReadLine() ?? "";



        // Create new Employee instance to put employee data
        Employee currentEmployee = new Employee(inputFirstName, inputLastName, inputId, inputUrl);

        employees.Add(currentEmployee);
      }
      return employees;
    }

  }
}