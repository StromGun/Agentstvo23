using Agentstvo23.Infrastructure.Commands.Base;
using System;

namespace Agentstvo23.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object?> _Execute;
        private readonly Func<object?, bool>? _CanExecute;

        public LambdaCommand(Action Execute, Func<bool>? CanExecute = null) 
            : this(_ => Execute(), CanExecute is null ? null : _ => CanExecute()) { }

        public LambdaCommand(Action<object?> Execute, Func<object?, bool>? CanExecute = null)
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object? parameter) => base.CanExecute(parameter) && (_CanExecute?.Invoke(parameter) ?? true);

        public override void Execute(object? parameter)
        {
            if (!CanExecute(parameter)) return;
            _Execute(parameter);
        }
    }
}
