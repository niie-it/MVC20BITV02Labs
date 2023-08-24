namespace MyEstoreProject.Models
{
    public class Report
    {
        public string Category { get; set; }  // tên loại
        public string Supplier { get; set; }  // tên nhà cung cấp
        public double Total { get; set; }     // tổng giá trị
        public double Average { get; set; }   // giá trung bình
        public int ItemCount { get; set; }    // tổng số lượng
        public double MinPrice { get; set; }  // giá nhỏ nhất
        public double MaxPrice { get; set; }  // giá lớn nhất
    }
}
