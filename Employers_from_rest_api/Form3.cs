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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            salaryNumUpdown.Minimum = 0;
            salaryNumUpdown.Maximum = 10000;
        }

        private void mentesbutton_Click(object sender, EventArgs e)
        {
            Employer emp = new Employer(nevtextbox.Text, int.Parse(salaryNumUpdown.Value.ToString()));
            MessageBox.Show(emp.ToString());
            AddNewEmployer(emp);
        }

        private async void AddNewEmployer(Employer emp)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://api-generator.retool.com/JbW1bY/");
            string appurl = "employers";

            try
            {
                var json = JsonConvert.SerializeObject(emp);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(appurl, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres hozzáadás");
                }
                else
                {
                    MessageBox.Show("Hiba.");
                }
                this.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show("AddNewEmployer: " + e);
            }
        }
    }
}
