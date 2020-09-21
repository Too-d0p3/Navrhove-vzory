using Lib.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryPlugin
{
    class SalaryPlugin : ISalary
    {
        private List<List<SalaryResultDTO>> _resultList = new List<List<SalaryResultDTO>>();
        public List<List<SalaryResultDTO>> resultList { get => _resultList ; }

        Func<int, double, int> insurance = (x,y) => Convert.ToInt32(Math.Round(Convert.ToDouble(x) * y));

        public void calcSalaryForEmployee(Employee employee)
        {
            HashSet<int> months = new HashSet<int>();

            foreach (Salary salary in employee.salaryList)
            {
                months.Add(salary.Date.Month);
            }

            List<SalaryResultDTO> result = new List<SalaryResultDTO>();

            foreach (int month in months)
            {
                Console.WriteLine(month);
                int hours = 0;

                foreach (Salary s in getMonthListSalary(employee.salaryList, month))
                {
                    hours += s.Hours;
                }

                int grossWage = hours * employee.SalaryValue;
                int healthInsurance = insurance(grossWage, 0.065);
                int socialInsurance = insurance(grossWage, 0.045);
                int wage = grossWage - healthInsurance - socialInsurance;

                result.Add(new SalaryResultDTO
                {
                    Hours = hours,
                    GrossWage = grossWage,
                    Month = month,
                    Year = 2019,
                    HealthInsurance = healthInsurance,
                    SocialInsurance = socialInsurance,
                    Wage = wage,
                    employee = employee
                });
            }
            _resultList.Add(result);
        }

        private List<Salary> getMonthListSalary(List<Salary> salary, int month)
        {
            List<Salary> monthSalary = new List<Salary>();
            foreach (Salary s in salary)
            {
                if (s.Date.Month == month)
                {
                    monthSalary.Add(s);
                }
            }
            return monthSalary;
        }
    }
}
