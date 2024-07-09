using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SRP03
{
    public enum ContractType
    {
        Yearly,
        Hourly,
        ProjectBased,
    }
    namespace Invalid
    {
        public class Employee
        {
            public string? Name { get; set; }
            public int Id { get; set; }
            public ContractType ContractType { get; set; }
            public double Salary { get; set; }

            public void CalculateSalary()
            {
                switch (this.ContractType)
                {
                    case ContractType.Yearly:
                        // Calculate by year.
                        break;
                    case ContractType.Hourly:
                        // Calculate by month.
                        break;
                    case ContractType.ProjectBased:
                        // Calculate by project.
                        break;
                    default:
                        break;
                }
            }

            public void GenerateReport()
            {
                // Report generation logic
            }

            public void SaveToDatabase()
            {
                // Database save logic
            }
        }

    }

    // Ask the developers to try to write it
    //  Change `CalculateSalary` to take a collection `Employee`s.
    namespace Valid
    {
        public class Employee
        {
            public string? Name { get; set; }
            public int Id { get; set; }
            public double Salary { get; set; }
            public ContractType ContractType { get; set; }
        }

        public class SalaryCalculator
        {
            public static void CalculateSalary(in List<Employee> employees)
            {
                Parallel.ForEach(employees, static employee =>
                {
                    switch (employee.ContractType)
                    {
                        case ContractType.Yearly:
                            employee.Salary = calculateYearlySalary(1000, 165);
                            break;
                        case ContractType.Hourly:
                            employee.Salary =calculateHourlySalary();
                            break;
                        case ContractType.ProjectBased:
                            employee.Salary = calculateProjectBasedSalary();
                            break;
                        default:
                            break;
                    }
                });

                // Why bad idea?
                static double calculateYearlySalaryBadIdea(Employee employee) => 1000;
                static double calculateYearlySalary(double fullTimeSalary, double workedHours) => 1000;
                static double calculateHourlySalary() => 1000;
                static double calculateProjectBasedSalary() => 1000;
            }            
        }

        public class EmployeeReportGenerator
        {
            public void GenerateReport(Employee employee)
            {
                // Report generation logic
            }
        }

        public class EmployeeRepository
        {
            public void SaveToDatabase(Employee employee)
            {
                // Database save logic
            }
        }

    }
}