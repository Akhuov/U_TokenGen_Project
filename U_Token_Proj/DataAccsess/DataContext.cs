
using Microsoft.EntityFrameworkCore;
using U_Token_Proj.Entities;

namespace U_Token_Proj.DataAccsess
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }
        public required DbSet<User> Users { get; set; }
    }

}
