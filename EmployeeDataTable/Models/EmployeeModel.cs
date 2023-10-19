using System.ComponentModel.DataAnnotations;

namespace EmployeeDataTable.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmpName { get; set; }

        public int EmpAge { get; set; }
        public string EmpCity { get; set; }
        public string EmpDepartment { get; set; }
        public string EmpManager { get; set; }
        public DateTime JoiningDate { get; set; }
        public int Salary { get; set; }
    }
}
