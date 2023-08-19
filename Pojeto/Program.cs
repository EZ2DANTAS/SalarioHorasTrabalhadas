using System;
using System.Globalization;
using Pojeto.Entities;
using Pojeto.Entities.Enums;
namespace Pojeto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter departament´s name:");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter Worker data: ");

            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            Console.Write("Enter level Worker (Junior/MidLevel/Senior):");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);
            Console.Clear();
            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.WriteLine("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date,valuePerHour,hours);
                worker.AddContrac(contract);

                Console.Clear();
            }
            
            Console.WriteLine("Enter Month and Year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departament: " + worker.Departament.Name);
            Console.WriteLine("Income for: " + monthAndYear + ": " + "R$"+worker.Income(year, month).ToString("F2",CultureInfo.InvariantCulture));
        }
        }
}