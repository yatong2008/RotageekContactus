using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rotageek.Contactus.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Models.Contactus> Contactuses { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
