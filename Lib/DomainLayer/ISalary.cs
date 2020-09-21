using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DomainLayer
{
    public interface ISalary
    {
        List<List<SalaryResultDTO>> resultList { get; }

        void calcSalaryForEmployee(Employee employee);

    }
}
