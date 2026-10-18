using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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

