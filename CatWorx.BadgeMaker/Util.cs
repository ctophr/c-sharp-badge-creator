using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatWorx.BadgeMaker;
using System.Net.Http;
using SkiaSharp;

namespace Catworx.BadgeMaker
{
  class Util
  {

    async public static Task<List<Employee>> Initialize()
    {
      Console.WriteLine("Type 'Y' to fetch employees from API, or hit Enter to input manually");
      string inputInitialize = Console.ReadLine() ?? "";

      if (inputInitialize == "Y" || inputInitialize == "y")
      {
        List<Employee> employees = await PeopleFetcher.GetFromApi();
        return employees;
      }
      else
      {
        List<Employee> employees = PeopleFetcher.GetEmployees();
        return employees;
      }




    }
    public static void PrintEmployees(List<Employee> employees)
    {
      for (int i = 0; i < employees.Count; i++)
      {
        string template = "{0,-10}\t{1,-20}\t{2}";
        Console.WriteLine(String.Format(template, employees[i].GetId(),
         employees[i].GetFullName(), employees[i].GetPhotoUrl()));
      }
    }
    public static void MakeCSV(List<Employee> employees)
    {
      // If data directory does not exist, create it.
      if (!Directory.Exists("data"))
      {
        Directory.CreateDirectory("data");
      }
      using (StreamWriter file = new StreamWriter("data/employees.csv"))
      {
        // Create table headers
        file.WriteLine("ID,Name,PhotoUrl");

        // Write employee data into file
        for (int i = 0; i < employees.Count; i++)
        {
          string template = "{0},{1},{2}";
          file.WriteLine(String.Format(template, employees[i].GetId(),
           employees[i].GetFullName(), employees[i].GetPhotoUrl()));
        }
      }
    }
    async public static Task MakeBadges(List<Employee> employees)
    {
      // Bitmap layout variables reflecting badge template size
      int BADGE_WIDTH = 669;
      int BADGE_HEIGHT = 1044;

      // Layout variables for sizing, styling and placing the employee info
      int PHOTO_LEFT_X = 184;
      int PHOTO_TOP_Y = 215;
      int PHOTO_RIGHT_X = 486;
      int PHOTO_BOTTOM_Y = 517;

      int COMPANY_NAME_Y = 150;
      int EMPLOYEE_NAME_Y = 600;
      int EMPLOYEE_ID_Y = 730;
      float CENTERED_X = BADGE_WIDTH / 2;

      SKPaint companyNamePaint = new SKPaint
      {
        TextSize = 42.0f,
        IsAntialias = true,
        Color = SKColors.White,
        IsStroke = false,
        TextAlign = SKTextAlign.Center,
        Typeface = SKTypeface.FromFamilyName("Arial")
      };

      SKPaint employeeNamePaint = new SKPaint
      {
        TextSize = 42.0f,
        IsAntialias = true,
        Color = SKColors.Black,
        IsStroke = false,
        TextAlign = SKTextAlign.Center,
        Typeface = SKTypeface.FromFamilyName("Arial")
      };

      SKPaint idPaint = new SKPaint
      {
        TextSize = 42.0f,
        IsAntialias = true,
        Color = SKColors.Black,
        IsStroke = false,
        TextAlign = SKTextAlign.Center,
        Typeface = SKTypeface.FromFamilyName("Courier New")
      };





      // Instance of HttpClient is disposed after code block has run
      using (HttpClient client = new HttpClient())
      {
        for (int i = 0; i < employees.Count; i++)
        {
          // Use the GetPhotoURL() method on each Employee object in our List. 
          // Then use the GetStreamAsync() method with the await keyword to tell the method 
          // to wait for this method to complete. 
          // Then convert the Stream that is returned from 
          // the GetStreamAsync() method into an SKImage using the FromEncodedData() method.
          SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));

          SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));

          SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);
          SKCanvas canvas = new SKCanvas(badge);

          // Draw badge template
          canvas.DrawImage(background, new SKRect(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
          // Draw employee photo
          canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));
          // Draw company name at top
          canvas.DrawText(employees[i].GetCompanyName(), CENTERED_X, COMPANY_NAME_Y, companyNamePaint);
          // Draw employee name
          canvas.DrawText(employees[i].GetFullName(), CENTERED_X, EMPLOYEE_NAME_Y, employeeNamePaint);
          // Draw employee id
          canvas.DrawText(Convert.ToString(employees[i].GetId()), CENTERED_X, EMPLOYEE_ID_Y, idPaint);


          // Save completed badge to [ID]_badge.png
          SKImage finalImage = SKImage.FromBitmap(badge);
          SKData data = finalImage.Encode();
          string imagePathTemplate = "data/{0}_badge.png";
          data.SaveTo(File.OpenWrite(string.Format(imagePathTemplate, employees[i].GetId())));
        }
      }
    }
  }
}