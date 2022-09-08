using System;
using System.Windows.Input;

namespace CryptoInfoWPF.Commands
{
    public class CommandWithParameter : ICommand
    {
        private readonly Action<object> _action;

        public event EventHandler? CanExecuteChanged;

        public CommandWithParameter(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action(parameter);
        }
    }
}
