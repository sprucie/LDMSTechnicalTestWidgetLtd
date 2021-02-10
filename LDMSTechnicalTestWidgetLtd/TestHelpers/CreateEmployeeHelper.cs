using LDMSTechnicalTestWidgetLtd.Builders;
using System.Collections.Generic;

namespace LDMSTechnicalTestWidgetLtd.TestHelpers
{
    public class CreateEmployeeHelper
    {
        public List<Employee> CreateListOfEmployees(int numberOfEmployees)
        {
            var listOfEmployees = new List<Employee>
            {
                EmployeeBuilder.CEO(),
                EmployeeBuilder.EngineeringManager(),
                EmployeeBuilder.ResearchAndDevelopementManager(),
                EmployeeBuilder.SalesManager()
            };

            var employee = new Employee();

            for (var i = 1; i <= numberOfEmployees; i++)
            {
                employee = EmployeeBuilder.BuildValidEmployee();

                listOfEmployees.Add(employee);
            }

            return listOfEmployees;
        }
    }
}