using ExamesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamesAPI.Data
{
    public class ExameContext : DbContext
    {

        public ExameContext(DbContextOptions<ExameContext> opt) : base(opt)

        {

        }

        public DbSet<Exames> Exames { get; set; }
    }
}
