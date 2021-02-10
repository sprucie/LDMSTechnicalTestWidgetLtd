using LDMSTechnicalTestWidgetLtd.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LDMSTechnicalTestWidgetLtd.Reporting
{
    public class CreateEmployeesInDepartmentReport
    {
        private readonly List<Employee> _listOfEmployees;

        public CreateEmployeesInDepartmentReport(List<Employee> listOfEmployees)
        {
            _listOfEmployees = listOfEmployees;
        }
        public List<EmployeesInDepartment> CreateEmployeesinDepartmentReportWithDepartmentId(int departmentId)
        {
            var listOfEmployeesinDepartment = _listOfEmployees.Where(x => x.DepartmentId == departmentId);

            if (listOfEmployeesinDepartment == null)
            {
                throw new Exception($"No Employees found for department [{departmentId}].");
            }

            var employeesInDepartments = new List<EmployeesInDepartment>();

            foreach (var listOfEmployee in listOfEmployeesinDepartment)
            {
                employeesInDepartments.Add(new EmployeesInDepartment
                {
                    EmployeeId = listOfEmployee.EmployeeId,
                    EmployeeName = listOfEmployee.EmployeeName,
                    JobTitle = listOfEmployee.JobTitle,
                    Salary = listOfEmployee.Salary
                });
            }

            return employeesInDepartments;
        }
    }
}