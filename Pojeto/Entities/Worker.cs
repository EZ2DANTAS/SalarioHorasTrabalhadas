using System;
using Pojeto.Entities.Enums;
using System.Collections.Generic;

namespace Pojeto.Entities
{
    internal class Worker
    {
        public string Name { get; set; }

        //Propriedade do enum do WorkerLevel(Nivel do Trabalhador)
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }

        // Propriedade da Classe Departament
        public Department Departament { get; set; }

        //Foi instanciado para que não fique vazia
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        //Start metod builder
        public Worker() { }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;  
            BaseSalary = baseSalary;
            Departament = department;
        }
       // Ending metod builder


        // Metodo para adicinar Contrato na lista
        public void AddContrac(HourContract contract)
        {
            Contracts.Add(contract);
        }

        // Removendo Contrato na Lista
        public void RemoveContrac(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;

            foreach(HourContract contract in Contracts){
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }

            }
            return sum;
        }
    }
}
