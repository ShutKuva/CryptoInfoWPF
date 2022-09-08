using System;
using System.Windows.Input;

namespace CryptoInfoWPF.Commands
{
    public class CommandWithoutParameters : ICommand
    {
        private readonly Action _action;

        public event EventHandler? CanExecuteChanged;

        public CommandWithoutParameters(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action?.Invoke();
        }
    }
}
