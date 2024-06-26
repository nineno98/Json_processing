﻿using System;
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
        Form2 form2;
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
            LoadDatagridview();
            
            
            
        }

        private void LoadDatagridview()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Salary", "Salary");

            dataGridView1.Columns["Id"].DataPropertyName = "Id";
            dataGridView1.Columns["Name"].DataPropertyName = "Name";
            dataGridView1.Columns["Salary"].DataPropertyName = "Salary";

            dataGridView1.DataSource = employers;
        }

        private async void GetEmployers()
        {
            
            string appurl = "employers";
            try
            {
                var response = client.GetAsync(appurl).Result;
                var jsonresponse = await response.Content.ReadAsStringAsync();
                
                var jsonArray = JArray.Parse(jsonresponse);
                foreach (var item in jsonArray)
                {
                    Employer emp = JsonConvert.DeserializeObject<Employer>(item.ToString());                    
                    employers.Add(emp);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("GetEmployers: "+e.Message);
                
            }
            
            

        }

        private void modifiEmployer_Click(object sender, EventArgs e)
        {
            try
            {
                Employer selectedEmployer = dataGridView1.SelectedRows[0].DataBoundItem as Employer;
                label1.Text = selectedEmployer.ToString();
                form2 = new Form2();
                form2.Employer = selectedEmployer;
                form2.ShowDialog();
                employers.Clear();
                GetEmployers();

            }
            catch (Exception)
            {

                MessageBox.Show("Egy sor ki kell jelölni a módosításhoz!");
            }
            
        }

        private void newEmployer_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            
            employers.Clear();
            GetEmployers();
            
            LoadDatagridview();
            
        }
    }
}
