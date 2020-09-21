using Lib.DomainLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_App
{
    public partial class UserList : Form
    {
        private EmployeeAuthentication auth;
        private List<Employee> employeeList;
        public UserList(EmployeeAuthentication auth)
        {
            this.auth = auth;
            InitializeComponent();
            this.Visible = true;
            employeeList = Employee.getList();
            foreach(Employee emp in employeeList)
            {
                employeeListBox.Items.Add(emp.FirstName + " " + emp.LastName);
            }
        }

        private void detailButton_Click(object sender, EventArgs e)
        {
            if (employeeListBox.SelectedIndex >= 0) { 
                Employee tmp = employeeList[employeeListBox.SelectedIndex];
                EmployeeDetail form = new EmployeeDetail(tmp);
                form.ShowDialog();
            }
        }

        private void CalcSalary_Click(object sender, EventArgs e)
        {
            Employee tmp = employeeList[employeeListBox.SelectedIndex];
            Console.WriteLine(employeeListBox.SelectedIndex);
            SalaryView form = new SalaryView(tmp);
            form.ShowDialog();
        }

        private void calcAllSalary_Click(object sender, EventArgs e)
        {
            SalaryView form = new SalaryView();
            form.ShowDialog();
        }

        private void CarListLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new CarList(auth);
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }
    }
}
