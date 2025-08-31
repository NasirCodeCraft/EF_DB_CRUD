using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EF_DB_FIRST_PROJECT.Models
{
    public class StudentDBContext: DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options)
         : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
    }
}
