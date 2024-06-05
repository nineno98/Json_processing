using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Employers_from_rest_api
{
    public partial class Form1 : Form
    {
        private HttpClient client;
        private List<Employer> employers;
        public Form1()
        {
            employers = new List<Employer>();
            ClientSetup();
            InitializeComponent();
        }

        private void ClientSetup()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api-generator.retool.com/JbW1bY/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            GetEmployers();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Salary", "Salary");

            dataGridView1.Columns["Id"].DataPropertyName = "Id";
            dataGridView1.Columns["Name"].DataPropertyName = "Name";
            dataGridView1.Columns["Salary"].DataPropertyName = "Salary";

            dataGridView1.DataSource = employers;
            label1.Text = employers.Count().ToString();
        }

        private async void GetEmployers()
        {
            
            string appurl = "employers";
            try
            {
                var response = client.GetAsync(appurl).Result;
                var jsonresponse = await response.Content.ReadAsStringAsync();
                //MessageBox.Show(jsonresponse);
                var jsonArray = JArray.Parse(jsonresponse);
                foreach (var item in jsonArray)
                {
                    Employer emp = JsonConvert.DeserializeObject<Employer>(item.ToString());
                    //MessageBox.Show(emp.ToString());
                    employers.Add(emp);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("GetEmployers: "+e.Message);
                
            }
            
            

        }
    }
}
