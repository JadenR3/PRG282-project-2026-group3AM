using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System
{
    internal class Animal
    {
        public string animalID { get; set; }
        public string name { get; set; }
        public string species { get; set; }
        public int age { get; set; }
        public int recoveryScore { get; set; }
        public string status { get; set; }
        public string careLocation { get; set; }


        public Animal(string animalID, string name, string species, int age, int recoveryScore, string status, string careLocation)
        {
            this.animalID = animalID;
            this.name = name;
            this.species = species;
            this.age = age;
            this.recoveryScore = recoveryScore;
            this.status = status;
            this.careLocation = careLocation;
        }

        public bool AddAnimal()
        {
            try
            {
                string filePath = "Animals.txt";
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length >= 7 && parts[0].Trim().Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Animal with the same name already exists.");
                            return false;
                        }
                    }
                }
                string animalData = $"{animalID}|{name}|{species}|{age}|{recoveryScore}|{status}|{careLocation}";
                File.AppendAllText(filePath, animalData + Environment.NewLine);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding animal: {ex.Message}");
                return false;
            }
        }
        public static string GenerateAnimalID()
        {
            string filePath = "Animals.txt";
            int nextID = 0;
            if(File.Exists(filePath))
            { string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 7 && parts[0].StartsWith("WR-") && 
                        int.TryParse(parts[0].Substring(3), out int currentID))
                    {
                        nextID = Math.Max(nextID, currentID);
                    }
                }
            }
            return $"WR-{(nextID + 1).ToString("D4")}";
        }
        public void CalculateClassification()
        {
           
            if (recoveryScore <= 18)
            {
                status = "Critical";
                careLocation = "Intensive Care Unit";
            }
            else if (recoveryScore <= 39)
            {
                status = "Serious";
                careLocation = "High-Dependency Ward";
            }
            else if (recoveryScore <= 59)
            {
                status = "Stable";
                careLocation = "Recovery Ward";
            }
            else if (recoveryScore  <= 79)
            {
                status = "Recovering";
                careLocation = "General Care Area";
            }
            else
            {
                status = "Stable";
                careLocation = "General Care Area";
            }
        }
    }
}
