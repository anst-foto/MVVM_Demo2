using System.Windows;
using MVVM_Demo.WindowModels;

namespace MVVM_Demo.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        //DataContext = new MainWindowModel();
    }
}