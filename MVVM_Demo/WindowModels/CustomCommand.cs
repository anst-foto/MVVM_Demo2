using System.Windows.Input;

namespace MVVM_Demo.WindowModels;

public class CustomCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    : CustomCommandBase(execute, canExecute);