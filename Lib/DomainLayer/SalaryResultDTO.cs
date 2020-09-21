using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DomainLayer
{
    public class SalaryResultDTO
    {
        public Employee employee { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int GrossWage { get; set; }
        public int SocialInsurance { get; set; }
        public int HealthInsurance { get; set; }
        public int Hours { get; set; }
        public int Wage { get; set; }
    }
}
