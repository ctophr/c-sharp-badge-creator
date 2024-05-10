using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CatWorx.BadgeMaker;

namespace Catworx.BadgeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call GetEmployees method
            List<Employee> employees = Util.GetEmployees();

            // Call PrintEmployees method
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);


        }
    }
}