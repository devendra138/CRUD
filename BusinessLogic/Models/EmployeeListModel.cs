namespace BusinessLogic.Models
{
    public class EmployeeListModel
    {
        public int? EmployeeId { get; set; }
        public string? Name { get; set; }
        public double? Salary { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public bool? Status { get; set; }
    }
}
