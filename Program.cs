using System;
using System.Linq;

namespace JurassicPark
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Jurassic Park Dinosaur Tracker!");
      var dinosaur = new DinosaurTracker();

      var isRunning = true;
      while (isRunning)
      {

        Console.WriteLine("Would you like to (ADD), (REMOVE), (TRANSFER), (VIEW), (QUIT?)");
        var input = Console.ReadLine().ToLower();
        if (input == "add")
        {
          Console.WriteLine("What type of Dinosaur are you adding?");
          var name = Console.ReadLine().ToLower();

          Console.WriteLine("What is the diet type? (HERBIVORE) or (CARNIVORE)");
          var diet = Console.ReadLine().ToLower();

          Console.WriteLine("What is the weight in pounds?");
          var weight = int.Parse(Console.ReadLine());

          Console.WriteLine("What enclosure does it go in?");
          var enclosure = int.Parse(Console.ReadLine());

          dinosaur.AddNewDinosaur(name, diet, weight, enclosure);

        }
        else if (input == "remove")
        {
          Console.WriteLine("Current dinosaurs are: ");
          foreach (var d in dinosaur.Dinosaurs)
          {
            Console.WriteLine($"{d.DateAcquired}: {d.Name} is a {d.DietType}, weighs {d.Weight} pounds and lives in enclosure {d.EnclosureNumber}");
          }

          Console.WriteLine("Which dinosaur would you like to remove?");
          var remove = Console.ReadLine().ToLower();
          dinosaur.RemoveDinosaur(remove);
        }
        else if (input == "transfer")
        {
          Console.WriteLine("Current dinosaurs are: ");
          foreach (var d in dinosaur.Dinosaurs)
          {
            Console.WriteLine($"{d.DateAcquired}: {d.Name} is a {d.DietType}, weighs {d.Weight} pounds and lives in enclosure {d.EnclosureNumber}");
          }
          Console.WriteLine("Which dinosaur would you like to transfer?");
          var dinoName = Console.ReadLine().ToLower();
          dinosaur.TransferDinosaur(dinoName);

        }
        else if (input == "view")
        {
          Console.WriteLine("Do you want to view (ALL), the (THREE) heaviest dinosaurs, or a (DIET) summary?");
          var viewInput = Console.ReadLine().ToLower();

          if (viewInput == "three")
          {
            dinosaur.ThreeHeaviest();
          }
          else if (viewInput == "diet")
          {
            dinosaur.DietSummary();
          }
          else if (viewInput == "all")
          {
            foreach (var d in dinosaur.Dinosaurs)
            {
              Console.WriteLine($"{d.DateAcquired}: {d.Name} is a {d.DietType}, weighs {d.Weight} pounds and lives in enclosure {d.EnclosureNumber}");
            }

          }
        }

        if (input == "quit")
        {
          isRunning = false;
        }
      }
    }
  }
}

