namespace MVVM_Demo.Models;

public class Person : BaseNotifyPropertyChanged
{
    private Guid? _id;
    public Guid? Id
    {
        get => _id;
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
    
    public string FullName => FirstName is null || LastName is null 
        ? "" 
        :$"{LastName} {FirstName}";
}