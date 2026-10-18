using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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