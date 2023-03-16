using Agentstvo23.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agentstvo23.Infrastructure.Events
{
    internal class ViewModelChangedEventArgs : EventArgs
    {
        public ViewModel ViewModel { get; set; }

    }
}
