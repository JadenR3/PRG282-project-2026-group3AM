using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace Data_Manipulation_Part_Of_project
{
    internal class Animal
    {
        public string animalID;
        public string name;
        public string species;
        public int age;
        public int score;
        public string status;
        public string housingUnit;

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Animal ID");       
            dt.Columns.Add("Name");
            dt.Columns.Add("Species");
            dt.Columns.Add("Age");
            dt.Columns.Add("Recovery Score");   
            dt.Columns.Add("Status");   
            dt.Columns.Add("Housing Unit");

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("The file animals.txt does not exist. Creating a new file...");
                File.WriteAllText(filePath, ""); // Create an empty file
                
            }

            // Try to read the file with error handling
            List<string> lines;
            try
            {
                lines = File.ReadAllLines(filePath).ToList();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Could not access animals.txt |\nError: {ex.Message}");
                return dt;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Could not access animals.txt due to insufficient permissions or the file being read-only |\nError: {ex.Message}");
                return dt;
            }

            // Populate the DataTable with data from the file
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');

                // Skip malformed lines
                if (parts.Length != 7)
                {
                    continue;
                }

                dt.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]);
            }

            return dt;
        }

        public DataTable SearchAnimal(string animalID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Animal ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Species");
            dt.Columns.Add("Age");
            dt.Columns.Add("Recovery Score");
            dt.Columns.Add("Status");
            dt.Columns.Add("Housing Unit");
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt");
            // Try to read the file with error handling
            List<string> lines;
            try
            {
                lines = File.ReadAllLines(filePath).ToList();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Could not access animals.txt |\nError: {ex.Message}");
                return dt;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Could not access animals.txt due to insufficient permissions or the file being read-only |\nError: {ex.Message}");
                return dt;
            }
            // Populate the DataTable with data from the file
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');

                // Skip malformed lines
                if (parts.Length != 7)
                {
                    continue;
                }
                // Case-insensitive search for the animal ID
                if (parts[0].ToUpper().Trim() == animalID.ToUpper().Trim())
                {
                    dt.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]);
                    break; // Exit the loop after finding the first match
                }
            }
            return dt;
        }
        public bool UpdateAnimal(Animal updated)
        {
            string filePath = Path.Combine(Application.StartupPath, "animals.txt");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("The file animals.txt does not exist. Creating a new file...");
                File.WriteAllText(filePath, ""); // Create an empty file
                return false;
            }

            // Try to read the file with error handling
            List<string> lines;
            try
            {
                lines = File.ReadAllLines(filePath).ToList();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Could not access animals.txt |\nError: {ex.Message}");
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Could not access animals.txt due to insufficient permissions or the file being read-only |\nError: {ex.Message}");
                return false;
            }

            // Find the matching line and replace it
            bool found = false;
            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split('|');

                // Skip malformed lines
                if (parts.Length != 7)
                {
                    continue;
                }

                // Case-insensitive ID match
                if (parts[0].ToUpper().Trim() == updated.animalID.ToUpper().Trim())
                {

                    updated.CalculateClassification(); // Ensure status and housingUnit are updated based on the new score
                    
                    // Reconstruct the line with all 7 fields in required order, separated by '|'
                    lines[i] = $"{updated.animalID}|{updated.name}|{updated.species}|{updated.age}|{updated.score}|{updated.status}|{updated.housingUnit}";
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                return false;
            }

            // Rewrite the entire file — this replaces the old content automatically
            try
            {
                File.WriteAllLines(filePath, lines);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Could not save animals.txt. |\nError: {ex.Message}");
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Could not save animals.txt due to insufficient permissions or the file being read-only |\nError: {ex.Message}");
                return false;
            }

            return true;
        }

        public bool DeleteAnimal(Animal delete)
        {
            string filePath = Path.Combine(Application.StartupPath, "animals.txt");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("The file animals.txt does not exist. Creating a new file...");
                File.WriteAllText(filePath, ""); // Create an empty file
                return false;
            }

            // Try to read the file with proper error handling
            List<string> lines;
            try
            {
                lines = File.ReadAllLines(filePath).ToList();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Could not access animals.txt \nError: {ex.Message}");
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Could not access animals.txt due to insufficient permissions or the file being read-only |\nError: {ex.Message}");
                return false;
            }

            // Find the matching line and replace it
            bool found = false;
            for (int i = 0; i < lines.Count; i++)
            {
                string[] parts = lines[i].Split('|');

                // Skip malformed lines
                if (parts.Length != 7)
                {
                    continue;
                }

                // Case-insensitive ID match
                if (parts[0].ToUpper().Trim() == delete.animalID.ToUpper().Trim())
                {
                    // Remove the line from the list
                    lines.RemoveAt(i);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                return false;
            }

            // Rewrite the entire file;replaces the old content automatically
            try
            {
                File.WriteAllLines(filePath, lines);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Could not save animals.txt. The file may be in use by another program.\nError: {ex.Message}");
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Could not save animals.txt. The file may be read-only.\nError: {ex.Message}");
                return false;
            }

            return true;
        }



        public bool AddAnimal()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory    , "animals.txt");
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 7 && parts[0].Trim().Equals(animalID.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Animal with the same ID already exists.");
                            return false;
                        }
                    }
                }

                CalculateClassification();
                string animalData = $"{animalID}|{name}|{species}|{age}|{score}|{status}|{housingUnit}";
                File.AppendAllText(filePath, animalData + Environment.NewLine);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding animal: {ex.Message}");
                return false;
            }
        }

        public bool GenerateSummary()
        {
            string filePath = Path.Combine(Application.StartupPath, "animals.txt");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("The file animals.txt does not exist. Creating a new file...");
                File.WriteAllText(filePath,""); // Create an empty file
                return false;
            }

            List<string> lines;
            try
            {
                lines = File.ReadAllLines(filePath).ToList();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Could not access animals.txt |\nError: {ex.Message}");
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Could not access animals.txt due to insufficient permissions or the file being read-only |\nError: {ex.Message}");
                return false;
            }

            int totalAnimals = 0;
            int totalAge = 0;
            int totalScore = 0;

            int criticalCount = 0;
            int seriousCount = 0;
            int stableCount = 0;
            int recoveringCount = 0;
            int releaseReadyCount = 0;

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                totalAnimals++;
                totalAge += int.Parse(parts[3]);
                totalScore += int.Parse(parts[4]);

                switch (parts[5])
                {
                    case "Critical":
                        criticalCount++;
                        break;
                    case "Serious":
                        seriousCount++;
                        break;
                    case "Stable":
                        stableCount++;
                        break;
                    case "Recovering":
                        recoveringCount++;
                        break;
                    case "Release Ready":
                        releaseReadyCount++;
                        break;
                }
            }

            if (totalAnimals == 0)
            {
                MessageBox.Show("No animal data available.");
                return false;
            }

            double averageAge = totalAnimals > 0 ? Math.Round((double)totalAge / totalAnimals, 2) : 0;
            double averageScore = totalAnimals > 0 ? Math.Round((double)totalScore / totalAnimals, 2) : 0;

            string summaryData = "BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE\n" +
                                $"ANIMAL SUMMARY REPORT\n" +
                                $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}\n" +
                                "----------------------------------------\n" +
                                $"Total animals:            {totalAnimals}\n" +
                                $"Average age (years):      {averageAge.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                                $"Average recovery score:   {averageScore.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                                "----------------------------------------\n" +
                                $"Animals per status:\n" +
                                $"Critical:                 {criticalCount}\n" +
                                $"Serious:                  {seriousCount}\n" +
                                $"Stable:                   {stableCount}\n" +
                                $"Recovering:               {recoveringCount}\n" +
                                $"Release-Ready:            {releaseReadyCount}";

            File.WriteAllText(Path.Combine(Application.StartupPath, "summary.txt"), summaryData);

            return true;
        }

        public void CalculateClassification()
        {

            if (score >= 0 && score <= 19)
            {
                status = "Critical";
                housingUnit = "Intensive Care Unit";
            }
            else if ( score >= 20 && score <= 39)
            {
                status = "Serious";
                housingUnit = "High-Dependency Ward";
            }
            else if ( score >= 40 && score <= 59)
            {
                status = "Stable";
                housingUnit = "Recovery Ward";
            }
            else if (score >= 60 && score <= 79)
            {
                status = "Recovering";
                housingUnit = "Outdoor Enclosure";
            }
            else if (score >= 80 && score <= 100)
            {
                status = "Release-Ready ";
                housingUnit = "Pre-Release Camp";
            }
            else
            {
                status = "N/A";
                housingUnit = "N/A";
            }
        }

    }
}
