using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employers_from_rest_api
{
    public partial class Form2 : Form
    {
        private Employer _employer;

        internal Employer Employer { get => _employer; set => _employer = value; }

        public Form2()
        {
            InitializeComponent();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            nevTextbox.Text = Employer.Name;
            salaryNnumericUpDown1.Minimum = 0;
            salaryNnumericUpDown1.Maximum = 10000;
            salaryNnumericUpDown1.Value = Employer.Salary;
        }
    }
}
