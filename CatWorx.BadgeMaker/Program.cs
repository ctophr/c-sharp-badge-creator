﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CatWorx.BadgeMaker;

namespace Catworx.BadgeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call GetEmployees method to prompt user for employee info
            List<Employee> employees = Util.GetEmployees();

            // Print employees to console and also write to CSV file in /data
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);

            // Create badge png files
            Util.MakeBadges(employees);


        }
    }
}