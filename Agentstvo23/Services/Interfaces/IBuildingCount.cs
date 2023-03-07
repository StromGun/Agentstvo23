using System.Threading.Tasks;

namespace Agentstvo23.Services.Interfaces
{
    internal interface IBuildingCount
    {
        Task<int> GetCountAsync();
        Task<int> GetResidentalCountAsync();
        Task<int> GetNonResidentalCountAsync();
        Task<int> GetApartmentCountAsync();
    }
}
