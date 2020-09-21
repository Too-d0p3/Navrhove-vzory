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
    public partial class CarList : Form
    {
        private EmployeeAuthentication auth;
        private List<Car> carList;
        public CarList(EmployeeAuthentication auth)
        {
            this.auth = auth;
            InitializeComponent();
            this.Visible = true;
            carList = Car.getList();
            foreach (Car car in carList)
            {
                carListBox.Items.Add("ID: " + car.ID + "   Název: " + car.Name + " Typ: " + car.Type + "   Email: " + car.user.Email );
            } 
        }

        private void export_Click(object sender, EventArgs e)
        {
            Car.toXML();
        }

        private void import_Click(object sender, EventArgs e)
        {
            carListBox.Items.Clear();       
            foreach (Car car in Car.loadFromXML())
            {
                carListBox.Items.Add("ID: " + car.ID + "   Název: " + car.Name + " Typ: " + car.Type + "   Email: " + car.user.Email);
            }
        }

        private void sync_Click(object sender, EventArgs e)
        {
            Car.syncXmlWithDB(Car.loadFromXML());
        }

        private void clear_Click(object sender, EventArgs e)
        {
            carListBox.Items.Clear();
        }

        private void EmployeeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new UserList(auth);
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
        }
    }
}
