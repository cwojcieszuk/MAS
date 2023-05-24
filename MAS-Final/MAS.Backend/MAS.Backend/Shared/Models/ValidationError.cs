namespace MAS.Backend.Shared.Models;

public class ValidationError
{
    private string _error;
    private bool _isValid;
    
    public string Error
    {
        get => _error;
        set => _error = value;
    }

    public bool IsValid
    {
        get => _isValid;
        set => _isValid = value;
    }
    
    public ValidationError(bool isValid)
    {
        _isValid = isValid;
    }

    public ValidationError(string error, bool isValid)
    {
        _error = error;
        _isValid = isValid;
    }
}