using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDataTable.Models
{
    [Table("Employees")]
    public class EmployeeModel
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string EmpName { get; set; }

        [Range(18, 99)]
        public int EmpAge { get; set; }

        [StringLength(50)]
        public string EmpCity { get; set; }

        [StringLength(50)]
        public string EmpDepartment { get; set; }

        [StringLength(50)]
        public string EmpManager { get; set; }

        public DateTime JoiningDate { get; set; }

        [Range(0, 100000)]
        public int Salary { get; set; }
    }

}