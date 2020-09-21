using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Lib.DomainLayer
{
    public delegate void Log(string log);
    public class SalaryCalculator
    {
        event Log log;

        ISalary plugin;
        TextWriterTraceListener fileListener = new TextWriterTraceListener("log_file.txt");
        TextWriterTraceListener consoleListener = new TextWriterTraceListener(Console.Out);

        public SalaryCalculator()
        {
            this.log += new Log(WriteLog);
            Trace.Listeners.Clear();
            Trace.Listeners.Add(consoleListener);
            Trace.Listeners.Add(fileListener);
            Debug.Listeners.Add(new TextWriterTraceListener("log_file.txt"));

            Object tmp;
            try
            {
                Assembly assembly = Assembly.LoadFile(Path.GetFullPath("Salary Plugin.dll"));

                Type type = assembly.GetType("SalaryPlugin.SalaryPlugin");
                if (type != null)
                {
                    tmp = Activator.CreateInstance(type);
                    if (tmp is ISalary)
                    {
                        plugin = (ISalary)tmp;
                        
                    }
                }
            }
            catch (FileException er) {
                WriteLog("Nelze načíst dll soubor " + er.Message);
                throw new FileException("Nelze načíst dll soubor " + er.Message);
            }
            log("Plugin se načetl");
        }
        public List<List<SalaryResultDTO>> calcSalaryForAll(List<Employee> emp)
        {
            log("Start výpočtu");
            int index = 0;
            List<Thread> threads = new List<Thread>();
            foreach (Employee e in emp)
            {

                //threads.Add(new Thread(delegate () { calcSalaryForEmployee(e); }));       
                log("Start Thread["+index+"]");
                threads.Add(new Thread(delegate () { plugin.calcSalaryForEmployee(e); }));
                index++;
                threads[index-1].Start();
            }
            index = 0;
            foreach (Thread t in threads)
            {
                t.Join();
                log("Ukonćen Thread[" + index + "]");
                index++;
            }
            log("Výpočet ukončen");
            return plugin.resultList;
        }
        
        public List<SalaryResultDTO> getSalaryForEmployee(Employee employee)
        {
            //this.calcSalaryForEmployee(employee);
            plugin.calcSalaryForEmployee(employee);
            List<SalaryResultDTO> result = plugin.resultList[0];
            return result;
        }

       
        public void toXML()
        {
            StringBuilder result = new StringBuilder();
            foreach (List<SalaryResultDTO> emp in plugin.resultList)
            {
                result.AppendLine("Jméno a příjmení: " + emp[0].employee.FirstName + " " + emp[0].employee.LastName);
                foreach (SalaryResultDTO month in emp)
                {
                    string monthName = new DateTime(2019, month.Month, 1).ToString("MMM", CultureInfo.InvariantCulture);
                    result.AppendLine(" Měsíc: " + monthName);
                    result.AppendLine("     Hzubá mzda: " + month.GrossWage);
                    result.AppendLine("     Počet hodin: " + month.Hours);
                    result.AppendLine("     Čistá mzda: " + month.Wage);
                    result.AppendLine("     Sociální pojištění: " + month.SocialInsurance);
                    result.AppendLine("     Zdravotní pojištění: " + month.HealthInsurance);
                    result.AppendLine("");
                }
            }
            string s = result.ToString();
            File.WriteAllText("./Doklad.txt",s);
        }

        private void WriteLog(string log)
        {
            Trace.WriteLine(log);
            Debug.Indent();
            Debug.WriteLine(log);
            Debug.Unindent();
            foreach (TraceListener listener in Trace.Listeners)
            {
                listener.Flush();
            }
        }
    }
}
