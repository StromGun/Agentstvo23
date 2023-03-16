using Agentstvo23.DAL.Entities.Estates;
using System.Collections.ObjectModel;

namespace Agentstvo23.Services.Interfaces
{
    internal interface IGetBuildingData
    {
        ObservableCollection<Building> GetBuilding();
    }
}
