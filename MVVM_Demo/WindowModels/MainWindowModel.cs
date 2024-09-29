using System.Collections.ObjectModel;
using MVVM_Demo.Models;

namespace MVVM_Demo.WindowModels;

public class MainWindowModel : BaseNotifyPropertyChanged
{
    #region Properties
    private Guid? _id;
    public Guid? Id
    {
        get => _id;
        /*set
        {
            if (_id == value) return;
            
            _id = value;
            OnPropertyChanged(nameof(ID));
        }*/
        set => SetField(ref _id, value);
    }

    private string? _firstName;
    public string? FirstName 
    {
        get => _firstName;
        set => SetField(ref _firstName, value);
    }
    
    private string? _lastName;
    public string? LastName 
    {
        get => _lastName;
        set => SetField(ref _lastName, value);
    }
    
    private int? _age;
    public int? Age
    {
        get => _age;
        set => SetField(ref _age, value);
    }
    
    public ObservableCollection<Person> Persons { get; set; }
    
    private Person? _selectedPerson;
    public Person? SelectedPerson
    {
        get => _selectedPerson;
        set
        {
            if (!SetField(ref _selectedPerson, value)) return;
            
            Id = _selectedPerson?.Id;
            FirstName = _selectedPerson?.FirstName;
            LastName = _selectedPerson?.LastName;
            Age = _selectedPerson?.Age;
        }
    }
    #endregion
    
    #region Commands
    public CustomCommand SaveCommand { get; set; }
    public CustomCommand DeleteCommand { get; set; }
    public CustomCommand ClearCommand { get; set; }
    #endregion
    
    public MainWindowModel()
    {
        Persons =
        [
            new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Age = 25 },
            new Person { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", Age = 30 }
        ];
        
        ClearCommand = new CustomCommand(
            execute: _ => Clear(),
            canExecute: _ => IsNotNullProperties());

        DeleteCommand = new CustomCommand(
            execute: _ => Delete(),
            canExecute: _ => SelectedPerson is not null);
        
        SaveCommand = new CustomCommand(
            execute: _ => Save(),
            canExecute: _ => IsNotNullProperties());
    }
    
    #region Methods
    private bool IsNotNullProperties() =>
        !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && Age is not null;
    
    private void Save()
    {
        if (SelectedPerson is null)
        {
            Persons.Add(new Person
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName!,
                LastName = LastName!,
                Age = Age!.Value
            });
        }
        else
        {
            SelectedPerson.FirstName = FirstName!;
            SelectedPerson.LastName = LastName!;
            SelectedPerson.Age = Age!.Value;
        }
        
        Clear();
    }
    
    private void Delete()
    {
        Persons.Remove(SelectedPerson!);
        
        Clear();
    }
    
    private void Clear()
    {
        Id = Guid.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Age = null;
        
        SelectedPerson = null;
    }
    #endregion
}