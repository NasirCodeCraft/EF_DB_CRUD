namespace EF_DB_FIRST_PROJECT.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public decimal CGPA { get; set; }
    }
}
