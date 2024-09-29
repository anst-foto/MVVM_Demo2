using System.Windows.Input;

namespace MVVM_Demo.WindowModels;

public abstract class CustomCommandBase : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Predicate<object?> _canExecute;
    
    protected CustomCommandBase(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute ?? (_ => true);
    }
    
    public virtual bool CanExecute(object? parameter)
    {
        return _canExecute.Invoke(parameter);
    }

    public virtual void Execute(object? parameter)
    {
        _execute.Invoke(parameter);
    }
    
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}