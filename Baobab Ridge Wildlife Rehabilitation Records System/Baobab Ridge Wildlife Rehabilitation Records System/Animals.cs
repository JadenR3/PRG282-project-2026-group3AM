using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System
{
    internal class Animals
    {
        public string animalID { get; set; }
        public string name { get; set; }
        public string species { get; set; }
        public int age { get; set; }
        public int recoveryScore { get; set; }
        public string status { get; set; }
        public string housingUnit { get; set; }

        public Animals(string animalID, string name, string species, int age, int recoveryScore, string status, string housingUnit)
        {
            this.animalID = animalID;
            this.name = name;
            this.species = species;
            this.age = age;
            this.recoveryScore = recoveryScore;
            this.status = status;
            this.housingUnit = housingUnit;

        }
    }
}
