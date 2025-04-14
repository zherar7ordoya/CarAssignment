using Integrador.Infrastructure.Logging.Shared;

namespace Integrador.Presentation.UIComponents;

// Changed the access modifier of the ComboBoxItem class from private to internal
internal class ComboBoxItem
{
    public string Text { get; set; } = "";
    public LogLevel? Value { get; set; } // null = "Todos"

    public override string ToString() => Text;
}
