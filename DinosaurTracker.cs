using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
  public class DinosaurTracker
  {
    public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

    public void AddNewDinosaur(string name, string diet, int weight, int enclosure)


    {
      var addDinosaur = new Dinosaur
      {
        Name = name,
        DietType = diet,
        DateAcquired = DateTime.Now,
        Weight = weight,
        EnclosureNumber = enclosure
      };

      Dinosaurs.Add(addDinosaur);
    }

    public void RemoveDinosaur(string name)
    {

      var thingToRemove = Dinosaurs.Where(Dinosaurs => Dinosaurs.Name == name).ToList();
      if (thingToRemove.Count() > 1)
      {
        Console.WriteLine($"We found multiple {name}, which do you want to remove");
        for (int i = 0; i < thingToRemove.Count; i++)
        {
          var removeDinosaur = thingToRemove[i];
          Console.WriteLine($"{i + 1}: {removeDinosaur.Name} at enclosure #: {removeDinosaur.EnclosureNumber}");
        }

        var index = int.Parse(Console.ReadLine());
        Dinosaurs.Remove(thingToRemove[index - 1]);

      }
      else
      {
        // remove the only instance found
        Dinosaurs.Remove(thingToRemove.First());
      }

    }

    public void TransferDinosaur(string name)
    {
      var dinoToMove = Dinosaurs.IndexOf(Dinosaurs.First(name => Dinosaurs.Contains(name)));
      Console.WriteLine($"Where do you want to put them?");
      var newNumber = int.Parse(Console.ReadLine());
      Dinosaurs[dinoToMove].EnclosureNumber = newNumber;

    }
    public void ThreeHeaviest()
    {
      var heaviestDinos = (Dinosaurs.OrderByDescending(ThreeHeaviest => ThreeHeaviest.Weight).Take(3));
      foreach (var d in heaviestDinos)
      {
        Console.WriteLine($"The {d.Name} weighs {d.Weight} pounds");
      }
    }

    public void DietSummary(string diet)
    {
      var dinoHerbs = Dinosaurs.Sum(DietType => diet.Contains("herbivore"));
      foreach (var h in dinoHerbs)
      {
        Console.WriteLine($"There are a total of {dinoHerbs} herbivores in Jurassic Park!");
      }

      var dinoCarns = Dinosaurs.Sum(DietType => diet.Contains("carnivores"));
      foreach (var c in dinoCarns)
      {
        Console.WriteLine($"There are a total of {dinoCarns} carnivores in Jurassic Park!");
      }

    }
  }
}

