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
      // Sightings.RemoveAll(sighting => sighting.WhatISaw == what);

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


  }
}