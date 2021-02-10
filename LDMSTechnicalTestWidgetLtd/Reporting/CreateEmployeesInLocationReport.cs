using LDMSTechnicalTestWidgetLtd.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LDMSTechnicalTestWidgetLtd.Reporting
{
    public class CreateEmployeesInLocationReport
    {
        private List<Employee> _listOfEmployees;
        private List<Department> _listOfDepartment;
        public CreateEmployeesInLocationReport(List<Employee> listOfEmployees, List<Department> listOfDepartmnets)
        {
            _listOfEmployees = listOfEmployees;
            _listOfDepartment = listOfDepartmnets;
        }

        public List<EmployeesInLocation> CreateEmployeesInLocationReportWithLocationProvided(string location)
        {
            var departmentWithMatchedLocation = _listOfDepartment.Where(x => x.Location == location);

            if (departmentWithMatchedLocation == null)
            {
                throw new Exception($"No department found for location [{location}].");
            }

            var listOfEmployeesInDepartment = new List<Employee>();
            var employeesInLocation = new List<EmployeesInLocation>();

            foreach (var item in departmentWithMatchedLocation)
            {
                var departmentId = item.DepartmentId;
                var departmentName = item.DepartmentName;

                listOfEmployeesInDepartment = _listOfEmployees.Where(x => x.DepartmentId == departmentId).ToList();

                foreach (var listOfEmployee in listOfEmployeesInDepartment)
                {
                    employeesInLocation.Add(new EmployeesInLocation
                    {
                        EmployeeId = listOfEmployee.EmployeeId,
                        EmployeeName = listOfEmployee.EmployeeName,
                        JobTitle = listOfEmployee.JobTitle,
                        Salary = listOfEmployee.Salary,
                        DepartmentName = departmentName
                    });
                }
            }           

            return employeesInLocation;
        }
    }
}