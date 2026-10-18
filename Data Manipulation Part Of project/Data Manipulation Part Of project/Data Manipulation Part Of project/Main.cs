using System.Data;

namespace Data_Manipulation_Part_Of_project
{
    public partial class Main : Form
    {
        Animal animal = new Animal();
        public Main()
        {
            InitializeComponent();

            DataTable dataTable = new DataTable();
            dataTable = animal.GetAll();
            dgvAnimalData.DataSource = dataTable;

            dgvAnimalData.ReadOnly = true;
            dgvAnimalData.AllowUserToAddRows = false;
            dgvAnimalData.AllowUserToDeleteRows = false;

            tbAnimalID.ReadOnly = false;
            btnAdd.Enabled = true;
            btnSaveChanges.Enabled = false;

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            animal.animalID = tbAnimalID.Text;
            animal.name = tbName.Text;
            animal.species = tbSpecies.Text;
            animal.age = int.TryParse(tbAge.Text, out int age) ? age : 0;
            animal.status = tbStatus.Text;
            animal.housingUnit = tbHousingUnit.Text;

            bool isUpdated = animal.UpdateAnimal(animal);

            if (isUpdated)
            {
                MessageBox.Show("Animal data updated successfully.");
                DataTable dataTable = animal.GetAll();
                dgvAnimalData.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Failed to update animal data.");
            }

        }

        private void dgvAnimalData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that the clicked cell is not a header cell
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow viewRow = dgvAnimalData.Rows[e.RowIndex];

                dgvAnimalData.CurrentRow.Selected = true;

                // Populate the text boxes with the selected row's data, if the cell value is null, set the text box to an empty string
                tbAnimalID.Text = viewRow.Cells["Animal ID"].Value?.ToString() ?? "";
                tbName.Text = viewRow.Cells["Name"].Value?.ToString() ?? "";
                tbSpecies.Text = viewRow.Cells["Species"].Value?.ToString() ?? "";
                tbAge.Text = viewRow.Cells["Age"].Value?.ToString() ?? "";
                tbScore.Text = viewRow.Cells["Recovery Score"].Value?.ToString() ?? "";
                tbStatus.Text = viewRow.Cells["Status"].Value?.ToString() ?? "";
                tbHousingUnit.Text = viewRow.Cells["Housing Unit"].Value?.ToString() ?? "";

                // Set the Animal ID text box to read-only and disable the Add button, enable the Save Changes button
                tbAnimalID.ReadOnly = true;
                btnAdd.Enabled = false;
                btnSaveChanges.Enabled = true;

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbAnimalID.Clear();
            tbName.Clear();
            tbSpecies.Clear();
            tbAge.Clear();
            tbScore.Clear();
            tbStatus.Clear();
            tbHousingUnit.Clear();

            DataTable dataTable = new DataTable();
            dataTable = animal.GetAll();
            dgvAnimalData.DataSource = dataTable;

            tbAnimalID.ReadOnly = false;
            btnAdd.Enabled = true;
            btnSaveChanges.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            animal.animalID = tbAnimalID.Text;
            animal.name = tbName.Text;
            animal.species = tbSpecies.Text;
            animal.age = int.TryParse(tbAge.Text, out int age) ? age : 0;
            animal.status = tbStatus.Text;
            animal.housingUnit = tbHousingUnit.Text;

            DialogResult result = MessageBox.Show($"Are you sure you want to delete {animal.name}, animal {animal.animalID}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return; // User chose not to delete, exit the method
            }

            bool isDeleted = animal.DeleteAnimal(animal);
            if (isDeleted)
            {
                MessageBox.Show("Animal data deleted successfully.");
                DataTable dataTable = animal.GetAll();
                dgvAnimalData.DataSource = dataTable;

                tbAnimalID.Clear();
                tbName.Clear();
                tbSpecies.Clear();
                tbAge.Clear();
                tbScore.Clear();
                tbStatus.Clear();
                tbHousingUnit.Clear();
            }
            else
            {
                MessageBox.Show("Failed to delete animal data.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchAnimalID = tbSearch.Text.ToUpper().Trim();
            if (string.IsNullOrEmpty(searchAnimalID))
            {
                MessageBox.Show("Please enter an Animal ID to search.");
                return;
            }
            DataTable searchResults = new DataTable();

            searchResults = animal.SearchAnimal(searchAnimalID);
            dgvAnimalData.DataSource = searchResults;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbScore.Text, out int score))
            {
                MessageBox.Show("Please enter a valid recovery score.");
                tbScore.Focus();
                return;
            }

            animal.animalID = tbAnimalID.Text.Trim();
            animal.name = tbName.Text.Trim();
            animal.species = tbSpecies.Text.Trim();
            animal.age = int.TryParse(tbAge.Text, out int age) ? age : 0;
            animal.score = score;

            animal.CalculateClassification();

            tbStatus.Text = animal.status;
            tbHousingUnit.Text = animal.housingUnit;

            if (animal.AddAnimal())
            {
                MessageBox.Show("Animal data added successfully.");
                dgvAnimalData.DataSource = animal.GetAll();
            }
            else
            {
                MessageBox.Show("Failed to add animal data.");
            }
        }
    }
}
