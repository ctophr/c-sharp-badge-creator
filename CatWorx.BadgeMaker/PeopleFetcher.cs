using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


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
    async public static Task<List<Employee>> GetFromApi()
    {
      List<Employee> employees = new List<Employee>();
      using (HttpClient client = new HttpClient())
      {
        string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
        JObject json = JObject.Parse(response);
        // Console.WriteLine(json.SelectToken("results").Count());

        // Update iteration method with foreach

        foreach (JToken token in json.SelectToken("results")!)
        {
          Employee currentEmployee = new Employee(
            token.SelectToken("name.first")!.ToString(),
            token.SelectToken("name.last")!.ToString(),
            Convert.ToInt32(token.SelectToken("id.value")!.ToString().Replace("-", "")),
            token.SelectToken("picture.large")!.ToString()
          );

          employees.Add(currentEmployee);
        }

        // Original iteration method with normal for loop

        // for (int i = 0; i < json.SelectToken("results")!.Count(); i++)
        // {
        //   string firstNamePath = "results[{0}].name.first";
        //   string firstName = json.SelectToken(string.Format(firstNamePath, i))!.ToString();

        //   string lastNamePath = "results[{0}].name.last";
        //   string lastName = json.SelectToken(string.Format(lastNamePath, i))!.ToString();

        //   string idPath = "results[{0}].id.value";
        //   string idString = json.SelectToken(string.Format(idPath, i))!.ToString();
        //   int id = Convert.ToInt32(idString.Replace("-", ""));

        //   string photoPath = "results[{0}].picture.large";
        //   string photoUrl = json.SelectToken(string.Format(photoPath, i))!.ToString();

        //   Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);

        //   employees.Add(currentEmployee);
        // }

      }
      return employees;
    }

  }
}