using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rotageek.Contactus.Data
{
    public interface IDataContext : IDisposable
    {
        DbSet<Models.Contactus> Contactuses { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();

    }
}