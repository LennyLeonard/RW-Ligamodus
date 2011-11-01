using System;
using System.Windows.Input;

namespace Teammanager.Core
{
    public class CommandHelper : ICommand
    {
        public CommandHelper()
        {
        }
        public CommandHelper(Action<object> executeFunction)
        {
            ExecuteFunction = executeFunction;
        }
        public CommandHelper(Action<object> executeFunction, Func<object, bool> canExecuteFunction)
        {
            ExecuteFunction = executeFunction;
            CanExecuteFunction = canExecuteFunction;
        }

        public Func<object, bool> CanExecuteFunction;
        public bool CanExecute(object parameter)
        {
            if (CanExecuteFunction != null)
                return CanExecuteFunction(parameter);
            return true;
        }

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(sender ?? this, e ?? EventArgs.Empty);
        }

        public Action<object> ExecuteFunction;
        public void Execute(object parameter)
        {
            if (ExecuteFunction != null)
                ExecuteFunction(parameter);
        }


    }
}
