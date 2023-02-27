using Agentstvo23.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agentstvo23.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "Agentstvo23";
        private ViewModel currentView;

        public string Title { get => _title; set => Set(ref _title, value); }
        public ViewModel CurrentView { get => CurrentView; set => Set(ref currentView, value); }
    }
}
