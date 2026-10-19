using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System
{
    public class SummaryReportManager
    {
        private readonly string[] allStatuses = { "Under Care", "Ready for Release", "Released", "Quarantine", "Transferred" };

        public void GenerateSummaryReport(List<Animals> animalList, out string reportOutput)
        {
            if (animalList == null)
            {
                animalList = new List<Animals>();
            }

            int totalAnimals = animalList.Count;
            string avgAgeText = "N/A";
            string avgScoreText = "N/A";

            if (totalAnimals > 0)
            {
                double totalAge = 0;
                double totalScore = 0;

                foreach (var animal in animalList)
                {
                    totalAge += animal.age;
                    totalScore += animal.recoveryScore;
                }

                double avgAge = totalAge / totalAnimals;
                double avgScore = totalScore / totalAnimals;

                avgAgeText = avgAge.ToString("F2", CultureInfo.InvariantCulture);
                avgScoreText = avgScore.ToString("F2", CultureInfo.InvariantCulture);
            }

            Dictionary<string, int> statusCounts = new Dictionary<string, int>();
            foreach (string status in allStatuses)
            {
                statusCounts[status] = 0;
            }

            foreach (var animal in animalList)
            {
                foreach (string status in allStatuses)
                {
                    if (string.Equals(animal.status, status, StringComparison.OrdinalIgnoreCase))
                    {
                        statusCounts[status]++;
                        break;
                    }
                }
            }

            List<string> displayLines = new List<string>();
            displayLines.Add("Total Animals: " + totalAnimals);
            displayLines.Add("Average Age: " + avgAgeText);
            displayLines.Add("Average Score: " + avgScoreText);
            displayLines.Add("-------------------");

            foreach (string status in allStatuses)
            {
                displayLines.Add(status + ": " + statusCounts[status]);
            }

            reportOutput = string.Join(Environment.NewLine, displayLines);

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

            List<string> fileLines = new List<string>();
            fileLines.Add($"Summary Report Generated: {timestamp}");
            fileLines.Add($"Total Animals: {totalAnimals}");
            fileLines.Add($"Average Age: {avgAgeText}");
            fileLines.Add($"Average Score: {avgScoreText}");

            foreach (string status in allStatuses)
            {
                fileLines.Add($"{status}: {statusCounts[status]}");
            }

            File.WriteAllLines("summary.txt", fileLines);
        }
    }
}
