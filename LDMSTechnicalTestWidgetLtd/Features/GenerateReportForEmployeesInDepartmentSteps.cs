using LDMSTechnicalTestWidgetLtd.Models;
using LDMSTechnicalTestWidgetLtd.Reporting;
using LDMSTechnicalTestWidgetLtd.TestHelpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace LDMSTechnicalTestWidgetLtd.Features
{
    [Scope(Feature = "Generate Report For Employees In Department")]
    [Binding]
    public sealed class GenerateReportForEmployeesInDepartmentSteps
    {
        private List<Department> _listOfDepartments;
        private List<Employee> _listOfEmployees;
        private List<EmployeesInDepartment> _listOfEmployeesInDepartment;
        private int _departmentId;

        [Given(@"Widget Ltd have a record of their departments")]
        public void GivenWidgetLtdHaveARecordOfTheirDepartments()
        {
            _listOfDepartments = new CreateDepartmentHelper().CreateListOfDepartment();
        }

        [Given(@"Widget Ltd have a record of their employees")]
        public void GivenWidgetLtdHaveARecordOfTheirEmployees()
        {
            _listOfEmployees = new CreateEmployeeHelper().CreateListOfEmployees(6);
        }

        [When(@"a report is generated with '(.*)'")]
        public void WhenAReportIsGeneratedWith(int departmentId)
        {
            _departmentId = departmentId;

            _listOfEmployeesInDepartment = new CreateEmployeesInDepartmentReport(_listOfEmployees).CreateEmployeesinDepartmentReportWithDepartmentId(_departmentId);

            OutPutEmployeesInDepartmentInReport();
        }

        [Then(@"the report contains employees for that department")]
        public void ThenTheReportContainsEmployeesForThatDepartment()
        {
            OutPutEmployeesInDepartmentRecorded();

            var countOfEmployeesInDepartment = ListOfEmployeesWithDepartmentId().Count();

            Assert.That(countOfEmployeesInDepartment, Is.GreaterThanOrEqualTo(1),
                $"Expected to get a record of employees for [department {_departmentId}].");
            Assert.That(_listOfEmployeesInDepartment, Is.Not.Empty,
                $"Expected the report to contain Employees in [department {_departmentId}].");
            Assert.AreEqual(countOfEmployeesInDepartment, _listOfEmployeesInDepartment.Count(),
                $"Expected Employees recorded to be same in Report for [departmentId {_departmentId}].");
        }

        [Then(@"the report does not contains employees for that department")]
        public void ThenTheReportDoesNotContainsEmployeesForThatDepartment()
        {
            OutPutEmployeesInDepartmentRecorded();

            var countOfEmployeesInDepartment = ListOfEmployeesWithDepartmentId().Count();

            Assert.That(countOfEmployeesInDepartment, Is.EqualTo(0),
               $"Expected not to get a record back for employees in [department {_departmentId}].");
            Assert.That(_listOfEmployeesInDepartment, Is.Empty,
                $"Expected the report not to contain Employees in [department {_departmentId}].");        
        }

        private List<Employee> ListOfEmployeesWithDepartmentId()
        {
            var employeesMatchDepartmentId = _listOfEmployees.Where(x => x.DepartmentId == _departmentId).ToList();

            return employeesMatchDepartmentId;
        }

        private void OutPutEmployeesInDepartmentRecorded()
        {
            Console.WriteLine($"List of Employees recorded for Deparment [departmentId {_departmentId}].");

            ListOfEmployeesWithDepartmentId().ForEach(delegate (Employee e)
            {
                Console.WriteLine("EmployeeId : {0}", e.EmployeeId);
                Console.WriteLine("EmployeeName : {0}", e.EmployeeName);
                Console.WriteLine("JobTitle : {0}", e.JobTitle);
                Console.WriteLine("Salary : {0}", e.Salary);
            });
        }
        private void OutPutEmployeesInDepartmentInReport()
        {
            Console.WriteLine($"List of Employees recorded for Deparment [departmentId {_departmentId}].");

            _listOfEmployeesInDepartment.ForEach(delegate (EmployeesInDepartment r)
            {
                Console.WriteLine("EmployeeId : {0}", r.EmployeeId);
                Console.WriteLine("EmployeeName : {0}", r.EmployeeName);
                Console.WriteLine("JobTitle : {0}", r.JobTitle);
                Console.WriteLine("Salary : {0}", r.Salary);
            });
        }
    }
}