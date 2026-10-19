using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Data_Manipulation_Part_Of_project
{
    public partial class SummaryForm : Form
    {
        public SummaryForm()
        {
            InitializeComponent();

            string summaryPath = Path.Combine(Application.StartupPath, "summary.txt");
            if (!File.Exists(summaryPath))
            {
                lblSummary.Text = "Summary file not found.";
            }
            else
            {
                lblSummary.Text = File.ReadAllText(summaryPath);
            }
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
