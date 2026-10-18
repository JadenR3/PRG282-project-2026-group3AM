using System;
using System.Collections.Generic;
using System.Data;
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
                    // ID | Name | Species | Age | Score | Status | Housing Unit
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

        public void CalculateClassification()
        {

            if (score <= 18)
            {
                status = "Critical";
                housingUnit = "Intensive Care Unit";
            }
            else if (score <= 39)
            {
                status = "Serious";
                housingUnit = "High-Dependency Ward";
            }
            else if (score <= 59)
            {
                status = "Stable";
                housingUnit = "Recovery Ward";
            }
            else if (score <= 79)
            {
                status = "Recovering";
                housingUnit = "General Care Area";
            }
            else
            {
                status = "Stable";
                housingUnit = "General Care Area";
            }
        }

    }
}
