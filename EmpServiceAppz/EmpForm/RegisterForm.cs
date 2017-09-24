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
using EmpRestfulService;
using Newtonsoft.Json;

namespace EmpForm
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }



        private void btnSsave_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.EmployeeAddress = txtAddress.Text;
            emp.EmployeeEmail = txtEmail.Text;
            emp.EmployeeName = txtName.Text;
            emp.EmployeePhoneNo = Convert.ToInt64(txtPhoneNo.Text);
            emp.IsActive = Convert.ToBoolean(chkIsAcctive.Checked);
            string jsonContent = JsonConvert.SerializeObject(emp);
            HttpContent content = new StringContent(jsonContent);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1301/");
            content.Headers.Clear();
            content.Headers.Add("content-type", "application/json");
            HttpResponseMessage responsemployee = client.PostAsync("Employee/SaveEmployee", content).Result;
            string result = responsemployee.Content.ReadAsStringAsync().Result;

            long empIdGet = 0;
            bool isParse = long.TryParse(result, out empIdGet);
            if (isParse)
            {
                ModelSalary sal = new ModelSalary();
                sal.EmployeeId = empIdGet;
                sal.Salary = Convert.ToSingle(txtSalary.Text);
                string salJsonConvert = JsonConvert.SerializeObject(sal);
                content = new StringContent(salJsonConvert);
                content.Headers.Clear();
                content.Headers.Add("content-type", "application/json");

                HttpResponseMessage responseSalary = client.PostAsync("Salary/SaveModelSalary", content).Result;
                string resSalary = responseSalary.Content.ReadAsStringAsync().Result;


                ModelPhoto photo = new ModelPhoto();
                photo.EmployeeId = empIdGet;
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                byte[] buf = new byte[fs.Length];
                fs.Read(buf, 0, buf.Length);
                photo.Photo = buf;
                string phoJsonConvert = JsonConvert.SerializeObject(photo);
                content = new StringContent(phoJsonConvert);
                content.Headers.Clear();
                content.Headers.Add("content-type", "application/json");

                HttpResponseMessage responsePhoto = client.PostAsync("Photo/SaveModelPhoto", content).Result;
                string resPhoto = responsePhoto.Content.ReadAsStringAsync().Result;
                MessageBox.Show(resPhoto);
                Form1 frmForm1 = new Form1(txtName.Text, empIdGet);
                frmForm1.ShowDialog();
            }
            else
            {
                MessageBox.Show(result);
            }

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.Load(openFileDialog1.FileName);
        }
    }
}
