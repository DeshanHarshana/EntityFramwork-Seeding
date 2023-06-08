namespace EntityFramwork_Test.Models
{
    public class Operator
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; } = decimal.MaxValue;
    }
}
