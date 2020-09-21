using Lib.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_App
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EmployeeAuthentication auth = new EmployeeAuthentication();
            auth.Login("ondra@autobazar.cz", "ondra");
            //Application.Run(new Form1());
            Application.Run(new UserList(auth));

        }
    }
}
