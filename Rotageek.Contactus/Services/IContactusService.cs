using System.Threading.Tasks;

namespace Rotageek.Contactus.Services
{
    public interface IContactusService
    {
        Task Create(Models.Contactus contactus);
    }
}