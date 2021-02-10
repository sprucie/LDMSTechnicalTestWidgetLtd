using LDMSTechnicalTestWidgetLtd.Builders;
using LDMSTechnicalTestWidgetLtd.Models;
using System.Collections.Generic;

namespace LDMSTechnicalTestWidgetLtd.TestHelpers
{
    class CreateDepartmentHelper
    {
        public List<Department> CreateListOfDepartment()
        {
            return DepartmentBuilder.Departments();
        }
    }
}