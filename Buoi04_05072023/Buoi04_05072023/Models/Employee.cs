using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Buoi04_05072023.Models
{
    public enum Gender { Male, Female }

    public class Employee
    {
        public Guid? Id { get; set; }


        [RegularExpression("EMP[0-9]{5}")]
        public string EmployeeId { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Từ 3 - 100 kí tự")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Compare("Email", ErrorMessage ="Không khớp")]
        public string ConfirmEmail { get; set; }


        [Display(Name = "Website")]
        [Url]
        public string Website { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Giới tính")]
        public Gender Gender { get; set; }

        [Display(Name = "Lương")]
        [Range(0, 10000000)]
        public double Salary { get; set; }

        [Display(Name = "Bán thời gian")]
        public bool IsPartTime { get; set; }

        [Display(Name = "Địa chỉ")]
        [RegularExpression("[a-zA-Z 0-9]*")]
        public string Address { get; set; }

        [Display(Name = "Điện thoại")]
        [RegularExpression("0[35789][0-9]{8}")]
        public string Phone { get; set; }

        [Display(Name = "Số tài khoản")]
        [DataType(DataType.CreditCard)]
        public string CreditCard { get; set; }

        [Display(Name = "Thông tin thêm")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
