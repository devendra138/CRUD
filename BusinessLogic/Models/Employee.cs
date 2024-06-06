namespace APICRUDOperations.Models
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public double? Salary { get; set; }
        public int? DesignationId { get; set; }
        public int? GenderId { get; set; }
        public bool? Status { get; set; }
    }
}
