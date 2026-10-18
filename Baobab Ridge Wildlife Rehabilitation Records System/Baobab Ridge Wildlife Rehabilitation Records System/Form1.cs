using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
<<<<<<< HEAD
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

=======
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
>>>>>>> 45750fb71b49bc618e24d5027cbd75acdc4a57bd
namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
<<<<<<< HEAD
        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            string AnimalName = txtName.Text.Trim();
            string Species = txtSpecies.Text.Trim();
           
            try
            {
                if (string.IsNullOrEmpty(AnimalName) || string.IsNullOrEmpty(Species))
                {
                    MessageBox.Show("Please enter both Animal Name and Species.");
                    return;
                }
                
                if (!int.TryParse(txtAge.Text, out int Age) || Age < 0 || Age > 100)
                {
                    MessageBox.Show("Please enter a number between 0 and 100 for Age.");
                    return;
                }

                if (!int.TryParse(txtRecovery.Text, out int RecoveryScore) || RecoveryScore < 0 || RecoveryScore > 100)
                {
                    MessageBox.Show("Please enter a number between 0 and 100 for Recovery Score.");
                    return;
                }

                string animalID = Animal.GenerateAnimalID();
                Animal animal = new Animal(animalID, AnimalName, Species, Age, RecoveryScore, "", "");
               
                if(animal.AddAnimal())
                {
                    txtAnimalID.Text = animal.animalID;

                    lblStatus.Text = "Status: " + animal.status;
                    lblCareLocation.Text = "Care Location: " + animal.careLocation;

                    MessageBox.Show("Animal added successfully!");
                }

                MessageBox.Show("Animal information is valid!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the animal: {ex.Message}");
            }
        }
    }
}
=======

        //Method that clears TextBoxes 
        public void clear()
        {
            txtAnimalID.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtRecoveryScore.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Getting values from text box
            string animalID = txtAnimalID.Text.Trim();
            string name = txtName.Text.Trim();
            string species = txtSpecies.Text.Trim();
            int age = int.Parse(txtAge.Text.Trim());
            int recoveryscore = int.Parse(txtRecoveryScore.Text.Trim());

            //Validating Animal ID
            if (!Regex.IsMatch(animalID, @"^WR-\d{4}$"))
            {
                MessageBox.Show("Example of ID: WR-0001");
                return;
            }

            //Validating Name
            if (name.Length <= 0 || name.Length > 30 || name.Contains("|"))
            {
                MessageBox.Show("Invalid Input: ");
                MessageBox.Show("Name must be betweem 1-30 Characters");
                MessageBox.Show("Name cannot contain '|'");

                return;
            }


            //Validating Species
            if (species.Length <= 0 || species.Length > 30 || species.Contains("|"))
            {
                MessageBox.Show("Invalid Input: ");
                MessageBox.Show("Species must be betweem 1-30 Characters");
                MessageBox.Show("Species cannot contain '|'");

                return;
            }


            //Validating Age
            if (age > 100 || age < 0)
            {
                MessageBox.Show("Invalid Input: ");
                MessageBox.Show("Age must be a whole number between 0-100");
                return;
            }

            //Validating Recovery Score
            if (recoveryscore > 100 || age < 0)
            {
                MessageBox.Show("Invalid Input: ");
                MessageBox.Show("Score must be a whole number between 0-100");
                return;
            }

            //Calculating Animals Status and Housing Unit 
            AnimalClassification result = new AnimalClassification(recoveryscore);
            string status = result.status;
            string housingUnit = result.housingUnit;

            //Creating record 
            string record = $"{animalID}|{name}|{species}|{age}|{recoveryscore}|{status}|{housingUnit}";

            //Updating records
            File.AppendAllText("animals.txt", record + Environment.NewLine);

            MessageBox.Show("Animals added successfully");
            MessageBox.Show($"Status: {status} ");
            MessageBox.Show($"Housing Unit: {housingUnit} ");



            clear();



        }
    }
 }

>>>>>>> 45750fb71b49bc618e24d5027cbd75acdc4a57bd
