using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CatWorx.BadgeMaker;

namespace Catworx.BadgeMaker
{
    class Program
    {
        async static Task Main(string[] args)
        {
            // Call GetEmployees method to prompt user for employee info
            // List<Employee> employees = PeopleFetcher.GetEmployees();

            List<Employee> employees = await PeopleFetcher.GetFromApi();

            // Print employees to console and also write to CSV file in /data
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);

            // Create badge png files
            await Util.MakeBadges(employees);


        }
    }
}