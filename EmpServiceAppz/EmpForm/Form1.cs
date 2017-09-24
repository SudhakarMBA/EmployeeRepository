using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EmpForm
{
    public partial class Form1 : Form
    {
        private string _empName;
        private long _empId;
        public Form1(string empName, long employeeId)
        {
            InitializeComponent();
            _empName = empName;
            _empId = employeeId;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1301/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responsemployee = client.GetAsync("Employee/GetEmployee?employeeName=" + _empName).Result;
            string result = responsemployee.Content.ReadAsStringAsync().Result;

            Employee emp = JsonConvert.DeserializeObject<Employee>(result);
            label1.Text = emp.EmployeeName;
            label2.Text = emp.EmployeeAddress;
            label3.Text = emp.EmployeeEmail;
            label4.Text = emp.EmployeePhoneNo.ToString();

            HttpResponseMessage responsPhoto = client.GetAsync("Photo/GetModelPhoto?employeeId=" + _empId).Result;
            string resultPhoto = responsPhoto.Content.ReadAsStringAsync().Result;
            ModelPhoto phot = JsonConvert.DeserializeObject<ModelPhoto>(resultPhoto);
            pictureBox1.Image = Image.FromStream(new MemoryStream(phot.Photo));

        }
    }
}
