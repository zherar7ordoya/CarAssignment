namespace Integrador.Shared.Validators;

public class ValidationResult
{
    public ValidationResult() { }
    public ValidationResult(List<string> errors)
    {
        Errors = errors;
    }

    public List<string> Errors { get; } = [];
    public bool IsValid => Errors.Count == 0;
}
