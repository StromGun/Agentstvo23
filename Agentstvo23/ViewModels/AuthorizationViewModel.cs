using Agentstvo23.DAL.Context;
using Agentstvo23.ViewModels.Base;
using System.Security;

namespace Agentstvo23.ViewModels
{
    internal class AuthorizationViewModel : ViewModel
    {
        private string _title = "Авторизация";
        private string login;
        private SecureString password;


        private readonly RealEstateDB DataBase;

        public string Title { get => _title; set => Set(ref _title, value); }
        public string Login { get => login; set => Set(ref login, value); }
        public SecureString Password { get => password; set => Set(ref password, value); }

        public AuthorizationViewModel(RealEstateDB dB)
        {
            DataBase = dB;
        }
    }
}
