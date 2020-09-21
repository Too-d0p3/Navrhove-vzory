using Lib.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Console_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            try { 
                Employee test = Employee.GetByID(2);
                Console.WriteLine(test.ID);
                Console.WriteLine(test.FirstName);
                Console.WriteLine(test.LastName);
                Console.WriteLine(test.address.PSC);
                Console.WriteLine(test.SalaryValue);
                Console.WriteLine(test.isAdmin);
                Console.WriteLine(test.salaryList[1].Hours);
            }
            catch
            {
                Console.WriteLine("Zadny zaznam");
            }


            List<Employee> list = Employee.getList();
            foreach(Employee emp in list)
            {
                Console.WriteLine(emp.ID);
                Console.WriteLine(emp.FirstName);
                Console.WriteLine(emp.LastName);
                Console.WriteLine(emp.address.Street);
                Console.WriteLine(emp.SalaryValue);
            }

            EmployeeAuthentication auth = new EmployeeAuthentication();
            if(auth.Login("ondra@autobazar.cz", "ondra1"))
            {
                Console.WriteLine("Login succes");
            }else
                Console.WriteLine("Login failed");

            if (auth.Login("ondra@autobazar.cz", "ondra"))
            {
                Console.WriteLine("Login succes");
                Console.WriteLine(auth.employee.Email);
            }
            else
                Console.WriteLine("Login failed");



            List<Car> cars = Car.getCarsByUserID(1);
            foreach(Car car in cars)
            {
                Console.WriteLine(car.user.Email);
            }

            Employee test2 = Employee.GetByID(2);
            SalaryCalculator calc = new SalaryCalculator();
            List<SalaryResultDTO> res = calc.getSalaryForEmployee(test2);

            foreach(SalaryResultDTO r in res)
            {
                Console.WriteLine(r.GrossWage);
                Console.WriteLine(r.Wage);
            }




            Console.WriteLine("AUKCE TEST!!!");

            User user = User.GetByID(2);
            Car b = Car.getCarByID(1);




            //Car.toXML();
            foreach(Car c in Car.loadFromXML())
            {
                Console.WriteLine(c.Name);
            }

            //b.Insert();


            UserAuthentication ua = new UserAuthentication();
            //Console.WriteLine(ua.Login("madamik@gmail.com", "michal"));


        }
    }
}
