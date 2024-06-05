using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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

        private void button1_Click(object sender, EventArgs e)
        {
            
            Employer modifiedEmployer = new Employer(nevTextbox.Text, int.Parse(salaryNnumericUpDown1.Value.ToString()));

            ModifierEmployer(modifiedEmployer);
        }

        private async void ModifierEmployer(Employer modifiedEmployer)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://api-generator.retool.com/JbW1bY/");
            string urlapp = $"employers/{Employer.Id}";
            

            try
            {
                var json = JsonConvert.SerializeObject(modifiedEmployer);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(urlapp, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeresen módosítva.");
                }
                else
                {
                    MessageBox.Show("Valami hiba történt.");
                }
                this.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show("ModifierEmployer: " + e);
            }
        }
    }
}
