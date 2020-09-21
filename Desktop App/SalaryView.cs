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
    public partial class SalaryView : Form
    {
        SalaryCalculator calc;
        public SalaryView()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("cz-CZ");
            InitializeComponent();
            int count = 0;
            StringBuilder result = new StringBuilder();
            calc = new SalaryCalculator();
            foreach (List<SalaryResultDTO> emp in calc.calcSalaryForAll(Employee.getList())) {
                result.AppendLine("Jméno a příjmení: " + emp[count].employee.FirstName + " " + emp[count].employee.LastName);
                foreach (SalaryResultDTO month in emp)
                {
                    string monthName = new DateTime(2019, month.Month, 1).ToString("MMMM", CultureInfo.GetCultureInfo("cz-CZ"));
                    result.AppendLine(" Měsíc: " + monthName);
                    result.AppendLine("     Hzubá mzda: " + month.GrossWage);
                    result.AppendLine("     Počet hodin: " + month.Hours);
                    result.AppendLine("     Čistá mzda: " + month.Wage);
                    result.AppendLine("     Sociální pojištění: " + month.SocialInsurance);
                    result.AppendLine("     Zdravotní pojištění: " + month.HealthInsurance);
                    result.AppendLine("");
                }
                count++;
            }
            textBox.Text = result.ToString();
        }

        public SalaryView(Employee emp)
        {
            InitializeComponent();
            StringBuilder result = new StringBuilder();
            calc = new SalaryCalculator();
            foreach (SalaryResultDTO month in calc.getSalaryForEmployee(emp))
            {
                string monthName = new DateTime(2019, month.Month, 1).ToString("MMM", CultureInfo.InvariantCulture);
                result.AppendLine("Měsíc: " + monthName);
                result.AppendLine(" Hzubá mzda: " + month.GrossWage);
                result.AppendLine(" Počet hodin: " + month.Hours);
                result.AppendLine(" Čistá mzda: " + month.Wage);
                result.AppendLine(" Sociální pojištění: " + month.SocialInsurance);
                result.AppendLine(" Zdravotní pojištění: " + month.HealthInsurance);
                result.AppendLine("");
            }
            textBox.Text = result.ToString();
        }

        private void Doklad_Click(object sender, EventArgs e)
        {
            calc.toXML();
        }
    }
}
