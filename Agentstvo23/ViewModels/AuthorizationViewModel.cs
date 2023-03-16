using Agentstvo23.DAL.Context;
using Agentstvo23.Infrastructure.Commands;
using Agentstvo23.ViewModels.Base;
using System.Linq;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace Agentstvo23.ViewModels
{
    internal class AuthorizationViewModel : ViewModel
    {
        private string _title = "Авторизация";
        private string login;
        private string password;


        private readonly RealEstateDB DataBase;

        public MainWindowViewModel mainModel { get; set; }

        public string Title { get => _title; set => Set(ref _title, value); }
        public string Login { get => login; set => Set(ref login, value); }
        public string Password { get => password; set => Set(ref password, value); }


        #region Commands
        private LambdaCommand? authorization;
        public ICommand AuthorizationCmd => authorization
            ??= new(CanAuthorizationExecuted);
        private void CanAuthorizationExecuted()
        {
            var user = DataBase.Users.FirstOrDefault(p => p.Login.Equals(Login) && p.Password.Equals(Password));
            if (user != null)
            {
                mainModel.CurrentView = mainModel.NavigationVm;
                mainModel.User = user;
                mainModel.Load();
            }
            else MessageBox.Show("Неверные данные");
        }
        #endregion


        public AuthorizationViewModel(RealEstateDB dB)
        {
            DataBase = dB;
        }
    }
}
