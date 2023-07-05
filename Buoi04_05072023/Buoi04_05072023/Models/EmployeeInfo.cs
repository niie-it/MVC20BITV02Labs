using System.ComponentModel.DataAnnotations;

namespace Buoi04_05072023.Models
{
    public class EmployeeInfo
    {
        [Display(Name ="Họ tên")]
        [MinLength(5, ErrorMessage ="Tối thiểu 5 kí tự")]
        public string FullName { get; set; }

        [Display(Name = "Tuổi")]
        [Range(18, 60, ErrorMessage ="Tuổi từ 18 - 60")]
        public int Age { get; set; }
    }
}
