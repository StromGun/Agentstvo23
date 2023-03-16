using Agentstvo23.DAL.Entities.Estates;

namespace Agentstvo23.Services.Interfaces
{
    internal interface IUserDialog
    {
        bool Edit(Building building);

        bool ConfirmedInforamtion(string Information, string Caption);
        bool ConfirmWarning(string Warning, string Caption);
        bool ConfirmError(string Error, string Caption);
    }
}
