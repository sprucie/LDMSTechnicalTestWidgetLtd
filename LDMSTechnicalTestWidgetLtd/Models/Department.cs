namespace LDMSTechnicalTestWidgetLtd.Models
{
    public class Department
    {
        /// <summary>
        /// The unique identifier for the department.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// The name of the department.
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// The physical location of the department.
        /// </summary>
        public string Location { get; set; }
    }
}