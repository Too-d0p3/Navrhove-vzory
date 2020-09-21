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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            EmployeeAuthentication auth = new EmployeeAuthentication();
            if (auth.Login(Email.Text, Password.Text))
            {
                /*Home home = new Home(auth);
                home.ShowDialog();*/

                
                    var frm = new CarList(auth);
                    frm.Location = this.Location;
                    frm.StartPosition = FormStartPosition.Manual;
                    frm.FormClosing += delegate { this.Show(); };
                    frm.Show();
                    this.Hide();
                 
            }
            else
                ErrorMessage.Visible = true;
        }
    }
}
