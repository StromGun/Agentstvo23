using Agentstvo23.Infrastructure.Commands.Base;
using Agentstvo23.ViewModels.Base;
using System;
using System.ComponentModel;

namespace Agentstvo23.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object?> _Execute;
        private readonly Func<object?, bool>? _CanExecute;

        public LambdaCommand(Action Execute, Func<bool>? CanExecute = null) 
            : this(_ => Execute(), CanExecute is null ? null : _ => CanExecute()) { }

        public LambdaCommand(Action<object?> ExecuteAction, Func<bool>? CanExecute) : this(ExecuteAction, CanExecute is null ? null : _ => CanExecute!()) { }

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

    internal class LambdaCommand<T> : Command
    {

        #region Поля

        /// <summary>Делегат основного тела команды</summary>
        protected Action<T?>? _ExecuteAction;

        /// <summary>Функция определения возможности исполнения команды</summary>
        protected Func<T?, bool>? _CanExecute;

        #endregion

        public LambdaCommand(Action<T?> ExecuteAction, Func<bool>? CanExecute)
        : this(ExecuteAction, CanExecute is null ? null : new Func<T?, bool>(_ => CanExecute()))
        { }

        public LambdaCommand(Action<T?> ExecuteAction, Func<T?, bool>? CanExecute = null)
        {
            _ExecuteAction = ExecuteAction ?? throw new ArgumentNullException(nameof(ExecuteAction));
            _CanExecute =  CanExecute;
        }


        public static T ConvertParameter(object? parameter)
        {
            switch (parameter)
            {
                case null: return default!;
                case T result: return result;
            }

            var command_type = typeof(T);
            var parameter_type = parameter.GetType();

            if (command_type.IsAssignableFrom(parameter_type))
                return (T)parameter;

            var command_type_converter = TypeDescriptor.GetConverter(command_type);
            if (command_type_converter.CanConvertFrom(parameter_type))
                return ((T)command_type_converter.ConvertFrom(parameter))!;

            var parameter_converter = TypeDescriptor.GetConverter(parameter_type);
            if (parameter_converter.CanConvertTo(command_type))
                return (T)parameter_converter.ConvertFrom(parameter)!;

            return default!;
        }

        public override void Execute(object? parameter)
        {

            var execute_action = _ExecuteAction;

            if (parameter is not T value)
                value = parameter is null
                    ? default!
                    : ConvertParameter(parameter);

            if (_CanExecute?.Invoke(value!) == false) return;
            try
            {
                execute_action.Invoke(value!);
            }
            catch (Exception error)
            {
         
            }
        }
    }
}
