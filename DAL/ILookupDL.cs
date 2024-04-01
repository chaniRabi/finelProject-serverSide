using DAL.Models;

namespace DAL
{
    public interface ILookupDL
    {
     public Task<List<Contct>> GetContcts();
     public Task<List<Status>> GetStatus();
    }
}