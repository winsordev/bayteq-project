using PetstoreApp.Models;

namespace PetstoreApp.Services
{
    public interface IMascotaServices
    {
        Task<List<Mascota>> GetByStatus(string status);
    }
}
