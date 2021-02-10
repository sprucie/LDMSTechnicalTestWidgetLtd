using System;

namespace LDMSTechnicalTestWidgetLtd.Builders
{
    class EmployeeBuilder
    {
        private readonly Employee _employee;

        public EmployeeBuilder()
        {
            _employee = new Employee();
        }

        public static Employee CEO()
        {
            var employee = new Employee
            {
                EmployeeId = 00001,
                EmployeeName = RandomStringBuilder.BuildRandomAplhabeticString(10)
                + " " + RandomStringBuilder.BuildRandomAplhabeticString(20),
                JobTitle = "CEO",
                ManagerId = null,
                DateHired = DateTime.Now.AddYears(-10).Date,
                Salary = 1000000,
                DepartmentId = 1
            };

            return employee;
        }

        public static Employee EngineeringManager()
        {
            var employee = new Employee
            {
                EmployeeId = 00002,
                EmployeeName = RandomStringBuilder.BuildRandomAplhabeticString(10)
                + " " + RandomStringBuilder.BuildRandomAplhabeticString(20),
                JobTitle = "Manager",
                ManagerId = 00001,
                DateHired = DateTime.Now.AddYears(-4).Date,
                Salary = 25000,
                DepartmentId = 2
            };

            return employee;
        }

        public static Employee ResearchAndDevelopementManager()
        {
            var employee = new Employee
            {
                EmployeeId = 00003,
                EmployeeName = RandomStringBuilder.BuildRandomAplhabeticString(10)
                + " " + RandomStringBuilder.BuildRandomAplhabeticString(20),
                JobTitle = "Manager",
                ManagerId = 00001,
                DateHired = DateTime.Now.AddYears(-4).Date,
                Salary = 22000,
                DepartmentId = 3
            };

            return employee;
        }

        public static Employee SalesManager()
        {
            var employee = new Employee
            {
                EmployeeId = 00004,
                EmployeeName = RandomStringBuilder.BuildRandomAplhabeticString(10)
                + " " + RandomStringBuilder.BuildRandomAplhabeticString(20),
                JobTitle = "Manager",
                ManagerId = 00001,
                DateHired = DateTime.Now.AddYears(-4).Date,
                Salary = 23000,
                DepartmentId = 4
            };

            return employee;
        }

        public static Employee BuildValidEmployee()
        {
            return new EmployeeBuilder()
                .WithEmployeeID()
                .WithEmployeeName()
                .WithEmployeeJobTitle()
                .WithManagerId()
                .WithDateHired()
                .WithEmployeeSalary()
                .WithDepartmentId()
                .Build();
        }

        public EmployeeBuilder WithEmployeeID()
        {
            _employee.EmployeeId = RandomStringBuilder.BuildRandomNumeric(10);

            return this;
        }

        public EmployeeBuilder WithEmployeeName()
        {
            _employee.EmployeeName = RandomStringBuilder.BuildRandomAplhabeticString(10)
                + " " + RandomStringBuilder.BuildRandomAplhabeticString(20);

            return this;
        }

        public EmployeeBuilder WithEmployeeJobTitle()
        {
            var random = new Random();
            var list = new System.Collections.Generic.List<string> { "SalesPerson", "Engineer", "Secretary", "Research & Developement" };
            var index = random.Next(list.Count);
            string jobTitel = list[index];

            _employee.JobTitle = jobTitel;

            return this;
        }

        public EmployeeBuilder WithManagerId()
        {
            switch (_employee.JobTitle)
            {
                case "SalesPerson":
                    _employee.ManagerId = 00004;
                    break;
                case "Engineer":
                    _employee.ManagerId = 00002;
                    break;
                case "Research & Developement":
                    _employee.ManagerId = 00003;
                    break;
                default:
                    _employee.ManagerId = 00001;
                    break;
            }
            _employee.ManagerId = 00001;

            return this;
        }

        public EmployeeBuilder WithDateHired()
        {
            var rnd = new Random();
            var date = rnd.Next(1, 11);

            _employee.DateHired = DateTime.Now.AddYears(-date).Date;

            return this;
        }

        public EmployeeBuilder WithEmployeeSalary()
        {
            var rnd = new Random();
            var salary = rnd.Next(10000, 25001);

            _employee.Salary = salary;

            return this;
        }

        public EmployeeBuilder WithDepartmentId()
        {
            var rnd = new Random();
            var department = rnd.Next(1, 5);

            _employee.DepartmentId = department;

            return this;
        }

        public Employee Build()
        {
            return _employee;
        }
    }
}