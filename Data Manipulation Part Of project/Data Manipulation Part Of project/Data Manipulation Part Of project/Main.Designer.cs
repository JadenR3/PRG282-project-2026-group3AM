namespace Data_Manipulation_Part_Of_project
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvAnimalData = new DataGridView();
            btnAdd = new Button();
            btnSaveChanges = new Button();
            btnDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            tbAnimalID = new TextBox();
            tbName = new TextBox();
            tbSpecies = new TextBox();
            tbScore = new TextBox();
            tbAge = new TextBox();
            tbHousingUnit = new TextBox();
            tbStatus = new TextBox();
            btnClear = new Button();
            btnGenerateSummary = new Button();
            btnSearch = new Button();
            tbSearch = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAnimalData).BeginInit();
            SuspendLayout();
            // 
            // dgvAnimalData
            // 
            dgvAnimalData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimalData.Location = new Point(50, 255);
            dgvAnimalData.Name = "dgvAnimalData";
            dgvAnimalData.Size = new Size(805, 183);
            dgvAnimalData.TabIndex = 0;
            dgvAnimalData.CellClick += dgvAnimalData_CellClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(497, 211);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(116, 38);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(619, 211);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(116, 38);
            btnSaveChanges.TabIndex = 2;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(739, 211);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(116, 38);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 38);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 4;
            label1.Text = "Animal ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 70);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 5;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 105);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 6;
            label3.Text = "Species";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 142);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 7;
            label4.Text = "Age";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 179);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 8;
            label5.Text = "Score";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(342, 38);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 9;
            label6.Text = "Status";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(342, 70);
            label7.Name = "label7";
            label7.Size = new Size(77, 15);
            label7.TabIndex = 10;
            label7.Text = "Housing Unit";
            // 
            // tbAnimalID
            // 
            tbAnimalID.Location = new Point(126, 35);
            tbAnimalID.Name = "tbAnimalID";
            tbAnimalID.Size = new Size(62, 23);
            tbAnimalID.TabIndex = 11;
            // 
            // tbName
            // 
            tbName.Location = new Point(126, 67);
            tbName.Name = "tbName";
            tbName.Size = new Size(151, 23);
            tbName.TabIndex = 12;
            // 
            // tbSpecies
            // 
            tbSpecies.Location = new Point(126, 102);
            tbSpecies.Name = "tbSpecies";
            tbSpecies.Size = new Size(151, 23);
            tbSpecies.TabIndex = 13;
            // 
            // tbScore
            // 
            tbScore.Location = new Point(126, 176);
            tbScore.Name = "tbScore";
            tbScore.Size = new Size(42, 23);
            tbScore.TabIndex = 14;
            // 
            // tbAge
            // 
            tbAge.Location = new Point(126, 139);
            tbAge.Name = "tbAge";
            tbAge.Size = new Size(42, 23);
            tbAge.TabIndex = 15;
            // 
            // tbHousingUnit
            // 
            tbHousingUnit.Location = new Point(442, 67);
            tbHousingUnit.Name = "tbHousingUnit";
            tbHousingUnit.Size = new Size(151, 23);
            tbHousingUnit.TabIndex = 17;
            // 
            // tbStatus
            // 
            tbStatus.Location = new Point(442, 35);
            tbStatus.Name = "tbStatus";
            tbStatus.Size = new Size(151, 23);
            tbStatus.TabIndex = 16;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(47, 211);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(49, 38);
            btnClear.TabIndex = 18;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnGenerateSummary
            // 
            btnGenerateSummary.Location = new Point(739, 167);
            btnGenerateSummary.Name = "btnGenerateSummary";
            btnGenerateSummary.Size = new Size(116, 38);
            btnGenerateSummary.TabIndex = 19;
            btnGenerateSummary.Text = "Generate Summary";
            btnGenerateSummary.UseVisualStyleBackColor = true;
            btnGenerateSummary.Click += btnGenerateSummary_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(739, 69);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(116, 23);
            btnSearch.TabIndex = 20;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(739, 99);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(116, 23);
            tbSearch.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(632, 102);
            label8.Name = "label8";
            label8.Size = new Size(103, 15);
            label8.TabIndex = 22;
            label8.Text = "Search Animal ID :";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 450);
            Controls.Add(label8);
            Controls.Add(tbSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnGenerateSummary);
            Controls.Add(btnClear);
            Controls.Add(tbHousingUnit);
            Controls.Add(tbStatus);
            Controls.Add(tbAge);
            Controls.Add(tbScore);
            Controls.Add(tbSpecies);
            Controls.Add(tbName);
            Controls.Add(tbAnimalID);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnAdd);
            Controls.Add(dgvAnimalData);
            Name = "Main";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvAnimalData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAnimalData;
        private Button btnAdd;
        private Button btnSaveChanges;
        private Button btnDelete;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox tbAnimalID;
        private TextBox tbName;
        private TextBox tbSpecies;
        private TextBox tbScore;
        private TextBox tbAge;
        private TextBox tbHousingUnit;
        private TextBox tbStatus;
        private Button btnClear;
        private Button btnGenerateSummary;
        private Button btnSearch;
        private TextBox tbSearch;
        private Label label8;
    }
}
