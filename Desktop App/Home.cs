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
    public partial class Home : Form
    {
        private EmployeeAuthentication auth;
        public Home(EmployeeAuthentication auth)
        {
            this.auth = auth;
            InitializeComponent();
            //test.Text = auth.employee.FirstName;
        }
    }
}
