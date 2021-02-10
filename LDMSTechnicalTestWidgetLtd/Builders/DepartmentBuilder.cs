using LDMSTechnicalTestWidgetLtd.Models;
using System.Collections.Generic;

namespace LDMSTechnicalTestWidgetLtd.Builders
{
    public class DepartmentBuilder
    {
        public static List<Department> Departments()
        {
            return new List<Department>
            {
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "Management",
                    Location = "London"
                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "Engineering",
                    Location = "Cardiff"
                },
                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Research & Development",
                    Location = "Edinburgh"
                },
                new Department
                {
                    DepartmentId = 4,
                    DepartmentName = "Sales",
                    Location = "Belfast"
                }
            };
        }
    }
}