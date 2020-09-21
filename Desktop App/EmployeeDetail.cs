using Lib.DomainLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_App
{
    public partial class EmployeeDetail : Form
    {
        private Employee employee;
        public EmployeeDetail(Employee employee)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("cz-CZ");
            
            this.employee = employee;

            InitializeComponent();

            LastName.Text = employee.LastName;
            FirstName.Text = employee.FirstName;
            Email.Text = employee.Email;
            Salary.Text = employee.SalaryValue.ToString();
            Street.Text = employee.address.Street;
            City.Text = employee.address.City;
            PSC.Text = employee.address.PSC.ToString();


            StringBuilder sb = new StringBuilder();
            foreach(Salary s in employee.salaryList)
            {
                sb.AppendLine("Datum: " + s.Date.ToString(Thread.CurrentThread.CurrentUICulture) + "    Hodiny: " + s.Hours);
            }
            textBox.Text = sb.ToString();

        }

        private void czen_Click(object sender, EventArgs e)
        {
            if(Thread.CurrentThread.CurrentUICulture.Name == "cz-CZ")
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            else
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("cz-CZ");

            StringBuilder sb = new StringBuilder();
            foreach (Salary s in employee.salaryList)
            {
                sb.AppendLine("Datum: " + s.Date.ToString(Thread.CurrentThread.CurrentUICulture) + "    Hodiny: " + s.Hours.ToString(Thread.CurrentThread.CurrentUICulture));
            }
            textBox.Text = sb.ToString();
        }
    }
}
