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
    [Scope(Feature = "Generate Report For Employees In Location")]
    [Binding]
    public sealed class GenerateReportForEmployeesInLocationSteps
    {
        private List<Department> _listOfDepartments;
        private List<Employee> _listOfEmployees;
        private List<EmployeesInLocation> _listOfEmployeesInLocation;
        private string _location;

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
        public void WhenAReportIsGeneratedWith(string location)
        {
            _location = location;

            _listOfEmployeesInLocation = new CreateEmployeesInLocationReport(_listOfEmployees, _listOfDepartments).CreateEmployeesInLocationReportWithLocationProvided(_location);

            OutPutEmployeesInDepartmentInReport();
        }

        [Then(@"the report contains employees for that location")]
        public void ThenTheReportContainsEmployeesForThatLocation()
        {
            var listOfEmployeesMatchLocation = ListOfEmployeesWithLocation();

            Assert.That(listOfEmployeesMatchLocation.Count(), Is.GreaterThanOrEqualTo(1),
                $"Expected to get a record of employees for [location {_location}].");
            Assert.That(_listOfEmployeesInLocation, Is.Not.Empty,
                $"Expected the report to contain Employees in [location {_location}].");
            Assert.AreEqual(listOfEmployeesMatchLocation.Count(), _listOfEmployeesInLocation.Count(),
                $"Expected Employees recorded to be same in Report for [location {_location}].");
        }

        [Then(@"the report does not contain for that location")]
        public void ThenTheReportDoesNotContainForThatLocation()
        {
            var listOfEmployeesMatchLocation = ListOfEmployeesWithLocation();

            Assert.That(listOfEmployeesMatchLocation.Count(), Is.EqualTo(0),
                $"Expected not to get a record of employees for [location {_location}].");
            Assert.That(_listOfEmployeesInLocation, Is.Empty,
                $"Expected the report not to contain Employees in [location {_location}].");
        }

        private List<Employee> ListOfEmployeesWithLocation()
        {
            var departmentWithMatchedLocation = _listOfDepartments.Where(x => x.Location == _location);

            var listOfEmployeesInDepartment = new List<Employee>();

            foreach (var item in departmentWithMatchedLocation)
            {
                var departmentId = item.DepartmentId;
                var departmentName = item.DepartmentName;

                listOfEmployeesInDepartment = _listOfEmployees.Where(x => x.DepartmentId == departmentId).ToList();

                OutPutEmployeesInDepartmentRecorded(departmentName, departmentId, listOfEmployeesInDepartment);
            }
            return listOfEmployeesInDepartment;
        }

        private void OutPutEmployeesInDepartmentRecorded(string departmentName, int departmentId, List<Employee> listOfEmployees)
        {
            Console.WriteLine($"List of Employees recorded for Deparment [departmentId {departmentId}].");

            listOfEmployees.ForEach(delegate (Employee e)
            {
                Console.WriteLine("EmployeeId : {0}", e.EmployeeId);
                Console.WriteLine("EmployeeName : {0}", e.EmployeeName);
                Console.WriteLine("JobTitle : {0}", e.JobTitle);
                Console.WriteLine("Salary : {0}", e.Salary);
                Console.WriteLine("DepartmentName : {0}", departmentName);
            });
        }
        private void OutPutEmployeesInDepartmentInReport()
        {
            Console.WriteLine($"List of Employees recorded for Location [location {_location}].");

            _listOfEmployeesInLocation.ForEach(delegate (EmployeesInLocation l)
            {
                Console.WriteLine("EmployeeId : {0}", l.EmployeeId);
                Console.WriteLine("EmployeeName : {0}", l.EmployeeName);
                Console.WriteLine("JobTitle : {0}", l.JobTitle);
                Console.WriteLine("Salary : {0}", l.Salary);
                Console.WriteLine("DepartmentName : {0}", l.DepartmentName);
            });
        }
    }
}