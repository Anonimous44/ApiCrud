using ApiCrud.NewFolder;
using Microsoft.EntityFrameworkCore;
namespace ApiCrud.Context
{
    public class PatrocinioContex : DbContext
    {
        public PatrocinioContex(DbContextOptions<PatrocinioContex> options) : base(options)
        {
        }
        public DbSet<Patrocinio> Patrocinio { get; set; }
    }
}
