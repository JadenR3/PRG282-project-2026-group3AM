using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System
{
    internal class AnimalClassification
    {
        public string status { get; set; }
        public string housingUnit { get; set; }
        public AnimalClassification(int recoveryscore)
        {
            if (recoveryscore <= 19)
            {
                status = "Critical";
                housingUnit = "intensive Care Unit";
                Console.Write($"{status} , {housingUnit}");
            }
            else if (recoveryscore <= 39)
            {
                status = "Serious";
                housingUnit = "High Dependency Ward";
                Console.Write($"{status} , {housingUnit}");
            }
            else if (recoveryscore <= 59)
            {
                status = "Stable";
                housingUnit = "Recovery Ward";
                Console.Write($"{status} , {housingUnit}");
            }
            else if (recoveryscore <= 79)
            {
                status = "Recovring";
                housingUnit = "Outdoor Enclosure";
                Console.Write($"{status} , {housingUnit}");
            }
            else
            {
                status = "Ready for Release";
                housingUnit = "Pre Release Camp";
                Console.Write($"{status} , {housingUnit}");
            }
        }
    }
}
