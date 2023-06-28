namespace Lab01.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public double Mark { get; set; }
        public string Grade
        {
            get
            {
                if (Mark >= 8.5) return "A";
                if (Mark >= 7) return "B";
                if (Mark >= 5.5) return "C";
                if (Mark >= 4) return "D";
                return "F";
            }
        }
    }
}
